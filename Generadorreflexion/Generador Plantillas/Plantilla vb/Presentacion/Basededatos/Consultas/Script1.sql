IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Sp_ABMArbol')
   BEGIN
        DROP  Procedure Sp_ABMArbol
   End 
   GO 

CREATE Procedure Sp_ABMArbol
       @Idarbol bigint,
       @edad Float,
       @altura Float,
       @Idbosque bigint,
       @Idespecie integer,
       @tarea integer,
       @resultado integer output
   as
    if (@tarea=1)
        insert into Arbol values(@Idarbol,@edad,@altura,@Idbosque,@Idespecie)
    if (@tarea=2)
        update Arbol set Idarbol=@Idarbol,edad=@edad,altura=@altura,Idbosque=@Idbosque,Idespecie=@Idespecie where idArbol= @idArbol
    if (@tarea=3)
       delete from Arbol where idArbol= @idArbol
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
