#  Estética Automotiva

Sistema web desenvolvido para a disciplina de Arquitetura de Aplicações Web.

O projeto permite o gerenciamento de clientes e serviços de uma empresa de estética automotiva, utilizando uma API REST integrada a banco de dados SQLite.

---

#  Tecnologias Utilizadas

## Backend
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger/OpenAPI

## Frontend
- HTML5
- CSS3
- JavaScript
- Fetch API

---

#  Funcionalidades

## Clientes
- Listar clientes
- Buscar cliente por ID
- Cadastrar cliente
- Atualizar cliente
- Excluir cliente

## Serviços
- Listar serviços
- Buscar serviço por ID
- Cadastrar serviço
- Atualizar serviço
- Excluir serviço

## Frontend
- Dashboard
- Navegação assíncrona
- Consumo da API sem recarregar página
- Interface moderna

---

#  Estrutura do Projeto

/backend
- API REST
- Controllers
- Models
- Banco SQLite
- Swagger

/frontend
- HTML
- CSS
- JavaScript

---

#  Como Executar o Projeto

## Pré-requisitos

Instalar:
- .NET SDK 10
- Visual Studio Code

---

#  Executando o Backend

Abra o terminal na pasta backend:

```bash
cd backend
```

Execute:

```bash
dotnet run
```

A API estará disponível em:

```text
http://localhost:5179
```

---

#  Swagger

A documentação Swagger pode ser acessada em:

```text
http://localhost:5179/swagger
```

---

#  Executando o Frontend

Abra o arquivo:

```text
frontend/index.html
```

no navegador.

---

#  Banco de Dados

O projeto utiliza SQLite como banco de dados.

Arquivo do banco:

```text
backend/estetica.db
```

---

#  Migrations

Criar migration:

```bash
dotnet ef migrations add NomeDaMigration
```

Atualizar banco:

```bash
dotnet ef database update
```

---

#  Requisitos Atendidos

✅ API REST  
✅ CRUD completo  
✅ Banco de dados integrado  
✅ Swagger/OpenAPI  
✅ Frontend assíncrono  
✅ Navegação dinâmica  
✅ GitHub com histórico de commits  

---

#  Autor

Vinicius Macario