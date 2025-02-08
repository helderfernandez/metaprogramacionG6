IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Sp_TraerArbol')
   BEGIN
        DROP  Procedure Sp_TraerArbol
   End 
   GO 

CREATE Procedure Sp_TraerArbol
@IdArbol codigo
as
if (@IdArbol=0)
   select * from Arbol order by IdArbol desc
else
   select * from Arbol where  IdArbol=@IdArbol order by IdArbol desc
