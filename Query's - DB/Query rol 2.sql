SELECT * FROM ROL

/*insert into ROL(Descripcion) VALUES
('EMPLEADO')

SELECT * FROM PERMISO

INSERT INTO PERMISO(IdRol, NombreMenu) values
(1, 'btnProductos'),
(1, 'btnVentas'),
(1, 'btnClientes'),
(1, 'btnGastos'),
(1, 'btnMantenimiento'),
(1, 'btnReporte')

GO

INSERT INTO PERMISO(IdRol, NombreMenu) values
(2, 'btnProductos'),
(2, 'btnVentas'),
(2, 'btnClientes'),
(2, 'btnMantenimiento')*/

Select P.IdRol,P.NombreMenu from PERMISO P
inner Join ROL R ON R.IdRol = P.IdRol
inner Join USUARIO U on U.IdRol = R.IdRol
where U.IdUsuario = 1

select * from USUARIO

insert into USUARIO (Documento,NombreCompleto,Correo,Clave,IdRol,Estado)VALUES
('20','EMPLEADO','@MAIL.COM','123',2,1)