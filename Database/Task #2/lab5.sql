use ITI;

--1)
select count(St_Age)
from Student

--2)
select distinct Ins_Name
from Instructor

--3)
select St_Id as 'Student ID', isNull(St_Fname, ' ') + ' ' + isNull(St_Lname, ' ') as 'Student Full Name',isNull(dept_name, ' ') as 'Department name'
from Student s, Department d
where s.Dept_Id = d.Dept_Id

--4)
select ins_name,dept_name
from Instructor i, Department d
where i.Dept_Id = d. Dept_Id

--5)
select st_fname + ' ' + st_lname as 'full name', Crs_Name 
from Student s, Stud_Course stc ,Course c
where s.St_Id = stc.St_Id and stc.Crs_Id = c.Crs_Id and stc.Grade is not null

--6)
select crs_id , t.Top_Name
from Course c,Topic t
where c.Top_Id = t.Top_Id

--7)
select max(salary),min(salary)
from Instructor

--8)
select *
from Instructor
where Salary < (select avg (salary) from Instructor)

--9)
select dept_name
from Department d,Instructor i
where d.Dept_Id = i.Dept_Id and i.Salary = (select min(salary) from Instructor)

--10) 
select top(2) salary
from Instructor
order by Salary desc

--11)
select ins_name,coalesce(salary,'bonus')
from Instructor

--12)
select avg(salary)
from Instructor

--13)
select s.st_fname
from Student s,Student sup
where sup.St_super = s.St_Id

--14)
select salary
from (
	select salary, row_number() over(order by salary desc) as RN
	from Instructor
)as Newtable
where RN < 3

--15)
select *
from (
	select s.*,Row_number() over(partition by s.dept_id order by newid()) as R
	from Student s, Department d
	where s.Dept_Id = d.Dept_Id
) as sol
where R = 1
