import * as moment from 'moment';

export interface BaseAutoDto {
  id: number;
  name: string;
}

export interface Model extends BaseAutoDto {
  brand: BaseAutoDto;
}

export enum FuelType {
  Petrol = 1,
  Diesel = 2,
}

export const FuelTypeLabel: Record<FuelType, string> = {
  [FuelType.Petrol]: 'Petrol',
  [FuelType.Diesel]: 'Diesel',
};

export interface Engine extends BaseAutoDto {
  fuelType: FuelType;
  horsePower: number;
  capacity: number;
}

export enum GearboxType {
  Manual = 1,
  Automatic = 2,
  Variator = 3,
  Robotic = 4,
}

export const GearboxTypeLabel: Record<GearboxType, string> = {
  [GearboxType.Manual]: 'Manual',
  [GearboxType.Automatic]: 'Automatic',
  [GearboxType.Variator]: 'Variator',
  [GearboxType.Robotic]: 'Robotic',
};

export interface Gearbox extends BaseAutoDto {
  type: GearboxType;
}

export interface Generation extends BaseAutoDto {
  startYear: number;
  endYear: number | null;
}

export interface SearchRequest {
  brand: number;
  models: number[];
  generations: number[] | null;
  price: {
    from: number | null;
    to: number | null;
  };
  year: {
    from: number | null;
    to: number | null;
  };
  mileage: {
    from: number | null;
    to: number | null;
  };
}

export interface SaleAnnouncement {
  id: number;
  car: {
    model: Model;
    generation: Generation;
    engine: Engine;
    gearbox: Gearbox;
    equipment: BaseAutoDto;
    year: number;
    color: string;
    ownersCount: number;
    winNumber: string;
    mileage: number;
  };
  price: number;
  city: string;
  ownersCount: number;
  owner: {
    name: string;
    surname: string;
    email: string;
    phone: string;
  };
  description: string;
  createdAt: moment.Moment;
}
