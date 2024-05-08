create database ies_admin;
use ies_admin;
create table usuario(
	id varchar(20) not null,
    passw varchar(10) not null,
    primary key (id)
    
);

insert into usuario values("ale2","1234");
select * from usuario;

create table alumno(
	nombre varchar(60) not null,
    dni varchar(10) not null,
    edad varchar(3) not null,
    direccion varchar(60) not null,
    telefono varchar(15) not null,
    legajo varchar(5) not null,
    carrera varchar(30) not null,
    fecha varchar(10) not null,
    anio varchar(10) not null,
    primary key(dni)
);

select * from alumno;


