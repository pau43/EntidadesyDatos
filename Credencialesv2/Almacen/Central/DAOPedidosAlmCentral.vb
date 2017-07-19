Imports System.Data.SqlClient
Imports GEACEntidades.Almacen
Imports GEACEntidades.Almacen.PedidosAlmCentral
Imports PoolConexiones

Namespace DAOAlmacen

    Public Class DAOPedidosAlmCentral
        Private Advertencia As String = String.Empty

        Public Function MostrarListadoPedidos(ByVal pAñoPedido As Short, ByVal pEstadoPedido As Byte, ByVal pPageSize As Integer, ByVal pPageNumber As Integer, ByRef pTotalPages As Integer) As DataTable
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Da As SqlDataAdapter

            Dim dt As New DataTable
            Try
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.CommandText = "TRC.Almacen.SpAlm_PE_ListarPedidos"

                Prm = New SqlParameter("@EstadoPedido", pEstadoPedido)
                Cmd.Parameters.Add(Prm)
                'Prm = New SqlParameter("@IDSucursal", GEACEntidades.SesionUsuario.CodEmpresa)
                'Prm = New SqlParameter("@CodEmpresa", "01") 'GEACEntidades.SesionUsuario.CodigoEmpresa)
                'Cmd.Parameters.Add(Prm)
                'Prm = New SqlParameter("@IDSucursal", GEACEntidades.SesionUsuario.IDLocal)
                Prm = New SqlParameter("@IDLocalPedido", GEACEntidades.SesionUsuario.IDSucursal)
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@AnioPedido", pAñoPedido)
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@PageSize", pPageSize)
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@PageNumber", pPageNumber)
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@TotalPages", pTotalPages)
                Prm.Direction = ParameterDirection.Output
                Cmd.Parameters.Add(Prm)

                Cmd.Connection = TSQL.ConexionPermanente

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(dt)
                pTotalPages = Cmd.Parameters("@TotalPages").Value

                If dt Is Nothing Then
                    MsgBox(TSQL.UltimoMensaje, MsgBoxStyle.Critical) 'MaestroGeac)
                End If

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical) ', MaestroGeac )
                dt = Nothing
            End Try

            Return dt

        End Function

        Public Function NuevoPedidoAlmCentral(ByVal oPedidoAlmCentral As PedidosAlmCentral) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing
            'oConexion = New SqlConnection()
            'oConexion.ConnectionString = strConexion
            With oPedidoAlmCentral

                Try
                    '[SpAlm_NuevoPedidoAlmCentral]
                    Cmd.CommandText = "Almacen.SpAlm_PE_CrearPedido"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure

                    Prm = New SqlParameter("@IDLocalPedido", .IDPedido.IDLocalPedido)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@FechaPedido", .FechaPedido)
                    Cmd.Parameters.Add(Prm)

                    'Prm = New SqlParameter("@CodEmpresa", .CodEmpresa)
                    'Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@IDAreaPedido", .IDAreaPedido)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@IdSolicitante", .IDSolicitante)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@Observacion", IIf(.Observacion.Trim.Length = 0, DBNull.Value, .Observacion.Trim))
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@CodAlmAtiende", .CodAlmAtiende)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@xDtllePedido", .XMLListaProductos.Trim)
                    Cmd.Parameters.Add(Prm)

                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If

                    Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)

                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Nuevo Ingreso De Pedido")
                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Nuevo Ingreso De Pedido")
                    End If

                Catch ex As Exception
                    MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
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

        Public Function ModificaPedidoAlmCentral(ByVal oPedidoAlmCentral As PedidosAlmCentral, ByVal pGrabaDetalle As Boolean) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing
            'oConexion = New SqlConnection()
            'oConexion.ConnectionString = strConexion
            With oPedidoAlmCentral

                Try
                    '[SpAlm_NuevoPedidoAlmCentral]
                    Cmd.CommandText = "Almacen.SpAlm_PE_ModificarPedido"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure

                    Prm = New SqlParameter("@IDLocalPedido", .IDPedido.IDLocalPedido)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@FechaPedido", .FechaPedido)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@NroPedido", .IDPedido.NroPedido)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@IDAreaPedido", .IDAreaPedido)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@IdSolicitante", .IDSolicitante)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@Observacion", IIf(.Observacion.Trim.Length = 0, DBNull.Value, .Observacion.Trim))
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@CodAlmAtiende", .CodAlmAtiende)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@xDtllePedido", .XMLListaProductos.Trim)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@wGrabarDetalle", pGrabaDetalle)
                    Cmd.Parameters.Add(Prm)

                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If

                    Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)

                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Nuevo Ingreso De Pedido")
                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Nuevo Ingreso De Pedido")
                    End If

                Catch ex As Exception
                    MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
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


        Public Function ConsultaDetallePedido(ByVal pPKPedidos As PKPedidos) As DataTable
            'Dim Cmd As New SqlCommand
            'Dim Prm As SqlParameter
            'Dim Retorno As Boolean
            'Dim Dr As SqlDataReader = nothing
            Dim tabla As New DataTable
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Da As SqlDataAdapter
            'oConexion = New SqlConnection()
            'oConexion.ConnectionString = strConexion

            With pPKPedidos

                Try

                    Cmd.CommandText = "Almacen.SpAlm_PE_VerDetallePedido"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure

                    Prm = New SqlParameter("@IDLocalPedido", .IDLocalPedido)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@AnioPedido", .AnioPedido)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@NroPedido", .NroPedido)
                    Cmd.Parameters.Add(Prm)

                    Da = New SqlDataAdapter(Cmd)
                    Da.Fill(tabla)

                Catch ex As Exception
                    MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Equipamiento Estibas")
                    tabla = Nothing
                Finally
                    Da = Nothing
                    Cmd = Nothing
                    'StrComando = String.Empty
                End Try

                Return tabla
            End With
        End Function




        Public Function AnulaPedidoAlmCentral(ByVal pPKPedidos As PKPedidos, ByVal pMotivoAnulacion As String) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing
            'oConexion = New SqlConnection()
            'oConexion.ConnectionString = strConexion

            With pPKPedidos

                Try

                    Cmd.CommandText = "Almacen.SpAlm_PE_AnularPedido"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure

                    Prm = New SqlParameter("@IDLocalPedido", .IDLocalPedido)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@AnioPedido", .AnioPedido)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@NroPedido", .NroPedido)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@MotivoAnulacion", pMotivoAnulacion)
                    Cmd.Parameters.Add(Prm)

                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If

                    Dr = Cmd.ExecuteReader()

                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Nuevo Ingreso De Pedido")
                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Nuevo Ingreso De Pedido")
                    End If

                Catch ex As Exception
                    MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
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

        Public Function AutorizaPedidoAlmCentral(ByVal pPKPedidos As PKPedidos, ByVal pIDAutorizadoPor As Integer) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing
            'oConexion = New SqlConnection()
            'oConexion.ConnectionString = strConexion

            With pPKPedidos

                Try

                    Cmd.CommandText = "Almacen.SpAlm_PE_AutorizarPedido"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure

                    Prm = New SqlParameter("@IDLocalPedido", .IDLocalPedido)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@AnioPedido", .AnioPedido)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@NroPedido", .NroPedido)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@IDAutorizadoPor", pIDAutorizadoPor)
                    Cmd.Parameters.Add(Prm)

                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If

                    Dr = Cmd.ExecuteReader()

                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Nuevo Ingreso De Pedido")
                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Nuevo Ingreso De Pedido")
                    End If

                Catch ex As Exception
                    MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
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

        Public Function udfRPT_PedidosAlmacen(ByVal pIDLocalPedido As Integer, ByVal pFechaIni As Date, ByVal pFechaFin As Date) As DataTable
            Dim tabla As New DataTable
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Da As SqlDataAdapter
            'oConexion = New SqlConnection()
            'oConexion.ConnectionString = strConexion

            Try
                Cmd.CommandText = "Almacen.SpAlm_PE_Rpt_PedidosAlmacen"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@IDLocalPedido", pIDLocalPedido)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@FechaIni", pFechaIni)
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@FechaFin", pFechaFin)
                Cmd.Parameters.Add(Prm)

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Pedidos de Almacén")
                tabla = Nothing
            Finally
                Da = Nothing
                Cmd = Nothing
                'StrComando = String.Empty
            End Try

            Return tabla
        End Function

    End Class

End Namespace


