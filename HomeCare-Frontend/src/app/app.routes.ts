import { Routes } from '@angular/router';
import { PatientsComponent } from './patients/patients';
import { CaregiversComponent } from './caregivers/caregivers';


export const routes: Routes = [
  {
    path: '',
    redirectTo: 'patients',
    pathMatch: 'full'
  },
  {
    path: 'patients',
    component: PatientsComponent
  },
  {
    path: 'caregivers',
    component: CaregiversComponent
  }
];
