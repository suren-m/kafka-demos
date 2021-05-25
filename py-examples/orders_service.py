from logging import log
from kafka import KafkaProducer
from kafka.errors import KafkaError
import globals

producer = KafkaProducer(
    bootstrap_servers=globals.brokers)

# Async by default
for i in range(0, 10):
    msg = 'order-' + str(i)
    # future = producer.send(globals.topic, str.encode(msg))
    future = producer.send(
        globals.topic, key=b'discount-sale', value=str.encode(msg))

    # Block for 'synchronous' sends
    try:
        record_metadata = future.get(timeout=10)
    except KafkaError:
        # Decide what to do if produce request failed...
        log.exception()
        pass

    # Successful result returns assigned partition and offset
    print(f'Msg: {msg} Topic: {record_metadata.topic}, partition: {record_metadata.partition}, offset:, {record_metadata.offset}')

# print('press enter to exit')
# input()
