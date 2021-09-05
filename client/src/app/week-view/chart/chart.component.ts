import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css']
})
export class ChartComponent implements OnInit {
  @Input() input: any[];
  data: any[];

  constructor() {
  }

  ngOnInit(): void {
    this.data = this.input;
  }

}
