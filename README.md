# 🚀 ApiContratosDockerK8s

Projeto de exemplo que demonstra o ciclo completo de **containerização** e **orquestração** de uma aplicação .NET + MySQL utilizando **Docker**, **Docker Compose** e **Kubernetes**.

---

## 📌 Visão Geral

A solução é composta por:

- **API Contratos** (ASP.NET Core 9.0)  
- **Banco de Dados MySQL 8.0**  
- **Dockerfile** multi-stage (build otimizado)  
- **Docker Compose** para execução local (API + MySQL)  
- **Kubernetes Manifests** com:
  - ConfigMap (configurações não sensíveis)  
  - Secret (credenciais)  
  - Deployment (API e MySQL)  
  - Service (NodePort e ClusterIP)  
  - PVC (persistência de dados do banco)  

---

## 🛠️ Tecnologias Utilizadas

- [.NET 9.0](https://dotnet.microsoft.com/)  
- [MySQL 8.0](https://www.mysql.com/)  
- [Docker](https://www.docker.com/)  
- [Docker Compose](https://docs.docker.com/compose/)  
- [Kubernetes](https://kubernetes.io/)  

---

## 🐳 1. Docker Build e Execução

### Criar a imagem:

```powershell
docker build -t thiagodarlei/apicontratos:1.0 .
```

### Rodar o container:

```powershell
docker run -d -p 8080:80 --name apicontratos thiagodarlei/apicontratos:1.0
```

### Testar a API:

```powershell
curl http://localhost:8080/contratos
```

---

## 🐙 2. Docker Compose (API + MySQL)

### Subir os serviços:

```powershell
docker-compose up -d
```

### Listar containers:

```powershell
docker ps
```

### Testar API:

```powershell
curl http://localhost:8080/contratos
```

---

## 📦 3. Publicar no Docker Hub

### Login:

```powershell
docker login
```

### Criar a imagem com tag:

```powershell
docker build -t thiagodarlei/apicontratos:1.0 .
```

### Push para o Docker Hub:

```powershell
docker push thiagodarlei/apicontratos:1.0
```

### (Opcional) Testar pull em outra máquina:

```powershell
docker pull thiagodarlei/apicontratos:1.0
```

---

## ☸️ 4. Deploy no Kubernetes

### 4.1 Deploy do MySQL

```powershell
kubectl apply -f mysql-deployment.yaml
```

### 4.2 Deploy da API

```powershell
kubectl apply -f apicontratos-deployment.yaml
```

### Verificar pods e serviços:

```powershell
kubectl get pods
kubectl get svc
```

---

## 🌐 5. Testar API no Kubernetes

Se exposto via **NodePort (30080)**:

```powershell
curl http://localhost:30080/contratos
```

Se rodando em **Minikube**:

```powershell
minikube service apicontratos-service --url
curl $(minikube service apicontratos-service --url)/contratos
```

---

## ⚡ 6. Escalabilidade e Auto-Healing

### Escalar para 3 réplicas:

```powershell
kubectl scale deployment apicontratos --replicas=3
kubectl get pods -w
```

### Deletar um pod (auto-healing):

```powershell
kubectl delete pod <nome-do-pod>
```

➡️ O Kubernetes recria automaticamente o pod removido.

---

## 🧹 7. Encerrar / Limpar Recursos

```powershell
kubectl delete -f k8s/apicontratos-deployment.yaml
kubectl delete -f k8s/mysql-deployment.yaml
kubectl delete all --all -n default
docker rm -f $(docker ps -aq)
```

---

## ✅ Benefícios da Solução

* **Portabilidade**: a mesma imagem roda local, no Compose e no Kubernetes.
* **Escalabilidade**: múltiplas réplicas da API garantem alta disponibilidade.
* **Resiliência**: probes de readiness e liveness garantem auto-recuperação.
* **Persistência**: PVC mantém os dados do MySQL mesmo após reinícios.
* **Segurança**: separação entre ConfigMap (configs) e Secret (credenciais).

---

## 📌 Próximos Passos (Melhorias)

* Configurar **CI/CD** (GitHub Actions ou Azure DevOps).
* Monitoramento com **Prometheus + Grafana**.
* Implementar **Ingress Controller** para expor via domínio/HTTPS.
* Adicionar **migrations automáticas** no startup da API.
