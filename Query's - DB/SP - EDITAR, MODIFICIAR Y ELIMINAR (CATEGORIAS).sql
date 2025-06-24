USE DBSISTEMA_VENTA
GO
--PROCEDIMIENTO CREAR CATEGORIA --
CREATE PROC SP_RegistrarCategoria(
@Descripcion VARCHAR(50),
@Estado BIT,
@Resultado INT OUTPUT,
@Mensaje VARCHAR (500) OUTPUT
)
AS
BEGIN
	SET @Resultado = 0
	IF NOT EXISTS (SELECT * FROM CATEGORIA WHERE Descripcion = @Descripcion)
	BEGIN
		INSERT INTO CATEGORIA(Descripcion, Estado) VALUES (@Descripcion, @Estado)
		SET @Resultado = SCOPE_IDENTITY()
		SET @Mensaje = 'CATEGORIA creada exitosamente'
		END
		ELSE
			SET @Mensaje = 'No se puede repetir la descripcion de una categoria'
END
GO


--PROCEDIMIENTO MODIFICAR CATEGORIA--
CREATE PROC SP_EditarCategoria(
@IdCategoria INT,
@Descripcion VARCHAR(50),
@Estado BIT,
@Resultado INT OUTPUT,
@Mensaje VARCHAR (500) OUTPUT
)
AS
BEGIN
	SET @Resultado = 1
	SET @Mensaje = ''

	IF NOT EXISTS (SELECT 1 FROM CATEGORIA 
		WHERE Descripcion = @Descripcion AND IdCategoria = @IdCategoria
		)
	BEGIN
		UPDATE CATEGORIA SET Descripcion = @Descripcion, Estado = @Estado
		WHERE IdCategoria = @IdCategoria
		SET @Mensaje = 'CATEGORIA modificada exitosamente'
	END
	ELSE
	BEGIN
		SET @Resultado = 0
		SET @Mensaje = 'No se puede repetir la descripcion de una categoria'
	END
END
GO

--PROCEDIMIENTO ELIMINAR CATEGORIA--
CREATE PROC SP_EliminarCategoria
(
    @IdCategoria INT,
    @Resultado INT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
    SET @Resultado = 1
    SET @Mensaje = ''

    IF NOT EXISTS (
        SELECT 1
        FROM CATEGORIA C
        INNER JOIN PRODUCTO P ON P.IdCategoria = C.IdCategoria
        WHERE C.IdCategoria = @IdCategoria
    )
    BEGIN
        DELETE FROM CATEGORIA WHERE IdCategoria = @IdCategoria
        SET @Mensaje = 'Categoría eliminada correctamente.'
    END
    ELSE
    BEGIN
        SET @Resultado = 0
        SET @Mensaje = 'La categoría se encuentra relacionada a un producto.'
    END
END