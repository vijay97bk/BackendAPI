
Create PROCEDURE [dbo].[Er_GetAllEmployeedetails] 
AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
select employee_Table.EmployeeID,EmployeeName,Gender,Salary,StartDate,Notes,Picture,DepartmentName,DepartmentName2,DepartmentName3 from employee_Table
  left join department on employee_Table.EmployeeID = department.EmployeeID;
  

END