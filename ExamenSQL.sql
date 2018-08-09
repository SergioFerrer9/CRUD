CREATE DATABASE Examen
GO
USE Examen
GO

CREATE TABLE Album(
albumId int,
nombre varchar(50)
)
GO

CREATE TABLE Cancion(
cancionId int,
nombre varchar(50)
)
GO

SELECT * FROM Album

SELECT * FROM Cancion
GO

CREATE PROCEDURE spr_EliminarCancion
@cancionId int
AS BEGIN
	DELETE FROM Cancion WHERE cancionId=@cancionId
END
GO

CREATE PROCEDURE spr_AgregarCancion
@cancionId int,
@nombre varchar(50)
AS BEGIN
	INSERT INTO Cancion VALUES(@cancionId,@nombre)
END
GO

CREATE PROCEDURE spr_ModificarCancon
@cancionId int,
@nombre varchar(50)
AS BEGIN
	UPDATE Cancion SET nombre=@nombre WHERE cancionId=@cancionId
END
GO

EXEC spr_EliminarCancion 3

EXEC spr_AgregarCancion 7, 'Nirvansa'

EXEC spr_ModificarCancon 2, 'Musica Ligera';

