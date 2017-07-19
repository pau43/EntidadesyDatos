<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmODBC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmODBC))
        Me.picRemoto = New System.Windows.Forms.PictureBox
        Me.lblMsg = New System.Windows.Forms.Label
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.picLocal = New System.Windows.Forms.PictureBox
        Me.cbxRutaCnx = New System.Windows.Forms.ComboBox
        Me.picRpt = New System.Windows.Forms.PictureBox
        CType(Me.picRemoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLocal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picRpt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picRemoto
        '
        Me.picRemoto.Image = CType(resources.GetObject("picRemoto.Image"), System.Drawing.Image)
        Me.picRemoto.Location = New System.Drawing.Point(104, 20)
        Me.picRemoto.Name = "picRemoto"
        Me.picRemoto.Size = New System.Drawing.Size(110, 116)
        Me.picRemoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picRemoto.TabIndex = 0
        Me.picRemoto.TabStop = False
        Me.picRemoto.Visible = False
        '
        'lblMsg
        '
        Me.lblMsg.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblMsg.ForeColor = System.Drawing.Color.LightCyan
        Me.lblMsg.Location = New System.Drawing.Point(-1, 139)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(217, 18)
        Me.lblMsg.TabIndex = 1
        Me.lblMsg.Text = "....."
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(22, 65)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(59, 40)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "Crear"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'picLocal
        '
        Me.picLocal.Image = CType(resources.GetObject("picLocal.Image"), System.Drawing.Image)
        Me.picLocal.Location = New System.Drawing.Point(111, 39)
        Me.picLocal.Name = "picLocal"
        Me.picLocal.Size = New System.Drawing.Size(100, 97)
        Me.picLocal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picLocal.TabIndex = 5
        Me.picLocal.TabStop = False
        '
        'cbxRutaCnx
        '
        Me.cbxRutaCnx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxRutaCnx.FormattingEnabled = True
        Me.cbxRutaCnx.Location = New System.Drawing.Point(1, 20)
        Me.cbxRutaCnx.Name = "cbxRutaCnx"
        Me.cbxRutaCnx.Size = New System.Drawing.Size(104, 21)
        Me.cbxRutaCnx.TabIndex = 10
        '
        'picRpt
        '
        Me.picRpt.Location = New System.Drawing.Point(103, 45)
        Me.picRpt.Name = "picRpt"
        Me.picRpt.Size = New System.Drawing.Size(103, 91)
        Me.picRpt.TabIndex = 11
        Me.picRpt.TabStop = False
        Me.picRpt.Visible = False
        '
        'frmODBC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(216, 157)
        Me.Controls.Add(Me.picRpt)
        Me.Controls.Add(Me.cbxRutaCnx)
        Me.Controls.Add(Me.picLocal)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.picRemoto)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmODBC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Conexión ODBC"
        CType(Me.picRemoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLocal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picRpt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents picRemoto As System.Windows.Forms.PictureBox
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents picLocal As System.Windows.Forms.PictureBox
    Friend WithEvents cbxRutaCnx As System.Windows.Forms.ComboBox
    Friend WithEvents picRpt As System.Windows.Forms.PictureBox

End Class
