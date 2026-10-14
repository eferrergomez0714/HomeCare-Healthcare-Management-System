import { Component } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { CaregiversService } from '../services/caregivers-service';
import { CaregiversModel } from '../models/caregivers-model';
import { CreateCaregivers } from '../models/create-caregivers';
import { FormsModule } from '@angular/forms';
import { JsonPipe } from '@angular/common';

@Component({
  imports: [FormsModule, JsonPipe],
  selector: 'app-caregivers',
  styleUrl: './caregivers.css',
  templateUrl: './caregivers.html',
  standalone: true
})
export class CaregiversComponent {
  caregivers: CaregiversModel[] = [];

  newCareGiver: CreateCaregivers = {
    name: '',
    email: '',
    rate: 0,
    city: ''
  };

  constructor(private caregiversService: CaregiversService) {}

  getCaregivers(): void {
    this.caregiversService.getCaregivers()
      .subscribe({
        next: (data: CaregiversModel[]) => {
          this.caregivers = data;
        },
        error: (error: HttpErrorResponse) => {
          console.error('API ERROR:', error);
        }
      });
  }

  createCaregiver(): void {
    this.caregiversService.createCaregiver(this.newCareGiver).subscribe({
      next: (caregiver: CaregiversModel) => {
        this.getCaregivers(); // Refresh the list after creating a new caregiver
        this.newCareGiver = {
        name: '',
        email: '',
        rate: 0,
        city: ''
      };
      },
      error: (error: HttpErrorResponse) => {
        console.error('API ERROR:', error);
      }
    });
  }
}
