import { Component, Input, OnInit } from '@angular/core';
import { Training } from 'src/app/models/training.model';

@Component({
  selector: 'app-training',
  templateUrl: './training.component.html',
  styleUrls: ['./training.component.css']
})
export class TrainingComponent implements OnInit {
  @Input() public training: Training;
  @Input() public expanded: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

}
