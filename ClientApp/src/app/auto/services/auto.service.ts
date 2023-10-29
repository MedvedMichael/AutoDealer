import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { API_BASE_URL } from 'src/app/app.module';
import {
  BaseAutoDto,
  Engine,
  FuelType,
  GearboxType,
  Generation,
  SaleAnnouncement,
  SearchRequest,
} from '../interfaces/Auto';
import * as moment from 'moment';

const MOCK_ANNOUNCEMENTS: SaleAnnouncement[] = [
  {
    id: 1,
    car: {
      model: {
        id: 1,
        name: 'A7 Sportback',
        brand: {
          id: 1,
          name: 'Audi',
        },
      },
      generation: {
        id: 1,
        name: 'C7 (FL)',
        startYear: 2008,
        endYear: 2015,
      },
      engine: {
        id: 1,
        name: 'CREC',
        fuelType: FuelType.Petrol,
        horsePower: 333,
        capacity: 3,
      },
      gearbox: {
        id: 1,
        name: 'DSG',
        type: GearboxType.Robotic,
      },
      equipment: {
        id: 1,
        name: 'Premium Plus (Quattro)',
      },
      year: 2017,
      color: 'Grey',
      ownersCount: 4,
      winNumber: 'WAUZZZ4G8GN108742',
      mileage: 125,
    },
    price: 10000,
    city: 'Kyiv',
    ownersCount: 1,
    owner: {
      name: 'John',
      surname: 'Doe',
      email: 'email@gmail.com',
      phone: '+380123456789',
    },

    description: `Audi A7 Spotback ABT Машина своя , я владелец! Полная комплектация , аналогов в Украине нету! 2020 год / 20 тис пробег 3.0 дизель с мягким гибридом Состояние нового авто! Полностью в родной краске! Оригинальный обвес Audi S7 ABT Акустика Bang Olufsen c выезжающими 3D колонками Лазерные фары Динамичное приветствие фар Диски R21 + тормоза Audi S7 Двойные стекла , вентиляция и массаж сидений Камеры 360 3D Дистроник , датчик мертвых зон Большой плюс это динамика и экономия!
    Джерело: https://auto.ria.com/uk/auto_audi_a7_sportback_35216487.html © AUTO.RIA.com™`,
    createdAt: moment(),
  },
];

@Injectable({
  providedIn: 'root',
})
export class AutoService {
  private readonly baseUrl = `${this.apiBaseUrl}/auto`;
  constructor(
    private httpClient: HttpClient,
    @Inject(API_BASE_URL) private apiBaseUrl: string
  ) {}

  public getBrands(): Observable<BaseAutoDto[]> {
    return this.httpClient.get<BaseAutoDto[]>(`${this.baseUrl}/brands`);
  }

  public getModels(
    brandId: number,
    search?: string
  ): Observable<BaseAutoDto[]> {
    const queryParams = new URLSearchParams({ brand: `${brandId}` });
    if (search) {
      queryParams.append('search', search);
    }

    return this.httpClient.get<BaseAutoDto[]>(
      `${this.baseUrl}/models?${queryParams.toString()}`
    );
  }

  public getGenerations = (
    modelId: number,
    search?: string
  ): Observable<Generation[]> => {
    const queryParams = new URLSearchParams({ model: `${modelId}` });
    if (search) {
      queryParams.append('search', search);
    }

    return this.httpClient.get<Generation[]>(
      `${this.baseUrl}/generations?${queryParams.toString()}`
    );
  };

  public getEngines(modelId: number, search?: string): Observable<Engine[]> {
    const queryParams = new URLSearchParams({ model: `${modelId}` });
    if (search) {
      queryParams.append('search', search);
    }

    return this.httpClient.get<Engine[]>(
      `${this.baseUrl}/engines?${queryParams.toString()}`
    );
  }

  public getEquipments(modelId: number): Observable<BaseAutoDto[]> {
    const queryParams = new URLSearchParams({ model: `${modelId}` });

    return this.httpClient.get<BaseAutoDto[]>(
      `${this.baseUrl}/equipments?${queryParams.toString()}`
    );
  }

  public getSaleAnnouncements = (
    search: SearchRequest
  ): Observable<SaleAnnouncement[]> => {
    return of([
      ...MOCK_ANNOUNCEMENTS,
      ...MOCK_ANNOUNCEMENTS,
      ...MOCK_ANNOUNCEMENTS,
      ...MOCK_ANNOUNCEMENTS,
      ...MOCK_ANNOUNCEMENTS,
      ...MOCK_ANNOUNCEMENTS,
      ...MOCK_ANNOUNCEMENTS,
      ...MOCK_ANNOUNCEMENTS,
      ...MOCK_ANNOUNCEMENTS,
      ...MOCK_ANNOUNCEMENTS,
      ...MOCK_ANNOUNCEMENTS,
      ...MOCK_ANNOUNCEMENTS,
    ]);
  };

  public getSaleAnnouncement = (
    id: number
  ): Observable<SaleAnnouncement | null> => {
    return of(MOCK_ANNOUNCEMENTS[0]);
  };
}
