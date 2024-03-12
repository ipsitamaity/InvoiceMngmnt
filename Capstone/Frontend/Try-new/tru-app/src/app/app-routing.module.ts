import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InvoiceComponent } from './invoice/invoice.component';
import { InvoiceitemComponent } from './invoiceitem/invoiceitem.component';
import { LoginComponent } from './login/login.component';
import { AuthgardService } from './shared/authgard.service';

const routes: Routes = [
  { path: 'invoice', component: InvoiceComponent, canActivate: [AuthgardService]},
  { path: 'login', component: LoginComponent },
  { path: 'invoice-item', component: InvoiceitemComponent },
  { path: '**', redirectTo: '/invoice', pathMatch: 'full' },
  { path: '', redirectTo: '/invoice', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
