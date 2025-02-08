IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Sp_ABMHoja')
   BEGIN
        DROP  Procedure Sp_ABMHoja
   End 
   GO 

CREATE Procedure Sp_ABMHoja
       @idArbol bigint,
       @forma varchar(250),
       @color varchar(250),
       @tarea integer,
       @resultado integer output
   as
    if (@tarea=1)
        insert into Hoja values(@idArbol,@forma,@color)
    if (@tarea=2)
        update Hoja set idArbol=@idArbol,forma=@forma,color=@color where idArbol= @idArbol
    if (@tarea=3)
       delete from Hoja where idArbol= @idArbol
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
