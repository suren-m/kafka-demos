docker-compose down
docker volume rm $(docker volume ls -f name=docker-compose_zookeeper_data -q)
docker volume rm $(docker volume ls -f name=docker-compose_kafka_data -q)

# docker rm -f $(docker ps -a -f name=docker-compose_zookeeper_1 -q)
# docker rm -f $(docker ps -a -f name=docker-compose_kafka_1 -q)