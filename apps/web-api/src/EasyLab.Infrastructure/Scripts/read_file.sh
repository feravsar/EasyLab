#!/bin/bash

if [ -z $1 ] || [ -z $2 ] || [ -z $3 ] 
then
        echo "missing parameters: Username, ProjectId and File name required"
        exit 1
fi

cd /srv/easylab/$1/$2/src  

while IFS= read -r line
do
  echo "$line"
done < "$3"