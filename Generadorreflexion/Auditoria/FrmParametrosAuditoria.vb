Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class FrmParametrosAuditoria
    Private da As OleDbDataAdapter
    Private ds As DataSet
    Private conexion As OleDbConnection
    Private t As New conexion
    Dim nrofilas As Integer
    Dim yapaso As Boolean = False
    ' Defino la estructura del array de campos
    Structure regCampo
        Dim nombre As String
        Dim tipo As String
    End Structure

    ' Defino el array donde se guardarán los datos de la tabla
    Dim arrEstructura() As regCampo
    Private Sub cargarAtributos(ByVal tabla As String)
        Dim cadenita As String
        cadenita = "packet size=4096;integrated security=SSPI;data source=" & Utilitarios.servidor & ";persist security info=False;initial catalog=" & Utilitarios.Basededatos
        Dim cn As New SqlConnection(cadenita)
        Dim da As New SqlDataAdapter("SELECT * FROM [" & tabla & "]", cn) ' los [] ban por si es una tabla de nombre compuesto
        Dim cb As New SqlCommandBuilder(da)
        Dim ds As New DataSet
        Dim dc As DataColumn
        da.Fill(ds, "tabla")
        Dim indice As Short
        indice = 0
        ReDim arrEstructura(ds.Tables("tabla").Columns.Count() - 1)
        For Each dc In ds.Tables("tabla").Columns()
            arrEstructura(indice).nombre = dc.ColumnName.ToString
            arrEstructura(indice).tipo = Mid$(dc.DataType.ToString, InStr(dc.DataType.ToString, ".", CompareMethod.Text) + 1)
            indice = indice + 1
        Next
    End Sub
    Public Function CargarComboGDV(ByRef cbo As ComboBox, ByVal tabla As String)
        cbo.Items.Clear()
        Dim reg As regCampo
        cargarAtributos(tabla)
        For Each reg In arrEstructura
            cbo.Items.Add(reg.nombre)
        Next
        Return cbo
    End Function

    Private Sub FrmParametrosAuditoria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarComboGDV(Me.CbAtributos, Utilitarios.Tabla)
    End Sub

    Private Sub btnGenerarProcedimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerarProcedimiento.Click
        Utilitarios.AtributoDescriptor = Me.CbAtributos.Text
        Dim i As Integer
        Utilitarios.insertar = False
        Utilitarios.Modificar = False
        Utilitarios.Eliminar = False
        For i = 0 To CheckedListBox1.CheckedItems.Count - 1
            Select Case CheckedListBox1.CheckedItems(i).ToString
                Case "Insertar"
                    Utilitarios.insertar = True
                Case "Modificar"
                    Utilitarios.Modificar = True
                Case "Eliminar"
                    Utilitarios.Eliminar = True
                Case "Todas"
                    Utilitarios.Eliminar = True
                    Utilitarios.insertar = True
                    Utilitarios.Modificar = True
            End Select
        Next i
        Me.Close()
    End Sub

   
End Class