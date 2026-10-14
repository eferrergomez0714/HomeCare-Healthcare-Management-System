import { Component, OnInit } from '@angular/core';
import { PatientService } from '../services/patient-service';
import { PatientModel } from '../models/patient-model';
import { HttpErrorResponse } from '@angular/common/http';
import { JsonPipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PatientCreateModel } from '../models/create-patient';
import { PatientMedicalRecords } from '../models/patient-medical-records';

@Component({
  selector: 'app-patients',
  standalone: true,
  imports: [JsonPipe, FormsModule],
  templateUrl: './patients.html',
  styleUrl: './patients.css'
})
export class PatientsComponent {

  patients: PatientModel[] = [];

  newPatient: PatientCreateModel = {
    name: '',
    email: '',
    age: 0,
    city: ''
  };

  searchName = '';

  searchAge = 0;

  updatePatientId = 0;

  deletePatientId = 0;

  showPatients = false;

  medicalRecordsPatientId: number = 0;

  medicalRecords: PatientMedicalRecords | null = null;

  constructor(private patientService: PatientService) {}

  getMedicalRecords() {

  this.patientService
    .getMedicalRecords(this.medicalRecordsPatientId)
    .subscribe({
      next: (response: PatientMedicalRecords) => {
        this.medicalRecords = response;
      },
      error: (error: HttpErrorResponse) => {
        console.error('Error getting medical records:', error);
        this.medicalRecords = null;
      }
    });

}

openMedicalRecord(url: string) {
  window.open(url, '_blank');
}

  searchPatients(): void {

  this.patientService.searchPatientsByName(this.searchName)
    .subscribe({

      next: (data: PatientModel[]) => {
        this.patients = data;
      },

      error: (error: HttpErrorResponse) => {
        console.error('Search error:', error);
      }

    });
}

  refreshPatients(): void {
  this.patientService.getPatients().subscribe({
    next: (data: PatientModel[]) => {
      this.patients = data;
      this.showPatients = true;
    },
    error: (error: HttpErrorResponse) => {
      console.error('Error refreshing patients:', error);
    }
  });
}

  getPatients(): void {

  if (this.patients.length === 0) {
    this.patientService.getPatients().subscribe({
      next: (data: PatientModel[]) => {
        this.patients = data;
        this.showPatients = true;
      },
      error: (error: HttpErrorResponse) => {
        console.error('API ERROR:', error);
      }
    });
  } else {
    this.showPatients = !this.showPatients;
  }
}

  createPatient(): void {

  this.patientService.createPatient(this.newPatient).subscribe({

    next: (patient: PatientModel) => {
      console.log('Patient created:', patient);
      this.newPatient = {
        name: '',
        email: '',
        age: 0,
        city: ''
      };
      this.refreshPatients();
      
    },

    error: (error: HttpErrorResponse) => {
      console.error('Error creating patient:', error);
    }

  });
}

updatePatient(id: number): void {

  this.patientService.updatePatient(id, this.newPatient).subscribe({

    next: (updatedPatient: PatientModel) => {
      console.log('Patient updated:', updatedPatient);

      this.newPatient = {
        name: '',
        email: '',
        age: 0,
        city: ''
      };
      this.refreshPatients();
    },

    error: (error: HttpErrorResponse) => {
      console.error('Error updating patient:', error);
    }

  });
}

searchPatientsByAge(): void {

  this.patientService.searchPatientsByAge(this.searchAge)
    .subscribe({

      next: (data: PatientModel[]) => {
        this.patients = data;
      },

      error: (error: HttpErrorResponse) => {
        console.error('Age search error:', error);
      }

    });
}
deletePatient(id: number): void {

  this.patientService.deletePatient(id).subscribe({

    next: () => {
      console.log('Patient deleted with ID:', id);
      this.refreshPatients(); // Refresh the list after deleting a patient
    },

    error: (error: HttpErrorResponse) => {
      console.error('Error deleting patient:', error);
    }

  });
}
}
