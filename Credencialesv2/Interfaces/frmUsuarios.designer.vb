<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUsuarios))
        Me.gbxPersonas = New System.Windows.Forms.GroupBox
        Me.tsmPaginado = New System.Windows.Forms.ToolStrip
        Me.tsb_Ver = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.tslbl_PagX = New System.Windows.Forms.ToolStripLabel
        Me.tscbx_Paginas = New System.Windows.Forms.ToolStripComboBox
        Me.tslbl_DePag = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.tstxt_Buscar = New System.Windows.Forms.ToolStripTextBox
        Me.dgvPersonas = New System.Windows.Forms.DataGridView
        Me.gbxUsuario = New System.Windows.Forms.GroupBox
        Me.nudUsuarios = New System.Windows.Forms.NumericUpDown
        Me.TabUsuario = New System.Windows.Forms.TabControl
        Me.tpgDatos = New System.Windows.Forms.TabPage
        Me.chbRemoto = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.picUserHe = New System.Windows.Forms.PictureBox
        Me.chkHabilitado = New System.Windows.Forms.CheckBox
        Me.picUserShe = New System.Windows.Forms.PictureBox
        Me.txtNombre = New System.Windows.Forms.TextBox
        Me.txtUsuario = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.tpgListado = New System.Windows.Forms.TabPage
        Me.dgvUsuarios = New System.Windows.Forms.DataGridView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbCrear = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbDeshacer = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbMapSis = New System.Windows.Forms.ToolStripButton
        Me.tsbVolver = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbReiniciaClave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkRol = New System.Windows.Forms.CheckBox
        Me.cbxRol = New System.Windows.Forms.ComboBox
        Me.gbxMapeo = New System.Windows.Forms.GroupBox
        Me.btnAsignar = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbxSucursal = New System.Windows.Forms.ComboBox
        Me.cbxSistemas = New System.Windows.Forms.ComboBox
        Me.dgvMapeoSistemas = New System.Windows.Forms.DataGridView
        Me.gbxPersonas.SuspendLayout()
        Me.tsmPaginado.SuspendLayout()
        CType(Me.dgvPersonas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxUsuario.SuspendLayout()
        CType(Me.nudUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabUsuario.SuspendLayout()
        Me.tpgDatos.SuspendLayout()
        CType(Me.picUserHe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picUserShe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgListado.SuspendLayout()
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbxMapeo.SuspendLayout()
        CType(Me.dgvMapeoSistemas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbxPersonas
        '
        Me.gbxPersonas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbxPersonas.Controls.Add(Me.tsmPaginado)
        Me.gbxPersonas.Controls.Add(Me.dgvPersonas)
        Me.gbxPersonas.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxPersonas.ForeColor = System.Drawing.SystemColors.Desktop
        Me.gbxPersonas.Location = New System.Drawing.Point(374, 0)
        Me.gbxPersonas.Name = "gbxPersonas"
        Me.gbxPersonas.Size = New System.Drawing.Size(492, 449)
        Me.gbxPersonas.TabIndex = 0
        Me.gbxPersonas.TabStop = False
        Me.gbxPersonas.Text = "P E R S O N A S"
        '
        'tsmPaginado
        '
        Me.tsmPaginado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tsmPaginado.AutoSize = False
        Me.tsmPaginado.Dock = System.Windows.Forms.DockStyle.None
        Me.tsmPaginado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsb_Ver, Me.ToolStripSeparator5, Me.tslbl_PagX, Me.tscbx_Paginas, Me.tslbl_DePag, Me.ToolStripSeparator6, Me.ToolStripLabel1, Me.tstxt_Buscar})
        Me.tsmPaginado.Location = New System.Drawing.Point(4, 17)
        Me.tsmPaginado.Name = "tsmPaginado"
        Me.tsmPaginado.Size = New System.Drawing.Size(482, 30)
        Me.tsmPaginado.TabIndex = 3
        Me.tsmPaginado.Text = "ToolStrip2"
        '
        'tsb_Ver
        '
        Me.tsb_Ver.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsb_Ver.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tsb_Ver.Image = CType(resources.GetObject("tsb_Ver.Image"), System.Drawing.Image)
        Me.tsb_Ver.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_Ver.Name = "tsb_Ver"
        Me.tsb_Ver.Size = New System.Drawing.Size(46, 27)
        Me.tsb_Ver.Text = "&Ver"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 30)
        '
        'tslbl_PagX
        '
        Me.tslbl_PagX.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tslbl_PagX.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tslbl_PagX.Name = "tslbl_PagX"
        Me.tslbl_PagX.Size = New System.Drawing.Size(59, 27)
        Me.tslbl_PagX.Text = "Pag.(x...)"
        '
        'tscbx_Paginas
        '
        Me.tscbx_Paginas.AutoSize = False
        Me.tscbx_Paginas.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tscbx_Paginas.Name = "tscbx_Paginas"
        Me.tscbx_Paginas.Size = New System.Drawing.Size(60, 22)
        '
        'tslbl_DePag
        '
        Me.tslbl_DePag.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tslbl_DePag.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tslbl_DePag.Name = "tslbl_DePag"
        Me.tslbl_DePag.Size = New System.Drawing.Size(27, 27)
        Me.tslbl_DePag.Text = "- ..."
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 30)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(46, 27)
        Me.ToolStripLabel1.Text = "Buscar:"
        '
        'tstxt_Buscar
        '
        Me.tstxt_Buscar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxt_Buscar.Name = "tstxt_Buscar"
        Me.tstxt_Buscar.Size = New System.Drawing.Size(100, 30)
        Me.tstxt_Buscar.ToolTipText = "[Enter]: ejecuta filtro"
        '
        'dgvPersonas
        '
        Me.dgvPersonas.AllowUserToAddRows = False
        Me.dgvPersonas.AllowUserToDeleteRows = False
        Me.dgvPersonas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPersonas.Location = New System.Drawing.Point(4, 45)
        Me.dgvPersonas.Name = "dgvPersonas"
        Me.dgvPersonas.ReadOnly = True
        Me.dgvPersonas.Size = New System.Drawing.Size(480, 398)
        Me.dgvPersonas.TabIndex = 0
        '
        'gbxUsuario
        '
        Me.gbxUsuario.Controls.Add(Me.nudUsuarios)
        Me.gbxUsuario.Controls.Add(Me.TabUsuario)
        Me.gbxUsuario.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxUsuario.ForeColor = System.Drawing.SystemColors.Desktop
        Me.gbxUsuario.Location = New System.Drawing.Point(5, 61)
        Me.gbxUsuario.Name = "gbxUsuario"
        Me.gbxUsuario.Size = New System.Drawing.Size(354, 200)
        Me.gbxUsuario.TabIndex = 1
        Me.gbxUsuario.TabStop = False
        Me.gbxUsuario.Text = "USUARIO"
        '
        'nudUsuarios
        '
        Me.nudUsuarios.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudUsuarios.Location = New System.Drawing.Point(273, 14)
        Me.nudUsuarios.Name = "nudUsuarios"
        Me.nudUsuarios.ReadOnly = True
        Me.nudUsuarios.Size = New System.Drawing.Size(72, 21)
        Me.nudUsuarios.TabIndex = 6
        Me.nudUsuarios.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudUsuarios.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'TabUsuario
        '
        Me.TabUsuario.Controls.Add(Me.tpgDatos)
        Me.TabUsuario.Controls.Add(Me.tpgListado)
        Me.TabUsuario.Location = New System.Drawing.Point(6, 16)
        Me.TabUsuario.Name = "TabUsuario"
        Me.TabUsuario.SelectedIndex = 0
        Me.TabUsuario.Size = New System.Drawing.Size(342, 178)
        Me.TabUsuario.TabIndex = 10
        '
        'tpgDatos
        '
        Me.tpgDatos.Controls.Add(Me.chbRemoto)
        Me.tpgDatos.Controls.Add(Me.Label6)
        Me.tpgDatos.Controls.Add(Me.picUserHe)
        Me.tpgDatos.Controls.Add(Me.chkHabilitado)
        Me.tpgDatos.Controls.Add(Me.picUserShe)
        Me.tpgDatos.Controls.Add(Me.txtNombre)
        Me.tpgDatos.Controls.Add(Me.txtUsuario)
        Me.tpgDatos.Controls.Add(Me.Label4)
        Me.tpgDatos.Controls.Add(Me.Label3)
        Me.tpgDatos.Controls.Add(Me.Label1)
        Me.tpgDatos.Location = New System.Drawing.Point(4, 23)
        Me.tpgDatos.Name = "tpgDatos"
        Me.tpgDatos.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgDatos.Size = New System.Drawing.Size(334, 151)
        Me.tpgDatos.TabIndex = 0
        Me.tpgDatos.Text = "Datos"
        Me.tpgDatos.UseVisualStyleBackColor = True
        '
        'chbRemoto
        '
        Me.chbRemoto.AutoSize = True
        Me.chbRemoto.Location = New System.Drawing.Point(198, 42)
        Me.chbRemoto.Name = "chbRemoto"
        Me.chbRemoto.Size = New System.Drawing.Size(15, 14)
        Me.chbRemoto.TabIndex = 16
        Me.chbRemoto.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label6.Location = New System.Drawing.Point(121, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 22)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Remoto:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'picUserHe
        '
        Me.picUserHe.Image = CType(resources.GetObject("picUserHe.Image"), System.Drawing.Image)
        Me.picUserHe.Location = New System.Drawing.Point(249, 12)
        Me.picUserHe.Name = "picUserHe"
        Me.picUserHe.Size = New System.Drawing.Size(32, 35)
        Me.picUserHe.TabIndex = 8
        Me.picUserHe.TabStop = False
        Me.picUserHe.Visible = False
        '
        'chkHabilitado
        '
        Me.chkHabilitado.AutoSize = True
        Me.chkHabilitado.Location = New System.Drawing.Point(86, 42)
        Me.chkHabilitado.Name = "chkHabilitado"
        Me.chkHabilitado.Size = New System.Drawing.Size(15, 14)
        Me.chkHabilitado.TabIndex = 13
        Me.chkHabilitado.UseVisualStyleBackColor = True
        '
        'picUserShe
        '
        Me.picUserShe.Image = CType(resources.GetObject("picUserShe.Image"), System.Drawing.Image)
        Me.picUserShe.Location = New System.Drawing.Point(249, 12)
        Me.picUserShe.Name = "picUserShe"
        Me.picUserShe.Size = New System.Drawing.Size(32, 35)
        Me.picUserShe.TabIndex = 9
        Me.picUserShe.TabStop = False
        Me.picUserShe.Visible = False
        '
        'txtNombre
        '
        Me.txtNombre.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(85, 62)
        Me.txtNombre.Multiline = True
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNombre.Size = New System.Drawing.Size(196, 70)
        Me.txtNombre.TabIndex = 14
        '
        'txtUsuario
        '
        Me.txtUsuario.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.Location = New System.Drawing.Point(85, 12)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(128, 22)
        Me.txtUsuario.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label4.Location = New System.Drawing.Point(9, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 22)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Habilitado:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label3.Location = New System.Drawing.Point(9, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 70)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Nombre:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label1.Location = New System.Drawing.Point(9, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 22)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Usuario:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tpgListado
        '
        Me.tpgListado.Controls.Add(Me.dgvUsuarios)
        Me.tpgListado.Location = New System.Drawing.Point(4, 23)
        Me.tpgListado.Name = "tpgListado"
        Me.tpgListado.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgListado.Size = New System.Drawing.Size(334, 151)
        Me.tpgListado.TabIndex = 1
        Me.tpgListado.Text = "Listado"
        Me.tpgListado.UseVisualStyleBackColor = True
        '
        'dgvUsuarios
        '
        Me.dgvUsuarios.AllowUserToAddRows = False
        Me.dgvUsuarios.AllowUserToDeleteRows = False
        Me.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUsuarios.Location = New System.Drawing.Point(1, 4)
        Me.dgvUsuarios.Name = "dgvUsuarios"
        Me.dgvUsuarios.ReadOnly = True
        Me.dgvUsuarios.Size = New System.Drawing.Size(327, 143)
        Me.dgvUsuarios.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbCrear, Me.ToolStripSeparator1, Me.tsbEditar, Me.ToolStripSeparator2, Me.tsbDeshacer, Me.ToolStripSeparator3, Me.tsbGrabar, Me.ToolStripSeparator4, Me.tsbMapSis, Me.tsbVolver, Me.ToolStripSeparator7, Me.tsbReiniciaClave, Me.ToolStripSeparator8, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(371, 53)
        Me.ToolStrip1.TabIndex = 2
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
        'tsbMapSis
        '
        Me.tsbMapSis.Image = CType(resources.GetObject("tsbMapSis.Image"), System.Drawing.Image)
        Me.tsbMapSis.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbMapSis.Name = "tsbMapSis"
        Me.tsbMapSis.Size = New System.Drawing.Size(47, 50)
        Me.tsbMapSis.Text = "MapSis"
        Me.tsbMapSis.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.tsbMapSis.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbMapSis.ToolTipText = "Mapeo de Sistemas"
        '
        'tsbVolver
        '
        Me.tsbVolver.Image = CType(resources.GetObject("tsbVolver.Image"), System.Drawing.Image)
        Me.tsbVolver.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbVolver.Name = "tsbVolver"
        Me.tsbVolver.Size = New System.Drawing.Size(45, 50)
        Me.tsbVolver.Text = "Volver"
        Me.tsbVolver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbVolver.Visible = False
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 53)
        '
        'tsbReiniciaClave
        '
        Me.tsbReiniciaClave.Image = CType(resources.GetObject("tsbReiniciaClave.Image"), System.Drawing.Image)
        Me.tsbReiniciaClave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbReiniciaClave.Name = "tsbReiniciaClave"
        Me.tsbReiniciaClave.Size = New System.Drawing.Size(36, 50)
        Me.tsbReiniciaClave.Text = "R-C"
        Me.tsbReiniciaClave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbReiniciaClave.ToolTipText = "Reinicia Contraseña"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 53)
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkRol)
        Me.GroupBox1.Controls.Add(Me.cbxRol)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.GroupBox1.Location = New System.Drawing.Point(5, 267)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(354, 49)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ROL"
        '
        'chkRol
        '
        Me.chkRol.AutoSize = True
        Me.chkRol.Location = New System.Drawing.Point(9, 22)
        Me.chkRol.Name = "chkRol"
        Me.chkRol.Size = New System.Drawing.Size(15, 14)
        Me.chkRol.TabIndex = 6
        Me.chkRol.UseVisualStyleBackColor = True
        '
        'cbxRol
        '
        Me.cbxRol.BackColor = System.Drawing.Color.White
        Me.cbxRol.Enabled = False
        Me.cbxRol.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxRol.FormattingEnabled = True
        Me.cbxRol.Location = New System.Drawing.Point(29, 17)
        Me.cbxRol.Name = "cbxRol"
        Me.cbxRol.Size = New System.Drawing.Size(309, 24)
        Me.cbxRol.TabIndex = 5
        '
        'gbxMapeo
        '
        Me.gbxMapeo.Controls.Add(Me.btnAsignar)
        Me.gbxMapeo.Controls.Add(Me.Label5)
        Me.gbxMapeo.Controls.Add(Me.Label2)
        Me.gbxMapeo.Controls.Add(Me.cbxSucursal)
        Me.gbxMapeo.Controls.Add(Me.cbxSistemas)
        Me.gbxMapeo.Controls.Add(Me.dgvMapeoSistemas)
        Me.gbxMapeo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxMapeo.ForeColor = System.Drawing.SystemColors.Desktop
        Me.gbxMapeo.Location = New System.Drawing.Point(365, 61)
        Me.gbxMapeo.Name = "gbxMapeo"
        Me.gbxMapeo.Size = New System.Drawing.Size(469, 255)
        Me.gbxMapeo.TabIndex = 5
        Me.gbxMapeo.TabStop = False
        Me.gbxMapeo.Text = "MAPEO DE SISTEMAS Y SUCURSALES"
        Me.gbxMapeo.Visible = False
        '
        'btnAsignar
        '
        Me.btnAsignar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAsignar.Image = CType(resources.GetObject("btnAsignar.Image"), System.Drawing.Image)
        Me.btnAsignar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAsignar.Location = New System.Drawing.Point(349, 19)
        Me.btnAsignar.Name = "btnAsignar"
        Me.btnAsignar.Size = New System.Drawing.Size(56, 56)
        Me.btnAsignar.TabIndex = 10
        Me.btnAsignar.Text = "Asignar"
        Me.btnAsignar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnAsignar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(41, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 14)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Sucursal:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(43, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 14)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Sistema:"
        '
        'cbxSucursal
        '
        Me.cbxSucursal.BackColor = System.Drawing.Color.White
        Me.cbxSucursal.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxSucursal.FormattingEnabled = True
        Me.cbxSucursal.Location = New System.Drawing.Point(96, 49)
        Me.cbxSucursal.Name = "cbxSucursal"
        Me.cbxSucursal.Size = New System.Drawing.Size(247, 24)
        Me.cbxSucursal.TabIndex = 7
        '
        'cbxSistemas
        '
        Me.cbxSistemas.BackColor = System.Drawing.Color.White
        Me.cbxSistemas.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxSistemas.FormattingEnabled = True
        Me.cbxSistemas.Location = New System.Drawing.Point(96, 19)
        Me.cbxSistemas.Name = "cbxSistemas"
        Me.cbxSistemas.Size = New System.Drawing.Size(247, 24)
        Me.cbxSistemas.TabIndex = 6
        '
        'dgvMapeoSistemas
        '
        Me.dgvMapeoSistemas.AllowUserToAddRows = False
        Me.dgvMapeoSistemas.AllowUserToDeleteRows = False
        Me.dgvMapeoSistemas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMapeoSistemas.Location = New System.Drawing.Point(8, 87)
        Me.dgvMapeoSistemas.Name = "dgvMapeoSistemas"
        Me.dgvMapeoSistemas.ReadOnly = True
        Me.dgvMapeoSistemas.Size = New System.Drawing.Size(454, 159)
        Me.dgvMapeoSistemas.TabIndex = 0
        '
        'frmUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Beige
        Me.ClientSize = New System.Drawing.Size(872, 453)
        Me.Controls.Add(Me.gbxMapeo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.gbxUsuario)
        Me.Controls.Add(Me.gbxPersonas)
        Me.MinimumSize = New System.Drawing.Size(880, 487)
        Me.Name = "frmUsuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Usuarios del Sistema"
        Me.gbxPersonas.ResumeLayout(False)
        Me.tsmPaginado.ResumeLayout(False)
        Me.tsmPaginado.PerformLayout()
        CType(Me.dgvPersonas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxUsuario.ResumeLayout(False)
        CType(Me.nudUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabUsuario.ResumeLayout(False)
        Me.tpgDatos.ResumeLayout(False)
        Me.tpgDatos.PerformLayout()
        CType(Me.picUserHe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picUserShe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgListado.ResumeLayout(False)
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbxMapeo.ResumeLayout(False)
        Me.gbxMapeo.PerformLayout()
        CType(Me.dgvMapeoSistemas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbxPersonas As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPersonas As System.Windows.Forms.DataGridView
    Friend WithEvents gbxUsuario As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbCrear As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsmPaginado As System.Windows.Forms.ToolStrip
    Friend WithEvents tsb_Ver As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tslbl_PagX As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tscbx_Paginas As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tslbl_DePag As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tstxt_Buscar As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents picUserHe As System.Windows.Forms.PictureBox
    Friend WithEvents picUserShe As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbxRol As System.Windows.Forms.ComboBox
    Friend WithEvents chkRol As System.Windows.Forms.CheckBox
    Friend WithEvents TabUsuario As System.Windows.Forms.TabControl
    Friend WithEvents tpgDatos As System.Windows.Forms.TabPage
    Friend WithEvents chkHabilitado As System.Windows.Forms.CheckBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tpgListado As System.Windows.Forms.TabPage
    Friend WithEvents dgvUsuarios As System.Windows.Forms.DataGridView
    Friend WithEvents tsbMapSis As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents gbxMapeo As System.Windows.Forms.GroupBox
    Friend WithEvents dgvMapeoSistemas As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbxSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents cbxSistemas As System.Windows.Forms.ComboBox
    Friend WithEvents btnAsignar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tsbVolver As System.Windows.Forms.ToolStripButton
    Friend WithEvents nudUsuarios As System.Windows.Forms.NumericUpDown
    Friend WithEvents tsbReiniciaClave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chbRemoto As System.Windows.Forms.CheckBox
   
End Class
