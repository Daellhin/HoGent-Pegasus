import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Registration } from '../models/registration.model';

@Injectable({
  providedIn: 'root'
})
export class TrainingDataService {

  constructor(private http: HttpClient) {
  }

  addNewRegistration(trainingId: number, registration: Registration) {
    return this.http
      .post(`${environment.apiUrl}/trainings/${trainingId}/registrations/`, registration.toJSON())
  }

}
