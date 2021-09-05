export interface TrainerJson {
  name: string;
}
export class Trainer {
  constructor(private _name: string) { }

  static fromJSON(json: TrainerJson): Trainer {
    const trainer = new Trainer(json.name);
    return trainer;
  }

  public toString(): string {
    return `${this.name}`;
  }

  get name(): string {
    return this._name;
  }

  public toJSON(): Trainer {
    return <Trainer>{
      name: this.name
    };
  }

}
