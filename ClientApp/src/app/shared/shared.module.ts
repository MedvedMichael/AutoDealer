import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotificationComponent } from './components/notification/notification.component';
import { IconComponent } from './components/icon/icon.component';
import { CarouselComponent } from './components/carousel/carousel.component';
import { AntdModule } from './antd.module';

@NgModule({
  declarations: [NotificationComponent, IconComponent, CarouselComponent],
  imports: [CommonModule, AntdModule],
  exports: [NotificationComponent, IconComponent, CarouselComponent],
})
export class SharedModule {}
