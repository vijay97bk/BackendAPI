use [Employee_Payroll_Backend]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[Er_GetOneEmployee] 
@id int
AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
select employee_Table.EmployeeId,EmployeeName,Gender,Salary,StartDate,Notes,Picture,DepartmentName,DepartmentName2,DepartmentName3 from employee_Table
  left join department on employee_Table.EmployeeID = Department.EmployeeID where employee_Table.EmployeeID= @id;
  select @@identity
END


