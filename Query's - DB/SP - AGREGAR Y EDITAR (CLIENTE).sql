USE DBSISTEMA_VENTA
GO
--PROCEDIMIENTO REGISTRO CLIENTE--
SELECT * FROM CLIENTE

GO

CREATE PROCEDURE SP_RegistrarCliente(
@Documento VARCHAR(50),
@NombreCompleto VARCHAR(100),
@Correo VARCHAR(100),
@Telefono VARCHAR(50),
@Estado BIT,
@Resultado INT OUTPUT,
@Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
	SET @Resultado = 0
	DECLARE @IdPersona INT
	IF NOT EXISTS (SELECT * FROM CLIENTE WHERE Documento = @Documento)
	BEGIN 
		INSERT INTO CLIENTE(Documento,NombreCompleto,Correo,Telefono,Estado)
		VALUES (@Documento,@NombreCompleto,@Correo,@Telefono,@Estado)

		SET @Resultado = SCOPE_IDENTITY()
	END
	ELSE
	SET @Mensaje = 'Error, el numero de documento ya existe'
END

GO

--PROCEDIMIENTO MODIFICAR CLIENTE--
CREATE PROC Sp_ModificarCliente(
@IdCliente INT,
@Documento VARCHAR(50),
@NombreCompleto VARCHAR(100),
@Correo VARCHAR(100),
@Telefono VARCHAR(50),
@Estado BIT,
@Resultado INT OUTPUT,
@Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
	SET @Resultado = 1
	Declare @IdPersona INT
	IF NOT EXISTS (SELECT * FROM CLIENTE WHERE Documento = @Documento AND IdCliente != @IdCliente)
	BEGIN
		UPDATE CLIENTE SET
		Documento = @Documento,
		NombreCompleto = @NombreCompleto,
		Correo = @Correo,
		Telefono = @Telefono,
		Estado = @Estado
		WHERE IdCliente = @IdCliente

		SET @Resultado = 1
		SET @Mensaje = 'El CLIENTE ha sido modificado correctamente'
	END
	ELSE
		SET @Mensaje = 'Error, no se pudo modificar el CLIENTE'
END

GO




