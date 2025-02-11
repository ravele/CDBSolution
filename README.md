# CDB Calculator Solution (CDBSolution) 📈

Este repositório contém a solução **CDB Calculator**, desenvolvida com:
- **Frontend**: Angular + TypeScript
- **Backend**: .NET Core 8.0 Web API
- **Teste Unitário**: xUnit com Moq e Bogus

## 🚀 Funcionalidades
- Cálculo de investimentos em CDB baseado no CDI e taxa bancária fixa.
- Interface simples para entrada de valores e visualização dos resultados (bruto e líquido).
- Validação de regras de negócio robusta no backend.
- Testes unitários com cobertura superior a 90%.

## 📂 Estrutura do Projeto

📂 CDBSolution 
	├── 📁 CDB.WebApi │
		├── Controllers │
		├── Program.cs │
		└── appsettings.json │
	├── 📁 CDB.Domain │
		└── Services │
	├── 📁 CDB.UnitTests │
		├── Mocks │
		└── Units │
	├── 📁 CDB.AngularApp │
		├── src │
		└── angular.json
└── README.md

## 🛠️ Pré-requisitos

Antes de executar o projeto, certifique-se de ter instalado:
- [.NET SDK 8.0](https://dotnet.microsoft.com/download)
- [Node.js 16+](https://nodejs.org) e [npm 8+](https://www.npmjs.com/)
- [Angular CLI](https://angular.io/guide/setup-local) (`npm install -g @angular/cli`)

## 🏃‍♂️ Como Executar

### 1 Backend (.NET Core 8.0)
1. Navegue até a pasta `CDB.WebApi`:  
   ```bash
   cd CDBSolution/CDB.WebApi
   
2. Execute a aplicação:
   ```bash
   dotnet run
   
3. A API estará disponível em: http://localhost:7001/api/cdb (Ou outra porta configurada)

### 2 Frontend (Angular)
1. Navegue até a pasta CDB.AngularApp:
   ```bash
   cd CDBSolution/CDB.AngularApp
   
2. Instale as dependências do projeto:
   ```bash
   npm install
   
3. Execute o frontend:
   ```bash
   ng serve
   
4. Acesse o frontend em: http://localhost:4200

### 3 Como Executar os Testes Unitários
1. Navegue até a pasta CDB.UnitTests:
   ```bash
   cd CDBSolution/CDB.UnitTests
   
2. Execute os testes:
   ```bash
   dotnet test
A cobertura de testes atinge mais de 90%.

## 📚 Referências e Ferramentas Utilizadas
- Backend: ASP.NET Core 8.0
- Frontend: Angular 15+
- Testes: xUnit, Moq, Bogus
- Mock Data: Bogus (pt_BR)

## 📝 Licença
Este projeto é de código aberto e está licenciado sob os termos da MIT License.

## 📧 Contato
Ravele
GitHub: @ravele
