import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { EMPTY, forkJoin, Observable, Subject } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { TrainingDataService } from 'src/app/data-services/training-data.service';
import { WeekDataService } from 'src/app/data-services/week-data.service';
import { Registration } from 'src/app/models/registration.model';
import { Training } from 'src/app/models/training.model';
import { Week } from 'src/app/models/week.model';
import { AppError } from '../models/app-error.model';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
// Source https://coryrylan.com/blog/creating-a-dynamic-checkbox-list-in-angular
export class RegistrationComponent implements OnInit {
  private _currentWeek = 0;
  public displayedColumns: string[] = ['select', 'dayOfWeek', 'startHour', 'endHour', 'group', 'trainers'];

  public registration: FormGroup;
  private _week$: Observable<Week>;
  private _guiWeek$: Subject<Week> = new Subject<Week>();
  private _trainings: Training[];

  public appError: AppError;

  constructor(private _fb: FormBuilder,
    private _weekDataService: WeekDataService,
    private _trainingDataService: TrainingDataService,
    private _router: Router
  ) {
  }

  get guiWeek$(): Observable<Week> {
    return this._guiWeek$;
  }

  get trainingsFormArray(): FormArray {
    return this.registration.controls.trainings as FormArray;
  }

  private addCheckboxes(): void {
    this._trainings.forEach(() => this.trainingsFormArray.push(new FormControl(false)));
  }

  minSelectedCheckboxes(min = 1): ValidatorFn {
    const validator: ValidatorFn = (formArray: FormArray) => {
      const totalSelected = formArray.controls
        // get a list of checkbox values (boolean)
        .map(control => control.value)
        // total up the number of checked checkboxes
        .reduce((prev, next) => next ? prev + next : prev, 0);

      // if the total is not greater than the minimum, return the error message
      return totalSelected >= min ? null : { required: true };
    };
    return validator;
  }

  toggleCheckbox(row: number) {
    this.trainingsFormArray.controls[row].patchValue(!this.registration.value.trainings[row]);
    this.registration.get('trainings').markAsTouched();
  }

  submit() {
    let requests = [];
    let name: string = this.registration.value.name;
    let selectedTrainings: Training[] = this.registration.value.trainings;

    selectedTrainings.forEach((selected, index: number) => {
      if (selected) {
        let registration: Registration = new Registration(name);
        let training: Training = this._trainings[index];
        requests.push(this._trainingDataService.addNewRegistration(training.id, registration));
      }
    });

    forkJoin(requests)
      .pipe(catchError(e => this.handleError(e)))
      .subscribe(() => {
        this._router.navigate(['inschrijven/ingeschreven']);
      });
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

    this._week$.subscribe(week => {
      this._trainings = week.trainings;
      this.addCheckboxes();
      this._guiWeek$.next(week);
    });
  }

  handleError(error) {
    this.appError = AppError.newError(error);
    return EMPTY;
  }

  ngOnInit(): void {
    this.registration = this._fb.group({
      name: ["", Validators.required],
      trainings: this._fb.array([], this.minSelectedCheckboxes(1))
    })

    this.fetchWeek();
  }

}
