#!/bin/bash

 cd /home/ubuntu/IRIS.BCK.Api
 sudo dotnet build
 
 cd /home/ubuntu/IRIS.BCK.Api
 sudo rm -rf bin/
 sudo rm -rf obj/
 sudo dotnet build
 sudo chown -R ubuntu:ubuntu ./bin
 sudo chown -R ubuntu:ubuntu ./obj
 pm2 start 'dotnet run  --urls "http://localhost:5000"' --name IRIS
