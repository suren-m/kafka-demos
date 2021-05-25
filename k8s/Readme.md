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

### External Testing

```bash
kafka-topics.sh --create --topic sample --bootstrap-server 10.0.18.1:9094
kafka-topics.sh --describe --topic sample --bootstrap-server 10.0.18.1:9094

kafka-console-producer.sh --topic sample --bootstrap-server 10.0.18.1:9094

# From separate terminal
kafka-console-consumer.sh --topic sample --from-beginning --bootstrap-server 10.0.18.1:9094
```
