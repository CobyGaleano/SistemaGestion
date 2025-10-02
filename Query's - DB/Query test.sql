SELECT v.IdVenta, u.NombreCompleto, v.DocumentoCliente, v.NombreCliente, v.TipoDocumento,
v.NumeroDocumento, v.MontoPago, v.MontoCambio, v FROM VENTA V

SELECT * FROM VENTA V INNER JOIN USUARIO U ON U.IdUsuario = V.IdUsuario
WHERE V.NumeroDocumento = '00001'