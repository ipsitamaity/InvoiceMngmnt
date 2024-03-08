import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InvoiceitemComponent } from './invoiceitem.component';

describe('InvoiceitemComponent', () => {
  let component: InvoiceitemComponent;
  let fixture: ComponentFixture<InvoiceitemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InvoiceitemComponent]
    });
    fixture = TestBed.createComponent(InvoiceitemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
