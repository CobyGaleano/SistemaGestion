USE DBSISTEMA_VENTA
GO
--PROCEDIMIENTO REGISTRO USUARIO--
SELECT * FROM USUARIO

GO

CREATE PROCEDURE SP_REGISTRARUSUARIO(
@Documento varchar(50),
@NombreCompleto varchar(100),
@Correo varchar(100),
@Clave varchar(50),
@IdRol int,
@Estado bit,
@IdUsuarioResultado int output,
@Mensaje varchar(500) output
)
as
begin 
	set @IdUsuarioResultado = 0
	set @Mensaje = ''

	if not exists(select * from USUARIO where Documento = @Documento)
	begin
	
			insert into USUARIO(Documento, NombreCompleto,Correo,Clave,IdRol,Estado) values
		(@Documento, @NombreCompleto,@Correo,@Clave,@IdRol,@Estado)

		set @IdUsuarioResultado = SCOPE_IDENTITY()

	end
	else
		set @Mensaje = 'No se puede repetir el documento para más de un usuario'
end

DECLARE @idusuriogenerado INT
DECLARE @Mensaje VARCHAR(500)

EXEC SP_REGISTRARUSUARIO '123','pruebas','test@gmail.com','456',2,1, @idusuriogenerado OUTPUT,@Mensaje OUTPUT

SELECT @idusuriogenerado

SELECT @Mensaje

GO

--PROCEDIMIENTO EDITAR USUARIO--
CREATE PROCEDURE SP_EDITARUSUARIO(
@IdUsuario int,
@Documento varchar(50),
@NombreCompleto varchar(100),
@Correo varchar(100),
@Clave varchar(50),
@IdRol int,
@Estado bit,
@Respuesta bit output,
@Mensaje varchar(500) output
)
as
begin 
	set @Respuesta = 0
	set @Mensaje = ''

	if not exists(select * from USUARIO where Documento = @Documento and IdUsuario != @IdUsuario)
	begin
	
		Update USUARIO set
		Documento = @Documento,
		NombreCompleto = @NombreCompleto,
		Correo = @Correo,
		Clave = @Clave,
		IdRol = @IdRol,
		Estado = @Estado
		where IdUsuario = @IdUsuario

		set  @Respuesta = 1

	end
	else
		set @Mensaje = 'No se puede repetir el documento para más de un usuario'
end
go

DECLARE @Respuesta bit
DECLARE @Mensaje varchar (500)

EXEC SP_EDITARUSUARIO 2, '123','pruebas2','test@gmail.com','456',2,1, @Respuesta OUTPUT,@Mensaje OUTPUT

SELECT @Respuesta

SELECT @Mensaje

select * from USUARIO


GO

--PROCEDIMIENTO ELIMINAR USUARIO--
CREATE PROCEDURE SP_ELIMINARUSUARIO(
@IdUsuario int,
@Respuesta bit output,
@Mensaje varchar(500) output
)
as
begin 
	set @Respuesta = 0
	set @Mensaje = ''
	declare @pasoreglas bit = 1

	IF EXISTS(SELECT * FROM COMPRA C
	INNER JOIN USUARIO U ON U.IdUsuario = C.IdUsuario
	WHERE  U.IdUsuario = @IdUsuario
	)
	BEGIN
		set @pasoreglas = 0 
		set @Respuesta = 0
		set @Mensaje = @Mensaje + 'No se puedo eliminar. El usuario se encuentra relacionado a una COMPRA\n'
	END

	IF EXISTS(SELECT * FROM VENTA V
	INNER JOIN USUARIO U ON U.IdUsuario = V.IdUsuario
	WHERE  V.IdUsuario = @IdUsuario
	)
	BEGIN
		set @Respuesta = 0
		set @Mensaje = @Mensaje + 'No se puedo eliminar. El usuario se encuentra relacionado a una VENTA\n'
	END

	IF (@pasoreglas = 1)
	BEGIN
		DELETE FROM USUARIO WHERE IdUsuario = @IdUsuario
		set @Respuesta = 1
	END

END

select * from usuario