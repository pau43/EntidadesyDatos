<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSistemas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSistemas))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbCrear = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbDeshacer = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbRecargar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgvSistemas = New System.Windows.Forms.DataGridView
        Me.chkActivo = New System.Windows.Forms.CheckBox
        Me.txtConexionRemota = New System.Windows.Forms.TextBox
        Me.txtCadenaConexion = New System.Windows.Forms.TextBox
        Me.txtDescripcion = New System.Windows.Forms.TextBox
        Me.txtIDSistema = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.gbxTipoConexion = New System.Windows.Forms.GroupBox
        Me.pic_Remoto = New System.Windows.Forms.PictureBox
        Me.pic_Local = New System.Windows.Forms.PictureBox
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.tsb_Crear = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.tsb_Editar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.tsb_Deshacer = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.tsb_Grabar = New System.Windows.Forms.ToolStripButton
        Me.dgv_TipoConexion = New System.Windows.Forms.DataGridView
        Me.rbtn_Remoto = New System.Windows.Forms.RadioButton
        Me.rbtn_Local = New System.Windows.Forms.RadioButton
        Me.txt_Password = New System.Windows.Forms.TextBox
        Me.txt_UserId = New System.Windows.Forms.TextBox
        Me.cbx_Sucursal = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblSistema = New System.Windows.Forms.Label
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvSistemas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxTipoConexion.SuspendLayout()
        CType(Me.pic_Remoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_Local, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.dgv_TipoConexion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbCrear, Me.ToolStripSeparator1, Me.tsbEditar, Me.ToolStripSeparator2, Me.tsbDeshacer, Me.ToolStripSeparator3, Me.tsbGrabar, Me.ToolStripSeparator4, Me.tsbRecargar, Me.ToolStripSeparator5, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(824, 53)
        Me.ToolStrip1.TabIndex = 0
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
        'tsbRecargar
        '
        Me.tsbRecargar.Image = CType(resources.GetObject("tsbRecargar.Image"), System.Drawing.Image)
        Me.tsbRecargar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRecargar.Name = "tsbRecargar"
        Me.tsbRecargar.Size = New System.Drawing.Size(59, 50)
        Me.tsbRecargar.Text = "&ReCargar"
        Me.tsbRecargar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 53)
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
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgvSistemas)
        Me.GroupBox1.Controls.Add(Me.chkActivo)
        Me.GroupBox1.Controls.Add(Me.txtConexionRemota)
        Me.GroupBox1.Controls.Add(Me.txtCadenaConexion)
        Me.GroupBox1.Controls.Add(Me.txtDescripcion)
        Me.GroupBox1.Controls.Add(Me.txtIDSistema)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GroupBox1.Location = New System.Drawing.Point(3, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(470, 396)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SISTEMAS"
        '
        'dgvSistemas
        '
        Me.dgvSistemas.AllowUserToAddRows = False
        Me.dgvSistemas.AllowUserToDeleteRows = False
        Me.dgvSistemas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSistemas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSistemas.Location = New System.Drawing.Point(6, 228)
        Me.dgvSistemas.MultiSelect = False
        Me.dgvSistemas.Name = "dgvSistemas"
        Me.dgvSistemas.ReadOnly = True
        Me.dgvSistemas.Size = New System.Drawing.Size(458, 163)
        Me.dgvSistemas.TabIndex = 6
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.Enabled = False
        Me.chkActivo.Location = New System.Drawing.Point(135, 203)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(15, 14)
        Me.chkActivo.TabIndex = 5
        Me.chkActivo.UseVisualStyleBackColor = True
        '
        'txtConexionRemota
        '
        Me.txtConexionRemota.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtConexionRemota.Enabled = False
        Me.txtConexionRemota.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConexionRemota.Location = New System.Drawing.Point(132, 135)
        Me.txtConexionRemota.Multiline = True
        Me.txtConexionRemota.Name = "txtConexionRemota"
        Me.txtConexionRemota.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtConexionRemota.Size = New System.Drawing.Size(332, 61)
        Me.txtConexionRemota.TabIndex = 4
        '
        'txtCadenaConexion
        '
        Me.txtCadenaConexion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCadenaConexion.Enabled = False
        Me.txtCadenaConexion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCadenaConexion.Location = New System.Drawing.Point(132, 71)
        Me.txtCadenaConexion.Multiline = True
        Me.txtCadenaConexion.Name = "txtCadenaConexion"
        Me.txtCadenaConexion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCadenaConexion.Size = New System.Drawing.Size(332, 61)
        Me.txtCadenaConexion.TabIndex = 3
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Enabled = False
        Me.txtDescripcion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(132, 46)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(312, 22)
        Me.txtDescripcion.TabIndex = 2
        '
        'txtIDSistema
        '
        Me.txtIDSistema.Enabled = False
        Me.txtIDSistema.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIDSistema.Location = New System.Drawing.Point(132, 21)
        Me.txtIDSistema.Name = "txtIDSistema"
        Me.txtIDSistema.Size = New System.Drawing.Size(100, 22)
        Me.txtIDSistema.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(6, 199)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 22)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Activo:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(6, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 61)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Conexión Remota:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(6, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 61)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Conexión Local:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(6, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 22)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Descripción:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(6, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbxTipoConexion
        '
        Me.gbxTipoConexion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbxTipoConexion.Controls.Add(Me.pic_Remoto)
        Me.gbxTipoConexion.Controls.Add(Me.pic_Local)
        Me.gbxTipoConexion.Controls.Add(Me.ToolStrip2)
        Me.gbxTipoConexion.Controls.Add(Me.dgv_TipoConexion)
        Me.gbxTipoConexion.Controls.Add(Me.rbtn_Remoto)
        Me.gbxTipoConexion.Controls.Add(Me.rbtn_Local)
        Me.gbxTipoConexion.Controls.Add(Me.txt_Password)
        Me.gbxTipoConexion.Controls.Add(Me.txt_UserId)
        Me.gbxTipoConexion.Controls.Add(Me.cbx_Sucursal)
        Me.gbxTipoConexion.Controls.Add(Me.Label10)
        Me.gbxTipoConexion.Controls.Add(Me.Label9)
        Me.gbxTipoConexion.Controls.Add(Me.Label8)
        Me.gbxTipoConexion.Controls.Add(Me.Label7)
        Me.gbxTipoConexion.Controls.Add(Me.lblSistema)
        Me.gbxTipoConexion.Location = New System.Drawing.Point(7, 12)
        Me.gbxTipoConexion.Name = "gbxTipoConexion"
        Me.gbxTipoConexion.Size = New System.Drawing.Size(334, 389)
        Me.gbxTipoConexion.TabIndex = 2
        Me.gbxTipoConexion.TabStop = False
        '
        'pic_Remoto
        '
        Me.pic_Remoto.Image = CType(resources.GetObject("pic_Remoto.Image"), System.Drawing.Image)
        Me.pic_Remoto.Location = New System.Drawing.Point(144, 139)
        Me.pic_Remoto.Name = "pic_Remoto"
        Me.pic_Remoto.Size = New System.Drawing.Size(34, 32)
        Me.pic_Remoto.TabIndex = 13
        Me.pic_Remoto.TabStop = False
        Me.pic_Remoto.Visible = False
        '
        'pic_Local
        '
        Me.pic_Local.BackColor = System.Drawing.SystemColors.Control
        Me.pic_Local.Image = CType(resources.GetObject("pic_Local.Image"), System.Drawing.Image)
        Me.pic_Local.Location = New System.Drawing.Point(142, 139)
        Me.pic_Local.Name = "pic_Local"
        Me.pic_Local.Size = New System.Drawing.Size(36, 34)
        Me.pic_Local.TabIndex = 12
        Me.pic_Local.TabStop = False
        Me.pic_Local.Visible = False
        '
        'ToolStrip2
        '
        Me.ToolStrip2.AutoSize = False
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsb_Crear, Me.ToolStripSeparator6, Me.tsb_Editar, Me.ToolStripSeparator7, Me.tsb_Deshacer, Me.ToolStripSeparator8, Me.tsb_Grabar})
        Me.ToolStrip2.Location = New System.Drawing.Point(5, 24)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(304, 25)
        Me.ToolStrip2.TabIndex = 11
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'tsb_Crear
        '
        Me.tsb_Crear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsb_Crear.Image = CType(resources.GetObject("tsb_Crear.Image"), System.Drawing.Image)
        Me.tsb_Crear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_Crear.Name = "tsb_Crear"
        Me.tsb_Crear.Size = New System.Drawing.Size(46, 22)
        Me.tsb_Crear.Text = "&Nuevo"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'tsb_Editar
        '
        Me.tsb_Editar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsb_Editar.Image = CType(resources.GetObject("tsb_Editar.Image"), System.Drawing.Image)
        Me.tsb_Editar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_Editar.Name = "tsb_Editar"
        Me.tsb_Editar.Size = New System.Drawing.Size(38, 22)
        Me.tsb_Editar.Text = "&Edita"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'tsb_Deshacer
        '
        Me.tsb_Deshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsb_Deshacer.Enabled = False
        Me.tsb_Deshacer.Image = CType(resources.GetObject("tsb_Deshacer.Image"), System.Drawing.Image)
        Me.tsb_Deshacer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_Deshacer.Name = "tsb_Deshacer"
        Me.tsb_Deshacer.Size = New System.Drawing.Size(52, 22)
        Me.tsb_Deshacer.Text = "C&ancela"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'tsb_Grabar
        '
        Me.tsb_Grabar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsb_Grabar.Enabled = False
        Me.tsb_Grabar.Image = CType(resources.GetObject("tsb_Grabar.Image"), System.Drawing.Image)
        Me.tsb_Grabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_Grabar.Name = "tsb_Grabar"
        Me.tsb_Grabar.Size = New System.Drawing.Size(53, 22)
        Me.tsb_Grabar.Text = "G&uardar"
        '
        'dgv_TipoConexion
        '
        Me.dgv_TipoConexion.AllowUserToAddRows = False
        Me.dgv_TipoConexion.AllowUserToDeleteRows = False
        Me.dgv_TipoConexion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_TipoConexion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_TipoConexion.Location = New System.Drawing.Point(7, 184)
        Me.dgv_TipoConexion.Name = "dgv_TipoConexion"
        Me.dgv_TipoConexion.ReadOnly = True
        Me.dgv_TipoConexion.Size = New System.Drawing.Size(321, 200)
        Me.dgv_TipoConexion.TabIndex = 10
        '
        'rbtn_Remoto
        '
        Me.rbtn_Remoto.AutoSize = True
        Me.rbtn_Remoto.Enabled = False
        Me.rbtn_Remoto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtn_Remoto.Location = New System.Drawing.Point(66, 153)
        Me.rbtn_Remoto.Name = "rbtn_Remoto"
        Me.rbtn_Remoto.Size = New System.Drawing.Size(68, 18)
        Me.rbtn_Remoto.TabIndex = 9
        Me.rbtn_Remoto.TabStop = True
        Me.rbtn_Remoto.Text = "Remoto"
        Me.rbtn_Remoto.UseVisualStyleBackColor = True
        '
        'rbtn_Local
        '
        Me.rbtn_Local.AutoSize = True
        Me.rbtn_Local.Enabled = False
        Me.rbtn_Local.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtn_Local.Location = New System.Drawing.Point(66, 135)
        Me.rbtn_Local.Name = "rbtn_Local"
        Me.rbtn_Local.Size = New System.Drawing.Size(52, 18)
        Me.rbtn_Local.TabIndex = 8
        Me.rbtn_Local.TabStop = True
        Me.rbtn_Local.Text = "Local"
        Me.rbtn_Local.UseVisualStyleBackColor = True
        '
        'txt_Password
        '
        Me.txt_Password.Enabled = False
        Me.txt_Password.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Password.Location = New System.Drawing.Point(66, 109)
        Me.txt_Password.Name = "txt_Password"
        Me.txt_Password.Size = New System.Drawing.Size(182, 22)
        Me.txt_Password.TabIndex = 7
        '
        'txt_UserId
        '
        Me.txt_UserId.Enabled = False
        Me.txt_UserId.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_UserId.Location = New System.Drawing.Point(66, 85)
        Me.txt_UserId.Name = "txt_UserId"
        Me.txt_UserId.Size = New System.Drawing.Size(182, 22)
        Me.txt_UserId.TabIndex = 6
        '
        'cbx_Sucursal
        '
        Me.cbx_Sucursal.Enabled = False
        Me.cbx_Sucursal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbx_Sucursal.FormattingEnabled = True
        Me.cbx_Sucursal.Location = New System.Drawing.Point(66, 61)
        Me.cbx_Sucursal.Name = "cbx_Sucursal"
        Me.cbx_Sucursal.Size = New System.Drawing.Size(243, 22)
        Me.cbx_Sucursal.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 136)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 14)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Conexión:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 14)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Password:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(17, 89)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 14)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "User ID:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 14)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Sucursal:"
        '
        'lblSistema
        '
        Me.lblSistema.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.lblSistema.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSistema.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblSistema.Location = New System.Drawing.Point(6, 1)
        Me.lblSistema.Name = "lblSistema"
        Me.lblSistema.Size = New System.Drawing.Size(303, 23)
        Me.lblSistema.TabIndex = 0
        Me.lblSistema.Text = "Label6"
        Me.lblSistema.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 53)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.gbxTipoConexion)
        Me.SplitContainer1.Size = New System.Drawing.Size(824, 404)
        Me.SplitContainer1.SplitterDistance = 476
        Me.SplitContainer1.TabIndex = 3
        '
        'frmSistemas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Beige
        Me.ClientSize = New System.Drawing.Size(824, 457)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.MinimumSize = New System.Drawing.Size(840, 495)
        Me.Name = "frmSistemas"
        Me.Text = "Sistemas"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvSistemas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxTipoConexion.ResumeLayout(False)
        Me.gbxTipoConexion.PerformLayout()
        CType(Me.pic_Remoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_Local, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.dgv_TipoConexion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents txtConexionRemota As System.Windows.Forms.TextBox
    Friend WithEvents txtCadenaConexion As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtIDSistema As System.Windows.Forms.TextBox
    Friend WithEvents dgvSistemas As System.Windows.Forms.DataGridView
    Friend WithEvents tsbRecargar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents gbxTipoConexion As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblSistema As System.Windows.Forms.Label
    Friend WithEvents txt_Password As System.Windows.Forms.TextBox
    Friend WithEvents txt_UserId As System.Windows.Forms.TextBox
    Friend WithEvents cbx_Sucursal As System.Windows.Forms.ComboBox
    Friend WithEvents rbtn_Remoto As System.Windows.Forms.RadioButton
    Friend WithEvents rbtn_Local As System.Windows.Forms.RadioButton
    Friend WithEvents dgv_TipoConexion As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsb_Crear As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsb_Editar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsb_Deshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsb_Grabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents pic_Remoto As System.Windows.Forms.PictureBox
    Friend WithEvents pic_Local As System.Windows.Forms.PictureBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
End Class
