#!/bin/bash
echo "application stop now!"
cd /home/ubuntu
sudo pm2 stop all
sudo pm2 delete all

