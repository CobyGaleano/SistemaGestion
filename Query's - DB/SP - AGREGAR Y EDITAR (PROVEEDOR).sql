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
