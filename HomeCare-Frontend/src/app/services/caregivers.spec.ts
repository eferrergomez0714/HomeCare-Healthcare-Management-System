import { TestBed } from '@angular/core/testing';
import { CaregiversService } from './caregivers-service';

describe('Caregivers', () => {
  let service: CaregiversService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CaregiversService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
