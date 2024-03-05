import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { InvoiceItem } from '../model/invoiceitem.model';

@Injectable({
  providedIn: 'root'
})

export class InvoiceitemService {
  //private baseUrl = "https://localhost:7047/api/InvoiceItem/";
  private baseUrl = 'https://localhost:7047/api/InvoiceItem';
  constructor(private http: HttpClient) { }
  getInvoiceItems(invoiceID:number): Observable<InvoiceItem[]> {
    const url = `${this.baseUrl}?invoiceID=${invoiceID}`;
    console.log(url);
    return this.http.get<InvoiceItem[]>(url)
    //return this.http.get<InvoiceItem[]>('${this.baseUrl}?invoiceID=${invoiceID}');
  }
}
