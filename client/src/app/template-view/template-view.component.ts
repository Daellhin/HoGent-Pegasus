import { Component, OnInit } from '@angular/core';
import { EMPTY, Observable, Subject } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { WeekTemplateDataService } from '../data-services/week-template-data.service';
import { AppError } from '../models/app-error.model';
import { Trainer } from '../models/trainer.model';
import { TemplateWeek } from './../models/template-week.model';
import { Training } from './../models/training.model';

@Component({
  selector: 'app-template-view',
  templateUrl: './template-view.component.html',
  styleUrls: ['./template-view.component.css']
})
export class TemplateViewComponent implements OnInit {
  public appError: AppError;
  public week: TemplateWeek;
  public possibleTrainers$: Observable<Trainer[]>;
  public trainings$: Subject<Training[]> = new Subject<Training[]>();
  public newTrainings: Training[] = []; // objects in array only a negative id

  constructor(private _weekTemplateDataService: WeekTemplateDataService) { }

  updateTraining(newTraining: Training) {
    this._weekTemplateDataService.updateTraining(this.week.id, newTraining)
      .subscribe(() => {
        this.week.replaceTraining(newTraining);
        this.trainings$.next(this.week.trainings);
      });
  }

  createTraining(newTraining: Training) {
    newTraining
    this._weekTemplateDataService.createTraining(this.week.id, newTraining)
      .subscribe(e => {
        this.newTrainings = this.newTrainings.filter(j => j.id != newTraining.id);
        this.week.addTraining(e);
        this.trainings$.next(this.week.trainings);
      });
  }

  addEmptyTraining() {
    let max = 1;
    if (this.newTrainings.length != 0) {
      max = (Math.max.apply(Math, this.newTrainings.map(e => -e.id)) + 1);
    }
    this.newTrainings.push(Training.newTraining(-max));
  }

  deleteEmptyTraining(training: Training) {
    this.newTrainings = this.newTrainings.filter(j => j.id != training.id);
  }

  deleteTraining(training: Training) {
    this._weekTemplateDataService.deleteTraining(this.week.id, training.id)
      .pipe(catchError(e => this.handleError(e)))
      .subscribe(() => {
        this.week.trainings = this.week.trainings.filter(e => e.id != training.id);
        this.trainings$.next(this.week.trainings);
      });
  }

  handleError(error) {
    this.appError = AppError.newError(error);
    return EMPTY;
  }

  ngOnInit(): void {
    this._weekTemplateDataService.week$().pipe(
      catchError(e => this.handleError(e))
    ).subscribe(e => {
      this.week = e;
      this.trainings$.next(this.week.trainings);
    });

    this.possibleTrainers$ = this._weekTemplateDataService.trainers$().pipe(
      catchError(e => this.handleError(e))
    );
  }

}
