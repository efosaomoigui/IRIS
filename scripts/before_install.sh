#!/bin/bash

pm2 stop all
pm2 delete all


DIR="/home/ubuntu/Iris"
 if [ -d "$DIR" ]; then
    echo "S{DIR} exists"
 else
    echo "creating ${DIR} directory"
    mkdir ${DIR}
 fi
