import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { RegistrationComponent } from './registration/registration.component';
import { TemplateViewComponent } from './template-view/template-view.component';
import { WeekViewComponent } from './week-view/week-view.component';

const appRoutes: Routes = [
  { path: 'inschrijven', component: RegistrationComponent },
  { path: 'trainers', component: WeekViewComponent },
  { path: 'weekplanning', component: TemplateViewComponent },
  {
    path: 'changelog',
    loadChildren: () => import('./changelog/changelog.module').then(mod => mod.ChangelogModule)
  },
  { path: '', redirectTo: 'inschrijven', pathMatch: 'full' },

  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  declarations: [],
  exports: [RouterModule]
})
export class AppRoutingModule { }
