## Sobre o Projeto

Esta API, desenvolvida utilizando **.NET 8**, adota os princípios do **Domain-Driven Design(DDD)** para oferecer uma solução estruturada e eficaz no gerenciamento de despesas pessoais. O principal objetivo é permitir que os usuários registrem suas despesas, detalhando informações como título, data e hora, descrição, valor e tipo de pagamento, com os dados sendo armazenados de forma segura em um banco de dados **PostreSql**.

A arquitetura da API baseia-se em REST, utilizando métodos **HTTP** padrão para uma comunicação eficiente e simplificada. Além disso, é complementada por uma documentação **Swagger**, que proporciona uma interface gráfica interativa para que os desenolvedores possam explorar e testar os endpoints de maneira fácil.
É base ainda do projeto a cobertura de testes de unidade e integração para garantir o funcionamento do código em todas as pontas importantes, verificando as regras de negócio definidas no escopo do projeto e o funcionamento de ponta a ponta desde a chamada nos endpoints até a manipulação de dados em banco de dados, para isso é utilizada a estratégia de uso de banco de dados em memória que é criado no momento da execução dos testes e deletado ao final dos mesmos.

Dentre os pacotes **NuGet** utilizados, o **AutoMapper** é o responsável pelo mapeamento entre objetos de domínio e requisição/resposta, reduzindo a necessidade de código repetitivo e manual. O **FluentAssertions** é utilizados nos testes de unidade para tornar as verificação mais legíveis, ajudando a escrever testes claros e compreensíveis.
Para as validações, o **FluentValidation** é usado para implementar regras de validação de forma simples e intuitiva nas classes de requisições, mantendo o código limpo e fácil de manter. Por fim, o **EntityFramework** atua como um **ORM (Object-Relational Mapper)** que simplifica as interações com o banco de dados, permitindo o uso de objetos **.NET** para manipular dados diretamente, sem a necessidade de lidar com consultas SQL. 
Para os testes de unidade e integração são utilizados os pacotes do **Bogus** que garante a simulação de nossas entidades de dominío e comunicação, além do **Moq** que nos permite o uso de instâncias de nossas interfaces de maneira a não prejudicar o funcionamento produtivo da aplicação. 

![hero-image]

### Features

- **Domain-Driven Design (DDD)**: Estrutura modular que facilita o entendimento e a manutenção do domínio da aplicação
- **Testes de Unidade e Integração**: Testes abrangentes com FluentAssertions para garantir a funcionalidade e a qualidade do código.
- **Geração de Relatórios**: Capacidade de exportar relatórios detalhados para **PDF e Excel**, oferencendo uma análise visual e eficaz das despesas.
- **RESTful API com Documentação Swagger**: Interface documentada que facilita a integração e o teste por parte dos desenvolvedores.
- **Conceitos de SOLID**: Estrutura do projeto construída seguindo princípios do SOLID afim de facilitar a manutenção e legibilidade dos código.
- **Uso de autenticação JWT Bearer**: Uso de autenticação através de tokens JWT garantindo a segurança ao permitir ou bloquear acessos a endpoints sensíveis.

## Construído com

![badge-dot-net]
![badge-visual-studio]
![badge-windows]
![badge-swagger]
![badge-postgre-sql]

## Getting Started

Para obter uma cópia local funcionando, siga estes passos simples.

### Requisitos

* Visual Studio Versão 2022+ ou Visual Studio Code
* Windows 10+ ou Linux/MacOs com [.NET SDK][dot-net-sdk] instalado
* PostgreSql instalado localmente *(opcional)*

### Instalação

1. Clone o repositório a partir da branch `main`:
    ```sh
    git clone https://github.com/henrikesilva/CashFlow.git
    ```

2. Crie uma nova branch
3. Preencha as informações no arquivo `appsettings.Development.json`.
4. Execute a API e aproveite o seu teste :)



<!-- Links -->
[render]: https://render.com
[deployed]: https://cashflow-5anp.onrender.com/swagger/index.html
[dot-net-sdk]: https://dotnet.microsoft.com/pt-br/download/dotnet/8.0

<!-- Images -->
[hero-image]: images/heroimage.png

<!-- Badges -->
[badge-dot-net]: https://img.shields.io/badge/.NET-512BD4?logo=dotnet&logoColor=fff&style=for-the-badge
[badge-visual-studio]: https://img.shields.io/badge/Visual%20Studio-5C2D91?logo=visualstudio&logoColor=fff&style=for-the-badge
[badge-windows]: https://img.shields.io/badge/Windows-0078D4?logo=windows&logoColor=fff&style=for-the-badge
[badge-swagger]: https://img.shields.io/badge/Swagger-85EA2D?logo=swagger&logoColor=000&style=for-the-badge
[badge-postgre-sql]: https://img.shields.io/badge/PostgreSQL-4169E1?logo=postgresql&logoColor=fff&style=for-the-badge
