import { Component, Input, OnInit } from '@angular/core';
import { AppError } from './../models/app-error.model';

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.css']
})
export class ErrorComponent implements OnInit {
  @Input() public appError: AppError = null;

  constructor() { }

  ngOnInit(): void {
  }

}
