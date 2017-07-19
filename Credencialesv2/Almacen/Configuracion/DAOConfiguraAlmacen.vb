Imports System.Data.SqlClient
Imports PoolConexiones

Namespace DAOAlmacen

    Public NotInheritable Class DAOConfiguraAlmacen

        Private Sub New()
        End Sub

        Private Shared _InstanciaConfiguraAlmacen As DAOConfiguraAlmacen = Nothing
        Public Advertencia As String = String.Empty

        'Instancia unica de la clase
        Public Shared ReadOnly Property Instancia() As DAOConfiguraAlmacen
            Get
                If _InstanciaConfiguraAlmacen Is Nothing Then
                    _InstanciaConfiguraAlmacen = New DAOConfiguraAlmacen
                End If
                Return _InstanciaConfiguraAlmacen
            End Get
        End Property


#Region "Tablas Maestras"

        'Busca los productos de acuerdo a un criterio de busqueda
        Public Function fdu_Central_BuscarProductos(ByVal Criterio As String) As DataTable
            Dim Dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_BuscarProductosCentral]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@Criterio", Criterio)

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(Dt)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Dt = Nothing
            Finally
                Da = Nothing
                Cmd = Nothing
            End Try

            Return Dt

        End Function

        'Para Cargar los combobox del FrmListaProductos
        Public Function fdu_LlenarFrmListaProductos() As DataTable

            Dim tabla As New DataTable
            Dim Cmd As New SqlCommand

            Dim Da As SqlDataAdapter
            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_LlenarFrmListaProductos]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(tabla)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                tabla = Nothing
            Finally
                Da = Nothing
                Cmd = Nothing
            End Try

            Return tabla
        End Function

        Public Function fdu_BuscarProducto(ByVal CodProd As String, ByVal Desc As String) As DataTable
            Dim Dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_BuscarProducto]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@codProd", IIf(CodProd.Trim.Length = 0, DBNull.Value, CodProd))
                Cmd.Parameters.AddWithValue("@desc", IIf(Desc.Trim.Length = 0, DBNull.Value, Desc))

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(Dt)

                If Dt Is Nothing OrElse Dt.Rows.Count = 0 Then
                    Advertencia = "No hay datos para mostrar"
                End If

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Dt = Nothing
            Finally
                Da = Nothing
                Cmd = Nothing
            End Try

            Return Dt

        End Function

        Public Function fdu_EliminarProducto(ByVal nroProducto As Integer) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_EliminarProducto]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@NroProd", nroProducto)
                Cmd.Parameters.Add(Prm)

                If Cmd.Connection.State = ConnectionState.Closed Then
                    Cmd.Connection.Open()
                End If

                dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dr.Read()
                Retorno = TSQL.CodigoRetorno(dr.GetString(0), Advertencia)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Retorno = False
            Finally
                If Not IsNothing(dr) Then
                    dr.Close()
                End If
                dr = Nothing
                Prm = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno
        End Function

        Public Function fdu_ActDesactProducto(ByVal nroProducto As Integer, ByVal estado As Boolean) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_ActDesactProducto]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@NroProd", nroProducto)
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@estado", estado)
                Cmd.Parameters.Add(Prm)

                If Cmd.Connection.State = ConnectionState.Closed Then
                    Cmd.Connection.Open()
                End If

                dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dr.Read()
                Retorno = TSQL.CodigoRetorno(dr.GetString(0), Advertencia)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Retorno = False
            Finally
                If Not IsNothing(dr) Then
                    dr.Close()
                End If
                dr = Nothing
                Prm = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno

        End Function

        Public Function fdu_NuevoProducto(ByVal oProducto As GEACEntidades.Almacen.CodigosProducto) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            With oProducto
                Try
                    Cmd.CommandText = "[Almacen].[SpAlm_CTRL_NuevoProducto]"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure

                    Prm = New SqlParameter("@codProducto", .CodProducto)
                    Cmd.Parameters.Add(Prm)
                    Prm = New SqlParameter("@descripcion", .Descripcion)
                    Cmd.Parameters.Add(Prm)
                    Prm = New SqlParameter("@IDMarca", IIf(.IDMarca <= 0, DBNull.Value, .IDMarca))
                    Cmd.Parameters.Add(Prm)
                    Prm = New SqlParameter("@IDMedida", IIf(.IDFraccion <= 0, DBNull.Value, .IDFraccion))
                    Cmd.Parameters.Add(Prm)
                    'Para Parte Unidad
                    Prm = New SqlParameter("@IDParte", IIf(.NroFamilia <= 0, DBNull.Value, .NroFamilia))
                    Cmd.Parameters.Add(Prm)
                    '
                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If

                    Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    Dr.Read()
                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)

                Catch ex As Exception
                    Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                    Retorno = False
                Finally
                    If Not IsNothing(Dr) Then
                        Dr.Close()
                    End If
                    Dr = Nothing
                    Prm = Nothing
                    Cmd.Dispose()
                    Cmd = Nothing
                End Try

                Return Retorno
            End With
        End Function

        Public Function fdu_ModificarProducto(ByVal oProducto As GEACEntidades.Almacen.CodigosProducto) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            With oProducto
                Try
                    Cmd.CommandText = "[Almacen].[SpAlm_CTRL_ModificarProducto]"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure

                    Prm = New SqlParameter("@nroProd", .IDPresentacion) 'Para el NroProducto
                    Cmd.Parameters.Add(Prm)
                    If .CodReemplazo.Length > 0 Then
                        Prm = New SqlParameter("@CodReemplazo", .CodReemplazo)
                        Cmd.Parameters.Add(Prm)
                    End If
                    Prm = New SqlParameter("@descripcion", .Descripcion)
                    Cmd.Parameters.Add(Prm)
                    Prm = New SqlParameter("@IDMarca", IIf(.IDMarca <= 0, DBNull.Value, .IDMarca))
                    Cmd.Parameters.Add(Prm)
                    'Prm = New SqlParameter("@IDMedida", IIf(.IDFraccion <= 0, DBNull.Value, .IDFraccion))
                    'Cmd.Parameters.Add(Prm)

                    'Para Parte Unidad
                    Prm = New SqlParameter("@IDParte", IIf(.NroFamilia <= 0, DBNull.Value, .NroFamilia))
                    Cmd.Parameters.Add(Prm)
                    '
                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If
                    Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    Dr.Read()
                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)

                Catch ex As Exception
                    Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                    Retorno = False
                Finally
                    If Not IsNothing(Dr) Then
                        Dr.Close()
                    End If
                    Dr = Nothing
                    Prm = Nothing
                    Cmd.Dispose()
                    Cmd = Nothing
                End Try

                Return Retorno
            End With
        End Function

        Public Function fdu_CambiarCodigoProducto(ByVal nroProducto As Integer, ByVal codProd As String) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_CambiarCodigoProducto]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@nroProd", nroProducto)
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@codProd", codProd)
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@User", GEACEntidades.SesionUsuario.Usuario)
                Cmd.Parameters.Add(Prm)

                If Cmd.Connection.State = ConnectionState.Closed Then
                    Cmd.Connection.Open()
                End If
                Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()
                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Retorno = False
            Finally
                If Not IsNothing(Dr) Then
                    Dr.Close()
                End If
                Dr = Nothing
                Prm = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno
        End Function

        Public Function fdu_FiltrarProducto(ByVal CodProd As String, ByVal Desc As String) As DataTable
            Dim Dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_FiltrarProductoXDesc]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure
                If Desc.Trim.Length > 0 Then Cmd.Parameters.AddWithValue("@desc", Desc)
                If CodProd.Trim.Length > 0 Then Cmd.Parameters.AddWithValue("@codProd", CodProd)

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(Dt)
            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                Dt = Nothing
            Finally
                Da = Nothing
                Cmd = Nothing
            End Try

            Return Dt
        End Function

        'Public Function fdu_MapeoFamiliaProducto(ByVal xmlMapeo As String, ByVal NroFamilia As Integer) As Boolean
        '    Dim Cmd As New SqlCommand
        '    Dim Prm As SqlParameter
        '    Dim Retorno As Boolean
        '    Dim dr As SqlDataReader = Nothing

        '    Try
        '        Cmd.CommandText = "[Almacen].[SpAlm_CTRL_MapeoFamiliaProducto]"
        '        Cmd.Connection = TSQL.ConexionPermanente
        '        Cmd.CommandType = CommandType.StoredProcedure

        '        Prm = New SqlParameter("@xMapeo", xmlMapeo)
        '        Cmd.Parameters.Add(Prm)

        '        If NroFamilia > 0 Then
        '            Prm = New SqlParameter("@nroFam", NroFamilia)
        '            Cmd.Parameters.Add(Prm)
        '        End If

        '        If Cmd.Connection.State = ConnectionState.Closed Then
        '            Cmd.Connection.Open()
        '        End If

        '        dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
        '        dr.Read()
        '        Retorno = TSQL.CodigoRetorno(dr.GetString(0), Advertencia)

        '    Catch ex As Exception
        '        Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
        '        Retorno = False
        '    Finally
        '        If Not IsNothing(dr) Then
        '            dr.Close()
        '        End If
        '        dr = Nothing
        '        Prm = Nothing
        '        Cmd.Dispose()
        '        Cmd = Nothing
        '    End Try

        '    Return Retorno
        'End Function
        Public Function fdu_MapeoGruposProducto(ByVal xmlMapeo As String, ByVal NroFamilia As Integer) As Boolean
            Dim Cmd As New SqlCommand
            Dim Retorno As Boolean
            Dim dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_MapeoGruposProducto]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@xMapeo", xmlMapeo)
                Cmd.Parameters.AddWithValue("@NroFamilia", IIf(NroFamilia <= 0, DBNull.Value, NroFamilia))

                If Cmd.Connection.State = ConnectionState.Closed Then
                    Cmd.Connection.Open()
                End If

                dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dr.Read()
                Retorno = TSQL.CodigoRetorno(dr.GetString(0), Advertencia)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Retorno = False
            Finally
                If Not IsNothing(dr) Then
                    dr.Close()
                End If
                dr = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno
        End Function

        Public Function fdu_VerProductosMapeados(ByVal NroFamilia As Integer, ByVal Todo As Boolean) As DataTable
            Dim Dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_VerProductosMapeados]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@NroFamilia", IIf(NroFamilia <= 0, DBNull.Value, NroFamilia))
                Cmd.Parameters.AddWithValue("@Todo", Todo)

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(Dt)

                If Dt Is Nothing OrElse Dt.Rows.Count = 0 Then
                    Advertencia = "No hay Productos mapeados a esta Familia."
                End If

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Dt = Nothing
            Finally
                Da = Nothing
                Cmd = Nothing
            End Try

            Return Dt
        End Function

        Public Function fdu_VerProdMapeados_Pag(ByVal NroFamilia As Integer, ByVal Desde As Integer, _
                                                ByVal Hasta As Integer) As DataTable
            Dim Dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_VerProdMapeados_Pag]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@NroFamilia", IIf(NroFamilia <= 0, DBNull.Value, NroFamilia))
                Cmd.Parameters.AddWithValue("@Desde", Desde)
                Cmd.Parameters.AddWithValue("@Hasta", Hasta)

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(Dt)

                If Dt Is Nothing OrElse Dt.Rows.Count = 0 Then
                    Advertencia = "No hay Productos mapeados a esta Familia."
                End If

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Dt = Nothing
            Finally
                Da = Nothing
                Cmd = Nothing
            End Try

            Return Dt
        End Function

        Public Function fdu_LlenarFrmMaestroFamiliaProductos() As DataTable

            Dim tabla As New DataTable
            Dim Cmd As New SqlCommand

            Dim Da As SqlDataAdapter
            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_FrmMaestroFamiliaProductos]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(tabla)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                tabla = Nothing
            Finally
                Da = Nothing
                Cmd = Nothing
            End Try

            Return tabla
        End Function

        Public Function fdu_ListarSubAlmacenXEmp(ByVal CodEmp As String) As DataTable
            Dim Dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_ListarSubAlmacenXEmp]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@CodEmp", CodEmp)
                Da = New SqlDataAdapter(Cmd)
                Da.Fill(Dt)
            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                Dt = Nothing
            Finally
                Da = Nothing
                Cmd = Nothing
            End Try

            Return Dt
        End Function

        Public Function fdu_NuevaFamiliaProducto(ByVal Descripcion As String, ByVal CCC As String, ByVal CCI2 As String, ByVal CCI6 As String, _
                                        ByVal CCS2 As String, ByVal CCS6 As String, ByVal CCD9 As String, ByVal CCD7 As String, _
                                        ByVal CodSubAlm As String, ByVal CodEmp As String, ByVal xGrupos As String) As Boolean
            Dim Cmd As New SqlCommand
            'Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_NuevaFamiliaProducto]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@Descripcion", Descripcion)
                Cmd.Parameters.AddWithValue("@CCC", IIf(CCC.Trim.Length = 0, DBNull.Value, CCC))
                Cmd.Parameters.AddWithValue("@CCI2", IIf(CCI2.Trim.Length = 0, DBNull.Value, CCI2))
                Cmd.Parameters.AddWithValue("@CCI6", IIf(CCI6.Trim.Length = 0, DBNull.Value, CCI6))
                Cmd.Parameters.AddWithValue("@CCS2", IIf(CCS2.Trim.Length = 0, DBNull.Value, CCS2))
                Cmd.Parameters.AddWithValue("@CCS6", IIf(CCS6.Trim.Length = 0, DBNull.Value, CCS6))
                Cmd.Parameters.AddWithValue("@CCD9", IIf(CCD9.Trim.Length = 0, DBNull.Value, CCD9))
                Cmd.Parameters.AddWithValue("@CCD7", IIf(CCD7.Trim.Length = 0, DBNull.Value, CCD7))
                Cmd.Parameters.AddWithValue("@CodSubAlm", CodSubAlm)
                Cmd.Parameters.AddWithValue("@CodEmp", CodEmp)
                Cmd.Parameters.AddWithValue("@xGrupos", xGrupos)

                'Cmd.Parameters.AddWithValue("@nroFamilia", 0)
                'Cmd.Parameters("@nroFamilia").Direction = ParameterDirection.Output
                If Cmd.Connection.State = ConnectionState.Closed Then
                    Cmd.Connection.Open()
                End If

                Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()
                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Retorno = False
            Finally
                If Not IsNothing(Dr) Then
                    Dr.Close()
                End If
                'nroFamilia = Cmd.Parameters("@nroFamilia").Value
                Dr = Nothing
                ' Prm = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno
        End Function

        Public Function fdu_ModificarFamiliaProducto(ByVal NroFamilia As Integer, ByVal Descripcion As String, ByVal CCC As String, _
                                                    ByVal CCI2 As String, ByVal CCI6 As String, _
                                                    ByVal CCS2 As String, ByVal CCS6 As String, _
                                                    ByVal CCD9 As String, ByVal CCD7 As String, ByVal xGrupos As String) As Boolean
            Dim Cmd As New SqlCommand
            'Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_ModificarFamiliaProducto]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@NroFamilia", NroFamilia)
                Cmd.Parameters.AddWithValue("@descripcion", Descripcion)
                Cmd.Parameters.AddWithValue("@CCC", IIf(CCC.Trim.Length = 0, DBNull.Value, CCC))
                Cmd.Parameters.AddWithValue("@CCI2", IIf(CCI2.Trim.Length = 0, DBNull.Value, CCI2))
                Cmd.Parameters.AddWithValue("@CCI6", IIf(CCI6.Trim.Length = 0, DBNull.Value, CCI6))
                Cmd.Parameters.AddWithValue("@CCS2", IIf(CCS2.Trim.Length = 0, DBNull.Value, CCS2))
                Cmd.Parameters.AddWithValue("@CCS6", IIf(CCS6.Trim.Length = 0, DBNull.Value, CCS6))
                Cmd.Parameters.AddWithValue("@CCD9", IIf(CCD9.Trim.Length = 0, DBNull.Value, CCD9))
                Cmd.Parameters.AddWithValue("@CCD7", IIf(CCD7.Trim.Length = 0, DBNull.Value, CCD7))
                Cmd.Parameters.AddWithValue("@xGrupos", xGrupos)

                If Cmd.Connection.State = ConnectionState.Closed Then
                    Cmd.Connection.Open()
                End If
                Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()
                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Retorno = False
            Finally
                If Not IsNothing(Dr) Then
                    Dr.Close()
                End If
                Dr = Nothing
                'Prm = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno

        End Function

        Public Function fdu_BuscarFamiliaProducto(ByVal Desc As String) As DataTable
            Dim Dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_BuscarFamiliaProducto]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@desc", IIf(Desc.Trim.Length = 0, DBNull.Value, Desc))

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(Dt)

                If Dt Is Nothing OrElse Dt.Rows.Count = 0 Then
                    Advertencia = "No hay 'Familia de Producto' para mostrar"
                End If

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Dt = Nothing
            Finally
                Da = Nothing
                Cmd = Nothing
            End Try

            Return Dt
        End Function

        Public Function fdu_VerFamiliaDeProducto(ByVal NroProd As Integer) As DataTable
            Dim Dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_VerFamiliaDeProducto]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@NroProducto", IIf(NroProd <= 0, DBNull.Value, NroProd))

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(Dt)

                If Dt Is Nothing OrElse Dt.Rows.Count = 0 Then
                    Advertencia = "No hay datos para este producto."
                End If

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Dt = Nothing
            Finally
                Da = Nothing
                Cmd = Nothing
            End Try

            Return Dt
        End Function

        Public Function fdu_EliminarFamiliaProducto(ByVal nroFamilia As Integer) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_EliminarFamiliaProducto]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@nroFamilia", nroFamilia)
                Cmd.Parameters.Add(Prm)

                If Cmd.Connection.State = ConnectionState.Closed Then
                    Cmd.Connection.Open()
                End If

                dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dr.Read()
                Retorno = TSQL.CodigoRetorno(dr.GetString(0), Advertencia)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Retorno = False
            Finally
                If Not IsNothing(dr) Then
                    dr.Close()
                End If
                dr = Nothing
                Prm = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno
        End Function


        Public Function fdu_BuscarPlanContable(ByVal CodEmp As String, ByVal CodCuenta As String, ByVal Desc As String) As DataTable
            Dim Dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_BuscarPlanContable]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@CodEmp", CodEmp)
                Cmd.Parameters.AddWithValue("@CodCuenta", IIf(CodCuenta.Trim.Length = 0, DBNull.Value, CodCuenta))
                Cmd.Parameters.AddWithValue("@desc", IIf(Desc.Trim.Length = 0, DBNull.Value, Desc))

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(Dt)

                If Dt Is Nothing OrElse Dt.Rows.Count = 0 Then
                    Advertencia = "No hay Plan Contable para mostrar."
                End If

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Dt = Nothing
            Finally
                Da = Nothing
                Cmd = Nothing
            End Try

            Return Dt

        End Function

        Public Function fdu_EliminarGrupoProducto(ByVal nroFamilia As Integer, ByVal nroGrupo As Integer) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_EliminarGrupoProducto]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@NroFamilia", nroFamilia)
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@nroGrupo", nroGrupo)
                Cmd.Parameters.Add(Prm)

                If Cmd.Connection.State = ConnectionState.Closed Then
                    Cmd.Connection.Open()
                End If

                dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dr.Read()
                Retorno = TSQL.CodigoRetorno(dr.GetString(0), Advertencia)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Retorno = False
            Finally
                If Not IsNothing(dr) Then
                    dr.Close()
                End If
                dr = Nothing
                Prm = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno
        End Function

        Public Function fdu_RestaurarGrupoProducto(ByVal nroFamilia As Integer, ByVal xGrupos As String) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_RestaurarGrupoProducto]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@NroFamilia", nroFamilia)
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@xGrupos", xGrupos)
                Cmd.Parameters.Add(Prm)

                If Cmd.Connection.State = ConnectionState.Closed Then
                    Cmd.Connection.Open()
                End If

                dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dr.Read()
                Retorno = TSQL.CodigoRetorno(dr.GetString(0), Advertencia)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Retorno = False
            Finally
                If Not IsNothing(dr) Then
                    dr.Close()
                End If
                dr = Nothing
                Prm = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno
        End Function

        Public Function fdu_BuscarProdNeumaticos(ByVal NroProducto As Integer) As DataTable
            Dim Dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_BuscarProdNeumaticos] "
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@NroProducto", IIf(NroProducto <= 0, DBNull.Value, NroProducto))

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(Dt)

                If Dt Is Nothing OrElse Dt.Rows.Count = 0 Then
                    Advertencia = "No hay 'Neumático' para mostrar"
                End If

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Dt = Nothing
            Finally
                Da = Nothing
                Cmd = Nothing
            End Try

            Return Dt
        End Function

        Public Function fdu_AgregarProductoMapeo(ByVal nroGrupo As Integer, ByVal nroProducto As Integer, _
                                                ByVal nroFamilia As Integer, ByVal IDModelo As Integer, _
                                                ByVal IDMedida As Integer) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_AgregarProductoMapeo]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@NroGrupo", nroGrupo)
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@NroProducto", nroProducto)
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@NroFamilia", nroFamilia)
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@IDModelo", IIf(IDModelo <= 0, DBNull.Value, IDModelo))
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@IDMedida", IIf(IDMedida <= 0, DBNull.Value, IDMedida))
                Cmd.Parameters.Add(Prm)

                If Cmd.Connection.State = ConnectionState.Closed Then
                    Cmd.Connection.Open()
                End If

                dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dr.Read()
                Retorno = TSQL.CodigoRetorno(dr.GetString(0), Advertencia)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Retorno = False
            Finally
                If Not IsNothing(dr) Then
                    dr.Close()
                End If
                dr = Nothing
                Prm = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno
        End Function

        Public Function fdu_QuitarProductoMapeo(ByVal nroGrupo As Integer, ByVal nroProducto As Integer) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_QuitarProductoMapeo]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@NroGrupo", nroGrupo)
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@NroProducto", nroProducto)
                Cmd.Parameters.Add(Prm)

                If Cmd.Connection.State = ConnectionState.Closed Then
                    Cmd.Connection.Open()
                End If

                dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dr.Read()
                Retorno = TSQL.CodigoRetorno(dr.GetString(0), Advertencia)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Retorno = False
            Finally
                If Not IsNothing(dr) Then
                    dr.Close()
                End If
                dr = Nothing
                Prm = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno
        End Function


        Public Function fdu_NuevoModeloNeum(ByVal Modelo As String, ByVal IDMarca As Integer) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_NuevoModeloNeum]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@Modelo", Modelo)
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@IDMarca", IIf(IDMarca <= 0, DBNull.Value, IDMarca))
                Cmd.Parameters.Add(Prm)

                If Cmd.Connection.State = ConnectionState.Closed Then
                    Cmd.Connection.Open()
                End If

                Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()
                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Retorno = False
            Finally
                If Not IsNothing(Dr) Then
                    Dr.Close()
                End If
                Dr = Nothing
                Prm = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno
        End Function

        Public Function fdu_ModificarModeloNeum(ByVal IDModelo As Integer, ByVal Modelo As String, ByVal IDMarca As Integer) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_ModificarModeloNeum]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@IDModelo", IDModelo)
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@Modelo", Modelo)
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@IDMarca", IIf(IDMarca <= 0, DBNull.Value, IDMarca))
                Cmd.Parameters.Add(Prm)

                If Cmd.Connection.State = ConnectionState.Closed Then
                    Cmd.Connection.Open()
                End If
                Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()
                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Retorno = False
            Finally
                If Not IsNothing(Dr) Then
                    Dr.Close()
                End If
                Dr = Nothing
                Prm = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno
        End Function

        Public Function fdu_EliminarModeloNeum(ByVal IDModelo As Integer) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_EliminarModeloNeum]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@IDModelo", IDModelo)
                Cmd.Parameters.Add(Prm)

                If Cmd.Connection.State = ConnectionState.Closed Then
                    Cmd.Connection.Open()
                End If

                dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dr.Read()
                Retorno = TSQL.CodigoRetorno(dr.GetString(0), Advertencia)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Retorno = False
            Finally
                If Not IsNothing(dr) Then
                    dr.Close()
                End If
                dr = Nothing
                Prm = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno
        End Function

        Public Function fdu_BuscarModeloNeum(ByVal Desc As String) As DataTable
            Dim Dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_BuscarModeloNeum]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@desc", IIf(Desc.Trim.Length = 0, DBNull.Value, Desc))

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(Dt)

                If Dt Is Nothing OrElse Dt.Rows.Count = 0 Then
                    Advertencia = "No hay 'Modelos de Neumático' para mostrar"
                End If

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Dt = Nothing
            Finally
                Da = Nothing
                Cmd = Nothing
            End Try

            Return Dt
        End Function


        Public Function fdu_NuevaMedidaNeum(ByVal Medida As String) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_NuevaMedidaNeum]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@Medida", Medida)
                Cmd.Parameters.Add(Prm)

                If Cmd.Connection.State = ConnectionState.Closed Then
                    Cmd.Connection.Open()
                End If

                Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()
                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Retorno = False
            Finally
                If Not IsNothing(Dr) Then
                    Dr.Close()
                End If
                Dr = Nothing
                Prm = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno
        End Function

        Public Function fdu_ModificarMedidaNeum(ByVal IDMedida As Integer, ByVal Medida As String) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_ModificarMedidaNeum]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@IDMedida", IDMedida)
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@Medida", Medida)
                Cmd.Parameters.Add(Prm)

                If Cmd.Connection.State = ConnectionState.Closed Then
                    Cmd.Connection.Open()
                End If
                Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()
                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Retorno = False
            Finally
                If Not IsNothing(Dr) Then
                    Dr.Close()
                End If
                Dr = Nothing
                Prm = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno
        End Function

        Public Function fdu_EliminarMedidaNeum(ByVal IDMedida As Integer) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_EliminarMedidaNeum]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@IDMedida", IDMedida)
                Cmd.Parameters.Add(Prm)

                If Cmd.Connection.State = ConnectionState.Closed Then
                    Cmd.Connection.Open()
                End If

                dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dr.Read()
                Retorno = TSQL.CodigoRetorno(dr.GetString(0), Advertencia)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Retorno = False
            Finally
                If Not IsNothing(dr) Then
                    dr.Close()
                End If
                dr = Nothing
                Prm = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno
        End Function

        Public Function fdu_BuscarMedidaNeum(ByVal Desc As String) As DataTable
            Dim Dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_BuscarMedidaNeum]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@desc", IIf(Desc.Trim.Length = 0, DBNull.Value, Desc))

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(Dt)

                If Dt Is Nothing OrElse Dt.Rows.Count = 0 Then
                    Advertencia = "No hay 'Medidas de Neumático' para mostrar"
                End If

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Dt = Nothing
            Finally
                Da = Nothing
                Cmd = Nothing
            End Try

            Return Dt
        End Function


        Public Function fdu_NuevaPropiedad(ByVal IDModelo As Integer, ByVal IDMedida As Integer, _
                                               ByVal Lonas As Integer, ByVal Cocada As Decimal) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_NuevaPropiedad]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@IDModelo", IDModelo)
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@IDMedida", IDMedida)
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@Lonas", Lonas)
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@Cocada", Cocada)
                Cmd.Parameters.Add(Prm)

                If Cmd.Connection.State = ConnectionState.Closed Then
                    Cmd.Connection.Open()
                End If

                Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()
                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Retorno = False
            Finally
                If Not IsNothing(Dr) Then
                    Dr.Close()
                End If
                Dr = Nothing
                Prm = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno
        End Function

        Public Function fdu_ModificarPropiedad(ByVal IDModelo As Integer, ByVal IDMedida As Integer, _
                                               ByVal Lonas As Integer, ByVal Cocada As Decimal) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_ModificarPropiedad]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@IDModelo", IDModelo)
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@IDMedida", IDMedida)
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@Lonas", Lonas)
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@Cocada", Cocada)
                Cmd.Parameters.Add(Prm)

                If Cmd.Connection.State = ConnectionState.Closed Then
                    Cmd.Connection.Open()
                End If
                Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()
                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Retorno = False
            Finally
                If Not IsNothing(Dr) Then
                    Dr.Close()
                End If
                Dr = Nothing
                Prm = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno
        End Function

        Public Function fdu_EliminarPropiedad(ByVal IDModelo As Integer, ByVal IDMedida As Integer) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_EliminarPropiedad]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@IDModelo", IDModelo)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@IDMedida", IDMedida)
                Cmd.Parameters.Add(Prm)

                If Cmd.Connection.State = ConnectionState.Closed Then
                    Cmd.Connection.Open()
                End If

                dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dr.Read()
                Retorno = TSQL.CodigoRetorno(dr.GetString(0), Advertencia)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Retorno = False
            Finally
                If Not IsNothing(dr) Then
                    dr.Close()
                End If
                dr = Nothing
                Prm = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno
        End Function

        Public Function fdu_BuscarPropiedad() As DataTable
            Dim Dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_BuscarPropiedad]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(Dt)

                If Dt Is Nothing OrElse Dt.Rows.Count = 0 Then
                    Advertencia = "No hay 'Propiedades' para mostrar"
                End If

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Dt = Nothing
            Finally
                Da = Nothing
                Cmd = Nothing
            End Try

            Return Dt
        End Function


        Public Function fdu_BuscarAlmacenes(Optional ByVal user As String = "", _
                                                   Optional ByVal sucursal As Integer = -1, Optional ByVal nivel As String = "") As DataTable

            Dim Dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_BuscarAlmacenes]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@User", IIf(user.Trim.Length = 0, DBNull.Value, user))
                Cmd.Parameters.AddWithValue("@Sucursal", IIf(sucursal = -1, DBNull.Value, sucursal))
                Cmd.Parameters.AddWithValue("@Nivel", IIf(nivel.Trim.Length = 0, DBNull.Value, nivel))

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(Dt)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Dt = Nothing
            Finally
                Da = Nothing
                Cmd = Nothing
            End Try

            Return Dt



        End Function


#End Region


#Region "Producto Stocks Min y Max de Inventario"
        Public Function fdu_StkInventarioBuscar(ByVal codAlmacen As String, Optional ByVal Descripcion As String = "") As DataTable
            Dim Dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_StkInventarioBuscar]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@CodAlmacen", codAlmacen)
                Cmd.Parameters.AddWithValue("@Q", Descripcion)

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(Dt)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Dt = Nothing
            Finally
                Da = Nothing
                Cmd = Nothing
            End Try

            Return Dt
        End Function

        Public Function fdu_StkInventarioActualiza(ByVal codAlmacen As String, ByVal nroProducto As Integer, Optional ByVal stockMin As Double = 0, Optional ByVal stockMax As Double = 0) As Boolean
            Dim Retorno As Boolean = True
            Dim Cmd As New SqlCommand
            Dim Dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_StkInventarioActualiza]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure


                Cmd.Parameters.AddWithValue("@CodAlmacen", codAlmacen)
                Cmd.Parameters.AddWithValue("@NroProducto", nroProducto)
                Cmd.Parameters.AddWithValue("@StockMin", stockMin)
                Cmd.Parameters.AddWithValue("@StockMax", stockMax)

                Dr = Cmd.ExecuteReader()
                Dr.Read()

                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Retorno = False
            Finally
                If Not Dr Is Nothing Then
                    Dr.Close()
                End If
                Dr = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno
        End Function
#End Region

    End Class

End Namespace
