#!/bin/bash
echo "application stop now!"
cd /home/ubuntu/IRIS.BCK
pm2 describe appname > /dev/null
RUNNING=$?

if [ "${RUNNING}" -ze 0 ]; then
  pm2 stop all && pm2 delete all
fi;


