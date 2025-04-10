#!/bin/bash

# Função para matar processos em uma porta
kill_port() {
  PORT=$1
  PID=$(lsof -ti tcp:$PORT)
  if [ -n "$PID" ]; then
    echo "Matando processo na porta $PORT (PID: $PID)..."
    kill -9 $PID
  fi
}

# Matar todas as portas usadas pelos serviços
for PORT in 7000 7001 7003 7005 7006 7007; do
  kill_port $PORT
done

echo "Iniciando API Gateway na porta 7000..."
dotnet run --project ApiGateway/ApiGateway.csproj --urls=http://localhost:7000 &

echo "Iniciando AuthService na porta 7001..."
dotnet run --project AuthService/AuthService.csproj --urls=http://localhost:7001 &

echo "Iniciando UserService na porta 7003..."
dotnet run --project UserService/UserService.csproj --urls=http://localhost:7003 &

echo "Iniciando DeliverymanService na porta 7005..."
dotnet run --project Services/DeliverymanService/DeliverymanService.Api/DeliverymanService.Api.csproj --urls=http://localhost:7005 &

echo "Iniciando CustomerService na porta 7006..."
dotnet run --project Services/CustomerService/CustomerService.Api/CustomerService.Api.csproj --urls=http://localhost:7006 &

echo "Iniciando VehicleService na porta 7007..."
dotnet run --project Services/VehicleService/VehicleService.Api/VehicleService.Api.csproj --urls=http://localhost:7007 &

echo "Todos os serviços foram iniciados!"
