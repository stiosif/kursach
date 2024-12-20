
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

create proc ServiceAdd
@name varchar(20),
@price money
as
insert into services values(@name, @price)

create proc ServiceEdit
@id int,
@name varchar(20),
@price varchar(20)
as
begin
update services
set name = @name, price = @price where id = @id
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

drop table clients
create TABLE clients (
    id      INT           IDENTITY (1, 1) NOT NULL,
    [surname] NVARCHAR (20) NULL,
    [name]    NVARCHAR (20) NULL,
    [phone]   NVARCHAR(20) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

alter table orders add foreign key (clients_id) references clients(id)

create table orders(
id int primary key identity not null,
clients_id int references clients(id) not null,
books_amount int,
total money
)

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

alter view InStockMaterials
as
select materials.id as id, name, sum(dbo.NullToZero(supplies.area)) - (select dbo.NullToZero(sum(dbo.NullToZero(pages_area))) from orders where pages_materials_id = materials.id and status = 'завершен') - (select dbo.NullToZero(sum(dbo.NullToZero(cover_area))) from orders where cover_materials_id = materials.id and status = 'завершен') as instock
from supplies
full join materials on materials.id = supplies.materials_id
group by materials.id, name

