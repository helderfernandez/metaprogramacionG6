IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Sp_TraerTallo')
   BEGIN
        DROP  Procedure Sp_TraerTallo
   End 
   GO 

CREATE Procedure Sp_TraerTallo
@idarbol codigo
as
if (@idarbol=0)
   select * from Tallo order by idarbol desc
else
   select * from Tallo where  idarbol=@idarbol order by idarbol desc
