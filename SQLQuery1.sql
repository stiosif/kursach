drop table if exists dbo.orders
drop table if exists dbo.supplies
drop table if exists dbo.clients
drop table if exists dbo.materials
drop table if exists dbo.users
drop table if exists dbo.journal
go

CREATE TABLE [dbo].[clients] (
    [id]      INT           IDENTITY (1, 1) NOT NULL,
    [surname] NVARCHAR (20) NULL,
    [name]    NVARCHAR (20) NULL,
    [phone]   NVARCHAR (20) NULL
	constraint pk_clients primary key(id)

);
go

CREATE TABLE [dbo].[materials] (
    [id]    INT          IDENTITY (1, 1) NOT NULL,
    [name]  VARCHAR (30) NULL,
    [price] MONEY        NULL
	constraint pk_materials primary key(id)
);
go

CREATE TABLE [dbo].[supplies] (
    [id]           INT        IDENTITY (1, 1) NOT NULL,
    [Date]         DATE       NULL,
    [area]         FLOAT (53) NULL,
    [materials_id] INT        NOT NULL,
	constraint pk_supplies primary key(id),
	constraint fk_supplies_materials foreign key(materials_id)  references materials(id)
);
go

CREATE TABLE [dbo].[orders] (
    [id]             INT           IDENTITY (1, 1) NOT NULL,
    [clients_id]     INT           NOT NULL,
    [books_amount]   INT           NULL,
    [total]          MONEY         NULL,
    [cost]           MONEY         NULL,
    [pages_materials_id] INT       NULL,
    [pages_area]     FLOAT (53)    NULL,
    [pages]          INT           NULL,
    [cover_materials_id] INT       NULL,
    [cover_area]     FLOAT (53)    NULL,
    [status]         NVARCHAR (50) NULL,
	constraint pk_orders primary key(id),
	constraint fk_clients_materials			foreign key(clients_id)				references clients(id),
	constraint fk_orders_pages_materials	foreign key(pages_materials_id)		references materials(id),
	constraint fk_orders_cover_materials	foreign key(cover_materials_id)		references materials(id)

);
go

create table dbo.users(
login varchar(15),
password varchar(20),
permission int
constraint pk_users primary key(login),
)
go

insert into users values 
('Sava','Sava',1),
('Zhenya','Zhenya',1),
('Nya','Nya',2),
('Kashka','Kashka',2)
go

CREATE TABLE [dbo].[journal]
(
	[Id] INT NOT NULL identity PRIMARY KEY, 
    [date] DATE NULL, 
    [event] VARCHAR(MAX) NULL
)
go

create or alter trigger Materials_UpdatePrice on materials
for update
as
insert into journal 
values(getdate(),'Цена материала ' + Cast((select id from inserted) as varchar(max)) + 'изменилась на ' + Cast((select price from inserted) as varchar(max)))
go

create or alter proc ClientAdd
	@surname varchar(20),
	@name varchar(20),
	@phone varchar(20)
as
begin
	insert into clients values(@surname, @name, @phone)
end
go

create or alter proc ClientEdit
	@id int,
	@surname varchar(20),
	@name varchar(20),
	@phone varchar(20)
as
begin
	update clients 
	set surname = @surname, 
		name = @name, 
		phone = @phone 
	where id = @id
end
go

create or alter proc MaterialAdd
	@name varchar(20),
	@price money
as
	insert into materials 
	values(@name, @price)
go

create or alter proc MaterialEdit
	@id int,
	@name varchar(20),
	@price varchar(20)
as
begin
	update materials
	set name = @name, 
		price = @price 
	where id = @id
end
go

create or alter proc SupplyAdd
	@date date,
	@area float,
	@materials_id int
as
	insert into supplies 
	values(@date, @area, @materials_id)
go

create or alter proc SupplyEdit
	@id int,
	@date date,
	@area float,
	@materials_id int
as 
	update supplies 
	set Date = @date, 
		area = @area, 
		materials_id = @materials_id 
	where id = @id
go

create or alter proc OrderCreate
	@clients_id int,
	@books_amount int,
	@total money,
	@cost money,
	@pages_material int,
	@pages_area float,
	@pages int,
	@cover_material int,
	@cover_area float
as
	insert into orders 
	values(@clients_id,@books_amount,@total,@cost,@pages_material,@pages_area,@pages,@cover_material,@cover_area, 'новый')
go

create or alter view InStockMaterials
as
select 
	m.id as id, 
	name, 
	sum(isnull(s.area, 0))	- (
										select sum(isnull(pages_area, 0)) 
										from orders 
										where pages_materials_id = m.id 
											and status = 'завершен') 
									- (
										select sum(isnull(cover_area, 0))
										from orders 
										where cover_materials_id = m.id 
											and status = 'завершен') as instock
from supplies s
	full join materials m
		on m.id = s.materials_id
group by m.id, name
go
