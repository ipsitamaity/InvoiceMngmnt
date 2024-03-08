import { Component, Input} from '@angular/core';
//import { MatDialogRef } from '@angular/material/dialog';
import { InvoiceService } from '../shared/services/invoice.service';
import { Invoice } from '../shared/model/invoice.model';

@Component({
  selector: 'app-addinvoice',
  templateUrl: './addinvoice.component.html',
  styleUrls: ['./addinvoice.component.css']
})
export class AddinvoiceComponent {
  showAddInvoice=true;
  public currentDate= new Date();
  invoice: Invoice={
    invoiceID:0,
    invoiceNumber:"",
    invoiceDate:"",
    vendorID:0,
    customerID:0,
    totalAmount:0,
    currencyID:0,
  };
  @Input() p_title!:string;
   //invoices: Invoice[] = []

  //constructor(public dialogRef: MatDialogRef<AddinvoiceComponent>, private invoiceService: InvoiceService) { }
  constructor(private invoiceService:InvoiceService) {}
  onSubmit() {
    // Call the service to add the invoice
    this.invoiceService.addInvoice(this.invoice)
      .subscribe(
        response => {
          console.log("Invoice added successfully!", response);
          // Close the modal upon successful submission
          //this.dialogRef.close();
          this.closeAddInvoice();
        },
        error => {
          console.error("Failed to add invoice!", error);
          // Handle error if needed
        }
      );
  }
  onClose(){
    this.closeAddInvoice();

  }
  closeAddInvoice(){
    this.showAddInvoice=false;
    location.reload();
  }


}
