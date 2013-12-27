/*1 Write a SQL query to find the names and salaries of the employees 
	that take the minimal salary in the company. Use a nested SELECT statement.*/
SELECT FirstName + ' ' + LastName AS [Employee's Name],
	   Salary
FROM Employees
WHERE Salary = (SELECT MIN(Salary) 
			   FROM Employees)

/*2 Write a SQL query to find the names and salaries of the employees 
that have a salary that is up to 10% higher than the minimal salary for the company.*/
SELECT FirstName + ' ' + LastName AS [Employee's Name],
	   Salary
FROM Employees
WHERE Salary BETWEEN (SELECT MIN(Salary)
						FROM Employees) 
				 AND (SELECT MIN(Salary) * 1.1
						FROM Employees)

/*3 Write a SQL query to find the full name, salary and department 
of the employees that take the minimal salary in their department. 
Use a nested SELECT statement.*/
SELECT emp.FirstName + ' ' + emp.LastName AS [Employee's Name],
	   emp.Salary,
	   dep.Name AS Department
FROM Employees AS emp 
	INNER JOIN Departments AS dep
	ON emp.DepartmentID = dep.DepartmentID
WHERE Salary = (SELECT MIN(Salary) 
			   FROM Employees)

/*4 Write a SQL query to find the average salary in the department #1.*/
SELECT AVG(Salary) AS [Average Salary]
  FROM Employees
 WHERE DepartmentID = 1

/*5 Write a SQL query to find the average salary  in the "Sales" department.*/
SELECT AVG(Salary) AS [Average Salary]
  FROM Employees AS emp 
	   INNER JOIN Departments AS dep
	ON emp.DepartmentID = dep.DepartmentID
  WHERE dep.Name = 'Sales'

/*6 Write a SQL query to find the number of employees in the "Sales" department.*/
SELECT COUNT(emp.EmployeeID) AS [Average Salary]
  FROM Employees AS emp 
	   INNER JOIN Departments AS dep
	ON emp.DepartmentID = dep.DepartmentID
  WHERE dep.Name = 'Sales'

/*7 Write a SQL query to find the number of all employees that have manager.*/
SELECT COUNT(ManagerID) FROM Employees 

/*8 Write a SQL query to find the number of all employees that have no manager.*/
SELECT COUNT(*) FROM Employees
WHERE ManagerID IS NULL

/*9 Write a SQL query to find all departments and the average salary for each of them.*/
SELECT dep.DepartmentID, dep.Name, AVG(emp.Salary)
FROM Departments AS dep 
	 INNER JOIN Employees AS emp
  ON dep.DepartmentID = emp.DepartmentID
GROUP BY dep.DepartmentID, dep.Name

/*10 Write a SQL query to find the count of all employees in each department and for each town.*/
SELECT dep.DepartmentID, dep.Name AS Department, t.Name AS Town, COUNT(emp.EmployeeID)
FROM Departments AS dep 
	 INNER JOIN Employees AS emp
  ON dep.DepartmentID = emp.DepartmentID
	 INNER JOIN Addresses as adr
  ON emp.AddressID = adr.AddressID
	 INNER JOIN Towns as t
  ON adr.TownID = t.TownID 
GROUP BY dep.DepartmentID, dep.Name,t.Name
ORDER BY Town, Department 

/*11 Write a SQL query to find all managers that have exactly 5 employees. 
Display their first name and last name.*/
SELECT mgr.FirstName + ' ' + mgr.LastName AS [Manager's Full Name]
FROM Employees as emp
	INNER JOIN Employees as mgr
	ON emp.ManagerID = mgr.EmployeeID
GROUP BY mgr.FirstName + ' ' + mgr.LastName
HAVING COUNT(emp.EmployeeID) = 5

/*12 Write a SQL query to find all employees along with their managers. 
	 For employees that do not have manager display the value "(no manager)".*/
SELECT emp.FirstName + ' ' + emp.LastName AS [Employee's Full Name]
	  , ISNULL( CONVERT(nvarchar(150), mgr.FirstName + ' ' + mgr.LastName ), '(no manager)') AS [Manager's Full Name]
FROM Employees as emp
	LEFT OUTER JOIN Employees as mgr
	ON emp.ManagerID = mgr.EmployeeID

/*13 Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. 
Use the built-in LEN(str) function.*/
SELECT FirstName + ' ' + LastName AS [Employee's Full Name]
FROM Employees
WHERE LEN(LastName) = 5

/*14 Write a SQL query to display the current date and time in the following format 
"day.month.year hour:minutes:seconds:milliseconds". Search in  Google to find how to format dates in SQL Server.*/
SELECT REPLACE (CONVERT(nvarchar, GETDATE(), 105), '-', '.') + ' ' + CONVERT(nvarchar, GETDATE(), 114)

/*15 Write a SQL statement to create a table Users. Users should have username, password, full name and last login time. 
	Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint. 
	Define the primary key column as identity to facilitate inserting records. Define unique constraint to avoid repeating usernames. 
	Define a check constraint to ensure the password is at least 5 characters long.*/
	CREATE TABLE Users(
	UserID int IDENTITY NOT NULL,
	UserName nvarchar(150) NOT NULL, 
	Pwd nvarchar(20) NOT NULL, 
	FullName nvarchar(150) NOT NULL, 
	LastLoginTime datetime,
	CONSTRAINT PK_Users PRIMARY KEY(UserID), 
	CONSTRAINT UN_Users UNIQUE(UserName),
	CONSTRAINT CHK_USERS CHECK(LEN(Pwd)>=5), 
	)
	GO
 
/*16 Write a SQL statement to create a view that displays the users from the 
Users table that have been in the system today. Test if the view works correctly.*/
USE TelerikAcademy
GO
CREATE VIEW TodayLogedUsers AS
SELECT * FROM Users
WHERE CONVERT(date, LastLoginTime) = CONVERT(date, GETDATE()) 
GO


/*17 Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint). 
	 Define primary key and identity column.*/
CREATE TABLE Groups(
	GroupId int IDENTITY,
	Name varchar(50) NOT NULL,
	CONSTRAINT PK_Groups PRIMARY KEY(GroupId),
	CONSTRAINT UK_Groups UNIQUE(Name)
)

/*18 Write a SQL statement to add a column GroupID to the table Users. 
Fill some data in this new column and as well in the Groups table. 
Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.*/
ALTER TABLE Users ADD GroupId int
ALTER TABLE Users ADD CONSTRAINT FK_Users_Group
	FOREIGN KEY (GroupId)
	REFERENCES Groups(GroupId)
	
/*19 Write SQL statements to insert several records in the Users and Groups tables.*/
INSERT INTO Users(UserName, Pwd, FullName, GroupID)
	   VALUES ('jaky', 'bakibaki', 'Jaklin Kostadinova',1),
			  ('daka', 'dakabaka', 'Daniel Marinov', 2)

INSERT INTO Groups(Name)
VALUES ('Pichove'), 
	   ('Karabataci')


/*20 Write SQL statements to update some of the records in the Users and Groups tables.*/
UPDATE Users
SET LastLoginTime = GETDATE()
WHERE LastLoginTime IS NULL
/*21 Write SQL statements to delete some of the records from the Users and Groups tables.*/
DELETE Groups
WHERE Name = 'Karabataci'
/*22 Write SQL statements to insert in the Users table the names of all employees from the Employees table. 
Combine the first and last names as a full name. For username use the first letter of the first name + the last name (in lowercase). 
Use the same for the password, and NULL for last login time.*/
ALTER TABLE Users DROP CONSTRAINT UN_Users;
GO
INSERT INTO USERS(UserName, Pwd, FullName)
SELECT DISTINCT LOWER(SUBSTRING(FirstName, 1, 1) + LastName) AS [User name],
	   '12345678',
	   FirstName + ' ' + LastName AS [Name]
FROM Employees

ALTER TABLE Users ADD CONSTRAINT UN_Users UNIQUE(UserName)
GO

/*23 Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.*/
UPDATE Users
SET Pwd = NULL
WHERE CONVERT(DATE,LastLoginTime) <= '20100310'

/*24 Write a SQL statement that deletes all users without passwords (NULL password).*/
DELETE Users
WHERE Pwd IS NULL

/*25 Write a SQL query to display the average employee salary by department and job title.*/
SELECT dep.DepartmentID, dep.Name, emp.JobTitle, AVG(emp.Salary)
FROM Departments AS dep 
	 INNER JOIN Employees AS emp
  ON dep.DepartmentID = emp.DepartmentID
GROUP BY dep.DepartmentID, dep.Name,emp.JobTitle

/*26 Write a SQL query to display the minimal employee salary by department and job title 
along with the name of some of the employees that take it.*/
SELECT dep.DepartmentID, dep.Name, emp.JobTitle, MIN(emp.Salary), MIN(emp.FirstName + ' ' + emp.LastName)
FROM Departments AS dep 
	 INNER JOIN Employees AS emp
  ON dep.DepartmentID = emp.DepartmentID
GROUP BY dep.DepartmentID, dep.Name,emp.JobTitle

/*27 Write a SQL query to display the town where maximal number of employees work.*/
SELECT TOP 1 t.Name AS Town
FROM Employees AS emp
	 INNER JOIN Addresses as adr
  ON emp.AddressID = adr.AddressID
	 INNER JOIN Towns as t
  ON adr.TownID = t.TownID
GROUP BY t.Name
ORDER BY COUNT(emp.EmployeeID) DESC 

/*28 Write a SQL query to display the number of managers from each town.*/
SELECT t.Name AS Town,
		COUNT(emp.EmployeeID)
FROM Employees AS emp
	 INNER JOIN Addresses as adr
  ON emp.AddressID = adr.AddressID
	 INNER JOIN Towns as t
  ON adr.TownID = t.TownID
WHERE ManagerID IS NULL
GROUP BY t.Name
 
/*29 Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments). 
Don't forget to define  identity, primary key and appropriate foreign key.
	Issue few SQL statements to insert, update and delete of some data in the table.
	Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. 
	For each change keep the old record data, the new record data and the command (insert / update / delete)*/
CREATE TABLE WorkHours(
        EmployeeID int IDENTITY,
        [Date] datetime,
        Task nvarchar(50),
        [Hours] int,
        Comment nvarchar(50),
        CONSTRAINT PK_WorkHours PRIMARY KEY(EmployeeID),
        CONSTRAINT FK_WorkHours_Employees FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID)
)

INSERT INTO WorkHours(Date, Task, Hours)
VALUES
        (getdate(), 'Sample Task1', 23),
        (getdate(), 'Sample Task2', 3)

DELETE FROM WorkHours
WHERE Task LIKE '%Task1'

UPDATE WorkHours
SET HOURS = 10
WHERE Task = 'Sample Task2'

CREATE TABLE WorkHoursLog(
        Id int IDENTITY,
        OldRecord nvarchar(100) NOT NULL,
        NewRecord nvarchar(100) NOT NULL,
        Command nvarchar(10) NOT NULL,
        EmployeeId int NOT NULL,
        CONSTRAINT PK_WorkHoursLog PRIMARY KEY(Id),
        CONSTRAINT FK_WorkHoursLogs_WorkHours FOREIGN KEY(EmployeeId) REFERENCES WorkHours(EmployeeID)
)
GO

CREATE TRIGGER tr_WorkHoursInsert ON WorkHours FOR INSERT
AS
        INSERT INTO WorkHoursLog(OldRecord, NewRecord, Command, EmployeeId)
        Values(' ',
                   (SELECT 'Day: ' + CAST(Date AS nvarchar(50)) + ' ' + ' Task: ' + Task + ' ' + ' Hours: ' + CAST([Hours] AS nvarchar(50)) + ' ' + Comment 
                        FROM Inserted),
                   'INSERT',
                   (SELECT EmployeeID FROM Inserted))
GO

CREATE TRIGGER tr_WorkHoursUpdate ON WorkHours FOR UPDATE
AS
        INSERT INTO WorkHoursLog(OldRecord, NewRecord, Command, EmployeeId)
        Values((SELECT 'Day: ' + CAST(Date AS nvarchar(50)) + ' ' + ' Task: ' + Task + ' ' + ' Hours: ' + CAST([Hours] AS nvarchar(50)) + ' ' + Comment FROM Deleted),
                   (SELECT 'Day: ' + CAST(Date AS nvarchar(50)) + ' ' + ' Task: ' + Task + ' ' + ' Hours: ' + CAST([Hours] AS nvarchar(50)) + ' ' + Comment FROM Inserted),
                   'UPDATE',
                   (SELECT EmployeeID FROM Inserted))
GO

CREATE TRIGGER tr_WorkHoursDeleted ON WorkHours FOR DELETE
AS
        INSERT INTO WorkHoursLog(OldRecord, NewRecord, Command, EmployeeId)
        Values((SELECT 'Day: ' + CAST(Date AS nvarchar(50)) + ' ' + ' Task: ' + Task + ' ' + ' Hours: ' + CAST([Hours] AS nvarchar(50)) + ' ' + Comment FROM Deleted),
                   ' ',
                   'DELETE',
                   (SELECT EmployeeID FROM Deleted))
GO

INSERT INTO WorkHours([Date], Task, Hours, Comment)
VALUES(GETDATE(), 'Random task4', 12, 'Comment4')

DELETE FROM WorkHours
WHERE Task = 'Random task3'

UPDATE WorkHours
SET Task = 'Random task12'
WHERE EmployeeID = 8

--TASK 30 Start a database transaction, delete all employees from the 'Sales' department 
--along with all dependent records from the pother tables. At the end rollback the transaction.
BEGIN TRAN
DELETE FROM Employees
        SELECT d.Name
        FROM Employees e JOIN Departments d
        ON e.DepartmentID = d.DepartmentID
        WHERE d.Name = 'Sales'
        GROUP BY d.Name
ROLLBACK TRAN
/*30 Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the pother tables. At the end rollback the transaction.*/
/*31 Start a database transaction and drop the table EmployeesProjects. Now how you could restore back the lost table data?*/
/*32 Find how to use temporary tables in SQL Server. Using temporary tables backup all records 
from EmployeesProjects and restore them back after dropping and re-creating the table.*/


