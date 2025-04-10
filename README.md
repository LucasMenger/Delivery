# 🚀 Projeto de Microserviços com .NET 8, Docker e Ocelot

Este projeto é composto por múltiplos microserviços, cada um com seu próprio contexto, utilizando .NET 8, arquitetura Clean Architecture e Ocelot como API Gateway. Todos os serviços rodam em containers Docker orquestrados via `docker-compose`.

---

## 🧱 Estrutura de Pastas

/ ├── ApiGateway/ │ └── Dockerfile ├── AuthService/ │ └── Dockerfile ├── UserService/ │ └── Dockerfile ├── Services/ │ ├── DeliverymanService/ │ │ └── DeliverymanService.Api/ │ │ └── Dockerfile │ ├── CustomerService/ │ │ └── CustomerService.Api/ │ │ └── Dockerfile │ ├── VehicleService/ │ │ └── VehicleService.Api/ │ │ └── Dockerfile ├── Shared.Data/ ├── docker-compose.yml


---

## ⚙️ Pré-requisitos

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download)
- [Docker](https://www.docker.com/)
- [EF Core CLI](https://learn.microsoft.com/ef/core/cli/dotnet)

---

## 🔧 Configurando o Banco de Dados

O projeto utiliza PostgreSQL. A string de conexão está no appsettings dos serviços e usa a seguinte configuração padrão:
Host=postgres;Port=5432;Database=microservices_db;Username=postgres;Password=postgres


> O nome do host `postgres` é usado porque o container do banco se chama `postgres` no `docker-compose.yml`.

---

## 🛠️ Aplicar Migrations (Exemplo com VehicleService)

```bash
dotnet ef migrations add InitialCreate \
  --project Shared.Data \
  --startup-project Services/VehicleService/VehicleService.Api


🐳 Rodando com Docker
1. Criar imagens e subir containers
docker-compose up --build
2. Parar e remover containers
docker-compose down

🔌 Endpoints
Serviço	Porta	Exemplo de Endpoint
API Gateway	7000	http://localhost:7000/api/user
AuthService	7001	http://localhost:7001/api/auth/login
UserService	7003	http://localhost:7003/api/user
DeliverymanService	7005	http://localhost:7005/api/deliverymen
CustomerService	7006	http://localhost:7006/api/customers
VehicleService	7007	http://localhost:7007/api/vehicles
PostgreSQL	5432	User=postgres, Password=postgres



--
📦 TODOs Futuro
Adicionar Swagger para cada serviço

Implementar autenticação JWT entre microserviços

Adicionar health checks

Feito com ❤️ por [Lucas Menger]
