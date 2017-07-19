Imports PoolConexiones
Imports System.Data.SqlClient
Imports GEACEntidades.Almacen
'Imports GEACEntidades.EAlmacen
Imports GEACEntidades

Namespace DAOAlmacen

    Public Class DAOTransferenciasEqAuxiliares
        Private Advertencia As String = String.Empty

        Public Function MostrarTransferenciasAuxSinRecepcionar(ByVal CodAlmacenOrigen As String, ByVal CodAlmacenDestino As String) As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter

            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarTransferenciasAuxSinRecepcionar]"
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

        Public Function MostrarStockEqAlmAuxiliar(ByVal CodAlmacen As String) As DataTable

            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarStockEqAlmAuxiliar]"
            Try
                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@codalmacen", CodAlmacen)
                comando.Parameters.Add(param)

                Da = New SqlDataAdapter(comando)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Transferencias Equipos Auxiliares")
                tabla = Nothing
            Finally

                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                param = Nothing

            End Try
            Return tabla
        End Function

        Public Function NuevaTransferenciaAlmAuxiliares(ByVal OTransferencia As Transferencias_EqAuxiliares) As Boolean 'utilizado tanto para solicitar como para devolver
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_TxDesdeAlmAuxiliar]"
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

                    param = New SqlParameter("@xCodEquipos", IIf(.XMLKardexAlmAuxiliar.Trim.Length = 0, DBNull.Value, .XMLKardexAlmAuxiliar))
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@xSerieEquipos", IIf(.XMLKardexAlmAuxiliarPcod.Trim.Length = 0, DBNull.Value, .XMLKardexAlmAuxiliarPcod))
                    comando.Parameters.Add(param)


                End With

                If comando.Connection.State = ConnectionState.Closed Then
                    comando.Connection.Open()
                End If

                Dr = comando.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()

                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Transferencia Equipos Auxiliares")

                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Transferencia Equipos Auxiliares")
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

        Public Function AnularTxAlmAuxiliar(ByVal OTransferencia As Transferencias_EqAuxiliares) As Boolean 'utilizado tanto para solicitar como para devolver
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_AnularTxAlmAuxiliar]"
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
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Transferencia Equipos Auxiliares")

                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Transferencia Equipos Auxiliares")
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

        Public Function RecepcionarTxAlmAuxiliar(ByVal OTransferencia As Transferencias_EqAuxiliares) As Boolean 'utilizado tanto para solicitar como para devolver
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing
            Try
                comando.CommandText = "[Almacen].[SpAlm_RecepcionarTxAlmAuxiliar]"
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

                    param = New SqlParameter("@Observacion", IIf(.Observacion.Trim.Length = 0, DBNull.Value, .Observacion))
                    comando.Parameters.Add(param)

                End With

                If comando.Connection.State = ConnectionState.Closed Then
                    comando.Connection.Open()
                End If

                Dr = comando.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()

                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Transferencia Equipos Auxiliares")

                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Transferencia Equipos Auxiliares")
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

        Public Function AnularRecepcionTxAlmAuxiliar(ByVal OTransferencia As Transferencias_EqAuxiliares) As Boolean 'utilizado tanto para solicitar como para devolver
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing
            Try
                comando.CommandText = "[Almacen].[SpAlm_AnularRecepcionTxAlmAuxiliar]"
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
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Transferencia Equipos Auxiliares")

                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Transferencia Equipos Auxiliares")
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

        Public Function MostrarAlmDestinoTxAux(ByVal IDSucursal As Integer) As DataTable

            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarAlmDestinoTxAux]"
            Try
                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@idsucursal", IIf(IDSucursal <= 0, DBNull.Value, IDSucursal))
                comando.Parameters.Add(param)

                Da = New SqlDataAdapter(comando)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Transferencias Equipos Auxiliares")
                tabla = Nothing
            Finally

                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                param = Nothing

            End Try
            Return tabla
        End Function

       


    End Class


End Namespace
