📘 TaskManager API
🚀 Sobre o projeto
O TaskManager API é uma aplicação desenvolvida em .NET 10 utilizando solução no formato .slnx (Solution Filter), que permite organizar múltiplos projetos dentro da mesma solução de forma escalável.
O objetivo é fornecer uma API RESTful robusta para gerenciamento de tarefas, aplicando boas práticas de arquitetura e desenvolvimento.

🏗️ Arquitetura
O projeto segue uma arquitetura em camadas:

Api → Controllers, Middlewares e configuração do pipeline.

Application → DTOs, Validators (FluentValidation), lógica de aplicação.

Domain → Entidades e regras de negócio.

Infrastructure → Persistência, repositórios e integração com banco de dados.

Tests → Testes automatizados (unitários e de integração).

📦 DTOs
Os Data Transfer Objects (DTOs) são usados para separar a entrada/saída da API das entidades de domínio.
Isso garante desacoplamento e facilita validações, versionamento e evolução da API.

⚙️ Middleware
Middleware de Logs → Registra requisições e respostas (método, URL, status code, tempo de execução).

Middleware de Erros → Captura exceções não tratadas e retorna respostas padronizadas em JSON.

Esses middlewares centralizam responsabilidades e mantêm os controllers limpos.

🌍 Internacionalização
Optamos por escrever o código e a documentação em inglês, mesmo sendo um projeto iniciado em português, para permitir escalabilidade internacional e facilitar colaboração global.

💡 Boas práticas aplicadas
Dependency Injection (DI) → Todos os serviços e repositórios são injetados via construtor.

SOLID →

Single Responsibility: cada classe tem uma responsabilidade clara.

Open/Closed: fácil extensão sem modificar código existente.

Liskov Substitution: interfaces e abstrações respeitadas.

Interface Segregation: interfaces específicas para cada contexto.

Dependency Inversion: dependências invertidas para abstrações.

RESTful API → Uso correto dos verbos HTTP:

GET /tasks → listar tarefas

GET /tasks/{id} → buscar tarefa por ID

POST /tasks → criar nova tarefa

PUT /tasks/{id} → atualizar tarefa

DELETE /tasks/{id} → remover tarefa

📖 Swagger
A API expõe documentação interativa via Swagger UI, permitindo:

Visualizar endpoints e modelos.

Executar chamadas diretamente pelo navegador.

Facilitar testes e integração com clientes externos.

🧪 Testes Automatizados
Unit Tests → Validam regras de negócio e validators (FluentValidation).

Integration Tests → Simulam chamadas reais à API usando WebApplicationFactory.

Executados via dotnet test e integráveis em pipelines CI/CD.

📂 Estrutura de pastas
Código
TaskManager.slnx
 ├── Api
 ├── Application
 ├── Domain
 ├── Infrastructure
 └── Tests
🔮 Futuras melhorias
Autenticação e autorização (JWT).

Observabilidade com métricas e tracing.

Deploy automatizado em containers (Docker/Kubernetes).
