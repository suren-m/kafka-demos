
### Kafka streams

## If you're very new to Java, then this tutorial may be a bit challenging.

# For the streams app, you should be running java 8 and have Maven installed.

Example based on : https://kafka.apache.org/28/documentation/streams/quickstart

## Check Java / open-jdk version as below

```
❯ java -version
openjdk version "1.8.0_292"
OpenJDK Runtime Environment (build 1.8.0_292-8u292-b10-0+deb9u1-b10)
OpenJDK 64-Bit Server VM (build 25.292-b10, mixed mode)
```

## Check Maven is installed

```
# Take a look at maven install for the platform of your choice.
https://maven.apache.org/install.html

❯ mvn --version
Apache Maven 3.8.1 (05c21c65bdfed0f71a2f2ada8b84da59348c4c5d)
Maven home: /home/suren/.sdkman/candidates/maven/current
Java version: 1.8.0_292, vendor: Oracle Corporation, runtime: /usr/lib/jvm/java-8-openjdk-amd64/jre
Default locale: en_US, platform encoding: UTF-8
OS name: "linux", version: "5.4.72-microsoft-standard-wsl2", arch: "amd64", family: "unix"

```
---

Make sure kafka and zookeeper containers are running

```
docker ps
```

1. Create input topic

```
kafka-topics.sh --create \
    --bootstrap-server localhost:9093 \
    --replication-factor 1 \
    --partitions 1 \
    --topic streams-plaintext-input
```

2. Create output topic

```
kafka-topics.sh --create \
    --bootstrap-server localhost:9093 \
    --replication-factor 1 \
    --partitions 1 \
    --topic streams-wordcount-output \
    --config cleanup.policy=compact
```

3. Cd into the directory

```
cd streams.examples
```

4. Run the wordcount app

```
mvn clean package
mvn exec:java -Dexec.mainClass=myapps.WordCount
```

5. Open a separate terminal for producer to send some data

```
kafka-console-producer.sh --bootstrap-server localhost:9093 --topic streams-plaintext-input
```

6. Open another separate terminal for consumer

```
kafka-console-consumer.sh --bootstrap-server localhost:9092 \
    --topic streams-wordcount-output \
    --from-beginning \
    --formatter kafka.tools.DefaultMessageFormatter \
    --property print.key=true \
    --property print.value=true \
    --property key.deserializer=org.apache.kafka.common.serialization.StringDeserializer \
    --property value.deserializer=org.apache.kafka.common.serialization.LongDeserializer
```

7. Now Start sending some data from the producer terminal such as below

```
all streams lead to kafka
hello kafka streams
```

8. You should see output on consumer such as below

```
all	    1
streams	1
lead	1
to	    1
kafka	1
hello	1
kafka	2
streams	2
```

For more detailed example, take a look at: https://kafka.apache.org/28/documentation/streams/quickstart

If you're new to Maven, take a look at https://maven.apache.org/guides/getting-started/maven-in-five-minutes.html
