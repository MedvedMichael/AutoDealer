import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './components/navbar/navbar.component';
import { AntdModule } from '../shared/antd.module';
import { RouterModule } from '@angular/router';
import { MainLayoutComponent } from './components/main-layout/main-layout.component';

@NgModule({
  declarations: [NavbarComponent, MainLayoutComponent],
  imports: [CommonModule, AntdModule, RouterModule],
  exports: [NavbarComponent, MainLayoutComponent],
})
export class CoreModule {}
