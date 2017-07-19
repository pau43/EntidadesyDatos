Imports System.Text
Imports System.IO
Imports System.Data.SqlClient
Imports PoolConexiones
Imports GEACEntidades.Almacen
Imports GEACEntidades

Namespace DAOAlmacen

    Public Class DAODevolucionesAAlmacenCentral
        Private Advertencia As String = String.Empty

        Public Function MostrarDevolucionesACentral(ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
            Dim Dt As New DataTable
            Dim prm As SqlParameter
            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarDevolucionesACentralEstiba]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                prm = New SqlParameter("@fechainicio", FechaInicio)
                comando.Parameters.Add(prm)

                prm = New SqlParameter("@fechafin", FechaFin)
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

        Public Function NuevaDevolucionesEquipos(ByVal ODevoluciones As Devoluciones_Estiba) As Boolean
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_NuevaDevolucionACentral]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                With ODevoluciones

                    param = New SqlParameter("@fechadevolucion", .FechaDevolucion)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@codmovi", .CodMovi)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@codalmorigen", .CodAlmacenOrigen)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@codalmdestino", .CodAlmacenDestino)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@observaciones", IIf(.Observaciones.Trim.Length = 0, DBNull.Value, .Observaciones))
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@detalles", IIf(.XMLDetalles_Devoluciones.Trim.Length = 0, DBNull.Value, .XMLDetalles_Devoluciones)) 'para necesario para el sp
                    comando.Parameters.Add(param)
                End With


                If comando.Connection.State = ConnectionState.Closed Then
                    comando.Connection.Open()
                End If


                Dr = comando.ExecuteReader(CommandBehavior.CloseConnection)

                Dr.Read()
                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Devoluciones Equipos")

                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Devoluciones Equipos")
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

        Public Function EliminarDevolucionesACentral(ByVal IDDevEstiba As Integer) As Boolean

            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_EliminarDevolucionACentral]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@iddevestiba", IDDevEstiba)
                comando.Parameters.Add(param)

                If comando.Connection.State = ConnectionState.Closed Then
                    comando.Connection.Open()
                End If

                Dr = comando.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()

                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Devoluciones Equipos")
                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Devoluciones Equipos")
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

