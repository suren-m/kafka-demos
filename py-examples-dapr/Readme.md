
# Python examples for kafka basics with Dapr sdk


``` 
 dapr init -k
```

```
 kubectl apply -f pubsub-component.yaml
```

```
 make deploy
```
```
py-orders-logs:
 	k logs --selector=app=py-orders --follow -n py-orders-dapr -c py-orders

py-inventory-logs:
 	k logs --selector=app=py-inventory --follow -n py-inventory-dapr -c py-inventory

py-shipment-logs:
 	k logs --selector=app=py-shipment --follow -n py-shipment-dapr -c py-shipment
```