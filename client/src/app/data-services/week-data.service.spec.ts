import { TestBed } from '@angular/core/testing';
import { WeekDataService } from './week-data.service';


describe('TrainingDataService', () => {
  let service: WeekDataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WeekDataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
