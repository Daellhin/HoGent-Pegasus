import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeekToggleComponent } from './week-toggle.component';

describe('WeekToggleComponent', () => {
  let component: WeekToggleComponent;
  let fixture: ComponentFixture<WeekToggleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WeekToggleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WeekToggleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
