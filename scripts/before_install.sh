#!/bin/bash

DIR="/home/ubuntu/Iris"
 if [ -d "$DIR" ]; then
    echo "S{DIR} exists"
 else
    echo "creating ${DIR} directory"
    mkdir ${DIR}
 fi
