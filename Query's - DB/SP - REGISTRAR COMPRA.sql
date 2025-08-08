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

Create PROCEDURE sp_RegistrarCompra(
@IdUsuario INT,
@IdProveedor INT,
@TipoDocumento VARCHAR (500),
@NumeroDocumento VARCHAR (500),
@MontoTotal Decimal(18,2),
@DetalleCompra [EDetalle_compra] READONLY
)