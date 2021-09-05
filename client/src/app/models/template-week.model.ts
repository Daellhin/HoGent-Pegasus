import { Training, TrainingJson } from './training.model';

export interface TemplateWeekJson {
  id: number;
  active: boolean;
  trainings: TrainingJson[];
}

export class TemplateWeek {

  constructor(
    private _id: number,
    private _active: boolean,
    private _trainings: Training[]
  ) { }

  static fromJSON(json: TemplateWeekJson): TemplateWeek {
    let week = new TemplateWeek(
      json.id,
      json.active,
      json.trainings.map(Training.fromJSON)
    );
    week.sortTrainings();
    return week;
  }

  public sortTrainings(): void {
    this._trainings = this._trainings.sort((a: Training, b: Training) => {
      return (a.dayOfWeek + 6) % 7 - (b.dayOfWeek + 6) % 7 || a.startHour.getTime() - b.startHour.getTime();
    });
  }

  public replaceTraining(newTraining:Training): void {
    this.trainings = this.trainings.map(e => (e.id == newTraining.id) ? newTraining : e);
    this.sortTrainings();
  }

  public addTraining(newTraining: Training) {
    this.trainings.push(newTraining);
    this.sortTrainings();
  }

  public hasTrainings(): boolean {
    return this._trainings.length > 0;
  }

  get trainings(): Training[] {
    return this._trainings;
  }

  set trainings(training:Training[]) {
    this._trainings = training;
  }

  get id(): number {
    return this._id;
  }

}
