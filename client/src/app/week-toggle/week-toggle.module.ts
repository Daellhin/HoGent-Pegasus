import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MaterialModule } from '../material/material.module';
import { WeekToggleComponent } from './week-toggle.component';

@NgModule({
  declarations: [WeekToggleComponent],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports: [
    WeekToggleComponent
  ]
})
export class WeekToggleModule { }
