import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Trainer } from '../models/trainer.model';
import { TemplateWeek } from './../models/template-week.model';
import { Training } from './../models/training.model';

@Injectable({
  providedIn: 'root'
})
export class WeekTemplateDataService {

  constructor(private http: HttpClient) { }

  week$(): Observable<TemplateWeek> {
    return this.http.get(`${environment.apiUrl}/WeekTemplates`).pipe(
      map((e: any): TemplateWeek => TemplateWeek.fromJSON(e))
    );
  }

  // week$(): Observable<TemplateWeek> {
  //   return new Observable(subscriber => {
  //     setTimeout(() => subscriber.next(TEMPLATE_WEEK), 100);
  //   });
  // }

  trainers$(): Observable<Trainer[]> {
    return this.http.get(`${environment.apiUrl}/WeekTemplates/trainers`).pipe(
      map((e: any[]): Trainer[] => e.map(Trainer.fromJSON))
    );
  }

  // trainers$(): Observable<Trainer[]> {
  //   return new Observable(subscriber => {
  //     setTimeout(() => subscriber.next(TRAINERS), 100);
  //   });
  // }

  createTraining(weektemplateId: number, training: Training): Observable<Training> {
    return this.http.post(`${environment.apiUrl}/WeekTemplates/${weektemplateId}/trainingTemplate`, training.toTrainingTemplatePostJSON()).pipe(
      map((e: any): Training => Training.fromJSON(e))
    );
  }

  updateTraining(weektemplateId: number, training: Training): Observable<Object> {
    return this.http.put(`${environment.apiUrl}/WeekTemplates/${weektemplateId}/trainingTemplate/${training.id}`, training.toTrainingTemplatePutJSON());
  }

  deleteTraining(weektemplateId: number, trainingId: number): Observable<Object> {
    return this.http.delete(`${environment.apiUrl}/WeekTemplates/${weektemplateId}/trainingTemplate/${trainingId}`);
  }

}
