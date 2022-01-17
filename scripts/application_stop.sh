#!/bin/bash

echo "stopping Testr.API application now"
pm2 stop all
pm2 delete all  
