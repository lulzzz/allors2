import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule, Title } from '@angular/platform-browser';

import { AuthenticationConfig, AuthenticationInterceptor, AuthenticationService, DatabaseConfig, AllorsFocusModule, AllorsModule } from '../allors/angular';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { environment } from '../environments/environment';

import { AuthorizationService } from './auth/authorization.service';
import { LoginComponent } from './auth/login.component';

import { FetchComponent } from './fetch/fetch.component';
import { FormComponent } from './form/form.component';
import { HomeComponent } from './home/home.component';
import { QueryComponent } from './query/query.component';

@NgModule({
  bootstrap: [AppComponent],
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    FormComponent,
    QueryComponent,
    FetchComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule,
    AllorsModule.forRoot(),
    AllorsFocusModule.forRoot()
  ],
  providers: [
    Title,
    { provide: DatabaseConfig, useValue: { url: environment.url } },
    { provide: AuthenticationConfig, useValue: { url: environment.url + environment.authenticationUrl} },
    { provide: HTTP_INTERCEPTORS, useClass: AuthenticationInterceptor, multi: true },
    AuthenticationService,
    AuthorizationService,
  ],
})
export class AppModule { }
