create database dbLojaVirtual;

use dbLojaVirtual;

create table tbUsuario(
Id int primary key auto_increment,
Email varchar(50) not null,
Senha varchar(250) not null,
Nivel varchar(30) not null,
Nome varchar(50) not null
);

insert into tbUsuario(Email,Senha,Nivel,Nome) values ('hudson@gmail.com', 'hud123@', 'Administrador', 'Hudson');
insert into tbUsuario(Email,Senha,Nivel,Nome) values ('hud@gmail.com', 'hud321@', 'Usuário', 'Hud');

select * from tbUsuario;