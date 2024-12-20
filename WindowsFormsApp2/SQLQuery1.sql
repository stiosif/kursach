alter proc ClientAdd
@surname varchar(20),
@name varchar(20),
@phone varchar(20)
as
begin
insert into clients values(@surname, @name, @phone)
end

create proc ClientEdit
@id int,
@surname varchar(20),
@name varchar(20),
@phone varchar(20)
as
begin
update clients 
set surname = @surname, name = @name, phone = @phone where id = @id
end

create proc MaterialAdd
@name varchar(20),
@price money
as
insert into materials values(@name, @price)

create proc MaterialEdit
@id int,
@name varchar(20),
@price varchar(20)
as
begin
update materials
set name = @name, price = @price where id = @id
end

create proc SupplyAdd
@date date,
@area float,
@materials_id int
as
insert into supplies values(@date, @area, @materials_id)

create proc SupplyEdit
@id int,
@date date,
@area float,
@materials_id int
as 
update supplies set Date = @date, area = @area, materials_id = @materials_id where id = @id

create proc OrderCreate
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
insert into orders values(@clients_id,@books_amount,@total,@cost,@pages_material,@pages_area,@pages,@cover_material,@cover_area, 'новый')





create function NullToZero(@var int)
returns int
as
begin
    if (@var is null)
    begin
        set @var = 0
    end
    return @var
end

create proc SelectInStockMaterials
as
select materials.id as id, name, sum(dbo.NullToZero(supplies.area)) - (select dbo.NullToZero(sum(dbo.NullToZero(pages_area))) from orders where pages_material = materials.id and status = 'завершен') - (select dbo.NullToZero(sum(dbo.NullToZero(cover_area))) from orders where cover_material = materials.id and status = 'завершен') as instock
from supplies
full join materials on materials.id = supplies.materials_id
group by materials.id, name

create view InStockMaterials
as
select materials.id as id, name, sum(dbo.NullToZero(supplies.area)) - (select dbo.NullToZero(sum(dbo.NullToZero(pages_area))) from orders where pages_material = materials.id and status = 'завершен') - (select dbo.NullToZero(sum(dbo.NullToZero(cover_area))) from orders where cover_material = materials.id and status = 'завершен') as instock
from supplies
full join materials on materials.id = supplies.materials_id
group by materials.id, name

create login Seva with password = '123', check_expiration = off, check_policy = off

create login Zhenya with password = '123', check_expiration = off, check_policy = off

create login Kostik with password = '123', check_expiration = off, check_policy = off

create role Admin

create role employee

exec sp_adduser 'Seva', 'Seva', 'Admin'
exec sp_adduser 'Zhenya', 'Zhenya', 'employee'
exec sp_adduser 'Kostik', 'Kostik', 'employee'

grant select, insert, delete, update to admin
grant select, insert, delete, update to employee



CREATE TABLE [dbo].[clients] (
    [id]      INT           IDENTITY (1, 1) NOT NULL,
    [surname] NVARCHAR (20) NULL,
    [name]    NVARCHAR (20) NULL,
    [phone]   NVARCHAR (20) NULL
);

CREATE TABLE [dbo].[materials] (
    [id]    INT          IDENTITY (1, 1) NOT NULL,
    [name]  VARCHAR (30) NULL,
    [price] MONEY        NULL
);

CREATE TABLE [dbo].[supplies] (
    [id]           INT        IDENTITY (1, 1) NOT NULL,
    [Date]         DATE       NULL,
    [area]         FLOAT (53) NULL,
    [materials_id] INT        NOT NULL references materials(id)
);


CREATE TABLE [dbo].[orders] (
    [id]             INT           IDENTITY (1, 1) NOT NULL,
    [clients_id]     INT           NOT NULL references clients(id),
    [books_amount]   INT           NULL,
    [total]          MONEY         NULL,
    [cost]           MONEY         NULL,
    [pages_material] INT           NULL references materials(id),
    [pages_area]     FLOAT (53)    NULL,
    [pages]          INT           NULL,
    [cover_material] INT           NULL references materials(id),
    [cover_area]     FLOAT (53)    NULL,
    [status]         NVARCHAR (50) NULL
);








create table users(
login varchar(15),
password varchar(20),
permission int
)

insert into users values ('Seva','Seva',1),
('Zhenya','Zhenya',1),
('Nya','Nya',2),
('Kashka','Kashka',2)


CREATE TABLE [dbo].[journal]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [date] DATE NULL, 
    [event] VARCHAR(MAX) NULL
)

create trigger Materials_UpdatePrice on materials
for update
as
insert into journal values(getdate()
,'Цена материала ' + Cast((select id from updated) as varchar(max)) 
+ 'изменилась на ' + Cast((select price from updated) as varchar(max)))
