# kafka-workshop

## Installation Options:

Take a look at install directory for installation options. 

### Local setup (recommended)
1. Use docker-compose for a quick and easy single-node-broker setup
    * The above will provide access to kafka broker via `localhost:9093` from local machine.
    * see `docker-compose` inside `install` directoy.

2. Optionally, install `kafka` locally, so you can use its Command-Line Interface. 
    * See `local` directory inside `install` folder
    * If you don't have `docker`, then you'll also have the option to run kafka server directly.
    
---
>Don't worry about Kubernetes for now. It is mainly for running demos.
---

### WSL2 - Volume data for Docker Desktop if using Windows Subsystem for Linux (WSL2)
* If you're running docker using WSL2, then the data for kafka can be found below location. 

* Open this in file explorer
```
\\wsl$\docker-desktop-data\version-pack-data\community\docker\volumes\docker-compose_kafka_data\_data\kafka\data

# or if you don't know the name of the container
\\wsl$\docker-desktop-data\version-pack-data\community\docker\volumes
```

For Linux, see:
https://docs.docker.com/storage/#:~:text=Volumes%20are%20stored%20in%20a,%2Fvolumes%2F%20on%20Linux).

---
