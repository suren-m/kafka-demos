
## download or copy the contents of docker-compose.yml and save it locally

```bash
# from the directory where docker-compose.yml is located
docker-compose up -d
```

# OR to configure from the scratch

## See: https://hub.docker.com/r/bitnami/kafka/

1. Download from bitnami's repo
```
curl -sSL https://raw.githubusercontent.com/bitnami/bitnami-docker-kafka/master/docker-compose.yml > docker-compose.yml
```
2. configure docker-compose.yml as you prefer and then 

3. Run
```
docker-compose up -d
```
