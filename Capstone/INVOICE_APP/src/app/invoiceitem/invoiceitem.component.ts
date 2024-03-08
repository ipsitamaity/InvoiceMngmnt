import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { InvoiceItem } from '../shared/model/invoiceitem.model';
import { InvoiceitemService } from '../shared/services/invoiceitem.service';
@Component({
  selector: 'app-invoiceitem',
  templateUrl: './invoiceitem.component.html',
  styleUrls: ['./invoiceitem.component.css']
})
export class InvoiceitemComponent implements OnInit {
  invoiceItem: InvoiceItem[] = [];
  p_invoiceId: number=0;
  //displayedColumns: string[] = ['invoiceId', ..., 'actions'];
  constructor(private invoiceitemService: InvoiceitemService, private route: ActivatedRoute) { }

  ngOnInit():void {
    this.route.params.subscribe(params => {
      this.p_invoiceId = Number(params['invoiceID']);
    this.fetchInvoiceItems();
    });
  }
  
  fetchInvoiceItems() {
    console.log("p_invoiceId",this.p_invoiceId);
    this.invoiceitemService.getInvoiceItems(this.p_invoiceId).subscribe((invoiceItem: InvoiceItem[]) => {
      this.invoiceItem = invoiceItem;
      console.log(invoiceItem);
    });
    
  }

}
