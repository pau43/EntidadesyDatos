Imports System.Data.SqlClient
Imports GEACEntidades.Almacen
Imports PoolConexiones

Namespace DAOAlmacen

    Public Class DAOTransferenciasCentral
        Private Advertencia As String = String.Empty

        Public Function MostrarTransferenciasCentralSinRecepcionar(ByVal CodAlmacenOrigen As String, ByVal CodAlmacenDestino As String) As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter

            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarTransferenciasCentralSinRecepcionar]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@codalmacenorigen", IIf(CodAlmacenOrigen.Trim.Length = 0, DBNull.Value, CodAlmacenOrigen))
                comando.Parameters.Add(param)

                param = New SqlParameter("@codalmacendestino", IIf(CodAlmacenDestino.Trim.Length = 0, DBNull.Value, CodAlmacenDestino))
                comando.Parameters.Add(param)

                Da = New SqlDataAdapter(comando)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Equipamiento Estibas")
                tabla = Nothing
            Finally
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
            End Try
            Return tabla
        End Function

        Public Function MostrarStockCodigosProducto(ByVal CodAlmacen As String, ByVal CodProducto As String, ByVal Producto As String) As DataTable

            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarStockCodigosProducto]"
            Try
                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure


                param = New SqlParameter("@codalmacen", CodAlmacen)
                comando.Parameters.Add(param)


                param = New SqlParameter("@codproducto", IIf(CodProducto.Trim.Length = 0, DBNull.Value, CodProducto))
                comando.Parameters.Add(param)

                param = New SqlParameter("@producto", IIf(Producto.Trim.Length = 0, DBNull.Value, Producto))
                comando.Parameters.Add(param)

                Da = New SqlDataAdapter(comando)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Transferencias Almacenes")
                tabla = Nothing
            Finally

                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                param = Nothing

            End Try
            Return tabla
        End Function

        Public Function MostrarProductosRecepcionados(ByVal FechaInicio As Date, ByVal FechaFin As Date, Optional ByVal CodAlmacen As String = "") As DataTable  'muestra las trans recepcionadas
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter

            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarProductosRecepcionados]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@fechaini", FechaInicio)
                comando.Parameters.Add(param)

                param = New SqlParameter("@fechafin", FechaFin)
                comando.Parameters.Add(param)

                param = New SqlParameter("@codalmacen", IIf(CodAlmacen.Trim.Length = 0, DBNull.Value, CodAlmacen))
                comando.Parameters.Add(param)

                Da = New SqlDataAdapter(comando)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Equipos Auxiliares")
                tabla = Nothing
            Finally

                Da = Nothing
                comando = Nothing
                StrComando = String.Empty

            End Try

            Return tabla
        End Function

#Region "Mantenimiento de Datos"

        Public Function NuevaTransferenciaCentral(ByVal OTransferencia As TransferenciaCentral) As Boolean 'utilizado tanto para solicitar como para devolver
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_TxDesdeAlmCentral]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                With OTransferencia


                    param = New SqlParameter("@CodAlmOrigen", .CodAlmTxOrigen)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@FEnvio", IIf(.FechaEnvio = #12:00:00 AM#, DBNull.Value, .FechaEnvio))
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@IdPersona", .IDPersona)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@Observacion", IIf(.Observacion.Trim.Length = 0, DBNull.Value, .Observacion))
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@CodAlmDestino", .CodAlmTxDestino)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@xCodEquipos", IIf(.XMLCodigosProducto.Trim.Length = 0, DBNull.Value, .XMLCodigosProducto))
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@xSerieEquipos", IIf(.XMLSeriesProducto.Trim.Length = 0, DBNull.Value, .XMLSeriesProducto))
                    comando.Parameters.Add(param)


                End With

                If comando.Connection.State = ConnectionState.Closed Then
                    comando.Connection.Open()
                End If

                Dr = comando.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()

                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Transferencias Almacen Central")

                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Transferencias Almacen Central")
                End If

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                Retorno = False
            Finally
                If Not IsNothing(Dr) Then
                    Dr.Close()
                End If

                Dr = Nothing
                param = Nothing
                comando.Dispose()
                comando = Nothing

            End Try
            Return Retorno
        End Function

        Public Function RecepcionarTxAlmCentral(ByVal OTransferencia As TransferenciaCentral) As Boolean 'utilizado tanto para solicitar como para devolver
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing
            Try
                comando.CommandText = "[Almacen].[SpAlm_RecepcionarTxAlmCentral]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                With OTransferencia

                    param = New SqlParameter("@CodAlmOrigen", .CodAlmTxOrigen)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@AnioTx", .AnioTx)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@NroTx", .NroTx)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@FRecepcion", IIf(.FechaRecepcion = #12:00:00 AM#, DBNull.Value, .FechaRecepcion))
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@Observacion", IIf(.ObservacionRecepcion.Trim.Length = 0, DBNull.Value, .ObservacionRecepcion))
                    comando.Parameters.Add(param)

                End With

                If comando.Connection.State = ConnectionState.Closed Then
                    comando.Connection.Open()
                End If

                Dr = comando.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()

                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Transferencias Central")

                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Transferencias Central")
                End If

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                Retorno = False
            Finally
                If Not IsNothing(Dr) Then
                    Dr.Close() ' al cerrar el datareader tambien cierra el comando asociado
                End If

                Dr = Nothing
                param = Nothing
                comando.Dispose()
                comando = Nothing

            End Try
            Return Retorno
        End Function

        Public Function AnularTxAlmCentral(ByVal OTransferencia As TransferenciaCentral) As Boolean 'utilizado tanto para solicitar como para devolver
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_AnularTxAlmCentral]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                With OTransferencia

                    param = New SqlParameter("@CodAlmOrigen", .CodAlmTxOrigen)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@AnioTx", .AnioTx)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@NroTx", .NroTx)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@Motivo", .MotivoAnulacion)
                    comando.Parameters.Add(param)

                End With

                If comando.Connection.State = ConnectionState.Closed Then
                    comando.Connection.Open()
                End If

                Dr = comando.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()

                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Transferencias Central")

                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Transferencias Central")
                End If

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                Retorno = False
            Finally
                If Not IsNothing(Dr) Then
                    Dr.Close() ' al cerrar el datareader tambien cierra el comando asociado
                End If

                Dr = Nothing
                param = Nothing
                comando.Dispose()
                comando = Nothing

            End Try
            Return Retorno
        End Function

        Public Function ConfirmarBajaEquiposPorVale(ByVal OTransferencia As TransferenciaCentral) As Boolean 'utilizado tanto para solicitar como para devolver
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing
            Try
                comando.CommandText = "[Almacen].[SpAlm_ConfirmarBajaEquiposPorVale]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                With OTransferencia

                    param = New SqlParameter("@CodAlmOrigen", .CodAlmTxOrigen)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@AnioTx", .AnioTx)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@NroTx", .NroTx)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@FBaja", IIf(.FechaRecepcion = #12:00:00 AM#, DBNull.Value, .FechaRecepcion))
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@Observacion", IIf(.ObservacionRecepcion.Trim.Length = 0, DBNull.Value, .ObservacionRecepcion))
                    comando.Parameters.Add(param)

                End With

                If comando.Connection.State = ConnectionState.Closed Then
                    comando.Connection.Open()
                End If

                Dr = comando.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()

                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Transferencias Central")

                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Transferencias Central")
                End If

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                Retorno = False
            Finally
                If Not IsNothing(Dr) Then
                    Dr.Close() ' al cerrar el datareader tambien cierra el comando asociado
                End If

                Dr = Nothing
                param = Nothing
                comando.Dispose()
                comando = Nothing

            End Try
            Return Retorno
        End Function

        Public Function AnularRecepcionTxAlmCentral(ByVal OTransferencia As TransferenciaCentral) As Boolean 'utilizado tanto para solicitar como para devolver
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing
            Try
                comando.CommandText = "[Almacen].[SpAlm_AnularRecepcionTxAlmCentral]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                With OTransferencia

                    param = New SqlParameter("@CodAlmOrigen", .CodAlmTxOrigen)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@AnioTx", .AnioTx)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@NroTx", .NroTx)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@Motivo", .MotivoAnulacion)
                    comando.Parameters.Add(param)

                End With

                If comando.Connection.State = ConnectionState.Closed Then
                    comando.Connection.Open()
                End If

                Dr = comando.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()

                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Transferencia Almacén Central")

                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Transferencia Almacén Central")
                End If

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                Retorno = False
            Finally
                If Not IsNothing(Dr) Then
                    Dr.Close() ' al cerrar el datareader tambien cierra el comando asociado
                End If

                Dr = Nothing
                param = Nothing
                comando.Dispose()
                comando = Nothing

            End Try
            Return Retorno
        End Function


#End Region


    End Class





End Namespace


