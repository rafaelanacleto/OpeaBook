# OpeaBook: Sistema de Gestão de Biblioteca

Este projeto implementa uma API RESTful para um sistema de gestão de bibliotecas comunitárias, seguindo os princípios de Modelagem de Domínio Rico.

## Tecnologias

* **.NET 5** (ou superior)
* **ASP.NET Core**
* **Entity Framework Core**
* **SQL Server** (ou outro banco de dados relacional)

## Requisitos

* .NET SDK 5.0 (ou superior)
* SQL Server (ou outro banco de dados relacional)

## Configuração do Projeto

1.  **Clonar o repositório:**
    `git clone https://github.com/seu-usuario/OpeaBook.git`
    `cd OpeaBook`

2.  **Configurar o banco de dados:**
    * Abra o arquivo `appsettings.json` na pasta `OpeaBook.API`.
    * Altere a string de conexão `"DefaultConnection"` para apontar para seu banco de dados.
    `"DefaultConnection": "Server=localhost;Database=OpeaBookDB;Trusted_Connection=True;"`

3.  **Executar as migrações do Entity Framework Core:**
    * No terminal, navegue até a pasta do projeto da API (`OpeaBook.API`).
    * Execute os comandos:
        `dotnet ef migrations add InitialCreate`
		ou
		`dotnet ef migrations add InitialCreate --startup-project ../OpeaBook.API/OpeaBook.API.csproj`
		
        `dotnet ef database update`

4.  **Rodar a aplicação:**
    * Na pasta `OpeaBook.API`, execute:
        `dotnet run`
    * A API estará disponível em `https://localhost:5001` (ou a porta configurada).

## Endpoints da API

* `POST /api/livros`: Cria um novo livro.
* `GET /api/livros/{id}`: Obtém um livro por ID.
* `GET /api/livros`: Lista todos os livros.
* `POST /api/emprestimos`: Solicita um novo empréstimo.
* `PUT /api/emprestimos/{id}/devolver`: Devolve um livro emprestado.
* `GET /api/emprestimos`: Lista todos os empréstimos.