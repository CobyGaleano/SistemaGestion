USE DBSISTEMA_VENTA
GO

/*PROCESOS PARA REGISTRAR UNA VENTA*/
CREATE TYPE [dbo].[EDetalle_Venta] AS TABLE(
	[IdProducto] INT NULL,
	[PrecioVenta] DECIMAL(18,2) NULL,
	[Cantidad] INT NULL,
	[SubTotal] DECIMAL(18,2) NULL
)

GO

CREATE PROCEDURE sp_RegistrarVenta(
@IdUsuario INT,
@TipoDocumento VARCHAR(500),
@NumeroDocumento VARCHAR(500),
@DocumentoCliente VARCHAR(500),
@NombreCliente VARCHAR(500),
@MontoPago DECIMAL(18,2),
@MontoCambio DECIMAL(18,2),
@MontoTotal DECIMAL(18,2),
@DetalleVenta [EDetalle_Venta] READONLY,
@Resultado BIT OUTPUT,
@Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
	BEGIN TRY
	
		DECLARE @idventa INT = 0
		SET @Resultado = 1
		SET @Mensaje = ''
	
		bEGIN TRANSACTION registro

		INSERT INTO VENTA(IdUsuario,TipoDocumento,NumeroDocumento,DocumentoCliente,NombreCliente,MontoPago,MontoCambio,MontoTotal)
		VALUES (@IdUsuario,@TipoDocumento,@NumeroDocumento,@DocumentoCliente,@NombreCliente,@MontoPago,@MontoCambio,@MontoTotal)

		SET @idventa = SCOPE_IDENTITY()

		INSERT INTO DETALLE_VENTA (IdVenta,IdProducto,PrecioVenta,Cantidad,SubTotal)
		SELECT @idventa, IdProducto, PrecioVenta,Cantidad,Subtotal FROM @DetalleVenta

		COMMIT TRANSACTION registro

	END TRY
	BEGIN CATCH
		SET @Resultado = 0
		SET @Mensaje = ERROR_MESSAGE()
		ROLLBACK TRANSACTION registro
	END CATCH
END

GO

UPDATE PRODUCTO SET Stock = Stock - @cantidad WHERE IdProducto = @idProducto

select * from venta
