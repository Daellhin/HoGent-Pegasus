import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../material/material.module';
import { ErrorModule } from './../error/error.module';
import { WeekToggleModule } from './../week-toggle/week-toggle.module';
import { ConfirmationComponent } from './confirmation/confirmation.component';
import { RegistrationComponent } from './registration.component';

const routes = [
  { path: 'inschrijven/ingeschreven', component: ConfirmationComponent },
];

@NgModule({
  declarations: [
    RegistrationComponent,
    ConfirmationComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    MaterialModule,
    ErrorModule,
    WeekToggleModule,
    RouterModule.forChild(routes)
  ],
  exports: [
    RegistrationComponent
  ]
})
export class RegistrationModule { }
