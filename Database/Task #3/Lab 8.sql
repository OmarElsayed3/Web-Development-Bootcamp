use ITI;

---------------------------------------------------------------------------
--============================ Lab 8 ====================================--

--1)
create view vw_GetStNameCrsName
as
	select st_fname + ' ' + st_lname as FullName, Crs_Name
	from Student s, Stud_Course stc, Course c
	where s.St_Id = stc.St_Id and stc.Crs_Id = c.Crs_Id and stc.Grade > 50

select * from vw_GetStNameCrsName
---------------------------------------------------------------------------
--2)
create view vw_MgNameTopic
with encryption
as	
	select Ins_Name, Top_Name
	from Instructor I, Topic T, Ins_Course IC, Course C, Department D
	where  I.Dept_Id = D.Dept_Id 
		  and I.Ins_Id = IC.Ins_Id and  IC.Crs_Id = C.Crs_Id 
		  and T.Top_Id = C.Top_Id and I.Ins_Id = D.Dept_Manager

select * from vw_MgNameTopic

sp_helptext 'vw_MgNameTopic'
---------------------------------------------------------------------------
--3)
create view vw_InsNameInDeptJavaOrSD
as
	select Ins_name, Dept_name
	from Instructor I, Department D
	where I.Dept_Id = D.Dept_Id and D.Dept_Name in ('Java', 'SD')

select * from vw_InsNameInDeptJavaOrSD
---------------------------------------------------------------------------
--4)
create view V1
as
	select * 
	from Student
	where St_Address in ('Alex','Cairo')

select * from V1

Update V1 
set st_address='tanta'
Where st_address='alex';
---------------------------------------------------------------------------
--5)
use Company_SD
create view vw_GetPNameAndCountOfEmp
as
	select pname,count(SSN) as 'N.O Employee'
	from Project p,Employee e,Works_for w
	where p.Pnumber = w.Pno and e.SSN = w.ESSn
	group by Pname

select * from vw_GetPNameAndCountOfEmp
---------------------------------------------------------------------------
--6)
use ITI;
create clustered index ix_test
on Department(Manager_hiredate)
-- Cannot create more than one clustered index on table 'Department'.

---------------------------------------------------------------------------
--7)
create unique index ix_StudentAge
on Student(st_age);
--The CREATE UNIQUE INDEX statement terminated because a duplicate key was found for the object name 'dbo.Student' and the index name 'ix_StudentAge'. The duplicate key value is (21).
--The statement has been terminated.

---------------------------------------------------------------------------
--8)
create table DailyTransactions(
	id int primary key,
	TransactionAmount int
)
create table LastTransactions(
	id int primary key,
	TransactionAmount int
)
insert into DailyTransactions values
	(1,1000),
	(2,2000),
	(3,1000);

insert into LastTransactions values
	(1,4000),
	(4,2000),
	(2,10000);

merge into LastTransactions as T
using DailyTransactions as S
on T.id = S.id
when Matched then
	update set T.TransactionAmount = S.TransactionAmount

when Not matched then
	insert values(s.id,s.TransactionAmount);

select * from DailyTransactions
select * from LastTransactions
------------------------------------------------------------------------
------------------------------ Part 2 ----------------------------------
use SD_DB;

--1)
Create view v_clerk
as
	select e.EmpNo, p.ProjectNo , Enter_Date
	from Hr.Employee e, Works_on w, Hr.Project p
	where e.EmpNo = w.EmpNo and p.ProjectNo = w.ProjectNo and w.Job = 'Clerk'

select * from v_clerk
------------------------------------------------------------------------
--2)
create view v_without_budget
as 
	select p.ProjectNo, p.ProjectName
	from Hr.Project p

select * from v_without_budget
------------------------------------------------------------------------
--3)
create view v_count 
as 
	select ProjectName, Job
	from Hr.Project p, Works_on w
	where p.ProjectNo = w.ProjectNo

select * from v_count
------------------------------------------------------------------------
--4)
create view v_project_p2
as 
	select EmpNo
	from v_clerk
	where ProjectNo = 2

select * from v_project_p2
------------------------------------------------------------------------
--5)
alter view v_without_budget
as 
	select *
	from Hr.Project p
	where ProjectNo in (1,2)

select * from v_without_budget
------------------------------------------------------------------------
--6)
drop view v_clerk;
drop view v_count;
------------------------------------------------------------------------
--7)
create view vw_EmpNo_EmpLname
as 
	select EmpNo, EmpLname
	from HR.Employee
	where DeptNo = 2

select * from vw_EmpNo_EmpLname
------------------------------------------------------------------------
--8)
select EmpLname
from vw_EmpNo_EmpLname
where EmpLname like '%J%'
------------------------------------------------------------------------
--9)
create view v_dept
as
	select DeptNo, DeptName
	from Department

select * from v_dept
------------------------------------------------------------------------
--10)
insert into v_dept values (4,'Development');
------------------------------------------------------------------------
--11)
create view v_2006_check
as 
	select e.EmpNo, p.ProjectNo, Enter_Date
	from HR.Employee e inner join Works_on w
	on e.EmpNo = w.EmpNo inner join HR.Project p
	on w.ProjectNo = p.ProjectNo
	where w.Enter_Date between '2006-01-01' and '2006-12-31'
with check option;
