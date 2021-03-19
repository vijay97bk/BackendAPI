select * from sys.databases;
USE Employee_Payroll_Backend;

create table employee_Table(
EmployeeID int not null identity(1,1) primary key,
EmployeeName varchar(150) not null,
Gender varchar(10) not null,
Salary bigint not null,
StartDate date not null,
Notes varchar(250)
);

create table Department(
EmployeeID int not null,
DepartmentName varchar(50),
foreign key (EmployeeID) references Employee_table(EmployeeID)
);

insert into employee_Table (EmployeeName, Gender, Salary,StartDate)
values ('Ramesh', 'M',150000,'2001-10-01' );
insert into employee_Table (EmployeeName, Gender, Salary,StartDate)
values ('Rohish', 'M',120000,'2002-01-08' ),
 ('Nikita', 'F',155000,'2001-11-22' ), 
 ('Priyanka', 'F',110000,'2003-04-04' ),
 ('Avinash', 'M',90000,'2006-05-25' );

 select * from employee_Table;
 select * from Department;

 insert into Department(EmployeeID)
 select EmployeeID from employee_Table;
 insert into Department(DepartmentName)

 alter table Department
 add DepartmentName2 varchar(50), DepartmentName3 varchar(50);

 update Department set DepartmentName2='Finance' where EmployeeID=1 or EmployeeID=4;
update Department set DepartmentName2='HR', DepartmentName3='IT' where EmployeeID=3;

