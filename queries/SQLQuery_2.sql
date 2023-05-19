use Course_Work_Bus
CREATE table Users
(
   usertype bit,
   id int IDENTITY(0,1) PRIMARY KEY,
   login NVARCHAR (50),
   PASSWORD NVARCHAR(50),
)
CREATE TABLE Orders
(
    id int Identity(0,1) PRIMARY KEY,
    route_id int,
    price float,
    user_id int,
    order_time TIME
)