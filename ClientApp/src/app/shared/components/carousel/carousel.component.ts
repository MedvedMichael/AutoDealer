import { Component, Input, ViewChild } from '@angular/core';
import { NzCarouselComponent } from 'ng-zorro-antd/carousel';

@Component({
  selector: 'app-carousel',
  templateUrl: './carousel.component.html',
  styleUrls: ['./carousel.component.scss'],
})
export class CarouselComponent {
  @Input() images: string[] = [];

  @ViewChild('carousel') carousel!: NzCarouselComponent;

  public onArrowClick(direction: 'left' | 'right'): void {
    const mapDirection = {
      left: () => this.carousel.pre(),
      right: () => this.carousel.next(),
    };

    mapDirection[direction]();
  }
}
