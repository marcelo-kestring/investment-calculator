import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { API_PATH } from 'src/environments/environment';
import { IResultInvestmentCalculation } from './IResultInvestmentCalculation';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ResultInvestmentCalculationService {

  constructor(private httpClient: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Access-Control-Allow-Origin': '*',
      'Access-Control-Allow-Headers': 'X-API-KEY, Origin, X-Requested-With, Content-Type, Accept, Access-Control-Request-Method, Authorization',
      'Access-Control-Allow-Methods': 'GET, POST, OPTIONS, PUT, DELETE, PATCH'
    })
  }

  calculateInvestment(amount: number, months: number): Observable<IResultInvestmentCalculation> {
    return this.httpClient.get<IResultInvestmentCalculation>(`${API_PATH}api/Investimentos/calculo/cdb?valor=${amount}&prazo=${months}`, this.httpOptions);
  }
}
