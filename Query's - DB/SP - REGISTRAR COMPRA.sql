USE DBSISTEMA_VENTA
GO

CREATE TYPE [dbo].[EDetalle_Compra] AS TABLE(
	[IdProducto] INT NULL,
	[PrecioCompra] DECIMAL (18,2) NULL,
	[PrecioVenta] DECIMAL (18,2) NULL,
	[Cantidad] INT NULL,
	[MontoTotal] DECIMAL (18,2) NULL
)

GO

CREATE PROCEDURE sp_RegistrarCompra(
@IdUsuario INT,
@IdProveedor INT,
@TipoDocumento VARCHAR (500),
@NumeroDocumento VARCHAR (500),
@MontoTotal Decimal(18,2),
@DetalleCompra [EDetalle_compra] READONLY,
@Resultado BIT OUTPUT,
@Mensaje VARCHAR (500) OUTPUT
)
AS
BEGIN 
	BEGIN TRY
		DECLARE @idCompra INT = 0
		SET @Resultado = 1
		SET @Mensaje = ''

		BEGIN TRANSACTION Registro

		INSERT INTO COMPRA (IdUsuario, IdProveedor, TipoDocumento, NumeroDocumento, MontoTotal)
		VALUES (@IdUsuario, @IdProveedor, @TipoDocumento, @NumeroDocumento, @MontoTotal)

		SET @idCompra = SCOPE_IDENTITY()

		INSERT INTO DETALLE_COMPRA (IdCompra, IdProducto, PrecioCompra, PrecioVenta, Cantidad, MontoTotal)
		SELECT @idCompra, IdProducto, PrecioCompra, PrecioVenta, Cantidad, MontoTotal FROM @DetalleCompra

		UPDATE P SET P.Stock = P.Stock + DC.Cantidad,
		P.PrecioCompra = DC.PrecioCompra,
		P.PrecioVenta = DC.PrecioVenta
		FROM PRODUCTO P
		INNER JOIN @DetalleCompra DC ON DC.IdProducto = P.IdProducto

		COMMIT TRANSACTION Registro

	END TRY
	BEGIN CATCH
		SET @Resultado = 1
		SET @Mensaje = ERROR_MESSAGE()
		
		ROLLBACK TRANSACTION Registro

	END CATCH

END