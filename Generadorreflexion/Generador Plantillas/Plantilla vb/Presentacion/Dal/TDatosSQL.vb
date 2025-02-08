Imports System.Data.SqlClient
Public Class TDatosSQL
#Region "Atributos"
    Protected Servidor As String 'Nombre del Servidor
    Protected BaseDatos As String 'Nombre de la base de datos
    Protected Usuario As String 'Nombre del inicio de sesion
    Protected Password As String 'Password del usuario en caso de que el inicio de sesion lo requiera
    Protected ModoMixto As Boolean 'En caso de que el Servidor acepte modo mixto de autenticacion
    Protected CadenaConexion As String 'Asigna la cadena de conexion creada por los anteriores parametros
    Private ColComandos As System.Collections.Hashtable 'Almacena los parametros de los procedimientos almacenados
#End Region
#Region "Constructor"
    Public Sub New(ByVal strCadena As String)
        pCadenaConexion = strCadena
    End Sub
    Public Sub New(ByVal vServidor As String, ByVal vBaseDatos As String, ByVal vUsuario As String, ByVal vPassword As String, ByVal vModoMixto As Boolean)
        pServidor = vServidor
        pBaseDatos = vBaseDatos
        pPassword = vPassword
        pUsuario = vUsuario
        ModoMixto = vModoMixto
    End Sub
    Public Sub New()
        Servidor = My.Resources.Servidor
        BaseDatos = My.Resources.BaseDatos
        Password = My.Resources.Password
        Usuario = My.Resources.Usuario
        ModoMixto = (My.Resources.ModoMixto = "1")
        CadenaConexion = pCadenaConexion
        ColComandos = New System.Collections.Hashtable
    End Sub
#End Region
#Region "Propiedades"
    Public Property pUsuario() As String
        Get
            Return Usuario
        End Get
        Set(ByVal value As String)
            Usuario = value
        End Set
    End Property
    Public Property pModoMixto() As Boolean
        Get
            Return ModoMixto
        End Get
        Set(ByVal value As Boolean)
            ModoMixto = value
        End Set
    End Property
    Public Property pServidor() As String
        Get
            Return Servidor
        End Get
        Set(ByVal Value As String)
            Servidor = Value
        End Set
    End Property
    Public Property pBaseDatos() As String
        Get
            Return BaseDatos
        End Get
        Set(ByVal Value As String)
            BaseDatos = Value
        End Set
    End Property
    Public Property pPassword() As String
        Get
            Return Password
        End Get
        Set(ByVal Value As String)
            Password = Value
        End Set
    End Property

    Public Property pCadenaConexion() As String
        Get
            'Return CadenaConexion
            If (Me.Servidor.Length <> 0) And (Me.BaseDatos.Length <> 0) Then
                Dim strCadena As New System.Text.StringBuilder
                If ModoMixto Then
                    strCadena.Append("data source=<SERVIDOR>;")
                    strCadena.Append("initial catalog=<BASEDATOS>;password='';")
                    strCadena.Append("persist security info=True;")
                    strCadena.Append("user id=<USUARIO>;pwd=<PASSWORD>;packet size=4096")
                    strCadena.Replace("<USUARIO>", Me.Usuario) 'PARA REEMPLAZAR LOS VALORES DE strCadena
                    strCadena.Replace("<SERVIDOR>", Me.Servidor) 'PARA REEMPLAZAR LOS VALORES DE strCadena
                    strCadena.Replace("<BASEDATOS>", Me.BaseDatos) ' IDEM PARA BASE DE DATOS
                    strCadena.Replace("<PASSWORD>", Me.Password) 'IDEM PARA PASSWORD
                Else
                    'CadenaConexion = "Data Source=PC-10AF49FB76BE\SQLEXPRESS;Initial Catalog=db_sipad;Integrated Security=True"
                    strCadena.Append("data source=<SERVIDOR>;")
                    strCadena.Append("initial catalog=<BASEDATOS>;")
                    strCadena.Append("Integrated Security=True")
                    strCadena.Replace("<SERVIDOR>", Me.Servidor) 'PARA REEMPLAZAR LOS VALORES DE strCadena
                    strCadena.Replace("<BASEDATOS>", Me.BaseDatos) ' IDEM PARA BASE DE DATOS
                End If
                Return strCadena.ToString
            Else
                Dim Ex As New System.Exception("No se puede establecer la cadena de conexión")
                Throw Ex
                Return ""
            End If
        End Get
        Set(ByVal Value As String)
            CadenaConexion = Value
        End Set
    End Property
#End Region
#Region "Acciones"
    Public Function GetCadena() As String
        Return CadenaConexion
    End Function
    Public Function CrearConexion(ByVal strCadena As String) As SqlConnection        
        Return New SqlConnection(strCadena)
    End Function
    Public Function Conexion() As SqlConnection
        Return CrearConexion(CadenaConexion)
    End Function
    Public Function Comando(ByVal NombreProcedimiento As String) As SqlCommand
        Dim Com As SqlCommand
        If ColComandos.Contains(NombreProcedimiento) Then
            Com = ColComandos(NombreProcedimiento)
        Else
            Dim Con2 As New SqlConnection(CadenaConexion)
            Con2.Open()
            Com = New SqlCommand(NombreProcedimiento, Con2)
            Com.CommandType = CommandType.StoredProcedure
            SqlCommandBuilder.DeriveParameters(Com)
            Con2.Close()
            Con2.Dispose()
            ColComandos.Add(NombreProcedimiento, Com)
            Com.Connection = Me.Conexion
            Com.Connection.Open()
            Com.Transaction = Transaccion
        End If
        Return Com
    End Function
    Public Function Comando(ByVal NombreProcedimiento As String, ByVal tran As SqlTransaction) As SqlCommand
        Dim Com As SqlCommand
        If ColComandos.Contains(NombreProcedimiento) Then
            Com = ColComandos(NombreProcedimiento)
        Else
            Dim Con2 As New SqlConnection(CadenaConexion)
            Con2.Open()
            Com = New SqlCommand(NombreProcedimiento, Con2)
            Com.CommandType = CommandType.StoredProcedure
            SqlCommandBuilder.DeriveParameters(Com)
            Con2.Close()
            Con2.Dispose()
            ColComandos.Add(NombreProcedimiento, Com)
            Com.Connection = tran.Connection
            Com.Transaction = tran
        End If
        Return Com
    End Function
    Public Function CrearDataAdapter(ByVal NombreProcedimiento As String, ByVal args() As System.Object) As SqlDataAdapter
        Dim da As New SqlDataAdapter(Me.Comando(NombreProcedimiento))
        If (args.Length <> 0) Then
            CargarParametros(da.SelectCommand, args)
        End If
        Return da
    End Function
    Public Function CrearDataAdapter(ByVal NombreProcedimiento As String) As SqlDataAdapter
        Dim da As New SqlDataAdapter(Me.Comando(NombreProcedimiento))
        Return da
    End Function
    Public Function RelacionarDosTablas(ByVal TablaPadre As String, ByVal ColumnaTablaPadre As String, ByVal TablaHija As String, ByVal ColumnaTablaHija As String) As DataSet
        Dim com As New SqlCommand
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        com.Connection = Conexion()

        com.CommandText = "SELECT *FROM " & TablaPadre
        da.SelectCommand = com
        da.Fill(ds, TablaPadre)

        com.CommandText = "SELECT *FROM " & TablaHija
        da.SelectCommand = com
        da.Fill(ds, TablaHija)

        ds.Relations.Add(("Relacion-" + TablaPadre + "-" & TablaHija), ds.Tables(TablaPadre).Columns(ColumnaTablaPadre), ds.Tables(TablaHija).Columns(ColumnaTablaHija))
        Return ds
    End Function
    Public Sub CargarParametros(ByVal Comando As SqlCommand, ByVal args() As System.Object)
        Dim Par As SqlParameter
        Dim i As Integer = 1
        While (i < Comando.Parameters.Count)
            Par = Comando.Parameters(i)
            If (i <= args.Length) Then
                Par.Value = args(i - 1)
            Else
                Par.Value = Nothing
            End If
            i = i + 1
        End While
    End Sub
    Public Function Ejecutar(ByVal NombreProcedimiento As String) As Integer
        Return Me.Comando(NombreProcedimiento).ExecuteNonQuery
    End Function
    Public Function Ejecutar(ByVal NombreProcedimiento As String, ByVal args() As System.Object) As Integer
        Dim Com As New SqlCommand
        Dim Respuesta As Integer
        Com = Me.Comando(NombreProcedimiento)
        Me.CargarParametros(Com, args)
        Try
            Respuesta = Com.ExecuteNonQuery
            Dim Par As SqlParameter
            Dim i As Integer = 1
            While (i < Com.Parameters.Count)
                Par = Com.Parameters(i)
                If (Par.Direction = ParameterDirection.InputOutput) Or (Par.Direction = ParameterDirection.Output) Then
                    args.SetValue(Par.Value, i - 1)
                    Respuesta = CInt(Par.Value)
                End If
                i = i + 1
            End While
            Return Respuesta
        Catch ex As Exception
            Return Respuesta
        End Try
    End Function
    Public Function TraerDataTablestrSql(ByVal strSql As String) As DataTable
        Dim Com As New SqlCommand
        Com.Connection = New SqlConnection(CadenaConexion)
        Com.Connection.Open()
        Com.CommandText = strSql

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        da.SelectCommand = Com

        da.Fill(dt)
        Com.Connection.Close()
        Com.Dispose()
        da.Dispose()
        Return dt
    End Function
    Public Function Ejecutar(ByVal NombreProcedimiento As String, ByVal args() As System.Object, ByVal tran As SqlTransaction) As Integer
        Dim Com As New SqlCommand
        Dim Respuesta As Integer
        Com = Me.Comando(NombreProcedimiento, tran)
        Me.CargarParametros(Com, args)
        Respuesta = Com.ExecuteNonQuery
        Dim Par As SqlParameter
        Dim i As Integer = 1
        While (i < Com.Parameters.Count)
            Par = Com.Parameters(i)
            If (Par.Direction = ParameterDirection.InputOutput) Or (Par.Direction = ParameterDirection.Output) Then
                args.SetValue(Par.Value, i - 1)
                Respuesta = CInt(Par.Value)
            End If
            i = i + 1
        End While
        Return Respuesta
    End Function

    'Ejecuta y devuelve dos resultads
    Public Function EjecutarMejorado(ByVal NombreProcedimiento As String, ByVal args() As System.Object) As Object()
        Dim Respuesta(2) As System.Object
        Dim Com As New SqlCommand
        Com = Me.Comando(NombreProcedimiento)
        Me.CargarParametros(Com, args)
        Try
            Com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Dim Par As SqlParameter
        Dim i As Integer = 1
        Dim cr As Integer = 0
        While (i < Com.Parameters.Count)
            Par = Com.Parameters(i)
            If (Par.Direction = ParameterDirection.InputOutput) Or (Par.Direction = ParameterDirection.Output) Then
                args.SetValue(Par.Value, i - 1)
                Respuesta(cr) = Par.Value
                cr = cr + 1
            End If
            i = i + 1
        End While
        Return Respuesta
    End Function

    'Ejecuta y devuelve dos resultads
    Public Function EjecutarMejorado(ByVal NombreProcedimiento As String, ByVal args() As System.Object, ByVal tran As SqlTransaction) As Object()
        Dim Respuesta(2) As System.Object
        Dim Com As New SqlCommand
        Com = Me.Comando(NombreProcedimiento, tran)
        Me.CargarParametros(Com, args)
        Try
            Com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Dim Par As SqlParameter
        Dim i As Integer = 1
        Dim cr As Integer = 0
        While (i < Com.Parameters.Count)
            Par = Com.Parameters(i)
            If (Par.Direction = ParameterDirection.InputOutput) Or (Par.Direction = ParameterDirection.Output) Then
                args.SetValue(Par.Value, i - 1)
                Respuesta(cr) = Par.Value
                cr = cr + 1
            End If
            i = i + 1
        End While
        Return Respuesta
    End Function
    Protected Function ejecutarDML(ByVal strDML As String) As Integer
        Dim trnTemp As System.Data.SqlClient.SqlTransaction = Me.IniciarTransaccion()
        Dim i As Integer = Me.ejecutarDML(strDML, trnTemp)
        trnTemp.Commit()
        Return i
    End Function

    Protected Function ejecutarDML(ByVal strDML As String, ByVal trnTemp As System.Data.SqlClient.SqlTransaction) As Integer
        Dim cmdTemp As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand(strDML, trnTemp.Connection)
        cmdTemp.Transaction = trnTemp
        Try
            Return cmdTemp.ExecuteNonQuery()
        Catch ex As Exception
            Return 0
            MsgBox(ex.Message)
        End Try
    End Function
    Protected Function consultar(ByVal strSelect As String) As System.Data.DataSet
        Dim trnTemp As System.Data.SqlClient.SqlTransaction = Me.IniciarTransaccion()
        Dim dtsTemp As System.Data.DataSet = Me.consultar(strSelect, trnTemp)
        trnTemp.Commit()
        Return dtsTemp
    End Function
    Protected Function consultar(ByVal strSelect As String, ByVal trnTemp As System.Data.SqlClient.SqlTransaction) As System.Data.DataSet
        Dim adaTemp As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(strSelect, trnTemp.Connection)
        adaTemp.SelectCommand.Transaction = trnTemp
        Dim dtsTemp As System.Data.DataSet = New System.Data.DataSet
        adaTemp.Fill(dtsTemp)
        Return dtsTemp
    End Function
    Public Function generarcodigo(ByVal tabla As String) As Long
        Dim strSelect As String = "Select * from " & tabla & " order by id" & tabla & " desc"
        Dim trnTemp As System.Data.SqlClient.SqlTransaction = Me.IniciarTransaccion()
        Dim dtTemp As System.Data.DataTable = Me.TraerDataTablestrSql(strSelect)
        trnTemp.Commit()
        Dim nrocodigo As Long = dtTemp.Rows(0).Item(0)
        Return nrocodigo
    End Function
#End Region
#Region "Transacciones"
    Protected Transaccion As SqlTransaction
    Protected EnTransaccion As Boolean
    Public Function IniciarTransaccion() As SqlTransaction
        Dim Con As SqlConnection = Me.Conexion()
        Con.Open()    
        Return Con.BeginTransaction()
        'EnTransaccion = True
    End Function
    Public Sub TerminarTransaccion()
        Try
            Try
                Transaccion.Commit()
            Catch ex As Exception
                Throw ex
            End Try
        Finally
            Transaccion = Nothing
            EnTransaccion = False
        End Try
    End Sub
    Public Sub AbortarTransaccion()
        Try
            Try
                Transaccion.Rollback()
            Catch ex As Exception
                Throw ex
            End Try
        Finally
            Transaccion = Nothing
            EnTransaccion = False
        End Try
    End Sub
#End Region
#Region "Lecturas"
    Public Function TraerDataSet(ByVal NombreProcedimiento As String) As DataSet
        Dim ds As New DataSet
        Me.CrearDataAdapter(NombreProcedimiento).Fill(ds)
        Return ds
    End Function
    Public Function TraerDataSet(ByVal NombreProcedimiento As String, ByVal args() As System.Object) As DataSet
        Dim ds As New DataSet
        Me.CrearDataAdapter(NombreProcedimiento, args).Fill(ds)
        Return ds
    End Function

    Public Function TraerDataTable(ByVal NombreProcedimiento As String) As DataTable
        Return Me.TraerDataSet(NombreProcedimiento).Tables(0).Copy
    End Function

    Public Function TraerDataTable(ByVal NombreProcedimiento As String, ByVal args() As System.Object) As DataTable
        Return Me.TraerDataSet(NombreProcedimiento, args).Tables(0).Copy
    End Function

    Public Function TraerValor(ByVal NombreProcedimiento As String) As System.Object
        Dim Com As New SqlCommand
        Com = Me.Comando(NombreProcedimiento)
        Com.ExecuteNonQuery()
        Dim Par As SqlParameter
        Dim Valor As Object = DBNull.Value
        Dim i As Integer = 0
        While (i < Com.Parameters.Count)
            Par = Com.Parameters(i)
            If (Par.Direction = ParameterDirection.InputOutput) Or (Par.Direction = ParameterDirection.Output) Then
                Valor = Par.Value
            End If
            i = i + 1
        End While
        Return Valor
    End Function

    Public Function TraerValor(ByVal NombreProcedimiento As String, ByVal args() As System.Object) As System.Object
        Dim Com As New SqlCommand
        Com = Me.Comando(NombreProcedimiento)
        Me.CargarParametros(Com, args)
        Dim Valor As Object = DBNull.Value
        Com.ExecuteNonQuery()
        Dim Par As SqlParameter
        Dim i As Integer = 0
        While (i < Com.Parameters.Count)
            Par = Com.Parameters(i)
            If (Par.Direction = ParameterDirection.InputOutput) Or (Par.Direction = ParameterDirection.Output) Then
                Valor = Par.Value
            End If
            i = i + 1
        End While

        Return Valor
    End Function

#End Region
#Region "Destructor"

#End Region
End Class
