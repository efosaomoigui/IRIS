#!/bin/bash

 sudo cp -r !(Iris) /home/ubuntu/Iris
 cd ./Iris/IRIS.BCK.Api
 sudo rm -rf bin/
 sudo rm -rf obj/
 sudo dotnet build
 pm2 start 'dotnet run  --urls "http://localhost:5000"' --name IRIS
