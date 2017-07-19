<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptRolesPermisos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptRolesPermisos))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cbxRol = New System.Windows.Forms.ComboBox
        Me.dgvRoles = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbSistema = New System.Windows.Forms.ComboBox
        Me.gbModulo = New System.Windows.Forms.GroupBox
        Me.tvw_SMO = New System.Windows.Forms.TreeView
        Me.btnOut = New System.Windows.Forms.Button
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.btnIn = New System.Windows.Forms.Button
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvRoles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gbModulo.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbxRol)
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(510, 124)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(286, 44)
        Me.GroupBox2.TabIndex = 59
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Rol"
        '
        'cbxRol
        '
        Me.cbxRol.BackColor = System.Drawing.Color.White
        Me.cbxRol.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxRol.FormattingEnabled = True
        Me.cbxRol.Location = New System.Drawing.Point(7, 14)
        Me.cbxRol.Name = "cbxRol"
        Me.cbxRol.Size = New System.Drawing.Size(273, 24)
        Me.cbxRol.TabIndex = 50
        '
        'dgvRoles
        '
        Me.dgvRoles.AllowUserToAddRows = False
        Me.dgvRoles.AllowUserToDeleteRows = False
        Me.dgvRoles.AllowUserToResizeRows = False
        Me.dgvRoles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvRoles.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRoles.Location = New System.Drawing.Point(7, 299)
        Me.dgvRoles.Name = "dgvRoles"
        Me.dgvRoles.ReadOnly = True
        Me.dgvRoles.Size = New System.Drawing.Size(807, 307)
        Me.dgvRoles.TabIndex = 55
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Verdana", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(823, 28)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "ROLES Y PERMISOS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbSistema)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(510, 174)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(286, 44)
        Me.GroupBox1.TabIndex = 60
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sistema"
        '
        'cbSistema
        '
        Me.cbSistema.BackColor = System.Drawing.Color.White
        Me.cbSistema.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSistema.FormattingEnabled = True
        Me.cbSistema.Location = New System.Drawing.Point(7, 14)
        Me.cbSistema.Name = "cbSistema"
        Me.cbSistema.Size = New System.Drawing.Size(273, 24)
        Me.cbSistema.TabIndex = 50
        '
        'gbModulo
        '
        Me.gbModulo.Controls.Add(Me.tvw_SMO)
        Me.gbModulo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbModulo.Location = New System.Drawing.Point(7, 42)
        Me.gbModulo.Name = "gbModulo"
        Me.gbModulo.Size = New System.Drawing.Size(486, 251)
        Me.gbModulo.TabIndex = 61
        Me.gbModulo.TabStop = False
        Me.gbModulo.Text = "Modulo"
        '
        'tvw_SMO
        '
        Me.tvw_SMO.BackColor = System.Drawing.SystemColors.HighlightText
        Me.tvw_SMO.CheckBoxes = True
        Me.tvw_SMO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvw_SMO.Location = New System.Drawing.Point(3, 18)
        Me.tvw_SMO.Name = "tvw_SMO"
        Me.tvw_SMO.Size = New System.Drawing.Size(480, 230)
        Me.tvw_SMO.TabIndex = 1
        '
        'btnOut
        '
        Me.btnOut.Image = Global.CredencialesSistemas.My.Resources.Resources.arrow_out
        Me.btnOut.Location = New System.Drawing.Point(496, 60)
        Me.btnOut.Name = "btnOut"
        Me.btnOut.Size = New System.Drawing.Size(32, 30)
        Me.btnOut.TabIndex = 62
        Me.btnOut.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.Location = New System.Drawing.Point(700, 224)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(90, 34)
        Me.btnBuscar.TabIndex = 56
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnIn
        '
        Me.btnIn.Image = CType(resources.GetObject("btnIn.Image"), System.Drawing.Image)
        Me.btnIn.Location = New System.Drawing.Point(496, 60)
        Me.btnIn.Name = "btnIn"
        Me.btnIn.Size = New System.Drawing.Size(32, 30)
        Me.btnIn.TabIndex = 63
        Me.btnIn.UseVisualStyleBackColor = True
        '
        'FrmRptRolesPermisos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Beige
        Me.ClientSize = New System.Drawing.Size(823, 613)
        Me.Controls.Add(Me.gbModulo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.dgvRoles)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnOut)
        Me.Controls.Add(Me.btnIn)
        Me.Name = "FrmRptRolesPermisos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte: Roles y Permisos"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvRoles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.gbModulo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbxRol As System.Windows.Forms.ComboBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents dgvRoles As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbSistema As System.Windows.Forms.ComboBox
    Friend WithEvents gbModulo As System.Windows.Forms.GroupBox
    Friend WithEvents tvw_SMO As System.Windows.Forms.TreeView
    Friend WithEvents btnOut As System.Windows.Forms.Button
    Friend WithEvents btnIn As System.Windows.Forms.Button
End Class
