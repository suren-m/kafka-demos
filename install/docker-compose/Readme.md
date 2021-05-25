
## Easy Local Setup with Docker (Recommended)

1. Download or copy the contents of `docker-compose.yml` in this directory and save it locally

```bash
# from the directory where docker-compose.yml is located
docker-compose up -d
```
2. Later, if you want to do a clean restart of `kafka` and `zookeeper` containers, run

```bash
# Take a look at clean.sh
# From the directory you have `docker-compose.yml`, run `./clean.sh`
# The below will remove `kafka` and `zookeeper` containers and their volumes.
./clean.sh

# To start again, just run
docker-compose up -d
```

---


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
