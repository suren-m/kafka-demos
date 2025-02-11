build:
	docker build ./orders -f ./orders/Dockerfile.orders -t surenmcode/py-orders:1.1-dapr-grpc
	docker build ./inventory -f ./inventory/Dockerfile.inventory -t surenmcode/py-inventory:1.1-dapr-grpc
	docker build ./shipment -f ./shipment/Dockerfile.shipment -t surenmcode/py-shipment:1.1-dapr-grpc

push:
	docker push surenmcode/py-orders:1.1-dapr-grpc
	docker push surenmcode/py-inventory:1.1-dapr-grpc
	docker push surenmcode/py-shipment:1.1-dapr-grpc

deploy:	py-orders py-inventory py-shipment

py-orders:
	kubectl apply -f ./orders/deploy/pubsub-component.yaml
	kubectl apply -f ./orders/deploy/orders.yaml

py-inventory:
	kubectl apply -f ./inventory/deploy/pubsub-component.yaml
	kubectl apply -f ./inventory/deploy/inventory.yaml

py-shipment:
	kubectl apply -f ./shipment/deploy/pubsub-component.yaml
	kubectl apply -f ./shipment/deploy/shipment.yaml

py-orders-logs:
	kubectl logs --selector=app=py-orders --follow -n py-orders-dapr-grpc -c py-orders

py-orders-daprd-logs:
	kubectl logs --selector=app=py-orders --follow -n py-orders-dapr-grpc -c daprd

py-inventory-logs:
	kubectl logs --selector=app=py-inventory --follow -n py-inventory-dapr-grpc -c py-inventory

py-inventory-daprd-logs:
	kubectl logs --selector=app=py-inventory --follow -n py-inventory-dapr-grpc -c daprd

py-shipment-logs:
	kubectl logs --selector=app=py-shipment --follow -n py-shipment-dapr-grpc -c py-shipment	

py-shipment-daprd-logs:
	kubectl logs --selector=app=py-shipment --follow -n py-shipment-dapr-grpc -c daprd

delete-all:
	kubectl delete ns py-orders-dapr-grpc
	kubectl delete ns py-inventory-dapr-grpc
	kubectl delete ns py-shipment-dapr-grpc
