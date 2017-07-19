Imports System.Data.SqlClient
Imports GEACEntidades.Almacen
Imports PoolConexiones

Namespace DAOAlmacen

    Public Class DAOProductosXAlmacen
        Private Advertencia As String = String.Empty


#Region "Mantenimiento de Datos"

        Public Function AsignarNivelProducto(ByVal oProductoXAlmacen As Productos_X_Almacen) As Boolean
            Dim valor As Boolean = True

            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Lector As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_NuevoAsignacionNivelProducto]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                With oProductoXAlmacen

                    param = New SqlParameter("@codproducto", .CodProducto)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@xmlasignaciones", IIf(.XMLProductosXAlmacen.Trim.Length = 0, DBNull.Value, .XMLProductosXAlmacen))
                    comando.Parameters.Add(param)

                End With

                If comando.Connection.State = ConnectionState.Closed Then
                    comando.Connection.Open()
                End If

                Lector = comando.ExecuteReader(CommandBehavior.CloseConnection)
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
                param = Nothing
                comando.Dispose()
                comando = Nothing
            End Try

            Return Retorno

        End Function

        Public Function QuitarNivelProducto(ByVal CodProducto As String, ByVal Nivel As String) As Boolean
            Dim valor As Boolean = True

            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Lector As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_QuitarAsignacionNivelProducto]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                '   With oProductoXAlmacen

                param = New SqlParameter("@codproducto", CodProducto)
                comando.Parameters.Add(param)

                param = New SqlParameter("@nivel", Nivel)
                comando.Parameters.Add(param)

                ' End With

                If comando.Connection.State = ConnectionState.Closed Then
                    comando.Connection.Open()
                End If

                Lector = comando.ExecuteReader(CommandBehavior.CloseConnection)
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
                param = Nothing
                comando.Dispose()
                comando = Nothing
            End Try

            Return Retorno

        End Function

#End Region





    End Class



End Namespace


