IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Sp_TraerHoja')
   BEGIN
        DROP  Procedure Sp_TraerHoja
   End 
   GO 

CREATE Procedure Sp_TraerHoja
@idarbol codigo
as
if (@idarbol=0)
   select * from Hoja order by idarbol desc
else
   select * from Hoja where  idarbol=@idarbol order by idarbol desc
