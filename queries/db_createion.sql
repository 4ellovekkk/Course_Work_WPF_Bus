use Course_Work_Bus
create table Bus
(
	places int ,
	max_speed float,
	color nvarchar(50),
	photo_path nvarchar(200),
	bus_name nvarchar (100),
	id int identity(0,1) primary key 
)
create table Path
(
	start_point nvarchar(100),
	end_point nvarchar (100),
	id int identity(0,1) primary key
)
create table Route
(
	start_point nvarchar(100),
	end_point nvarchar (100),
	route_id int,
	id int identity(0,1) primary key,
	timer time,
	how_often bit,
	bus_id int
)