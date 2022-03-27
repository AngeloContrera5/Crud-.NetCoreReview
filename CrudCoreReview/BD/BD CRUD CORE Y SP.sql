CREATE DATABASE DBCRUDCORE

USE DBCRUDCORE

CREATE TABLE CONTACTO(
idContacto int identity primary key,
nomContacto varchar(50),
telContacto varchar(50),
correoContacto varchar(50)
)

--select * from CONTACTO


--PROCEDIMIENTO ALMACENADO PARA LLAMAR A TODA LA DATA DE LA TABLA "CONTACTO"
CREATE PROC sp_list
as
begin 
	select * from CONTACTO
end

--PROC. ALMACENADO PARA LLAMAR A TODA LA DATA DE UN ESPECÍFICO CONTACTO FILTRADO POR ID
CREATE PROC sp_get(
@IdContacto int
)
as
begin
	select * from CONTACTO where idContacto = @IdContacto
end

CREATE PROC sp_save(
@NomContacto varchar(50),
@TelContacto varchar(50),
@CorreoContacto varchar(50)
)
as
begin
	insert into CONTACTO(nomContacto, telContacto, correoContacto) values (@NomContacto, @TelContacto, @CorreoContacto)
end





CREATE PROC sp_update(
@IdContacto int,
@NomContacto varchar(50),
@TelContacto varchar(50),
@CorreoContacto varchar(50)
)
as
begin
	update CONTACTO set nomContacto=@NomContacto, telContacto=@TelContacto, correoContacto=@CorreoContacto where idContacto=@IdContacto
end

CREATE PROC sp_delete(
@IdContacto int
)
as
begin
	delete from CONTACTO where idContacto = @IdContacto
end