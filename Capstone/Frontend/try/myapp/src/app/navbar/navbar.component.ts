import { Component } from '@angular/core';
//import { TaxcalcComponent } from '../taxcalc/taxcalc.component';
import { NavbarService } from '../shared/services/navbar.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})


export class NavbarComponent {
  taxType: string = "";
  inpAmount : number = 0;
  payAmount: number | null = null;
  showForm!: boolean;

  currType: string = "";
  inpCCAmount : number = 0;
  ccAmount: number | null = null;
  showFormCC!: boolean;

  constructor(private navbarService: NavbarService) {}
  toggleForm():void {
    this.showForm = !this.showForm;
    console.log(this.showForm)
  }

  TaxCalc(): void {
    console.log(this.payAmount)
    this.navbarService.getTaxCalc(this.inpAmount, this.taxType).subscribe(result => {
      this.payAmount = result;
      console.log(this.payAmount)
    });
  }


  toggleFormCC():void {
  this.showFormCC = !this.showFormCC;
  console.log(this.showFormCC)
}

CurrConvCalc(): void {
  console.log(this.ccAmount)
  this.navbarService.getccCalc(this.inpCCAmount, this.currType).subscribe(result => {
    this.ccAmount = result;
    console.log(this.ccAmount)
    });
  }
}

 



