# Basic Kafka labs using its CLI 

## Pre-requisites

1. This documentation assumes that you have setup kafka server locally using `docker-compose`. If you hadn't done this yet, take a look at `install` directory of this repo.
2. It's much easier if you also have `kafka` installed locally, so you can use its `command-line interface` seamlessly. You can keep the server running inside docker but communicate with it using `localhost:9093` (you may also need Java / Open-JDK 8 or above)
3. If you don't have kafka locally intalled, then you'd need to `exec` into the kafka container and run the cli commands from there.

## Additional tools used in the demo (not needed to do `basics` lab)

1. Kafkacat 
    * If you don't have kafka installed locally. 
    * see: https://github.com/edenhill/kafkacat

2. Make
    * Makefile was used during demo to simplify command execution.  
    * If `Make` is unavailable, just run the kafka commands directly. (see readme below)
    * To install make on debian-based linux, `sudo apt install build-essential`
    * For any other platforms, use your favourite package manager. For e.g:
        * macOS -  https://formulae.brew.sh/formula/make             
---

### Basics

### 1. Connect to Broker and List available topics 

Ensure you can connect to the kafka server (broker) running inside docker container.

```bash
# below command should print out kafka and zookeeper running
docker ps
```

#### If you have installed `kafka` locally, (recommended)
```bash
kafka-topics.sh --list --bootstrap-server localhost:9093

# If you see `command` not found error, it either means kafka is not correctly installed or it's not added to PATH correctly.
```

#### **OR if you don't** have kafka locally,
```bash
# Exec into the kafka container
docker exec -it docker-compose_kafka_1 sh

# Now, list the topics.
kafka-topics.sh --list --bootstrap-server localhost:9093
```

> Note that the shell inside kafka container may not support `tab`,`delete` or `arrow` keys. This is another reason to setup kafka locally.

### 2. Create a topic

```bash
kafka-topics.sh --create --topic music-playlist-events \
--replication-factor 1 \
--partitions 3 \
--bootstrap-server localhost:9093
```

### 3. Describe the Topic

```
kafka-topics.sh --describe --topic music-playlist-events --bootstrap-server localhost:9093
```

### 4. Send some data to the topic using a producer

```bash
kafka-console-producer.sh --topic music-playlist-events --bootstrap-server localhost:9093
```

#### Example:

```
❯ kafka-console-producer.sh --topic music-playlist-events --bootstrap-server localhost:9093
>rock
>jazz
>blues
>jazz
>
```

#### 5. Consume the data using a consumer (or multiple consumers)

Open a new terminal, and run below command to consume data

```bash
kafka-console-consumer.sh --topic music-playlist-events --from-beginning --bootstrap-server localhost:9093
```

#### Example: (note that ordering may be different in your case)

```
❯ kafka-console-consumer.sh --topic music-playlist-events --from-beginning --bootstrap-server localhost:9093
jazz
blues
rock
jazz
```

Try sending more data from producer terminal and watch them appear on the consumer one. 

Optionally, try opening another terminal and create another consumer to retrieve the records again on that consumer.

---

This concludes kafka setup lab. You're free to try out other demos (non-prescriptive) in this repo or try things on your own. 
