<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMapeoSubAlm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMapeoSubAlm))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbAlmacen = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgvSubAlmacenes = New System.Windows.Forms.DataGridView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton
        Me.lblUsuario = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.scSubAlmacenes = New System.Windows.Forms.SplitContainer
        Me.Check = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.RW1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvSubAlmacenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.scSubAlmacenes.Panel1.SuspendLayout()
        Me.scSubAlmacenes.Panel2.SuspendLayout()
        Me.scSubAlmacenes.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbAlmacen)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(443, 46)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Almacén"
        '
        'cbAlmacen
        '
        Me.cbAlmacen.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAlmacen.FormattingEnabled = True
        Me.cbAlmacen.Location = New System.Drawing.Point(6, 19)
        Me.cbAlmacen.Name = "cbAlmacen"
        Me.cbAlmacen.Size = New System.Drawing.Size(430, 22)
        Me.cbAlmacen.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.dgvSubAlmacenes)
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(443, 303)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sub Almacenes"
        '
        'dgvSubAlmacenes
        '
        Me.dgvSubAlmacenes.AllowUserToAddRows = False
        Me.dgvSubAlmacenes.AllowUserToDeleteRows = False
        Me.dgvSubAlmacenes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSubAlmacenes.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvSubAlmacenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSubAlmacenes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Check, Me.RW1})
        Me.dgvSubAlmacenes.Location = New System.Drawing.Point(6, 21)
        Me.dgvSubAlmacenes.Name = "dgvSubAlmacenes"
        Me.dgvSubAlmacenes.ReadOnly = True
        Me.dgvSubAlmacenes.RowHeadersVisible = False
        Me.dgvSubAlmacenes.Size = New System.Drawing.Size(428, 276)
        Me.dgvSubAlmacenes.TabIndex = 6
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.btnCancelar, Me.lblUsuario, Me.ToolStripLabel2, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(457, 25)
        Me.ToolStrip1.TabIndex = 50
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(5, 1, 0, 2)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(69, 22)
        Me.btnGuardar.Text = "&Guardar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(73, 22)
        Me.btnCancelar.Text = "&Cancelar"
        '
        'lblUsuario
        '
        Me.lblUsuario.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblUsuario.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblUsuario.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(49, 22)
        Me.lblUsuario.Text = "Usuario"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel2.ForeColor = System.Drawing.Color.Maroon
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(50, 22)
        Me.ToolStripLabel2.Text = "Usuario:"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'scSubAlmacenes
        '
        Me.scSubAlmacenes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scSubAlmacenes.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.scSubAlmacenes.IsSplitterFixed = True
        Me.scSubAlmacenes.Location = New System.Drawing.Point(0, 25)
        Me.scSubAlmacenes.Name = "scSubAlmacenes"
        Me.scSubAlmacenes.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'scSubAlmacenes.Panel1
        '
        Me.scSubAlmacenes.Panel1.Controls.Add(Me.GroupBox1)
        '
        'scSubAlmacenes.Panel2
        '
        Me.scSubAlmacenes.Panel2.Controls.Add(Me.GroupBox2)
        Me.scSubAlmacenes.Size = New System.Drawing.Size(457, 374)
        Me.scSubAlmacenes.SplitterDistance = 61
        Me.scSubAlmacenes.TabIndex = 51
        '
        'Check
        '
        Me.Check.HeaderText = "Check"
        Me.Check.Name = "Check"
        Me.Check.ReadOnly = True
        Me.Check.Width = 50
        '
        'RW1
        '
        Me.RW1.HeaderText = "RW"
        Me.RW1.Name = "RW1"
        Me.RW1.ReadOnly = True
        Me.RW1.Width = 40
        '
        'frmMapeoSubAlm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Beige
        Me.ClientSize = New System.Drawing.Size(457, 399)
        Me.Controls.Add(Me.scSubAlmacenes)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmMapeoSubAlm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mapeo: Usuario - SubAlmacenes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvSubAlmacenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.scSubAlmacenes.Panel1.ResumeLayout(False)
        Me.scSubAlmacenes.Panel2.ResumeLayout(False)
        Me.scSubAlmacenes.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblUsuario As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgvSubAlmacenes As System.Windows.Forms.DataGridView
    Friend WithEvents scSubAlmacenes As System.Windows.Forms.SplitContainer
    Friend WithEvents Check As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents RW1 As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
