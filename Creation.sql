create table Users
( 
	id int identity primary key,
	firstName varchar(50) not null,
	lastName varchar(50) not null,
	middleInit char,
	username varchar(50) not null unique,
	password varchar(20) not null,
	role varchar(10),
	contact_idFK int foreign key references contact(id)
)
select * From Users
create table contact(
	id int identity primary key,
	PO_or_street bit not null,
	poNumber int not null default 0,
	streetNumber int not null default 0,
	streetName varchar(255) not null,
	city varchar(255) not null,
	state varchar(50) not null,
	zipcode int not null
)

create table policy(
	id int identity primary key,
	insurance int foreign key references Users(id),
	coverage varchar(max) not null
)
drop table policy;
create table claims(
	id int identity primary key,
	patient int foreign key references Users(id),
	doctor int foreign key references Users(id),
	policy int foreign key references Users(id),
	reasonForVisit varchar(max) not null,
	status varchar(max) not null default 'Pending'
)

create table ticket(
	id int identity primary key,
	claim int foreign key references claims(id),
	patient int foreign key references Users(id),
	policy int foreign key references policy(id),
	notes varchar(max) not null
)