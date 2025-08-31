# Sistema de Tarefas API

Este projeto é uma API RESTful desenvolvida em **.NET 6** para
gerenciamento de tarefas e usuários.\
Ela permite **criar, listar, atualizar e excluir** tarefas e usuários,
utilizando **Entity Framework Core** e **SQL Server**.

------------------------------------------------------------------------

## 🚀 Tecnologias Utilizadas

-   ASP.NET Core 6
-   Entity Framework Core
-   SQL Server
-   Swagger (para documentação e testes)

------------------------------------------------------------------------

## 📌 Endpoints Principais

### Usuários

-   `GET /api/usuarios` → Lista todos os usuários
-   `GET /api/usuarios/{id}` → Busca um usuário pelo ID
-   `POST /api/usuarios` → Cria um novo usuário
-   `PUT /api/usuarios/{id}` → Atualiza um usuário existente
-   `DELETE /api/usuarios/{id}` → Remove um usuário

### Tarefas

-   `GET /api/tarefas` → Lista todas as tarefas
-   `GET /api/tarefas/{id}` → Busca uma tarefa pelo ID
-   `POST /api/tarefas` → Cria uma nova tarefa
-   `PUT /api/tarefas/{id}` → Atualiza uma tarefa existente
-   `DELETE /api/tarefas/{id}` → Remove uma tarefa

------------------------------------------------------------------------

## 🛠️ Como Executar o Projeto

1.  Clone este repositório:

    ``` bash
    git clone https://github.com/seu-usuario/sistema-de-tarefas-api.git
    ```

2.  Entre na pasta do projeto:

    ``` bash
    cd sistema-de-tarefas-api
    ```

3.  Configure a string de conexão no arquivo **appsettings.json** para o
    seu SQL Server.

4.  Rode as migrações para criar o banco de dados:

    ``` bash
    dotnet ef database update
    ```

5.  Execute o projeto:

    ``` bash
    dotnet run
    ```

6.  Acesse o Swagger para testar a API:

        https://localhost:7038/swagger/index.html

------------------------------------------------------------------------

## 📚 Estrutura do Projeto

    📂 SistemaDeTarefasAPI
     ┣ 📂 Controllers
     ┣ 📂 Data
     ┣ 📂 DTOs
     ┣ 📂 Models
     ┣ 📂 Migrations
     ┣ appsettings.json
     ┣ Program.cs

------------------------------------------------------------------------

## 👨‍💻 Autor

Projeto desenvolvido por **Heldemilde João** 
