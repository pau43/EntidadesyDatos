Imports PoolConexiones
Imports System.Data.SqlClient
Imports GEACEntidades.Almacen
Imports GEACEntidades


Namespace DAOAlmacen

    Public Class DAOControlSolicitudEquipos
        Public Advertencia As String = String.Empty

        Public Function MostrarSolicitudesAlmAuxiliar() As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter

            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarSolicitudesAlmAuxiliar]"
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


        Public Function MostrarSolicitudesAlmAuxiliar(ByVal IDSucursal As Integer, ByVal CodAlmacen As String) As DataTable  'sobrecarga, filtrando con almacen que dio origen,PRIMERO PROBAR ESTE, LUEGO ELIMINAR EL OTRO
            Dim tabla As New DataTable

            'tabla.Columns.Add("IDLocalSol", Type.GetType("System.Int32"))
            'tabla.Columns.Add("AnioSol", Type.GetType("System.Int32"))
            'tabla.Columns.Add("NroSolicitud", Type.GetType("System.Int32"))
            'tabla.Columns.Add("NroAutorizacion", Type.GetType("System.String"))
            'tabla.Columns.Add("FechaSolicitud", Type.GetType("System.DateTime"))
            'tabla.Columns.Add("FechaEntrega", Type.GetType("System.DateTime"))
            'tabla.Columns.Add("Solicitante", Type.GetType("System.String"))
            'tabla.Columns.Add("IDArea", Type.GetType("System.Int32"))
            'tabla.Columns.Add("Area", Type.GetType("System.String"))
            'tabla.Columns.Add("CodLugar", Type.GetType("System.String"))
            'tabla.Columns.Add("IDDestino", Type.GetType("System.Int32"))
            'tabla.Columns.Add("Destino", Type.GetType("System.String"))
            'tabla.Columns.Add("IDPersona", Type.GetType("System.Int32"))
            'tabla.Columns.Add("Trabajador", Type.GetType("System.String"))
            'tabla.Columns.Add("DocIdentidad", Type.GetType("System.String"))
            'tabla.Columns.Add("IDRemolcador", Type.GetType("System.Int32"))
            'tabla.Columns.Add("Unidad", Type.GetType("System.String"))
            'tabla.Columns.Add("IDSemiRemolque", Type.GetType("System.Int32"))
            'tabla.Columns.Add("Plataforma", Type.GetType("System.String"))
            'tabla.Columns.Add("Carga", Type.GetType("System.String"))
            'tabla.Columns.Add("Observacion", Type.GetType("System.String"))
            'tabla.Columns.Add("CodAlmEntrega", Type.GetType("System.String"))
            'tabla.Columns.Add("NivelAmacenEntrega", Type.GetType("System.Int32"))
            'tabla.Columns.Add("Almacen", Type.GetType("System.String"))
            'tabla.Columns.Add("Estado", Type.GetType("System.String"))
            'tabla.Columns.Add("Solicitudes", Type.GetType("System.String"))
            'tabla.Columns.Add("XMLProductos", Type.GetType("System.String"))



            Dim comando As New SqlCommand
            ' Dim param As SqlParameter

            ' Dim dr As SqlDataReader = Nothing



            Dim Da As SqlDataAdapter


            Dim StrComando = "[Almacen].[SpAlm_MostrarSolicitudesAlmAuxiliarV2]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure


                comando.Parameters.AddWithValue("idsucursal", IDSucursal)
                comando.Parameters.AddWithValue("codalmacen", IIf(CodAlmacen.Trim.Length = 0, DBNull.Value, CodAlmacen))



                '  dr = comando.ExecuteReader(CommandBehavior.CloseConnection)

                'While dr.Read
                '    Dim Fil As DataRow
                '    Fil = tabla.NewRow

                '    Fil.Item("IDLocalSol") = dr.GetValue(0)
                '    Fil.Item("AnioSol") = dr.GetValue(1)
                '    Fil.Item("NroSolicitud") = dr.GetValue(2)
                '    '  Fil.Item("IDLocalSol") = dr.GetValue(3)
                '    Fil.Item("NroAutorizacion") = dr.GetValue(3)
                '    Fil.Item("FechaSolicitud") = dr.GetValue(4)
                '    Fil.Item("FechaEntrega") = dr.GetValue(5)
                '    Fil.Item("Solicitante") = dr.GetValue(6)
                '    Fil.Item("IDArea") = dr.GetValue(7)
                '    Fil.Item("Area") = dr.GetValue(8)
                '    Fil.Item("CodLugar") = dr.GetValue(9)
                '    Fil.Item("IDDestino") = dr.GetValue(10)
                '    Fil.Item("Destino") = dr.GetValue(11)
                '    Fil.Item("IDPersona") = dr.GetValue(12)
                '    Fil.Item("Trabajador") = dr.GetValue(13)
                '    Fil.Item("DocIdentidad") = dr.GetValue(14)
                '    Fil.Item("IDRemolcador") = dr.GetValue(15)
                '    Fil.Item("Unidad") = dr.GetValue(16)
                '    Fil.Item("IDSemiRemolque") = dr.GetValue(17)
                '    Fil.Item("Plataforma") = dr.GetValue(18)
                '    Fil.Item("Carga") = dr.GetValue(19)
                '    Fil.Item("Observacion") = dr.GetValue(20)
                '    Fil.Item("CodAlmEntrega") = dr.GetValue(21)
                '    Fil.Item("NivelAmacenEntrega") = dr.GetValue(22)
                '    Fil.Item("Almacen") = dr.GetValue(23)
                '    Fil.Item("Estado") = dr.GetValue(24)
                '    Fil.Item("Solicitudes") = dr.GetValue(25)
                '    Fil.Item("XMLProductos") = dr.GetValue(26)


                '    tabla.Rows.Add(Fil)

                'End While


                'param = New SqlParameter("@idsucursal", IDSucursal) ' el idsucursal para las notas de solicitud
                'comando.Parameters.Add(param)

                'param = New SqlParameter("@codalmacen", IIf(CodAlmacen.Trim.Length = 0, DBNull.Value, CodAlmacen)) ' el idsucursal para las notas de solicitud
                'comando.Parameters.Add(param)


                Da = New SqlDataAdapter(comando)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Equipamiento Estibas")
                tabla = Nothing
            Finally
                'If Not IsNothing(dr) Then
                '    dr.Close()
                'End If
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                ' dr = Nothing

            End Try

            Return tabla
        End Function

        Public Function MostrarEquiposAlmAuxiliarXSucursal(ByVal IDSucursal As Integer) As DataTable

            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarEquiposAlmAuxiliarXSucursal]"
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


        Public Function MostrarEquiposAlmAuxiliarXAlmacen(ByVal CodAlmacen As String) As DataTable

            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarEquiposAlmAuxiliarXAlmacen]"
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


        Public Function MostrarStockEquiposAlmAuxiliarXAlmacen(ByVal CodAlmacen As String) As DataTable

            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_AUX_VerStockEqAuxiliaresPorAlmacen]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@CodAlmacen", CodAlmacen)
                comando.Parameters.Add(param)

                Da = New SqlDataAdapter(comando)
                Da.Fill(tabla)

            Catch ex As Exception
                Advertencia = "Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message
                tabla = Nothing
            Finally

                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                param = Nothing

            End Try
            Return tabla
        End Function


        Public Function LlenarFormSolicitudAlmAuxiliar(ByVal IDLocal As Integer, ByVal CodEmpresa As String) As DataTable ' cambiado a por almacen
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter

            Dim StrComando = "[Almacen].[SpAlm_LlenarFormSolicitudAlmAuxiliar]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@IdLocal", IIf(IDLocal <= 0, DBNull.Value, IDLocal))
                comando.Parameters.Add(param)
                param = New SqlParameter("@CodEmpresa", IIf(CodEmpresa.Trim.Length = 0, DBNull.Value, CodEmpresa))
                comando.Parameters.Add(param)


                Da = New SqlDataAdapter(comando)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Equipos Auxiliares")
                tabla = Nothing
            Finally

                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                param = Nothing
            End Try

            Return tabla
        End Function

        Public Function MostrarEquiposAuxiliaresXAlmacen(ByVal CodAlmacen As String) As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter

            Dim StrComando = "[Almacen].[SpAlm_MostrarEquiposAuxiliaresXAlmacen]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@codalmacen", IIf(CodAlmacen.Trim.Length = 0, DBNull.Value, CodAlmacen))
                comando.Parameters.Add(param)

                Da = New SqlDataAdapter(comando)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Equipos Auxiliares")
                tabla = Nothing
            Finally

                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                param = Nothing
            End Try

            Return tabla
        End Function

        Public Function MostrarProductosXEquipo(ByVal CodAlmacen As String, ByVal IDEquipo As Integer) As DataTable 'Filtra por equipo y almacen

            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarProductosXEquipo]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@codalmacen", CodAlmacen)
                comando.Parameters.Add(param)


                param = New SqlParameter("@idequipo", IDEquipo)
                comando.Parameters.Add(param)


                Da = New SqlDataAdapter(comando)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Solicitud Almacen Auxiliar")
                tabla = Nothing
            Finally

                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                param = Nothing

            End Try
            Return tabla
        End Function


        Public Function MostrarKardexAlmAuxiliarXSolicitud(ByVal OSolicitud As Solicitudes_AlmAuxiliar) As DataTable 'Filtra por equipo y almacen

            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarKardexAlmAuxiliarXSolicitud]"
            Try


                With OSolicitud


                    comando.CommandText = StrComando
                    comando.Connection = TSQL.ConexionPermanente
                    comando.CommandType = CommandType.StoredProcedure

                    param = New SqlParameter("@idlocalsol", .IDLocalSolicitud)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@aniosol", .AnioSolicitud)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@nrosolicitud", .NroSolicitud)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@codalmentrega", .CodAlmEntrega)
                    comando.Parameters.Add(param)


                End With


                Da = New SqlDataAdapter(comando)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Solicitud Almacen Auxiliar")
                tabla = Nothing
            Finally

                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                param = Nothing

            End Try
            Return tabla
        End Function

        Public Function VerValesPendientesAlmAuxiliar(ByVal CodAlmacen As String) As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter

            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_VerValesPendientesAlmAuxiliar]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@CodAlmacen", CodAlmacen)
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

        Public Function MostrarKardexValeAlmAuxiliar(ByVal ONotaSalida As Notas_AlmAuxiliar) As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter

            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarKardexValeAlmAuxiliar]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                With ONotaSalida

                    param = New SqlParameter("@codalmacen", .CodAlmNota)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@anio", .AnioNota)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@codmovi", .CodMoviNota)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@nromovimientoaux", .NroMovimientoAux)
                    comando.Parameters.Add(param)


                End With




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

        Public Function MostrarEquiposRecepcionados(ByVal FechaInicio As Date, ByVal FechaFin As Date, Optional ByVal CodAlmacen As String = "") As DataTable  'muestra vales generados, devoluciones, transferencias
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter

            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarEquiposRecepcionados]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@fechaini", FechaInicio)
                comando.Parameters.Add(param)

                param = New SqlParameter("@fechafin", FechaFin)
                comando.Parameters.Add(param)

                param = New SqlParameter("@codalmacen", IIf(CodAlmacen.Trim.Length = 0, DBNull.Value, CodAlmacen))
                comando.Parameters.Add(param)

                Da = New SqlDataAdapter(comando)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Equipos Auxiliares")
                tabla = Nothing
            Finally

                Da = Nothing
                comando = Nothing
                StrComando = String.Empty

            End Try

            Return tabla
        End Function

        Public Function MostrarCodProductosMapeados(ByVal CodProducto As String) As DataTable

            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarCodProductosMapeados]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@codproducto", IIf(CodProducto.Trim.Length = 0, DBNull.Value, CodProducto))
                comando.Parameters.Add(param)


                Da = New SqlDataAdapter(comando)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Equipos Auxiliares")
                tabla = Nothing
            Finally

                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                param = Nothing

            End Try
            Return tabla
        End Function

        Public Function LlenarFormVistaSolicitudEstiba(ByVal CodAlmacen As String, ByVal CodEmpresa As String, ByVal IDSucursal As Integer) As DataTable

            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            'Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_LlenarFormVistaSolicitudEstiba]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure


                comando.Parameters.AddWithValue("@codalmacen", IIf(CodAlmacen.Trim.Length = 0, DBNull.Value, CodAlmacen))
                comando.Parameters.AddWithValue("@codempresa", IIf(CodEmpresa.Trim.Length = 0, DBNull.Value, CodEmpresa))
                comando.Parameters.AddWithValue("@idsucursal", IIf(IDSucursal <= 0, DBNull.Value, IDSucursal))

                'param = New SqlParameter("@codalmacen", CodAlmacen)
                'comando.Parameters.Add(param)

                'param = New SqlParameter("@codalmacen", CodAlmacen)
                'comando.Parameters.Add(param)

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

        'trae las sucursales de la empresa logueada(trc en este caso)y sus almacenes respectivos
        Public Function CodigosSucursales_AlmSec() As DataTable

            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "Almacen.SpAlm_CodigosSucursales_AlmSec"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandTimeout = 300
                param = New SqlParameter("@CodEmpresa", SesionUsuario.CodEmpresa)
                comando.Parameters.Add(param)


                Da = New SqlDataAdapter(comando)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Equipos Auxiliares")
                tabla = Nothing
            Finally

                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                param = Nothing

            End Try
            Return tabla
        End Function


        Public Function MostrarSolicitudes_StkEquipos(ByVal CodAlmacen As String) As DataTable

            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            ' Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_MostrarSolicitudes_StkEquipos]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure
                comando.CommandTimeout = 300
                comando.Parameters.AddWithValue("@idsucursal", SesionUsuario.IDSucursal) 'se necesita la sucursal logueada
                comando.Parameters.AddWithValue("@codalmacen", IIf(CodAlmacen.Trim.Length = 0, DBNull.Value, CodAlmacen))

                'param = New SqlParameter("@CodEmpresa", SesionUsuario.CodEmpresa)
                'comando.Parameters.Add(param)

                Da = New SqlDataAdapter(comando)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Equipos Auxiliares")
                tabla = Nothing
            Finally

                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                'param = Nothing

            End Try
            Return tabla
        End Function


#Region "Reportes"

        Public Function ConsultaKardexAlmAuxiliar(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal CodAlmacen As String, ByVal CodProducto As String) As DataTable

            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_ConsultaKardexAlmAuxiliar]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@fechainicio", FechaInicio)
                comando.Parameters.Add(param)

                param = New SqlParameter("@fechafin", FechaFin)
                comando.Parameters.Add(param)

                param = New SqlParameter("@codalmacen", IIf(CodAlmacen.Trim.Length = 0, DBNull.Value, CodAlmacen))
                comando.Parameters.Add(param)

                param = New SqlParameter("@codproducto", IIf(CodProducto.Trim.Length = 0, DBNull.Value, CodProducto))
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

        Public Function ConsultaKardexEquiposAlmAuxiliar(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal CodAlmacen As String, ByVal IDEquipo As Integer, _
                                                         ByVal Placa As String, ByVal IdPersona As Integer) As DataTable

            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_ConsultaKardexEquiposAlmAuxiliar]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@fechainicio", Format(FechaInicio, "dd/MM/yyyy"))
                comando.Parameters.Add(param)

                param = New SqlParameter("@fechafin", Format(FechaFin, "dd/MM/yyyy"))
                comando.Parameters.Add(param)

                param = New SqlParameter("@codalmacen", IIf(CodAlmacen.Trim.Length = 0, DBNull.Value, CodAlmacen))
                comando.Parameters.Add(param)

                param = New SqlParameter("@idequipo", IIf(IDEquipo <= 0, DBNull.Value, IDEquipo))
                comando.Parameters.Add(param)

                param = New SqlParameter("@Placa", IIf(Placa.Trim.Length = 0, DBNull.Value, Placa))
                comando.Parameters.Add(param)

                param = New SqlParameter("@IdPersona", IIf(IdPersona <= 0, DBNull.Value, IdPersona))
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

        Public Function ResumenStockEquipos(ByVal Nivel As Integer, ByVal IDEquipo As Integer) As DataTable

            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_ResumenStockEquipos]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@nivel", Nivel)
                comando.Parameters.Add(param)

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

        Public Function MostrarEquiposSinDevolucionXEquipo(ByVal IDEquipo As Integer, ByVal CodAlmacen As String) As DataTable

            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "Almacen.SpAlm_MostrarEquiposSinDevolucionXEquipo"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                'param = New SqlParameter("@nivel", Nivel)
                'comando.Parameters.Add(param)
                If IDEquipo > 0 Then
                    param = New SqlParameter("@idequipo", IDEquipo)
                    comando.Parameters.Add(param)
                End If

                param = New SqlParameter("@codalmacen", CodAlmacen)
                comando.Parameters.Add(param)



                Da = New SqlDataAdapter(comando)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Equipos Auxiliares")
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


#Region "Mantenimiento de datos"

        Public Function NuevaSolicitudAlmAuxiliar(ByVal NSolicitudEquipo As Solicitudes_AlmAuxiliar, ByVal Nivel As Integer) As Boolean 'utilizado tanto para solicitar como para devolver
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                If Nivel = NivelAlmacen.Estibas Then
                    comando.CommandText = "[Almacen].[SpAlm_NuevaSolicitudAlmEstiba]"
                ElseIf Nivel = NivelAlmacen.Herramientas Then
                    comando.CommandText = "[Almacen].[SpAlm_NuevaSolicitudAlmHerramientas]"
                End If

                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                With NSolicitudEquipo

                    param = New SqlParameter("@IdLocal", .IDLocalSolicitud)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@FSolicitud", IIf(.FechaSolicitud = #12:00:00 AM#, DBNull.Value, .FechaSolicitud))
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@Solicitante", .Solicitante)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@IdArea", .IDArea)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@CodAlmacen", .CodAlmEntrega)
                    comando.Parameters.Add(param)


                    If Nivel = NivelAlmacen.Estibas Then


                        param = New SqlParameter("@IdRemolcador", .IDRemolcador)
                        comando.Parameters.Add(param)
                        param = New SqlParameter("@IdSemiRemolque", IIf(.IDSemiRemolque <= 0, DBNull.Value, .IDSemiRemolque))
                        comando.Parameters.Add(param)
                        param = New SqlParameter("@Carga", IIf(.Carga.Trim.Length = 0, DBNull.Value, .Carga))
                        comando.Parameters.Add(param)
                        param = New SqlParameter("@IdDestino", .IDDestino)
                        comando.Parameters.Add(param)

                    End If





                    param = New SqlParameter("@IdPersona", IIf(.IDPersona <= 0, DBNull.Value, .IDPersona))
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@Observacion", IIf(.Observacion.Trim.Length = 0, DBNull.Value, .Observacion))
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@xEqSolicitados", IIf(.XMLSolicitudEquipo.Trim.Length = 0, DBNull.Value, .XMLSolicitudEquipo))
                    comando.Parameters.Add(param)


                End With

                If comando.Connection.State = ConnectionState.Closed Then
                    comando.Connection.Open()
                End If

                Dr = comando.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()

                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Solicitud Equipos Auxiliares")

                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Solicitud Equipos Auxiliares")
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

        Public Function ModificarSolicitudAlmAuxiliar(ByVal NSolicitudEquipo As Solicitudes_AlmAuxiliar, ByVal Nivel As Integer) As Boolean 'utilizado tanto para solicitar como para devolver

            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try

                If Nivel = NivelAlmacen.Estibas Then
                    comando.CommandText = "[Almacen].[SpAlm_ModificarSolicitudAlmEstiba]"
                ElseIf Nivel = NivelAlmacen.Herramientas Then
                    comando.CommandText = "[Almacen].[SpAlm_ModificarSolicitudAlmHerramientas]"
                End If

                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                With NSolicitudEquipo


                    param = New SqlParameter("@IdLocal", .IDLocalSolicitud)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@Anio", .AnioSolicitud)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@Numero", .NroSolicitud)
                    comando.Parameters.Add(param)

                    'param = New SqlParameter("@FSolicitud", IIf(.FechaSolicitud = #12:00:00 AM#, DBNull.Value, .FechaSolicitud))
                    'comando.Parameters.Add(param)
                    param = New SqlParameter("@Solicitante", .Solicitante)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@IdArea", .IDArea)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@CodAlmacen", .CodAlmEntrega)
                    comando.Parameters.Add(param)


                    If Nivel = NivelAlmacen.Estibas Then

                        param = New SqlParameter("@IdRemolcador", .IDRemolcador)
                        comando.Parameters.Add(param)
                        param = New SqlParameter("@IdSemiRemolque", IIf(.IDSemiRemolque <= 0, DBNull.Value, .IDSemiRemolque))
                        comando.Parameters.Add(param)
                        param = New SqlParameter("@Carga", IIf(.Carga.Trim.Length = 0, DBNull.Value, .Carga))
                        comando.Parameters.Add(param)
                        param = New SqlParameter("@IdDestino", .IDDestino)
                        comando.Parameters.Add(param)

                    End If


                    param = New SqlParameter("@IdPersona", IIf(.IDPersona <= 0, DBNull.Value, .IDPersona))
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@Observacion", IIf(.Observacion.Trim.Length = 0, DBNull.Value, .Observacion))
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@xEqSolicitados", IIf(.XMLSolicitudEquipo.Trim.Length = 0, DBNull.Value, .XMLSolicitudEquipo))
                    comando.Parameters.Add(param)


                End With

                If comando.Connection.State = ConnectionState.Closed Then
                    comando.Connection.Open()
                End If

                Dr = comando.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()

                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Solicitud Equipos Auxiliares")

                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Solicitud Equipos Auxiliares")
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

        Public Function AnularSolicitudEquipos(ByVal NSolicitudEquipo As Solicitudes_AlmAuxiliar) As Boolean 'solo se pueden anular las notas con estado de solicitud entregado
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try

                With NSolicitudEquipo


                    comando.CommandText = "[Almacen].[SpAlm_AnularSolicitudAlmAuxiliar]"
                    comando.Connection = TSQL.ConexionPermanente
                    comando.CommandType = CommandType.StoredProcedure

                    param = New SqlParameter("@IdLocal", .IDLocalSolicitud)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@Anio", .AnioSolicitud)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@Numero", .NroSolicitud)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@Motivo", .MotivoAnulacion)
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


                End With


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



        Public Function DarEntregadoSolicitudAlmAuxiliar(ByVal ONotasAlmAuxiliar As Notas_AlmAuxiliar) As Boolean 'utilizado tanto para solicitar como para devolver
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_EntregarSolicitudAlmAuxiliar]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                With ONotasAlmAuxiliar


                    param = New SqlParameter("@IdLocal", .IDLocalSol)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@Anio", .AnioSol)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@Numero", .NroSolicitud)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@Observacion", .Observacion)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@FDespacho", IIf(.FechaNota = #12:00:00 AM#, DBNull.Value, .FechaNota))
                    comando.Parameters.Add(param)


                    param = New SqlParameter("@xCodEquipos", IIf(.XMLKardexAlmAuxiliar.Trim.Length = 0, DBNull.Value, .XMLKardexAlmAuxiliar))
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@xSerieEquipos", IIf(.XMLKardexAlmAuxiliarPcod.Trim.Length = 0, DBNull.Value, .XMLKardexAlmAuxiliarPcod))
                    comando.Parameters.Add(param)


                End With

                If comando.Connection.State = ConnectionState.Closed Then
                    comando.Connection.Open()
                End If

                Dr = comando.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()

                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Entrega Equipos Auxiliares")

                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Entrega Equipos Auxiliares")
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


        Public Function AnularEntregaSolicitudEquipos(ByVal NSolicitudEquipo As Solicitudes_AlmAuxiliar) As Boolean 'solo se pueden anular las notas con estado de solicitud entregado
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try

                With NSolicitudEquipo


                    comando.CommandText = "[Almacen].[SpAlm_AnularEntregaSolicitudAlmAuxiliar]"
                    comando.Connection = TSQL.ConexionPermanente
                    comando.CommandType = CommandType.StoredProcedure

                    param = New SqlParameter("@IdLocal", .IDLocalSolicitud)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@Anio", .AnioSolicitud)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@Numero", .NroSolicitud)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@Motivo", .MotivoAnulacion)
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


                End With


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

        Public Function DevolverSolicitudAlmAuxiliar(ByVal ONotasAlmAuxiliar As Notas_AlmAuxiliar) As Boolean
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_DevolverSolicitudAlmAuxiliar]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                With ONotasAlmAuxiliar


                    param = New SqlParameter("@IdLocal", .IDLocalSol)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@Anio", .AnioSol)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@Numero", .NroSolicitud)
                    comando.Parameters.Add(param)


                    param = New SqlParameter("@Observacion", IIf(.Observacion.Trim.Length = 0, DBNull.Value, .Observacion))
                    comando.Parameters.Add(param)


                    param = New SqlParameter("@FDevuelve", IIf(.FechaNota = #12:00:00 AM#, DBNull.Value, .FechaNota))
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@CodAlmRecibe", .CodAlmNotaAux)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@xCodEquipos", IIf(.XMLKardexAlmAuxiliar.Trim.Length = 0, DBNull.Value, .XMLKardexAlmAuxiliar))
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@xSerieEquipos", IIf(.XMLKardexAlmAuxiliarPcod.Trim.Length = 0, DBNull.Value, .XMLKardexAlmAuxiliarPcod))
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@Monto", IIf(.MontoVale < 0, DBNull.Value, .MontoVale))
                    comando.Parameters.Add(param)


                End With

                If comando.Connection.State = ConnectionState.Closed Then
                    comando.Connection.Open()
                End If

                Dr = comando.ExecuteReader(CommandBehavior.CloseConnection)
                Dr.Read()

                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Devolución Equipos Auxiliares")

                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Devolución Equipos Auxiliares")
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

        Public Function LiquidarValeAlmAuxiliar(ByVal ONotasAlmAuxiliar As Notas_AlmAuxiliar) As Boolean
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_LiquidarValeAlmAuxiliar]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                With ONotasAlmAuxiliar

                    param = New SqlParameter("@CodAlmNota", .CodAlmNota)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@CodMovi", .CodMoviNota)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@Anio", .AnioNota)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@NroMovi", .NroMovimientoNota)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@FRecepcion", IIf(.FechaNota = #12:00:00 AM#, DBNull.Value, .FechaNota))
                    comando.Parameters.Add(param)



                    param = New SqlParameter("@CodAlmRecepciona", .CodAlmacenRecepcionaVale)
                    comando.Parameters.Add(param)



                    param = New SqlParameter("@Cobrado", .Cobrado)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@Observacion", IIf(.Observacion.Trim.Length = 0, DBNull.Value, .Observacion))
                    comando.Parameters.Add(param)

                    ' If .Cobrado Then

                    param = New SqlParameter("@CodAlmTxCentral", IIf(.CodAlmNotaAux.Trim.Length = 0, DBNull.Value, .CodAlmNotaAux)) 'almacen central donde se transfiere para la baja
                    comando.Parameters.Add(param)

                    'End If

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
                    Dr.Close()
                End If

                Dr = Nothing
                param = Nothing
                comando.Dispose()
                comando = Nothing

            End Try

            Return Retorno

        End Function
        Public Function ModificarMontoValeAlmAuxiliar(ByVal ONotasAlmAuxiliar As Notas_AlmAuxiliar) As Boolean
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_ModificarMontoValeAlmAuxiliar]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                With ONotasAlmAuxiliar

                    param = New SqlParameter("@CodAlmVale", .CodAlmNota)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@CodMovi", .CodMoviNota)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@Anio", .AnioNota)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@NroMovi", .NroMovimientoNota)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@Monto", .MontoVale)
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
                    Dr.Close()
                End If

                Dr = Nothing
                param = Nothing
                comando.Dispose()
                comando = Nothing

            End Try

            Return Retorno

        End Function

        Public Function AnularLiquidacionValeAlmAuxiliar(ByVal ONotasAlmAuxiliar As Notas_AlmAuxiliar) As Boolean
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try
                comando.CommandText = "[Almacen].[SpAlm_AnularLiquidacionValeAlmAuxiliar]"
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                With ONotasAlmAuxiliar

                    param = New SqlParameter("@CodAlmVale", .CodAlmNotaAux)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@CodMovi", .CodMoviAux)
                    comando.Parameters.Add(param)
                    param = New SqlParameter("@Anio", .AnioNota)
                    comando.Parameters.Add(param)


                    param = New SqlParameter("@NroMovi", .NroMovimientoAux)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@Motivo", .MotivoAnulacion)
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
                    Dr.Close()
                End If

                Dr = Nothing
                param = Nothing
                comando.Dispose()
                comando = Nothing

            End Try

            Return Retorno

        End Function

        Public Function AnularDevolucionSolicitudAlmAuxiliar(ByVal NSolicitudEquipo As Solicitudes_AlmAuxiliar) As Boolean 'solo se pueden anular las notas con estado de solicitud entregado
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Retorno As Boolean
            Dim Dr As SqlDataReader = Nothing

            Try

                With NSolicitudEquipo

                    comando.CommandText = "[Almacen].[SpAlm_AnularDevolucionSolicitudAlmAuxiliar]"
                    comando.Connection = TSQL.ConexionPermanente
                    comando.CommandType = CommandType.StoredProcedure

                    param = New SqlParameter("@IdLocal", .IDLocalSolicitud)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@Anio", .AnioSolicitud)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@Numero", .NroSolicitud)
                    comando.Parameters.Add(param)

                    param = New SqlParameter("@Motivo", .MotivoAnulacion)
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

                End With

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

#Region "Para Impresion"
        Public Function DetallesDeImpresionAlmAux(ByVal IDLocal As Integer, ByVal AnioSol As Integer, ByVal NroSolicitud As Integer) As DataTable
            Dim tabla As New DataTable
            Dim comando As New SqlCommand
            Dim param As SqlParameter
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_DetallesDeImpresionAlmAux]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@idlocal", IDLocal)
                comando.Parameters.Add(param)


                param = New SqlParameter("@aniosol", AnioSol)
                comando.Parameters.Add(param)


                param = New SqlParameter("@nrosolicitud", NroSolicitud)
                comando.Parameters.Add(param)

                Da = New SqlDataAdapter(comando)
                Da.Fill(tabla)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Equipos Auxiliares")
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


