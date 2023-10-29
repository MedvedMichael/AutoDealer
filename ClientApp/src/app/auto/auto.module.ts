import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';

import { AutoRoutingModule } from './auto-routing.module';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { AntdModule } from '../shared/antd.module';
import { autoFeatureKey, autoReducer } from './store/reducers/auto.reducer';
import { AutoEffects } from './store/effects/auto.effects';

import { AutoCardComponent } from './components/auto-card/auto-card.component';
import { SharedModule } from '../shared/shared.module';
import { AnnouncementPageComponent } from './pages/announcement-page/announcement-page.component';
import { EditAnnouncementPageComponent } from './pages/edit-announcement-page/edit-announcement-page.component';
import { AnnouncementEffects } from './store/effects/announcement.effects';
import {
  announcementFeatureKey,
  announcementReducer,
} from './store/reducers/announcement.reducer';

@NgModule({
  declarations: [
    HomePageComponent,
    AutoCardComponent,
    AnnouncementPageComponent,
    EditAnnouncementPageComponent,
  ],
  imports: [
    CommonModule,
    AutoRoutingModule,
    SharedModule,
    AntdModule,
    ReactiveFormsModule,
    StoreModule.forFeature(autoFeatureKey, autoReducer),
    StoreModule.forFeature(announcementFeatureKey, announcementReducer),
    EffectsModule.forFeature([AutoEffects, AnnouncementEffects]),
  ],
})
export class AutoModule {}
