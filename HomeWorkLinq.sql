use NorthwindDB;


--2--


select C.CompanyName, E.FirstName, E.LastName, O.OrderID, O.OrderDate, S.CompanyName
from Orders O
join Customers C
on O.CustomerID = C.CustomerID
join Employees E
on O.EmployeeID = E.EmployeeID
join Shippers S
on O.ShipVia = S.ShipperID


--3--

select E.FirstName, E.LastName, E.BirthDate, (year(getDate())- year(E.BirthDate)) Age
from Employees E


--4--

select C.ContactName, CompanyName
from Customers C
where C.CompanyName like '%Restaurant%'

--5--

select C.CategoryName, sum(P.UnitsInStock) as SumStock
from Categories C
join Products P
on C.CategoryID = P.CategoryID
group by C.CategoryName

--6--

create function NameToIdFunc (@name nvarchar(max))
returns int
as
begin
	
	declare @id int = (select top 1 CategoryID from Categories where CategoryName = @name)
	return @id

end;

declare @ctgId int = (select dbo.NameToIdFunc('Beverages') as CategoryId)

insert into Products(ProductName, UnitPrice, UnitsInStock, CategoryID) values('Kola', 5.00,500, @ctgId);