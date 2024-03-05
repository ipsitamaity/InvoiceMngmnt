import { Component } from '@angular/core';
import { InvoiceService } from '../shared/services/invoice.service';
import { Invoice } from '../shared/model/invoice.model';
import { Input } from '@angular/core';

@Component({
  selector: 'app-updateinvoice',
  templateUrl: './updateinvoice.component.html',
  styleUrls: ['./updateinvoice.component.css']
})
export class UpdateinvoiceComponent {
  @Input() updInvoice!:Invoice;
  constructor( private invoiceService: InvoiceService) {}
  onSubmit(){
    this.invoiceService.updateInvoice(this.updInvoice)
      .subscribe(
        response => {
          console.log('Invoice updated successfully!', response);
  },
  error => {
    console.error('Failed to add invoice!', error);
    // Handle error if needed
  }
  );
}
onClose(): void {
  console.log("Window is closed");
}
}


