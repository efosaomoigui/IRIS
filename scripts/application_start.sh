#!/bin/bash

 cd /home/ubuntu/IRIS.BCK
 pm2 start 'dotnet run  --urls "http://localhost:5000"' --name IRIS
