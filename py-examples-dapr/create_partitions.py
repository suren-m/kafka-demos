from kafka import KafkaAdminClient
from kafka.admin import NewPartitions
import globals

admin_client = KafkaAdminClient(bootstrap_servers=globals.brokers)

topic_partitions = {}

topic_partitions[globals.topic] = NewPartitions(
    total_count=globals.partition_count)

admin_client.create_partitions(topic_partitions)
