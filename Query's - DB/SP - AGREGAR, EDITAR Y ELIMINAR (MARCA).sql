USE DBSISTEMA_VENTA
GO
--PROCEDIMIENTO CREAR CATEGORIA --
CREATE PROC SP_RegistrarMarca(
@Nombre VARCHAR(50),
@Estado BIT,
@Resultado INT OUTPUT,
@Mensaje VARCHAR (500) OUTPUT
)
AS
BEGIN
	SET @Resultado = 0
	IF NOT EXISTS (SELECT * FROM MARCA WHERE Nombre = @Nombre)
	BEGIN
		INSERT INTO MARCA(Nombre, Estado) VALUES (@Nombre, @Estado)
		SET @Resultado = SCOPE_IDENTITY()
		SET @Mensaje = 'MARCA creada exitosamente'
		END
		ELSE
			SET @Mensaje = 'No se puede repetir el nombre de una Marca'
END
GO

--PROCEDIMIENTO MODIFICAR CATEGORIA--
CREATE PROC SP_EditarMarca(
@IdMarca INT,
@Nombre VARCHAR(50),
@Estado BIT,
@Resultado INT OUTPUT,
@Mensaje VARCHAR (500) OUTPUT
)
AS
BEGIN
	SET @Resultado = 1
	SET @Mensaje = ''

	IF NOT EXISTS (SELECT 1 FROM MARCA 
		WHERE Nombre = @Nombre AND IdMarca = @IdMarca
		)
	BEGIN
		UPDATE MARCA SET Nombre = @Nombre, Estado = @Estado
		WHERE IdMarca = @IdMarca
		SET @Mensaje = 'MARCA modificada exitosamente'
	END
	ELSE
	BEGIN
		SET @Resultado = 0
		SET @Mensaje = 'No se puede repetir el nombre de una MARCA '
	END
END
GO

--PROCEDIMIENTO ELIMINAR CATEGORIA--
CREATE PROC SP_EliminarMarca
(
    @IdMarca INT,
    @Resultado INT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
    SET @Resultado = 1
    SET @Mensaje = ''

    IF NOT EXISTS (
        SELECT 1
        FROM MARCA M
        INNER JOIN PRODUCTO P ON P.IdCategoria = M.IdMarca
        WHERE M.IdMarca = @IdMarca
    )
    BEGIN
        DELETE FROM MARCA WHERE IdMarca = @IdMarca
        SET @Mensaje = 'MARCA eliminada correctamente.'
    END
    ELSE
    BEGIN
        SET @Resultado = 0
        SET @Mensaje = 'La MARCA se encuentra relacionada a un producto.'
    END
END
