Public Module Utilitario
    Public NroReporte As Integer
    Public Idespecie As Integer
    Public idarbol As Long
    Public idpedido As Long
    Public Enum Tarea
        guardar = 1
        modificar = 2
        eliminar = 3
    End Enum
    Public Enum ListaReporte
        ListadoDeEspecies = 1
        ListadoBosqueArbol = 2
        listdopedido = 3
    End Enum
    Public Function EsNumero(ByVal Nro As String) As Boolean
        Try
            Dim n As Integer = CInt(Nro)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Module
