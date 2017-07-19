Imports System.Data.SqlClient
Imports GEACEntidades.Almacen
Imports PoolConexiones

Namespace DAOAlmacen

    Public NotInheritable Class DAOControlKardexEstiba

        Private Sub New()
        End Sub

        Private Shared _InstanciaControlKardexEstiba As DAOControlKardexEstiba = Nothing
        Public Advertencia As String = String.Empty

        'Instancia unica de la clase
        Public Shared ReadOnly Property Instancia() As DAOControlKardexEstiba
            Get
                If _InstanciaControlKardexEstiba Is Nothing Then
                    _InstanciaControlKardexEstiba = New DAOControlKardexEstiba
                End If
                Return _InstanciaControlKardexEstiba
            End Get
        End Property


        Public Function fdu_LlenarFormControlNotasEstiba(ByVal Usuario As String) As DataTable
            Dim dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_LlenarFormControlNotasEstiba]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@User", Usuario)

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(dt)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Return Nothing
            Finally
                Cmd.Dispose()
                Cmd = Nothing
                If Not IsNothing(Da) Then
                    Da.Dispose()
                    Da = Nothing
                End If
            End Try

            Return dt

        End Function

        Public Function fdu_CargarTiposMovimiento(ByVal TipoMovi As String) As DataTable
            Dim Dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_TipoDeMovimientoEstiba]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                If TipoMovi.Trim.Length > 0 Then
                    Cmd.Parameters.AddWithValue("@TipoMovi", TipoMovi)
                End If

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(Dt)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Dt = Nothing
            Finally
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Dt

        End Function

        Public Function fdu_VerAlmacenesEstiba() As DataTable
            Dim xDt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing
            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_VerAlmacenesEstiba]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure
                Da = New SqlDataAdapter(Cmd)
                Da.Fill(xDt)
            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Return Nothing
            Finally
                Cmd.Dispose()
                Cmd = Nothing
                If Not IsNothing(Da) Then
                    Da.Dispose()
                    Da = Nothing
                End If
            End Try
            Return xDt
        End Function

#Region "Vista Vales Pendientes"

        Public Function fdu_VerPersonalConSolicitudesPendientes(ByVal TextoBusca As String) As DataTable
            Dim dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_VerPersonalConSolicitudesPendientes]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                If TextoBusca.Trim.Length > 0 Then
                    Cmd.Parameters.AddWithValue("@Texto", TextoBusca)
                End If

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(dt)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Return Nothing
            Finally
                Cmd.Dispose()
                Cmd = Nothing
                If Not IsNothing(Da) Then
                    Da.Dispose()
                    Da = Nothing
                End If
            End Try

            Return dt

        End Function

        Public Function fdu_VerSolicitudesPendientesPorPersonal(ByVal IDResponsable As Integer) As DataTable
            Dim Dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_VerSolicitudesPendientesPorPersonal]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@IDResp", IDResponsable)

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(Dt)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Return Nothing
            Finally
                Cmd.Dispose()
                Cmd = Nothing
                If Not IsNothing(Da) Then
                    Da.Dispose()
                    Da = Nothing
                End If
            End Try

            Return Dt

        End Function

        Public Function fdu_VerEquiposEstibaPorSolicitud(ByVal CodAlmacen As String, ByVal AnioSol As Integer, _
                                                         ByVal NroSol As Integer, ByVal SoloSaldo As Boolean) As DataTable
            Dim dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_VerEquiposEstibaPorSolicitud]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
                Cmd.Parameters.AddWithValue("@ASol", AnioSol)
                Cmd.Parameters.AddWithValue("@NSol", NroSol)
                Cmd.Parameters.AddWithValue("@SoloSaldo", SoloSaldo)

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(dt)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Return Nothing
            Finally
                Cmd.Dispose()
                Cmd = Nothing
                If Not IsNothing(Da) Then
                    Da.Dispose()
                    Da = Nothing
                End If
            End Try

            Return dt

        End Function

#End Region

#Region "Vista Vales Por Personal"

        Public Function fdu_VerPersonalConNotasEstiba(ByVal CodAlmacen As String, ByVal TextoBusca As String, _
                                                            ByVal Desde As Date, ByVal Hasta As Date) As DataTable
            Dim dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_VerPersonalConNotasEstiba]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
                If TextoBusca.Trim.Length > 0 Then
                    Cmd.Parameters.AddWithValue("@Texto", TextoBusca)
                End If
                Cmd.Parameters.AddWithValue("@Desde", Format(Desde, "dd/MM/yyyy"))
                Cmd.Parameters.AddWithValue("@Hasta", Format(Hasta, "dd/MM/yyyy"))

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(dt)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Return Nothing
            Finally
                Cmd.Dispose()
                Cmd = Nothing
                If Not IsNothing(Da) Then
                    Da.Dispose()
                    Da = Nothing
                End If
            End Try

            Return dt

        End Function

        Public Function fdu_VerNotasEstibaPorPersonal(ByVal CodAlmacen As String, ByVal IDResponsable As Integer, _
                                                            ByVal Desde As Date, ByVal Hasta As Date) As DataTable
            Dim dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_VerNotasEstibaPorPersonal]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
                Cmd.Parameters.AddWithValue("@IDResp", IDResponsable)
                Cmd.Parameters.AddWithValue("@Desde", Format(Desde, "dd/MM/yyyy"))
                Cmd.Parameters.AddWithValue("@Hasta", Format(Hasta, "dd/MM/yyyy"))

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(dt)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Return Nothing
            Finally
                Cmd.Dispose()
                Cmd = Nothing
                If Not IsNothing(Da) Then
                    Da.Dispose()
                    Da = Nothing
                End If
            End Try

            Return dt

        End Function

        Public Function fdu_VerKardexEstibaPorNota(ByVal CodAlmacen As String, ByVal CodMov As String, _
                                                         ByVal AnioNota As Integer, ByVal NroNota As Integer) As DataTable
            Dim dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_VerKardexEstibaPorNota]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
                Cmd.Parameters.AddWithValue("@CodMovi", CodMov)
                Cmd.Parameters.AddWithValue("@ANota", AnioNota)
                Cmd.Parameters.AddWithValue("@NNota", NroNota)

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(dt)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Return Nothing
            Finally
                Cmd.Dispose()
                Cmd = Nothing
                If Not IsNothing(Da) Then
                    Da.Dispose()
                    Da = Nothing
                End If
            End Try

            Return dt

        End Function

#End Region

#Region "Solicitudes de Estiba"

        Public Function fdu_NuevaSolicitudEstiba(ByVal oSolicEstiba As SolicitudEstiba, ByRef NroSolicitud As Integer) As Boolean
            Dim Retorno As Boolean = True
            Dim Cmd As New SqlCommand
            Dim Dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_NuevaSolicitudEstiba]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                With oSolicEstiba
                    Cmd.Parameters.AddWithValue("@CodAlmacen", .CodAlmacen)
                    Cmd.Parameters.AddWithValue("@FSolicitud", Format(.Fecha, "dd/MM/yyyy"))
                    Cmd.Parameters.AddWithValue("@Solicitante", IIf(.Solicitante.Trim.Length = 0, DBNull.Value, .Solicitante))
                    Cmd.Parameters.AddWithValue("@IDChofer", .IDResponsable)
                    Cmd.Parameters.AddWithValue("@IDRemolcador", .IDRemolcador)
                    Cmd.Parameters.AddWithValue("@IDSemiRemolque", IIf(.IDSemiRemolque <= 0, DBNull.Value, .IDSemiRemolque))
                    Cmd.Parameters.AddWithValue("@IDDestino", .IDDestino)
                    If .CodServTransporte.Trim.Length > 0 Then
                        Cmd.Parameters.AddWithValue("@CodServTransp", .CodServTransporte.Trim)
                    End If
                    Cmd.Parameters.AddWithValue("@Carga", IIf(.Carga.Trim.Length = 0, DBNull.Value, .Carga))
                    Cmd.Parameters.AddWithValue("@Observacion", IIf(.Observacion.Trim.Length = 0, DBNull.Value, .Observacion))
                    Cmd.Parameters.AddWithValue("@xEquipos", .XMLDetalles)
                    Cmd.Parameters.AddWithValue("@User", GEACEntidades.SesionUsuario.Usuario)
                    Cmd.Parameters.AddWithValue("@NroSol", 0)
                    Cmd.Parameters("@NroSol").Direction = ParameterDirection.Output
                End With

                Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()
                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Retorno = False
            Finally
                If Not Dr Is Nothing Then
                    Dr.Close()
                End If
                NroSolicitud = IIf(Cmd.Parameters("@NroSol").Value Is DBNull.Value, 0, Cmd.Parameters("@NroSol").Value)
                Dr = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno

        End Function

        Public Function fdu_ModificarSolicitudEstiba(ByVal oSolicEstiba As SolicitudEstiba) As Boolean
            Dim Retorno As Boolean = True
            Dim Cmd As New SqlCommand
            Dim Dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_ModificarSolicitudEstiba]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                With oSolicEstiba
                    Cmd.Parameters.AddWithValue("@CodAlmacen", .CodAlmacen)
                    Cmd.Parameters.AddWithValue("@AnioSol", .AnioSolicitud)
                    Cmd.Parameters.AddWithValue("@NroSol", .NroSolicitud)
                    Cmd.Parameters.AddWithValue("@Solicitante", IIf(.Solicitante.Trim.Length = 0, DBNull.Value, .Solicitante))
                    Cmd.Parameters.AddWithValue("@IDRemolcador", .IDRemolcador)
                    Cmd.Parameters.AddWithValue("@IDSemiRemolque", IIf(.IDSemiRemolque <= 0, DBNull.Value, .IDSemiRemolque))
                    Cmd.Parameters.AddWithValue("@IDDestino", .IDDestino)
                    If .CodServTransporte.Trim.Length > 0 Then
                        Cmd.Parameters.AddWithValue("@CodServTransp", .CodServTransporte.Trim)
                    End If
                    Cmd.Parameters.AddWithValue("@Carga", IIf(.Carga.Trim.Length = 0, DBNull.Value, .Carga))
                    Cmd.Parameters.AddWithValue("@Observacion", IIf(.Observacion.Trim.Length = 0, DBNull.Value, .Observacion))
                    Cmd.Parameters.AddWithValue("@User", GEACEntidades.SesionUsuario.Usuario)
                End With

                Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()
                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Retorno = False
            Finally
                If Not Dr Is Nothing Then
                    Dr.Close()
                End If
                Dr = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno

        End Function

        Public Function fdu_AnularSolicitudEstiba(ByVal CodAlmacen As String, ByVal AnioSol As Integer, _
                                                  ByVal NroSol As Integer, ByVal Motivo As String) As Boolean
            Dim Retorno As Boolean = True
            Dim Cmd As New SqlCommand
            Dim Dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_AnularSolicitudEstiba]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
                Cmd.Parameters.AddWithValue("@AnioSol", AnioSol)
                Cmd.Parameters.AddWithValue("@NroSol", NroSol)
                Cmd.Parameters.AddWithValue("@Motivo", Motivo)
                Cmd.Parameters.AddWithValue("@User", GEACEntidades.SesionUsuario.Usuario)

                Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()
                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Retorno = False
            Finally
                If Not Dr Is Nothing Then
                    Dr.Close()
                End If
                Dr = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno

        End Function

        Public Function fdu_DevolverSolicitudEstiba(ByVal oSolicEstiba As SolicitudEstiba) As Boolean
            Dim Retorno As Boolean = True
            Dim Cmd As New SqlCommand
            Dim Dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_DevolverSolicitudEstiba]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                With oSolicEstiba
                    Cmd.Parameters.AddWithValue("@CodAlmSol", .CodAlmacen)
                    Cmd.Parameters.AddWithValue("@AnioSol", .AnioSolicitud)
                    Cmd.Parameters.AddWithValue("@NroSol", .NroSolicitud)
                    Cmd.Parameters.AddWithValue("@CodAlmRecibe", .CodAlmRecepciona)
                    Cmd.Parameters.AddWithValue("@FDevolucion", Format(.Fecha, "dd/MM/yyyy"))
                    Cmd.Parameters.AddWithValue("@Observacion", IIf(.Observacion.Trim.Length = 0, DBNull.Value, .Observacion))
                    Cmd.Parameters.AddWithValue("@xEquipos", .XMLDetalles)
                    Cmd.Parameters.AddWithValue("@User", GEACEntidades.SesionUsuario.Usuario)
                End With

                Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()
                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Retorno = False
            Finally
                If Not Dr Is Nothing Then
                    Dr.Close()
                End If
                Dr = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno

        End Function

        Public Function fdu_DarDeBajaSolicitudEstiba(ByVal CodAlmacen As String, ByVal AnioSol As Integer, _
                                                  ByVal NroSol As Integer, ByVal Comentario As String) As Boolean
            Dim Retorno As Boolean = True
            Dim Cmd As New SqlCommand
            Dim Dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_DarDeBajaSolicitudEstiba]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@CodAlmSol", CodAlmacen)
                Cmd.Parameters.AddWithValue("@AnioSol", AnioSol)
                Cmd.Parameters.AddWithValue("@NroSol", NroSol)
                Cmd.Parameters.AddWithValue("@Observacion", IIf(Comentario.Trim.Length = 0, DBNull.Value, Comentario))
                Cmd.Parameters.AddWithValue("@User", GEACEntidades.SesionUsuario.Usuario)

                Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()
                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Retorno = False
            Finally
                If Not Dr Is Nothing Then
                    Dr.Close()
                End If
                Dr = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno

        End Function

        Public Function fdu_GenerarNotaKardexEstiba(ByVal oNotaAlmEq As NotaAlmacenEstiba) As Boolean
            Dim Retorno As Boolean = True
            Dim Cmd As New SqlCommand
            Dim Dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_GenerarNotaAlmEstiba]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                With oNotaAlmEq
                    Cmd.Parameters.AddWithValue("@CodAlmacen", .CodAlmacen)
                    If .CodMovimiento.Trim.Length > 0 Then
                        Cmd.Parameters.AddWithValue("@CodMovi", .CodMovimiento)
                    End If

                    Cmd.Parameters.AddWithValue("@EsIngreso", .Ingreso)
                    Cmd.Parameters.AddWithValue("@FNota", Format(.Fecha, "dd/MM/yyyy"))
                    Cmd.Parameters.AddWithValue("@Observacion", IIf(.Observacion.Trim.Length = 0, DBNull.Value, .Observacion))
                    Cmd.Parameters.AddWithValue("@xEquipos", .XMLDetalles)
                    Cmd.Parameters.AddWithValue("@User", GEACEntidades.SesionUsuario.Usuario)
                    Cmd.Parameters.AddWithValue("@EsTx", .EsTX)
                    If .CodAlmacenTx.Length > 0 Then
                        Cmd.Parameters.AddWithValue("@CodAlmTx", .CodAlmacenTx)
                    End If
                    If .NroTx > 0 And .AnioTx > 0 Then
                        Cmd.Parameters.AddWithValue("@AnioTx", .AnioTx)
                        Cmd.Parameters.AddWithValue("@NroTx", .NroTx)
                    End If
                    Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    Dr.Read()
                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                End With
            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Retorno = False
            Finally
                If Not Dr Is Nothing Then
                    Dr.Close()
                End If
                Dr = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno

        End Function

        Public Function fdu_AnularNotaKardexEstiba(ByVal CodAlmacen As String, ByVal CodMovi As String, ByVal AnioNota As Integer, _
                                                   ByVal NroNota As Integer, ByVal Motivo As String) As Boolean
            Dim Retorno As Boolean = True
            Dim Cmd As New SqlCommand
            Dim Dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_AnularNotaAlmEstiba]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
                Cmd.Parameters.AddWithValue("@CodMovi", CodMovi)
                Cmd.Parameters.AddWithValue("@AnioNota", AnioNota)
                Cmd.Parameters.AddWithValue("@NroNota", NroNota)
                Cmd.Parameters.AddWithValue("@Motivo", Motivo)
                Cmd.Parameters.AddWithValue("@User", GEACEntidades.SesionUsuario.Usuario)

                Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()
                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Retorno = False
            Finally
                If Not Dr Is Nothing Then
                    Dr.Close()
                End If
                Dr = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno

        End Function

        Public Function fdu_VerEstiba(ByVal CodAlmacen As String, ByVal EnAlmacen As Boolean) As DataTable
            Dim Dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_VerEstiba]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
                Cmd.Parameters.AddWithValue("@EnAlmacen", EnAlmacen)

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(Dt)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Dt = Nothing
            Finally
                Da = Nothing
                Cmd = Nothing
            End Try

            Return Dt

        End Function

        Public Function fdu_RxTxAlmacenCentral(ByVal oNotaAlmEq As NotaAlmacenEstiba) As Boolean
            Dim Retorno As Boolean = True
            Dim Cmd As New SqlCommand
            Dim Dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_RxTxAlmacenCentral]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                With oNotaAlmEq
                    Cmd.Parameters.AddWithValue("@CodAlmacen", .CodAlmacen)
                    Cmd.Parameters.AddWithValue("@FNota", Format(.Fecha, "dd/MM/yyyy"))
                    Cmd.Parameters.AddWithValue("@Observacion", IIf(.Observacion.Trim.Length = 0, DBNull.Value, .Observacion))
                    Cmd.Parameters.AddWithValue("@xEquipos", .XMLDetalles)
                    If .CodAlmacenTx.Length > 0 Then
                        Cmd.Parameters.AddWithValue("@CodAlmTx", .CodAlmacenTx)
                    End If
                    If .NroTx > 0 And .AnioTx > 0 Then
                        Cmd.Parameters.AddWithValue("@AnioTx", .AnioTx)
                        Cmd.Parameters.AddWithValue("@NroTx", .NroTx)
                    End If
                    Cmd.Parameters.AddWithValue("@User", GEACEntidades.SesionUsuario.Usuario)

                    Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    Dr.Read()
                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                End With
            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Retorno = False
            Finally
                If Not Dr Is Nothing Then
                    Dr.Close()
                End If
                Dr = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno

        End Function

#End Region


#Region "Transferencias"

        Public Function fdu_VerTxRecepcionEstiba(ByVal pCodAlmacenTx As String) As DataTable
            Dim xDt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing
            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_VerTxRecepcionEstiba]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@CodAlmacenTx", pCodAlmacenTx)
                Da = New SqlDataAdapter(Cmd)
                Da.Fill(xDt)
            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Return Nothing
            Finally
                Cmd.Dispose()
                Cmd = Nothing
                If Not IsNothing(Da) Then
                    Da.Dispose()
                    Da = Nothing
                End If
            End Try
            Return xDt
        End Function

        

#End Region

        Public Function fdu_VerValesEstiba(ByVal IDResponsable As Integer, ByVal CodMovi As String, ByVal CodAlmacen As String, _
                                                     ByVal Inicio As Date, ByVal Fin As Date, ByVal IDEquipo As Integer, _
                                                     ByVal Remol As String, ByVal SemiRem As String, ByVal idDestino As Integer) As DataTable
            Dim dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing
            Try

                If CodAlmacen.Trim.Length = 0 Then
                    Advertencia = "No seleccionó Almacén."
                    Return Nothing
                End If

                Cmd.CommandText = "[Almacen].[SpAlm_EST_VerValesEstiba]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@IdResp", IIf(IDResponsable = -1, DBNull.Value, IDResponsable))
                Cmd.Parameters.AddWithValue("@CodMov", IIf(CodMovi.Trim.Length = 0, DBNull.Value, CodMovi))
                Cmd.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
                Cmd.Parameters.AddWithValue("@Desde", Format(Inicio, "dd/MM/yyyy"))
                Cmd.Parameters.AddWithValue("@Hasta", Format(Fin, "dd/MM/yyyy"))
                Cmd.Parameters.AddWithValue("@IDEquipo", IIf(IDEquipo = -1, DBNull.Value, IDEquipo))
                Cmd.Parameters.AddWithValue("@Rem", IIf(Remol.Trim.Length = 0, DBNull.Value, Remol))
                Cmd.Parameters.AddWithValue("@SemiRem", IIf(SemiRem.Trim.Length = 0, DBNull.Value, SemiRem))
                Cmd.Parameters.AddWithValue("@IdDestino", IIf(idDestino = -1, DBNull.Value, idDestino))

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(dt)

                If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                    Advertencia = "No se encontraron Datos para Mostrar."
                Else : Advertencia = ""
                End If

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Return Nothing
            Finally
                Cmd.Dispose()
                Cmd = Nothing
                If Not IsNothing(Da) Then
                    Da.Dispose()
                    Da = Nothing
                End If
            End Try
            Return dt
        End Function

        Public Function fdu_VerMapeoEquipo(ByVal CodProducto As String) As DataTable
            Dim Dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_VerMapeoEquipo]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@CodProducto", CodProducto)
                Da = New SqlDataAdapter(Cmd)
                Da.Fill(Dt)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Return Nothing
            Finally
                Cmd.Dispose()
                Cmd = Nothing
                If Not IsNothing(Da) Then
                    Da.Dispose()
                    Da = Nothing
                End If
            End Try

            Return Dt
        End Function

#Region "Reportes"

        Public Function fdu_Rpt_InventarioEquipos(ByVal pCodAlmacen As String, Optional ByVal pTipoStock As Short = -1) As DataTable
            Dim dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing
            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_Rpt_InventarioEquipos]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@CodAlmacen", pCodAlmacen)
                If pTipoStock >= 0 Then
                    Cmd.Parameters.AddWithValue("@TipoStock", IIf(pTipoStock = 0, False, True))
                End If
                Da = New SqlDataAdapter(Cmd)
                Da.Fill(dt)
            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Return Nothing
            Finally
                Cmd.Dispose()
                Cmd = Nothing
                If Not IsNothing(Da) Then
                    Da.Dispose()
                    Da = Nothing
                End If
            End Try
            Return dt
        End Function

        Public Function fdu_Rpt_PendientesXResponsable(ByVal pCodAlmacen As String, ByVal pIDResponsable As Integer, _
                                                      Optional ByVal Desde As Date = Nothing, Optional ByVal Hasta As Date = Nothing, _
                                                      Optional ByVal pCodServTransp As String = "") As DataTable
            Dim dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing
            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_Rpt_PendientesXResponsable]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@CodAlmacen", IIf(pCodAlmacen.Trim.Length = 0, DBNull.Value, pCodAlmacen))
                If pIDResponsable > 0 Then
                    Cmd.Parameters.AddWithValue("@IDResp", pIDResponsable)
                End If
                If Desde <> Nothing Then
                    Cmd.Parameters.AddWithValue("@Desde", Format(Desde, "dd/MM/yyyy"))
                End If
                If Hasta <> Nothing Then
                    Cmd.Parameters.AddWithValue("@Hasta", Format(Hasta, "dd/MM/yyyy"))
                End If
                If pCodServTransp.Trim.Length > 0 Then
                    Cmd.Parameters.AddWithValue("@CodServTransp", pCodServTransp.Trim)
                End If

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(dt)
            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Return Nothing
            Finally
                Cmd.Dispose()
                Cmd = Nothing
                If Not IsNothing(Da) Then
                    Da.Dispose()
                    Da = Nothing
                End If
            End Try
            Return dt
        End Function

        Public Function fdu_Rpt_EquiposPendientes(ByVal pCodAlmacen As String, ByVal IDEquipo As Integer, _
                                                  Optional ByVal Desde As Date = Nothing, Optional ByVal Hasta As Date = Nothing) As DataTable
            Dim dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing
            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_Rpt_EquiposPendientes]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@CodAlmacen", pCodAlmacen)
                Cmd.Parameters.AddWithValue("@IDEquipo", IIf(IDEquipo <= 0, DBNull.Value, IDEquipo))
                If Desde <> Nothing Then
                    Cmd.Parameters.AddWithValue("@Desde", Format(Desde, "dd/MM/yyyy"))
                End If
                If Hasta <> Nothing Then
                    Cmd.Parameters.AddWithValue("@Hasta", Format(Hasta, "dd/MM/yyyy"))
                End If
                Da = New SqlDataAdapter(Cmd)
                Da.Fill(dt)

                If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                    Advertencia = "No hay datos para mostrar."
                    Return Nothing
                Else : Advertencia = ""
                End If

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Return Nothing
            Finally
                Cmd.Dispose()
                Cmd = Nothing
                If Not IsNothing(Da) Then
                    Da.Dispose()
                    Da = Nothing
                End If
            End Try
            Return dt
        End Function

        Public Function fdu_Rpt_DetalleKardexPorVale(ByVal IDResponsable As Integer, ByVal CodMovi As String, ByVal CodAlmacen As String, _
                                                        ByVal Inicio As Date, ByVal Fin As Date, ByVal IDEquipo As Integer, _
                                                     ByVal Remol As String, ByVal SemiRem As String, ByVal idDestino As Integer) As DataTable
            Dim dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing
            Try

                If CodAlmacen.Trim.Length = 0 Then
                    Advertencia = "No seleccionó Almacén."
                    Return Nothing
                End If

                Cmd.CommandText = "[Almacen].[SpAlm_EST_Rpt_DetalleKardexPorVale]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@IdResp", IIf(IDResponsable = -1, DBNull.Value, IDResponsable))
                Cmd.Parameters.AddWithValue("@CodMov", IIf(CodMovi.Trim.Length = 0, DBNull.Value, CodMovi))
                Cmd.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
                Cmd.Parameters.AddWithValue("@Desde", Format(Inicio, "dd/MM/yyyy"))
                Cmd.Parameters.AddWithValue("@Hasta", Format(Fin, "dd/MM/yyyy"))
                Cmd.Parameters.AddWithValue("@IDEquipo", IIf(IDEquipo = -1, DBNull.Value, IDEquipo))
                Cmd.Parameters.AddWithValue("@Rem", IIf(Remol.Trim.Length = 0, DBNull.Value, Remol))
                Cmd.Parameters.AddWithValue("@SemiRem", IIf(SemiRem.Trim.Length = 0, DBNull.Value, SemiRem))
                Cmd.Parameters.AddWithValue("@IdDestino", IIf(idDestino = -1, DBNull.Value, idDestino))

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(dt)

                If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                    Advertencia = "No se encontraron Datos para Mostrar."
                Else : Advertencia = ""
                End If

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Return Nothing
            Finally
                Cmd.Dispose()
                Cmd = Nothing
                If Not IsNothing(Da) Then
                    Da.Dispose()
                    Da = Nothing
                End If
            End Try
            Return dt
        End Function

        Public Function fdu_Rpt_VerSolicitudesPendientesPorPersonal(ByVal IDResponsable As Integer) As DataTable
            Dim Dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_Rpt_SolicitudesPendientesPorPersonal]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@IdResp", IDResponsable)

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(Dt)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Return Nothing
            Finally
                Cmd.Dispose()
                Cmd = Nothing
                If Not IsNothing(Da) Then
                    Da.Dispose()
                    Da = Nothing
                End If
            End Try

            Return Dt

        End Function

        Public Function fdu_Rpt_VerUltimoValeSalidaPorPrestamo(ByVal CodAlmacen As String, ByVal AnioSol As Integer, _
                                                               ByVal NroSol As Integer) As DataTable
            Dim Dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_Rpt_SolicitudEstiba]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@CodAlmSol", CodAlmacen)
                Cmd.Parameters.AddWithValue("@Asol", AnioSol)
                Cmd.Parameters.AddWithValue("@NSol", NroSol)
                Da = New SqlDataAdapter(Cmd)
                Da.Fill(Dt)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                Return Nothing
            Finally
                Cmd.Dispose()
                Cmd = Nothing
                If Not IsNothing(Da) Then
                    Da.Dispose()
                    Da = Nothing
                End If
            End Try

            Return Dt

        End Function

        Public Function fdu_Rpt_ResumenStockEquipos(ByVal IDEquipo As Integer) As DataTable

            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_EST_Rpt_ResumStockEquiposEstiba]"
            Try
                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@idequipo", IIf(IDEquipo <= 0, DBNull.Value, IDEquipo))
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