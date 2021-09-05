import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Day } from 'src/app/models/day.model';
import { Trainer } from 'src/app/models/trainer.model';
import { GROUPS, Training } from 'src/app/models/training.model';

@Component({
  selector: 'app-training-template',
  templateUrl: './training-template.component.html',
  styleUrls: ['./training-template.component.css']
})
export class TrainingTemplateComponent implements OnInit {
  public npxSimplebarOptions = {
    autoHide: false,
    scrollbarMaxSize: 55,
    clickOnTrack: false
  };

  @Input() public training: Training;  //negative id means that the component is used for creating a training
  @Input() public possibleTrainers: Trainer[];
  @Output() public update = new EventEmitter<Training>();
  @Output() public delete = new EventEmitter<Training>();

  public trainingForm: FormGroup;
  public GROUPS = GROUPS; // Is it posible to directly import variables in the template html?
  public DAYS_OF_WEEK = Day.daysStartOnMonday();

  constructor(private fb: FormBuilder) {
  }

  public isUpdateComponent(): boolean {
    return this.training.id > 0;
  }

  minArrayLength(min = 1): ValidatorFn {
    const validator: ValidatorFn = (e: FormControl) => {
      return e.value?.length >= min ? null : { required: true };
    };
    return validator;
  }

  ngOnInit(): void {
    this.trainingForm = this.fb.group({
      dayOfWeek: [, [Validators.required]],
      startHour: [, [Validators.required]],
      endHour: [, [Validators.required]],
      group: [, [Validators.required]],
      trainers: [, [this.minArrayLength(1)]]
    });
    if (this.isUpdateComponent()) {
      this.resetTraining();
    }
  }

  public updateTraining() {
    let neWtraining = new Training(
      this.training.id,
      this.trainingForm.get("dayOfWeek").value,
      new Date("0001-01-01T" + this.trainingForm.get("startHour").value + ":00"),
      new Date("0001-01-01T" + this.trainingForm.get("endHour").value + ":00"),
      this.trainingForm.get("group").value,
      this.trainingForm.get("trainers").value.map(e => this.possibleTrainers.find(f => f.name == e)),
    );
    this.update.emit(neWtraining);
  }

  public resetTraining() {
    this.trainingForm.patchValue({
      dayOfWeek: this.training.dayOfWeek,
      startHour: this.training.formatedStartHour(),
      endHour: this.training.formatedEndHour(),
      group: this.training.group,
      trainers: this.training.trainers.map(e => e.name)
    })
  }

  public deleteTraining() {
    this.delete.emit(this.training);
  }

}
