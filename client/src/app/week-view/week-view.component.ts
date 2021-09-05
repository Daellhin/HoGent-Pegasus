import { Component, OnInit } from '@angular/core';
import { EMPTY, Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { WeekDataService } from 'src/app/data-services/week-data.service';
import { Week } from 'src/app/models/week.model';
import { AppError } from '../models/app-error.model';

@Component({
  selector: 'app-week-view',
  templateUrl: './week-view.component.html',
  styleUrls: ['./week-view.component.css']
})
export class WeekViewComponent implements OnInit {
  private _currentWeek = 0;
  private _week$: Observable<Week>;

  public appError: AppError;

  constructor(private _weekDataService: WeekDataService) {
  }

  get week$(): Observable<Week> {
    return this._week$;
  }

  changeWeek(previous: boolean) {
    if (previous) {
      this._currentWeek--;
    } else {
      this._currentWeek++;
    }
    this.fetchWeek();
  }

  fetchWeek(): void {
    this._week$ = this._weekDataService.week$(this._currentWeek).pipe(
      catchError(e => this.handleError(e))
    );
  }

  handleError(error) {
    this.appError = AppError.newError(error);
    return EMPTY;
  }

  ngOnInit(): void {
    this.fetchWeek();
  }

}
