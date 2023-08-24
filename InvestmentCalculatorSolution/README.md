# Instruções de Execução e Testes

Esta pasta do repositório contém uma solução que inclui um projeto [backend](https://github.com/marcelo-kestring/investment-calculator/tree/main/InvestmentCalculatorSolution#backend-net-c) em .NET C# e um projeto [frontend](https://github.com/marcelo-kestring/investment-calculator/tree/main/InvestmentCalculatorSolution#frontend-angular-16) em Angular 16.

## Backend (.NET C#)

### Requisitos

- Visual Studio 2022 (versão 17.6.5 ou superior)
- .NET SDK (versão 7.0 ou superior)

### Passos para Execução

1. Abra a solução `InvestmentCalculatorSolution.sln` no Visual Studio.
2. No `Solution Explore`, clique na solução e depois em `Restaurar Pacotes do Nuget`.
3. No `Solution Explore` novamente, clique na opção `Build` da solução.
4. Se você já tiver realizado os passos 1, 2 e 3 para a execução do Frontend, execute a aplicação pressionando `F5` ou selecionando `Depurar > Iniciar Depuração`, onde o sistema deve iniciar o backend e frontend, sendo possível utilizá-lo.

### Testes

1. No Visual Studio, abra a janela de Test Explorer.
2. Clique em Executar Todos os Testes para executar os testes unitários.

### Visualização da Cobertura de Testes

Para visualizar a cobertura de testes

1. Utilize o ReportGenerator em [https://reportgenerator.io/usage](https://reportgenerator.io/usage) para gerar relatórios de cobertura de testes.
2. Siga as instruções fornecidas na página de uso do ReportGenerator para gerar e visualizar os relatórios.

## Frontend (Angular 16)

### Requisitos

- Node.js (versão 18.17.1 ou superior)
- Angular CLI (versão 16.2.0 ou superior)

### Passos para Execução (caso queira executar apenas o frontend ou até o passo 2 para instalar dependências do frontend)

1. Abra o terminal e navegue até a pasta do projeto frontend (`InvestmentCalculatorFrontend`).
2. Execute o comando `npm install` para instalar as dependências.
3. Execute o comando `ng serve` para iniciar o servidor de desenvolvimento.
4. Acesse a aplicação no navegador através da URL `http://localhost:4200`.

### Testes

1. No terminal, navegue até a pasta do projeto frontend (`InvestmentCalculatorFrontend`).
2. Execute o comando `ng test` para executar os testes unitários.

---

Sinta-se à vontade para entrar em contato (marcelo.kestring@outlook.com) se precisar de ajuda com a execução, testes ou qualquer outra parte da solução.
