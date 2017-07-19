Imports System.Text
Imports System.IO
Imports System.Data.SqlClient
Imports PoolConexiones
Imports GEACEntidades.Almacen
'Imports GEACEntidades.EAlmacen

Namespace DAOAlmacen

    Public Class DAOKardexMovimiento
        Private Advertencia As String = String.Empty

        Public Function CargarUbicaciones() As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarUbicaciones]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                Da = New SqlDataAdapter(comando)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Ubicaciones")
                tabla = Nothing
            Finally
                'Dr.Close()
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
            End Try

            Return tabla

        End Function
        'Public Function CargarTiposMovimiento(ByVal TipoNota As String) As DataTable
        '    Dim tabla As New DataTable
        '    Dim Prm As SqlParameter
        '    Dim comando As New SqlCommand
        '    Dim Da As SqlDataAdapter
        '    Dim StrComando = "[Almacen].[SpAlm_MostrarTipos_Movimiento]"
        '    Try

        '        comando.CommandText = StrComando
        '        comando.Connection = TSQL.ConexionPermanente
        '        comando.CommandType = CommandType.StoredProcedure

        '        Prm = New SqlParameter("@tiponota", IIf(TipoNota.Trim.Length = 0, DBNull.Value, TipoNota))
        '        comando.Parameters.Add(Prm)

        '        Da = New SqlDataAdapter(comando)
        '        Da.Fill(tabla)

        '    Catch ex As Exception
        '        MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Ubicaciones")
        '        tabla = Nothing
        '    Finally
        '        Da = Nothing
        '        comando = Nothing
        '        StrComando = String.Empty
        '        Prm = Nothing

        '    End Try

        '    Return tabla

        'End Function
        'Public Function CargarUnidades() As DataTable
        '    Dim tabla As New DataTable
        '    Dim comando As New SqlCommand
        '    Dim Da As SqlDataAdapter
        '    Dim StrComando = "[Almacen].[SpAlm_MostrarUnidades]"
        '    Try

        '        comando.CommandText = StrComando
        '        comando.Connection = TSQL.ConexionPermanente
        '        comando.CommandType = CommandType.StoredProcedure

        '        Da = New SqlDataAdapter(comando)
        '        Da.Fill(tabla)

        '    Catch ex As Exception
        '        MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Unidades")
        '        tabla = Nothing
        '    Finally
        '        'Dr.Close()
        '        Da = Nothing
        '        comando = Nothing
        '        StrComando = String.Empty
        '    End Try

        '    Return tabla

        'End Function
        'Public Function BuscarProveedorPorCodigo(ByVal CodigoProveedor As String) As DataTable
        '    Dim Dt As New DataTable
        '    Dim oTSQL As New TSQL

        '    CodigoProveedor = oTSQL.EliminarInyeccionSQL(CodigoProveedor)

        '    Dim Prm = New SqlParameter("@codagente", CodigoProveedor)

        '    Dim comando As New SqlCommand
        '    Dim Da As SqlDataAdapter
        '    Dim StrComando = "[Almacen].[SpAlm_BuscarProveedorPorCodigo]"
        '    Try

        '        comando.CommandText = StrComando
        '        comando.Connection = TSQL.ConexionPermanente
        '        comando.CommandType = CommandType.StoredProcedure

        '        comando.Parameters.Add(Prm)

        '        Da = New SqlDataAdapter(comando)
        '        Da.Fill(Dt)

        '    Catch ex As Exception
        '        MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Busqueda Proveedor")
        '        Dt = Nothing
        '    Finally
        '        Da = Nothing
        '        comando = Nothing
        '        StrComando = String.Empty
        '        Prm = Nothing
        '    End Try
        '    Return Dt

        'End Function

        Public Function ProductosPorCodigoProducto(ByVal CodProducto As String, ByVal CodAlmacen As String, ByVal TipoNota As String) As DataTable
            Dim Dt As New DataTable
            Dim Prm As SqlParameter
            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_ProductoPorCodigoProducto]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@codproducto", CodProducto)
                comando.Parameters.Add(Prm)
                Prm = New SqlParameter("@codalmacen", CodAlmacen)
                comando.Parameters.Add(Prm)
                Prm = New SqlParameter("@tiponota", TipoNota)
                comando.Parameters.Add(Prm)

                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Reporte Incidente")
                Dt = Nothing
            Finally
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                Prm = Nothing
            End Try
            Return Dt
        End Function
        Public Function CargarProductosPorCodigoYAlmacen(ByVal oProducto As Productos) As DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim Dt As New DataTable
            Try

                comando.CommandText = "[Almacen].[SpAlm_ProductosPorCodigoProductoYAlmacen]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                With oProducto
                    param = New SqlParameter("@codproducto", .CodProducto)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@codalmacen", .CodAlmacen)
                    comando.Parameters.Add(param)
                End With
                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Busqueda Productos")
                Dt = Nothing
            Finally
                'Dr.Close()
                Da = Nothing
                comando = Nothing
                param = Nothing
            End Try

            Return Dt

        End Function
        Public Function CargarSoloCodigosProducto(ByVal CodAlmacen As String) As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_SoloCodigoProducto]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@codalmacen", CodAlmacen)
                comando.Parameters.Add(param)

                Da = New SqlDataAdapter(comando)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Ubicaciones")
                tabla = Nothing
            Finally
                'Dr.Close()
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
            End Try

            Return tabla

        End Function
      
        'Public Function CargarCondiciones() As DataTable
        '    Dim tabla As New DataTable
        '    Dim comando As New SqlCommand
        '    Dim Da As SqlDataAdapter
        '    Dim StrComando = "[Almacen].[SpAlm_MostrarCondiciones_Producto]"
        '    Try

        '        comando.CommandText = StrComando
        '        comando.Connection = TSQL.ConexionPermanente
        '        comando.CommandType = CommandType.StoredProcedure

        '        Da = New SqlDataAdapter(comando)
        '        Da.Fill(tabla)

        '    Catch ex As Exception
        '        MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Condiciones")
        '        tabla = Nothing
        '    Finally
        '        'Dr.Close()
        '        Da = Nothing
        '        comando = Nothing
        '        StrComando = String.Empty
        '    End Try

        '    Return tabla

        'End Function
        Public Function RegistrarNotaAlmacen(ByVal oNotaAlmacen As Notas_Almacen) As Boolean

            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            With oNotaAlmacen

                Try
                    'Cmd.CommandText = "[Almacen].[SpAlm_NuevaNotaAlmacen]"


                    Cmd.CommandText = "[Almacen].[SpAlm_NuevaNotaAlmacenAux]" 'probando para tipos NOTAS especiales


                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure

                    Prm = New SqlParameter("@fechanota", .FechaNota)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@observaciones", IIf(.Observacion = String.Empty, DBNull.Value, .Observacion))
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@codalmacen", .CodAlmacen)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@codmovi", .CodMovi)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@idalmacenero", .IDAlmacenero)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@idsucursal", .IDSucursal)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@tiponota", .TipoNota)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@pcodificados", IIf(.XMLKardex = String.Empty, DBNull.Value, .XMLKardex)) ' codificable
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@pnocodificados", IIf(.XMLKardexNoCodificable = String.Empty, DBNull.Value, .XMLKardexNoCodificable))
                    Cmd.Parameters.Add(Prm)

                    If .IDProveedor > 0 Then
                        Prm = New SqlParameter("@idproveedor", .IDProveedor)  'si es pro Ocompra va a ser null
                        Cmd.Parameters.Add(Prm)
                    Else
                        Prm = New SqlParameter("@idproveedor", DBNull.Value)  'si es pro Ocompra va a ser null
                        Cmd.Parameters.Add(Prm)
                    End If

                    Prm = New SqlParameter("@nota", SqlDbType.VarChar, 50)
                    Prm.Direction = ParameterDirection.Output
                    Cmd.Parameters.Add(Prm)



                    Dr = Cmd.ExecuteReader
                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Salida Almacén")
                        oNotaAlmacen.NroNota = Cmd.Parameters("@nota").Value    ' en caso de éxito obtiene el Nro de Nota asignado
                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Salida Almacén")
                    End If

                Catch ex As Exception
                    MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                    Retorno = False
                Finally

                    Dr.Close()
                    Dr = Nothing
                    Prm = Nothing
                    Cmd.Dispose()
                    Cmd = Nothing
                End Try

                Return Retorno

            End With

        End Function
        Public Function MostrarNotasAlmacenPorFecha(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal CodAlmacen As String) As DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim Dt As New DataTable
            Try

                comando.CommandText = "[Almacen].[SpAlm_MostrarNotasAlmacenPorFechas]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@fechainicio", FechaInicio)
                comando.Parameters.Add(param)
                param = New SqlParameter("@fechafin", FechaFin)
                comando.Parameters.Add(param)
                param = New SqlParameter("@codalmacen", CodAlmacen)
                comando.Parameters.Add(param)

                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Busqueda Notas Almacén")
                Dt = Nothing
            Finally
                'Dr.Close()
                Da = Nothing
                comando = Nothing
                param = Nothing
            End Try

            Return Dt

        End Function
        Public Function MostrarItemsPorNotaAlmacen(ByVal idnota As Integer) As DataTable
            Dim Dt As New DataTable
            Dim Prm = New SqlParameter("@idnota", idnota)

            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarItemsNotaAlmacen]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                comando.Parameters.Add(Prm)

                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Mostrar Detalle")
                Dt = Nothing
            Finally
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                Prm = Nothing
            End Try
            Return Dt
        End Function
        Public Function CargarNotaAlmacen(ByVal IDNotaAlmacen As Integer, ByVal CodAlmacen As String) As DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim Dt As New DataTable
            Try

                comando.CommandText = "[Almacen].[SpAlm_MostrarNotaAlmacen]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure


                param = New SqlParameter("@IDNotaAlmacen", IDNotaAlmacen)
                comando.Parameters.Add(param)
                param = New SqlParameter("@CodAlmacen", CodAlmacen)
                comando.Parameters.Add(param)

                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Cargar Nota Almacén")
                Dt = Nothing
            Finally
                Da = Nothing
                comando = Nothing
                param = Nothing
            End Try

            Return Dt

        End Function
        Public Function EliminarItemNotaAlmacen(ByVal IDKardex As Integer) As Boolean
            Dim valor As Boolean = True

            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Lector As SqlDataReader = Nothing

            Try
                comando = New SqlCommand("[Almacen].[SpAlm_EliminarItemNotaAlmacen]", TSQL.ConexionPermanente)
                comando.CommandType = CommandType.StoredProcedure
                param = New SqlParameter("@idkardex", IDKardex)
                comando.Parameters.Add(param)

                Lector = comando.ExecuteReader
                Lector.Read()
                Retorno = TSQL.CodigoRetorno(Lector.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Eliminar Kardex")
                Else
                    MsgBox(Advertencia, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Eliminar Kardex")
                    ' Return False
                End If

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                'Retorno = False
            Finally

                Lector.Close()
                Lector = Nothing
                param = Nothing
                comando.Dispose()
                comando = Nothing
            End Try



            Return Retorno

        End Function
        Public Function ModificarNotaAlmacen(ByVal oNotaAlmacen As Notas_Almacen) As Boolean

            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            With oNotaAlmacen

                Try

                    Cmd.CommandText = "Almacen.SpAlm_ModificarNotaAlmacen"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure

                    Prm = New SqlParameter("@idnotaalmacen", .IDNotaAlmacen)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@codmovi", .CodMovi)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@observacion", .Observacion)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@tiponota", .TipoNota)  'se podria quitar ya que el idnotaalmacen ya se registro como salida
                    Cmd.Parameters.Add(Prm)



                    Dr = Cmd.ExecuteReader()
                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Modificar Nota Almacén")
                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Modificar Nota Almacén")
                    End If

                Catch ex As Exception
                    MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                    'Retorno = False
                Finally
                    oNotaAlmacen.Inicializar()
                    Dr.Close()
                    Dr = Nothing
                    Prm = Nothing
                    Cmd.Dispose()
                    Cmd = Nothing
                End Try

                Return Retorno

            End With

        End Function
        Public Function BuscarIDUnidad(ByVal Placa As String) As DataTable
            Dim Dt As New DataTable
            Dim Prm = New SqlParameter("@placa", Placa)

            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "Mantenimiento.SpMan_EsRemolcador"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                comando.Parameters.Add(Prm)

                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Busqueda Unidad")
                Dt = Nothing
            Finally
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                Prm = Nothing
            End Try
            Return Dt


        End Function
        Public Function ModificarItemNotaAlmacen(ByVal oKardexAlmacen As Kardex_Almacen) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            With oKardexAlmacen

                Try

                    Cmd.CommandText = "[Almacen].[SpAlm_ModificarItemNotaAlmacen]" 'Luego Probar con [Almacen].[SpAlm_ModificarItemNotaAlmacen] (Es tanto para Ingreso como Salida)
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure

                    Prm = New SqlParameter("@idkardex", .IDKardex)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@idtrabajador", IIf(.IDTrabajador = 0, DBNull.Value, .IDTrabajador))
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@codcondicion", .CodCondicion)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@idprovieneva", IIf(.IDProvieneVa <= 0, DBNull.Value, .IDProvieneVa))
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@referencia", IIf(.Referencia = String.Empty, DBNull.Value, .Referencia))
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@cantidad", .Cantidad)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@observaciones", IIf(.Observaciones = String.Empty, DBNull.Value, .Observaciones))
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@idunidad", IIf(.IDUnidad = 0, DBNull.Value, .IDUnidad))
                    Cmd.Parameters.Add(Prm)


                    Dr = Cmd.ExecuteReader()
                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Modificar Item Nota Almacén")
                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Modificar Item Nota Almacén")
                    End If

                Catch ex As Exception
                    MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                    ' Retorno = False
                Finally
                    ' oKardexAlmacen.Inicializar()
                    Dr.Close()
                    Dr = Nothing
                    Prm = Nothing
                    Cmd.Dispose()
                    Cmd = Nothing
                End Try

                Return Retorno

            End With

        End Function
        Public Function AnularNotaAlmacen(ByVal IDNotaAlmacen As Integer) As Boolean
            Dim valor As Boolean = True

            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Lector As SqlDataReader = Nothing

            Try
                comando = New SqlCommand("[Almacen].[SpAlm_AnularNotaAlmacen]", TSQL.ConexionPermanente)
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@idnotaalmacen", IDNotaAlmacen)
                comando.Parameters.Add(param)

                Lector = comando.ExecuteReader
                Lector.Read()
                Retorno = TSQL.CodigoRetorno(Lector.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Anular Nota Almacén")
                Else
                    MsgBox(Advertencia, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Anular Nota Almacén")
                    Return False
                End If

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                ' Retorno = False
            Finally
                ' oKardexAlmacen.Inicializar()
                Lector.Close()
                Lector = Nothing
                param = Nothing
                comando.Dispose()
                comando = Nothing
            End Try

            Return Retorno

        End Function
        Public Function MostrarCabeceraOrdenCompra(ByVal CodAlmacen As String) As DataTable
            Dim tabla As New DataTable
            Dim Prm = New SqlParameter("@codalmacen", CodAlmacen)
            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarCabeceraOCompra]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                comando.Parameters.Add(Prm)



                Da = New SqlDataAdapter(comando)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Trabajadores")
                tabla = Nothing
            Finally
                'Dr.Close()
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
            End Try
            Return tabla
        End Function
        'Public Function GenerarNotaIngresoPorOrdenCompra(ByVal oOrdenOC As OrdenCompra) As Boolean

        '    Dim Cmd As New SqlCommand
        '    Dim Prm As SqlParameter
        '    Dim Retorno As Boolean
        '    Dim Dr As SqlDataReader = nothing

        '    With oOrdenOC

        '        Try

        '            Cmd.CommandText = "[Almacen].[SpAlm_GenerarNotaIngresoPorOrdenCompra]"
        '            Cmd.Connection = TSQL.ConexionPermanente
        '            Cmd.CommandType = CommandType.StoredProcedure

        '            Prm = New SqlParameter("@idordcompra", .IDOrdenCompra)
        '            Cmd.Parameters.Add(Prm)

        '            Prm = New SqlParameter("@codalmacen", .CodigoAlmacen)
        '            Cmd.Parameters.Add(Prm)

        '            Prm = New SqlParameter("@fechaingreso", .FechaEntrega)
        '            Cmd.Parameters.Add(Prm)

        '            Prm = New SqlParameter("@observacion", IIf(.Observacion = String.Empty, DBNull.Value, .Observacion))
        '            Cmd.Parameters.Add(Prm)

        '            Prm = New SqlParameter("@idsucursal", .IDSucursal)
        '            Cmd.Parameters.Add(Prm)

        '            Prm = New SqlParameter("@idalmacenero", .IDAlmacenero)
        '            Cmd.Parameters.Add(Prm)


        '            Prm = New SqlParameter("@detalles", .XMLDetalle)
        '            Cmd.Parameters.Add(Prm)

        '            Dr = Cmd.ExecuteReader
        '            Dr.Read()

        '            Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
        '            If Retorno Then
        '                MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Generar Nota Ingreso")
        '                Return True
        '            Else
        '                MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Generar Nota Ingreso")

        '            End If

        '        Catch ex As Exception
        '            MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
        '            Retorno = False
        '        Finally
        '            oOrdenOC.Inicializar()
        '            Dr.Close()
        '            Dr = Nothing
        '            Prm = Nothing
        '            Cmd.Dispose()
        '            Cmd = Nothing
        '        End Try

        '        Return Retorno

        '    End With

        'End Function
        Public Function NuevoItemNota(ByVal NKardexAlmacen As Kardex_Almacen) As Boolean
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_NuevoItemNotaAlmacen]"
                comando.Connection = TSQL.ConexionPermanente
                'comando = New SqlCommand("[Almacen].[SpAlm_NuevoItemNotaAlmacen]", TSQL.ConexionPermanente)
                comando.CommandType = CommandType.StoredProcedure

                With NKardexAlmacen
                    param = New SqlParameter("@referencia", .Referencia)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@codproducto", .CodProducto)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@idproducto", IIf(.IDProducto = 0, DBNull.Value, .IDProducto))
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@cantidad", .Cantidad)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@tiponota", .TipoNota)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@codcondicion", .CodCondicion)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@observaciones", .Observaciones)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@idnotaalmacen", .IDNotaAlmacen)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@codalmacen", .CodAlmacen)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@idprovieneva", IIf(.IDProvieneVa = 0, DBNull.Value, .IDProvieneVa))
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@idtrabajador", IIf(.IDTrabajador = 0, DBNull.Value, .IDTrabajador))
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@idunidad", IIf(.IDUnidad = 0, DBNull.Value, .IDUnidad))
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@idkardex", SqlDbType.Int)
                    param.Direction = ParameterDirection.Output
                    comando.Parameters.Add(param)
                End With

                Dr = comando.ExecuteReader
                Dr.Read()

                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Nuevo Item Nota")
                    NKardexAlmacen.IDKardex = comando.Parameters("@idkardex").Value

                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Nuevo Item Nota")
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
        Public Function ProductosPorCodigo(ByVal CodProducto As String, ByVal CodAlmacen As String) As DataTable 'Usado en la Asignacion de NroInventario,FormMantenimiento
            Dim Dt As New DataTable
            Dim Prm As SqlParameter


            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_ProductosPorCodigo]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@codproducto", CodProducto)
                comando.Parameters.Add(Prm)
                Prm = New SqlParameter("@codalmacen", CodAlmacen)
                comando.Parameters.Add(Prm)


                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Reporte Incidente")
                Dt = Nothing
            Finally
                Da = Nothing
                comando.Dispose()
                comando = Nothing
                StrComando = String.Empty
                Prm = Nothing
            End Try
            Return Dt
        End Function
        Public Function CaracteristicasPorCodigoProducto(ByVal CodProducto As String) As DataTable 'Usado en la Asignacion de NroInventario
            Dim Dt As New DataTable
            Dim Prm = New SqlParameter("@codproducto", CodProducto)

            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_CaracteristicasPorCodigoProducto]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                comando.Parameters.Add(Prm)

                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Reporte Incidente")
                Dt = Nothing
            Finally
                Da = Nothing
                comando.Dispose()
                comando = Nothing
                StrComando = String.Empty
                Prm = Nothing
            End Try
            Return Dt
        End Function
        Public Function MostrarCaracteristicasPorCodigoProducto(ByVal CodProducto As String) As DataTable 'Usado en la Asignacion de NroInventario
            Dim Dt As New DataTable
            Dim Prm = New SqlParameter("@codproducto", CodProducto)

            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarCaracteristicasPorCodigoProducto]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                comando.Parameters.Add(Prm)

                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Reporte Incidente")
                Dt = Nothing
            Finally
                Da = Nothing
                comando.Dispose()
                comando = Nothing
                StrComando = String.Empty
                Prm = Nothing
            End Try
            Return Dt
        End Function

        Public Function MostrarCaracteristicasPorCodProducto(ByVal CodProducto As String) As DataTable 'Usado en la Asignacion de NroInventario
            Dim Dt As New DataTable
            Dim Prm = New SqlParameter("@codproducto", CodProducto)

            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarCaracteristicasPorCodProducto]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                comando.Parameters.Add(Prm)

                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Reporte Incidente")
                Dt = Nothing
            Finally
                Da = Nothing
                comando.Dispose()
                comando = Nothing
                StrComando = String.Empty
                Prm = Nothing
            End Try
            Return Dt
        End Function

        Public Function MostrarCaracteristicasParticularesPorAsignar(ByVal IDProducto As Integer) As DataTable 'si este queda elanterior no va MostrarCaracteristicasPorCodProducto
            Dim Dt As New DataTable
            Dim Prm = New SqlParameter("@idproducto", IDProducto)

            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarCaracteristicasParticularesPorAsignar]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                comando.Parameters.Add(Prm)

                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Asignación Características")
                Dt = Nothing
            Finally
                Da = Nothing
                comando.Dispose()
                comando = Nothing
                StrComando = String.Empty
                Prm = Nothing
            End Try
            Return Dt
        End Function

        Public Function MostrarCaracteristicasPorAsignar(ByVal IDProducto As Integer) As DataTable 'Usado en la Asignacion de NroInventario
            Dim Dt As New DataTable
            Dim Prm = New SqlParameter("@idproducto", IDProducto)

            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarCaracteristicasPorAsignar]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                comando.Parameters.Add(Prm)

                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Asignación Características")
                Dt = Nothing
            Finally
                Da = Nothing
                comando.Dispose()
                comando = Nothing
                StrComando = String.Empty
                Prm = Nothing
            End Try
            Return Dt
        End Function

        Public Function RegistrarCaracteristicaPorCodigo(ByVal oCaracteristicas As Caracteristicas_Producto) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            With oCaracteristicas
                Try
                    Cmd.CommandText = "[Almacen].[SpAlm_RegistrarCaractPorCodigo]"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure


                    Prm = New SqlParameter("@caracteristicas", IIf(.XMLCaractPorCodigoProducto = String.Empty, DBNull.Value, .XMLCaractPorCodigoProducto))
                    Cmd.Parameters.Add(Prm)


                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If



                    Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Registrar Características")
                        Return True
                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Registrar Características")

                    End If

                Catch ex As Exception
                    MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                    Retorno = False
                Finally
                    ' oOrdenOC.Inicializar()
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

        Public Function QuitarCaracteristicaPorCodigo(ByVal oCaracteristicas As Caracteristicas_Producto) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            With oCaracteristicas
                Try
                    Cmd.CommandText = "[Almacen].[SpAlm_QuitarCaractPorCodigo]"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure


                    Prm = New SqlParameter("@caracteristicas", IIf(.XMLCaractPorCodigoProducto = String.Empty, DBNull.Value, .XMLCaractPorCodigoProducto))
                    Cmd.Parameters.Add(Prm)


                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If

                    Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Registrar Características")
                        Return True
                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Registrar Características")

                    End If

                Catch ex As Exception
                    MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                    Retorno = False
                Finally
                    ' oOrdenOC.Inicializar()
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

        Public Function RegistrarDetallesCaracteristicasProducto(ByVal oCaracteristicas As Caracteristicas_Producto) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            With oCaracteristicas
                Try
                    Cmd.CommandText = "[Almacen].[SpAlm_RegistrarDetallesCaractProducto]"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure


                    Prm = New SqlParameter("@caracteristicas", IIf(.XMLDetallesCaractProductos = String.Empty, DBNull.Value, .XMLDetallesCaractProductos))
                    Cmd.Parameters.Add(Prm)

                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If


                    Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Registrar Características")
                        Return True
                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Registrar Características")

                    End If

                Catch ex As Exception
                    MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                    Retorno = False
                Finally
                    ' oOrdenOC.Inicializar()

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
        Public Function ActualizarCaracteristicasProducto(ByVal XML As String) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            ' With oCaracteristicas
            Try
                Cmd.CommandText = "[Almacen].[SpAlm_ActualizarCaracteristicasProducto]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure


                Prm = New SqlParameter("@producto", IIf(XML = String.Empty, DBNull.Value, XML))
                Cmd.Parameters.Add(Prm)

                If Cmd.Connection.State = ConnectionState.Closed Then
                    Cmd.Connection.Open()
                End If

                Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()

                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Codificación Productos")
                    Return True
                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Codificación Productos")

                End If

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                Retorno = False
            Finally
                ' oOrdenOC.Inicializar()
                If Not IsNothing(Dr) Then
                    Dr.Close()
                End If


                Dr = Nothing
                Prm = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno

            'End With

        End Function
        Public Function MostrarCaracteristicasAsignadas(ByVal IDProducto As Integer) As DataTable 'Usado en la actualizacion de caracteristicas
            Dim Dt As New DataTable
            Dim Prm = New SqlParameter("@idproducto", IDProducto)

            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarCaracteristicasaAsignadas]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                comando.Parameters.Add(Prm)

                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Asignación Características")
                Dt = Nothing
            Finally
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                Prm = Nothing
            End Try
            Return Dt
        End Function
        Public Function ActualizarDetallesCaracteristicasProducto(ByVal oCaracteristicas As Caracteristicas_Producto) As Boolean ' se podria unir luego con el registrar
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            With oCaracteristicas
                Try
                    Cmd.CommandText = "[Almacen].[SpAlm_ActualizarDetallesCaractProducto]"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure


                    Prm = New SqlParameter("@caracteristicas", IIf(.XMLDetallesCaractProductos = String.Empty, DBNull.Value, .XMLDetallesCaractProductos))
                    Cmd.Parameters.Add(Prm)

                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If


                    Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Actualización Características")
                        Return True
                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Actualización Características")

                    End If

                Catch ex As Exception
                    MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                    Retorno = False
                Finally
                    ' oOrdenOC.Inicializar()
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

        Public Function ActualizarCaracteristicaPorCodigo(ByVal oCaractPorCodigoProducto As Caracteristicas_Producto.Caract_PorCodigo_Producto) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            With oCaractPorCodigoProducto
                Try
                    Cmd.CommandText = "[Almacen].[SpAlm_ActualizarCaractPorCodigoAux]"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure

                    Prm = New SqlParameter("@codproducto", .CodProducto)
                    Cmd.Parameters.Add(Prm)
                    Prm = New SqlParameter("@idcaractproducto", .IDCaractProducto)
                    Cmd.Parameters.Add(Prm)
                    Prm = New SqlParameter("@esparticular", .EsParticular)
                    Cmd.Parameters.Add(Prm)

                    'Prm = New SqlParameter("@caracteristicas", IIf(.XMLCaractPorCodigoProducto = String.Empty, DBNull.Value, .XMLCaractPorCodigoProducto))
                    'Cmd.Parameters.Add(Prm)
                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If


                    Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Registrar Características")
                        Return True
                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Registrar Características")

                    End If

                Catch ex As Exception
                    MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                    Retorno = False
                Finally
                    ' oOrdenOC.Inicializar()
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

        Public Function AsignarValoresCaractPorCodProducto(ByVal oCaracteristicas As Caracteristicas_Producto) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            With oCaracteristicas
                Try
                    Cmd.CommandText = "[Almacen].[SpAlm_AsignarValoresValoresCaractPorCodProducto]"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure


                    Prm = New SqlParameter("@caracteristicas", IIf(.XMLCaractPorCodigoProducto = String.Empty, DBNull.Value, .XMLCaractPorCodigoProducto))
                    Cmd.Parameters.Add(Prm)


                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If

                    Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Registrar Características")
                        Return True
                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Registrar Características")

                    End If

                Catch ex As Exception
                    MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                    Retorno = False
                Finally
                    ' oOrdenOC.Inicializar()
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
        Public Function VerProductosPorRecibir(ByVal IDSucursal As Integer) As DataTable
            Dim Dt As New DataTable
            Dim Prm As SqlParameter
            ' Dim Prm = New SqlParameter("@codproducto", CodProducto)

            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_VerProductosPorRecibir]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@idprovieneva", IDSucursal)
                comando.Parameters.Add(Prm)


                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Reporte Incidente")
                Dt = Nothing
            Finally
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                Prm = Nothing
            End Try
            Return Dt
        End Function

        Public Function RegistrarNotaAlmacenPorTraslado(ByVal oNotaAlmacen As Notas_Almacen) As Boolean 'Despues juntarlo con RegistrarNotaAlmacen

            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            With oNotaAlmacen

                Try
                    'Cmd.CommandText = "[Almacen].[SpAlm_NuevaNotaAlmacen]"


                    Cmd.CommandText = "[Almacen].[SpAlm_NuevaNotaAlmacenPorTraslado]" 'probando para tipos NOTAS especiales


                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure

                    Prm = New SqlParameter("@fechanota", .FechaNota)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@observaciones", IIf(.Observacion = String.Empty, DBNull.Value, .Observacion))
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@codalmacen", .CodAlmacen)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@codmovi", .CodMovi)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@idalmacenero", .IDAlmacenero)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@idsucursal", .IDSucursal)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@tiponota", .TipoNota)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@pcodificados", IIf(.XMLKardex = String.Empty, DBNull.Value, .XMLKardex)) ' codificable
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@pnocodificados", IIf(.XMLKardexNoCodificable = String.Empty, DBNull.Value, .XMLKardexNoCodificable))
                    Cmd.Parameters.Add(Prm)

                    If .IDProveedor > 0 Then
                        Prm = New SqlParameter("@idproveedor", .IDProveedor)  'si es pro Ocompra va a ser null
                        Cmd.Parameters.Add(Prm)
                    Else
                        Prm = New SqlParameter("@idproveedor", DBNull.Value)  'si es pro Ocompra va a ser null
                        Cmd.Parameters.Add(Prm)
                    End If

                    Prm = New SqlParameter("@nota", SqlDbType.VarChar, 50)
                    Prm.Direction = ParameterDirection.Output
                    Cmd.Parameters.Add(Prm)



                    Dr = Cmd.ExecuteReader
                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Registro Ingreso")
                        oNotaAlmacen.NroNota = Cmd.Parameters("@nota").Value    ' en caso de éxito obtiene el Nro de Nota asignado
                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Registro Ingreso")
                    End If

                Catch ex As Exception
                    MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                    Retorno = False
                Finally

                    Dr.Close()
                    Dr = Nothing
                    Prm = Nothing
                    Cmd.Dispose()
                    Cmd = Nothing
                End Try

                Return Retorno

            End With

        End Function

        Public Function VerProductosEnviados(ByVal IDSucursal As Integer) As DataTable
            Dim Dt As New DataTable
            Dim Prm As SqlParameter
            ' Dim Prm = New SqlParameter("@codproducto", CodProducto)

            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_VerProductosEnviados]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@idprovieneva", IDSucursal)
                comando.Parameters.Add(Prm)


                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Reporte Incidente")
                Dt = Nothing
            Finally
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                Prm = Nothing
            End Try
            Return Dt
        End Function

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class

End Namespace


