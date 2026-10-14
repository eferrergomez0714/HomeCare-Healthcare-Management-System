import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CaregiversModel } from '../models/caregivers-model';
import { CreateCaregivers } from '../models/create-caregivers';

@Injectable({
  providedIn: 'root'
})
export class CaregiversService {

    private apiUrl = 'https://localhost:7258/homecare/caregivers';

  constructor(private http: HttpClient) {}

  getCaregivers(): Observable<CaregiversModel[]> {
    return this.http.get<CaregiversModel[]>(`${this.apiUrl}`);
  }

  createCaregiver(caregiver: CreateCaregivers): Observable<CaregiversModel> {
    return this.http.post<CaregiversModel>(`${this.apiUrl}`, caregiver);
  }
}
