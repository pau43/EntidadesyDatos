Imports System.Data.SqlClient
Imports PoolConexiones
Imports GEACEntidades.Personal
Imports GEACEntidades.Compras
Imports GEACEntidades


Namespace DAORptConsultas

    Public Class DAORptConsultas
        '-- Esta Clase debe ser eliminada 
        '-- Todas las funciones estan en: DAOControlKardexAlmCentral
        Public Advertencia As String = String.Empty
        Private Shared _Instancia As DAORptConsultas = Nothing

        Public Shared ReadOnly Property Instancia() As DAORptConsultas
            Get
                If _Instancia Is Nothing Then
                    _Instancia = New DAORptConsultas
                End If
                Return _Instancia
            End Get
        End Property

        '********************
        '-- buscar en DAOControlKardexAlmCentral: fdu_CTRL_KardexConsumoDetallado_T
        'Public Function ConsumoDetallado(ByVal Anio As Integer, _
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

        '********************
        '-- buscar en DAOControlKardexAlmCentral: fdu_CTRL_EST_MOV_ActualizarData
        'Public Function Actualizar(ByVal Anio As Integer, ByVal CodEmpresa As String) As Boolean
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

    End Class

End Namespace

