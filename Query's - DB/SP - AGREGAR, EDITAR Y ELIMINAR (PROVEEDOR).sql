USE DBSISTEMA_VENTA
GO
SELECT * FROM PROVEEDOR
GO

--PROCEDIMIENTO PARA REGISTRAR PROVEEDOR--
CREATE PROC SP_RegistarProveedor(
@Documento VARCHAR(50),
@RazonSocial VARCHAR(100),
@Correo VARCHAR(100),
@Telefono VARCHAR(50),
@Estado BIT,
@Resultado INT OUTPUT,
@Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
	SET @Resultado = 0
	DECLARE @IdProveedor INT
	IF NOT EXISTS (SELECT * FROM PROVEEDOR WHERE Documento = @Documento)
	BEGIN
		INSERT INTO PROVEEDOR (Documento,RazonSocial,Correo,Telefono,Estado) VALUES(
		@Documento,@RazonSocial,@Correo,@Telefono,@Estado)

		SET  @Resultado = SCOPE_IDENTITY()
	END
	ELSE
		SET @Mensaje = 'El numero de documento ya existe'
END
GO

--PROCEDIMIENTO PARA MODIFICAR PROVEEDOR--
CREATE PROC SP_ModificarProveedor(
@Documento VARCHAR(50),
@RazonSocial VARCHAR(100),
@Correo VARCHAR(100),
@Telefono VARCHAR(50),
@Estado BIT,
@Resultado INT OUTPUT,
@Mensaje VARCHAR(500) OUTPUT
)
AS
	SET @Resultado = 0
	DECLARE @IdProvedor INT
	IF NOT EXISTS (SELECT * FROM PROVEEDOR WHERE Documento = @Documento AND IdProveedor != @IdProvedor)
	BEGIN 
		UPDATE PROVEEDOR SET
		Documento = @Documento,
		RazonSocial = @RazonSocial,
		Correo = @Correo,
		Telefono = @Telefono,
		Estado = Estado
		WHERE IdProveedor = @IdProvedor
	END
	ELSE
	BEGIN
		SET @Resultado = 0
		SET @Mensaje = 'El numero de documento ya existe'
	END
GO

--PROCEDIMIENTO PARA ELIMINAR PROVEEDOR--
CREATE PROC SP_EliminarProveedor(
@IdProveedor INT,
@Resultado INT OUTPUT,
@Mensaje VARCHAR (500) OUTPUT
)
AS
BEGIN
	SET @Resultado = 1
	IF NOT EXISTS(SELECT * FROM PROVEEDOR P INNER JOIN COMPRA C ON
	P.IdProveedor = C.IdProveedor WHERE P.IdProveedor = @IdProveedor)
	BEGIN
		DELETE TOP (1) FROM PROVEEDOR WHERE IdProveedor = @IdProveedor
	END
	ELSE
	BEGIN
		SET @Resultado = 0
		SET @Mensaje = 'ERROR, El PROVEEDOR se encuentra relacionado a una compra.'
	END
END
GO
	