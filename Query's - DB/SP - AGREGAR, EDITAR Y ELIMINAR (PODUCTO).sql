USE DBSISTEMA_VENTA
GO
SELECT * FROM PRODUCTO
GO

--PROCEDIMIENTO REGISTRAR PRODUCTO--
CREATE PROC sp_RegistrarProducto(
@Codigo VARCHAR (20),
@Nombre VARCHAR (30),
@Descripcion VARCHAR (50),
@IdCategoria INT,
@IdMarca INT,
@Estado BIT,
@Resultado BIT OUTPUT,
@Mensaje VARCHAR (500) OUTPUT
)
AS
BEGIN
	SET @Resultado = 0
	SET @Mensaje = ''
	IF NOT EXISTS (SELECT 1 FROM PRODUCTO WHERE Codigo = @Codigo)
	BEGIN
		INSERT INTO PRODUCTO(Codigo,Nombre,Descripcion,IdCategoria,IdMarca,Estado) 
		VALUES (@Codigo,@Nombre,@Descripcion,@IdCategoria,@IdMarca,@Estado)
		SET @Resultado = SCOPE_IDENTITY()
	END
	ELSE
	SET @Mensaje = 'Ya existe un producto registrado con el mismo codigo'
END
GO

--PROCEDIMIENTO MODIFICAR PRODUCTO
CREATE PROC sp_ModificarProducto(
@IdProducto INT,
@Codigo VARCHAR (20),
@Nombre VARCHAR (30),
@Descripcion VARCHAR (50),
@IdCategoria INT,
@IdMarca INT,
@Estado BIT,
@Resultado BIT OUTPUT,
@Mensaje VARCHAR (500) OUTPUT
)
AS
BEGIN
	SET @Resultado = 0
	SET @Mensaje = ''
	IF NOT EXISTS (SELECT 1 FROM PRODUCTO WHERE @Codigo = Codigo and @IdProducto != IdProducto)
	
	UPDATE PRODUCTO SET
	Codigo = @Codigo,
	Nombre = @Nombre,
	Descripcion = @Descripcion,
	IdCategoria = @IdCategoria,
	IdMarca = @IdMarca,
	Estado = @Estado
	BEGIN
		SET @Resultado = 0;
		SET @Mensaje = 'Ya existe un producto registrado con el mismo codigo'
	END
END
GO

--SET ELIMINAR PRODUCTO--
CREATE PROC sp_EliminarProducto(
@IdProducto INT,
@Respuesta BIT OUTPUT,
@Mensaje VARCHAR (500) OUTPUT
)
AS
BEGIN
	SET @Respuesta = 0
	SET @Mensaje = ''
	DECLARE @pasoreglas BIT = 1

	IF EXISTS (SELECT  * FROM DETALLE_COMPRA DC
	INNER JOIN PRODUCTO P ON P.IdProducto = DC.IdProducto
	WHERE P.IdProducto = @IdProducto
	)
	BEGIN 
		SET @pasoreglas = 0
		SET @Respuesta = 0
		SET @Mensaje = @Mensaje + 'No se puede eliminar porque el PRODUCTO se encuentra relacionado a una COMPRA\n'
	END

	IF EXISTS (SELECT  * FROM DETALLE_VENTA DV
	INNER JOIN PRODUCTO P ON P.IdProducto = DV.IdProducto
	WHERE P.IdProducto = @IdProducto
	)
	BEGIN
		SET @pasoreglas = 0
		SET @Respuesta = 0
		SET @Mensaje = @Mensaje + 'No se puede eliminar porque el PRODUCTO se encuentra relacionado a una VENTA\n'
	END

	IF(@pasoreglas = 1)
	BEGIN
		DELETE FROM PRODUCTO WHERE IdProducto = @IdProducto
		SET @Respuesta = 1
		SET @Mensaje = 'El PRODUCTO ha sido eliminado correctamente'
	END
END