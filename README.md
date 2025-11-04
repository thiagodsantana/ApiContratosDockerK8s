# 🧾 ApiContratosDockerK8s

![.NET](https://img.shields.io/badge/.NET-8.0-blueviolet?logo=dotnet)
![Docker](https://img.shields.io/badge/Docker-Container-blue?logo=docker)
![Kubernetes](https://img.shields.io/badge/Kubernetes-Orchestration-326ce5?logo=kubernetes)
![Terraform](https://img.shields.io/badge/Terraform-IaC-623CE4?logo=terraform)
![Status](https://img.shields.io/badge/Status-Ativo-success)

---

## 📘 Descrição do Projeto

O **ApiContratosDockerK8s** é um serviço REST desenvolvido em **.NET 8**, projetado para o gerenciamento e integração de **contratos corporativos**.  
A aplicação é totalmente **containerizada com Docker** e **orquestrada via Kubernetes**, com **infraestrutura declarativa** provisionada via **Terraform**.

Seu objetivo é oferecer uma API performática, escalável e resiliente, adequada para ambientes de **produção em nuvem** (GCP, Azure ou AWS).

---

## ⚙️ Tecnologias Utilizadas

- **Linguagem:** C# (.NET 8)
- **Framework:** ASP.NET Core Web API
- **Containerização:** Docker
- **Orquestração:** Kubernetes (K8s)
- **Infraestrutura:** Terraform (IaC)
- **Banco de Dados:** PostgreSQL (padrão configurável)
- **Configuração:** Variáveis de ambiente e Secrets (Kubernetes Secrets / ConfigMaps)
- **Monitoramento:** Prometheus (opcional)
- **Logs:** Console e StackDriver (ou Cloud Logging)

---

## 🧩 Arquitetura da Solução

flowchart TD
    A[Cliente / Sistema Externo] -->|Requisição REST| B[API Contratos .NET 8]
    B -->|Imagem Docker| C[Container]
    C -->|Implantação| D[Kubernetes Cluster]
    D -->|Gerenciado por| E[Terraform IaC]
    D -->|Configurações| F[ConfigMaps e Secrets]
    D -->|Banco de Dados| G[(PostgreSQL)]
    D -->|Exposição| H[Ingress Controller ou LoadBalancer]
    H -->|Acesso HTTP/HTTPS| A

---

## 🚀 Estrutura do Projeto

```
ApiContratosDockerK8s/
│
├── src/
│   └── ApiContratos/              # Projeto principal (.NET API)
│
├── infra/
│   ├── terraform/                 # Módulos e definições IaC
│   └── k8s/                       # Manifests YAML (Deployment, Service, Ingress)
│
├── docker/
│   └── Dockerfile                 # Build da imagem
│
├── tests/                         # Testes unitários e de integração
│
└── README.md
```

---

## 🧰 Pré-Requisitos

Antes de iniciar, certifique-se de ter instalado:

* [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
* [Docker Desktop](https://www.docker.com/)
* [kubectl](https://kubernetes.io/docs/tasks/tools/)
* [Terraform](https://developer.hashicorp.com/terraform/downloads)
* [Minikube](https://minikube.sigs.k8s.io/docs/) *(para ambiente local)*

---

## 🧱 Setup e Execução Local

1. **Clonar o repositório**

   ```bash
   git clone https://github.com/thiagodsantana/ApiContratosDockerK8s.git
   cd ApiContratosDockerK8s
   ```

2. **Construir o projeto**

   ```bash
   dotnet build
   ```

3. **Executar localmente**

   ```bash
   dotnet run --project ./src/ApiContratos
   ```

4. **Acessar a API**

   * Swagger UI: [http://localhost:5000/swagger](http://localhost:5000/swagger)
   * Health Check: [http://localhost:5000/health](http://localhost:5000/health)

---

## 🐳 Execução via Docker

1. **Gerar a imagem**

   ```bash
   docker build -t api-contratos:latest -f ./docker/Dockerfile .
   ```

2. **Rodar o container**

   ```bash
   docker run -d -p 8080:80 --name api-contratos api-contratos:latest
   ```

3. **Acessar**

   * [http://localhost:8080/swagger](http://localhost:8080/swagger)

---

## ☸️ Deploy no Kubernetes

1. **Aplicar as configurações**

   ```bash
   kubectl apply -f infra/k8s/
   ```

2. **Verificar o status**

   ```bash
   kubectl get pods,svc,ingress
   ```

3. **Expor localmente (caso use Minikube)**

   ```bash
   minikube service api-contratos-service
   ```

---

## 🧮 Provisionamento com Terraform

1. **Inicializar**

   ```bash
   cd infra/terraform
   terraform init
   ```

2. **Planejar**

   ```bash
   terraform plan
   ```

3. **Aplicar**

   ```bash
   terraform apply
   ```

---

## 🧠 Boas Práticas e Padrões

* **12-Factor App**: configurações desacopladas do código.
* **Observabilidade nativa** com métricas e logs estruturados.
* **Infraestrutura Imutável**: controlada via IaC.
* **Escalabilidade horizontal** via réplicas K8s.
* **Automação CI/CD** integrada (GitHub Actions, ArgoCD, etc.).

---

## 📈 Próximos Passos

* Integração com pipelines CI/CD.
* Configuração de monitoração (Prometheus / Grafana).
* Automação de secrets via HashiCorp Vault ou GCP Secret Manager.

---

## 👨‍💻 Autor

**Thiago D. Santana**
Analista de Sistemas | Arquiteto em evolução
[GitHub](https://github.com/thiagodsantana) • [LinkedIn](https://www.linkedin.com/in/thiagodsantana)

