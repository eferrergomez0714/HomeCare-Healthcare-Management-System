import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PatientModel } from '../models/patient-model';
import { PatientCreateModel } from '../models/create-patient';
import { PatientMedicalRecords } from '../models/patient-medical-records';

export interface Patient {
  id: number;
  name: string;
  email: string;
  age: number;
  city: string;
}

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  private apiUrl = 'https://localhost:7258/homecare/patients';

  constructor(private http: HttpClient) {}

  getMedicalRecords(patientId: number) {
    return this.http.get<PatientMedicalRecords>(`${this.apiUrl}/${patientId}/medical-records`);
  }

  getPatients(): Observable<PatientModel[]> {
    return this.http.get<PatientModel[]>(this.apiUrl);
  }

  createPatient(patient: PatientCreateModel): Observable<PatientModel> {
    return this.http.post<PatientModel>(this.apiUrl, patient);
  }

  searchPatientsByName(name: string): Observable<PatientModel[]> {
  return this.http.get<PatientModel[]>(
    `${this.apiUrl}/search?name=${encodeURIComponent(name)}`
  );
  }

  searchPatientsByAge(age: number): Observable<PatientModel[]> {
  return this.http.get<PatientModel[]>(
    `${this.apiUrl}/search/age?age=${age}`
  );
  }

  updatePatient(id: number, patient: PatientCreateModel): Observable<PatientModel> {
    return this.http.put<PatientModel>(`${this.apiUrl}/${id}`, patient);
  }
  
  deletePatient(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}