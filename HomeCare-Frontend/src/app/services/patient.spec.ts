import { TestBed } from '@angular/core/testing';
import { Patient, PatientService } from './patient-service';

describe('Patient', () => {
  let service: PatientService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PatientService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
