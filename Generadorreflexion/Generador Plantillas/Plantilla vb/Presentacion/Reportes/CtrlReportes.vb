Public Class CtrlReportes
    'Public Function ListadoEspecie(ByVal id_especie As Long) As DataSet
    '    Dim objespecie As New Negocio.Especie
    '    objespecie.pIdespecie = id_especie
    '    Dim ds1 As New DataSet
    '    ds1.Tables.Add(objespecie.Traer_Especie(String.Empty))
    '    ds1.Tables(0).TableName = "especie"
    '    Return ds1
    'End Function

    'Public Function ListadoBosqueArboles(ByVal idarbol As Long) As DataSet
    '    Dim ds1 As New DataSet
    '    'cargamos la tabla bosque
    '    Dim objbosque As New Negocio.Bosque
    '    ds1.Tables.Add(objbosque.TraerBosque())
    '    ds1.Tables(0).TableName = "bosque"
    '    'cargamos la tabla especie
    '    Dim objespecie As New Negocio.Especie
    '    ds1.Tables.Add(objespecie.Traer_Especie(String.Empty))
    '    ds1.Tables(1).TableName = "Especie"
    '    'cagamos los datos del arbol
    '    Dim objarbol As New Negocio.Arbol
    '    objarbol.pIdarbol = idarbol
    '    ds1.Tables.Add(objarbol.traerArbol())
    '    ds1.Tables(2).TableName = "arbol"
    '    'cargamos la tabla hoja 
    '    Dim objhojas As New Negocio.Hoja
    '    ds1.Tables.Add(objhojas.traerhoja())
    '    ds1.Tables(3).TableName = "hoja"
    '    'cargamos la tabla tallo
    '    Dim objtallo As New Negocio.tallo
    '    ds1.Tables.Add(objtallo.traerTallo())
    '    ds1.Tables(4).TableName = "tallo"
    '    'cargamos la tabla raiz
    '    Dim objraiz As New Negocio.Raiz
    '    ds1.Tables.Add(objraiz.traerRaiz())
    '    ds1.Tables(5).TableName = "raiz"
    '    Return ds1
    'End Function


    'Public Function Listadopedido(ByVal idpedido As Long) As DataSet
    '    Dim ds1 As New DataSet
    '    'cargamos la tabla bosque
    '    Dim objbosque As New Negocio.Bosque
    '    ds1.Tables.Add(objbosque.TraerBosque())
    '    ds1.Tables(0).TableName = "bosque"
    '    Dim l As Integer = objbosque.TraerBosque.Rows.Count
    '    'cargamos la tabla especie
    '    Dim objespecie As New Negocio.Especie
    '    ds1.Tables.Add(objespecie.Traer_Especie(String.Empty))
    '    ds1.Tables(1).TableName = "Especie"
    '    l = objespecie.Traer_Especie(String.Empty).Rows.Count
    '    'cargamos los datos del arbol
    '    Dim objarbol As New Negocio.Arbol
    '    ds1.Tables.Add(objarbol.traerArbol())
    '    ds1.Tables(2).TableName = "arbol"
    '    l = objarbol.traerArbol.Rows.Count

    '    'cargamos el pedido
    '    Dim objpedido As New Negocio.Pedido
    '    objpedido.Pidpedido = idpedido
    '    ds1.Tables.Add(objpedido.Traer_Pedido())
    '    ds1.Tables(3).TableName = "pedido"
    '    l = objpedido.Traer_Pedido.Rows.Count
    '    'cargamos el detallepedido
    '    Dim objdetallepedido As New Negocio.Detalle_pedido
    '    objdetallepedido.Pidpedido = idpedido
    '    ds1.Tables.Add(objdetallepedido.Traer_Detalle_pedido())
    '    ds1.Tables(4).TableName = "Detalle_pedido"
    '    l = objdetallepedido.Traer_Detalle_pedido.Rows.Count


    '    Return ds1
    'End Function

End Class
