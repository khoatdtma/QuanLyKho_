create database Quanlykho;
go

use Quanlykho;
go

create table Unit(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(max)
)
go

create table Supplier(
	Id int identity(1,1) primary key,
	Displayname nvarchar(max),
	Address nvarchar(max),
	Phone nvarchar(20),
	Email nvarchar(200),
	MoreInfo nvarchar(max),
	ContractDate Datetime
)
go


create table Customer(
	Id int identity(1,1) primary key,
	Displayname nvarchar(max),
	Address nvarchar(max),
	Phone nvarchar(20),
	Email nvarchar(200),
	MoreInfo nvarchar(max),
	ContractDate Datetime
)
go

create table Product(
	Id nvarchar(128) primary key,
	DisplayName nvarchar(max),
	IdUnit int not null,
	IdSupplier int not null,
	QRCode nvarchar(max),
	Barcode nvarchar(max),
	
	foreign key (IdUnit) references Unit(Id),
	foreign key (IdSupplier) references Supplier(Id)
)
go

create table UserRole(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(50)
)
go

create table Users(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(50),
	Username nvarchar(50),
	Password nvarchar(max),
	IdRole int not null,
	foreign key (IdRole) references UserRole(Id)
)

create table Input(
	Id nvarchar(128) primary key,
	InputDate Datetime	
)
go

create table InputInfo(
	Id nvarchar(128) primary key,
	IdProduct nvarchar(128) not null,
	IdInput nvarchar(128) not null,
	Count int,
	InputPrice float default 0,
	OutputPrice float default 0,

	foreign key (IdProduct) references Product(Id),
	foreign key (IdInput) references Input(Id)
)
go

create table Outputs(
	Id nvarchar(128) primary key,
	OutputDate Datetime	
)
go

create table OutputInfo(
	Id int identity(1,1) primary key,
	IdProduct nvarchar(128) not null,
	IdInputInfo nvarchar(128) not null,
	IdCustomer nvarchar(128) not null,
	Count int,
	InputPrice float default 0,
	OutputPrice float default 0,

	foreign key (IdProduct) references Product(Id),
	foreign key (IdInputInfo) references InputInfo(Id),
	foreign key (IdCustomer) references Customer(Id)
)
go