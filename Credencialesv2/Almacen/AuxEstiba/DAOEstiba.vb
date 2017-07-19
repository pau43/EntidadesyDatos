Imports System.Data.SqlClient
Imports PoolConexiones
Imports GEACEntidades.Almacen

Namespace DAOAlmacen

    Public NotInheritable Class DAOEstiba

        Private Sub New()
        End Sub

        Private Shared _InstanciaEstiba As DAOEstiba = Nothing
        Public Advertencia As String = String.Empty

        'Instancia unica de la clase
        Public Shared ReadOnly Property Instancia() As DAOEstiba
            Get
                If _InstanciaEstiba Is Nothing Then
                    _InstanciaEstiba = New DAOEstiba
                End If
                Return _InstanciaEstiba
            End Get
        End Property

#Region "Estiba"

        Public Function fdu_NuevaEstiba(ByVal Codigo As String, ByVal Descripcion As String, ByVal IdUniMedida As Integer, ByVal Costo As Decimal) As Boolean
            Dim Retorno As Boolean = True
            Dim Cmd As New SqlCommand
            Dim Dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_NuevaEstiba]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                If Codigo.Length > 0 Then
                    Cmd.Parameters.AddWithValue("@Codigo", Codigo)
                End If

                Cmd.Parameters.AddWithValue("@Descripcion", Descripcion)
                Cmd.Parameters.AddWithValue("@IdUniMed", IdUniMedida)
                Cmd.Parameters.AddWithValue("@CostoUni", Costo)

                Dr = Cmd.ExecuteReader()
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

        Public Function fdu_ModificarEstiba(ByVal idEquipo As Integer, ByVal Codigo As String, ByVal Descripcion As String, ByVal IDUniMedida As Integer, ByVal Costo As Decimal) As Boolean
            Dim Retorno As Boolean = True
            Dim Cmd As New SqlCommand
            Dim Dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_ModificarEstiba]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@IDEquipo", idEquipo)
                If Codigo.Length > 0 Then
                    Cmd.Parameters.AddWithValue("@Codigo", Codigo)
                End If
                Cmd.Parameters.AddWithValue("@Descripcion", Descripcion)
                Cmd.Parameters.AddWithValue("@IdUniMed", IDUniMedida)
                Cmd.Parameters.AddWithValue("@CostoUni", Costo)

                Dr = Cmd.ExecuteReader()
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

        Public Function fdu_EliminarEstiba(ByVal IDEquipo As Integer) As Boolean
            Dim Retorno As Boolean = True
            Dim Cmd As New SqlCommand
            Dim Dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_EliminarEstiba]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@IDEquipo", IDEquipo)
                Dr = Cmd.ExecuteReader()
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

        Public Function fdu_MaestroEstiba(ByVal Descripcion As String) As DataTable
            Dim Dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_MaestroEstiba]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                If Descripcion.Length > 0 Then
                    Cmd.Parameters.AddWithValue("@Descripcion", Descripcion)
                End If

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
#End Region

#Region "Estiba Inventario"

        Public Function fdu_StkInventarioEstiba(ByVal codAlmacen As String, Optional ByVal Descripcion As String = "") As DataTable
            Dim Dt As New DataTable
            Dim Cmd As New SqlCommand
            Dim Da As SqlDataAdapter

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_StkInventarioEstiba]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                Cmd.Parameters.AddWithValue("@CodAlmacen", codAlmacen)
                Cmd.Parameters.AddWithValue("@Q", Descripcion)

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

        Public Function fdu_StkInventarioActualiza(ByVal codAlmacen As String, ByVal idEquipo As Integer, Optional ByVal stockMin As Integer = 0, Optional ByVal stockMax As Integer = 0) As Boolean
            Dim Retorno As Boolean = True
            Dim Cmd As New SqlCommand
            Dim Dr As SqlDataReader = Nothing

            Try
                Cmd.CommandText = "[Almacen].[SpAlm_EST_StkActualizaInvEstiba]"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure


                Cmd.Parameters.AddWithValue("@CodAlmacen", codAlmacen)
                Cmd.Parameters.AddWithValue("@IDEquipo", idEquipo)
                Cmd.Parameters.AddWithValue("@StockMin", stockMin)
                Cmd.Parameters.AddWithValue("@StockMax", stockMax)

                Dr = Cmd.ExecuteReader()
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

    End Class

End Namespace

