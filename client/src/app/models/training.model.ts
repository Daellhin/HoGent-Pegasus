import { Registration, RegistrationJson } from './registration.model';
import { Trainer, TrainerJson } from './trainer.model';

export interface TrainingJson {
  id: number,
  dayOfWeek: number;
  startHour: string;
  endHour: string;
  group: number;
  trainers: TrainerJson[];
  registrations: RegistrationJson[];
}

export interface TrainingTemplatePutJson {
  id: number,
  dayOfWeek: number;
  startHour: string;
  endHour: string;
  group: number;
  trainers: TrainerJson[];
}

export interface TrainingTemplatePostJson {
  dayOfWeek: number;
  startHour: string;
  endHour: string;
  group: number;
  trainers: TrainerJson[];
}

export enum DayOfWeek {
  Sunday = 0,
  Monday = 1,
  Tuesday = 2,
  Wednesday = 3,
  Thursday = 4,
  Friday = 5,
  Saturday = 6
}

const GROUPS: string[] = [
  "Kangoeroes",
  "Benjamins",
  "Pupillen",
  "Miniemen",
  "Cadetten",
  "Scholieren",
  "Junioren",
  "Senioren",
  "Masters",
  "Spurters",
  "Alle Cat.",
  "Min-Sen"
];

const DAYS_OF_WEEK: string[] = [
  'Zondag',
  'Maandag',
  'Dinsdag',
  'Woensdag',
  'Donderdag',
  'Vrijdag',
  'Zaterdag'
];

export { GROUPS };
export { DAYS_OF_WEEK };

export class Training {
  constructor(
    public id: number,
    public dayOfWeek: DayOfWeek,
    public startHour = new Date(),
    public endHour = new Date(),
    public group: number,
    public trainers = new Array<Trainer>(),
    public registrations = new Array<Registration>()
  ) { }


  public static newTraining(id: number): Training {
    return new Training(id, null, null, null, null, null);
  }

  public static fromJSON(json: TrainingJson): Training {
    const training = new Training(
      json.id,
      json.dayOfWeek,
      new Date(json.startHour),
      new Date(json.endHour),
      json.group,
      json.trainers.map(Trainer.fromJSON),
      json.registrations.map(Registration.fromJSON),
    );
    training.sortRegistations();
    return training;
  }

  private sortRegistations(): void {
    this.registrations = this.registrations.sort((a: Registration, b: Registration) => {
      var textA = a.name.toUpperCase();
      var textB = b.name.toUpperCase();
      return (textA < textB) ? -1 : (textA > textB) ? 1 : 0;
    });
  }

  public formattedDayOfWeek(): string {
    return DAYS_OF_WEEK[this.dayOfWeek];
  }

  public shortenedDayOfWeek(): string {
    return `${DAYS_OF_WEEK[this.dayOfWeek].substring(0, 2)}.`;
  }

  public formattedGroup(): string {
    return GROUPS[this.group];
  }

  public formatedStartHour(): string {
    return this.startHour.toTimeString().substr(0,5);
  }

  public formatedEndHour(): string {
    return this.endHour.toTimeString().substr(0,5);
  }

  public trainerNames(): string[] {
    return this.trainers.map(e => e.name);
  }

  public toString(): string {
    return `${this.formattedDayOfWeek()} ${this.trainers.toString()}`;
  }

  update(training: Training) {
    this.dayOfWeek = training.dayOfWeek;
    this.startHour = training.startHour;
    this.endHour = training.endHour;
    this.group = training.group;
    this.trainers = training.trainers;
  }

  public toTrainingTemplatePutJSON(): TrainingTemplatePutJson {
    return <TrainingTemplatePutJson>{
      id: this.id,
      dayOfWeek: this.dayOfWeek,
      startHour:  `0001-01-01T${this.formatedStartHour()}:00`,
      endHour: `0001-01-01T${this.formatedEndHour()}:00`,
      group: this.group,
      trainers: this.trainers.map(e => e.toJSON())
    };
  }

  public toTrainingTemplatePostJSON(): TrainingTemplatePostJson {
    return <TrainingTemplatePostJson>{
      dayOfWeek: this.dayOfWeek,
      startHour: `0001-01-01T${this.formatedStartHour()}:00`,
      endHour: `0001-01-01T${this.formatedEndHour()}:00`,
      group: this.group,
      trainers: this.trainers.map(e => e.toJSON())
    };
  }

  private createDate(hour:string):Date {
    return new Date(null, null, null, parseInt(hour.substr(0,2)),  parseInt(hour.substr(3,2)));
  }

}
