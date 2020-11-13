#!/bin/bash

if [ -z $1 ] || [ -z $2 ]
then
        echo "missing parameter: Username and ProjectId is required"
        exit 1
fi

mkdir -p /srv/easylab/$1/$2/{src,bin}

touch /srv/easylab/$1/$2/src/App.java

echo "public class App {
    public static void main(String[] args) throws Exception {
        System.out.println("Hello, World!");
    }
}" > /srv/easylab/$1/$2/src/App.java