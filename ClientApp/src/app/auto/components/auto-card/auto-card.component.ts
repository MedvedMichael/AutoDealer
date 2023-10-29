import { Component, Input } from '@angular/core';
import {
  FuelTypeLabel,
  GearboxTypeLabel,
  SaleAnnouncement,
} from '../../interfaces/Auto';
import { IconType } from 'src/app/shared/components/icon/icon.component';

@Component({
  selector: 'app-auto-card',
  templateUrl: './auto-card.component.html',
  styleUrls: ['./auto-card.component.scss'],
})
export class AutoCardComponent {
  @Input() announcement!: SaleAnnouncement;
  iconType = IconType;
  fuelTypeLabel = FuelTypeLabel;
  gearboxTypeLabel = GearboxTypeLabel;

  constructor() {}

  public get price(): string {
    const formatter = new Intl.NumberFormat('en-US', {
      minimumFractionDigits: 0,
      maximumFractionDigits: 0,
    });

    return formatter.format(this.announcement.price);
  }

  public get engineCapacity(): string {
    const formatter = new Intl.NumberFormat('en-US', {
      minimumFractionDigits: 1,
      maximumFractionDigits: 1,
    });

    return formatter.format(this.announcement.car.engine.capacity);
  }

  public get description(): string {
    const maxNumberOfCharacters = 250;
    return (
      this.announcement.description.slice(0, maxNumberOfCharacters) +
      (this.announcement.description.length >= maxNumberOfCharacters
        ? '...'
        : '')
    );
  }
}
