
Imports System.Data.SqlClient
Imports PoolConexiones
Imports GEACEntidades.Almacen
'Imports GEACEntidades.EAlmacen

Namespace DAOAlmacen

    Public Class DAOControlStockEquiposEstiba
        Private Advertencia As String = String.Empty
        Public Function MostrarControlStockEquiposEstiba(ByVal FechaInicial As Date, ByVal FechaFinal As Date, ByVal Opcion As Integer) As DataTable
            Dim Dt As New DataTable
            Dim prm As SqlParameter
            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarControlStockEstibas]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                prm = New SqlParameter("@fechainicio", FechaInicial)
                comando.Parameters.Add(prm)

                prm = New SqlParameter("@fechafin", FechaFinal)
                comando.Parameters.Add(prm)

                prm = New SqlParameter("@opcion", Opcion)
                comando.Parameters.Add(prm)


                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Reportes Almacén")
                Dt = Nothing
            Finally
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty

            End Try
            Return Dt
        End Function

        Public Function MostrarMovimientoStockEquipos(ByVal IDEstiba As Integer, ByVal CodAlmacen As String, ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarMovimientoStockEquipos]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure


                param = New SqlParameter("@idestiba", IIf(IDEstiba <= 0, DBNull.Value, IDEstiba))
                comando.Parameters.Add(param)


                param = New SqlParameter("@codalmacen", IIf(CodAlmacen.Trim.Length = 0, DBNull.Value, CodAlmacen))
                comando.Parameters.Add(param)


                param = New SqlParameter("@fini", FechaInicio)
                comando.Parameters.Add(param)

                param = New SqlParameter("@ffin", FechaFin)
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

        Public Function UltimoControlStockEquipos(ByVal CodAlmacen As String, ByVal IDEstiba As Integer) As DataTable
            Dim Dt As New DataTable
            Dim prm As SqlParameter
            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_UltimoControlStockEquipos]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                prm = New SqlParameter("@codalmacen", CodAlmacen)
                comando.Parameters.Add(prm)

                prm = New SqlParameter("@idestiba", IDEstiba)
                comando.Parameters.Add(prm)

                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Reportes Almacén")
                Dt = Nothing
            Finally
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty

            End Try
            Return Dt
        End Function

        Public Function MostarEquiposEstibaXAlmacen(ByVal CodAlmacen As String) As DataTable
            Dim Dt As New DataTable
            Dim prm As SqlParameter
            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarEquiposEstibaXAlmacen]"
            Try
                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                prm = New SqlParameter("@codalmacen", CodAlmacen)
                comando.Parameters.Add(prm)


                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Reportes Almacén")
                Dt = Nothing
            Finally
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty

            End Try
            Return Dt
        End Function

        Public Function MostrarMovimientoEquiposEstiba(ByVal IDEstiba As Integer, ByVal CodAlmacen As String, ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarMovimientoStockEquipos]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure


                param = New SqlParameter("@idestiba", IIf(IDEstiba <= 0, DBNull.Value, IDEstiba))
                comando.Parameters.Add(param)


                param = New SqlParameter("@codalmacen", IIf(CodAlmacen.Trim.Length = 0, DBNull.Value, CodAlmacen))
                comando.Parameters.Add(param)


                param = New SqlParameter("@fini", FechaInicio)
                comando.Parameters.Add(param)

                param = New SqlParameter("@ffin", FechaFin)
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

        Public Function PrimeraFechaIngreso(ByVal IDEstiba As Integer, ByVal CodAlmacen As String) As DataTable
            Dim Dt As New DataTable
            Dim prm As SqlParameter
            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MinFechaIngreso]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                prm = New SqlParameter("@idestiba", IDEstiba)
                comando.Parameters.Add(prm)

                prm = New SqlParameter("@codalmacen", CodAlmacen)
                comando.Parameters.Add(prm)


                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Reportes Almacén")
                Dt = Nothing
            Finally
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty

            End Try
            Return Dt
        End Function

        Public Function NuevoControlStockEstiba(ByVal OControlStockEstiba As Control_Stock_Estiba) As Boolean
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_NuevoControlStockEstiba]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                With OControlStockEstiba

                    param = New SqlParameter("@codalmacen", .CodAlmacen)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@idestiba", .IDEstiba)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@fechainicial", .FechaInicial)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@fechafinal", .FechaFinal)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@stkinicial", .StockInicial)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@stkfinal", .StockFinal)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@stkfinalreal", .StockFinalReal)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@comentario", IIf(.Comentario.Trim.Length = 0, DBNull.Value, .Comentario))
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@detalles", IIf(.XMLControlStockEstiba.Trim.Length = 0, DBNull.Value, .XMLControlStockEstiba)) 'para necesario para el sp
                    comando.Parameters.Add(param)
                End With


                If comando.Connection.State = ConnectionState.Closed Then
                    comando.Connection.Open()
                End If


                Dr = comando.ExecuteReader(CommandBehavior.CloseConnection)

                Dr.Read()
                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Control Stock Estiba")

                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Control Stock Estiba")
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

        Public Function EliminarControlStockEstiba(ByVal IDControl As Integer) As Boolean
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_EliminarControlStockEstiba]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@IdControl", IDControl)
                comando.Parameters.Add(param)


                If comando.Connection.State = ConnectionState.Closed Then
                    comando.Connection.Open()
                End If


                Dr = comando.ExecuteReader(CommandBehavior.CloseConnection)

                Dr.Read()
                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Control Stock Estiba")

                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Control Stock Estiba")
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

    End Class

End Namespace


