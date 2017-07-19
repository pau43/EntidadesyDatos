Imports System.Data.SqlClient
Imports PoolConexiones
Imports GEACEntidades.Almacen
'Imports GEACEntidades.EAlmacen

Namespace DAOAlmacen
    Public Class DAOConsultas
        Private Advertencia As String = String.Empty
        Public Function ConsultaTrabajadoresProductos(ByVal CodCondicion As String, ByVal IDTipoProducto As Integer) As DataTable
            Dim Dt As New DataTable
            Dim Prm As SqlParameter

            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_ConsultaTrabajadoresProductos]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@codcondicion", IIf(CodCondicion = String.Empty, DBNull.Value, CodCondicion))
                comando.Parameters.Add(Prm)
                Prm = New SqlParameter("@idtipoproducto", IIf(IDTipoProducto <= 0, DBNull.Value, IDTipoProducto))
                comando.Parameters.Add(Prm)

                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Reportes Almacén")
                Dt = Nothing
            Finally
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                Prm = Nothing
            End Try
            Return Dt
        End Function

        Public Function ConsultaStockProductos(ByVal CodAlmacen As String, ByVal IDTipoProducto As Integer) As DataTable
            Dim Dt As New DataTable
            Dim Prm As SqlParameter

            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "Almacen.SpAlm_ConsultaStockProductos"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@codalmacen", IIf(CodAlmacen = String.Empty, DBNull.Value, CodAlmacen))
                comando.Parameters.Add(Prm)
                Prm = New SqlParameter("@idtipoproducto", IIf(IDTipoProducto <= 0, DBNull.Value, IDTipoProducto))
                comando.Parameters.Add(Prm)

                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Reportes Almacén")
                Dt = Nothing
            Finally
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                Prm = Nothing
            End Try
            Return Dt
        End Function
        Public Function ConsultaRegistrosSeguimiento() As DataTable
            Dim Dt As New DataTable

            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_ConsultaRegistrosSeguimiento]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Reportes Almacén")
                Dt = Nothing
            Finally
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty

            End Try
            Return Dt
        End Function

        Public Function ConsultaMovimientoKardex(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal CodAlmacen As String) As DataTable
            Dim Dt As New DataTable
            Dim Prm As SqlParameter

            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_ConsultaMovimientoKardex]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@fechainicio", FechaInicio)
                comando.Parameters.Add(Prm)
                Prm = New SqlParameter("@fechafin", FechaFin)
                comando.Parameters.Add(Prm)
                Prm = New SqlParameter("@codalmacen", IIf(CodAlmacen = String.Empty, DBNull.Value, CodAlmacen))
                comando.Parameters.Add(Prm)

                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Consulta Movimiento Kardex")
                Dt = Nothing
            Finally
                Da = Nothing
                comando = Nothing
                StrComando = String.Empty
                Prm = Nothing
            End Try
            Return Dt
        End Function

        Public Function ConsultaEntradasSalidas(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal TipoNota As String) As DataTable
            Dim Dt As New DataTable
            Dim Prm As SqlParameter

            Dim comando As New SqlCommand
            Dim Da As SqlDataAdapter
            Dim StrComando = "[Almacen].[SpAlm_ConsultaEntradasSalidas]"
            Try

                comando.CommandText = StrComando
                comando.Connection = TSQL.ConexionPermanente
                comando.CommandType = CommandType.StoredProcedure

                Prm = New SqlParameter("@fechainicio", FechaInicio)
                comando.Parameters.Add(Prm)
                Prm = New SqlParameter("@fechafin", FechaFin)
                comando.Parameters.Add(Prm)
                Prm = New SqlParameter("@tiponota", IIf(TipoNota = String.Empty, DBNull.Value, TipoNota))
                comando.Parameters.Add(Prm)

                Da = New SqlDataAdapter(comando)
                Da.Fill(Dt)

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message, MsgBoxStyle.Critical, "Consulta Movimiento Kardex")
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


