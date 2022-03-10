#!/bin/bash
echo "application stop!"
cd /home/ubuntu
sudo pm2 stop all
sudo pm2 delete all

