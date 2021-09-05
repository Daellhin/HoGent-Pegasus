import { Training, TrainingJson } from './training.model';

export interface WeekJson {
  start: string;
  message: string;
  trainings: TrainingJson[];
  hasPreviousWeek: boolean;
  hasNextWeek: boolean;
}

export class Week {
  // Graph data is 'cached' in variable
  // because the data is requested way to much by ngr-charts when hovering or rescaling (up to 500 times per action)
  private _graphData = this.calculateGraphData();

  constructor(
    private _start = new Date(),
    private _message: string,
    private _trainings: Training[],
    private _hasPreviousWeek: boolean,
    private _hasNextWeek: boolean
  ) { }

  static fromJSON(json: WeekJson): Week {
    let week = new Week(
      new Date(json.start),
      json.message,
      json.trainings.map(Training.fromJSON),
      json.hasPreviousWeek,
      json.hasNextWeek
    );
    week.sortTrainings();
    return week;
  }

  private sortTrainings(): void {
    this._trainings = this._trainings.sort((a: Training, b: Training) => {
      return (a.dayOfWeek + 6) % 7 - (b.dayOfWeek + 6) % 7 || a.startHour.getTime() - b.startHour.getTime();
    });
  }

  public hasTrainings(): boolean {
    return this._trainings.length > 0;
  }

  public hasActivePreviousWeek(): boolean {
    return this._hasPreviousWeek && (new Date() <= this._start);
  }

  private calculateGraphData(): any[] {
    this.sortTrainings();
    let data = [];
    this.trainings.forEach(e => {
      data.push({
        name: `${e.shortenedDayOfWeek()} ${e.formattedGroup()}`,
        value: e.registrations.length
      });
    });
    return data;
  }

  public get graphData(): any[] {
    return this._graphData;
  }

  get start(): Date {
    return this._start;
  }

  get message(): string {
    return this._message;
  }

  get trainings(): Training[] {
    return this._trainings;
  }

  set trainings(training:Training[]) {
    this._trainings = training;
  }

  get hasPreviousWeek(): boolean {
    return this._hasPreviousWeek;
  }

  get hasNextWeek(): boolean {
    return this._hasNextWeek;
  }

}
