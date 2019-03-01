# Hair Salon Webpage
## by Tanner Damron

## Description
This webpage lets users see stylists and clients, and lets users add stylists and add/update clients to specific stylists.

## Specifications
* User can add new stylists
* User can see list of all stylists
* User can add new clients to specific stylist
* User can select a stylist, see details of stylist, and see all clients that belong to that stylist
* User can update client name 


### Setup Instructions
Download .NET Core 1.1.4 SDK and .NET Core Runtime 1.1.2 and MAMP and install them.

* Clone repository
* Add it to your desktop using "git clone "https://github.com/tannerdamron/HairSalon.Solution""
* Open in preferred text editor to see all code used
* Open MAMP (make sure Apache port is 8888 & MySql port is 8889) and start both the Apache serve and the MySql server
* !Database must be created first to use webpage!
* In the Command Prompt or Terminal use the command "mysql -uroot -proot"
* Use the following SQL commands in MySql to create database:
* > "CREATE DATABASE hair_salon;"
* > "USE hair_salon;"
* > "CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255));"
* > "CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255)), stylist_id INT;"
* > "CREATE DATABASE hair_salon_test;"
* > "USE hair_salon_test;"
* > "CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255));"
* > "CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255)), stylist_id INT;"
* To use the webpage, first navigate to the directory "HairSalon"
* Use the following commands:
* > "dotnet restore"
* > "dotnet build"
* > "dotnet run"
* Then go to "http://localhost:5000" to see webpage
* To run the tests, use these commands from the directory "HairSalon.Solution": 
* > "cd HairSalon.Tests"
* > "dotnet test"

### Known Bugs
* No Known Bugs

### Languages/Libraries Used
* C#
* .NET
* MAMP
* MySql
* PhpMyAdmin

### GitHub Repository Link
https://github.com/tannerdamron/HairSalon.Solution

### Support or Contact
* For any questions or suggestions email me at tanner.mdamron@gmail.com

Copyright (c) 2019 Tanner Damron.
