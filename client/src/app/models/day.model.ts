export class Day {
  static DAYS_OF_WEEK: Day[] = [
    new Day('Zondag', 0),
    new Day('Maandag', 1),
    new Day('Dinsdag', 2),
    new Day('Woensdag', 3),
    new Day('Donderdag', 4),
    new Day('Vrijdag', 5),
    new Day('Zaterdag', 6)
  ];

  constructor(
    private _name: string,
    private _index: number
  ) {
  }

  public static daysStartOnMonday(): Day[] {
    let output = [...this.daysStartOnSunday()];
    output.push(output.shift());
    return output;
  }

  public static daysStartOnSunday(): Day[] {
    return Day.DAYS_OF_WEEK;
  }

  get name() {
    return this._name;
  }

  get index() {
    return this._index;
  }
}
