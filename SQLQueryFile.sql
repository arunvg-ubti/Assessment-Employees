--Creating Database 'EmployeesAssessment'
create database EmployeesAssessment;
go

--Using this db
use EmployeesAssessment;
go

--Creating table Employees
create table Employees(Id int primary key,Name nvarchar(max),
Position nvarchar(max), Salary decimal(20,2));