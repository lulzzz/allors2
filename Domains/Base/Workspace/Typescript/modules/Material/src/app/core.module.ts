import { HttpClientModule } from '@angular/common/http';
import { NgModule, Optional, SkipSelf } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule, NoopAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { MAT_DATE_LOCALE, MAT_DATE_FORMATS, DateAdapter } from '@angular/material';
import { MAT_MOMENT_DATE_FORMATS } from '@angular/material-moment-adapter';

import { environment } from '../environments/environment';

import {
  ErrorService, AllorsModule, AllorsFocusModule, AllorsBarcodeModule, AllorsFilterModule, AllorsRefreshModule, AuthenticationModule, MediaModule, NavigationModule
} from '../allors/angular';

import {
  MomentUtcDateAdapter, DeleteModule, NavigateModule, DialogModule, LoggingModule, ErrorModule, SideNavModule
} from '../allors/material';

@NgModule({
  imports: [
    BrowserModule,
    environment.production ? BrowserAnimationsModule : NoopAnimationsModule,
    RouterModule,
    HttpClientModule,

    AllorsModule.forRoot({ url: environment.url }),
    AuthenticationModule.forRoot({ url: environment.url + environment.authenticationUrl }),
    LoggingModule.forRoot({ console: true }),
    ErrorModule.forRoot({ log: true, display: true }),

    AllorsBarcodeModule.forRoot(),
    AllorsFocusModule.forRoot(),
    AllorsFilterModule.forRoot(),
    AllorsRefreshModule.forRoot(),
    DialogModule.forRoot(),
    MediaModule.forRoot({ url: environment.url }),

    // Menu/Navigation
    NavigationModule.forRoot(),
    SideNavModule.forRoot(),

    // Actions
    DeleteModule.forRoot(),
    NavigateModule.forRoot(),
  ],
  providers: [
    { provide: MAT_DATE_LOCALE, useValue: 'en-GB' },
    { provide: MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS },
    { provide: DateAdapter, useClass: MomentUtcDateAdapter },
  ],
})
export class CoreModule {

  constructor(@Optional() @SkipSelf() core: CoreModule) {
    if (core) {
      throw new Error('Only use CoreModule from AppModule');
    }
  }

}
