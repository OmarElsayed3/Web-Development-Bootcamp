------------------------------------Lab 9-------------------------------------------
--1)
use ITI;
create procedure sp_NofStudentDeptName
as
	select count(st_id) as 'N.o Student', dept_name
	from student s join Department d
	on s.Dept_Id = d.Dept_Id
	group by Dept_Name

sp_NofStudentDeptName
--or
execute sp_NofStudentDeptName;
--------------------------------------------------------------
--2)
use Company_SD;

create proc sp_CheckEmployeesInProjectP1
as
	declare @cnt int
	select @cnt = count(*)
	from Works_for
	where Pno = 100 

	if @cnt > 3
	begin
		print 'The number of employees in the project p1 is 3 or more';
	end
	else
	begin
		print 'The following employees work for the project p1';

		select Fname, Lname
		from Employee e join Works_for w
		on e.SSN = w.ESSn
		where w.Pno = 100
	end
		
sp_CheckEmployeesInProjectP1
--------------------------------------------------------------
--3)
use Company_SD;

create procedure sp_ReplaceEmployeeOnProject
	@OldEmpSSN int,
    @NewEmpSSN int,
    @ProjectNum int
as
	update Works_for
	set ESSn = @NewEmpSSN
	where ESSn = @OldEmpSSN and Pno = @ProjectNum

exec sp_ReplaceEmployeeOnProject 
	 @OldEmpSSN = 968574,
	 @NewEmpSSN = 321654,
	 @ProjectNum = 700;
--------------------------------------------------------------
--4)
alter table project add budget int

update Project
set budget = 2000

create table ProjectBudgetAudit(
	ProjectNo int ,
	UserName varchar(50), 	
	ModifiedDate date,
	Budget_Old int,
	Budget_New int
);

create trigger trg_ProjectBudgetAudit
on project
after update 
as
	if update(budget)
	begin
		declare @ProjectNo int , 	
				@Budget_Old int,
				@Budget_New int

		select @Budget_Old = budget from deleted
		select @ProjectNo = Pnumber, @Budget_New = budget from inserted
		insert into ProjectBudgetAudit
		values (@ProjectNo,suser_name(),getdate(),@Budget_Old,@Budget_New);
	end

update Project 
set budget = 175000 
where Pnumber = 700;

select * from ProjectBudgetAudit;
	
--------------------------------------------------------------
--5)
use ITI;

create trigger trg_PreventInsert
on Department 
instead of insert
as
	select 'Can’t insert a new record in that table'

insert into Department(Dept_Id, Dept_Name)
values (11,'test');	
--------------------------------------------------------------
--6)
use Company_SD;

create trigger trg_PreventInsertOnMarch
on Employee
after insert
as
	if format(getdate(),'mmmm') = 'March'
	begin 
		select 'Can’t insert a new record in that table in this month'
	end
--------------------------------------------------------------
--7)
use ITI;

create table StudentAudit(
	keyValue int identity(1,1) primary key,
    ServerUserName varchar(100) not null,
    AuditDate date not null DEFAULT GETDATE(),
    Note varchar(100) not null
);
create trigger trg_InsertStu
on student
after insert
as
	declare @username int
	select @username = st_id from inserted

	insert into StudentAudit
	values (system_user,getdate(),cast(@username as varchar(100)));
		
insert into Student(St_Id,St_Fname)
values(103, 'John');
select * from StudentAudit
--------------------------------------------------------------
--8)
create trigger trg_StudentInsteadOfDelete
on Student
instead of delete
as
    insert into StudentAudit
    select SYSTEM_USER, GETDATE(),
        'Try to delete Row with Key= ' + CAST(st_id as varchar(50))
    from deleted;

DELETE FROM Student WHERE st_id = 10;

SELECT * FROM StudentAudit;
--------------------------------------------------------------
--9)
use ITI;
--a.
select Dept_Name, Ins_Name
from Department D,Instructor I
where d.Dept_Id = I.Dept_Id
for xml auto
--------------------------------------------------------------
--b.
select Dept_Name "@DepartmentId", Ins_Name "InstructorName"
from Department D,Instructor I
where d.Dept_Id = I.Dept_Id
for xml path
--------------------------------------------------------------
--10)
use Company_SD;

declare @docs xml ='<customers>
              <customer FirstName="Bob" Zipcode="91126">
                     <order ID="12221">Laptop</order>
              </customer>
              <customer FirstName="Judy" Zipcode="23235">
                     <order ID="12221">Workstation</order>
              </customer>
              <customer FirstName="Howard" Zipcode="20009">
                     <order ID="3331122">Laptop</order>
              </customer>
              <customer FirstName="Mary" Zipcode="12345">
                     <order ID="555555">Server</order>
              </customer>
       </customers>'
declare @hdocs int

exec Sp_xml_preparedocument @hdocs output, @docs

select * into customers
from openxml (@hdocs, '/customers/customer', 2)
with (
	FirstName varchar(50) '@FirstName',
	Zipcode int '@Zipcode',
	orderID int 'order/@ID',
	Product varchar(50) 'order'
)
exec sp_xml_removedocument @hdocs


select * from customers
--------------------------------------------------------------
--------------------------------------------------------------
--2)
create trigger trg_PreventsAlter
on database
for alter_table
as
	print 'Altering tables in the Company database is not allowed.';
    rollback;

alter table employee add NewColumn int;
----------------------------------------------------------------------
--3)
SELECT
    1 as Tag,
    NULL AS Parent,
    NULL AS [Students!1],
    NULL AS [Student!2!StudentId],         -- Attribute
    NULL AS [Student!2!StudentName!ELEMENT],
    NULL AS [Student!2!StudentLastName!ELEMENT]

UNION ALL

SELECT
    2 AS Tag,
    1 AS Parent,
    NULL AS [Students!1],
    St_Id AS [Student!2!StudentId],        -- Attribute
    St_Fname AS [Student!2!StudentName!ELEMENT],
    St_Lname AS [Student!2!StudentLastName!ELEMENT]
FROM Student
FOR XML EXPLICIT;
