#!/bin/bash
echo "application stop now!"
cd /home/ubuntu/IRIS.BCK
sudo pm2 stop all
sudo pm2 delete all


