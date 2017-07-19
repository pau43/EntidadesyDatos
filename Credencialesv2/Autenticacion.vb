Imports System.Text
Imports System.Security.Cryptography
Imports PoolConexiones
Imports HYDRAEntidades

Public Class Autenticacion

    Private Mensaje As String = String.Empty

    Public ReadOnly Property UltimoMensaje() As String
        Get
            Return Mensaje
        End Get
    End Property

    Public Function IniciarSesionConServidor(ByVal user As String, ByVal pass As String) As Boolean

        Dim Sesion As New TSQL
        Dim validado As Boolean

        SesionUsuario.Permisos = Sesion.fdu_SolicitarConexionAlSistema(user, EncriptarClaveSHA(pass), validado)

        If validado Then

            If SesionUsuario.Permisos Is Nothing Then
                Mensaje = "No se ha devuelto ningún acceso para este usuario."
                Return False
            End If
            If SesionUsuario.Permisos.Rows.Count > 0 Then
                'Verifico si es rol administrador
                SesionUsuario.Administrador = Convert.ToBoolean(SesionUsuario.Permisos.Rows(0)("Admin"))
                '''''''''''''''''''''''''
                'If SesionUsuario.Administrador Then
                '    Mensaje = "Bienvenido " & vbCrLf & SesionUsuario.NombreUsuario
                '    Return True
                'End If
                '''''''''''''''''''''''''' esto al final comenatrlo solo se coloco par efctso de ejecutar GEAC
                If IsDBNull(SesionUsuario.Permisos.Rows(0)("Permisos")) Then
                    Mensaje = "No se ha devuelto ningún acceso para este usuario."
                    Return False
                End If
            Else
                Mensaje = "No se ha devuelto ningún acceso para este usuario."
                Return False
            End If
            Mensaje = "Bienvenido " & vbCrLf & SesionUsuario.NombreUsuario
        Else
            Mensaje = TSQL.UltimoMensaje
            Return False
        End If

        Return True

    End Function

    '//---> Cambiar la clave del usuario
    Public Function CambiarClaveDeUsuario(ByVal user As String, ByVal antigua As String, ByVal nueva As String) As Boolean

        Dim Sesion As New TSQL
        Dim valor As Boolean

        valor = Sesion.fdu_SolicitarCambioDeClave(user, EncriptarClaveSHA(antigua), EncriptarClaveSHA(nueva))
        Mensaje = TSQL.UltimoMensaje
        Return valor
    End Function

    '//---> Encriptar clave ingresada del usuario
    Private Function EncriptarClaveSHA(ByVal palabra As String) As String

        If palabra.Length = 0 Then
            Return palabra 'sin clave
        End If
        '
        'Función de encriptación utilizando SHA1
        Dim i As Integer
        Dim enc As New UTF8Encoding()
        Dim data() As Byte = enc.GetBytes(palabra)
        Dim result() As Byte
        Dim sha As New SHA1CryptoServiceProvider()
        '
        result = sha.ComputeHash(data)
        Dim sb As New StringBuilder()
        '
        For i = 0 To result.Length - 1
            If result(i) < 16 Then
                sb.Append("0")
            End If
            sb.Append(result(i).ToString("x"))
        Next
        Return sb.ToString.ToUpper

    End Function

End Class

