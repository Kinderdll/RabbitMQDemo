# RabbitMqProductAPI
## RabbitMQ Demo Project

## Installation

Project requires visual studio 2022 , docker desktop.

Clone project and navigate to project folder.

Start Docker desktop

Open .sln using vs2022

Open Developer Powershell and type :

 -docker run -e ‘ACCEPT_EULA=Y’ -e ‘SA_PASSWORD=Str0ngPa$$w0rd’ -p 1433:1433 -d mcr.microsoft.com/mssql/server
 
 -docker run -d -p 15672:15672 -p 5672:5672 --name rabbitmq rabbitmq:3-management 


Open Package Manager Console
-update-database

(Azure Data Studio is a nice tool to check localhost sql server db)

Run solution using multiple project on StartUp (both api and console application)

Verify producer
```sh
https://localhost:7232/swagger/index.html
```
Verify RabbitMQ GUI
```sh
http://localhost:15672/#/
```

Use Swagger Post Endpoint to post a product in DB
Check Console that outputs consumer message (product posted)

Have fun :)

