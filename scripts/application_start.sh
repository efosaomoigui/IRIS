#!/bin/bash

 cd /home/ubuntu/IRIS.BCK/IRIS.BCK.Api
#  sudo rm -rf bin/
#  sudo rm -rf obj/
#  sudo dotnet build || { echo 'build failed' ; exit 1; }
 sudo chmod -R 777 /home/ubuntu/IRIS.BCK/IRIS.BCK.Api/
 sudo chown -R ubuntu:ubuntu /home/ubuntu/IRIS.BCK/IRIS.BCK.Api/
 sudo chmod -R 777 /home/ubuntu/IRIS.BCK/IRIS.BCK.Infrastructure.Files/
 sudo chown -R ubuntu:ubuntu /home/ubuntu/IRIS.BCK/IRIS.BCK.Infrastructure.Files/
 sudo chmod -R 777 /home/ubuntu/IRIS.BCK/IRIS.BCK.Infrastructure.Persistence/
 sudo chown -R ubuntu:ubuntu /home/ubuntu/IRIS.BCK/IRIS.BCK.Infrastructure.Persistence/
 sudo chown -R ubuntu:ubuntu ./bin
 sudo chown -R ubuntu:ubuntu ./obj
 sudo pm2 start 'dotnet run  --urls "http://localhost:5000"' --name IRIS
