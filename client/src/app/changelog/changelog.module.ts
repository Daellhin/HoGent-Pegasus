import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MarkdownModule } from 'ngx-markdown';
import { MaterialModule } from '../material/material.module';
import { ErrorModule } from './../error/error.module';
import { ChangelogComponent } from './changelog.component';

const routes = [
  { path: '', component: ChangelogComponent }
];

@NgModule({
  declarations: [
    ChangelogComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    ErrorModule,
    MarkdownModule.forRoot(),
    RouterModule.forChild(routes)
  ], exports: [
    ChangelogComponent
  ]
})
export class ChangelogModule { }


