# Installing Kafka to a Kubernetes cluster using helm

see: https://bitnami.com/stack/kafka/helm

## Add helm repo

```
helm repo add bitnami https://charts.bitnami.com/bitnami
```

## Install Kafka

```
helm install my-release bitnami/kafka
```

---

## On AKS

```
helm repo add azure-marketplace https://marketplace.azurecr.io/helm/v1/repo
helm install my-release azure-marketplace/kafka
```



