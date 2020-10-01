#!/bin/bash

if [ -z $1 ] || [ -z $2 ] || [ -z $3 ]
then
        echo "missing parameters: CourseId, AssignmentId and ProjectId is required"
        exit 1
fi

cd /srv/easy-lab/$1/$2/$3/

javac -d bin/ $(find . -name "*.java")