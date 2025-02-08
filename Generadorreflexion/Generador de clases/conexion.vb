Imports System.Data.OleDb
Public Class conexion

    Public Function conectar(ByVal base As String, ByVal server As String)
        Try
            Dim cade As String
            '"Data Source=LONDON;Initial Catalog=dbcooperativa;User ID=ESoto,pwd=UnoUpds2008
            'cade = "Provider=SQLOLEDB;Data Source=" & server & ";Integrated Security=SSPI;Initial Catalog=" & base

            If (base = "" Or server = "") Then
                Throw New Exception("Error al conectar")
            End If

            cade = "Provider=SQLOLEDB;Data Source=" & server & ";Integrated Security=SSPI;Initial Catalog=" & base & ";User ID=ESoto,pwd=UnoUpds2008"
            Dim cone As New OleDbConnection(cade)
            cone.Open()
            Return cone
        Catch ex As Exception
            ' MsgBox("Error al conectar al servidor")
        End Try
    End Function


    Public Function conectar(ByVal base As String, ByVal server As String, ByVal usuario As String, ByVal contraseña As String)
        Try
            Dim cade As String
            '"Data Source=LONDON;Initial Catalog=dbcooperativa;User ID=ESoto,pwd=UnoUpds2008
            'cade = "Provider=SQLOLEDB;Data Source=" & server & ";Integrated Security=SSPI;Initial Catalog=" & base
            cade = "Provider=SQLOLEDB;Data Source=" & server & ";Integrated Security=SSPI;Initial Catalog=" & base & ";User ID=" & usuario & ",pwd=" & contraseña
            Dim cone As New OleDbConnection(cade)
            cone.Open()
            Return cone
        Catch ex As Exception
            ' MsgBox("Error al conectar al servidor")
        End Try
    End Function
    Public Function conectar(ByVal server As String, ByVal usuario As String, ByVal contraseña As String)
        Try
            Dim cade As String
            '"Data Source=LONDON;Initial Catalog=dbcooperativa;User ID=ESoto,pwd=UnoUpds2008
            'cade = "Provider=SQLOLEDB;Data Source=" & server & ";Integrated Security=SSPI;Initial Catalog=" & base
            cade = "Provider=SQLOLEDB;Data Source=" & server & ";User ID=" & usuario & ";pwd=" & contraseña
            Dim cone As New OleDbConnection(cade)
            cone.Open()
            Return cone
        Catch ex As Exception
            ' MsgBox("Error al conectar al servidor")
        End Try
    End Function
    Public Function conectar(ByVal server As String)
        Try
            Dim cade As String
            '"Data Source=LONDON;Initial Catalog=dbcooperativa;User ID=ESoto,pwd=UnoUpds2008
            'cade = "Provider=SQLOLEDB;Data Source=" & server & ";Integrated Security=SSPI;Initial Catalog=" & base
            If (server = "") Then
                Throw New Exception("Error al conectar")
            End If
            cade = "Provider=SQLOLEDB;Data Source=" & server & ";Integrated Security=SSPI"
            Dim cone As New OleDbConnection(cade)
            cone.Open()
            Return cone
        Catch ex As Exception
            ' MsgBox("Error al conectar al servidor")
        End Try
    End Function
End Class
