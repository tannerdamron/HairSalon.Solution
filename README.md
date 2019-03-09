# Hair Salon Webpage
## by Tanner Damron

## Description
This webpage lets users see Stylists, Clients, and Specialties, and lets users add stylists and specialties. It will also allow users to add/update clients to specific stylists, as well as add specialties by themselves or to specific stylists. The user can also delete clients and stylists, and change the name of clients and stylists. The user can view a list of all clients, and see which stylist the client is attached to. The user can view a list of all specialties and add a stylist to them as well.

## Specifications
* User can add new stylists
* > Input: "Jane"
* > Output: Creates stylist with the name: "Jane"
* User can see list of all stylists
* User can add new clients to specific stylist
* > Input: "Jim"
* > Output: Creates client with the name: "Jim"
* User can select a stylist, see details of stylist, and see all clients and specialties that belong to that stylist
* User can update client information
* > Input: "Jim"
* > Output: Update client name with the name: "Jimbo"
* User can delete all or single stylists
* User can delete all or single clients
* User can view a list of all or single clients
* User can update stylist name
* > Input: "Janey"
* > Output: Update client name with the name: "Janey"
* User can add a specialty
* > Input: "Bob Cut"
* > Output: Creates a specialty of: "Bob Cut"
* User can view all specialties
* User can add a specialty to specific stylist
* User can view specialty and see all stylists that have that specialty
* User can add a stylist a stylist to a specialty from a specialty page


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
* > CREATE TABLE specialities (id serial PRIMARY KEY, name VARCHAR(255));
* > CREATE TABLE specialities_stylists (id serial PRIMARY KEY, speciality_id INT, stylist_id INT;
* > "CREATE DATABASE hair_salon_test;"
* > "USE hair_salon_test;"
* > "CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255));"
* > "CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255)), stylist_id INT;"
* > CREATE TABLE specialities (id serial PRIMARY KEY, name VARCHAR(255));
* > CREATE TABLE specialities_stylists (id serial PRIMARY KEY, speciality_id INT, stylist_id INT;
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
