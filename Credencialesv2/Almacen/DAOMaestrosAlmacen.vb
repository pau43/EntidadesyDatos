Imports System.Text
Imports System.Data.SqlClient
Imports PoolConexiones
Imports GEACEntidades.Almacen
'Imports GEACEntidades.EAlmacen
Namespace DAOAlmacen
    Public Class DAOMaestrosAlmacen
        Private Advertencia As String = String.Empty
#Region "CodigosProductos"
        Public Function CargarMaestroCodigosProducto() As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MaestroCodigoProducto]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                Da = New SqlDataAdapter(comando)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Proveedores")
                tabla = Nothing
            Finally
                'Dr.Close()
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
            End Try

            Return tabla

        End Function
        'Public Function NuevoCodigoProducto(ByVal NCodigoProducto As Codigos_Producto) As Boolean
        '    Dim Cmd As New SqlCommand
        '    Dim Prm As SqlParameter
        '    Dim Retorno As Boolean
        '    Dim Dr As SqlDataReader = nothing

        '    With NCodigoProducto
        '        Try
        '            Cmd.CommandText = "Almacen.SpAlm_NuevoCodigoProducto"
        '            Cmd.Connection = TSQL.ConexionPermanente
        '            Cmd.CommandType = CommandType.StoredProcedure

        '            Prm = New SqlParameter("@codproducto", .CodProducto)
        '            Cmd.Parameters.Add(Prm)

        '            Prm = New SqlParameter("@descripcion", .Descripcion)
        '            Cmd.Parameters.Add(Prm)

        '            Prm = New SqlParameter("@procedencia", IIf(.Procedencia = String.Empty, DBNull.Value, .Procedencia))
        '            Cmd.Parameters.Add(Prm)

        '            Prm = New SqlParameter("@observaciones", IIf(.Observaciones = String.Empty, DBNull.Value, .Observaciones))
        '            Cmd.Parameters.Add(Prm)

        '            Prm = New SqlParameter("@idmarca", IIf(.IDMarca <= 0, DBNull.Value, .IDMarca))
        '            Cmd.Parameters.Add(Prm)

        '            Prm = New SqlParameter("@idtipoproducto", IIf(.IDTipoProducto <= 0, DBNull.Value, .IDTipoProducto))
        '            Cmd.Parameters.Add(Prm)

        '            Prm = New SqlParameter("@secodifica", .SeCodifica)
        '            Cmd.Parameters.Add(Prm)


        '            Dr = Cmd.ExecuteReader
        '            Dr.Read()

        '            Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
        '            If Retorno Then
        '                MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Codigos Producto")

        '            Else
        '                MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Codigos Producto")

        '            End If

        '        Catch ex As Exception
        '            MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
        '            Retorno = False
        '        Finally

        '            Dr.Close()
        '            Dr = Nothing
        '            Prm = Nothing
        '            Cmd.Dispose()
        '            Cmd = Nothing
        '        End Try

        '        Return Retorno

        '    End With

        'End Function

        'Public Function ModificarCodigosProducto(ByVal MCodigoProducto As Codigos_Producto) As Boolean
        '    Dim Cmd As New SqlCommand
        '    Dim Prm As SqlParameter
        '    Dim Retorno As Boolean
        '    Dim Dr As SqlDataReader = nothing

        '    With MCodigoProducto
        '        Try
        '            Cmd.CommandText = "Almacen.SpAlm_ModificarCodigoProducto"
        '            Cmd.Connection = TSQL.ConexionPermanente
        '            Cmd.CommandType = CommandType.StoredProcedure

        '            Prm = New SqlParameter("@codproducto", .CodProducto)
        '            Cmd.Parameters.Add(Prm)

        '            Prm = New SqlParameter("@descripcion", .Descripcion)
        '            Cmd.Parameters.Add(Prm)

        '            Prm = New SqlParameter("@procedencia", IIf(.Procedencia = String.Empty, DBNull.Value, .Procedencia))
        '            Cmd.Parameters.Add(Prm)

        '            Prm = New SqlParameter("@observaciones", IIf(.Observaciones = String.Empty, DBNull.Value, .Observaciones))
        '            Cmd.Parameters.Add(Prm)

        '            Prm = New SqlParameter("@habilitado", .Habilitado)
        '            Cmd.Parameters.Add(Prm)

        '            Prm = New SqlParameter("@idmarca", IIf(.IDMarca <= 0, DBNull.Value, .IDMarca))
        '            Cmd.Parameters.Add(Prm)

        '            Prm = New SqlParameter("@idtipoproducto", IIf(.IDTipoProducto <= 0, DBNull.Value, .IDTipoProducto))
        '            Cmd.Parameters.Add(Prm)

        '            Prm = New SqlParameter("@secodifica", .SeCodifica)
        '            Cmd.Parameters.Add(Prm)


        '            Dr = Cmd.ExecuteReader
        '            Dr.Read()

        '            Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
        '            If Retorno Then
        '                MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Codigos Producto")

        '            Else
        '                MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Codigos Producto")

        '            End If

        '        Catch ex As Exception
        '            MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
        '            Retorno = False
        '        Finally

        '            Dr.Close()
        '            Dr = Nothing
        '            Prm = Nothing
        '            Cmd.Dispose()
        '            Cmd = Nothing
        '        End Try

        '        Return Retorno

        '    End With

        'End Function
        'Public Function EliminarCodigoProducto(ByVal oCodigoProducto As Codigos_Producto) As Boolean
        '    Dim valor As Boolean = True

        '    Dim comando As New SqlCommand
        '    Dim param As SqlParameter
        '    Dim Retorno As Boolean
        '    Dim Lector As SqlDataReader = nothing

        '    Try
        '        comando.CommandText = "[Almacen].[SpAlm_EliminarCodigoProducto]"
        '        comando.Connection = TSQL.ConexionPermanente
        '        comando.CommandType = CommandType.StoredProcedure

        '        param = New SqlParameter("@CodProducto", oCodigoProducto.CodProducto)
        '        comando.Parameters.Add(param)

        '        Lector = comando.ExecuteReader
        '        Lector.Read()
        '        Retorno = TSQL.CodigoRetorno(Lector.GetString(0), Advertencia)
        '        If Retorno Then
        '            MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Códigos Producto")
        '        Else
        '            MsgBox(Advertencia, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Códigos Producto")

        '        End If

        '    Catch ex As Exception
        '        MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
        '        Retorno = False
        '    Finally

        '        Lector.Close()
        '        Lector = Nothing
        '        param = Nothing
        '        comando.Dispose()
        '        comando = Nothing
        '    End Try


        '    Return Retorno




        'End Function




#End Region
#Region "Tipos Producto"

        Public Function CargarMaestroTiposProducto() As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MaestroTiposProducto]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                Da = New SqlDataAdapter(comando)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Proveedores")
                tabla = Nothing
            Finally
                'Dr.Close()
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
            End Try

            Return tabla

        End Function

        Public Function NuevoTipoProducto(ByVal NTipoProducto As TiposProductos) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            With NTipoProducto
                Try
                    Cmd.CommandText = "[Almacen].[SpAlm_NuevoTiposProducto]"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure

                    Prm = New SqlParameter("@descripcion", .Descripcion)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@accion", "N")
                    Cmd.Parameters.Add(Prm)

                    'Prm = New SqlParameter("@idcaractproducto", "'DEFAULT'")
                    'Cmd.Parameters.Add(Prm)

                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If



                    Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Tipos Producto")

                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Tipos Producto")

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

        Public Function ModificarTiposProducto(ByVal NTiposProducto As TiposProductos) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            With NTiposProducto
                Try
                    Cmd.CommandText = "[Almacen].[SpAlm_NuevoTiposProducto]"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure


                    Prm = New SqlParameter("@descripcion", .Descripcion)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@accion", "M")
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@idtipoproducto", .IDTipoProducto)
                    Cmd.Parameters.Add(Prm)

                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If

                    Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Tipos Producto")
                        ' Return True
                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Tipos Producto")

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

        Public Function EliminarTiposProducto(ByVal NTiposProducto As TiposProductos) As Boolean
            Dim valor As Boolean = True

            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Lector As SqlDataReader = Nothing

            Try

                comando.CommandText = "[Almacen].[SpAlm_NuevoTiposProducto]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure
                'comando = New SqlCommand("[Almacen].[SpAlm_NuevoTiposProducto]", TSQL.ConexionPermanente)
                'comando.CommandType = CommandType.StoredProcedure
                param = New SqlParameter("@descripcion", NTiposProducto.Descripcion)
                comando.Parameters.Add(param)
                param = New SqlParameter("@accion", "E")
                comando.Parameters.Add(param)
                param = New SqlParameter("@idtipoproducto", NTiposProducto.IDTipoProducto)
                comando.Parameters.Add(param)

                If comando.Connection.State = ConnectionState.Closed Then
                    comando.Connection.Open()
                End If

                Lector = comando.ExecuteReader(CommandBehavior.CloseConnection)
                Lector.Read()
                Retorno = TSQL.CodigoRetorno(Lector.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Tipos Producto")
                Else
                    MsgBox(Advertencia, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Tipos Producto")
                    'Return False
                End If

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                Retorno = False
            Finally
                If Not IsNothing(Lector) Then
                    Lector.Close()
                End If


                Lector = Nothing
                param = Nothing
                comando.Dispose()
                comando = Nothing

            End Try
            Return Retorno

        End Function


#End Region
#Region "Familia Productos"

        'Public Function CargarMaestroFamiliaProducto() As DataTable
        '    Dim tabla As New DataTable
        '    Dim comando As New SqlCommand
        '    Dim Da As SqlDataAdapter
        '    Dim StrComando = "[Almacen].[SpAlm_MaestroFamiliaProductos]"
        '    Try

        '        comando.CommandText = StrComando
        '        comando.Connection = TSQL.ConexionPermanente
        '        comando.CommandType = CommandType.StoredProcedure

        '        Da = New SqlDataAdapter(comando)
        '        Da.Fill(tabla)

        '    Catch ex As Exception
        '        MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Familia Productos")
        '        tabla = Nothing
        '    Finally

        '        Da = Nothing
        '        comando = Nothing
        '        StrComando = String.Empty
        '    End Try
        '    Return tabla

        'End Function

        Public Function NuevoFamiliaProducto(ByRef OFamiliaProducto As FamiliaProducto) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            With OFamiliaProducto
                Try
                    Cmd.CommandText = "[Almacen].[SpAlm_NuevaFamiliaProducto]"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure

                    Prm = New SqlParameter("@Descripcion", .Descripcion)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@EquipadoA", .EquipadoA)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@NroFamilia", SqlDbType.Int)
                    Prm.Direction = ParameterDirection.Output
                    Cmd.Parameters.Add(Prm)

                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If

                    Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Familia Producto")

                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Familia Producto")

                    End If

                Catch ex As Exception
                    MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                    Retorno = False
                Finally
                    If Not IsNothing(Dr) Then
                        Dr.Close()
                        If Not Cmd.Parameters("@NroFamilia").Value Is DBNull.Value Then
                            .NroFamilia = Cmd.Parameters("@NroFamilia").Value
                        End If
                    End If
                    Dr = Nothing
                    Prm = Nothing
                    Cmd.Dispose()
                    Cmd = Nothing
                End Try
                Return Retorno
            End With


        End Function

        Public Function ModificarFamiliaProducto(ByVal OFamiliaProducto As FamiliaProducto) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            With OFamiliaProducto
                Try
                    Cmd.CommandText = "[Almacen].[SpAlm_ModificarFamiliaProducto]"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure

                    Prm = New SqlParameter("@Descripcion", .Descripcion)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@EquipadoA", .EquipadoA)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@NroFamilia", .NroFamilia)
                    Cmd.Parameters.Add(Prm)


                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If


                    Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Familia Producto")

                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Familia Producto")

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

        Public Function EliminarFamiliaProducto(ByVal OFamiliaProducto As FamiliaProducto) As Boolean
            Dim valor As Boolean = True

            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Lector As SqlDataReader = Nothing

            Try

                comando.CommandText = "[Almacen].[SpAlm_EliminarFamiliaProducto]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure


                param = New SqlParameter("@NroFamilia", OFamiliaProducto.NroFamilia)
                comando.Parameters.Add(param)


                If comando.Connection.State = ConnectionState.Closed Then
                    comando.Connection.Open()
                End If

                Lector = comando.ExecuteReader(CommandBehavior.CloseConnection)
                Lector.Read()
                Retorno = TSQL.CodigoRetorno(Lector.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Familia Producto")
                Else
                    MsgBox(Advertencia, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Familia Producto")
                    'Return False
                End If

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                Retorno = False
            Finally
                If Not IsNothing(Lector) Then
                    Lector.Close()
                End If
                Lector = Nothing
                param = Nothing
                comando.Dispose()
                comando = Nothing

            End Try
            Return Retorno

        End Function


#End Region
#Region "Marcas"
        Public Function CargarMaestroMarcas() As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "Almacen.SpAlm_MaestroMarcas"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                Da = New SqlDataAdapter(comando)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Proveedores")
                tabla = Nothing
            Finally
                'Dr.Close()
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
            End Try

            Return tabla

        End Function

        Public Function NuevaMarca(ByVal NMarca As Marcas) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            With NMarca
                Try
                    Cmd.CommandText = "[Almacen].[SpAlm_NuevaMarca]"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure

                    Prm = New SqlParameter("@descripcion", .Descripcion)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@accion", "N")
                    Cmd.Parameters.Add(Prm)

                    'Prm = New SqlParameter("@idmarca", .IDMarca)
                    'Cmd.Parameters.Add(Prm)

                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If


                    Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Tipos Producto")

                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Tipos Producto")

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
        Public Function ModificarMarca(ByVal NMarca As Marcas) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            With NMarca
                Try
                    Cmd.CommandText = "[Almacen].[SpAlm_NuevaMarca]"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure
                    Prm = New SqlParameter("@descripcion", .Descripcion)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@accion", "M")
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@idmarca", .IDMarca)
                    Cmd.Parameters.Add(Prm)

                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If

                    Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)

                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Marcas")

                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Marcas")
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

        Public Function EliminarMarca(ByVal MMarca As Marcas) As Boolean

            Dim valor As Boolean = True
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Lector As SqlDataReader = Nothing
            Try

                comando.CommandText = "[Almacen].[SpAlm_NuevaMarca]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                With MMarca

                    param = New SqlParameter("@descripcion", .Descripcion)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@accion", "E")
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@idmarca", .IDMarca)
                    comando.Parameters.Add(param)

                End With

                If comando.Connection.State = ConnectionState.Closed Then
                    comando.Connection.Open()
                End If

                Lector = comando.ExecuteReader

                Lector.Read()
                Retorno = TSQL.CodigoRetorno(Lector.GetString(0), Advertencia)

                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Marcas")
                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Marcas")
                End If

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                Retorno = False
            Finally

                If Not IsNothing(Lector) Then
                    Lector.Close()
                End If

                Lector = Nothing
                param = Nothing
                comando.Dispose()
                comando = Nothing
            End Try

            Return Retorno

        End Function

#End Region
#Region "Caracteristicas Producto"
        Public Function CargarMaestroCaracteristicas() As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MaestroCaracteristica]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                Da = New SqlDataAdapter(comando)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Proveedores")
                tabla = Nothing
            Finally
                'Dr.Close()
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
            End Try

            Return tabla

        End Function

        Public Function NuevaCaracteristica(ByVal NCaracteristica As Caracteristicas_Producto) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            With NCaracteristica
                Try
                    Cmd.CommandText = "[Almacen].[SpAlm_NuevaCaracteristica]"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure

                    Prm = New SqlParameter("@descripcion", .Descripcion)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@accion", "N")
                    Cmd.Parameters.Add(Prm)

                    'Prm = New SqlParameter("@idcaractproducto", "'DEFAULT'")
                    'Cmd.Parameters.Add(Prm)


                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If


                    Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Características")

                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Características")

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

        Public Function ModificarCaracteristica(ByVal NCaracteristica As Caracteristicas_Producto) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            With NCaracteristica
                Try
                    Cmd.CommandText = "[Almacen].[SpAlm_NuevaCaracteristica]"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure


                    Prm = New SqlParameter("@descripcion", .Descripcion)
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@accion", "M")
                    Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@idcaractproducto", .IDCaractProducto)
                    Cmd.Parameters.Add(Prm)


                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If

                    Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Características")

                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Características")

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

        Public Function EliminarCaracteristica(ByVal NCaracteristica As Caracteristicas_Producto) As Boolean
            Dim valor As Boolean = True

            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Lector As SqlDataReader = Nothing

            Try
                comando = New SqlCommand("[Almacen].[SpAlm_NuevaCaracteristica]", TSQL.ConexionPermanente)
                comando.CommandType = CommandType.StoredProcedure


                param = New SqlParameter("@descripcion", NCaracteristica.Descripcion)
                comando.Parameters.Add(param)

                param = New SqlParameter("@accion", "E")
                comando.Parameters.Add(param)

                param = New SqlParameter("@idcaractproducto", NCaracteristica.IDCaractProducto)
                comando.Parameters.Add(param)

                If comando.Connection.State = ConnectionState.Closed Then
                    comando.Connection.Open()
                End If

                Lector = comando.ExecuteReader(CommandBehavior.CloseConnection)
                Lector.Read()
                Retorno = TSQL.CodigoRetorno(Lector.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Característica")
                Else
                    MsgBox(Advertencia, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Característica")

                End If

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                Retorno = False

            Finally

                If Not IsNothing(Lector) Then
                    Lector.Close()
                End If

                Lector = Nothing
                param = Nothing
                comando.Dispose()
                comando = Nothing
            End Try


            Return Retorno

        End Function
        Public Function ActualizarCodificacionProductos(ByVal oProducto As Productos) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            With oProducto
                Try
                    Cmd.CommandText = "[Almacen].[SpAlm_ActualizarCodificacionProducto]"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure


                    Prm = New SqlParameter("@idproducto", .IDProducto)
                    Cmd.Parameters.Add(Prm)
                    Prm = New SqlParameter("@nroinventario", IIf(.NroInventario = String.Empty, DBNull.Value, .NroInventario))
                    Cmd.Parameters.Add(Prm)
                    Prm = New SqlParameter("@serie", IIf(.Serie = String.Empty, DBNull.Value, .Serie))
                    Cmd.Parameters.Add(Prm)
                    Prm = New SqlParameter("@nroparte", IIf(.NroParte = String.Empty, DBNull.Value, .NroParte))
                    Cmd.Parameters.Add(Prm)
                    Prm = New SqlParameter("@codigobarras", IIf(.CodigoBarras = String.Empty, DBNull.Value, .CodigoBarras))
                    Cmd.Parameters.Add(Prm)
                    Prm = New SqlParameter("@codcondicion", IIf(.CodigoCondicion = String.Empty, DBNull.Value, .CodigoCondicion))
                    Cmd.Parameters.Add(Prm)
                    Prm = New SqlParameter("@observacion", IIf(.Observacion = String.Empty, DBNull.Value, .Observacion))
                    Cmd.Parameters.Add(Prm)


                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If


                    Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Actualización Productos")

                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Actualización Productos")

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

        Public Function DarDeBajaProducto(ByVal oProducto As Productos) As Boolean
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            With oProducto
                Try
                    Cmd.CommandText = "[Almacen].[SpAlm_DarDeBajaProducto]"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure


                    Prm = New SqlParameter("@idproducto", .IDProducto)
                    Cmd.Parameters.Add(Prm)
                    Prm = New SqlParameter("@fechabaja", .FechaBaja)
                    Cmd.Parameters.Add(Prm)
                    Prm = New SqlParameter("@motivobaja", IIf(.MotivoBaja = String.Empty, DBNull.Value, .MotivoBaja))
                    Cmd.Parameters.Add(Prm)



                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If

                    Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Actualización Productos")

                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Actualización Productos")

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
#End Region
#Region "Almacenes"

        'Public Function CargarMaestroAlmacenes() As DataTable
        '    Dim tabla As New DataTable
        '    Dim comando As New SqlCommand
        '    Dim Da As SqlDataAdapter
        '    Dim StrComando = "[Almacen].[SpAlm_MaestroAlmacenes]"
        '    Try

        '        comando.CommandText = StrComando
        '        comando.Connection = TSQL.ConexionPermanente
        '        comando.CommandType = CommandType.StoredProcedure

        '        Da = New SqlDataAdapter(comando)
        '        Da.Fill(tabla)

        '    Catch ex As Exception
        '        MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Almacenes")
        '        tabla = Nothing
        '    Finally
        '        'Dr.Close()
        '        Da = Nothing
        '        comando = Nothing
        '        StrComando = String.Empty
        '    End Try

        '    Return tabla

        'End Function

        'Public Function NuevoAlmacen(ByVal NAlmacen As Almacen) As Boolean
        '    Dim Cmd As New SqlCommand
        '    Dim Prm As SqlParameter
        '    Dim Retorno As Boolean
        '    Dim Dr As SqlDataReader = nothing

        '    With NAlmacen
        '        Try
        '            Cmd.CommandText = "[Almacen].[SpAlm_NuevoAlmacenTRC]"
        '            Cmd.Connection = TSQL.ConexionPermanente
        '            Cmd.CommandType = CommandType.StoredProcedure

        '            Prm = New SqlParameter("@codigo", .CodAlmacen)
        '            Cmd.Parameters.Add(Prm)

        '            Prm = New SqlParameter("@descripcion", .Descripcion)
        '            Cmd.Parameters.Add(Prm)

        '            Prm = New SqlParameter("@idsucursal", .IDSucursal)
        '            Cmd.Parameters.Add(Prm)

        '            'Prm = New SqlParameter("@accion", "N")
        '            'Cmd.Parameters.Add(Prm)

        '            Dr = Cmd.ExecuteReader
        '            Dr.Read()

        '            Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
        '            If Retorno Then
        '                MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Almacenes")

        '            Else
        '                MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Almacenes")

        '            End If

        '        Catch ex As Exception
        '            MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
        '            Retorno = False
        '        Finally

        '            Dr.Close()
        '            Dr = Nothing
        '            Prm = Nothing
        '            Cmd.Dispose()
        '            Cmd = Nothing
        '        End Try

        '        Return Retorno

        '    End With

        'End Function
        'Public Function ModificarAlmacen(ByVal NAlmacen As Almacen) As Boolean
        '    Dim Cmd As New SqlCommand
        '    Dim Prm As SqlParameter
        '    Dim Retorno As Boolean
        '    Dim Dr As SqlDataReader = nothing

        '    With NAlmacen
        '        Try
        '            Cmd.CommandText = "[Almacen].[SpAlm_NuevoAlmacenTRC]"
        '            Cmd.Connection = TSQL.ConexionPermanente
        '            Cmd.CommandType = CommandType.StoredProcedure

        '            Prm = New SqlParameter("@codigo", .CodAlmacen)
        '            Cmd.Parameters.Add(Prm)

        '            Prm = New SqlParameter("@descripcion", .Descripcion)
        '            Cmd.Parameters.Add(Prm)

        '            Prm = New SqlParameter("@idsucursal", .IDSucursal)
        '            Cmd.Parameters.Add(Prm)

        '            Prm = New SqlParameter("@accion", "M")
        '            Cmd.Parameters.Add(Prm)

        '            Dr = Cmd.ExecuteReader
        '            Dr.Read()

        '            Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
        '            If Retorno Then
        '                MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Almacenes")

        '            Else
        '                MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Almacenes")

        '            End If

        '        Catch ex As Exception
        '            MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
        '            Retorno = False
        '        Finally

        '            Dr.Close()
        '            Dr = Nothing
        '            Prm = Nothing
        '            Cmd.Dispose()
        '            Cmd = Nothing
        '        End Try

        '        Return Retorno

        '    End With

        'End Function

        'Public Function EliminarAlmacen(ByVal OAlmacen As Almacen) As Boolean
        '    Dim valor As Boolean = True

        '    Dim comando As New SqlCommand
        '    Dim param As SqlParameter
        '    Dim Retorno As Boolean
        '    Dim Lector As SqlDataReader = nothing

        '    Try

        '        With OAlmacen

        '            comando.CommandText = "[Almacen].[SpAlm_NuevoAlmacenTRC]"
        '            comando.Connection = TSQL.ConexionPermanente
        '            comando.CommandType = CommandType.StoredProcedure


        '            param = New SqlParameter("@codigo", .CodAlmacen)
        '            comando.Parameters.Add(param)

        '            param = New SqlParameter("@descripcion", .Descripcion)
        '            comando.Parameters.Add(param)

        '            param = New SqlParameter("@idsucursal", .IDSucursal)
        '            comando.Parameters.Add(param)

        '            param = New SqlParameter("@accion", "E")
        '            comando.Parameters.Add(param)

        '            Lector = comando.ExecuteReader
        '            Lector.Read()
        '            Retorno = TSQL.CodigoRetorno(Lector.GetString(0), Advertencia)
        '            If Retorno Then
        '                MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Almacenes")
        '            Else
        '                MsgBox(Advertencia, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Almacenes")

        '            End If

        '        End With

        '    Catch ex As Exception
        '        MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
        '        Retorno = False
        '    Finally

        '        Lector.Close()
        '        Lector = Nothing
        '        param = Nothing
        '        comando.Dispose()
        '        comando = Nothing
        '    End Try

        '    Return Retorno

        'End Function

#End Region
#Region "Inventarios Productos"

        Public Function ConsultaInventario(ByVal CodProducto As String, ByVal CodAlmacen As String)
            Dim Dt As New DataTable
            Dim Prm As SqlParameter
            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_ConsultaInventario]"
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

        'Public Function ModificarInventario(ByVal MInventario As Inventarios_Almacen) As Boolean
        '    Dim Cmd As New SqlCommand
        '    Dim Prm As SqlParameter
        '    Dim Retorno As Boolean
        '    Dim Dr As SqlDataReader = nothing

        '    With MInventario
        '        Try
        '            Cmd.CommandText = "Almacen.SpAlm_ModificarInventario"
        '            Cmd.Connection = TSQL.ConexionPermanente
        '            Cmd.CommandType = CommandType.StoredProcedure


        '            Prm = New SqlParameter("@codproducto", .CodProducto)
        '            Cmd.Parameters.Add(Prm)
        '            Prm = New SqlParameter("@codalmacen", .CodAlmacen)
        '            Cmd.Parameters.Add(Prm)
        '            Prm = New SqlParameter("@stockmin", .StockMinimo)
        '            Cmd.Parameters.Add(Prm)
        '            Prm = New SqlParameter("@stockmax", .StockMaximo)
        '            Cmd.Parameters.Add(Prm)
        '            Prm = New SqlParameter("@observaciones", IIf(.Observaciones = String.Empty, DBNull.Value, .Observaciones))
        '            Cmd.Parameters.Add(Prm)

        '            Dr = Cmd.ExecuteReader
        '            Dr.Read()

        '            Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
        '            If Retorno Then
        '                MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Inventarios Almacén")

        '            Else
        '                MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Inventarios Almacén")

        '            End If

        '        Catch ex As Exception
        '            MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
        '            Retorno = False
        '        Finally

        '            Dr.Close()
        '            Dr = Nothing
        '            Prm = Nothing
        '            Cmd.Dispose()
        '            Cmd = Nothing
        '        End Try

        '        Return Retorno

        '    End With

        'End Function
        Public Function CargarProductoPorCodigoYAlmacen(ByVal CodProducto As String, ByVal CodAlmacen As String)
            Dim Dt As New DataTable
            Dim Prm As SqlParameter
            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_ProductosPorCodigoProductoYAlmacen]"
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
#End Region

#Region "Presentacion Producto"

        Public Function NuevaPresentacionProducto(ByRef OPresentacion As PresentacionProducto) As Boolean

            'se utiliza para la operacion de Nuevo,Modificar,Eliminar
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            With OPresentacion
                Try
                    Cmd.CommandText = "[Almacen].[SpAlm_NuevaPresentacionProducto]"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure

                    Prm = New SqlParameter("@presentacion", IIf(.Presentacion.Trim.Length = 0, DBNull.Value, .Presentacion))
                    Cmd.Parameters.Add(Prm)
                    Prm = New SqlParameter("@abrev", IIf(.Abreviatura.Trim.Length = 0, DBNull.Value, .Abreviatura))
                    Cmd.Parameters.Add(Prm)
                    Prm = New SqlParameter("@accion", IIf(.Accion.Trim.Length = 0, DBNull.Value, .Accion))
                    Cmd.Parameters.Add(Prm)

                    'Prm = New SqlParameter("@idpresentacion", IIf(.IDPresentacion <= 0, DBNull.Value, .IDPresentacion), )
                    'Cmd.Parameters.Add(Prm)
                    'Cmd.Parameters("@idpresentacion").Direction = ParameterDirection.InputOutput

                    Prm = New SqlParameter("@idpresentacion", SqlDbType.Int, 4) ', ParameterDirection.InputOutput)
                    Prm.Direction = ParameterDirection.InputOutput

                    If .Accion <> "N" Then
                        Prm.Value = .IDPresentacion
                    End If


                    Cmd.Parameters.Add(Prm)

                    'Cmd.Parameters("@idpresentacion").Direction = ParameterDirection.InputOutput
                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If


                    Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Producto Presentación")
                        'If .Accion = "N" Then
                        '    If Not IsDBNull(Cmd.Parameters("@idpresentacion").Value) Then
                        '        .IDPresentacion = Cmd.Parameters("@idpresentacion").Value
                        '    End If
                        'End If
                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Producto Presentación")

                    End If

                Catch ex As Exception
                    MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                    Retorno = False
                Finally
                    If Not IsNothing(Dr) Then
                        Dr.Close()
                        If Not IsDBNull(Cmd.Parameters("@idpresentacion").Value) Then
                            .IDPresentacion = Cmd.Parameters("@idpresentacion").Value
                        End If
                    End If
                    Dr = Nothing
                    Prm = Nothing

                    If Cmd.Connection.State = ConnectionState.Open Then
                        Cmd.Connection.Close()
                    End If

                    Cmd.Dispose()
                    Cmd = Nothing
                End Try

                Return Retorno

            End With

        End Function

        Public Function NuevaFraccionProducto(ByRef OFraccion As FraccionProducto) As Boolean

            'se utiliza para la operacion de Nuevo,Modificar,Eliminar

            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            With OFraccion

                Try
                    Cmd.CommandText = "[Almacen].[SpAlm_NuevaFraccionProducto]"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure

                    Prm = New SqlParameter("@fraccion", IIf(.Fraccion.Trim.Length = 0, DBNull.Value, .Fraccion))
                    Cmd.Parameters.Add(Prm)
                    Prm = New SqlParameter("@abrev", IIf(.Abreviatura.Trim.Length = 0, DBNull.Value, .Abreviatura))
                    Cmd.Parameters.Add(Prm)
                    Prm = New SqlParameter("@accion", IIf(.Accion.Trim.Length = 0, DBNull.Value, .Accion))
                    Cmd.Parameters.Add(Prm)

                    '    If .Accion <> "N" Then

                    'Prm = New SqlParameter("@idfraccion", IIf(.IDFraccion <= 0, DBNull.Value, .IDFraccion))
                    'Cmd.Parameters.Add(Prm)

                    Prm = New SqlParameter("@idfraccion", SqlDbType.Int, 4) ', ParameterDirection.InputOutput)
                    Prm.Direction = ParameterDirection.InputOutput

                    If .Accion <> "N" Then
                        Prm.Value = .IDFraccion
                    End If
                    Cmd.Parameters.Add(Prm)

                    'End If

                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If

                    Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Fracción Producto")
                        If .Accion = "N" Then

                            'If Not IsDBNull(Cmd.Parameters("@idfraccion").Value) Then
                            '    .IDFraccion = Cmd.Parameters("@idfraccion").Value
                            'End If

                        End If
                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Fracción Producto")

                    End If

                Catch ex As Exception
                    MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                    Retorno = False
                Finally

                    'Dr.Close()

                    'If Not IsDBNull(Cmd.Parameters("@idfraccion").Value) Then
                    '    .IDFraccion = Cmd.Parameters("@idfraccion").Value
                    'End If

                    If Not IsNothing(Dr) Then
                        Dr.Close()
                        If Not IsDBNull(Cmd.Parameters("@idfraccion").Value) Then
                            .IDFraccion = Cmd.Parameters("@idfraccion").Value
                        End If
                    End If

                    Dr = Nothing
                    Prm = Nothing

                    If Cmd.Connection.State = ConnectionState.Open Then
                        Cmd.Connection.Close()
                    End If


                    Cmd.Dispose()
                    Cmd = Nothing
                End Try

                Return Retorno
            End With
        End Function

        Public Function NuevaUnidadMedida(ByRef OUnidadMedida As Unidades_Medida) As Boolean

            'se utiliza para la operacion de Nuevo,Modificar,Eliminar
            Dim Cmd As New SqlCommand
            Dim Prm As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            With OUnidadMedida

                Try
                    Cmd.CommandText = "[Almacen].[SpAlm_NuevaUnidadMedida]"
                    Cmd.Connection = TSQL.ConexionPermanente
                    Cmd.CommandType = CommandType.StoredProcedure

                    Prm = New SqlParameter("@unidadmedida", IIf(.Descripcion.Trim.Length = 0, DBNull.Value, .Descripcion))
                    Cmd.Parameters.Add(Prm)
                    Prm = New SqlParameter("@abrev", IIf(.Abreviatura.Trim.Length = 0, DBNull.Value, .Abreviatura))
                    Cmd.Parameters.Add(Prm)
                    Prm = New SqlParameter("@presentacion", .Presentacion)
                    Cmd.Parameters.Add(Prm)
                    Prm = New SqlParameter("@fraccion", .Fraccion)
                    Cmd.Parameters.Add(Prm)
                    Prm = New SqlParameter("@accion", IIf(.Accion.Trim.Length = 0, DBNull.Value, .Accion))
                    Cmd.Parameters.Add(Prm)


                    Prm = New SqlParameter("@idunimedida", SqlDbType.Int, 4) ', ParameterDirection.InputOutput)
                    Prm.Direction = ParameterDirection.InputOutput

                    If .Accion <> "N" Then
                        Prm.Value = .IDUniMedida
                    End If
                    Cmd.Parameters.Add(Prm)

                    'End If

                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If

                    Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    Dr.Read()

                    Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                    If Retorno Then
                        MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Unidad Medida")
                        If .Accion = "N" Then

                            'If Not IsDBNull(Cmd.Parameters("@idfraccion").Value) Then
                            '    .IDFraccion = Cmd.Parameters("@idfraccion").Value
                            'End If

                        End If
                    Else
                        MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Unidad Medida")

                    End If

                Catch ex As Exception
                    MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                    Retorno = False
                Finally

                    'Dr.Close()

                    'If Not IsDBNull(Cmd.Parameters("@idfraccion").Value) Then
                    '    .IDFraccion = Cmd.Parameters("@idfraccion").Value
                    'End If

                    If Not IsNothing(Dr) Then
                        Dr.Close()
                        If Not IsDBNull(Cmd.Parameters("@idunimedida").Value) Then
                            .IDUniMedida = Cmd.Parameters("@idunimedida").Value
                        End If
                    End If

                    Dr = Nothing
                    Prm = Nothing

                    If Cmd.Connection.State = ConnectionState.Open Then
                        Cmd.Connection.Close()
                    End If


                    Cmd.Dispose()
                    Cmd = Nothing
                End Try

                Return Retorno

            End With

        End Function


#End Region

    End Class

End Namespace

