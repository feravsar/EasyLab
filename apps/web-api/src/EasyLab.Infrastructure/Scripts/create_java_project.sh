#!/bin/bash

if [ -z $1 ] || [ -z $2 ] || [ -z $3 ]
then
        echo "missing parameters: CourseId, AssignmentId and ProjectId is required"
        exit 1
fi

mkdir -p /home/20195175002/$1/$2/$3/{src,bin}

cd /home/20195175002/$1/$2/$3/src/

touch App.java

echo "public class App {
    public static void main(String[] args) throws Exception {
        System.out.println("Hello, World!");
    }
}" > App.java