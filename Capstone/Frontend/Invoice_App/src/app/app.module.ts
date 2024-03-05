import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { InvoiceComponent } from './invoice/invoice.component';
import { InvoiceService } from './shared/services/invoice.service';
import { InvoiceitemComponent } from './invoiceitem/invoiceitem.component';
import { NavbarComponent } from './navbar/navbar.component';
import { RouterModule } from '@angular/router';
import { AddinvoiceComponent } from './addinvoice/addinvoice.component';
import { FormsModule } from '@angular/forms';
import { UpdateinvoiceComponent } from './updateinvoice/updateinvoice.component';
import { TaxcalcComponent } from './taxcalc/taxcalc.component';
//import { MatDialogModule } from '@angular/material/dialog';


@NgModule({
  declarations: [
    AppComponent,
    InvoiceComponent,
    InvoiceitemComponent,
    NavbarComponent,
    AddinvoiceComponent,
    UpdateinvoiceComponent,
    TaxcalcComponent,
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    FormsModule
  ],
  providers: [InvoiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
