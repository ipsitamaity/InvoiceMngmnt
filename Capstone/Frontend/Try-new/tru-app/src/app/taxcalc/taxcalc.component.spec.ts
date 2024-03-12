import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaxcalcComponent } from './taxcalc.component';

describe('TaxcalcComponent', () => {
  let component: TaxcalcComponent;
  let fixture: ComponentFixture<TaxcalcComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TaxcalcComponent]
    });
    fixture = TestBed.createComponent(TaxcalcComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
