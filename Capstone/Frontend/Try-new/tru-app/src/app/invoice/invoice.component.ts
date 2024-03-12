import { Component, OnInit } from '@angular/core';
import { Invoice } from '../shared/model/invoice.model';
import { InvoiceService } from '../shared/services/invoice.service';
import { InvoiceitemService } from '../shared/services/invoiceitem.service';
//import { MatDialog } from '@angular/material/dialog';
import { AddinvoiceComponent } from '../addinvoice/addinvoice.component';
import { UpdateinvoiceComponent } from '../updateinvoice/updateinvoice.component';
import { Router } from '@angular/router';
import { HttpResponse } from '@angular/common/http';



@Component({
  selector: 'app-invoice',
  templateUrl: './invoice.component.html',
  styleUrls: ['./invoice.component.css']
})
export class InvoiceComponent implements OnInit {
  invoices: Invoice[] = [];
  filteredInvoices: Invoice[]=[];
  selectedFilter: string='';
  error: string = '';
  //constructor(private invoiceService: InvoiceService, public invoiceItem:InvoiceitemService,public matDialog: MatDialog,private router: Router) { }
  insertInvoice:boolean=false;
  updateInvoiceFlg: boolean[] = [false];
  invoiceInst={
    invoiceID:0,
    invoiceNumber:"",
    invoiceDate:"",
    vendorID:0,
    customerID:0,
    totalAmount:0,
    currencyID:0,
    category:""
  };
  title= 'Insert';
  constructor(private invoiceService: InvoiceService, 
    public invoiceItem:InvoiceitemService,
    private router: Router
    ) { }
  ngOnInit() {
    this.fetchInvoices();
    //this.applyFilter('');
  }

  fetchInvoices() {
    this.invoiceService.getInvoices().subscribe(
      invoices => {
        this.invoices = invoices;
        console.log(this.invoices);
        console.log('Response:',Response);
        this.applyFilter('');
         // Verify if data is received
      },
      error => {
        this.error = error; // Handle any errors
      }
    );
  }
  /*fetchInvoices() {
    let responseStatus: number = 0;
    let responseURL: string = '';
        this.invoiceService.getInvoices().subscribe(
          (response: HttpResponse<Invoice[]>) => {
            this.invoices = response.body || [];
            console.log("Status:", response.status);
            console.log("Response URL", response.url || '');
    },
          (error) => {
            console.error('Error:', error);
          }
        );
      }*/
  openAddInvoice() {
    //this.matDialog.open(AddinvoiceComponent, {
      //width: '500px'
      this.insertInvoice=!this.insertInvoice;
    };
    EditInvoice(invoiceIndex: number) {
      this.updateInvoiceFlg[invoiceIndex]=! this.updateInvoiceFlg[invoiceIndex];
     this.invoiceInst = this.invoices[invoiceIndex];
     }
     applyFilter(filterCriteria: string) {
        console.log("in apply-filter");
        console.log(filterCriteria);
      if (filterCriteria === '') {
        this.filteredInvoices = this.invoices;
      } else {
        this.filteredInvoices = this.invoices.filter(invoice => invoice.category === filterCriteria);
      }
    }

}

