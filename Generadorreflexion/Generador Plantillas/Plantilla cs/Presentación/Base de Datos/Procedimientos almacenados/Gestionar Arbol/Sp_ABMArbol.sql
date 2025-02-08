IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Sp_ABMArbol')
   BEGIN
        DROP  Procedure Sp_ABMArbol
   End 
   GO 

CREATE Procedure Sp_ABMArbol
       @idArbol bigint,
       @nombre_Arbol varchar(250),
       @edad Float,
       @ancho Float,
       @idEspecie bigint,
       @idBosque bigint,
       @tarea integer,
       @resultado integer output
   as
    if (@tarea=1)
        insert into Arbol values(@idArbol,@nombre_Arbol,@edad,@ancho,@idEspecie,@idBosque)
    if (@tarea=2)
        update Arbol set idArbol=@idArbol,nombre_Arbol=@nombre_Arbol,edad=@edad,ancho=@ancho,idEspecie=@idEspecie,idBosque=@idBosque where idArbol= @idArbol
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
