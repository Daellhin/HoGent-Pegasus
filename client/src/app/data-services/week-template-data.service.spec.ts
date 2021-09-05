import { TestBed } from '@angular/core/testing';

import { WeekTemplateDataService } from './week-template-data.service';

describe('WeekTemplateDataService', () => {
  let service: WeekTemplateDataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WeekTemplateDataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
