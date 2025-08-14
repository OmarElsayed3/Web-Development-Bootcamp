use ITI;

----------------------------------------------------------------------
----------------------------------------------------------------------
--============================ Part 1 ================================

--1)
create function fn_MonthName(@date date)
returns varchar(20)
begin
	return DateName(month,@date)
end;

select dbo.fn_MonthName('6-12-2004')
---------------------------------------------------------------------
--2)
create function fn_NumberBetween_AandB(@A int, @B int)
returns @result table(
	numbers int
)
as 
begin
	while @A <= @B
	begin
		insert into @result
		values(@A);
		set @A += 1
	end

	return
end

select *
from fn_NumberBetween_AandB(5,10)
---------------------------------------------------------------------
--3)
create function fn_GetDeptNameStName(@id int)
returns table
as 
return (
	select Dept_name,st_fname + ' ' + st_lname as 'Full Name'
	from Department d, Student s
	where d.Dept_Id = s.Dept_Id and st_id = @id
)

select * from fn_GetDeptNameStName(5)
---------------------------------------------------------------------
--4)
create function fn_Massage(@id int)
returns varchar(100)
begin
	declare @fname varchar(20),@lname varchar(20)	
	select @fname = st_fname, @lname = st_lname
	from Student
	where st_id = @id

	if @fname is null and @lname is null
		return 'First name & last name are null'
	else if @fname is null and @lname is not null
		return 'first name is null'
	else if @fname is not null and @lname is null
		return 'last name is null'
	else
	 return 'First name & last name are not null'

	return null

end

select dbo.fn_massage(14)
---------------------------------------------------------------------
--5)
create function fn_GetHiringDate(@formatDate int)
returns table
as 
return(
	select dept_name, Ins_Name, convert(varchar(50),d.Manager_hiredate,@formatDate) as Manager_hiredate
	from Department d, Instructor i
	where d.Dept_Id = i.Dept_Id
)

select *
from fn_GetHiringDate(103)--dd-mm-yyyy

---------------------------------------------------------------------
--6)
create function fn_GetName(@string varchar(50))
returns @result table(
	Name varchar(101)
)
as
begin 
	if @string = 'First name'
		insert into @result
		select IsNull(St_Fname, '')as 'First Name' from Student
	else if @string = 'Last name'
		insert into @result
		select IsNull(St_Lname, '')as 'Last Name' from Student
	else if  @string = 'Full name'
		insert into @result
		select IsNull(St_Fname,'') + ' ' + IsNull(St_Lname,'') as 'Full Name' from Student
	return
end

select *
from fn_GetName('First Name')

---------------------------------------------------------------------
--7)
select st_id, Left(st_fname,len(st_fname) - 1) as Fname
from Student

---------------------------------------------------------------------
--8)
declare @columns varchar(50)
declare @tableName varchar(50);
declare @Query varchar(max)

set @columns = 'St_Fname, St_lname'
set @tableName = 'Student'

set @Query = 'select ' + @columns + ' from ' + @tableName;

exec (@Query)

----------------------------------------------------------------------
--9)
update stc
set Grade = Null
from Stud_Course stc, student st, Department d
where stc.St_Id = st.St_Id and st.Dept_Id = d.Dept_Id and d.Dept_Name = 'SD';

----------------------------------------------------------------------
----------------------------------------------------------------------
--============================ Part 2 ================================

--1)
use Company_SD;
Go
if not exists (select 1 from Departments where Dnum = 1)
    insert into Departments (Dnum, Dname) 
    values (1, 'd1');
Go
begin Transaction
	declare @count int = 1;
	declare @Rows int = 3000;

	while @count <= @Rows
	begin
		insert into Employee (SSN, Lname, Fname, Dno)
		values (@count, 'Jane', 'Smith', 1);

		set @count += 1;
	end

commit Transaction
Go
select count(*) 
from Employee
where Dno = 1 
