#!/bin/bash
echo "application stop now!"
sudo pm2 stop all
sudo pm2 delete all


