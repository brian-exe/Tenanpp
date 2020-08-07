USE TenanppDB;

CREATE VIEW RankingAtencion
AS 
SELECT TOP (3)
    InmobiliariaId,
    Inmo.Nombre,
    ROUND(AVG(CAST(ValoracionAtencion AS FLOAT)), 2) AS 'PromedioAtencion'
FROM [TenanppDB].[dbo].[OpinionesInmobiliarias] Opi
    Inner JOIN [TenanppDB].[dbo].[Inmobiliarias] Inmo ON Opi.InmobiliariaId = Inmo.Id
GROUP BY Opi.InmobiliariaId, Inmo.Nombre
ORDER BY PromedioAtencion DESC;

CREATE VIEW RankingResponsabilidad
AS 
SELECT TOP (3)
    InmobiliariaId,
    Inmo.Nombre,
        ROUND(AVG(CAST(ValoracionResponsabilidad AS FLOAT)), 2) AS 'PromedioResponsabilidad'
FROM [TenanppDB].[dbo].[OpinionesInmobiliarias] Opi
    Inner JOIN [TenanppDB].[dbo].[Inmobiliarias] Inmo ON Opi.InmobiliariaId = Inmo.Id
GROUP BY Opi.InmobiliariaId, Inmo.Nombre
ORDER BY PromedioResponsabilidad DESC;

CREATE VIEW RankingConductaEtica
AS 
SELECT TOP (3)
    InmobiliariaId,
    Inmo.Nombre,
    ROUND(AVG(CAST(ValoracionConductaEtica AS FLOAT)), 2) AS 'PromedioConductaEtica'
FROM [TenanppDB].[dbo].[OpinionesInmobiliarias] Opi
    Inner JOIN [TenanppDB].[dbo].[Inmobiliarias] Inmo ON Opi.InmobiliariaId = Inmo.Id
GROUP BY Opi.InmobiliariaId, Inmo.Nombre
ORDER BY PromedioConductaEtica DESC;

CREATE VIEW RankingGeneral
AS 
SELECT TOP (3)
    InmobiliariaId,
    Inmo.Nombre,
    (ROUND(AVG(CAST(ValoracionConductaEtica AS FLOAT)), 2) + 
    ROUND(AVG(CAST(ValoracionResponsabilidad AS FLOAT)), 2) +
    ROUND(AVG(CAST(ValoracionAtencion AS FLOAT)), 2)) /3 AS 'PromedioGeneral'
FROM [TenanppDB].[dbo].[OpinionesInmobiliarias] Opi
    Inner JOIN [TenanppDB].[dbo].[Inmobiliarias] Inmo ON Opi.InmobiliariaId = Inmo.Id
GROUP BY Opi.InmobiliariaId, Inmo.Nombre
ORDER BY PromedioGeneral DESC;