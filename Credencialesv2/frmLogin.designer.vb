<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class frmLogin
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.txtNuevaClave = New System.Windows.Forms.TextBox
        Me.pBotones = New System.Windows.Forms.Panel
        Me.btnCambiarClave = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.txtClave = New System.Windows.Forms.TextBox
        Me.txtUsuario = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblTitulo = New System.Windows.Forms.Label
        Me.pSucursal = New System.Windows.Forms.Panel
        Me.cbSede = New System.Windows.Forms.ComboBox
        Me.pCambClave = New System.Windows.Forms.Panel
        Me.txtRepNuevaClave = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.picODBC = New System.Windows.Forms.PictureBox
        Me.pBotones.SuspendLayout()
        Me.pSucursal.SuspendLayout()
        Me.pCambClave.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picODBC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtNuevaClave
        '
        Me.txtNuevaClave.Location = New System.Drawing.Point(104, 16)
        Me.txtNuevaClave.MaxLength = 10
        Me.txtNuevaClave.Name = "txtNuevaClave"
        Me.txtNuevaClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNuevaClave.Size = New System.Drawing.Size(128, 20)
        Me.txtNuevaClave.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtNuevaClave, "Máximo de 10 caracteres")
        '
        'pBotones
        '
        Me.pBotones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pBotones.BackColor = System.Drawing.Color.Transparent
        Me.pBotones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pBotones.Controls.Add(Me.btnCambiarClave)
        Me.pBotones.Controls.Add(Me.btnCancelar)
        Me.pBotones.Controls.Add(Me.btnAceptar)
        Me.pBotones.Location = New System.Drawing.Point(7, 250)
        Me.pBotones.Name = "pBotones"
        Me.pBotones.Size = New System.Drawing.Size(328, 40)
        Me.pBotones.TabIndex = 61
        '
        'btnCambiarClave
        '
        Me.btnCambiarClave.BackColor = System.Drawing.Color.Silver
        Me.btnCambiarClave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCambiarClave.ImageIndex = 2
        Me.btnCambiarClave.ImageList = Me.ImageList1
        Me.btnCambiarClave.Location = New System.Drawing.Point(197, 8)
        Me.btnCambiarClave.Name = "btnCambiarClave"
        Me.btnCambiarClave.Size = New System.Drawing.Size(122, 23)
        Me.btnCambiarClave.TabIndex = 2
        Me.btnCambiarClave.Text = "Cam&biar clave..."
        Me.btnCambiarClave.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "ACEPTAR.ICO")
        Me.ImageList1.Images.SetKeyName(1, "CANCELAR.ICO")
        Me.ImageList1.Images.SetKeyName(2, "SECUR01B.ICO")
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.Silver
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 1
        Me.btnCancelar.ImageList = Me.ImageList1
        Me.btnCancelar.Location = New System.Drawing.Point(96, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(95, 23)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.Color.Silver
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.ImageIndex = 0
        Me.btnAceptar.ImageList = Me.ImageList1
        Me.btnAceptar.Location = New System.Drawing.Point(8, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(82, 23)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'txtClave
        '
        Me.txtClave.Location = New System.Drawing.Point(188, 139)
        Me.txtClave.MaxLength = 10
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClave.Size = New System.Drawing.Size(128, 20)
        Me.txtClave.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtClave, "Máximo de 10 caracteres")
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(188, 99)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(128, 20)
        Me.txtUsuario.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(84, 139)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "Contraseña:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(84, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Usuario:"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 40)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Nueva contraseña:"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.Panel1.ForeColor = System.Drawing.SystemColors.Control
        Me.Panel1.Location = New System.Drawing.Point(-1, 51)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(343, 18)
        Me.Panel1.TabIndex = 59
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(8, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 23)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Sede:"
        '
        'lblTitulo
        '
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.Blue
        Me.lblTitulo.Location = New System.Drawing.Point(0, 3)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(343, 45)
        Me.lblTitulo.TabIndex = 58
        Me.lblTitulo.Text = "Nombre de la Empresa"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pSucursal
        '
        Me.pSucursal.BackColor = System.Drawing.Color.Transparent
        Me.pSucursal.Controls.Add(Me.cbSede)
        Me.pSucursal.Controls.Add(Me.Label6)
        Me.pSucursal.Location = New System.Drawing.Point(4, 251)
        Me.pSucursal.Name = "pSucursal"
        Me.pSucursal.Size = New System.Drawing.Size(328, 40)
        Me.pSucursal.TabIndex = 63
        '
        'cbSede
        '
        Me.cbSede.Location = New System.Drawing.Point(64, 8)
        Me.cbSede.Name = "cbSede"
        Me.cbSede.Size = New System.Drawing.Size(248, 21)
        Me.cbSede.TabIndex = 24
        '
        'pCambClave
        '
        Me.pCambClave.BackColor = System.Drawing.Color.Transparent
        Me.pCambClave.Controls.Add(Me.txtRepNuevaClave)
        Me.pCambClave.Controls.Add(Me.txtNuevaClave)
        Me.pCambClave.Controls.Add(Me.Label5)
        Me.pCambClave.Controls.Add(Me.Label4)
        Me.pCambClave.Location = New System.Drawing.Point(84, 161)
        Me.pCambClave.Name = "pCambClave"
        Me.pCambClave.Size = New System.Drawing.Size(240, 88)
        Me.pCambClave.TabIndex = 62
        '
        'txtRepNuevaClave
        '
        Me.txtRepNuevaClave.Location = New System.Drawing.Point(104, 56)
        Me.txtRepNuevaClave.MaxLength = 10
        Me.txtRepNuevaClave.Name = "txtRepNuevaClave"
        Me.txtRepNuevaClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtRepNuevaClave.Size = New System.Drawing.Size(128, 20)
        Me.txtRepNuevaClave.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtRepNuevaClave, "Máximo de 10 caracteres")
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(0, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 33)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Repetir contraseña:"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(4, 51)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(131, 155)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 60
        Me.PictureBox1.TabStop = False
        '
        'picODBC
        '
        Me.picODBC.BackColor = System.Drawing.Color.Transparent
        Me.picODBC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picODBC.Image = CType(resources.GetObject("picODBC.Image"), System.Drawing.Image)
        Me.picODBC.Location = New System.Drawing.Point(301, 48)
        Me.picODBC.Margin = New System.Windows.Forms.Padding(13, 3, 3, 3)
        Me.picODBC.Name = "picODBC"
        Me.picODBC.Size = New System.Drawing.Size(25, 35)
        Me.picODBC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picODBC.TabIndex = 64
        Me.picODBC.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picODBC, "Cambiar Conexión al Servidor")
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightYellow
        Me.ClientSize = New System.Drawing.Size(342, 294)
        Me.Controls.Add(Me.picODBC)
        Me.Controls.Add(Me.pBotones)
        Me.Controls.Add(Me.txtClave)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.pSucursal)
        Me.Controls.Add(Me.pCambClave)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Acceso Restringido..."
        Me.pBotones.ResumeLayout(False)
        Me.pSucursal.ResumeLayout(False)
        Me.pCambClave.ResumeLayout(False)
        Me.pCambClave.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picODBC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNuevaClave As System.Windows.Forms.TextBox
    Friend WithEvents pBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCambiarClave As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pSucursal As System.Windows.Forms.Panel
    Friend WithEvents cbSede As System.Windows.Forms.ComboBox
    Friend WithEvents pCambClave As System.Windows.Forms.Panel
    Friend WithEvents txtRepNuevaClave As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Public WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents picODBC As System.Windows.Forms.PictureBox

End Class
