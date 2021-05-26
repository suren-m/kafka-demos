BROKER := localhost:9093
TOPIC := streams-plaintext-input
INPUTTOPIC := streams-plaintext-input
OUTPUTTOPIC := streams-wordcount-output
CGROUP := my-consumer-app
REPLICAS := 1
PARTITIONS := 1
DEFAULT_PARTITION := 0

list-topics:	
	@echo "Listing topics for $(BROKER) \n"
	kafka-topics.sh --list --bootstrap-server $(BROKER)

create-topic:
	@echo "Creating topic $(TOPIC) for $(BROKER)"
	kafka-topics.sh --create --topic $(INPUTTOPIC) \
	--replication-factor $(REPLICAS) \
	--partitions $(PARTITIONS) \
	--bootstrap-server $(BROKER)

create-topic-compact:
	@echo "Creating topic $(TOPIC) for $(BROKER) with compaction"
	kafka-topics.sh --create --topic $(OUTPUTTOPIC) \
	--replication-factor $(REPLICAS) \
	--partitions $(PARTITIONS) \
	--bootstrap-server $(BROKER) \
    --config cleanup.policy=compact

producer:
	@echo "Running producer for topic $(TOPIC) for $(BROKER) \n"
	kafka-console-producer.sh --topic $(TOPIC) \
	--bootstrap-server $(BROKER)
