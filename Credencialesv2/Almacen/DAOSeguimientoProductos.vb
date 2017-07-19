Imports System.Data.SqlClient
Imports PoolConexiones
Imports GEACEntidades.Almacen
'Imports GEACEntidades.EAlmacen
Namespace DAOAlmacen
    Public Class DAOSeguimientoProductos
        Private Advertencia As String = String.Empty
        Public Function BuscarProductosPorTrajadorOUnidad(ByVal IDTrabajador As Integer, ByVal IDUnidad As Integer) As DataTable
            Dim Dt As New DataTable
            Dim oTSQL As New TSQL
            Dim Prm As SqlParameter
            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            'Dim StrComando = "[Almacen].[SpAlm_BuscarProductosPorTrabajador]"  Luego Eliminar este SP 
            Dim StrComando = "[Almacen].[SpAlm_BuscarProductosPorTrabajadorOUnidad]"
            Try
                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@idtrabajador", IIf(IDTrabajador <= 0, DBNull.Value, IDTrabajador))
                comando.Parameters.Add(Prm)

                Prm = New SqlParameter("@idunidad ", IIf(IDUnidad <= 0, DBNull.Value, IDUnidad))
                comando.Parameters.Add(Prm)


                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Busqueda Proveedor")
                Dt = Nothing
            Finally
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                Prm = Nothing
            End Try
            Return Dt

        End Function
        Public Function BuscarProductosPorNroInventario(ByVal NroInventario As String) As DataTable 'parecido al anterior BuscarProveedorPorCodigo
            Dim Dt As New DataTable
            Dim oTSQL As New TSQL

            Dim Prm = New SqlParameter("@nroinventario", NroInventario)

            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_BuscarProductosPorNroInventario]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                comando.Parameters.Add(Prm)

                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Busqueda Productos")
                Dt = Nothing
            Finally
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                Prm = Nothing
            End Try
            Return Dt

        End Function
        'Public Function RegistrarSeguimientoProducto(ByVal oSeguimiento As Seguimiento_Productos) As Boolean
        '    Dim comando As New SqlCommand
        '    Dim param As SqlParameter
        '    Dim Retorno As Boolean
        '    Dim Dr As SqlDataReader = nothing

        '    Try
        '        comando.CommandText = "[Almacen].[SpAlm_RegistrarSeguimientoProducto]"
        '        comando.Connection = TSQL.ConexionPermanente
        '        comando.CommandType = CommandType.StoredProcedure

        '        With oSeguimiento
        '            param = New SqlParameter("@fechacontrol", .FechaControl)
        '            comando.Parameters.Add(param)
        '            param = New SqlParameter("@codcondicion", .CodCondicion)
        '            comando.Parameters.Add(param)
        '            param = New SqlParameter("@presente", .Presente)
        '            comando.Parameters.Add(param)
        '            param = New SqlParameter("@observacion", IIf(.Observacion = String.Empty, DBNull.Value, .Observacion))
        '            comando.Parameters.Add(param)
        '            param = New SqlParameter("@idtipoproducto", .IDTipoProducto)
        '            comando.Parameters.Add(param)
        '            param = New SqlParameter("@idproducto", .IDProducto)
        '            comando.Parameters.Add(param)
        '            param = New SqlParameter("@idunidad", IIf(.IDUnidad <= 0, DBNull.Value, .IDUnidad))
        '            comando.Parameters.Add(param)
        '            param = New SqlParameter("@idtrabajador", .IDTrabajador)
        '            comando.Parameters.Add(param)
        '            param = New SqlParameter("@idkardex", .IDKardex)
        '            comando.Parameters.Add(param)
        '            param = New SqlParameter("@idforminsp", IIf(.IDFormInsp = String.Empty, DBNull.Value, .IDFormInsp))
        '            comando.Parameters.Add(param)

        '        End With

        '        Dr = comando.ExecuteReader
        '        Dr.Read()

        '        Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
        '        If Retorno Then
        '            MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Seguimiento Productos")

        '        Else
        '            MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Seguimiento Productos")
        '        End If
        '    Catch ex As Exception
        '        MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
        '        Retorno = False
        '    Finally
        '        Dr.Close()
        '        Dr = Nothing
        '        param = Nothing
        '        comando.Dispose()
        '        comando = Nothing

        '    End Try

        '    Return Retorno

        'End Function

        Public Function RegistrosSeguimientoPorTrabajador(ByVal IDTrabajador As Integer) As DataTable
            Dim Dt As New DataTable
            Dim oTSQL As New TSQL

            Dim Prm = New SqlParameter("@idtrabajador", IDTrabajador)

            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_RegistrosSegPorTrabajador]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                comando.Parameters.Add(Prm)

                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Seguimiento Productos")
                Dt = Nothing
            Finally
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                Prm = Nothing
            End Try
            Return Dt

        End Function

        'Public Function ModificarSeguimientoProducto(ByVal oSeguimiento As Seguimiento_Productos) As Boolean
        '    Dim comando As New SqlCommand
        '    Dim param As SqlParameter
        '    Dim Retorno As Boolean
        '    Dim Dr As SqlDataReader = nothing

        '    Try
        '        comando.CommandText = "[Almacen].[SpAlm_ModificarSeguimientoProducto]"
        '        comando.Connection = TSQL.ConexionPermanente
        '        comando.CommandType = CommandType.StoredProcedure

        '        With oSeguimiento
        '            param = New SqlParameter("@idsegproducto", .IDSegProducto)
        '            comando.Parameters.Add(param)
        '            param = New SqlParameter("@fechacontrol", .FechaControl)
        '            comando.Parameters.Add(param)
        '            param = New SqlParameter("@codcondicion", .CodCondicion)
        '            comando.Parameters.Add(param)
        '            param = New SqlParameter("@presente", .Presente)
        '            comando.Parameters.Add(param)
        '            param = New SqlParameter("@observacion", IIf(.Observacion = String.Empty, DBNull.Value, .Observacion))
        '            comando.Parameters.Add(param)
        '            'param = New SqlParameter("@idtipoproducto", .IDTipoProducto)
        '            'comando.Parameters.Add(param)
        '            param = New SqlParameter("@idproducto", .IDProducto)
        '            comando.Parameters.Add(param)
        '            param = New SqlParameter("@idunidad", IIf(.IDUnidad <= 0, DBNull.Value, .IDUnidad))
        '            comando.Parameters.Add(param)
        '            param = New SqlParameter("@idtrabajador", .IDTrabajador)
        '            'comando.Parameters.Add(param)
        '            'param = New SqlParameter("@idkardex", .IDKardex)
        '            comando.Parameters.Add(param)
        '            param = New SqlParameter("@idforminsp", IIf(.IDFormInsp = String.Empty, DBNull.Value, .IDFormInsp))
        '            comando.Parameters.Add(param)

        '        End With

        '        Dr = comando.ExecuteReader
        '        Dr.Read()

        '        Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
        '        If Retorno Then
        '            MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Seguimiento Productos")

        '        Else
        '            MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Seguimiento Productos")
        '        End If
        '    Catch ex As Exception
        '        MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
        '        Retorno = False
        '    Finally
        '        Dr.Close()
        '        Dr = Nothing
        '        param = Nothing
        '        comando.Dispose()
        '        comando = Nothing

        '    End Try

        '    Return Retorno

        'End Function
        Public Function MostrarCaracteristicasPorProducto(ByVal IDProducto As Integer) As DataTable 'parecido al anterior BuscarProveedorPorCodigo
            Dim Dt As New DataTable
            Dim oTSQL As New TSQL

            Dim Prm = New SqlParameter("@idproducto", IDProducto)

            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarCaracteristicasPorProducto]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                comando.Parameters.Add(Prm)

                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Busqueda Productos")
                Dt = Nothing
            Finally
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                Prm = Nothing
            End Try
            Return Dt

        End Function

        Public Function RegistrosSeguimientoPorUnidad(ByVal IDUnidad As Integer) As DataTable
            Dim Dt As New DataTable
            Dim oTSQL As New TSQL

            Dim Prm = New SqlParameter("@idunidad", IDUnidad)

            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_RegistrosSegPorUnidad]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                comando.Parameters.Add(Prm)

                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Seguimiento Productos")
                Dt = Nothing
            Finally
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                Prm = Nothing
            End Try
            Return Dt

        End Function
        Public Function MostrarSituacionPorNroInventario(ByVal NroInventario As String) As DataTable 'parecido al anterior BuscarProveedorPorCodigo
            Dim Dt As New DataTable
            Dim oTSQL As New TSQL

            Dim Prm = New SqlParameter("@nroinventario", NroInventario)

            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarSituacionPorNroInventario]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                comando.Parameters.Add(Prm)

                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Busqueda Productos")
                Dt = Nothing
            Finally
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                Prm = Nothing
            End Try
            Return Dt

        End Function

        Public Function RegistrosSeguimientoPorProducto(ByVal IDProducto As Integer) As DataTable
            Dim Dt As New DataTable
            Dim oTSQL As New TSQL

            Dim Prm = New SqlParameter("@idproducto", IDProducto)

            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_RegistrosSegPorProducto]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                comando.Parameters.Add(Prm)

                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Seguimiento Productos")
                Dt = Nothing
            Finally
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                Prm = Nothing
            End Try
            Return Dt

        End Function

        Public Function MostrarProductosPorTipo(ByVal IDTipoProducto As Integer, ByVal IDTrabajador As Integer) As DataTable
            Dim Dt As New DataTable
            Dim Prm As SqlParameter
            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarProductosPorTipo]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@idtipoproducto", IDTipoProducto)
                comando.Parameters.Add(Prm)
                Prm = New SqlParameter("@idtrabajador", IDTrabajador)
                comando.Parameters.Add(Prm)

                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception

                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Seguimiento Productos")
                Dt = Nothing
            Finally
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                Prm = Nothing
            End Try
            Return Dt
        End Function
    End Class
End Namespace

