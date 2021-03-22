
Alter PROCEDURE [dbo].[DeleteContact]
( @id int)
AS
BEGIN
	
	SET NOCOUNT ON;
	Delete from employee_Table where EmployeeID=@id;
	end