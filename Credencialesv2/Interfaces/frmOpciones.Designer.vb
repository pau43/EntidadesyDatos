<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOpciones
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOpciones))
        Me.gbxSistemas = New System.Windows.Forms.GroupBox
        Me.cbxSistemas = New System.Windows.Forms.ComboBox
        Me.gbxModulos = New System.Windows.Forms.GroupBox
        Me.dgvModulos = New System.Windows.Forms.DataGridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtProceso = New System.Windows.Forms.TextBox
        Me.chkRevalidar = New System.Windows.Forms.CheckBox
        Me.dgvOpciones = New System.Windows.Forms.DataGridView
        Me.txtOpcion = New System.Windows.Forms.TextBox
        Me.txtCodNivel = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblModulo = New System.Windows.Forms.Label
        Me.lblSistema = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbCrear = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbDeshacer = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbBorrar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbRecargar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.gbxSistemas.SuspendLayout()
        Me.gbxModulos.SuspendLayout()
        CType(Me.dgvModulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvOpciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbxSistemas
        '
        Me.gbxSistemas.Controls.Add(Me.cbxSistemas)
        Me.gbxSistemas.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxSistemas.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gbxSistemas.Location = New System.Drawing.Point(4, 3)
        Me.gbxSistemas.Name = "gbxSistemas"
        Me.gbxSistemas.Size = New System.Drawing.Size(309, 54)
        Me.gbxSistemas.TabIndex = 0
        Me.gbxSistemas.TabStop = False
        Me.gbxSistemas.Text = "SISTEMAS"
        '
        'cbxSistemas
        '
        Me.cbxSistemas.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxSistemas.FormattingEnabled = True
        Me.cbxSistemas.Location = New System.Drawing.Point(7, 20)
        Me.cbxSistemas.Name = "cbxSistemas"
        Me.cbxSistemas.Size = New System.Drawing.Size(296, 24)
        Me.cbxSistemas.TabIndex = 0
        '
        'gbxModulos
        '
        Me.gbxModulos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbxModulos.Controls.Add(Me.dgvModulos)
        Me.gbxModulos.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxModulos.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gbxModulos.Location = New System.Drawing.Point(4, 59)
        Me.gbxModulos.Name = "gbxModulos"
        Me.gbxModulos.Size = New System.Drawing.Size(310, 296)
        Me.gbxModulos.TabIndex = 1
        Me.gbxModulos.TabStop = False
        Me.gbxModulos.Text = "MODULOS"
        '
        'dgvModulos
        '
        Me.dgvModulos.AllowUserToAddRows = False
        Me.dgvModulos.AllowUserToDeleteRows = False
        Me.dgvModulos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvModulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvModulos.Location = New System.Drawing.Point(7, 20)
        Me.dgvModulos.Name = "dgvModulos"
        Me.dgvModulos.ReadOnly = True
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.dgvModulos.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvModulos.Size = New System.Drawing.Size(297, 270)
        Me.dgvModulos.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.txtProceso)
        Me.GroupBox3.Controls.Add(Me.chkRevalidar)
        Me.GroupBox3.Controls.Add(Me.dgvOpciones)
        Me.GroupBox3.Controls.Add(Me.txtOpcion)
        Me.GroupBox3.Controls.Add(Me.txtCodNivel)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.lblModulo)
        Me.GroupBox3.Controls.Add(Me.lblSistema)
        Me.GroupBox3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(347, 352)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "OPCIONES"
        '
        'txtProceso
        '
        Me.txtProceso.Enabled = False
        Me.txtProceso.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProceso.Location = New System.Drawing.Point(106, 119)
        Me.txtProceso.Name = "txtProceso"
        Me.txtProceso.Size = New System.Drawing.Size(236, 22)
        Me.txtProceso.TabIndex = 8
        '
        'chkRevalidar
        '
        Me.chkRevalidar.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkRevalidar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRevalidar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkRevalidar.Location = New System.Drawing.Point(23, 122)
        Me.chkRevalidar.Name = "chkRevalidar"
        Me.chkRevalidar.Size = New System.Drawing.Size(81, 17)
        Me.chkRevalidar.TabIndex = 7
        Me.chkRevalidar.Text = "Revalidar? :"
        Me.chkRevalidar.UseVisualStyleBackColor = True
        '
        'dgvOpciones
        '
        Me.dgvOpciones.AllowUserToAddRows = False
        Me.dgvOpciones.AllowUserToDeleteRows = False
        Me.dgvOpciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvOpciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOpciones.Location = New System.Drawing.Point(6, 145)
        Me.dgvOpciones.Name = "dgvOpciones"
        Me.dgvOpciones.ReadOnly = True
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.dgvOpciones.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvOpciones.Size = New System.Drawing.Size(335, 201)
        Me.dgvOpciones.TabIndex = 6
        '
        'txtOpcion
        '
        Me.txtOpcion.Enabled = False
        Me.txtOpcion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOpcion.Location = New System.Drawing.Point(89, 94)
        Me.txtOpcion.Name = "txtOpcion"
        Me.txtOpcion.Size = New System.Drawing.Size(253, 22)
        Me.txtOpcion.TabIndex = 5
        '
        'txtCodNivel
        '
        Me.txtCodNivel.Enabled = False
        Me.txtCodNivel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodNivel.Location = New System.Drawing.Point(89, 69)
        Me.txtCodNivel.Name = "txtCodNivel"
        Me.txtCodNivel.Size = New System.Drawing.Size(65, 22)
        Me.txtCodNivel.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(6, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 22)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Opción:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(6, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 22)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Cod. Nivel:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblModulo
        '
        Me.lblModulo.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblModulo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModulo.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblModulo.Location = New System.Drawing.Point(6, 43)
        Me.lblModulo.Name = "lblModulo"
        Me.lblModulo.Size = New System.Drawing.Size(336, 24)
        Me.lblModulo.TabIndex = 1
        Me.lblModulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSistema
        '
        Me.lblSistema.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblSistema.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSistema.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblSistema.Location = New System.Drawing.Point(6, 19)
        Me.lblSistema.Name = "lblSistema"
        Me.lblSistema.Size = New System.Drawing.Size(336, 23)
        Me.lblSistema.TabIndex = 0
        Me.lblSistema.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbCrear, Me.ToolStripSeparator1, Me.tsbEditar, Me.ToolStripSeparator2, Me.tsbDeshacer, Me.ToolStripSeparator3, Me.tsbGrabar, Me.ToolStripSeparator4, Me.tsbBorrar, Me.ToolStripSeparator5, Me.tsbRecargar, Me.ToolStripSeparator6, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(2, 1)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(323, 53)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbCrear
        '
        Me.tsbCrear.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbCrear.Image = CType(resources.GetObject("tsbCrear.Image"), System.Drawing.Image)
        Me.tsbCrear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCrear.Name = "tsbCrear"
        Me.tsbCrear.Size = New System.Drawing.Size(39, 50)
        Me.tsbCrear.Text = "&Crear"
        Me.tsbCrear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 53)
        '
        'tsbEditar
        '
        Me.tsbEditar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbEditar.Image = CType(resources.GetObject("tsbEditar.Image"), System.Drawing.Image)
        Me.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditar.Name = "tsbEditar"
        Me.tsbEditar.Size = New System.Drawing.Size(58, 50)
        Me.tsbEditar.Text = "&Modificar"
        Me.tsbEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 53)
        '
        'tsbDeshacer
        '
        Me.tsbDeshacer.Enabled = False
        Me.tsbDeshacer.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbDeshacer.Image = CType(resources.GetObject("tsbDeshacer.Image"), System.Drawing.Image)
        Me.tsbDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDeshacer.Name = "tsbDeshacer"
        Me.tsbDeshacer.Size = New System.Drawing.Size(61, 50)
        Me.tsbDeshacer.Text = "&Deshacer"
        Me.tsbDeshacer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 53)
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Enabled = False
        Me.tsbGrabar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(46, 50)
        Me.tsbGrabar.Text = "&Grabar"
        Me.tsbGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 53)
        '
        'tsbBorrar
        '
        Me.tsbBorrar.Image = CType(resources.GetObject("tsbBorrar.Image"), System.Drawing.Image)
        Me.tsbBorrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbBorrar.Name = "tsbBorrar"
        Me.tsbBorrar.Size = New System.Drawing.Size(43, 50)
        Me.tsbBorrar.Text = "&Borrar"
        Me.tsbBorrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 53)
        '
        'tsbRecargar
        '
        Me.tsbRecargar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbRecargar.Image = CType(resources.GetObject("tsbRecargar.Image"), System.Drawing.Image)
        Me.tsbRecargar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRecargar.Name = "tsbRecargar"
        Me.tsbRecargar.Size = New System.Drawing.Size(59, 50)
        Me.tsbRecargar.Text = "&ReCargar"
        Me.tsbRecargar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbRecargar.Visible = False
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 53)
        Me.ToolStripSeparator6.Visible = False
        '
        'tsbSalir
        '
        Me.tsbSalir.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(36, 50)
        Me.tsbSalir.Text = "&Salir"
        Me.tsbSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(2, 57)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox3)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.gbxSistemas)
        Me.SplitContainer1.Panel2.Controls.Add(Me.gbxModulos)
        Me.SplitContainer1.Size = New System.Drawing.Size(678, 360)
        Me.SplitContainer1.SplitterDistance = 355
        Me.SplitContainer1.TabIndex = 4
        '
        'frmOpciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Beige
        Me.ClientSize = New System.Drawing.Size(684, 425)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(690, 452)
        Me.Name = "frmOpciones"
        Me.Text = "Opciones de Módulo del Sistema"
        Me.gbxSistemas.ResumeLayout(False)
        Me.gbxModulos.ResumeLayout(False)
        CType(Me.dgvModulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvOpciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbxSistemas As System.Windows.Forms.GroupBox
    Friend WithEvents cbxSistemas As System.Windows.Forms.ComboBox
    Friend WithEvents gbxModulos As System.Windows.Forms.GroupBox
    Friend WithEvents dgvModulos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbCrear As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbRecargar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtOpcion As System.Windows.Forms.TextBox
    Friend WithEvents txtCodNivel As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblModulo As System.Windows.Forms.Label
    Friend WithEvents lblSistema As System.Windows.Forms.Label
    Friend WithEvents dgvOpciones As System.Windows.Forms.DataGridView
    Friend WithEvents tsbBorrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents chkRevalidar As System.Windows.Forms.CheckBox
    Friend WithEvents txtProceso As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
End Class
