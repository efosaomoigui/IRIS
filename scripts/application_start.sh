#!/bin/bash

 cd /home/ubuntu/IRIS.BCK.Api
 sudo dotnet build
 
 cd /home/ubuntu/IRIS.BCK.Api
 sudo dotnet build
 pm2 start 'dotnet run  --urls "http://localhost:5000"' --name IRIS
