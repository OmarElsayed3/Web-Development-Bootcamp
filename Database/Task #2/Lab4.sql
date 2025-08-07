use Company_SD;

----------------- DQL ----------------------
--1. Display (Using Union Function)
	--a. The name and the gender of the dependence that's gender is Female and depending on Female Employee.
		select Dependent_name,sex
		from Dependent
		where sex = 'F'
		union
		select Dependent_name,d.sex
		from Dependent d , Employee e
		where e.Sex = 'F' and ESSN = ssn and d.Sex = 'F'
	--b. And the male dependence that depends on Male Employee.
		select Dependent_name,sex
		from Dependent
		where sex = 'M'
		union
		select Dependent_name,d.sex
		from Dependent d , Employee e
		where e.Sex = 'M' and ESSN = ssn and d.Sex = 'M'
--2. For each project, list the project name and the total hours per week (for all employees) spent on that project.
	select p.Pname,sum(w.Hours)
	from project p,Works_for w
	where p.Pnumber = w.Pno
	group by pname

--3. Display the data of the department which has the smallest employee ID over all employees' ID.
	--using top()
	select *
	from Departments
	where Dnum in (
		select top(1) dno
		from Employee
		group by dno 
		order by count(dno) asc
	);
	--using subquery
	select *
	from Departments
	where Dnum in (
		select dno
		from (
			select dno, count(*) AS emp_count
			from Employee
			group by dno
		) as counts
		where emp_count = (
			select min(emp_count)
			from (
				select count(*) as emp_count
				from Employee
				group by dno
			) as inner_counts
		)
	);


--4. For each department, retrieve the department name and the maximum, minimum and average salary of its employees.
	select dname, max(salary) as maximum, min(salary) as minimum, avg(salary) as average
	from Departments,Employee
	where dno = Dnum
	group by dname

--5. List the last name of all managers who have no dependents.
	select x.ssn, x.lname as lastName
	from Employee x inner join Employee y
	on y.SSN = x.Superssn
	where x.ssn not in (
		select essn 
		from Dependent
	)
--6. For each department-- if its average salary is less than the average salary of all employees-- display its number, name and number of its employees.
	select Dnum,dname,count(ssn)
	from Departments,Employee
	where Dno = Dnum 
	group by Dnum,Dname
	having avg(salary) < (
		select avg(salary)
		from Employee
	);
	
--7. Retrieve a list of employees and the projects they are working on ordered by department and within each department, ordered alphabetically by last name, first name.
	select fname + ' ' + lname as FullName, pname
	from Employee e , Works_for w, project p
	where e.ssn = w.ESSn and p.Pnumber = w.Pno
	order by dno, fname, lname
--8. Try to get the max 2 salaries using subquery
	select max(salary)
	from employee
	where salary not in (
		select max(salary)
		from employee
	)	
	union
	select max(salary)
	from employee

--9. Get the full name of employees that is similar to any dependent name
	select fname + ' ' + lname as fullname
	from Employee
	where (fname + ' ' + lname) in (
		select Dependent_name
		from Dependent
	);
--10. Try to update all salaries of employees who work in Project ‘Al Rabwah’ by 30% 
	update employee
	set Salary += Salary * 0.3
	where ssn in (
		select w.ESSn
		from Works_for w, project p
		where w.Pno = p.Pnumber and p.Pname = 'Al Rabwah'
	)
--11. Display the employee number and name if at least one of them have dependents (use exists keyword) self-study.
	select ssn, fname + ' ' + lname as fullname
	from Employee e
	where exists (
		select *
		from Dependent
		where ssn = essn
	);

-------------------- DML ---------------------------------

--1. In the department table insert new department called "DEPT IT" , with id 100, employee with SSN = 112233 as a manager for this department. The start date for this manager is '1-11-2006'
	insert into Departments(Dname,Dnum,[MGRStart Date],MGRSSN) values ('DEPT IT',100,'1-11-2006',112233)
--2. Do what is required if you know that : Mrs.Noha Mohamed(SSN=968574)  moved to be the manager of the new department (id = 100), and they give you(your SSN =102672) her position (Dept. 20 manager) 
	--a. First try to update her record in the department table
		update Departments 
		set MGRSSN = '968574', 
		[MGRStart Date] = GETDATE()
		where Dnum = 100;
	--b. Update your record to be department 20 manager.
		update Departments
		set MGRSSN = '102672',
		[MGRStart Date] = GETDATE()
		where Dnum = 20;
	--c. Update the data of employee number=102660 to be in your teamwork (he will be supervised by you) (your SSN =102672)
		update Employee
		set SuperSSN = '102672'
		where SSN = '102660';