use Company_SD;

--1. Display the Department id, name and id and the name of its manager.
select Dnum as 'Department Id', x.fname + ' ' + x.lname as Name,y.fname + ' ' + y.lname as 'Manager Name'
from Departments dept, Employee x, Employee y
where dept.Dnum = x.Dno and y.SSN = x.Superssn;

--2. Display the name of the departments and the name of the projects under its control.
select Dname, Pname
from Departments dept, Project pro
where dept.Dnum = pro.Dnum

--3. Display the full data about all the dependence associated with the name of the employee they depend on him/her.
select fname + ' ' + lname, dep.*
from Employee emp, Dependent dep
where emp.SSN = dep.ESSN

--4. Display the Id, name and location of the projects in Cairo or Alex city.
select pnumber, pname, plocation
from Project
where project.City = 'Cairo' or project.City = 'Alex';

--5. Display the Projects full data of the projects with a name starts with "a" letter.
select * 
from Project
where pname like 'a%';

--6. display all the employees in department 30 whose salary from 1000 to 2000 LE monthly
select *
from Employee
where Dno = 30 and Salary >= 1000 and Salary <= 2000;

--7. Retrieve the names of all employees in department 10 who works more than or equal 10 hours per week on "AL Rabwah" project.
select fname + ' ' + lname as 'Full Name'
from Employee emp, Works_for w, Project proj
where emp.Dno = proj.Dnum and proj.Pnumber = w.Pno and emp.Dno = 10 and w.Hours >= 10 and proj.Pname = 'AL Rabwah';

--8. Find the names of the employees who directly supervised with Kamel Mohamed.
select x.fname + ' ' + x.lname as 'Full Name'
from Employee x, Employee y
where y.SSN = x.Superssn and y.Fname='Kamel' and y.Lname = 'Mohamed'

--9. Retrieve the names of all employees and the names of the projects they are working on, sorted by the project name.
select fname + ' ' + lname as 'Full Name', pname as 'Project Name'
from Employee emp, Works_for wf, Project proj
where emp.SSN = wf.ESSn and wf.Pno = proj.Pnumber
order by proj.Pname;

--10. For each project located in Cairo City , find the project number, the controlling department name ,the department manager last name ,address and birthdate.
select pnumber, dname, lname, address, bdate
from Project proj, Departments dept, Employee emp
where proj.Dnum = dept.Dnum and dept.MGRSSN = emp.SSN and proj.City = 'cairo' 

--11. Display All Data of the mangers
select emp.*
from Employee emp, Departments dept
where dept.MGRSSN = emp.SSN

--12. Display All Employees data and the data of their dependents even if they have no dependents
select * 
from Employee 
where SSN not in (select ESSN from Dependent)

------------- Data Manipulating Language:
--1. Insert your personal data to the employee table as a new employee in department number 30, SSN = 102672, Superssn = 112233, salary=3000.
insert into employee (ssn,fname,lname, dno, superssn, salary)
values (102672,'Omar','Elsayed', 30, 112233, 3000);
--2. Insert another employee with personal data your friend as new employee in department number 30, SSN = 102660, but don’t enter any value for salary or manager number to him.
insert into employee (ssn, dno)
values (102660, 30);
--3. Upgrade your salary by 20 % of its last value.
update employee
set salary = salary * 1.2
where ssn = 102672;
