import { Component, HostBinding, Input } from '@angular/core';

export enum IconType {
  Fuel = 'fuel',
  Speed = 'speed',
  Location = 'location',
  Gearbox = 'gearbox',
}

@Component({
  selector: 'app-icon',
  templateUrl: './icon.component.html',
  styleUrls: ['./icon.component.scss'],
})
export class IconComponent {
  @Input() icon!: IconType;
  @Input() size: number = 24;

  @HostBinding('style.width')
  get hostWidth() {
    return `${this.size}px`;
  }

  @HostBinding('style.height')
  get hostHeight() {
    return `${this.size}px`;
  }

  public get iconPath(): string {
    return `assets/icons/${this.icon}.svg`;
  }
}
