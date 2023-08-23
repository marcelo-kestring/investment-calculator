import { TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { HttpClient } from '@angular/common/http';
import { IResultInvestmentCalculation } from './IResultInvestmentCalculation';

fdescribe('AppComponent', () => {
  let httpStub: Partial<IResultInvestmentCalculation>;
  
  beforeEach(() => {
    httpStub = {
      resultadoBruto: 10.5,
      resultadoLiquido: 10
    };

    TestBed.configureTestingModule({
      declarations: [AppComponent],
      providers: [
        {
          provide: HttpClient,
          useValue: httpStub
        }
      ]
    });
  });

  it('should create the app', () => {
    TestBed.configureTestingModule({
    })
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have as title 'InvestmentCalculatorFrontend'`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app.title).toEqual('AppComponent - Calculate Investment');
  });
  
  it('should render title', () => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('h1')?.textContent).toContain('Investment Calculator');
  });
});
