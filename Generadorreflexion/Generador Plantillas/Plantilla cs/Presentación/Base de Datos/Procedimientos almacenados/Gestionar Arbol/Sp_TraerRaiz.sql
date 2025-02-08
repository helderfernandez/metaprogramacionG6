IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Sp_TraerRaiz')
   BEGIN
        DROP  Procedure Sp_TraerRaiz
   End 
   GO 

CREATE Procedure Sp_TraerRaiz
@Idarbol codigo
as
if (@Idarbol=0)
   select * from Raiz order by Idarbol desc
else
   select * from Raiz where  Idarbol=@Idarbol order by Idarbol desc
