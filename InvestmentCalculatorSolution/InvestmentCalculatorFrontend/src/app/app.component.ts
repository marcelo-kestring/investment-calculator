import { Component } from '@angular/core';

import { ResultInvestmentCalculationService } from './resultinvestmentcalculation.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'ApiRequest - Calculate Investment'

  constructor(private resultInvestmentCalculationService: ResultInvestmentCalculationService) { }

  calculateInvestment() : void {
    const amountInput = document.getElementById("amount") as HTMLInputElement;
    const monthsInput = document.getElementById("months") as HTMLInputElement;

    const resultGross = document.getElementById("resultGross") as HTMLInputElement;
    const resultNet = document.getElementById("resultNet") as HTMLInputElement;

    const amount = parseFloat(amountInput.value);
    const months = parseInt(monthsInput.value);

    this.resultInvestmentCalculationService.calculateInvestment(amount, months)
      .subscribe((result) => {
        console.log(result);
        const grossResult = result.resultadoBruto;
        const netResult = result.resultadoLiquido;

        resultGross.textContent = grossResult.toFixed(2);
        resultNet.textContent = netResult.toFixed(2);
      });
  }
}


