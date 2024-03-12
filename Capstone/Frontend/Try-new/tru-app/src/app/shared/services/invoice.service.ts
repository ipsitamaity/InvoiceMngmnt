import { Injectable } from '@angular/core';
import { HttpClient,HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import {Invoice} from '../model/invoice.model';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {
  private apiUrl = "https://localhost:7047/api/Invoices";
  private baseUrl= "https://localhost:7047/api/Invoices" ;

  constructor(private http: HttpClient) { }
 getInvoices(): Observable<Invoice[]> {
    return this.http.get<Invoice[]>(this.baseUrl);
  }
  /*getInvoices(): Observable<HttpResponse<Invoice[]>> {
    return this.http.get<Invoice[]>(this.baseUrl, { observe: 'response' });
}*/
 
   addInvoice(invoice: Invoice): Observable<any> {
    invoice.invoiceID = Math.floor(Math.random()*1000);
    console.log('invoice',invoice.invoiceID);
    console.log("Calling Post Service");
    console.log(invoice);
    const url = `${this.baseUrl}`;
    return this.http.post<any>(url,invoice);
    }
    updateInvoice(invoice:Invoice): Observable<any> {
        console.log(invoice);
        const url = `${this.apiUrl}/put`;
        return this.http.put<any>(this.baseUrl, invoice);
        }
}
