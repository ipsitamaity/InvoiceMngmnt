import { TestBed } from '@angular/core/testing';

import { InvoiceitemService } from './invoiceitem.service';

describe('InvoiceitemService', () => {
  let service: InvoiceitemService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InvoiceitemService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
