import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { MaterialModule } from '../material/material.module';
import { ErrorModule } from './../error/error.module';
import { WeekToggleModule } from './../week-toggle/week-toggle.module';
import { TrainingComponent } from './training/training.component';
import { WeekViewComponent } from './week-view.component';
import { ChartComponent } from './chart/chart.component';

@NgModule({
  declarations: [
    WeekViewComponent,
    TrainingComponent,
    ChartComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    ErrorModule,
    WeekToggleModule,
    NgxChartsModule
  ],
  exports: [
    WeekViewComponent
  ]
})
export class WeekViewModule { }
