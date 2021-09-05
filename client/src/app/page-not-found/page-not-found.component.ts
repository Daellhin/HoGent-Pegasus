import { Component, OnInit } from '@angular/core';
import { AppError } from './../models/app-error.model';

@Component({
  selector: 'app-page-not-found',
  templateUrl: './page-not-found.component.html',
  styleUrls: ['./page-not-found.component.css']
})
export class PageNotFoundComponent implements OnInit {

  public appError:AppError = AppError.newNotFoundError();

  constructor() { }

  ngOnInit(): void {
  }

}
