import { Component, OnInit } from '@angular/core';
import { AppError } from './../models/app-error.model';

@Component({
  selector: 'app-changelog',
  templateUrl: './changelog.component.html',
  styleUrls: ['./changelog.component.css']
})
export class ChangelogComponent implements OnInit {

  public appError: AppError;
  public loading: boolean = true;

  constructor() {
  }

  ngOnInit(): void {
  }

  onError(error) {
    console.log(error);
    this.loading = false;
    this.appError = AppError.newGenericError("The changelog.md file could not be loaded");
  }

}
