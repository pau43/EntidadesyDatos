Imports System.Data.SqlClient
Imports PoolConexiones
Imports GEACEntidades.Almacen
'Imports GEACEntidades.EAlmacen


Namespace DAOAlmacen

    Public Class DAOMaestroEquiposAuxiliares
        Private Advertencia As String = String.Empty

#Region "Carga de Datos"


        Public Function MostrarEquiposAlmAuxiliar() As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand


            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarEquiposAlmAuxiliar]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure



                Da = New SqlDataAdapter(comando)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Equipos Almacén Auxiliar")
                tabla = Nothing
            Finally

                Da = Nothing
                comando = Nothing
                StrComando = String.Empty


            End Try

            Return tabla
        End Function

        Public Function LlenarFormEquipoAuxiliar() As DataTable

            Dim tabla As New DataTable
            Dim comando As New SqlCommand


            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_LlenarFormEquipoAuxiliar]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure



                Da = New SqlDataAdapter(comando)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Equipos Almacén Auxiliar")
                tabla = Nothing
            Finally

                Da = Nothing
                comando = Nothing
                StrComando = String.Empty


            End Try

            Return tabla
        End Function

        Public Function MostrarCodigosSinMapear(ByVal OMapeo As Equipamiento_Auxiliar.Mapeo_EqAuxiliares) As DataTable

            Dim tabla As New DataTable
            Dim param As SqlParameter
            Dim comando As New SqlCommand

            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarCodigosSinMapear]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                With OMapeo


                    param = New SqlParameter("@nivel", .Nivel)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@idtipoproducto", .IDTipoProducto)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@idfraccion", .IDFraccion)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@idequipo", .IDEquipo)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@secodifica", .SeCodifica)
                    comando.Parameters.Add(param)


                End With


                Da = New SqlDataAdapter(comando)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Equipos Almacén Auxiliar")
                tabla = Nothing
            Finally

                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                param = Nothing

            End Try

            Return tabla
        End Function

        Public Function MostrarProductosAsignadosXEquipo(ByVal IDEquipo As Integer) As DataTable
            Dim tabla As New DataTable
            Dim param As SqlParameter
            Dim comando As New SqlCommand


            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarProductosAsignadosXEquipo]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@idequipo", IDEquipo)
                comando.Parameters.Add(param)

                Da = New SqlDataAdapter(comando)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Equipos Almacén Auxiliar")
                tabla = Nothing
            Finally

                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                param = Nothing

            End Try

            Return tabla
        End Function






#End Region


#Region "Mantenimiento de Datos"


        Public Function NuevoEquipoAlmAuxiliar(ByVal NEquipoAuxiliar As Equipamiento_Auxiliar) As Boolean 'utilizado tanto para solicitar como para devolver
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_NuevoEquipoAlmAuxiliar]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                With NEquipoAuxiliar


                    param = New SqlParameter("@CodEquipo", .CodEquipo)
                    comando.Parameters.Add(param)


                    param = New SqlParameter("@Descripcion", .Descripcion)
                    comando.Parameters.Add(param)


                    param = New SqlParameter("@IdTipoProd", .IDTipoProducto)
                    comando.Parameters.Add(param)



                    param = New SqlParameter("@IdFraccion", .IDFraccion)
                    comando.Parameters.Add(param)


                    param = New SqlParameter("@SeCodifica", .SeCodifica)
                    comando.Parameters.Add(param)


                    param = New SqlParameter("@Nivel", .Nivel)
                    comando.Parameters.Add(param)


                End With

                If comando.Connection.State = ConnectionState.Closed Then
                    comando.Connection.Open()
                End If

                Dr = comando.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()

                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Equipos Auxiliares")

                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Equipos Auxiliares")
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


        Public Function ModificarEquipoAlmAuxiliar(ByVal NEquipoAuxiliar As Equipamiento_Auxiliar) As Boolean 'utilizado tanto para solicitar como para devolver
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_ModificarEquipoAlmAuxiliar]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                With NEquipoAuxiliar



                    param = New SqlParameter("@IdEquipo", .IDEquipo)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@CodEquipo", .CodEquipo)
                    comando.Parameters.Add(param)


                    param = New SqlParameter("@Descripcion", .Descripcion)
                    comando.Parameters.Add(param)


                End With

                If comando.Connection.State = ConnectionState.Closed Then
                    comando.Connection.Open()
                End If

                Dr = comando.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()

                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Equipos Auxiliares")

                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Equipos Auxiliares")
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


        Public Function EliminarEquipoAlmAuxiliar(ByVal IDEquipo As Integer) As Boolean
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_EliminarEquipoAlmAuxiliar]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure


                param = New SqlParameter("@IdEquipo", IDEquipo)
                comando.Parameters.Add(param)


                If comando.Connection.State = ConnectionState.Closed Then
                    comando.Connection.Open()
                End If

                Dr = comando.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()

                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Equipos Auxiliares")

                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Equipos Auxiliares")
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


        Public Function AsignarCodigosAlmAuxiliar(ByVal oEquipamientoAuxiliar As Equipamiento_Auxiliar) As Boolean
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_AsignarCodigosAlmAuxiliar]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure



                param = New SqlParameter("@IdEquipo", oEquipamientoAuxiliar.IDEquipo)
                comando.Parameters.Add(param)

                param = New SqlParameter("@xCodigos", oEquipamientoAuxiliar.XMLMapeoEqAuxiliares)
                comando.Parameters.Add(param)




                If comando.Connection.State = ConnectionState.Closed Then
                    comando.Connection.Open()
                End If

                Dr = comando.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()

                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Equipos Auxiliares")

                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Equipos Auxiliares")
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

        Public Function QuitarCodigosAlmAuxiliara(ByVal IDEquipo As Integer, ByVal CodProducto As String) As Boolean
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_QuitarCodigosAlmAuxiliar]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure


                param = New SqlParameter("@IdEquipo", IDEquipo)
                comando.Parameters.Add(param)

                param = New SqlParameter("@CodProducto", CodProducto)
                comando.Parameters.Add(param)


                If comando.Connection.State = ConnectionState.Closed Then
                    comando.Connection.Open()
                End If

                Dr = comando.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()

                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Equipos Auxiliares")

                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Equipos Auxiliares")
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


