Alter PROCEDURE [dbo].[Er_Getupdatedeatils] 
(
@employeeID int,
@employeeName  varchar (50),
@gender  varchar (1),
@salry int,
@startDate date,
@note  varchar (100),
@departmentName varchar(50),
@departmentName2 varchar(50),
@departmentName3 varchar(50),
@pic varchar(200)

)

AS
BEGIN
	DECLARE @row_count INTEGER


 update employee_Table  set EmployeeName =@employeeName, Gender=@gender, Salary=@salry, StartDate=@startDate, Notes=@note, Picture=@pic  where EmployeeID=@employeeID;
 update Department set EmployeeID=@employeeID, DepartmentName=@departmentName, DepartmentName2=@departmentName2, DepartmentName3=@departmentName3 where EmployeeID = @employeeID;
 	SELECT @row_count = @@ROWCOUNT;

	select employee_Table.EmployeeID,EmployeeName,Gender,Salary,StartDate,Picture,DepartmentName,DepartmentName2,DepartmentName3 from employee_Table
  left join Department on employee_Table.EmployeeID = Department.EmployeeID;
 
return @row_count
select @@identity
end

