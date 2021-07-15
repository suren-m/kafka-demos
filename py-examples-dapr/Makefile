BROKER := localhost:9093
TOPIC := orders
CGROUP := inventory-service
REPLICAS := 1
PARTITIONS := 3
DEFAULT_PARTITION := 0

list-topics:	
	@echo "Listing topics for $(BROKER) \n"
	kafka-topics.sh --list --bootstrap-server $(BROKER)

create-topic:
	@echo "Creating topic $(TOPIC) for $(BROKER)"
	kafka-topics.sh --create --topic $(TOPIC) \
	--replication-factor $(REPLICAS) \
	--partitions $(PARTITIONS) \
	--bootstrap-server $(BROKER)

describe-topic:
	@echo "Describing topic $(TOPIC) for $(BROKER) \n"
	kafka-topics.sh --describe --topic $(TOPIC) \
	--bootstrap-server $(BROKER)

producer:
	@echo "Running producer for topic $(TOPIC) for $(BROKER) \n"
	kafka-console-producer.sh --topic $(TOPIC) \
	--bootstrap-server $(BROKER)

producer-with-key:
	@echo "Running producer with message key for topic $(TOPIC) for $(BROKER) \n"
	kafka-console-producer.sh --topic $(TOPIC) \
	--property "parse.key=true" \
	--property "key.separator=:" \
	--bootstrap-server $(BROKER)

consumer:
	@echo "Running consumer for topic $(TOPIC) for $(BROKER) \n"
	kafka-console-consumer.sh --topic $(TOPIC) \
	--from-beginning \
	--bootstrap-server $(BROKER)

describe-consumer-group:
	@echo "Describing consumer group $(CGROUP) for topic $(TOPIC) for $(BROKER) \n"
	kafka-consumer-groups.sh --describe \
	--group $(CGROUP) \
	--bootstrap-server $(BROKER)

consumer-group:
	@echo "Running consumer group $(CGROUP) for topic $(TOPIC) for $(BROKER) \n"
	kafka-console-consumer.sh --topic $(TOPIC) \
	--group $(CGROUP) \
	--bootstrap-server $(BROKER)

consumer-group-with-key-and-partition:
	@echo "Running consumer group $(CGROUP) for Partition $(PARTITION) on topic $(TOPIC) for $(BROKER) \n "
	kafka-console-consumer.sh --topic $(TOPIC) --bootstrap-server $(BROKER) \
	--property print.key=true \
	--property key.separator=":" \
	--partition $(DEFAULT_PARTITION) \

# or latest or shift-by or period
# or dry-run
offset-reset:
	@echo "Resetting offsets for consumer group $(CGROUP) for topic $(TOPIC) for $(BROKER) \n"
	kafka-consumer-groups.sh --topic $(TOPIC) \
	--group $(CGROUP) --reset-offsets --to-earliest --execute --bootstrap-server $(BROKER)



