import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CaregiversComponent } from './caregivers';

describe('Caregivers', () => {
  let component: CaregiversComponent;
  let fixture: ComponentFixture<CaregiversComponent >;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CaregiversComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(CaregiversComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
