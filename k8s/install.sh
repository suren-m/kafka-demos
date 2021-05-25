ns=kafka
release=kafka
config_file=overrides.yaml

# setup namespace
kubectl create ns $ns

# add helm repo
helm repo add azure-marketplace https://marketplace.azurecr.io/helm/v1/repo

# install kafka with overrides.yaml
helm install $release -f $config_file -n $ns azure-marketplace/kafka

# optional: setup a client in same namespace for testing
# kubectl run kafka-client --restart='Never' --image marketplace.azurecr.io/bitnami/kafka:2.8.0-debian-10-r0 --namespace kafka --command -- sleep infinity

# For more info, see: https://github.com/bitnami/charts/tree/master/bitnami/kafka

# watch
watch kubectl get all -n $ns
