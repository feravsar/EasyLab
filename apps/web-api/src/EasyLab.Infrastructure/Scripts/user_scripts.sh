#!/bin/bash
if [ -z $1 ]
then
        echo "missing parameters: username is required"
        exit 1
fi

sudo useradd $1 -d /srv/easylab/$1 -m -N -s /bin/false -g student
