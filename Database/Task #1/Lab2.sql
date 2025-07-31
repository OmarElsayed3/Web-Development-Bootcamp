use Company_SD;

------------ Lab 2 --------------
--1. Display all the employees Data.
select * from Employee;
--2. Display the employee First name, last name, Salary and Department number.
select fname,lname,salary,dno from Employee;
--3. Display all the projects names, locations and the department which is responsible about it.
select pname,plocation,dnum from Project;
--4. If you know that the company policy is to pay an annual commission for each employee with specific percent equals 10% of his/her annual salary .Display each employee full name and his annual commission in an ANNUAL COMM column (alias).
select concat(fname, ' ', lname) as Full_Name, salary * 12 * 0.10 as Annual_Commission
from Employee;

select fname + ' ' + lname as Full_Name, salary * 12 * 0.10 as Annual_Commission
from Employee;
--5. Display the employees Id, name who earns more than 1000 LE monthly.
select ssn, concat(fname, ' ', lname) as Full_Name
from Employee
where salary > 1000;
--6. Display the employees Id, name who earns more than 10000 LE annually.
select ssn, concat(fname, ' ', lname) as Full_Name
from Employee
where salary * 12 > 10000;
--7. Display the names and salaries of the female employees 
select concat(fname, ' ', lname) as Full_Name, salary
from Employee
where sex = 'F';
--8. Display each department id, name which managed by a manager with id equals 968574.
select dnum, dname from Departments
where mgrssn = 968574;
--9. Dispaly the ids, names and locations of  the pojects which controled with department 10.
select pnumber, pname, plocation from Project
where dnum = 10;
