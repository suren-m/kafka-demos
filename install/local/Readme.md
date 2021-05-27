## Local Install on a Debian based linux. 

> ## For running the `kafka` server locally, try to use Docker-compose 

> ## Do this local install mainly to interact with kafka server running as a docker container.

#### This is just a reference. Your experience may vary depending on your linux distribution.

#### If you're on Mac, you may be able to install it via brew but make sure you have java / open-jdk installed.  

#### On Linux / WSL2

```bash
# Make sure java / openjdk-8 (recommended) is installed 
java -version

# If Java is not installed, then download open-jdk (min version 8)
# For example something like below (or specific version)
sudo apt install -y default-jdk

# ensure java is installed
java -version

# download kafka from any of the mirrors
# see: https://kafka.apache.org/downloads

curl -LO https://mirrors.gethosted.online/apache/kafka/2.8.0/kafka_2.13-2.8.0.tgz

# extract
tar -xvf kafka_2.13-2.8.0.tgz

# move it to your prefered location
# For example
mv kafka_2.13-2.8.0 ~./local/bin/

# Add the kafka binaries path to .bashrc either manually or by doing below.
# Make sure to only append. Notice the '>>' 
echo 'export PATH=$PATH:$HOME/.local/bin/kafka_2.13-2.8.0/bin' >> ~/.bashrc

# Restart shell
source ~/.bashrc

# There is no need to start the server if you're planning to just use the kafka cli to connect to a remote cluster / server
kafka-topics.sh --create --topic sample --bootstrap-server 'remote-server-ip:port'

# To start kafka server locally,open new terminal / tab
# Make sure ports 9092 and 2182 are not already taken

# first start zookeeper
zookeeper-server-start.sh ~/.local/bin/kafka_2.13-2.8.0/config/zookeeper.properties
# then open a new tab / terminal
# start kafka server
kafka-server-start.sh ~/.local/bin/kafka_2.13-2.8.0/config/server.properties

# to connect to local kafka server, 
kafka-topics.sh --create --topic sample --bootstrap-server 'localhost:9092'

# Optionally, feel free to change the data, logs location in kafka and zookeeper config (properties).
```


