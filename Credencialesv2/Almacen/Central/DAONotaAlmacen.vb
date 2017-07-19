Imports PoolConexiones
Imports GEACEntidades.Almacen
Imports GEACEntidades
Imports System.Data.SqlClient

Namespace DAOAlmacen

    Public Class DAONotaAlmacen
        Private Advertencia As String = String.Empty

        Public Function MostrarListadoNotaAlmacen(ByVal pCodAlmNota As String, ByVal pAnio As Short, ByVal pPageSize As Integer, ByVal pPageNumber As Integer, ByRef pTotalPages As Integer) As DataTable
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Da As SqlDataAdapter

            Dim dt As New DataTable
            Try
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.CommandText = "TRC.Almacen.SpAlm_NA_ListarNotaAlmacen"


                Prm = New SqlParameter("@CodAlmNota", pCodAlmNota)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@Anio", pAnio)
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
                    MsgBox(TSQL.UltimoMensaje, MsgBoxStyle.Critical, "Listar Nota de Almacén")
                End If

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Listar Nota de Almacén") ', MaestroGeac )
                dt = Nothing
            End Try
            Return dt
        End Function

        Public Function udfVerDetalleNotaAlmacen(ByVal pPKNotaAlmacen As PKNotaAlmacen) As DataTable
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

            With pPKNotaAlmacen

                Try

                    Cmd.CommandText = "Almacen.SpAlm_NA_VerDetalleNotaAlmacen"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure

                    Prm = New SqlParameter("@CodAlmNota", .f_CodAlmNota)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@CodMovi", .f_CodMovi)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@Anio", .f_Anio)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@NroMovimiento", .f_NroMovimiento)
                    Cmd.Parameters.Add(Prm)

                    Da = New SqlDataAdapter(Cmd)
                    Da.Fill(tabla)

                Catch ex As Exception
                    MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Detalle Nota Almacén")
                    tabla = Nothing
                Finally
                    Da = Nothing
                    Cmd = Nothing
                    'StrComando = String.Empty
                End Try

                Return tabla
            End With
        End Function

        Public Function NuevaNotaAlmacen(ByVal oNotaAlmacen As NotaAlmacen) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing
            'oConexion = New SqlConnection()
            'oConexion.ConnectionString = strConexion
            Dim xDtlleNA As String
            Dim xDtlleInv As String
            Dim xListPedido As String
            Dim xListOC As String
            Dim xNroRef As String
            Dim xObs As String
            Dim xNroInc As String

            With oNotaAlmacen

                Try
                    '[SpAlm_NuevoPedidoAlmCentral]
                    Cmd.CommandText = "Almacen.SpAlm_NA_CrearNotaAlmacen"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure

                    Prm = New SqlParameter("@CodAlmNota", .p_IDNotaAlmacen.f_CodAlmNota)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@CodMovi", .p_IDNotaAlmacen.f_CodMovi)
                    Cmd.Parameters.Add(Prm)

                    xNroRef = .p_NroReferencia
                    Prm = New SqlParameter("@NroReferencia", .p_NroReferencia)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@FechaNota", .p_FechaNota)
                    Cmd.Parameters.Add(Prm)

                    xObs = .p_Observacion
                    Prm = New SqlParameter("@Observacion", .p_Observacion)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@IDLocalNota", SesionUsuario.IDSucursal)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@IDProveedor", .p_IDProveedor)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@IDTrabajador", .p_IDTrabajador)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@IDUnidad", .p_IDUnidad)
                    Cmd.Parameters.Add(Prm)

                    xNroInc = .p_NroIncidente
                    Prm = New SqlParameter("@NroIncidente", .p_NroIncidente)
                    Cmd.Parameters.Add(Prm)

                    xDtlleNA = .p_XMLListaProductos.ToString.Trim
                    Prm = New SqlParameter("@xDtlleNotaAlmacen", .p_XMLListaProductos.ToString.Trim)
                    Cmd.Parameters.Add(Prm)

                    xDtlleInv = .p_XMLListaProdInventario.ToString.Trim
                    Prm = New SqlParameter("@xDtlleInventario", .p_XMLListaProdInventario.ToString.Trim)
                    Cmd.Parameters.Add(Prm)

                    xListPedido = .p_XMLListaPedidos.ToString.Trim
                    Prm = New SqlParameter("@xListaPedidos", .p_XMLListaPedidos.ToString.Trim)
                    Cmd.Parameters.Add(Prm)

                    xListOC = .p_XMLListaOCompra.ToString.Trim
                    Prm = New SqlParameter("@xListaOrdenC", .p_XMLListaOCompra.ToString.Trim)
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
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Nueva Nota de Almacen")
                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Nueva Nota de Almacen")
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

        Public Function ModificaNotaAlmacen(ByVal oNotaAlmacen As NotaAlmacen) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing
            'Dim xSQLModifica As String
            'oConexion = New SqlConnection()
            'oConexion.ConnectionString = strConexion
            With oNotaAlmacen

                Try
                    '[SpAlm_NuevoPedidoAlmCentral]
                    Cmd.CommandText = "Almacen.SpAlm_NA_ModificarNotaAlmacen"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure

                    'xSQLModifica = "Almacen.SpAlm_OC_ModificarOrdenCompra "

                    'xSQLModifica += CStr(.IDOrdenCompra.IDLocalOC) + ","
                    Prm = New SqlParameter("@CodAlmNota", .p_IDNotaAlmacen.f_CodAlmNota)
                    Cmd.Parameters.Add(Prm)

                    'xSQLModifica += CStr(.FechaEmision) + ","
                    Prm = New SqlParameter("@CodMovi", .p_IDNotaAlmacen.f_CodMovi)
                    Cmd.Parameters.Add(Prm)

                    'xSQLModifica += CStr(.CodEmpresa) + ","
                    Prm = New SqlParameter("@Anio", .p_IDNotaAlmacen.f_Anio)
                    Cmd.Parameters.Add(Prm)

                    'xSQLModifica += CStr(.IDOrdenCompra.AnioOC) + ","
                    Prm = New SqlParameter("@NroMovimiento", .p_IDNotaAlmacen.f_NroMovimiento)
                    Cmd.Parameters.Add(Prm)

                    'xSQLModifica += CStr(.IDOrdenCompra.NroOC) + ","
                    Prm = New SqlParameter("@NroReferencia", .p_NroReferencia)
                    Cmd.Parameters.Add(Prm)

                    'xSQLModifica += .Serie + ","
                    Prm = New SqlParameter("@FechaNota", .p_FechaNota)
                    Cmd.Parameters.Add(Prm)

                    'xSQLModifica += CStr(.Numero) + ","
                    Prm = New SqlParameter("@Observacion", .p_Observacion)
                    Cmd.Parameters.Add(Prm)

                    'xSQLModifica += CStr(.TerminosPago) + ","
                    Prm = New SqlParameter("@IDProveedor", .p_IDProveedor)
                    Cmd.Parameters.Add(Prm)

                    'xSQLModifica += CStr(.IDMoneda) + ","
                    Prm = New SqlParameter("@IDTrabajador", .p_IDTrabajador)
                    Cmd.Parameters.Add(Prm)

                    'xSQLModifica += .CodAlmOC + ","
                    Prm = New SqlParameter("@IDUnidad", .p_IDUnidad)
                    Cmd.Parameters.Add(Prm)

                    'xSQLModifica += CStr(.PlazoAtencion) + ","
                    Prm = New SqlParameter("@NroIncidente", .p_NroIncidente)
                    Cmd.Parameters.Add(Prm)



                    'xSQLModifica += CStr(.XMLListaProductos.Trim) + ","
                    Prm = New SqlParameter("@xDtlleNotaAlmacen", .p_XMLListaProductos.Trim)
                    Cmd.Parameters.Add(Prm)

                    'xSQLModifica += CStr(pGrabaDetalle) + ","
                    'Prm = New SqlParameter("@wGrabarDetalle", pGrabaDetalle)
                    'Cmd.Parameters.Add(Prm)

                    'xSQLModifica += CStr(.XMLListaPedidos.ToString.Trim) + ","
                    ' Lista de Pedidos que conforman OC, si es que los tiene
                    Prm = New SqlParameter("@xDtlleInventario", .p_XMLListaProdInventario.ToString.Trim)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@xListaPedidos", .p_XMLListaPedidos.ToString.Trim)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@Usuario", SesionUsuario.Usuario)
                    Cmd.Parameters.Add(Prm)

                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If

                    Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)

                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    'If Retorno Then
                    '    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Modifica Nota Almacen")
                    'Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Modifica Nota Almacen")
                    'End If

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

        Public Function udfVerPCodificablesAptos(ByVal pCodAlmacen As String, ByVal pCodMovi As String, ByVal pCodProducto As String, ByVal pPorIngreso As Boolean) As DataTable
            Dim tabla As New DataTable
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Da As SqlDataAdapter
            'oConexion = New SqlConnection()
            'oConexion.ConnectionString = strConexion

            Try
                Cmd.CommandText = "Almacen.SpAlm_NA_VerPCodificablesAptos"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@CodAlmacen", pCodAlmacen)
                Cmd.Parameters.Add(Prm)

                If pCodMovi.Length > 0 Then
                    Prm = New SqlParameter("@CodMovi", pCodMovi)
                    Cmd.Parameters.Add(Prm)
                End If

                If pCodProducto.Length > 0 Then
                    Prm = New SqlParameter("@CodProducto", pCodProducto)
                    Cmd.Parameters.Add(Prm)
                End If

                If pPorIngreso Then
                    Prm = New SqlParameter("@wPorIngreso", pPorIngreso)
                    Cmd.Parameters.Add(Prm)
                End If

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Productos Codificables")
                tabla = Nothing
            Finally
                Da = Nothing
                Cmd = Nothing
                'StrComando = String.Empty
            End Try

            Return tabla

        End Function



        Public Function AnulaNotaAlmacen(ByVal pPKNotaAlmacen As PKNotaAlmacen, ByVal pMotivoAnulacion As String) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing
            'oConexion = New SqlConnection()
            'oConexion.ConnectionString = strConexion

            With pPKNotaAlmacen

                Try

                    Cmd.CommandText = "Almacen.SpAlm_NA_AnularNotaAlmacen"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure

                    Prm = New SqlParameter("@CodAlmNota", .f_CodAlmNota)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@CodMovi", .f_CodMovi)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@Anio", .f_Anio)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@NroMovimiento", .f_NroMovimiento)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@MotivoAnulacion", pMotivoAnulacion)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@Usuario", SesionUsuario.Usuario)
                    Cmd.Parameters.Add(Prm)

                    ' Lista de Pedidos que conforman OC, si es que los tiene
                    'Prm = New SqlParameter("@xListaPedidos", .XMLListaPedidos.ToString.Trim)
                    'Cmd.Parameters.Add(Prm)
                    '------ Cuando se ANULA Orden de Compra
                    '       Se Liberan todos los Pedidos Anexados a ella (O.C.)

                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If

                    Dr = Cmd.ExecuteReader()

                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Anula Nota de Almacen")
                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Anula Nota de Almacen")
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

        Public Function udfRPT_KardexProductos(ByVal pCodAlmacen As String, ByVal pFechaIni As Date, ByVal pFechaFin As Date, ByVal pCodProductoIni As String, ByVal pCodProductoFin As String) As DataTable
            Dim tabla As New DataTable
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Da As SqlDataAdapter
            'oConexion = New SqlConnection()
            'oConexion.ConnectionString = strConexion

            Try
                Cmd.CommandText = "Almacen.SpAlm_NA_Rpt_KardexProductos"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@CodAlmNota", pCodAlmacen)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@FechaIni", pFechaIni)
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@FechaFin", pFechaFin)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@CodProductoIni", pCodProductoIni)
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@CodProductoFin", pCodProductoFin)
                Cmd.Parameters.Add(Prm)

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Kardex de Productos")
                tabla = Nothing
            Finally
                Da = Nothing
                Cmd = Nothing
                'StrComando = String.Empty
            End Try

            Return tabla
        End Function

        Public Function udfRPT_KardexProdCodificables(ByVal pFechaIni As Date, ByVal pFechaFin As Date, ByVal pCodProductoIni As String, ByVal pCodProductoFin As String) As DataTable
            Dim tabla As New DataTable
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Da As SqlDataAdapter
            'oConexion = New SqlConnection()
            'oConexion.ConnectionString = strConexion

            Try
                Cmd.CommandText = "Almacen.SpAlm_NA_Rpt_KardexProdCodificables"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@FechaIni", pFechaIni)
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@FechaFin", pFechaFin)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@CodProductoIni", pCodProductoIni)
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@CodProductoFin", pCodProductoFin)
                Cmd.Parameters.Add(Prm)

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Kardex de Productos Codificables")
                tabla = Nothing
            Finally
                Da = Nothing
                Cmd = Nothing
                'StrComando = String.Empty
            End Try

            Return tabla
        End Function

        Public Function udfRPT_NotasAlmacen(ByVal pCodAlmacen As String, ByVal pFechaIni As Date, ByVal pFechaFin As Date, ByVal pCodMovi As String) As DataTable
            Dim tabla As New DataTable
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Da As SqlDataAdapter
            'oConexion = New SqlConnection()
            'oConexion.ConnectionString = strConexion

            Try
                Cmd.CommandText = "Almacen.SpAlm_NA_Rpt_NotasAlmacen"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@CodAlmNota", pCodAlmacen)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@FechaIni", pFechaIni)
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@FechaFin", pFechaFin)
                Cmd.Parameters.Add(Prm)
                If pCodMovi.Length > 0 Then
                    Prm = New SqlParameter("@CodMovi", pCodMovi)
                    Cmd.Parameters.Add(Prm)
                End If


                Da = New SqlDataAdapter(Cmd)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Notas de Almacén")
                tabla = Nothing
            Finally
                Da = Nothing
                Cmd = Nothing
                'StrComando = String.Empty
            End Try

            Return tabla
        End Function

        Public Function udfVerProdAsignados(ByVal pIDPersona As Integer, ByVal pIDUnidad As Integer) As DataTable
            Dim tabla As New DataTable
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Da As SqlDataAdapter
            'oConexion = New SqlConnection()
            'oConexion.ConnectionString = strConexion

            Try
                Cmd.CommandText = "Almacen.SpAlm_NA_VerProductosAsignados"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@IDPersona", pIDPersona)
                Cmd.Parameters.Add(Prm)

                If pIDUnidad > 0 Then
                    Prm = New SqlParameter("@IDUnidad", pIDUnidad)
                    Cmd.Parameters.Add(Prm)
                End If
                'Prm = New SqlParameter("@FechaFin", pFechaFin)
                'Cmd.Parameters.Add(Prm)
                'If pCodMovi.Length > 0 Then
                '    Prm = New SqlParameter("@CodMovi", pCodMovi)
                '    Cmd.Parameters.Add(Prm)
                'End If


                Da = New SqlDataAdapter(Cmd)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Notas de Almacén")
                tabla = Nothing
            Finally
                Da = Nothing
                Cmd = Nothing
                'StrComando = String.Empty
            End Try

            Return tabla
        End Function

        Public Function udfRPT_AsignadosDetalle(ByVal pVerPermanente As Boolean, ByVal pEsPersonaUnidad As Boolean, ByVal pCodigoAsignado As Integer) As DataTable
            Dim tabla As New DataTable
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Da As SqlDataAdapter
            'oConexion = New SqlConnection()
            'oConexion.ConnectionString = strConexion

            Try
                Cmd.CommandText = "Almacen.SpAlm_NA_Rpt_AsignadosDetalle"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@VerPermanente", pVerPermanente)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@PersonaUnidad", pEsPersonaUnidad)
                Cmd.Parameters.Add(Prm)

                If pCodigoAsignado > 0 Then
                    Prm = New SqlParameter("@CodigoAsignado", pCodigoAsignado)
                    Cmd.Parameters.Add(Prm)
                End If

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Asignados - Detalle")
                tabla = Nothing
            Finally
                Da = Nothing
                Cmd = Nothing
                'StrComando = String.Empty
            End Try

            Return tabla
        End Function

        Public Function udfRPT_AsignadosInventario(ByVal pEsPersonaUnidad As Boolean, ByVal pCodigoAsignado As Integer) As DataTable
            Dim tabla As New DataTable
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Da As SqlDataAdapter
            'oConexion = New SqlConnection()
            'oConexion.ConnectionString = strConexion

            Try
                Cmd.CommandText = "Almacen.SpAlm_NA_Rpt_AsignadosInventario"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@PersonaUnidad", pEsPersonaUnidad)
                Cmd.Parameters.Add(Prm)

                If pCodigoAsignado > 0 Then
                    Prm = New SqlParameter("@CodigoAsignado", pCodigoAsignado)
                    Cmd.Parameters.Add(Prm)
                End If

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Asignados - Inventario")
                tabla = Nothing
            Finally
                Da = Nothing
                Cmd = Nothing
                'StrComando = String.Empty
            End Try

            Return tabla
        End Function

#Region "CONTROL DE NOTAS DE ALMACEN"
        Public Function udfCreaControlAlmacen(ByVal oControlAlmacen As ControlNotasAlmacen) As Boolean
            'Public Function udfCreaControlAlmacen(ByVal oCtrlNotaAlmacen As ControlNotasAlmacen) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing
            'oConexion = New SqlConnection()
            'oConexion.ConnectionString = strConexion


            Try
                '[SpAlm_NuevoPedidoAlmCentral]
                Cmd.CommandText = "Almacen.SpAlm_NA_CrearControlAlmacen"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure


                Prm = New SqlParameter("@CodAlmacen", oControlAlmacen.p_CodAlmacen)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@IDResponsable", SesionUsuario.IDPersona)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@xmlListCtrlProd", oControlAlmacen.p_XMLListaProductos)
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
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Crea Control de Nota de Almacen")
                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Crea Control de Nota de Almacen")
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

        End Function

        Public Function udfAnulaControlAlmacen(ByVal pCodAlmacen As String, ByVal pCodProducto As String, ByVal pNroCorte As Integer, ByVal pMotivoAnulacion As String) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing
            'oConexion = New SqlConnection()
            'oConexion.ConnectionString = strConexion


            Try
                '[SpAlm_NuevoPedidoAlmCentral]
                Cmd.CommandText = "Almacen.SpAlm_NA_AnularControlAlmacen"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@CodAlmacen", pCodAlmacen)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@CodProducto", pCodProducto)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@NroCorte", pNroCorte)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@IDRespAnula", SesionUsuario.IDPersona)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@MotivoAnulacion", pMotivoAnulacion)
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
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Anula Control de Nota de Almacen")
                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Crea Control de Nota de Almacen")
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

        End Function

        Public Function udfVerControlAlmacen(ByVal pCodAlmacen As String, ByVal pXMLTipoProducto As String, ByVal pNombreProducto As String, ByVal pPageSize As Integer, ByVal pPageNumber As Integer, ByRef pTotalPages As Integer) As DataTable
            Dim tabla As New DataTable
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_NA_VerControlAlmacen]"
            Try

                Cmd.CommandText = StrComando
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@CodAlmacen", pCodAlmacen)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@xmlIDTipoProducto", pXMLTipoProducto)
                Cmd.Parameters.Add(Prm)
                Prm = New SqlParameter("@NombreProducto", pNombreProducto)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@PageSize", pPageSize)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@PageNumber", pPageNumber)
                Cmd.Parameters.Add(Prm)

                Prm = New SqlParameter("@TotalPages", SqlDbType.Int)
                Prm.Direction = ParameterDirection.Output
                Cmd.Parameters.Add(Prm)

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(tabla)

                pTotalPages = Cmd.Parameters("@TotalPages").Value

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Ver Control de Almacén")
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

    End Class
End Namespace