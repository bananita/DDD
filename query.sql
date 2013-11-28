if object_id('DeliveryOrder', 'U') is not null drop table DeliveryOrder; 
go
if object_id('Client', 'U') is not null drop table Client;
go
if object_id('Driver', 'U') is not null drop table Driver; 
go

create table Client (
  ID int identity(1,1) not null primary key,
  name varchar(100),
  surname varchar(100),
  phone_number int,
  email varchar(100),
  address varchar(100)
);

create table Driver (
  ID int identity(1,1) not null primary key,
  name varchar(100),
  surname varchar(100),
  address varchar(100)
);

-- state 0: preparing
-- state 1: ready
-- state 2: delivered
create table DeliveryOrder (
  ID int identity(1,1) not null primary key,
  size int,
  weight int,
  posting_date date,
  receiving_date date,
  client_ID int,
  driver_ID int,
  state int
);
