import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InvoiceComponent } from './invoice/invoice.component';
import { InvoiceitemComponent } from './invoiceitem/invoiceitem.component';

const routes: Routes = [
  { path: 'invoice', component: InvoiceComponent},
  { path: 'invoice-item', component: InvoiceitemComponent },
  { path: '', redirectTo: '/invoice', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
