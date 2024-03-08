import { Component } from '@angular/core';
import { NavbarService } from '../shared/services/navbar.service';

@Component({
  selector: 'app-taxcalc',
  templateUrl: './taxcalc.component.html',
  styleUrls: ['./taxcalc.component.css']
})
export class TaxcalcComponent {
  taxType: string = "";
  inpAmount : number = 0;
  payAmount: number | null = null;
  showForm!: boolean;
  constructor(private navbarService: NavbarService) { }
  TaxCalc(): void {
    console.log(this.payAmount)
    this.navbarService.getTaxCalc(this.inpAmount, this.taxType).subscribe(result => {
      this.payAmount = result;
      console.log(this.payAmount)
  });

}
}
