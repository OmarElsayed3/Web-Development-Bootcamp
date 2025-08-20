Create database Dapper_Task_1;
Go
use Dapper_Task_1;
GO
Create Table Categories
(
    Id int identity(1,1) primary key,
    Name nvarchar(100) not null
);
Go
Create Table Products
(
    Id int identity(1,1) primary key,
    Name nvarchar(100) not null,
    Price decimal(18,2) not null,
    CategoryId int foreign key references Categories(Id) on delete set null
);
Go
--Insert
create proc usp_InsertProduct
    @Name nvarchar(100),
    @Price decimal(18,2),
    @CategoryId int
AS
    insert into Products (Name, Price, CategoryId)
    values (@Name, @Price, @CategoryId);
Go
create proc usp_InsertCategory
    @Name nvarchar(100)
AS
    insert into Categories (Name)
    values (@Name);
Go


--Update
create procedure usp_UpdateProduct
	@Id int,
    @Name nvarchar(100),
    @Price decimal(10,2),
    @CategoryId int
as
	update Products set Name=@Name, Price = @Price, CategoryId = @CategoryId WHERE Id = @Id;
Go
create procedure usp_UpdateCategory
    @CategoryId int,
    @Name nvarchar(100)
as
	update Products set Name=@Name WHERE Id = @CategoryId;
Go


--Delete
Create Procedure usp_DeleteProduct
    @ProductId int
as
    delete from Products where Id = @ProductId;
Go
Create Procedure usp_DeleteCategorie
    @CategoryId int
as
	update Products
    set CategoryId = NULL
    where CategoryId = @CategoryId;

    delete from Categories
    where id = @CategoryId;
Go
--View
Create view vw_Products
as
	select P.Id as ProductId, P.Name as ProductName, P.Price as ProductPrice, C.Name as CategoryName
	from Products P join Categories C
	on p.CategoryId = c.Id

Go
Create view vw_Categories
as
	select Id, Name
	from Categories;
Go
--Functions
create function fn_GetProductByName
(
    @Name nvarchar(100)
)
returns table
as
return
(
    select P.Id as ProductId, P.Name as ProductName, P.Price as ProductPrice, C.Name as CategoryName
    from Products P
    join Categories C on P.CategoryId = C.Id
    where P.Name = @Name
);
Go
create function fn_GetCategoryByName
(      
    @Name nvarchar(100)
)
returns table
as
return
(
    select * from Categories where Name = @Name
);