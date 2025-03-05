--Creating Database 'EmployeesAssessment'
create database EmployeesAssessment;
go

--Using this db
use EmployeesAssessment;
go

--Creating table Employees

--Added more fields in 'Employees' table
create table Employees(Id nvarchar(20) primary key,Name nvarchar(max),
Position nvarchar(max), Salary decimal(20,2), DateOfBirth datetime,
Email nvarchar(max), PhoneNumber nvarchar(max), Department nvarchar(max),
DateOfJoining datetime);
go

-- Creating table Users
create table Users(Username nvarchar(50) primary key,
Password nvarchar(50), IsAdmin bit);
go

INSERT INTO Employees (Id, Name, Position, Salary, DateOfBirth, Email, PhoneNumber, Department, DateOfJoining) VALUES
('E101', 'John Doe', 'Manager', 75000, '1985-07-23', 'john.doe@example.com', '+1-234-567-8901', 'Human Resources', '2020-01-15'),
('E102', 'Jane Smith', 'Developer', 65000, '1990-05-12', 'jane.smith@example.com', '+1-234-567-8902', 'IT', '2019-03-10'),
('E103', 'Alice Johnson', 'Sales Executive', 55000, '1988-11-30', 'alice.johnson@example.com', '+1-234-567-8903', 'Sales', '2021-06-25'),
('E104', 'Bob Brown', 'HR Specialist', 60000, '1992-02-18', 'bob.brown@example.com', '+1-234-567-8904', 'Human Resources', '2018-09-05'),
('E105', 'Carol White', 'Marketing Manager', 70000, '1987-08-14', 'carol.white@example.com', '+1-234-567-8905', 'Marketing', '2022-01-20');
go