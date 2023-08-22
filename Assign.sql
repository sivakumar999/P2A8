drop database AdvancedDb
create database AdvancedDb
on primary
(name = AdvancedDb_data,
filename = 'M:\Simplilearn\mphasis\Phase-2\day-8\Assign8\AdvancedDb_data.mdf')
------------------------------

use AdvancedDb

-- Create the Employees table

create table Employees (
    EmployeeId int primary key,
    FirstName nvarchar(max),
    LastName nvarchar(max),
    BirthDate DATE
)

-- Create the Products table
create table Products (
    ProductId int primary key,
    ProductName nvarchar(max),
    Description nvarchar(max),
    Price MONEY,
    ReleaseDate datetime
)

select * from Products
-- Create the Orders table
create table Orders (
    OrderId int primary key,
    OrderDate datetime,
    Quantity smallint,
    Discount float,
    IsShipped bit
)