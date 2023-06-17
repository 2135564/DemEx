use DemEx

Create table [Role]
(
	Id int identity primary key,
	Title nvarchar(max) not null
)
go

Create table [User]
(
	Id int identity primary key,
	Firstname nvarchar(max) not null,
	MiddleName nvarchar(max) not null,
	Lastname nvarchar(max) not null,
	[Login] nvarchar(max) not null,
	[Password] nvarchar(max) not null,
	RoleId int references [Role](Id) not null
)
go

Create table Manufacturer
(
	Id int identity primary key,
	Title nvarchar(max) not null
)
go

Create table Product
(
	Id int identity primary key,
	Photo nvarchar(max),
	Title nvarchar(max) not null,
	Decription nvarchar(max),
	Cost decimal not null,
	Discount int,
	ManufacturerId int references Manufacturer(Id) not null,
	CountInStock int not null,
)
go

Create table [Status]
(
	Id int identity primary key,
	Title nvarchar(max) not null
)
go

Create table Point
(
	Id int identity primary key,
	Title nvarchar(max) not null
)
go

Create table ProductSale
(
	Id int identity primary key,
	UserId int references [User](Id) not null,
	Number int not null,
	ProductId int references Product(Id) not null,
	StatusId int references [Status](Id) not null,
	PointId int references Point(Id) not null,
	DateOfIsue datetime not null,
	CostSum decimal not null,
	DateOfSale datetime not null,
	DiscountSum int
)
go
