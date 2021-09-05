import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-week-toggle',
  templateUrl: './week-toggle.component.html',
  styleUrls: ['./week-toggle.component.css']
})
export class WeekToggleComponent implements OnInit {
  @Input() public startDate: Date;
  @Input() public hasPreviousWeek: boolean;
  @Input() public hasNextWeek: boolean;
  @Output() public previousWeek = new EventEmitter<boolean>();

  constructor() { }

  ngOnInit(): void {
  }

  changeWeek(previous:boolean) {
    this.previousWeek.emit(previous);
  }

}
