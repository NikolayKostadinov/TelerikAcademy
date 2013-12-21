/*4*/
SELECT * From Departments

/*5*/
SELECT Name FROM Departments

/*6*/
SELECT Salary FROM Employees

/*7*/
SELECT FirstName + ' ' + LastName AS [Full Name] FROM Employees

/*8*/
SELECT FirstName + '.' + LastName + '@telerik.com' AS [Full Email Addresses]
FROM Employees

/*9.Write a SQL query to find all different employee salaries.*/
SELECT DISTINCT Salary From Employees

/*10 Write a SQL query to find all information 
  about the employees whose job title is “Sales Representative“.*/
SELECT * 
FROM Employees
WHERE JobTitle = 'Sales Representative'

/*11 Write a SQL query to find the names of all employees 
whose first name starts with "SA".*/
	SELECT FirstName, LastName 
	FROM Employees
	WHERE FirstName LIKE 'SA%'

/*12 Write a SQL query to find the names of all employees whose last name contains "ei".*/
SELECT FirstName + ' ' + LastName AS [Full Name]
FROM Employees
WHERE Lastname LIKE '%ei%'

/*13 Write a SQL query to find the salary of 
all employees whose salary is in the range [20000…30000].*/
SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

/*14 Write a SQL query to find the names of 
all employees whose salary is 25000, 14000, 12500 or 23600.*/
SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)

/*15 Write a SQL query to find all employees that do not have manager.*/
SELECT FirstName + ' ' + LastName AS [Full Name]
FROM Employees
WHERE ManagerID IS NULL

/*16 Write a SQL query to find all employees that have salary more than 50000. 
Order them in decreasing order by salary.*/
SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
WHERE Salary > 50000
ORDER BY Salary

/*17 Write a SQL query to find the top 5 best paid employees. */
SELECT TOP 5 FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
ORDER BY Salary DESC

/*18 Write a SQL query to find all employees along with their address. 
     Use inner join with ON clause.*/
SELECT FirstName + ' ' + LastName AS [Full Name],  
		t.Name + ' ' + adr.AddressText as [Full Address]
FROM Employees AS emp INNER JOIN Addresses AS adr
	ON emp.AddressID = adr.AddressID
INNER JOIN Towns AS t
	ON adr.TownID = t.TownID

/*19 Write a SQL query to find all employees and their address. 
Use equijoins (conditions in the WHERE clause). */

SELECT FirstName + ' ' + LastName AS [Full Name],  
		t.Name + ' ' + adr.AddressText AS [Full Address]
FROM Employees AS emp , Addresses AS adr,Towns AS t
WHERE (emp.AddressID = adr.AddressID) AND 
	  (adr.TownID = t.TownID)

/*20 Write a SQL query to find all employees along with their manager.*/
SELECT emp.EmployeeID AS [¹], emp.FirstName + ' ' + emp.LastName AS [Emploee's Full Name], 
	   mgr.FirstName + ' ' + mgr.LastName AS [Emploee's Full Name]
FROM Employees AS emp LEFT OUTER JOIN Employees AS mgr
	ON emp.ManagerID = mgr.EmployeeID
ORDER BY emp.EmployeeID

/*21 Write a SQL query to find all employees, along with their manager and their address. 
     Join the 3 tables: Employees e, Employees m and Addresses a.*/
SELECT emp.EmployeeID AS [¹], emp.FirstName + ' ' + emp.LastName AS [Emploee's Full Name], 
	   mgr.FirstName + ' ' + mgr.LastName AS [Emploee's Full Name],
	   t.Name + ' ' + adr.AddressText AS [Full Address]
FROM Employees AS emp LEFT OUTER JOIN Employees AS mgr
	ON emp.ManagerID = mgr.EmployeeID
INNER JOIN Addresses AS adr
	ON emp.AddressID = adr.AddressID
INNER JOIN Towns AS t
	ON adr.TownID = t.TownID
ORDER BY emp.EmployeeID

/*22 Write a SQL query to find all departments and all town names as a single list. Use UNION.*/
SELECT Name FROM Departments
UNION
SELECT Name FROM Towns

/*23 Write a SQL query to find all the employees 
	 and the manager for each of them along with the employees that do not have manager. 
	 Use right outer join. Rewrite the query to use left outer join.*/
SELECT emp.EmployeeID AS [¹], emp.FirstName + ' ' + emp.LastName AS [Emploee's Full Name], 
	   mgr.FirstName + ' ' + mgr.LastName AS [Emploee's Full Name]
FROM  Employees AS mgr RIGHT OUTER JOIN Employees AS emp
	ON emp.ManagerID = mgr.EmployeeID

SELECT emp.EmployeeID AS [¹], emp.FirstName + ' ' + emp.LastName AS [Emploee's Full Name], 
	   mgr.FirstName + ' ' + mgr.LastName AS [Emploee's Full Name]
FROM Employees AS emp LEFT OUTER JOIN Employees AS mgr
	ON emp.ManagerID = mgr.EmployeeID

/*24 Write a SQL query to find the names of all employees 
	 from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005*/
SELECT EmployeeID AS [¹], 
	   FirstName + ' ' + LastName AS [Emploee's Full Name],
	   dep.Name AS Department,
	   emp.HireDate AS [Hire Date]
FROM Employees emp INNER JOIN Departments dep ON
	emp.DepartmentID = dep.DepartmentID
WHERE ((dep.Name = 'Sales') OR (dep.Name = 'Finance')) AND
	  (emp.HireDate BETWEEN '19950101' AND '20051231')
ORDER BY emp.HireDate
