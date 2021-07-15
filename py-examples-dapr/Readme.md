
# Python examples for kafka basics

### Requirements:

* Python - 3.x (preferably, 3.7 and above)
* Pip 
* Pipenv (Recommended for virtual-env)

### Make sure to have above tools installed according to your dev environment.

### Easy setup with Pip. (for those already familiar with python, see end of this document for pipenv approach)

1. Install `kafka-python` package globally

```
pip install kafka-python
```

2. Run the Python scripts in this directory in separate terminal tabs / panes as needed.

```bash
python orders_service.py

// separate tab
python shipment_service.py

// separate tab
python inventory_service.py
```

3. Add additional partitions as needed.

```
# See: create_partitions.py
python create_partitions.py
```

4. Spin up more instances of shipment and inventory services by running `python inventory_service.py` in additional termainals

5. Try out `keyed` messages by commenting out `producer.send` and uncommenting below line in `orders_service.py`. 

```py
# Make sure the indentation is correct
future = producer.send(
        globals.topic, key=b'discount-sale', value=str.encode(msg))
```

6. Now run orders service again and see the `discount-sale` orders go to same partition. 

7. If you're running multiple instances of shipment or order service, you'll notice only the group that is subscribed to the associated partition for discounted sale will receive the messages.

8. Take a look at https://kafka-python.readthedocs.io/en/master/usage.html for more usage examples.


### Using Pipenv (for those familiar with python and virtual env)

* Run pipenv from this directory. (or the directory you have setup)

```
pipenv install 
pipenv shell
# Now you can run above scripts in virtual env created by pipenv
```
