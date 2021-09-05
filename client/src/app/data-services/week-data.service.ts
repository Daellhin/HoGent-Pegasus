import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Week } from '../models/week.model';

@Injectable({
  providedIn: 'root'
})
export class WeekDataService {
  constructor(private http: HttpClient) {
  }

  week$(weekOffset: number): Observable<Week> {
    return this.http.get(`${environment.apiUrl}/weeks/${weekOffset}`).pipe(
      map((e: any): Week => Week.fromJSON(e))
    );
  }

  // week$(weekOffset: number): Observable<Week> {
  //   return new Observable(subscriber => {
  //     setTimeout(() => subscriber.next(WEEK), 100);
  //   });
  // }

}
