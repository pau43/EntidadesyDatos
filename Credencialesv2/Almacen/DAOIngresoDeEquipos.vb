Imports PoolConexiones
Imports System.Data.SqlClient
Imports GEACEntidades.Almacen

Namespace DAOAlmacen

    Public Class DAOIngresoDeEquipos

        Private Advertencia As String = String.Empty


#Region "Lectura de Datos"

        Public Function ListarNotasDeSalida() As DataTable
            Dim Dt As New DataTable
            Dim oPrm As SqlParameter
            Dim oCmd As New SqlCommand
            Dim Da As SqlDataAdapter

            Try

                oCmd.CommandText = "Almacen.SpAlm_ListarNotasDeSalida"
                oCmd.Connection = TSQL.ConexionPermanente
                oCmd.CommandType = CommandType.StoredProcedure

                oPrm = New SqlParameter("@IDSucursal", GEACEntidades.SesionUsuario.IDSucursal)

                Da = New SqlDataAdapter(oCmd)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Listar Notas de Salida")
                Dt = Nothing
            Finally
                Da = Nothing
                oCmd = Nothing
                oPrm = Nothing
            End Try

            Return Dt

        End Function

        Public Function ListarIngresosRegistrados(ByVal CodEmisor As String, ByVal CodReceptor As String, ByVal FInicio As Date, ByVal FFin As Date, ByVal Busqueda As Integer) As DataTable
            Dim Dt As New DataTable
            Dim oPrm As SqlParameter
            Dim oCmd As New SqlCommand
            Dim Da As SqlDataAdapter

            Try

                oCmd.CommandText = "Almacen.SpAlm_ListarIngresosAAlmacenEstibas"
                oCmd.Connection = TSQL.ConexionPermanente
                oCmd.CommandType = CommandType.StoredProcedure

                If CodReceptor.Trim.Length < 1 Then
                    oPrm = New SqlParameter("@CodReceptor", DBNull.Value)
                Else
                    oPrm = New SqlParameter("@CodReceptor", CodReceptor)
                End If
                oCmd.Parameters.Add(oPrm)

                If CodEmisor.Trim.Length < 1 Then
                    oPrm = New SqlParameter("@CodEmisor", DBNull.Value)
                Else
                    oPrm = New SqlParameter("@CodEmisor", CodEmisor)
                End If
                oCmd.Parameters.Add(oPrm)

                If FInicio = Nothing Then
                    oPrm = New SqlParameter("@FInicio", DBNull.Value)
                    oCmd.Parameters.Add(oPrm)
                    oPrm = New SqlParameter("@FFin", DBNull.Value)
                    oCmd.Parameters.Add(oPrm)
                Else
                    oPrm = New SqlParameter("@FInicio", FInicio.ToShortDateString)
                    oCmd.Parameters.Add(oPrm)
                    oPrm = New SqlParameter("@FFin", FFin.ToShortDateString)
                    oCmd.Parameters.Add(oPrm)
                End If

                oPrm = New SqlParameter("@Busqueda", Busqueda)
                oCmd.Parameters.Add(oPrm)

                oPrm = New SqlParameter("@IDSucursal", GEACEntidades.SesionUsuario.IDSucursal)
                oCmd.Parameters.Add(oPrm)

                Da = New SqlDataAdapter(oCmd)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Listar Notas de Salida")
                Dt = Nothing
            Finally
                Da = Nothing
                oCmd = Nothing
                oPrm = Nothing
            End Try

            Return Dt

        End Function

        Public Function CargarEquipamientoEstiba() As DataTable ' cambiado a por almacen
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            'Dim param As SqlParameter

            Dim Da As SqlDataAdapter
            Dim StrComando = "Almacen.SpAlm_VerEquipamientoEstibas"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

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

#Region "Mantenimiento de Datos"

        Public Function NuevoIngresoDeEquipos(ByVal oIngresoEquipo As IngresoDeEquipos) As Boolean

            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            With oIngresoEquipo

                Try

                    Cmd.CommandText = "Almacen.SpAlm_NuevoIngresoEquiposEstiba"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure

                    Prm = New SqlParameter("@fingreso", .FechaIngreso.ToShortDateString)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@codalmrecibe", .CodigoAlmacenReceptor)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@observaciones", .Observaciones)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@eqestiba", .XMLEquipos)
                    Cmd.Parameters.Add(Prm)

                    If .IDNotaDeAlmacen > 0 Then
                        Prm = New SqlParameter("@idnotaalmacen", .IDNotaDeAlmacen)
                    Else
                        Prm = New SqlParameter("@idnotaalmacen", DBNull.Value)
                    End If
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@IDSucursal", GEACEntidades.SesionUsuario.IDSucursal)
                    Cmd.Parameters.Add(Prm)


                    Prm = New SqlParameter("@IDPersona", IIf(.IDPersona <= 0, DBNull.Value, .IDPersona))
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@CodMovi", IIf(.CodMovi.Trim.Length = 0, DBNull.Value, .CodMovi))
                    Cmd.Parameters.Add(Prm)

                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If

                    Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)

                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Nuevo Ingreso De Equipos")
                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Nuevo Ingreso De Equipos")
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

        Public Function ModificarIngresoDeEquipos(ByVal oIngresoEquipo As IngresoDeEquipos) As Boolean

            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            With oIngresoEquipo

                Try

                    Cmd.CommandText = "Almacen."
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure

                    Prm = New SqlParameter("@IDIngreso", .IDIngreso)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@fingreso", .FechaIngreso.ToShortDateString)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@codalmrecibe", .CodigoAlmacenReceptor)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@observaciones", .Observaciones)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@eqestiba", .XMLEquipos)
                    Cmd.Parameters.Add(Prm)

                    If .IDNotaDeAlmacen > 0 Then
                        Prm = New SqlParameter("@idnotaalmacen", .IDNotaDeAlmacen)
                    Else
                        Prm = New SqlParameter("@idnotaalmacen", DBNull.Value)
                    End If
                    Cmd.Parameters.Add(Prm)

                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If


                    Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)

                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Modificar Ingreso")
                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Modificar Ingreso")
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

        Public Function EliminarIngresoDeEquipos(ByVal IDIngreso As Integer) As Boolean

            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try

                Cmd.CommandText = "Almacen.SpAlm_EliminarIngresoEquiposEstiba"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@idingestiba", IDIngreso)
                Cmd.Parameters.Add(Prm)

                If Cmd.Connection.State = ConnectionState.Closed Then
                    Cmd.Connection.Open()
                End If

                Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)

                Dr.Read()

                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Eliminar Ingreso de Estiba")
                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Eliminar Ingreso de Estiba")
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

#End Region


    End Class

End Namespace
