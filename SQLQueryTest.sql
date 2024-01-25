create database Test

go

use Test;
create table Products
(
	Id int primary key IDENTITY,
	Name nvarchar(50) NOT NULL
);

create table Categories 
(
	Id int primary key identity,
	Name nvarchar(50) NOT NULL
);

go

create table Product_and_Categories
(
	Id int primary key identity,
	Product_id int  references Products(Id),
	Categories_id int references Categories(Id) NULL
);

go

insert into Categories
values
('Fluid'),
('Meel')

insert into Products
values
('Water'),
('Hot Water'),
('Ice'),
('Steam')

go

insert into Product_and_Categories
values
(
	(select Id from Products where Name = 'Water'),
	(select Id from Categories where Name = 'Fluid')
)

insert into Product_and_Categories
values
(
	(select Id from Products where Name = 'Water'),
	(select Id from Categories where Name = 'Meel')
)

insert into Product_and_Categories
values
(
	(select Id from Products where Name = 'Hot Water'),
	(select Id from Categories where Name = 'Fluid')
)

insert into Product_and_Categories
values
(
	(select Id from Products where Name = 'Ice'),
	(select Id from Categories where Name = 'Meel')
)

insert into Product_and_Categories
values
(
	(select Id from Products where Name = 'Steam'),
	NULL
)

go

select Products.Name, Categories.Name
from Products
left join Product_and_Categories ON Products.ID=Product_and_Categories.Product_id
left join Categories ON Categories.Id = Product_and_Categories.Categories_id
order by Products.Name;