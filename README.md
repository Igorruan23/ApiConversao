# API Conversão de Unidades - Backend C#

API RESTful simples em ASP.NET Core para conversão de unidades de comprimento com autenticação JWT.

---

## Funcionalidades

- Conversão entre unidades de comprimento: mm, cm, m, km, in, ft, yd, mi  
- Autenticação JWT para liberar o acesso ao endpoint de conversão  

---

## Usuários pré-definidos para autenticação JWT

| Usuário | Senha   |
|---------|---------|
| admin   | 1234    |
| user1   | senha1  |

---

## Como usar

1. Faça login no endpoint `POST /auth/login` enviando JSON com `userName` e `password`.  
2. Copie o token JWT retornado.  
3. No Swagger, clique em "Authorize" e cole o token no campo `Bearer <token>`.  
4. Use o endpoint `POST /conversor/convert` para realizar a conversão de unidades.

---

## Endpoints principais

- `POST /auth/login`  
  - Entrada:  
    ```json
    {
      "userName": "admin",
      "password": "1234"
    }
    ```  
  - Saída:  
    ```json
    {
      "token": "<JWT Token>"
    }
    ```  

- `POST /conversor/convert`  
  - Entrada:  
    ```json
    {
      "value": 10,
      "fromUnit": "ft",
      "toUnit": "yd"
    }
    ```  
  - Saída:  
    ```json
    {
      "original": {
        "value": 10,
        "fromUnit": "ft",
        "toUnit": "yd"
      },
      "convertedValue": 3.3333333333
    }
    ```  

---

## Tecnologias

- ASP.NET Core  
- JWT para autenticação  
- C#  
- Swagger para documentação e testes 

## Como rodar localmente

1. Clone o repositório  
2. Configure `appsettings.json` com sua chave JWT (`JwtConfig:Key`) e outros parâmetros  
3. Execute `dotnet restore` e `dotnet run`  
4. Acesse `https://localhost:7189/swagger` para testar  



