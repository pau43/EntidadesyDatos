Imports System.Text
'Imports System.IO
Imports System.Data.SqlClient
Imports PoolConexiones
Imports GEACEntidades.Almacen
Imports GEACEntidades


Namespace DAOAlmacen
    Public Class DAOEquipamientoEstibas
        Private Advertencia As String = String.Empty
#Region "Carga de datos"

        Public Function CargarEquipamientoEstiba(ByVal CodAlmacen As String) As DataTable ' cambiado a por almacen
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter

            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_VerEquipamientoEstibas]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@codalmacen", CodAlmacen)
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

        Public Function CargarEquipamientoEstiba() As DataTable ' cambiado a por almacen
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            'Dim param As SqlParameter

            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_VerEquipamientoEstibas]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                'param = New SqlParameter("@codalmacen", CodAlmacen)
                'comando.Parameters.Add(param)


                Da = New SqlDataAdapter(comando)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Equipamiento Estibas")
                tabla = Nothing
            Finally

                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                'param = Nothing
            End Try

            Return tabla
        End Function

        Public Function CargarNotasEquipamientoEstiba() As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter

            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_VerNotasEquipamientoEstiba]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@idsucursal", SesionUsuario.IDSucursal) ' el idsucursal para las notas de solicitud
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

        'Public Function CargarEquiposEnStock(ByVal IDSucursal As Integer) As DataTable
        '    Dim tabla As New DataTable
        '    Dim comando As New SqlCommand
        '    Dim param As SqlParameter
        '    Dim Da As SqlDataAdapter
        '    Dim StrComando = "[Almacen].[SpAlm_VerEquiposEnStock]"
        '    Try

        '        comando.CommandText = StrComando
        '        comando.Connection = TSQL.ConexionPermanente
        '        comando.CommandType = CommandType.StoredProcedure

        '        param = New SqlParameter("@idsucursal", IDSucursal)
        '        comando.Parameters.Add(param)


        '        Da = New SqlDataAdapter(comando)
        '        Da.Fill(tabla)

        '    Catch ex As Exception
        '        MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Equipamiento Estibas")
        '        tabla = Nothing
        '    Finally

        '        Da = Nothing
        '        comando = Nothing
        '        StrComando = String.Empty
        '        param = Nothing

        '    End Try

        '    Return tabla
        'End Function

        'Public Function VerStock(ByVal IDSucursal As Integer) As DataTable
        '    Dim tabla As New DataTable
        '    Dim comando As New SqlCommand
        '    Dim param As SqlParameter
        '    Dim Da As SqlDataAdapter
        '    Dim StrComando = "[Almacen].[SpAlm_VerEquiposEnStock]"
        '    Try

        '        comando.CommandText = StrComando
        '        comando.Connection = TSQL.ConexionPermanente
        '        comando.CommandType = CommandType.StoredProcedure

        '        param = New SqlParameter("@idsucursal", IDSucursal)
        '        comando.Parameters.Add(param)


        '        Da = New SqlDataAdapter(comando)
        '        Da.Fill(tabla)

        '    Catch ex As Exception
        '        MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Equipamiento Estibas")
        '        tabla = Nothing
        '    Finally

        '        Da = Nothing
        '        comando = Nothing
        '        StrComando = String.Empty
        '        param = Nothing

        '    End Try
        '    Return tabla
        'End Function

        Public Function VerEquiposEstibaXSucursal(ByVal IDSucursal As Integer) As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_VerEquiposEstibaXSucursal]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@idsucursal", IDSucursal)
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

        Public Function VerEquiposXNroAutorizacion(ByVal NroAutorizacion As String) As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter

            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_VerEquiposXNroAutorizacion]"
            Try
                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@nroautorizacion", NroAutorizacion)
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
                'param = Nothing
            End Try

            Return tabla
        End Function

        Public Function VerEquiposXIDTriaje(ByVal IDTriaje As Integer) As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter

            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_VerEquiposXIDTriaje]"
            Try
                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@idtriaje", IDTriaje)
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
                'param = Nothing
            End Try

            Return tabla
        End Function

#End Region

#Region "Mantenimiento de datos"

        Public Function NuevaSolicitudEstiba(ByVal NSalidaEstiba As Salidas_Estiba) As Boolean 'utilizado tanto para solicitar como para devolver
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_NuevaSolicitudEstiba]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                With NSalidaEstiba


                    param = New SqlParameter("@fechasolicitud", .FechaSolicitud)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@solicitante", .Solicitante)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@idarea", .IDArea)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@iddestino", .IDDestino)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@idchofer", .IDChofer)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@idremolcador", .IDRemolcador)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@idsemiremolque", IIf(.IDSemiRemolque <= 0, DBNull.Value, .IDSemiRemolque))
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@carga", IIf(.Carga.Trim.Length = 0, DBNull.Value, .Carga))
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@observaciones", IIf(.Observaciones.Trim.Length = 0, DBNull.Value, .Observaciones))
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@codalmentrega", .CodAlmEntrega)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@idsucursalentrega", SesionUsuario.IDSucursal) 'para necesario para el sp
                    comando.Parameters.Add(param)


                    param = New SqlParameter("@movsalestiba", IIf(.XMLMovSal_Estiba.Trim.Length = 0, DBNull.Value, .XMLMovSal_Estiba)) 'para necesario para el sp
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
                    Dr.Close() ' al cerrar el datareader tambien cierra el comando asociado
                End If

                Dr = Nothing
                param = Nothing
                comando.Dispose()
                comando = Nothing

            End Try

            Return Retorno

        End Function

        Public Function ModificarSolicitudEstiba(ByVal NSalidaEstiba As Salidas_Estiba) As Boolean 'utilizado tanto para solicitar como para devolver
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_ModificarSolicitudEstiba]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                With NSalidaEstiba


                    param = New SqlParameter("@idsalestiba", .IDSalEstiba)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@fechasolicitud", .FechaSolicitud)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@solicitante", .Solicitante)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@idarea", .IDArea)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@iddestino", .IDDestino)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@idchofer", .IDChofer)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@idremolcador", .IDRemolcador)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@idsemiremolque", IIf(.IDSemiRemolque <= 0, DBNull.Value, .IDSemiRemolque))
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@carga", .Carga)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@observaciones", IIf(.Observaciones.Trim.Length = 0, DBNull.Value, .Observaciones))
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@codalmentrega", .CodAlmEntrega)
                    comando.Parameters.Add(param)


                    param = New SqlParameter("@movsalestiba", IIf(.XMLMovSal_Estiba.Trim.Length = 0, DBNull.Value, .XMLMovSal_Estiba))
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

        Public Function ModificarSolicitudEstibaEntregada(ByVal NSalidaEstiba As Salidas_Estiba) As Boolean 'utilizado tanto para solicitar como para devolver
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_ModificarSalidaEstibaEntregada]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                With NSalidaEstiba

                    param = New SqlParameter("@idsalestiba", .IDSalEstiba)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@iddestino", .IDDestino)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@idchofer", .IDChofer)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@idremolcador", .IDRemolcador)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@carga", .Carga)
                    comando.Parameters.Add(param)

                End With

                Dr = comando.ExecuteReader
                Dr.Read()

                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Modificación")


                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Modificación")
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

        Public Function DarPorEntregadoSolicitudEstiba(ByVal IDSalEstiba As Integer, ByVal FechaEntrega As Date) As Boolean 'utilizado tanto para solicitar como para devolver
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_DarPorEntregadoEstiba]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure




                param = New SqlParameter("@idsalestiba", IDSalEstiba)
                comando.Parameters.Add(param)
                param = New SqlParameter("@fentrega", FechaEntrega)
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

        Public Function EliminarSolicitudEstiba(ByVal IDSalEstiba As Integer) As Boolean 'utilizado tanto para solicitar como para devolver
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_EliminarSolicitudEstiba]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@idsalestiba", IDSalEstiba)
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

        Public Function AnularSolicitudEstiba(ByVal IDSalEstiba As Integer, ByVal MotivoAnulacion As String) As Boolean 'solo se pueden anular las notas con estado de solicitud entregado
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_AnularNotaSalidaEstiba]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@idsalestiba", IDSalEstiba)
                comando.Parameters.Add(param)

                param = New SqlParameter("@motivoanulacion", IIf(MotivoAnulacion.Trim.Length = 0, DBNull.Value, MotivoAnulacion))
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
        Public Function DevolverEquipamientoEstiba(ByVal NSalidaEstiba As Salidas_Estiba) As Boolean 'utilizado tanto para solicitar como para devolver
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_DevolverEstiba]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                With NSalidaEstiba


                    param = New SqlParameter("@idsalestiba", .IDSalEstiba)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@fechadevolucion", .FechaDevolucion)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@codalmrecepciona", .CodAlmRecepciona)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@idsucursalrecepciona", SesionUsuario.IDSucursal)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@movsalestiba", IIf(.XMLMovSal_Estiba.Trim.Length = 0, DBNull.Value, .XMLMovSal_Estiba))
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
#Region "Consultas" 'Reportes

        Public Function ConsultaSalidasEquiposEstiba(ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_ConsultaSalidasEquiposEstiba]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@fechaini", FechaInicio)
                comando.Parameters.Add(param)

                param = New SqlParameter("@fechafin", FechaFin)
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

        Public Function ConsultaStockEquiposEstiba(ByVal IDSucursal As Integer, ByVal CodAlmacen As String) As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_ConsultaStockEquiposEstiba]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@idsucursal", IIf(IDSucursal <= 0, DBNull.Value, IDSucursal))
                comando.Parameters.Add(param)

                param = New SqlParameter("@codalmacen", IIf(CodAlmacen = String.Empty, DBNull.Value, CodAlmacen))
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

        Public Function ConsultaEntradasSalidasEquiposEstiba(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal Tipo As String) As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_ConsultaEntradasSalidasEquiposEstiba]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@fechaini", FechaInicio)
                comando.Parameters.Add(param)

                param = New SqlParameter("@fechafin", FechaFin)
                comando.Parameters.Add(param)

                param = New SqlParameter("@tipo", IIf(Tipo.Trim.Length = 0, DBNull.Value, Tipo))
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

        Public Function ConsultaMovimientoKardexEquiposEstiba(ByVal IDEstiba As Integer, ByVal CodAlmacen As String, ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "Almacen.SpAlm_ConsultaMovimientoEquiposEstiba"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure


                param = New SqlParameter("@idestiba", IIf(IDEstiba <= 0, DBNull.Value, IDEstiba))
                comando.Parameters.Add(param)


                param = New SqlParameter("@codalmacen", IIf(CodAlmacen.Trim.Length = 0, DBNull.Value, CodAlmacen))
                comando.Parameters.Add(param)


                param = New SqlParameter("@finicial", FechaInicio)
                comando.Parameters.Add(param)

                param = New SqlParameter("@ffinal", FechaFin)
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

        Public Function ConsultaNotasEquiposEstibaEntregados(ByVal IDSucursal As Integer, ByVal IDDestino As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter

            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_ConsultaNotasEquiEstibaEntregadas]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@idsucursal", IIf(IDSucursal <= 0, DBNull.Value, IDSucursal))
                comando.Parameters.Add(param)

                param = New SqlParameter("@iddestino", IIf(IDDestino <= 0, DBNull.Value, IDDestino))
                comando.Parameters.Add(param)

                param = New SqlParameter("@finicio", FechaInicio)
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

        Public Function ConsultaNotasEquiposEstibaDevueltas(ByVal IDSucursal As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal CodAlmacen As String) As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter

            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_ConsultaNotasEquiEstibaDevueltas]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@idsucursal", IIf(IDSucursal <= 0, DBNull.Value, IDSucursal))
                comando.Parameters.Add(param)

                param = New SqlParameter("@finicio", FechaInicio)
                comando.Parameters.Add(param)

                param = New SqlParameter("@ffin", FechaFin)
                comando.Parameters.Add(param)


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

        Public Function VerificarSiTieneEquiposEstiba(ByVal IDPersona As Integer) As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_VerificarSiTieneEquiposEstiba]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@idpersona", IIf(IDPersona <= 0, DBNull.Value, IDPersona))
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

        Public Function ConsultaAlmacenEstibaTriaje_Salidas(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal CodAlmacen As String) As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_ConsultaAlmacenEstibaTriaje_Salidas]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@finicial", FechaInicio)
                comando.Parameters.Add(param)

                param = New SqlParameter("@ffinal", FechaFin)
                comando.Parameters.Add(param)

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

        Public Function ConsultaStockEquiposXFecha(ByVal FechaDesde As Date, ByVal CodAlmacen As String) As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_ConsultaStockEquiposXFecha]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure


                param = New SqlParameter("@fechadesde", FechaDesde)
                comando.Parameters.Add(param)

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

        Public Function ConsultaMovimientoEquiposEstibaSalidas(ByVal IDEstiba As Integer, ByVal CodAlmacen As String, ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_ConsultaMovimientoEquiposEstibaSalidas]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure


                param = New SqlParameter("@idestiba", IIf(IDEstiba <= 0, DBNull.Value, IDEstiba))
                comando.Parameters.Add(param)


                param = New SqlParameter("@codalmacen", IIf(CodAlmacen.Trim.Length = 0, DBNull.Value, CodAlmacen))
                comando.Parameters.Add(param)


                param = New SqlParameter("@finicial", FechaInicio)
                comando.Parameters.Add(param)

                param = New SqlParameter("@ffinal", FechaFin)
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

        Public Function ConsultaMovimientoEstibaXDia(ByVal IDEstiba As Integer, ByVal CodAlmacen As String, ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_ConsultaMovimientoEstibaXDia]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure


                param = New SqlParameter("@idestiba", IIf(IDEstiba <= 0, DBNull.Value, IDEstiba))
                comando.Parameters.Add(param)


                param = New SqlParameter("@codalmacen", IIf(CodAlmacen.Trim.Length = 0, DBNull.Value, CodAlmacen))
                comando.Parameters.Add(param)


                param = New SqlParameter("@finicial", FechaInicio)
                comando.Parameters.Add(param)

                param = New SqlParameter("@ffinal", FechaFin)
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

        Public Function ConsultaKardexMovimientoEquiEstiba(ByVal IDEstiba As Integer, ByVal CodAlmacen As String, ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_ConsultaKardexMovimientoEquiEstiba]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure


                param = New SqlParameter("@idestiba", IIf(IDEstiba <= 0, DBNull.Value, IDEstiba))
                comando.Parameters.Add(param)


                param = New SqlParameter("@codalmacen", IIf(CodAlmacen.Trim.Length = 0, DBNull.Value, CodAlmacen))
                comando.Parameters.Add(param)


                param = New SqlParameter("@finicial", FechaInicio)
                comando.Parameters.Add(param)

                param = New SqlParameter("@ffinal", FechaFin)
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

        Public Function ConsultaIngresosEquiposEstiba(ByVal CodAlmacen As String, ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter

            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_ConsultaIngresosEquiposEstiba]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@codalmacen", IIf(CodAlmacen.Trim.Length = 0, DBNull.Value, CodAlmacen))
                comando.Parameters.Add(param)

                param = New SqlParameter("@fechainicio", FechaInicio)
                comando.Parameters.Add(param)

                param = New SqlParameter("@fechafin", FechaFin)
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



#End Region


    End Class

End Namespace



