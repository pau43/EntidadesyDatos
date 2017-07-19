
Imports System.Text
Imports System.IO
Imports System.Data.SqlClient
Imports PoolConexiones
Imports GEACEntidades.Almacen
'Imports GEACEntidades.EAlmacen
Imports GEACEntidades

Namespace DAOAlmacen
    Public Class DAOTransferenciasEquiposEstiba
        Private Advertencia As String = String.Empty

#Region "Carga de Datos"

        Public Function VerStockParaTransferenciaEstiba(ByVal CodAlmacen As String) As DataTable

            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter

            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_VerStockParaTransferenciaEstiba]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@codalmacen", IIf(CodAlmacen.Trim.Length = 0, DBNull.Value, CodAlmacen))
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
                param = Nothing
            End Try

            Return tabla
        End Function

        Public Function MostrarTransferenciasSinRecepcionar(ByVal CodAlmacen As String) As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter

            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarTransferenciasSinRecepcionar]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@codalmacen", IIf(CodAlmacen.Trim.Length = 0, DBNull.Value, CodAlmacen))
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

        Public Function MostrarTransferenciasSinRecepcionarV2(ByVal CodAlmacenOrigen As String, ByVal CodAlmacenDestino As String) As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter

            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarTransferenciasSinRecepcionarV2]"
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

#End Region

#Region "Mantenimiento de Datos"

        Public Function NuevaTransferenciaEquipos(ByVal OTransferencia As Transferencia_Estiba) As Boolean
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_NuevaTransferenciaEquipoEstiba]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                With OTransferencia

                    param = New SqlParameter("@fechatransferencia", .FechaTransferencia)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@codalmorigen", .CodAlmOrigen)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@codalmdestino", .CodAlmDestino)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@idchofer", .IDPersona)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@idremolcador", IIf(.IDRemolcador <= 0, DBNull.Value, .IDRemolcador))
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@idsemiremolque", IIf(.IDSemiRemolque <= 0, DBNull.Value, .IDSemiRemolque))
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@observaciones", IIf(.Observaciones.Trim.Length = 0, DBNull.Value, .Observaciones))
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@detalles", IIf(.XMLDetalles_Transferencia.Trim.Length = 0, DBNull.Value, .XMLDetalles_Transferencia)) 'para necesario para el sp
                    comando.Parameters.Add(param)
                End With


                If comando.Connection.State = ConnectionState.Closed Then
                    comando.Connection.Open()
                End If


                Dr = comando.ExecuteReader(CommandBehavior.CloseConnection)

                Dr.Read()
                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Transferencia Equipos")

                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Transferencia Equipos")
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

        Public Function ModificarTransferenciaEquipos(ByVal OTransferencia As Transferencia_Estiba) As Boolean
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_ModificarTransferenciaEquipoEstiba]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                With OTransferencia

                    param = New SqlParameter("@idtransferencia", .IDTransferencia)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@fechatransferencia", .FechaTransferencia)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@codalmorigen", .CodAlmOrigen)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@codalmdestino", .CodAlmDestino)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@idchofer", .IDPersona)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@idremolcador", .IDRemolcador)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@idsemiremolque", IIf(.IDSemiRemolque <= 0, DBNull.Value, .IDSemiRemolque))
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@observaciones", IIf(.Observaciones.Trim.Length = 0, DBNull.Value, .Observaciones))
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@detalles", IIf(.XMLDetalles_Transferencia.Trim.Length = 0, DBNull.Value, .XMLDetalles_Transferencia))
                    comando.Parameters.Add(param)
                End With
                Dr = comando.ExecuteReader
                Dr.Read()
                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Transferencia Equipos")

                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Transferencia Equipos")
                End If
            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                Retorno = False
            Finally
                Dr.Close()
                Dr = Nothing
                param = Nothing
                comando.Dispose()
                comando = Nothing
            End Try
            Return Retorno
        End Function

        Public Function EliminarTransferenciaEstiba(ByVal IDTransferencia As Integer) As Boolean

            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_EliminarTransferenciaEstiba]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@idtransferencia", IDTransferencia)
                comando.Parameters.Add(param)

                If comando.Connection.State = ConnectionState.Closed Then
                    comando.Connection.Open()
                End If

                Dr = comando.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()

                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Solicitud Equipamiento")
                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Solicitud Equipamiento")
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

        Public Function RecepcionarTransferenciaEstiba(ByVal OTransferencia As Transferencia_Estiba) As Boolean

            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_RecepcionarTransferenciaEquipoEstiba]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                With OTransferencia


                    param = New SqlParameter("@idtransferencia", .IDTransferencia)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@fecharecepcion", .FechaRecepcion)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@detalles", IIf(.XMLDetalles_Transferencia.Trim.Length = 0, DBNull.Value, .XMLDetalles_Transferencia))
                    comando.Parameters.Add(param)

                End With

                If comando.Connection.State = ConnectionState.Closed Then
                    comando.Connection.Open()
                End If



                Dr = comando.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()

                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Solicitud Equipamiento")
                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Solicitud Equipamiento")
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




#End Region



    End Class

End Namespace

