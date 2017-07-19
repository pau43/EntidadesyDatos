Imports System.Windows.Forms
Imports GEACEntidades
Imports System.Management
Imports System.Drawing
Imports HYDRAEntidades

Public Class frmLogin

    Private Login As New Autenticacion

    ' El objeto principal personalizado se puede adjuntar al objeto principal del subproceso actual como se indica a continuación: 
    ' My.User.CurrentPrincipal = CustomPrincipal
    ' donde CustomPrincipal es la implementación de IPrincipal utilizada para realizar la autenticación. 
    ' Posteriormente, My.User devolverá la información de identidad encapsulada en el objeto CustomPrincipal
    ' como el nombre de usuario, nombre para mostrar, etc.

    Public Sub New(ByVal IdSistema As Integer)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        'Incializar la sesión del usuario y otros datos públicos del sistema
        'Primera invocación de inicio de sesión del usuario

        SesionUsuario.IDSistema = IdSistema 'identificador del sistema que se quiere acceder desde la aplicacion cliente
        SesionUsuario.Usuario = String.Empty
        SesionUsuario.NombreUsuario = String.Empty
        SesionUsuario.IDPersona = -1
        SesionUsuario.IDSucursal = -1
        SesionUsuario.Sucursal = String.Empty
        SesionUsuario.CodEmpresa = String.Empty
        SesionUsuario.Empresa = String.Empty
        SesionUsuario.Permisos = Nothing
        SesionUsuario.Remoto = False

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If btnCambiarClave.Enabled Then 'Validar acceso del usuario

            If txtUsuario.Text.Trim <> String.Empty And txtClave.Text.Trim <> String.Empty Then
                'Solicitar una conexion al servidor de datos con las credenciales de usuario elegido
                'El conjunto de asignaciones por usuario son asignados a la variable publica del sistema
                If Login.IniciarSesionConServidor(txtUsuario.Text.Trim, txtClave.Text.Trim) Then
                    MsgBox(Login.UltimoMensaje, MsgBoxStyle.Information, lblTitulo.Text)
                    Me.Hide()
                Else
                    MsgBox(Login.UltimoMensaje, MsgBoxStyle.Critical, lblTitulo.Text)
                    txtUsuario.SelectAll()
                    txtUsuario.Focus()
                End If
            Else
                MessageBox.Show("Los campos 'Usuario' y 'Clave' son obligatorios.", lblTitulo.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtUsuario.SelectAll()
                txtUsuario.Focus()
            End If
        Else 'Cambiar clave del usuario

            If txtUsuario.Text.Trim <> String.Empty And txtClave.Text.Trim <> String.Empty _
            And txtNuevaClave.Text.Trim <> String.Empty And txtRepNuevaClave.Text.Trim <> String.Empty Then
                If txtNuevaClave.Text.Trim = txtRepNuevaClave.Text.Trim And txtClave.Text.Trim <> txtNuevaClave.Text.Trim Then
                    If Login.CambiarClaveDeUsuario(txtUsuario.Text.Trim, txtClave.Text.Trim, txtNuevaClave.Text.Trim) Then
                        MsgBox(Login.UltimoMensaje, MsgBoxStyle.Information, lblTitulo.Text)
                        btnCambiarClave.Enabled = True
                        txtNuevaClave.Text = String.Empty
                        txtRepNuevaClave.Text = String.Empty
                        txtClave.Text = String.Empty
                        txtUsuario.Text = String.Empty
                        SesionUsuario.Usuario = String.Empty 'para obligar una nueva validación
                        pCambClave.Visible = False
                        Me.Height = Me.Height - pCambClave.Height
                        txtUsuario.Focus()
                    Else
                        MsgBox(Login.UltimoMensaje, MsgBoxStyle.Exclamation, lblTitulo.Text)
                    End If
                Else

                    MessageBox.Show("La Clave original con la nueva clave debe ser diferentes" & vbCrLf & _
                    "y debe repetirse la misma nueva clave.", lblTitulo.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtNuevaClave.Text = ""
                    txtRepNuevaClave.Text = ""
                    txtClave.SelectAll()
                    txtClave.Focus()
                End If
            Else
                MessageBox.Show("Todos los campos son obligatorios.", lblTitulo.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtUsuario.SelectAll()
                txtUsuario.Focus()
            End If
        End If

    End Sub

    Private Sub pdu_DatosEquipo()
        Dim query As New SelectQuery("Win32_Processor")
        Dim search As New ManagementObjectSearcher(query)
        Dim info As ManagementObject

        Try
            For Each info In search.Get()
                Application.DoEvents()
                'Processor
                CheckEquipo.ProcesadorTipo = info("caption").ToString()
                'Processor Manufacturer
                CheckEquipo.ProcesadorMarca = info("name").ToString().TrimStart
                CheckEquipo.ProcesadorSerie = info("ProcessorID").ToString()
            Next
            CheckEquipo.EquipoNombre = SystemInformation.ComputerName
            '-- HDD info            
            Microsoft.VisualBasic.Left(My.Computer.FileSystem.CurrentDirectory, 3)
            CheckEquipo.HDDSerie = SerialNumber(Microsoft.VisualBasic.Left(My.Computer.FileSystem.CurrentDirectory, 3))
            '-- MainBoard --
            Dim mos As New ManagementObjectSearcher("root\CIMV2", _
                                            "SELECT * FROM Win32_BaseBoard")
            For Each mo As ManagementObject In mos.Get()
                CheckEquipo.PlacaMadreSerie = mo.GetPropertyValue("SerialNumber").ToString
                CheckEquipo.PlacaMadreMarca = mo.GetPropertyValue("Manufacturer").ToString
                CheckEquipo.PlacaMadreTipo = mo.GetPropertyValue("Product").ToString
            Next
        Catch
            CheckEquipo.EquipoNombre = String.Empty
        End Try

    End Sub

    Private Declare Function GetVolumeInformation Lib "Kernel32" Alias "GetVolumeInformationA" (ByVal lpRootPathName As String, ByVal lpVolumeNameBuffer As String, ByVal nVolumeNameSize As Integer, ByRef lpVolumeSerialNumber As Integer, ByRef lpMaximumComponentLength As Integer, ByRef lpFileSystemFlags As Integer, ByVal lpFileSystemNameBuffer As String, ByVal nFileSystemNameSize As Integer) As Integer

    Public Function SerialNumber(Optional ByVal Drive As String = "C:\") As String
        Dim Serial As Integer              'Serialno
        Dim VName, FSName As String
        'Create buffers
        VName = New String(Chr(0), 255)    'Volume name
        FSName = New String(Chr(0), 255)   'File system

        'Get the volume information
        GetVolumeInformation(Drive, VName, 255, Serial, 0, 0, FSName, 255)
        'Strip the extra chr$(0)'s
        VName = Microsoft.VisualBasic.Left(VName, InStr(1, VName, Chr(0)) - 1)
        FSName = Microsoft.VisualBasic.Left(FSName, InStr(1, FSName, Chr(0)) - 1)
        'Return Trim(Str(Serial))
        Return Serial.ToString.Trim
    End Function


    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If btnCambiarClave.Enabled Then
            SesionUsuario.Usuario = String.Empty ' indica que no estoy validado
            VarSale = True
            Me.Close()
        Else 'cancelar cambio de clave
            btnCambiarClave.Enabled = True
            txtNuevaClave.Text = String.Empty
            txtRepNuevaClave.Text = String.Empty
            txtClave.Text = String.Empty
            txtUsuario.Text = String.Empty
            pCambClave.Visible = False
            Me.Height = Me.Height - pCambClave.Height
            txtUsuario.Focus()
        End If
    End Sub

    Private Sub btnCambiarClave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCambiarClave.Click

        If MessageBox.Show("¿Desea cambiar su clave de usuario?", lblTitulo.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            btnCambiarClave.Enabled = False
            Me.Height = Me.Height + pCambClave.Height
            pCambClave.Visible = True
            txtUsuario.SelectAll()
            txtUsuario.Focus()
        End If

    End Sub

    Private Sub frmLogin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Application.Exit()

    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pdu_DatosEquipo()

        'Dim mibmp As Bitmap = picODBC.Image
        'Dim micol As Color = mibmp.GetPixel(1, 1)
        'mibmp.MakeTransparent(micol)
        'picODBC.Image = mibmp

        'If My.Application.Info.CompanyName.Trim <> String.Empty Then
        '    lblTitulo.Text = My.Application.Info.CompanyName
        'Else
        '    lblTitulo.Text = "Credenciales"
        'End If
        Me.Height = Me.Height - pCambClave.Height
        'cambiare con la clave
        pCambClave.Visible = False
        txtUsuario.Focus()

    End Sub

    Private Sub txtClave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClave.KeyPress
        If Asc(e.KeyChar) = Keys.Return Then
            If pCambClave.Visible = False Then
                btnAceptar.Focus()
            Else
                txtNuevaClave.Focus()
            End If
        End If
    End Sub

    Private Sub txtUsuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsuario.KeyPress
        If Asc(e.KeyChar) = Keys.Return Then txtClave.Focus()
    End Sub

    Private Sub txtNuevaClave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNuevaClave.KeyPress
        If Asc(e.KeyChar) = Keys.Return Then txtRepNuevaClave.Focus()
    End Sub

    Private Sub txtRepNuevaClave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRepNuevaClave.KeyPress
        If Asc(e.KeyChar) = Keys.Return Then btnAceptar.Focus()
    End Sub

    Private Sub picODBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picODBC.Click
        '--MsgBox("Cargar ODBC")
        Dim oFrm As New frmODBC
        oFrm.ShowDialog()
    End Sub
End Class
