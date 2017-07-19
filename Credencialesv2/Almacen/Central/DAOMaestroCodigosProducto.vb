
Imports System.Data.SqlClient
Imports GEACEntidades.Almacen
Imports GEACEntidades
Imports PoolConexiones

Namespace DAOAlmacen

    Public Class DAOMaestroCodigosProducto
        Private Advertencia As String = String.Empty

#Region "Carga de Datos"

        Public Function LlenarFormCodigosProducto() As DataTable

            Dim tabla As New DataTable
            Dim Cmd As New SqlCommand

            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_LlenarFormCodigosProducto]"
            Try

                Cmd.CommandText = StrComando
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Codigos Producto")
                tabla = Nothing
            Finally

                Da = Nothing
                Cmd = Nothing
                StrComando = String.Empty


            End Try

            Return tabla
        End Function

        Public Function CargarMaestroCodigosProducto(ByVal IDTipoProducto As Integer) As DataTable
            Dim tabla As New DataTable
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MaestroCodigoProducto]"
            Try

                Cmd.CommandText = StrComando
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@idtipoproducto", IIf(IDTipoProducto <= 0, DBNull.Value, IDTipoProducto))
                Cmd.Parameters.Add(Prm)

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Códigos Producto")
                tabla = Nothing
            Finally
                'Dr.Close()
                Da = Nothing
                Cmd = Nothing
                Prm = Nothing
                StrComando = String.Empty
            End Try

            Return tabla

        End Function

#End Region


#Region "Mantenimiento Codigos Producto"

        Public Function NuevoCodigoProducto(ByVal OCodigoProducto As CodigosProducto) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            With OCodigoProducto
                Try
                    Cmd.CommandText = "Almacen.SpAlm_NuevoCodigoProducto"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure

                    Prm = New SqlParameter("@codproducto", .CodProducto)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@descripcion", .Descripcion)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@idtipoproducto", IIf(.IDTipoProducto <= 0, DBNull.Value, .IDTipoProducto))
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@idmarca", IIf(.IDMarca <= 0, DBNull.Value, .IDMarca))
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@procedencia", IIf(.Procedencia = String.Empty, DBNull.Value, .Procedencia))
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@secodifica", .SeCodifica)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@observaciones", IIf(.Observaciones = String.Empty, DBNull.Value, .Observaciones))
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@idpresentacion", .IDPresentacion)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@capacidad", .Capacidad)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@idfraccion", IIf(.IDFraccion <= 0, DBNull.Value, .IDFraccion))
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@habilitado", .Habilitado)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@nrofamilia", IIf(.NroFamilia <= 0, DBNull.Value, .NroFamilia))
                    Cmd.Parameters.Add(Prm)


                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If


                    Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Codigos Producto")
                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Codigos Producto")
                    End If
                Catch ex As Exception
                    MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                    Retorno = False
                Finally
                    If Not IsNothing(Dr) Then
                        Dr.Close() ' al cerrar el datareader tambien cierra el comando asociado
                    End If

                    Dr = Nothing
                    Prm = Nothing
                    Cmd.Dispose()
                    Cmd = Nothing
                End Try

                Return Retorno

            End With

        End Function


        Public Function ModificarCodigoProducto(ByVal OCodigoProducto As CodigosProducto) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            With OCodigoProducto
                Try
                    Cmd.CommandText = "[Almacen].[SpAlm_ModificarCodigoProducto]"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure

                    Prm = New SqlParameter("@codproducto", .CodProducto)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@descripcion", .Descripcion)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@idtipoproducto", IIf(.IDTipoProducto <= 0, DBNull.Value, .IDTipoProducto))
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@idmarca", IIf(.IDMarca <= 0, DBNull.Value, .IDMarca))
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@procedencia", IIf(.Procedencia = String.Empty, DBNull.Value, .Procedencia))
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@secodifica", .SeCodifica)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@observaciones", IIf(.Observaciones = String.Empty, DBNull.Value, .Observaciones))
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@habilitado", .Habilitado)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@nrofamilia", IIf(.NroFamilia <= 0, DBNull.Value, .NroFamilia))
                    Cmd.Parameters.Add(Prm)


                    'Prm = New SqlParameter("@idpresentacion", .IDPresentacion)
                    'Cmd.Parameters.Add(Prm)

                    'Prm = New SqlParameter("@capacidad", .Capacidad)
                    'Cmd.Parameters.Add(Prm)

                    'Prm = New SqlParameter("@idfraccion", .IDFraccion)
                    'Cmd.Parameters.Add(Prm)


                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If



                    Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Codigos Producto")

                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Codigos Producto")

                    End If

                Catch ex As Exception
                    MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                    Retorno = False
                Finally

                    If Not IsNothing(Dr) Then
                        Dr.Close() ' al cerrar el datareader tambien cierra el comando asociado
                    End If

                    Dr = Nothing
                    Prm = Nothing
                    Cmd.Dispose()
                    Cmd = Nothing
                End Try

                Return Retorno

            End With

        End Function

        Public Function EliminarCodigoProducto(ByVal oCodigoProducto As CodigosProducto) As Boolean
            Dim valor As Boolean = True

            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Lector As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EliminarCodigoProducto]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@CodProducto", oCodigoProducto.CodProducto)
                Cmd.Parameters.Add(Prm)

                If Cmd.Connection.State = ConnectionState.Closed Then
                    Cmd.Connection.Open()
                End If


                Lector = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Lector.Read()
                Retorno = TSQL.CodigoRetorno(Lector.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Códigos Producto")
                Else
                    MsgBox(Advertencia, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Códigos Producto")

                End If

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                Retorno = False
            Finally

                If Not IsNothing(Lector) Then
                    Lector.Close() ' al cerrar el datareader tambien cierra el comando asociado
                End If
                Lector = Nothing
                Prm = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno


        End Function


#End Region

#Region "INVENTARIO INICIAL"
        Public Function udfVerProductoConAlmacenes(ByVal pEstado As Byte, ByVal pPageSize As Integer, ByVal pPageNumber As Integer, ByRef pTotalPages As Integer, ByVal pNombreProducto As String) As DataTable
            Dim tabla As New DataTable
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_PA_VerProductoConAlmacenes]"
            Try

                Cmd.CommandText = StrComando
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@IDLocal", GEACEntidades.SesionUsuario.IDSucursal)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@wEstado", pEstado)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@PageSize", pPageSize)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@PageNumber", pPageNumber)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@TotalPages", SqlDbType.Int)
                Prm.Direction = ParameterDirection.Output
                Cmd.Parameters.Add(Prm)

                If pNombreProducto.Length > 0 Then
                    Prm = New SqlParameter("@NombreProducto", pNombreProducto)
                    Cmd.Parameters.Add(Prm)
                End If

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(tabla)

                pTotalPages = Cmd.Parameters("@TotalPages").Value

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Producto con Almacenes")
                tabla = Nothing
            Finally
                'Dr.Close()
                Da = Nothing
                Cmd = Nothing
                Prm = Nothing
                StrComando = String.Empty
            End Try

            Return tabla

        End Function


        Public Function udfVerProductosPorAlmacen(ByVal pCodAlmacen As String, ByVal pXML_TipoProd As String, ByVal pEstado As Byte, ByVal pPageSize As Integer, ByVal pPageNumber As Integer, ByRef pTotalPages As Integer, ByVal pNombreProducto As String) As DataTable
            Dim tabla As New DataTable
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_PA_VerProductosPorAlmacen]"
            Try
                Cmd.CommandText = StrComando
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@CodAlmacen", pCodAlmacen)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@xmlIDTipoProducto", pXML_TipoProd)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@wEstado", pEstado)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@PageSize", pPageSize)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@PageNumber", pPageNumber)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@TotalPages", SqlDbType.Int)
                Prm.Direction = ParameterDirection.Output
                Cmd.Parameters.Add(Prm)

                If pNombreProducto.Length > 0 Then
                    Prm = New SqlParameter("@NombreProducto", pNombreProducto)
                    Cmd.Parameters.Add(Prm)
                End If

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(tabla)

                pTotalPages = Cmd.Parameters("@TotalPages").Value

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Productos por Almacén")
                tabla = Nothing
            Finally
                'Dr.Close()
                Da = Nothing
                Cmd = Nothing
                Prm = Nothing
                StrComando = String.Empty
            End Try

            Return tabla

        End Function

        Public Function udfVerInventarioProducto(ByVal pCodAlmacen As String, ByVal pCodProducto As String, ByRef pTieneMovis As Boolean) As DataTable
            Dim tabla As New DataTable
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Da As SqlDataAdapter
            'oConexion = New SqlConnection()
            'oConexion.ConnectionString = strConexion

            Try
                Cmd.CommandText = "Almacen.SpAlm_PA_VerInventarioProducto"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@CodAlmacen", pCodAlmacen)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@CodProducto", pCodProducto)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@wTieneMovis", SqlDbType.Bit)
                Prm.Direction = ParameterDirection.Output
                Cmd.Parameters.Add(Prm)

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(tabla)

                pTieneMovis = Cmd.Parameters("@wTieneMovis").Value

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Inventario de Producto")
                tabla = Nothing
            Finally
                Da = Nothing
                Cmd = Nothing
                'StrComando = String.Empty
            End Try

            Return tabla
        End Function

        Public Function udfActualizaInvInicial(ByVal pCodAlmacen As String, ByVal pCodProducto As String, ByVal pFInicio As DateTime, ByVal pCantInicial As Integer, ByVal pFracInicial As Single, ByVal pComentario As String) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "Almacen.SpAlm_PA_ActualizaInvInicial"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@CodAlmacen", pCodAlmacen)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@CodProducto", pCodProducto)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@FInicio", pFInicio)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@CantInicial", pCantInicial)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@FracInicial", pFracInicial)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@Comentario", pComentario)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@IDPersona", SesionUsuario.IDPersona)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@Usuario", SesionUsuario.Usuario)
                Cmd.Parameters.Add(Prm)

                If Cmd.Connection.State = ConnectionState.Closed Then
                    Cmd.Connection.Open()
                End If

                Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()

                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Atualiza Inventario de Producto")
                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Atualiza Inventario de Producto")
                End If
            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                Retorno = False
            Finally
                If Not IsNothing(Dr) Then
                    Dr.Close() ' al cerrar el datareader tambien cierra el comando asociado
                End If

                Dr = Nothing
                Prm = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try
            Return Retorno
        End Function

#End Region

    End Class

End Namespace


