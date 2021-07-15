build:
	docker build ./orders -f ./orders/Dockerfile.orders -t surenmcode/py-orders:1.1-dapr
	docker build ./inventory -f ./inventory/Dockerfile.inventory -t surenmcode/py-inventory:1.1-dapr
	docker build ./shipment -f ./shipment/Dockerfile.shipment -t surenmcode/py-shipment:1.1-dapr

push:
	docker push surenmcode/py-orders:1.1-dapr
	docker push surenmcode/py-inventory:1.1-dapr
	docker push surenmcode/py-shipment:1.1-dapr

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
	kubectl logs --selector=app=py-orders --follow -n py-orders-dapr -c py-orders

py-inventory-logs:
	kubectl logs --selector=app=py-inventory --follow -n py-inventory-dapr -c py-inventory

py-shipment-logs:
	kubectl logs --selector=app=py-shipment --follow -n py-shipment-dapr -c py-shipment	
