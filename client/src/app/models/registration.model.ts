export interface RegistrationJson {
  timestamp: string;
  name: string;
}

export class Registration {
  constructor(
    private _name: string,
    private _timeStamp?: Date,
  ) { }

  public static fromJSON(json: RegistrationJson): Registration {
    const registration = new Registration(json.name, new Date(json.timestamp));
    return registration;
  }

  public toJSON(): RegistrationJson {
    // Timestamp is set by server
    return <RegistrationJson>{
      name: this.name
    };
  }

  public toString(): string {
    return `${this.timeStamp.toLocaleString()} ${this.name}`;
  }

  get timeStamp(): Date {
    return this._timeStamp;
  }

  get name(): string {
    return this._name;
  }

}
