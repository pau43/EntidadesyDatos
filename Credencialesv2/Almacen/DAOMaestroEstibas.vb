Imports System.Text
Imports System.IO
Imports System.Data.SqlClient
Imports PoolConexiones
Imports GEACEntidades.Almacen
'Imports GEACEntidades.EAlmacen
Imports GEACEntidades


Namespace DAOAlmacen

    Public Class DAOMaestroEstibas
        Private Advertencia As String = String.Empty

#Region "Mantenimiento de Datos"

        Public Function NuevaEstiba(ByVal oEstiba As Equipamiento_Estiba) As Boolean

            Dim Cmd As New SqlCommand
            Dim oPrm As SqlParameter
            Dim Retorno As Boolean = True
            Dim Dr As SqlDataReader = Nothing

            Try

                Cmd.CommandText = "TRC.Almacen.SpAlm_NuevoEquipoEstiba"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                With oEstiba

                    oPrm = New SqlParameter("@Codigo", .CodigoEstiba)
                    Cmd.Parameters.Add(oPrm)

                    oPrm = New SqlParameter("@Descripcion", .Descripcion)
                    Cmd.Parameters.Add(oPrm)

                    If .IDTipoProducto > 0 Then
                        oPrm = New SqlParameter("@IDTipo", .IDTipoProducto)
                    Else
                        oPrm = New SqlParameter("@IDTipo", DBNull.Value)
                    End If
                    Cmd.Parameters.Add(oPrm)

                End With

                Dr = Cmd.ExecuteReader()
                Dr.Read()

                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Nuevo Equipo Estiba")
                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Nuevo Equipo Estiba")
                End If

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                Retorno = False
            Finally
                Dr.Close()
                Dr = Nothing
                oPrm = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno

        End Function

        Public Function ModificarEstiba(ByVal oEstiba As Equipamiento_Estiba) As Boolean

            Dim Cmd As New SqlCommand
            Dim oPrm As SqlParameter
            Dim Retorno As Boolean = True
            Dim Dr As SqlDataReader = Nothing

            Try

                Cmd.CommandText = "TRC.Almacen.SpAlm_ModificarEquipoEstiba"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                With oEstiba

                    oPrm = New SqlParameter("@IDEstiba", .IDEstiba)
                    Cmd.Parameters.Add(oPrm)

                    oPrm = New SqlParameter("@Codigo", .CodigoEstiba)
                    Cmd.Parameters.Add(oPrm)

                    oPrm = New SqlParameter("@Descripcion", .Descripcion)
                    Cmd.Parameters.Add(oPrm)

                    If .IDTipoProducto > 0 Then
                        oPrm = New SqlParameter("@IDTipo", .IDTipoProducto)
                    Else
                        oPrm = New SqlParameter("@IDTipo", DBNull.Value)
                    End If
                    Cmd.Parameters.Add(oPrm)

                End With

                Dr = Cmd.ExecuteReader()
                Dr.Read()

                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Modificar Equipo Estiba")
                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Modificar Equipo Estiba")
                End If

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                Retorno = False
            Finally
                Dr.Close()
                Dr = Nothing
                oPrm = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno

        End Function

        Public Function EliminarEstiba(ByVal IDEstiba As Integer) As Boolean

            Dim Cmd As New SqlCommand
            Dim oPrm As SqlParameter
            Dim Retorno As Boolean = True
            Dim Dr As SqlDataReader = Nothing

            Try

                Cmd.CommandText = "TRC.Almacen.SpAlm_EliminarEquipoEstiba"
                Cmd.Connection = TSQL.ConexionPermanente
                Cmd.CommandType = CommandType.StoredProcedure

                oPrm = New SqlParameter("@IDEstiba", IDEstiba)
                Cmd.Parameters.Add(oPrm)

                Dr = Cmd.ExecuteReader()
                Dr.Read()

                Retorno = TSQL.CodigoRetorno(Dr.GetString(0), Advertencia)
                If Retorno Then
                    MsgBox(Advertencia, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Eliminar Equipo Estiba")
                Else
                    MsgBox(Advertencia, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Eliminar Equipo Estiba")
                End If

            Catch ex As Exception
                MsgBox("Fuente: " & ex.Source & vbCrLf & "Mensaje: " & ex.Message)
                Retorno = False
            Finally
                Dr.Close()
                Dr = Nothing
                oPrm = Nothing
                Cmd.Dispose()
                Cmd = Nothing
            End Try

            Return Retorno

        End Function

#End Region


    End Class

End Namespace