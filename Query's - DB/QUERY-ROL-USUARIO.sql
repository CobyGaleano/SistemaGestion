SELECT * FROM USUARIO

SELECT * FROM ROL

INSERT INTO ROL(Descripcion)
VALUES ('ADMINISTRADOR')

INSERT INTO USUARIO(Documento,NombreCompleto,Correo,Clave,IdRol,Estado)
VALUES
('12345Gestion','ADMIN','ADMIN@GMAIL.COM','12345',1,1)