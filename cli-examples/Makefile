BROKER := localhost:9093
TOPIC := music-playlist-events
CGROUP := my-consumer-app
REPLICAS := 1
PARTITIONS := 3

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

consumer:
	@echo "Running consumer for topic $(TOPIC) for $(BROKER) \n"
	kafka-console-consumer.sh --topic $(TOPIC) \
	--from-beginning \
	--bootstrap-server $(BROKER)

consumer-group:
	@echo "Running consumer group $(CGROUP) for topic $(TOPIC) for $(BROKER) \n"
	kafka-console-consumer.sh --topic $(TOPIC) \
	--group $(CGROUP) \
	--from-beginning \
	--bootstrap-server $(BROKER)



