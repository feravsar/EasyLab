#!/bin/bash

if [ -z $1 ] || [ -z $2 ] 
then
        echo "missing parameters: Username and ProjectId is required"
        exit 1
fi

cd /srv/easylab/$1/$2
javac -d bin/ $(find . -name "*.java");