create table autor
(
claveA bigint primary key,
nombreA varchar (100)

);
create table editorial 
(
claveE int primary key,
nombree varchar (100)
);
create table libros 
(
claveL int primary key,
titulo varchar (100),
claveA bigint,
claveE int,
constraint fk_libros_autor foreign key (claveA) 
references autor (claveA),
constraint fk_libros_editorial foreign key (claveE) 
references editorial (claveE)
);