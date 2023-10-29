import { BrowserModule } from '@angular/platform-browser';
import { InjectionToken, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { AppComponent } from './app.component';
import { AuthModule } from './auth/auth.module';
import { AntdModule } from './shared/antd.module';
import { CoreModule } from './core/core.module';
import { AutoModule } from './auto/auto.module';
import { environment } from '@env/environment';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from './shared/shared.module';

export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AuthModule,
    AutoModule,
    AntdModule,
    CoreModule,
    SharedModule,
    RouterModule.forRoot([]),
    StoreModule.forRoot([], { metaReducers: [] }),
    EffectsModule.forRoot([]),
    BrowserAnimationsModule,
  ],
  providers: [
    {
      provide: API_BASE_URL,
      useValue: environment.apiRoot,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
