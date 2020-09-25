#!/bin/bash

if [ -z $1 ] || [ -z $2 ] || [ -z $3 ]
then
        echo "missing parameters: CourseId, AssignmentId and ProjectId is required"
        exit 1
fi

mkdir -p /srv/easy-lab/$1/$2/$3/{src,bin}

cd /srv/easy-lab/$1/$2/$3/src/

touch App.java

echo "public class App {
    public static void main(String[] args) throws Exception {
        System.out.println("Hello, World!");
    }
}" > App.java