#!/bin/bash

if [ -z $1 ] || [ -z $2 ] || [ -z $3 ] 
then
        echo "missing parameter: Username, ProjectId and file name are required"
        exit 1
fi


printf '%s' "$4" > /srv/easylab/$1/$2/src/$3
