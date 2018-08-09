use Base1;

SELECT * FROM Datos;

INSERT INTO Datos Values(1,'Sergio','Alfonso',22222,'Guatemala');
INSERT INTO Datos Values(2,'Sergio','Alfonso',22222,'Guatemala');
INSERT INTO Datos Values(3,'Sergio','Alfonso',22222,'Guatemala');
INSERT INTO Datos Values(4,'Sergio','Alfonso',22222,'Guatemala');
INSERT INTO Datos Values(5,'Sergio','Alfonso',22222,'Guatemala');
INSERT INTO Datos Values(6,'Sergio','Alfonso',22222,'Guatemala');
INSERT INTO Datos Values(7,'Sergio','Alfonso',22222,'Guatemala');
INSERT INTO Datos Values(8,'Sergio','Alfonso',22222,'Guatemala');

CREATE PROCEDURE spr_MostrarPersonas
AS BEGIN 
SELECT * FROM Datos
END


EXEC spr_MostrarPersonas

CREATE PROCEDURE spr_Eliminar
	@ID int
AS BEGIN
	DELETE FROM Datos WHERE ID=@ID;
END

EXEC spr_Eliminar 2;