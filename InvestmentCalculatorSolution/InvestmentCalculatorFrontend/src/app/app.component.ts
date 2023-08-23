import { Component } from '@angular/core';

import { ResultInvestmentCalculationService } from './resultinvestmentcalculation.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'AppComponent - Calculate Investment'

  constructor(private resultInvestmentCalculationService: ResultInvestmentCalculationService) { }

  calculateInvestment() : void {
    const amountInput = document.getElementById("amount") as HTMLInputElement;
    const monthsInput = document.getElementById("months") as HTMLInputElement;

    const resultGross = document.getElementById("resultGross") as HTMLInputElement;
    const resultNet = document.getElementById("resultNet") as HTMLInputElement;

    const errorMessages: string[] = [];

    if (!isValidMonetaryValue(amountInput.value)) {
      errorMessages.push(' - Informe um valor monetário positivo para o campo Valor Monetário.');
    }

    if (!isValidPositiveInteger(monthsInput.value)) {
      errorMessages.push(' - Informe um número inteiro maior que 1 (um) para o campo Prazo.');
    }

    if (errorMessages.length > 0) {
      alert(errorMessages.join('\n'));
      return;
    }

    const amount = parseFloat(amountInput.value);
    const months = parseInt(monthsInput.value);

    this.resultInvestmentCalculationService.calculateInvestment(amount, months)
      .subscribe((result) => {
        const grossResult = result.resultadoBruto;
        const netResult = result.resultadoLiquido;

        resultGross.textContent = grossResult.toFixed(2);
        resultNet.textContent = netResult.toFixed(2);
      });
  }
}

function isValidMonetaryValue(value: string): boolean {
  // Remove espaços em branco e vírgulas
  value = value.replace(/\s+/g, '').replace(/,/g, '');

  // Verifica se o valor é numérico e positivo
  if (!isNaN(parseFloat(value)) && parseFloat(value) >= 0) {
    // Verifica se o valor tem no máximo duas casas decimais
    if ((value.indexOf('.') === -1) || (value.split('.')[1].length <= 2)) {
      return true;
    }
  }
  return false;
}

function isValidPositiveInteger(value: string): boolean {
  const parsedValue = parseInt(value, 10);
  return Number.isInteger(parsedValue) && parsedValue > 1;
}
