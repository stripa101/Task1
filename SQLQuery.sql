create database gmaptask;
use gmaptask;

--òàáëèöà ãåîãðàôè÷åñêèå êîîðäèíàòû 
create table geographical_coordinates_tb
(
[id] int not null identity(1,1) primary key,
[x] DECIMAL(16,13),
[y]  DECIMAL(16,13),
);
--òàáëèöà òåõíèêà
create table equipment_tb
(
[id] int not null identity(1,1) primary key,
[name] nvarchar(100) not null,
);
--òàáëèöà ìíîãèå-êî-ìíîãèì
create table geographical_to_equipment
(
[id] int not null identity(1,1) primary key,
[fk_geographical] int references geographical_coordinates_tb(id),
[fk_equipment] int references equipment_tb(id)
);

insert into equipment_tb
values
('Слон'),
('Танк'),
('Петя);

insert into geographical_coordinates_tb(x,y)
values
(25.555,105.12),
(70.555,80.12),
(74.555,105.12);

insert into geographical_to_equipment
values
(1,1),
(2,2),
(3,3);
