if object_id('DeliveryOrder', 'U') is not null drop table DeliveryOrder; 
go
if object_id('Client', 'U') is not null drop table Client;
go
if object_id('Driver', 'U') is not null drop table Driver; 
go

create table Client (
  ID int not null primary key,
  name varchar(100),
  surname varchar(100),
  phone_number int,
  email varchar(100),
  address varchar(100)
);

create table Driver (
  ID int not null primary key,
  name varchar(100),
  surname varchar(100),
  address varchar(100)
);

create table DeliveryOrder (
  ID int not null primary key,
  size int,
  weight int,
  posting_date int,
  receiving_date int,
  client_ID int references Client(ID),
  driver_ID int,
  state int
);