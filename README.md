# Variacao-Ativos-PETR4.SA

Este projeto foi desenvolvido com **.NET 8** e **Angular 17.1.3**.

## Sobre o Projeto

Este projeto tem como padrão trazer os últimos dados de abertura do pregão da PETR4.SA e sempre vai trazer os últimos 30 pregões com o valor de abertura. Ele está hospedado em https://testeguide.azurewebsites.net/, onde você pode ver sua publicação.

Para a visualização dos gráficos, foi utilizado o PrimeNG.

Este projeto foi feito para um teste para a empresa Guide.

## Pré-requisitos

- .NET 8
- Angular 17.1.3
- SQL Server Local

## Configuração do Banco de Dados

Este projeto utiliza um banco de dados SQL Server local. A string de conexão está configurada para o padrão do SQL Server local. Se necessário, você pode precisar alterar a string de conexão no arquivo `appsettings.json`.

## Configuração do Projeto

1. **Restaurar os pacotes do .NET**: No terminal, navegue até a pasta do projeto .NET e execute o comando `dotnet restore`.

2. **Atualizar o banco de dados**: Ainda no terminal, execute o comando `dotnet ef database update` para aplicar as migrações do Entity Framework ao banco de dados.

3. **Instalar os pacotes do Node.js**: Navegue até a pasta do projeto Angular e execute o comando `npm install` para instalar todas as dependências do projeto.

## Execução do Projeto

1. **Executar o projeto .NET**: No terminal, na pasta do projeto .NET, execute o comando `dotnet run`.

2. **Executar o projeto Angular em ambiente de desenvolvimento**: No terminal, na pasta do projeto Angular, execute o comando `ng serve`. Navegue para `http://localhost:4200/`. O aplicativo será recarregado automaticamente se você alterar qualquer um dos arquivos de origem.

3. **Executar o projeto Angular em ambiente de produção**: No terminal, na pasta do projeto Angular, execute o comando `ng build --prod`. Os artefatos de construção serão armazenados no diretório `dist/`.

## Execução dos Testes

Para executar os testes que estão no projeto `VariacaoAtivosTestes`, você pode seguir estas etapas:

1. No terminal, navegue até a pasta `VariacaoAtivosTestes`.
2. Execute o comando `dotnet test`.

## Contribuição

As solicitações pull são bem-vindas. Para grandes alterações, abra um problema primeiro para discutir o que você gostaria de mudar.

## Licença

MIT