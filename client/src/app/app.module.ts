import { registerLocaleData } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import localeNl from '@angular/common/locales/nl';
import { LOCALE_ID, NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SimplebarAngularModule } from 'simplebar-angular';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ErrorModule } from './error/error.module';
import { httpInterceptorProviders } from './interceptors/index';
import { MaterialModule } from './material/material.module';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { RegistrationModule } from './registration/registration.module';
import { TemplateViewComponent } from './template-view/template-view.component';
import { TrainingTemplateComponent } from './template-view/training-template/training-template.component';
import { ToolbarComponent } from './toolbar/toolbar.component';
import { UserModule } from './user/user.module';
import { WeekViewModule } from './week-view/week-view.module';

registerLocaleData(localeNl);

@NgModule({
  declarations: [
    AppComponent,
    ToolbarComponent,
    PageNotFoundComponent,
    TemplateViewComponent,
    TrainingTemplateComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MaterialModule,
    ErrorModule,
    WeekViewModule,
    RegistrationModule,
    UserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    SimplebarAngularModule
  ],
  providers: [
    { provide: LOCALE_ID, useValue: 'nl-NL' },
    httpInterceptorProviders
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
