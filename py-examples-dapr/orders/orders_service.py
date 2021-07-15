import time
import json

from dapr.clients import DaprClient

with DaprClient() as d:
    id=0
    while True:
        id+=1

        msg = 'order-' + str(id)
        req_data = {
            'id': id,
            'message': msg
        }

        # Create a typed message with content type and body
        resp = d.publish_event(
            pubsub_name='my-pubsub',
            topic_name='dapr-demo-orders',
            data=json.dumps(req_data),
            data_content_type='application/json',
        )

        # Print the request
        print(req_data, flush=True)
        time.sleep(3)