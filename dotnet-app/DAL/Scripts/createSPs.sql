USE [TenanppDB];
GO;

CREATE PROCEDURE EstadisticasInmobiliaria
(
    @id INT
) 
AS
BEGIN
    SELECT 
        ROUND(AVG(CAST(ValoracionAtencion AS FLOAT)), 2) AS 'PromedioAtencion',
        ROUND(AVG(CAST(ValoracionResponsabilidad AS FLOAT)), 2) AS 'PromedioResponsabilidad',
        ROUND(AVG(CAST(ValoracionConductaEtica AS FLOAT)), 2) AS 'PromedioConductaEtica',
        COUNT(CASE WHEN AceptaPagoElectronico = 1 then 1 end) AS 'VotosPagoElectronico',
        COUNT(CASE WHEN AceptaPagoElectronico = 0 then 1 end) AS 'VotosNoPagoElectronico'
    FROM [TenanppDB].[dbo].[OpinionesInmobiliarias]
    WHERE InmobiliariaId = @id
END;
GO;