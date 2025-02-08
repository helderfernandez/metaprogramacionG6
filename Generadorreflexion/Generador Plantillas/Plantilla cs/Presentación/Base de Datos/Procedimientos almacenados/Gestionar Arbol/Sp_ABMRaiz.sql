IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Sp_ABMRaiz')
   BEGIN
        DROP  Procedure Sp_ABMRaiz
   End 
   GO 

CREATE Procedure Sp_ABMRaiz
       @idArbol bigint,
       @longitud Float,
       @descripcion varchar(250),
       @tarea integer,
       @resultado integer output
   as
    if (@tarea=1)
        insert into Raiz values(@idArbol,@longitud,@descripcion)
    if (@tarea=2)
        update Raiz set idArbol=@idArbol,longitud=@longitud,descripcion=@descripcion where idArbol= @idArbol
    if (@tarea=3)
       delete from Raiz where idArbol= @idArbol
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
