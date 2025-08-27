# 🚀 Projeto Full Stack: C# .NET 8 + Angular 19
---

## 🛠️ Pré-requisitos

Antes de começar, certifique-se de ter instalado:

* [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) 🟢
* [Node.js](https://nodejs.org/) (versão LTS recomendada) 🟢
* [Angular CLI](https://angular.io/cli) ⚡
* SQL Server

---

## 🖥️ Configurando o Backend

1. Abra a pasta do backend no Visual Studio ou VS Code 🖱️
2. Crie o arquivo `appsettings.json` na raiz do projeto com este conteúdo:

```json
{
  "ConnectionStrings": {
    "Connection": "Server=localhost;Database=YOUR_DATA-BASE;Trusted_Connection=True;"
  },
  "Settings": {
    "Jwt": {
      "SigningKey": "YOUR_SIGN_IN_KEY",
      "ExpiresMinutes": 30,
      "ExpiresMinutesRefresh": 1440
    }
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

> ⚠️ Ajuste a `ConnectionStrings.Connection` se seu SQL Server estiver em outra porta ou servidor.

3. Para produção ou proxy, adicione `api.production.json`:

```json
{
  "/api": {
    "target": "https://localhost:7080/",
    "secure": false,
    "changeOrigin": true,
    "pathRewrite": {
      "^/api": ""
    }
  }
}
```

---

### ▶️ Rodando o Backend

1. Abra o terminal na pasta do backend 🖥️
2. Execute:

```bash
dotnet run
```

3. O backend estará disponível em `https://localhost:7080` 🔗

---

## 🌐 Configurando o Frontend

1. Abra a pasta do frontend 🖱️
2. Instale as dependências do Angular:

```bash
npm install
```

3. Configure o proxy criando `proxy.conf.json` com o mesmo conteúdo do `api.production.json`:

```json
{
  "/api": {
    "target": "https://localhost:7080/",
    "secure": false,
    "changeOrigin": true,
    "pathRewrite": {
      "^/api": ""
    }
  }
}
```

---

### ▶️ Rodando o Frontend

1. No terminal da pasta do frontend, execute:

```bash
ng serve 
```

2. Acesse a aplicação em [http://localhost:4200](http://localhost:4200) 🎉

---

## ⚡ Dicas Importantes

* O backend utiliza **JWT** 🔐 para autenticação. Configure a `SigningKey` e os tempos de expiração (`ExpiresMinutes` e `ExpiresMinutesRefresh`).
* O frontend utiliza proxy 🌐 para redirecionar `/api` para o backend local.
* Certifique-se que o banco `DesafioPlenoFullStackPleno` existe e que o SQL Server está rodando 🗄️.
* Para ambientes diferentes (produção, desenvolvimento), crie arquivos `appsettings.{Ambiente}.json` e configure variáveis de ambiente no `.NET`.
