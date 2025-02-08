IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Sp_ABMTallo')
   BEGIN
        DROP  Procedure Sp_ABMTallo
   End 
   GO 

CREATE Procedure Sp_ABMTallo
       @idArbol bigint,
       @longitud Float,
       @diametro Float,
       @tarea integer,
       @resultado integer output
   as
    if (@tarea=1)
        insert into Tallo values(@idArbol,@longitud,@diametro)
    if (@tarea=2)
        update Tallo set idArbol=@idArbol,longitud=@longitud,diametro=@diametro where idArbol= @idArbol
    if (@tarea=3)
       delete from Tallo where idArbol= @idArbol
    if(@@error=0)
      begin
          set @resultado=1
          Return (1)
      End
      Else
        begin
            set @resultado=0
            Return (0)
        End 
