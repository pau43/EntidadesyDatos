Imports System.Data.SqlClient
Imports PoolConexiones
Imports GEACEntidades.Almacen

Namespace DAOAlmacen

    Public NotInheritable Class DAOControlKardexAlmCentral

        Private Sub New()
        End Sub

        Private Shared _InstanciaControlKardexAlmCentral As DAOControlKardexAlmCentral = Nothing
        Public Advertencia As String = String.Empty

        'Instancia unica de la clase
        Public Shared ReadOnly Property Instancia() As DAOControlKardexAlmCentral
            Get
                If _InstanciaControlKardexAlmCentral Is Nothing Then
                    _InstanciaControlKardexAlmCentral = New DAOControlKardexAlmCentral
                End If
                Return _InstanciaControlKardexAlmCentral
            End Get
        End Property

#Region "Kardex Central"

        Public Function fdu_FACT_VerGruposProdXAlmacen(ByVal codAlmacen As String) As DataTable
            Dim dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing
            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_BuscarGruposXAlmacen]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@CodAlmacen", codAlmacen)
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

        Public Function fdu_LlenarFormControlNotasAlmacen(ByVal Usuario As String) As DataTable
            Dim dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_LlenarFormControlNotasAlmacen]"
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
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_TipoDeMovimientoAlmCentral]"
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

        Public Function fdu_VerNotasAlmacenCentral(ByVal CodAlmacen As String, ByVal CodSubAlmacen As String, _
                                                   ByVal Desde As Date, ByVal Hasta As Date, ByVal Texto As String, _
                                                   ByVal TipoBusqueda As Short, ByVal CodMovi As String, ByVal Usuario As String) As DataTable
            Dim dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_VerNotasAlmacenCentral]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
                If CodSubAlmacen.Trim.Length > 0 Then
                    Cmd.Parameters.AddWithValue("@CodSubAlm", CodSubAlmacen)
                End If
                Cmd.Parameters.AddWithValue("@Desde", Format(Desde, "dd/MM/yyyy"))
                Cmd.Parameters.AddWithValue("@Hasta", Format(Hasta, "dd/MM/yyyy"))
                If Texto.Trim.Length > 0 Then
                    Cmd.Parameters.AddWithValue("@Texto", Texto)
                End If
                Cmd.Parameters.AddWithValue("@TipoBusq", TipoBusqueda)
                If CodMovi.Trim.Length > 0 Then
                    Cmd.Parameters.AddWithValue("@CodMovi", CodMovi)
                End If
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

        Public Function fdu_VerKardexAlmacenPorNota(ByVal CodAlmacen As String, ByVal CodMov As String, _
                                                       ByVal AnioNota As Integer, ByVal NroNota As Integer) As DataTable
            Dim dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_VerKardexAlmacenPorNota]"
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

        Public Function fdu_VerAlmacenPorUsuario() As DataTable
            Dim Dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_VerAlmacenPorUsuario]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure


                Cmd.Parameters.AddWithValue("@Usuario", GEACEntidades.SesionUsuario.Usuario)


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

        Public Function fdu_GenerarNotaAlmacen(ByVal oNotaAlmPrd As NotaAlmacenCentral) As Boolean
            Dim Retorno As Boolean = True
            Dim Cmd As New SqlCommand
            Dim Dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_GenerarNotaAlmCentral]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                With oNotaAlmPrd
                    Cmd.Parameters.AddWithValue("@CodAlmacen", .CodAlmacen)
                    Cmd.Parameters.AddWithValue("@CodSubAlm", .CodSubAlmacen)
                    If .CodMovimiento.Trim.Length > 0 Then
                        Cmd.Parameters.AddWithValue("@CodMovi", .CodMovimiento)
                    End If
                    Cmd.Parameters.AddWithValue("@EsIngreso", .Ingreso)
                    If .Fecha <> Nothing Then
                        Cmd.Parameters.AddWithValue("@FNota", Format(.Fecha, "dd/MM/yyyy HH:mm:ss"))
                    End If
                    If .NroDoc.Trim.Length > 0 Then
                        Cmd.Parameters.AddWithValue("@NroDocu", .NroDoc)
                    End If
                    If .IDProveedor > 0 Then
                        Cmd.Parameters.AddWithValue("@IdProv", .IDProveedor)
                    End If
                    If .IDResponsable > 0 Then
                        Cmd.Parameters.AddWithValue("@IdPer", .IDResponsable)
                    End If
                    If .IDSupervisor > 0 Then
                        Cmd.Parameters.AddWithValue("@IdSup", .IDSupervisor)
                    End If
                    If .IDChofer > 0 Then
                        Cmd.Parameters.AddWithValue("@IdChofer", .IDChofer)
                    End If
                    If .IDCCostoN1V1 > 0 And .IDCCostoN2V1 > 0 And .IDCCostoN3V1 > 0 And .IDCCostoN4V1 > 0 Then
                        Cmd.Parameters.AddWithValue("@IdCCN1", .IDCCostoN1V1)
                        Cmd.Parameters.AddWithValue("@IdCCN2", .IDCCostoN2V1)
                        Cmd.Parameters.AddWithValue("@IdCCN3", .IDCCostoN3V1)
                        Cmd.Parameters.AddWithValue("@IdCCN4", .IDCCostoN4V1)
                    End If
                    Cmd.Parameters.AddWithValue("@Observacion", IIf(.Observacion.Trim.Length = 0, DBNull.Value, .Observacion))
                    Cmd.Parameters.AddWithValue("@xProductos", .XMLDetalles)
                    Cmd.Parameters.AddWithValue("@User", GEACEntidades.SesionUsuario.Usuario)
                    Cmd.Parameters.AddWithValue("@EsTx", .EsTX)
                    If .CodAlmacenTx.Length > 0 Then
                        Cmd.Parameters.AddWithValue("@CodAlmTx", .CodAlmacenTx)
                    End If
                    If .NroTx > 0 And .AnioTx > 0 Then
                        Cmd.Parameters.AddWithValue("@AnioTx", .AnioTx)
                        Cmd.Parameters.AddWithValue("@NroTx", .NroTx)
                    End If

                    If .CodAlmAux.Trim.Length > 0 Then
                        Cmd.Parameters.AddWithValue("@CodAlmAux", .CodAlmAux)
                        Cmd.Parameters.AddWithValue("@xmlProdAux", IIf(.xmlProdAux.Trim.Length = 0, DBNull.Value, .xmlProdAux))
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

        Public Function fdu_ModificarNotaAlmacen(ByVal oNotaAlmPrd As NotaAlmacenCentral) As Boolean
            Dim Retorno As Boolean = True
            Dim Cmd As New SqlCommand
            Dim Dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_ModificarNotaAlmCentral]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                With oNotaAlmPrd
                    Cmd.Parameters.AddWithValue("@CodAlmacen", .CodAlmacen)
                    Cmd.Parameters.AddWithValue("@CodMovi", .CodMovimiento)
                    Cmd.Parameters.AddWithValue("@ANota", .AnioNota)
                    Cmd.Parameters.AddWithValue("@NNota", .NroNota)
                    If .NroDoc.Trim.Length > 0 Then
                        Cmd.Parameters.AddWithValue("@NroDocu", .NroDoc)
                    End If
                    If .IDProveedor > 0 Then
                        Cmd.Parameters.AddWithValue("@IdProv", .IDProveedor)
                    End If
                    If .IDResponsable > 0 Then
                        Cmd.Parameters.AddWithValue("@IdPer", .IDResponsable)
                    End If
                    If .IDSupervisor > 0 Then
                        Cmd.Parameters.AddWithValue("@IdSup", .IDSupervisor)
                    End If
                    If .IDChofer > 0 Then
                        Cmd.Parameters.AddWithValue("@IdChofer", .IDChofer)
                    End If
                    If .IDCCostoN1V1 > 0 And .IDCCostoN2V1 > 0 And .IDCCostoN3V1 > 0 And .IDCCostoN4V1 > 0 Then
                        Cmd.Parameters.AddWithValue("@IdCCN1", .IDCCostoN1V1)
                        Cmd.Parameters.AddWithValue("@IdCCN2", .IDCCostoN2V1)
                        Cmd.Parameters.AddWithValue("@IdCCN3", .IDCCostoN3V1)
                        Cmd.Parameters.AddWithValue("@IdCCN4", .IDCCostoN4V1)
                    End If
                    Cmd.Parameters.AddWithValue("@Observacion", IIf(.Observacion.Trim.Length = 0, DBNull.Value, .Observacion))
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

        Public Function fdu_AnularNotaAlmacen(ByVal CodAlmacen As String, ByVal CodMovi As String, ByVal AnioNota As Integer, _
                                                ByVal NroNota As Integer, ByVal Motivo As String) As Boolean
            Dim Retorno As Boolean = True
            Dim Cmd As New SqlCommand
            Dim Dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_AnularNotaAlmacen]"
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

        Public Function fdu_AnularKardexNotaAlmacen(ByVal CodAlmacen As String, ByVal CodMovi As String, ByVal AnioNota As Integer, _
                                                ByVal NroNota As Integer, ByVal NroProducto As Integer) As Boolean
            Dim Retorno As Boolean = True
            Dim Cmd As New SqlCommand
            Dim Dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_AnularKardexNotaAlmacen]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
                Cmd.Parameters.AddWithValue("@CodMovi", CodMovi)
                Cmd.Parameters.AddWithValue("@AnioNota", AnioNota)
                Cmd.Parameters.AddWithValue("@NroNota", NroNota)
                Cmd.Parameters.AddWithValue("@NroProducto", NroProducto)
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

        Public Function fdu_CambiarCantidadNotaAlmacen(ByVal CodAlmacen As String, ByVal CodMovi As String, ByVal AnioNota As Integer, _
                                                ByVal NroNota As Integer, ByVal NroProducto As Integer, ByVal Cantidad As Decimal) As Boolean
            Dim Retorno As Boolean = True
            Dim Cmd As New SqlCommand
            Dim Dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_CambiarCantidadNotaAlmacen]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
                Cmd.Parameters.AddWithValue("@CodMovi", CodMovi)
                Cmd.Parameters.AddWithValue("@AnioNota", AnioNota)
                Cmd.Parameters.AddWithValue("@NroNota", NroNota)
                Cmd.Parameters.AddWithValue("@NroProducto", NroProducto)
                Cmd.Parameters.AddWithValue("@Cantidad", Cantidad)
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

        Public Function fdu_VerPartesUnidad() As DataTable
            Dim xDt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing
            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_VerPartesUnidad]"
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

        Public Function fdu_VerStockAlmacen(ByVal CodAlmacen As String, ByVal CodProducto As String, ByVal Producto As String) As DataTable
            Dim dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing
            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_VerStockAlmacen]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
                If CodProducto.Trim.Length > 0 Then
                    Cmd.Parameters.AddWithValue("@CodProducto", CodProducto)
                End If
                If Producto.Trim.Length > 0 Then
                    Cmd.Parameters.AddWithValue("@Producto", Producto)
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

        Public Function fdu_BuscarProductoXAlmCentral(ByVal CodAlmacen As String, ByVal CodProducto As String, _
                                                      ByVal NomProducto As String) As DataTable
            Dim dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing
            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_BuscarProductoXAlmCentral]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
                Cmd.Parameters.AddWithValue("@CodProducto", CodProducto)
                Cmd.Parameters.AddWithValue("@NomProducto", NomProducto)

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

        Public Function fdu_ConsultaRapidaXProd(ByVal CodAlmacen As String, ByVal FechaI As Date, _
                                                       ByVal FechaF As Date, ByVal NroProd As Integer) As DataTable
            Dim dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing
            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_ConsultaRapidaXProd]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
                Cmd.Parameters.AddWithValue("@FechaI", Format(FechaI, "dd/MM/yyyy"))
                Cmd.Parameters.AddWithValue("@FechaF", Format(FechaF, "dd/MM/yyyy"))
                Cmd.Parameters.AddWithValue("@NroProducto", NroProd)

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

        Public Function fdu_VerProductosXNota(ByVal CodAlmacen As String, ByVal CodMovi As String, _
                                               ByVal AnioNota As Integer, ByVal NroNota As Integer) As DataTable
            Dim dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing
            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_VerProductosXNota]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
                Cmd.Parameters.AddWithValue("@CodMovi", CodMovi)
                Cmd.Parameters.AddWithValue("@AnioNota", AnioNota)
                Cmd.Parameters.AddWithValue("@NroNota", NroNota)

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

        Public Function fdu_ActualizarFHNota(ByVal CodAlmacen As String, ByVal CodMovi As String, ByVal AnioNota As Integer, _
                                                ByVal NroNota As Integer, ByVal FHNota As Date, ByVal FHAnt As Date) As Boolean
            Dim Retorno As Boolean = True
            Dim Cmd As New SqlCommand
            Dim Dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_ActualizarFHNota]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
                Cmd.Parameters.AddWithValue("@CodMovi", CodMovi)
                Cmd.Parameters.AddWithValue("@AnioNota", AnioNota)
                Cmd.Parameters.AddWithValue("@NroNota", NroNota)
                Cmd.Parameters.AddWithValue("@FHNota", Format(FHNota, "dd/MM/yyyy HH:mm:ss"))
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

        Public Function fdu_LlenarFormConsultaRapXProd(ByVal Usuario As String) As DataTable
            Dim dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_LlenarFormConsultaRapXProd]"
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

        Public Function fdu_LlenarFrmRptKardexAlmCentral() As DataTable
            Dim dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_LlenarFrmRptKardexAlmCentral]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure
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

        Public Function fdu_CTRL_LlenarFrmRptProdConsumidos() As DataTable
            Dim dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_LlenarFrmRptProdConsumidos]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure
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

        Public Function fdu_VerPersonalConNotasAlmCentral(ByVal TextoBusca As String) As DataTable
            Dim dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_VerPersonalConNotasAlmCentral]"
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

        Public Function fdu_LlenarFrmInventarioAlmacen() As DataTable
            Dim dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_LlenarFrmInventarioAlmacen]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

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

        Public Function fdu_RptInventarioAlmCentral(ByVal CodAlmacen As String, ByVal TipoStock As Integer, _
                                                    ByVal NroFamilia As Integer, ByVal NroGrupo As Integer, _
                                                    ByVal Inicial As Integer, ByVal Final As Integer, _
                                                    ByVal NomProdAprox As String, Optional ByVal Hasta As Date = #1/1/2000#) As DataTable
            Dim dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing
            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_RptInventarioAlmCentral]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure
                If NomProdAprox.Trim.Length = 0 Then
                    Cmd.Parameters.AddWithValue("@NroFamilia", IIf(NroFamilia > 0, NroFamilia, DBNull.Value))
                    Cmd.Parameters.AddWithValue("@NroGrupo", IIf(NroGrupo > 0, NroGrupo, DBNull.Value))
                    Cmd.Parameters.AddWithValue("@Inicial", Inicial)
                    Cmd.Parameters.AddWithValue("@Final", Final)
                Else
                    Cmd.Parameters.AddWithValue("@NomProdAprox", NomProdAprox)
                    Cmd.Parameters.AddWithValue("@Inicial", 0)
                    Cmd.Parameters.AddWithValue("@Final", 0)
                End If
                Cmd.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
                Cmd.Parameters.AddWithValue("@TipoStock", TipoStock)
                Cmd.Parameters.AddWithValue("@Hasta", IIf(Hasta.Year < 2010, DBNull.Value, Hasta))

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

        Public Function fdu_CambiarProducto(ByVal CodAlmacen As String, ByVal CodMovi As String, ByVal AnioNota As Integer, _
                      ByVal NroNota As Integer, ByVal NroProdAnt As Integer, ByVal NroProdAct As Integer) As Boolean

            Dim Retorno As Boolean = True
            Dim Cmd As New SqlCommand
            Dim Dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_CambiarProducto]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
                Cmd.Parameters.AddWithValue("@CodMovi", CodMovi)
                Cmd.Parameters.AddWithValue("@AnioNota", AnioNota)
                Cmd.Parameters.AddWithValue("@NroNota", NroNota)
                Cmd.Parameters.AddWithValue("@NroProdAnt", NroProdAnt)
                Cmd.Parameters.AddWithValue("@NroProdAct", NroProdAct)
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


        Public Function fdu_CTRL_BuscarMapeoCentralEstiba(ByVal CodEmpresa As String, ByVal xmlProductos As String, ByVal TipoAlm As Integer) As DataSet

            Dim ds As New DataSet
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_BuscarMapeoCentralEstiba]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@CodEmpresa", CodEmpresa)
                Cmd.Parameters.AddWithValue("@XMLProductos", xmlProductos)
                Cmd.Parameters.AddWithValue("@TipoAlm", TipoAlm)

                Da = New SqlDataAdapter(Cmd)
                Da.Fill(ds)

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

            Return ds

        End Function


        'Public Function fdu_TieneMapeoKardexEnAux(ByVal CodAlmacen As String, ByVal CodMovi As String, ByVal AnioNota As Short, _
        '                                          ByVal NroNota As Integer, Optional ByRef TieneMapeo As Boolean = False, _
        '                                          Optional ByVal EsCentral As Boolean = True, Optional ByRef TipoAux As Short = -1, Optional ByVal ProdAux As String = "") As DataTable
        '    Dim dt As New DataTable
        '    Dim Cmd As New SqlCommand
        '    Dim Da As SqlDataAdapter = Nothing
        '    Try
        '        Cmd.CommandText = "[Almacen].[SpAlm_CTRL_TieneMapeoKardexEnAux]"
        '        Cmd.Connection = TSQL.ConexionPermanente
        '        Cmd.CommandType = CommandType.StoredProcedure

        '        Cmd.Parameters.AddWithValue("@EsCentral", EsCentral)
        '        Cmd.Parameters.AddWithValue("@CodAlm", CodAlmacen)
        '        Cmd.Parameters.AddWithValue("@CodMovi", CodMovi)
        '        Cmd.Parameters.AddWithValue("@AnioNota", AnioNota)
        '        Cmd.Parameters.AddWithValue("@NroNota", NroNota)

        '        'Adiciono variables de retorno
        '        'Dim SqlPrm = New SqlParameter("@OkAux", SqlDbType.SmallInt)
        '        'SqlPrm.Direction = ParameterDirection.Output
        '        'Cmd.Parameters.Add(SqlPrm)

        '        'SqlPrm = New SqlParameter("@Return", SqlDbType.Xml)
        '        'SqlPrm.Direction = ParameterDirection.Output
        '        'Cmd.Parameters.Add(SqlPrm)

        '        Cmd.Parameters.AddWithValue("@OkAux", IIf(TipoAux = -1, DBNull.Value, TipoAux)).Direction = ParameterDirection.Output
        '        Cmd.Parameters.AddWithValue("@Return", DBNull.Value).Direction = ParameterDirection.Output

        '        Da = New SqlDataAdapter(Cmd)
        '        Da.Fill(dt)

        '        If Cmd.Parameters("@OkAux").Value = -1 Then
        '            dt = Nothing
        '        Else
        '            TipoAux = Cmd.Parameters("@OkAux").Value
        '            ProdAux = Cmd.Parameters("@Return").Value
        '            TieneMapeo = True
        '        End If

        '    Catch ex As Exception
        '        Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
        '        Return Nothing
        '    Finally
        '        Cmd.Dispose()
        '        Cmd = Nothing
        '        If Not IsNothing(Da) Then
        '            Da.Dispose()
        '            Da = Nothing
        '        End If
        '    End Try

        '    Return dt
        'End Function

        
#End Region

#Region "Periodos Ctbles"
        Public Function fdu_CTRL_PeriodoCtble_Ver(ByVal pCodEmpresa As String, ByVal pAnio As Integer) As DataTable
            Dim dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing
            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_PeriodoCtble_Ver]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@CodEmpresa", pCodEmpresa)
                Cmd.Parameters.AddWithValue("@Anio", pAnio)
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

        Public Function fdu_CTRL_PeriodoCtble_LlenarForm() As DataTable
            Dim dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing
            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_PeriodoCtble_LlenarForm]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@User", GEACEntidades.SesionUsuario.Usuario)
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

        Public Function fdu_CTRL_PeriodoCtble_Cerrar(ByVal pCodEmpresa As String, ByVal pAnio As Integer, ByVal pMes As Short, ByVal Autoriza As String, Optional ByVal CierreCompras As Boolean = False) As Boolean
            Dim Retorno As Boolean = True
            Dim Cmd As New SqlCommand
            Dim Dr As SqlDataReader = Nothing
            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_PeriodoCtble_Cerrar]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@CodEmpresa", pCodEmpresa)
                Cmd.Parameters.AddWithValue("@Anio", pAnio)
                Cmd.Parameters.AddWithValue("@Mes", pMes)
                Cmd.Parameters.AddWithValue("@User", Autoriza)
                Cmd.Parameters.AddWithValue("@CierreCompras", CierreCompras)
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

        Public Function fdu_CTRL_PeriodoCtble_ReAbrir(ByVal pCodEmpresa As String, ByVal pAnio As Integer, ByVal pMes As Short, ByVal Autoriza As String, Optional ByVal CierreCompras As Boolean = False) As Boolean
            Dim Retorno As Boolean = True
            Dim Cmd As New SqlCommand
            Dim Dr As SqlDataReader = Nothing
            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_PeriodoCtble_ReAbrir]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@CodEmpresa", pCodEmpresa)
                Cmd.Parameters.AddWithValue("@Anio", pAnio)
                Cmd.Parameters.AddWithValue("@Mes", pMes)
                Cmd.Parameters.AddWithValue("@User", Autoriza)
                Cmd.Parameters.AddWithValue("@CierreCompras", CierreCompras)
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


#End Region


#Region "Transferencias"

        Public Function fdu_VerAlmacenesParaTx(ByVal CodAlmacen As String) As DataTable
            Dim xDt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing
            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_VerAlmacenesParaTx]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
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

        Public Function fdu_VerTxRecepcionAlmacenCentral(ByVal pCodAlmacenTx As String) As DataTable
            Dim xDt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing
            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_VerTxRecepcionAlmCentral]"
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

#Region "Reportes"

        Public Function fdu_VerNotaAlmCentral(ByVal IDPersonal As Integer, ByVal CodMovi As String, ByVal CodAlmacen As String, _
                                            ByVal Inicio As Date, ByVal Fin As Date, ByVal NroProducto As Integer, ByVal Placa As String, _
                                            ByVal Prod As String, ByVal IDParte As Integer, ByVal Listado As Boolean, ByVal xListaGrupo As String) As DataTable
            Dim dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing

            Try
                Advertencia = ""

                If Listado Then
                    Cmd.CommandText = "[Almacen].[SpAlm_CTRL_RptKardexAlmCentral]"
                Else : Cmd.CommandText = "[Almacen].[SpAlm_CTRL_VerNotaAlmCentral]"
                End If

                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@IDPersonal", IIf(IDPersonal = -1, DBNull.Value, IDPersonal))
                Cmd.Parameters.AddWithValue("@CodMov", IIf(CodMovi.Trim.Length = 0, DBNull.Value, CodMovi))
                Cmd.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
                Cmd.Parameters.AddWithValue("@Desde", Format(Inicio, "dd/MM/yyyy"))
                Cmd.Parameters.AddWithValue("@Hasta", Format(Fin, "dd/MM/yyyy"))
                Cmd.Parameters.AddWithValue("@NroProducto", IIf(NroProducto = -1, DBNull.Value, NroProducto))
                Cmd.Parameters.AddWithValue("@Placa", IIf(Placa.Trim.Length = 0, DBNull.Value, Placa))
                Cmd.Parameters.AddWithValue("@Prod", IIf(Prod.Trim.Length = 0, DBNull.Value, Prod))
                Cmd.Parameters.AddWithValue("@IDParte", IIf(IDParte = -1, DBNull.Value, IDParte))
                If Listado Then
                    Cmd.Parameters.AddWithValue("@xListaGrupo", IIf(xListaGrupo.Trim.Length = 0, DBNull.Value, xListaGrupo))
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

        Public Function fdu_KardexValorizadoAlmCentral(ByVal CodAlmacen As String, ByVal Inicio As Date, ByVal Fin As Date, _
                                                       ByVal NroProducto As Integer, ByVal NroGrupo As Integer, ByVal Regenerar As Boolean) As DataTable
            Dim dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_CTRL_KardexValorizadoAlmCentral]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
                Cmd.Parameters.AddWithValue("@FechaI", Format(Inicio, "dd/MM/yyyy"))
                Cmd.Parameters.AddWithValue("@FechaF", Format(Fin, "dd/MM/yyyy"))
                Cmd.Parameters.AddWithValue("@NroProducto", IIf(NroProducto = -1, DBNull.Value, NroProducto))
                Cmd.Parameters.AddWithValue("@NroGrupo", NroGrupo)
                Cmd.Parameters.AddWithValue("@Regenerar", Regenerar)

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

        'Public Function fdu_CTRL_KardexConsumoDetallado_T(ByVal Anio As Integer, _
        '                                 ByVal FechaInicio As DateTime, _
        '                                 ByVal FechaFin As DateTime, _
        '                                 ByVal xmlListaGrupos As String, _
        '                                 ByVal xmlListaAlmacenes As String, _
        '                                 ByVal CodMov As String) As DataTable
        '    Dim Dt As New DataTable
        '    Dim Cmd As New SqlCommand
        '    Dim Da As SqlDataAdapter
        '    Try
        '        Cmd.CommandText = "[Almacen].[SpAlm_CTRL_KardexConsumoDetallado_T]"
        '        Cmd.Connection = TSQL.ConexionPermanente
        '        Cmd.CommandType = CommandType.StoredProcedure
        '        Cmd.Parameters.AddWithValue("@Anio", Anio)
        '        Cmd.Parameters.AddWithValue("@FechaI", FechaInicio)
        '        Cmd.Parameters.AddWithValue("@FechaF", FechaFin)
        '        Cmd.Parameters.AddWithValue("@xListaGrupo", xmlListaGrupos)
        '        Cmd.Parameters.AddWithValue("@xListaAlmacen", xmlListaAlmacenes)
        '        Cmd.Parameters.AddWithValue("@CodMov", CodMov)
        '        Da = New SqlDataAdapter(Cmd)
        '        Da.Fill(Dt)
        '    Catch ex As Exception
        '        Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
        '        Dt = Nothing
        '    Finally
        '        Da = Nothing
        '        Cmd = Nothing
        '    End Try
        '    Return Dt
        'End Function

        'Public Function fdu_CTRL_EST_MOV_ActualizarData(ByVal Anio As Integer, ByVal CodEmpresa As String) As Boolean
        '    Dim Cmd As New SqlCommand
        '    Dim Prm As SqlParameter
        '    Dim Retorno As Boolean
        '    Dim Dr As SqlDataReader = Nothing

        '    Try
        '        Cmd.CommandText = "[Almacen].[SpAlm_CTRL_EST_MOV_ActualizarData]"
        '        Cmd.Connection = TSQL.ConexionPermanente
        '        Cmd.CommandType = CommandType.StoredProcedure

        '        Cmd.Parameters.AddWithValue("@Anio", Anio)
        '        Cmd.Parameters.AddWithValue("@CodEmpresa", CodEmpresa)

        '        If Cmd.Connection.State = ConnectionState.Closed Then
        '            Cmd.Connection.Open()
        '        End If
        '        Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
        '        Dr.Read()
        '        Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)

        '    Catch ex As Exception
        '        Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje : " & ex.Message
        '        Retorno = False
        '    Finally

        '        If Not Dr Is Nothing Then
        '            Dr.Close()
        '        End If
        '        Dr = Nothing
        '        Prm = Nothing
        '        Cmd.Dispose()
        '        Cmd = Nothing
        '    End Try

        '    Return Retorno
        'End Function

        'Created By: ICR
        Public Function fdu_CTRL_SUNAT_GenerarLibroKardexValorizadoAlmCentral(ByVal CodAlmacen As String, ByVal Inicio As Date, ByVal Fin As Date, _
                                               ByVal NroProducto As Integer, ByVal XmlGrupo As String, ByVal NroVersion As Integer) As DataTable
            Dim dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter = Nothing

            Try
                Dim cmdStr As String = ""
                Select Case NroVersion
                    Case 3
                        cmdStr = "[Almacen].[SpAlm_SUNAT_LE_InventarioPermanenteValorizadoV3]"
                    Case 4
                        cmdStr = "[Almacen].[SpAlm_SUNAT_LE_InventarioPermanenteValorizadoV4]"
                End Select
                Cmd.CommandText = cmdStr ' "[Almacen].[SpAlm_CTRL_SUNAT_GenerarLibroKardexValorizadoAlmCentral]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandTimeout = 3000
                Cmd.CommandType = CommandType.StoredProcedure
                If NroVersion = 4 Then
                    Cmd.Parameters.AddWithValue("@CodAlmacen", CodAlmacen)
                Else
                    Cmd.Parameters.AddWithValue("@XmlCodAlmacen", "<r><d CodAlmacen=""" + CodAlmacen + """ /></r>")
                End If
                Cmd.Parameters.AddWithValue("@FechaI", Format(Inicio, "dd/MM/yyyy"))
                Cmd.Parameters.AddWithValue("@FechaF", Format(Fin, "dd/MM/yyyy"))
                Cmd.Parameters.AddWithValue("@NroProducto", IIf(NroProducto <= 0, DBNull.Value, NroProducto))
                Cmd.Parameters.AddWithValue("@xListaGrupo", IIf(XmlGrupo.Length = 0, DBNull.Value, XmlGrupo))

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


    End Class


End Namespace