<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOtrosAccesos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOtrosAccesos))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblRol = New System.Windows.Forms.Label
        Me.cbxUsuario = New System.Windows.Forms.ComboBox
        Me.lblPersona = New System.Windows.Forms.Label
        Me.tabOtrosAccesos = New System.Windows.Forms.TabControl
        Me.tpgAlmacenes = New System.Windows.Forms.TabPage
        Me.scAlmacenes = New System.Windows.Forms.SplitContainer
        Me.btnAsignarCCosto = New System.Windows.Forms.Button
        Me.chlbAlmacenes = New System.Windows.Forms.CheckedListBox
        Me.btnActualizar = New System.Windows.Forms.Button
        Me.ucCtrlCCostos = New ModuloCentral.ucCentroCostos
        Me.BtnGuardar = New System.Windows.Forms.Button
        Me.BtnCancelar = New System.Windows.Forms.Button
        Me.lblAlmacen = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.tpgCajas = New System.Windows.Forms.TabPage
        Me.btnActualizarC = New System.Windows.Forms.Button
        Me.chlbCajas = New System.Windows.Forms.CheckedListBox
        Me.tpgSubAlm = New System.Windows.Forms.TabPage
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.tvwPermisos = New System.Windows.Forms.TreeView
        Me.btnActSubAlm = New System.Windows.Forms.Button
        Me.tvw_SMO = New System.Windows.Forms.TreeView
        Me.tpgEmpCajas = New System.Windows.Forms.TabPage
        Me.btnActEmpCaja = New System.Windows.Forms.Button
        Me.chlbEmpCajas = New System.Windows.Forms.CheckedListBox
        Me.tpgEmpCompras = New System.Windows.Forms.TabPage
        Me.btnActEmpComp = New System.Windows.Forms.Button
        Me.chlbEmpCompra = New System.Windows.Forms.CheckedListBox
        Me.tpgSeriesGRT = New System.Windows.Forms.TabPage
        Me.BtnActualizarSeriesGRT = New System.Windows.Forms.Button
        Me.chkSeriesGRT = New System.Windows.Forms.CheckedListBox
        Me.tpgAsistOpEstablec = New System.Windows.Forms.TabPage
        Me.SplitContainer5 = New System.Windows.Forms.SplitContainer
        Me.SplitContainer6 = New System.Windows.Forms.SplitContainer
        Me.btnActualizaAOE = New System.Windows.Forms.Button
        Me.tv_AOE_Acceso = New System.Windows.Forms.TreeView
        Me.dgvAsistResumPlla = New System.Windows.Forms.DataGridView
        Me.btnAsistResumPlla = New System.Windows.Forms.Button
        Me.tv_AOE_Lista = New System.Windows.Forms.TreeView
        Me.tpgCtaBco = New System.Windows.Forms.TabPage
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.tv_CBA = New System.Windows.Forms.TreeView
        Me.btnActualizaCtaBco = New System.Windows.Forms.Button
        Me.tv_CBD = New System.Windows.Forms.TreeView
        Me.tpgEmpCtble = New System.Windows.Forms.TabPage
        Me.btnActEmpCtble = New System.Windows.Forms.Button
        Me.chlbEmpCtble = New System.Windows.Forms.CheckedListBox
        Me.tpgGRTSeries = New System.Windows.Forms.TabPage
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
        Me.tv_GRTS_Permisos = New System.Windows.Forms.TreeView
        Me.btnActualizaGRTSeries = New System.Windows.Forms.Button
        Me.tv_GRTS_Opciones = New System.Windows.Forms.TreeView
        Me.tpgVentaSeries = New System.Windows.Forms.TabPage
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer
        Me.tv_VtaS_Permisos = New System.Windows.Forms.TreeView
        Me.btnAtualizarVtaSeries = New System.Windows.Forms.Button
        Me.tv_VtaS_Opciones = New System.Windows.Forms.TreeView
        Me.tpgVentaGrupoOS = New System.Windows.Forms.TabPage
        Me.btnActualizaVOSG = New System.Windows.Forms.Button
        Me.chlbVOSG = New System.Windows.Forms.CheckedListBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1.SuspendLayout()
        Me.tabOtrosAccesos.SuspendLayout()
        Me.tpgAlmacenes.SuspendLayout()
        Me.scAlmacenes.Panel1.SuspendLayout()
        Me.scAlmacenes.Panel2.SuspendLayout()
        Me.scAlmacenes.SuspendLayout()
        Me.tpgCajas.SuspendLayout()
        Me.tpgSubAlm.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.tpgEmpCajas.SuspendLayout()
        Me.tpgEmpCompras.SuspendLayout()
        Me.tpgSeriesGRT.SuspendLayout()
        Me.tpgAsistOpEstablec.SuspendLayout()
        Me.SplitContainer5.Panel1.SuspendLayout()
        Me.SplitContainer5.Panel2.SuspendLayout()
        Me.SplitContainer5.SuspendLayout()
        Me.SplitContainer6.Panel1.SuspendLayout()
        Me.SplitContainer6.Panel2.SuspendLayout()
        Me.SplitContainer6.SuspendLayout()
        CType(Me.dgvAsistResumPlla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgCtaBco.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.tpgEmpCtble.SuspendLayout()
        Me.tpgGRTSeries.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.tpgVentaSeries.SuspendLayout()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        Me.tpgVentaGrupoOS.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblRol)
        Me.GroupBox1.Controls.Add(Me.cbxUsuario)
        Me.GroupBox1.Controls.Add(Me.lblPersona)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(4, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(564, 46)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "USUARIO"
        '
        'lblRol
        '
        Me.lblRol.AutoSize = True
        Me.lblRol.BackColor = System.Drawing.Color.DarkKhaki
        Me.lblRol.ForeColor = System.Drawing.Color.Beige
        Me.lblRol.Location = New System.Drawing.Point(163, 0)
        Me.lblRol.Name = "lblRol"
        Me.lblRol.Size = New System.Drawing.Size(42, 14)
        Me.lblRol.TabIndex = 4
        Me.lblRol.Text = "Label1"
        '
        'cbxUsuario
        '
        Me.cbxUsuario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbxUsuario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbxUsuario.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxUsuario.FormattingEnabled = True
        Me.cbxUsuario.Location = New System.Drawing.Point(6, 19)
        Me.cbxUsuario.Name = "cbxUsuario"
        Me.cbxUsuario.Size = New System.Drawing.Size(151, 22)
        Me.cbxUsuario.TabIndex = 1
        '
        'lblPersona
        '
        Me.lblPersona.AutoSize = True
        Me.lblPersona.Location = New System.Drawing.Point(163, 22)
        Me.lblPersona.Name = "lblPersona"
        Me.lblPersona.Size = New System.Drawing.Size(42, 14)
        Me.lblPersona.TabIndex = 3
        Me.lblPersona.Text = "Label2"
        '
        'tabOtrosAccesos
        '
        Me.tabOtrosAccesos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabOtrosAccesos.Controls.Add(Me.tpgAlmacenes)
        Me.tabOtrosAccesos.Controls.Add(Me.tpgCajas)
        Me.tabOtrosAccesos.Controls.Add(Me.tpgSubAlm)
        Me.tabOtrosAccesos.Controls.Add(Me.tpgEmpCajas)
        Me.tabOtrosAccesos.Controls.Add(Me.tpgEmpCompras)
        Me.tabOtrosAccesos.Controls.Add(Me.tpgSeriesGRT)
        Me.tabOtrosAccesos.Controls.Add(Me.tpgAsistOpEstablec)
        Me.tabOtrosAccesos.Controls.Add(Me.tpgCtaBco)
        Me.tabOtrosAccesos.Controls.Add(Me.tpgEmpCtble)
        Me.tabOtrosAccesos.Controls.Add(Me.tpgGRTSeries)
        Me.tabOtrosAccesos.Controls.Add(Me.tpgVentaSeries)
        Me.tabOtrosAccesos.Controls.Add(Me.tpgVentaGrupoOS)
        Me.tabOtrosAccesos.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabOtrosAccesos.HotTrack = True
        Me.tabOtrosAccesos.Location = New System.Drawing.Point(4, 55)
        Me.tabOtrosAccesos.Multiline = True
        Me.tabOtrosAccesos.Name = "tabOtrosAccesos"
        Me.tabOtrosAccesos.SelectedIndex = 0
        Me.tabOtrosAccesos.Size = New System.Drawing.Size(1062, 530)
        Me.tabOtrosAccesos.TabIndex = 7
        '
        'tpgAlmacenes
        '
        Me.tpgAlmacenes.Controls.Add(Me.scAlmacenes)
        Me.tpgAlmacenes.Location = New System.Drawing.Point(4, 23)
        Me.tpgAlmacenes.Name = "tpgAlmacenes"
        Me.tpgAlmacenes.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgAlmacenes.Size = New System.Drawing.Size(1054, 503)
        Me.tpgAlmacenes.TabIndex = 0
        Me.tpgAlmacenes.Text = "Almacenes"
        Me.tpgAlmacenes.UseVisualStyleBackColor = True
        '
        'scAlmacenes
        '
        Me.scAlmacenes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scAlmacenes.Location = New System.Drawing.Point(3, 3)
        Me.scAlmacenes.Name = "scAlmacenes"
        '
        'scAlmacenes.Panel1
        '
        Me.scAlmacenes.Panel1.Controls.Add(Me.btnAsignarCCosto)
        Me.scAlmacenes.Panel1.Controls.Add(Me.chlbAlmacenes)
        Me.scAlmacenes.Panel1.Controls.Add(Me.btnActualizar)
        '
        'scAlmacenes.Panel2
        '
        Me.scAlmacenes.Panel2.Controls.Add(Me.ucCtrlCCostos)
        Me.scAlmacenes.Panel2.Controls.Add(Me.BtnGuardar)
        Me.scAlmacenes.Panel2.Controls.Add(Me.BtnCancelar)
        Me.scAlmacenes.Panel2.Controls.Add(Me.lblAlmacen)
        Me.scAlmacenes.Panel2.Controls.Add(Me.Label10)
        Me.scAlmacenes.Size = New System.Drawing.Size(1048, 497)
        Me.scAlmacenes.SplitterDistance = 436
        Me.scAlmacenes.TabIndex = 5
        '
        'btnAsignarCCosto
        '
        Me.btnAsignarCCosto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAsignarCCosto.Image = CType(resources.GetObject("btnAsignarCCosto.Image"), System.Drawing.Image)
        Me.btnAsignarCCosto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAsignarCCosto.Location = New System.Drawing.Point(315, 8)
        Me.btnAsignarCCosto.Name = "btnAsignarCCosto"
        Me.btnAsignarCCosto.Size = New System.Drawing.Size(115, 23)
        Me.btnAsignarCCosto.TabIndex = 4
        Me.btnAsignarCCosto.Text = "Asignar CCosto"
        Me.btnAsignarCCosto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAsignarCCosto.UseVisualStyleBackColor = True
        '
        'chlbAlmacenes
        '
        Me.chlbAlmacenes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chlbAlmacenes.CheckOnClick = True
        Me.chlbAlmacenes.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chlbAlmacenes.FormattingEnabled = True
        Me.chlbAlmacenes.Location = New System.Drawing.Point(5, 42)
        Me.chlbAlmacenes.Name = "chlbAlmacenes"
        Me.chlbAlmacenes.Size = New System.Drawing.Size(425, 378)
        Me.chlbAlmacenes.TabIndex = 0
        '
        'btnActualizar
        '
        Me.btnActualizar.BackColor = System.Drawing.Color.LightGray
        Me.btnActualizar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizar.Image = CType(resources.GetObject("btnActualizar.Image"), System.Drawing.Image)
        Me.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActualizar.Location = New System.Drawing.Point(4, 3)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(99, 33)
        Me.btnActualizar.TabIndex = 3
        Me.btnActualizar.Text = "&Actualizar"
        Me.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnActualizar.UseVisualStyleBackColor = False
        '
        'ucCtrlCCostos
        '
        Me.ucCtrlCCostos.BackColor = System.Drawing.Color.Transparent
        Me.ucCtrlCCostos.Chofer = ""
        Me.ucCtrlCCostos.CodCCostoN1V1 = ""
        Me.ucCtrlCCostos.CodCCostoN2V1 = ""
        Me.ucCtrlCCostos.CodCCostoN3V1 = ""
        Me.ucCtrlCCostos.CodCCostoN4V1 = ""
        Me.ucCtrlCCostos.IDCCostoN1V1 = -1
        Me.ucCtrlCCostos.IDCCostoN2V1 = -1
        Me.ucCtrlCCostos.IDCCostoN3V1 = -1
        Me.ucCtrlCCostos.IDCCostoN4V1 = -1
        Me.ucCtrlCCostos.IDChofer = -1
        Me.ucCtrlCCostos.Location = New System.Drawing.Point(0, 76)
        Me.ucCtrlCCostos.Name = "ucCtrlCCostos"
        Me.ucCtrlCCostos.Size = New System.Drawing.Size(509, 122)
        Me.ucCtrlCCostos.TabIndex = 46
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardar.Location = New System.Drawing.Point(144, 212)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(93, 23)
        Me.BtnGuardar.TabIndex = 44
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCancelar.Location = New System.Drawing.Point(243, 212)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(91, 23)
        Me.BtnCancelar.TabIndex = 45
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'lblAlmacen
        '
        Me.lblAlmacen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAlmacen.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblAlmacen.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblAlmacen.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.lblAlmacen.Location = New System.Drawing.Point(0, 0)
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Size = New System.Drawing.Size(608, 22)
        Me.lblAlmacen.TabIndex = 43
        Me.lblAlmacen.Text = "ALMACEN"
        Me.lblAlmacen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Label10.Location = New System.Drawing.Point(3, 52)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(111, 16)
        Me.Label10.TabIndex = 42
        Me.Label10.Text = "Centro de Costos:"
        '
        'tpgCajas
        '
        Me.tpgCajas.Controls.Add(Me.btnActualizarC)
        Me.tpgCajas.Controls.Add(Me.chlbCajas)
        Me.tpgCajas.Location = New System.Drawing.Point(4, 23)
        Me.tpgCajas.Name = "tpgCajas"
        Me.tpgCajas.Size = New System.Drawing.Size(1054, 503)
        Me.tpgCajas.TabIndex = 2
        Me.tpgCajas.Text = "Cajas"
        Me.tpgCajas.UseVisualStyleBackColor = True
        '
        'btnActualizarC
        '
        Me.btnActualizarC.BackColor = System.Drawing.Color.LightGray
        Me.btnActualizarC.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizarC.Image = CType(resources.GetObject("btnActualizarC.Image"), System.Drawing.Image)
        Me.btnActualizarC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActualizarC.Location = New System.Drawing.Point(3, 4)
        Me.btnActualizarC.Name = "btnActualizarC"
        Me.btnActualizarC.Size = New System.Drawing.Size(99, 33)
        Me.btnActualizarC.TabIndex = 5
        Me.btnActualizarC.Text = "&Actualizar"
        Me.btnActualizarC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnActualizarC.UseVisualStyleBackColor = False
        '
        'chlbCajas
        '
        Me.chlbCajas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chlbCajas.CheckOnClick = True
        Me.chlbCajas.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chlbCajas.FormattingEnabled = True
        Me.chlbCajas.Location = New System.Drawing.Point(7, 43)
        Me.chlbCajas.Name = "chlbCajas"
        Me.chlbCajas.Size = New System.Drawing.Size(423, 293)
        Me.chlbCajas.TabIndex = 4
        '
        'tpgSubAlm
        '
        Me.tpgSubAlm.Controls.Add(Me.SplitContainer1)
        Me.tpgSubAlm.Location = New System.Drawing.Point(4, 23)
        Me.tpgSubAlm.Name = "tpgSubAlm"
        Me.tpgSubAlm.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgSubAlm.Size = New System.Drawing.Size(1054, 503)
        Me.tpgSubAlm.TabIndex = 3
        Me.tpgSubAlm.Text = "SubAlmacenes"
        Me.tpgSubAlm.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tvwPermisos)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnActSubAlm)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.tvw_SMO)
        Me.SplitContainer1.Size = New System.Drawing.Size(1048, 497)
        Me.SplitContainer1.SplitterDistance = 523
        Me.SplitContainer1.TabIndex = 57
        '
        'tvwPermisos
        '
        Me.tvwPermisos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvwPermisos.BackColor = System.Drawing.Color.White
        Me.tvwPermisos.Location = New System.Drawing.Point(3, 42)
        Me.tvwPermisos.Name = "tvwPermisos"
        Me.tvwPermisos.Size = New System.Drawing.Size(517, 452)
        Me.tvwPermisos.TabIndex = 56
        '
        'btnActSubAlm
        '
        Me.btnActSubAlm.BackColor = System.Drawing.Color.LightGray
        Me.btnActSubAlm.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActSubAlm.Image = CType(resources.GetObject("btnActSubAlm.Image"), System.Drawing.Image)
        Me.btnActSubAlm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActSubAlm.Location = New System.Drawing.Point(3, 3)
        Me.btnActSubAlm.Name = "btnActSubAlm"
        Me.btnActSubAlm.Size = New System.Drawing.Size(99, 33)
        Me.btnActSubAlm.TabIndex = 54
        Me.btnActSubAlm.Text = "&Actualizar"
        Me.btnActSubAlm.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnActSubAlm.UseVisualStyleBackColor = False
        '
        'tvw_SMO
        '
        Me.tvw_SMO.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tvw_SMO.CheckBoxes = True
        Me.tvw_SMO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvw_SMO.Location = New System.Drawing.Point(0, 0)
        Me.tvw_SMO.Name = "tvw_SMO"
        Me.tvw_SMO.Size = New System.Drawing.Size(521, 497)
        Me.tvw_SMO.TabIndex = 55
        '
        'tpgEmpCajas
        '
        Me.tpgEmpCajas.Controls.Add(Me.btnActEmpCaja)
        Me.tpgEmpCajas.Controls.Add(Me.chlbEmpCajas)
        Me.tpgEmpCajas.Location = New System.Drawing.Point(4, 23)
        Me.tpgEmpCajas.Name = "tpgEmpCajas"
        Me.tpgEmpCajas.Size = New System.Drawing.Size(1054, 503)
        Me.tpgEmpCajas.TabIndex = 4
        Me.tpgEmpCajas.Text = "EmpresaCajas"
        Me.tpgEmpCajas.UseVisualStyleBackColor = True
        '
        'btnActEmpCaja
        '
        Me.btnActEmpCaja.BackColor = System.Drawing.Color.LightGray
        Me.btnActEmpCaja.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActEmpCaja.Image = CType(resources.GetObject("btnActEmpCaja.Image"), System.Drawing.Image)
        Me.btnActEmpCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActEmpCaja.Location = New System.Drawing.Point(4, 4)
        Me.btnActEmpCaja.Name = "btnActEmpCaja"
        Me.btnActEmpCaja.Size = New System.Drawing.Size(99, 33)
        Me.btnActEmpCaja.TabIndex = 7
        Me.btnActEmpCaja.Text = "&Actualizar"
        Me.btnActEmpCaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnActEmpCaja.UseVisualStyleBackColor = False
        '
        'chlbEmpCajas
        '
        Me.chlbEmpCajas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chlbEmpCajas.CheckOnClick = True
        Me.chlbEmpCajas.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chlbEmpCajas.FormattingEnabled = True
        Me.chlbEmpCajas.Location = New System.Drawing.Point(5, 41)
        Me.chlbEmpCajas.Name = "chlbEmpCajas"
        Me.chlbEmpCajas.Size = New System.Drawing.Size(418, 293)
        Me.chlbEmpCajas.TabIndex = 6
        '
        'tpgEmpCompras
        '
        Me.tpgEmpCompras.Controls.Add(Me.btnActEmpComp)
        Me.tpgEmpCompras.Controls.Add(Me.chlbEmpCompra)
        Me.tpgEmpCompras.Location = New System.Drawing.Point(4, 23)
        Me.tpgEmpCompras.Name = "tpgEmpCompras"
        Me.tpgEmpCompras.Size = New System.Drawing.Size(1054, 503)
        Me.tpgEmpCompras.TabIndex = 5
        Me.tpgEmpCompras.Text = "EmpresaCompra"
        Me.tpgEmpCompras.UseVisualStyleBackColor = True
        '
        'btnActEmpComp
        '
        Me.btnActEmpComp.BackColor = System.Drawing.Color.LightGray
        Me.btnActEmpComp.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActEmpComp.Image = CType(resources.GetObject("btnActEmpComp.Image"), System.Drawing.Image)
        Me.btnActEmpComp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActEmpComp.Location = New System.Drawing.Point(6, 5)
        Me.btnActEmpComp.Name = "btnActEmpComp"
        Me.btnActEmpComp.Size = New System.Drawing.Size(99, 33)
        Me.btnActEmpComp.TabIndex = 9
        Me.btnActEmpComp.Text = "&Actualizar"
        Me.btnActEmpComp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnActEmpComp.UseVisualStyleBackColor = False
        '
        'chlbEmpCompra
        '
        Me.chlbEmpCompra.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chlbEmpCompra.CheckOnClick = True
        Me.chlbEmpCompra.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chlbEmpCompra.FormattingEnabled = True
        Me.chlbEmpCompra.Location = New System.Drawing.Point(6, 41)
        Me.chlbEmpCompra.Name = "chlbEmpCompra"
        Me.chlbEmpCompra.Size = New System.Drawing.Size(417, 293)
        Me.chlbEmpCompra.TabIndex = 8
        '
        'tpgSeriesGRT
        '
        Me.tpgSeriesGRT.Controls.Add(Me.BtnActualizarSeriesGRT)
        Me.tpgSeriesGRT.Controls.Add(Me.chkSeriesGRT)
        Me.tpgSeriesGRT.Location = New System.Drawing.Point(4, 23)
        Me.tpgSeriesGRT.Name = "tpgSeriesGRT"
        Me.tpgSeriesGRT.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgSeriesGRT.Size = New System.Drawing.Size(1054, 503)
        Me.tpgSeriesGRT.TabIndex = 6
        Me.tpgSeriesGRT.Text = "Barrick GRT"
        Me.tpgSeriesGRT.UseVisualStyleBackColor = True
        '
        'BtnActualizarSeriesGRT
        '
        Me.BtnActualizarSeriesGRT.BackColor = System.Drawing.Color.LightGray
        Me.BtnActualizarSeriesGRT.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnActualizarSeriesGRT.Image = CType(resources.GetObject("BtnActualizarSeriesGRT.Image"), System.Drawing.Image)
        Me.BtnActualizarSeriesGRT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnActualizarSeriesGRT.Location = New System.Drawing.Point(6, 5)
        Me.BtnActualizarSeriesGRT.Name = "BtnActualizarSeriesGRT"
        Me.BtnActualizarSeriesGRT.Size = New System.Drawing.Size(99, 33)
        Me.BtnActualizarSeriesGRT.TabIndex = 11
        Me.BtnActualizarSeriesGRT.Text = "&Actualizar"
        Me.BtnActualizarSeriesGRT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnActualizarSeriesGRT.UseVisualStyleBackColor = False
        '
        'chkSeriesGRT
        '
        Me.chkSeriesGRT.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkSeriesGRT.CheckOnClick = True
        Me.chkSeriesGRT.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSeriesGRT.FormattingEnabled = True
        Me.chkSeriesGRT.Location = New System.Drawing.Point(6, 41)
        Me.chkSeriesGRT.Name = "chkSeriesGRT"
        Me.chkSeriesGRT.Size = New System.Drawing.Size(417, 293)
        Me.chkSeriesGRT.TabIndex = 10
        '
        'tpgAsistOpEstablec
        '
        Me.tpgAsistOpEstablec.Controls.Add(Me.SplitContainer5)
        Me.tpgAsistOpEstablec.Location = New System.Drawing.Point(4, 23)
        Me.tpgAsistOpEstablec.Name = "tpgAsistOpEstablec"
        Me.tpgAsistOpEstablec.Size = New System.Drawing.Size(1054, 503)
        Me.tpgAsistOpEstablec.TabIndex = 13
        Me.tpgAsistOpEstablec.Text = "Asistencia OP x Establec"
        Me.tpgAsistOpEstablec.UseVisualStyleBackColor = True
        '
        'SplitContainer5
        '
        Me.SplitContainer5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer5.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer5.Name = "SplitContainer5"
        '
        'SplitContainer5.Panel1
        '
        Me.SplitContainer5.Panel1.Controls.Add(Me.SplitContainer6)
        '
        'SplitContainer5.Panel2
        '
        Me.SplitContainer5.Panel2.Controls.Add(Me.tv_AOE_Lista)
        Me.SplitContainer5.Size = New System.Drawing.Size(1054, 503)
        Me.SplitContainer5.SplitterDistance = 524
        Me.SplitContainer5.TabIndex = 15
        '
        'SplitContainer6
        '
        Me.SplitContainer6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer6.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer6.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer6.Name = "SplitContainer6"
        Me.SplitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer6.Panel1
        '
        Me.SplitContainer6.Panel1.Controls.Add(Me.btnActualizaAOE)
        Me.SplitContainer6.Panel1.Controls.Add(Me.tv_AOE_Acceso)
        '
        'SplitContainer6.Panel2
        '
        Me.SplitContainer6.Panel2.Controls.Add(Me.dgvAsistResumPlla)
        Me.SplitContainer6.Panel2.Controls.Add(Me.btnAsistResumPlla)
        Me.SplitContainer6.Size = New System.Drawing.Size(524, 503)
        Me.SplitContainer6.SplitterDistance = 322
        Me.SplitContainer6.TabIndex = 58
        '
        'btnActualizaAOE
        '
        Me.btnActualizaAOE.BackColor = System.Drawing.Color.LightGray
        Me.btnActualizaAOE.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizaAOE.Image = CType(resources.GetObject("btnActualizaAOE.Image"), System.Drawing.Image)
        Me.btnActualizaAOE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActualizaAOE.Location = New System.Drawing.Point(3, 3)
        Me.btnActualizaAOE.Name = "btnActualizaAOE"
        Me.btnActualizaAOE.Size = New System.Drawing.Size(99, 33)
        Me.btnActualizaAOE.TabIndex = 12
        Me.btnActualizaAOE.Text = "&Actualizar"
        Me.btnActualizaAOE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnActualizaAOE.UseVisualStyleBackColor = False
        '
        'tv_AOE_Acceso
        '
        Me.tv_AOE_Acceso.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tv_AOE_Acceso.BackColor = System.Drawing.Color.White
        Me.tv_AOE_Acceso.Location = New System.Drawing.Point(3, 37)
        Me.tv_AOE_Acceso.Name = "tv_AOE_Acceso"
        Me.tv_AOE_Acceso.Size = New System.Drawing.Size(518, 281)
        Me.tv_AOE_Acceso.TabIndex = 57
        '
        'dgvAsistResumPlla
        '
        Me.dgvAsistResumPlla.AllowUserToAddRows = False
        Me.dgvAsistResumPlla.AllowUserToDeleteRows = False
        Me.dgvAsistResumPlla.AllowUserToResizeRows = False
        Me.dgvAsistResumPlla.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAsistResumPlla.BackgroundColor = System.Drawing.Color.Beige
        Me.dgvAsistResumPlla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAsistResumPlla.Location = New System.Drawing.Point(3, 38)
        Me.dgvAsistResumPlla.Name = "dgvAsistResumPlla"
        Me.dgvAsistResumPlla.ReadOnly = True
        Me.dgvAsistResumPlla.RowHeadersVisible = False
        Me.dgvAsistResumPlla.Size = New System.Drawing.Size(518, 134)
        Me.dgvAsistResumPlla.TabIndex = 59
        '
        'btnAsistResumPlla
        '
        Me.btnAsistResumPlla.BackColor = System.Drawing.Color.LightGray
        Me.btnAsistResumPlla.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAsistResumPlla.Image = CType(resources.GetObject("btnAsistResumPlla.Image"), System.Drawing.Image)
        Me.btnAsistResumPlla.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAsistResumPlla.Location = New System.Drawing.Point(3, 4)
        Me.btnAsistResumPlla.Name = "btnAsistResumPlla"
        Me.btnAsistResumPlla.Size = New System.Drawing.Size(99, 33)
        Me.btnAsistResumPlla.TabIndex = 58
        Me.btnAsistResumPlla.Text = "&Actualizar"
        Me.btnAsistResumPlla.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAsistResumPlla.UseVisualStyleBackColor = False
        '
        'tv_AOE_Lista
        '
        Me.tv_AOE_Lista.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tv_AOE_Lista.CheckBoxes = True
        Me.tv_AOE_Lista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tv_AOE_Lista.Location = New System.Drawing.Point(0, 0)
        Me.tv_AOE_Lista.Name = "tv_AOE_Lista"
        Me.tv_AOE_Lista.Size = New System.Drawing.Size(526, 503)
        Me.tv_AOE_Lista.TabIndex = 56
        '
        'tpgCtaBco
        '
        Me.tpgCtaBco.Controls.Add(Me.SplitContainer2)
        Me.tpgCtaBco.Location = New System.Drawing.Point(4, 23)
        Me.tpgCtaBco.Name = "tpgCtaBco"
        Me.tpgCtaBco.Size = New System.Drawing.Size(1054, 503)
        Me.tpgCtaBco.TabIndex = 8
        Me.tpgCtaBco.Text = "Ctas. x Bancos"
        Me.tpgCtaBco.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.tv_CBA)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btnActualizaCtaBco)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.tv_CBD)
        Me.SplitContainer2.Size = New System.Drawing.Size(1054, 503)
        Me.SplitContainer2.SplitterDistance = 524
        Me.SplitContainer2.TabIndex = 14
        '
        'tv_CBA
        '
        Me.tv_CBA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tv_CBA.BackColor = System.Drawing.Color.White
        Me.tv_CBA.Location = New System.Drawing.Point(-4, 42)
        Me.tv_CBA.Name = "tv_CBA"
        Me.tv_CBA.Size = New System.Drawing.Size(525, 461)
        Me.tv_CBA.TabIndex = 57
        '
        'btnActualizaCtaBco
        '
        Me.btnActualizaCtaBco.BackColor = System.Drawing.Color.LightGray
        Me.btnActualizaCtaBco.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizaCtaBco.Image = CType(resources.GetObject("btnActualizaCtaBco.Image"), System.Drawing.Image)
        Me.btnActualizaCtaBco.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActualizaCtaBco.Location = New System.Drawing.Point(3, 3)
        Me.btnActualizaCtaBco.Name = "btnActualizaCtaBco"
        Me.btnActualizaCtaBco.Size = New System.Drawing.Size(99, 33)
        Me.btnActualizaCtaBco.TabIndex = 12
        Me.btnActualizaCtaBco.Text = "&Actualizar"
        Me.btnActualizaCtaBco.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnActualizaCtaBco.UseVisualStyleBackColor = False
        '
        'tv_CBD
        '
        Me.tv_CBD.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tv_CBD.CheckBoxes = True
        Me.tv_CBD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tv_CBD.Location = New System.Drawing.Point(0, 0)
        Me.tv_CBD.Name = "tv_CBD"
        Me.tv_CBD.Size = New System.Drawing.Size(526, 503)
        Me.tv_CBD.TabIndex = 56
        '
        'tpgEmpCtble
        '
        Me.tpgEmpCtble.Controls.Add(Me.btnActEmpCtble)
        Me.tpgEmpCtble.Controls.Add(Me.chlbEmpCtble)
        Me.tpgEmpCtble.Location = New System.Drawing.Point(4, 23)
        Me.tpgEmpCtble.Name = "tpgEmpCtble"
        Me.tpgEmpCtble.Size = New System.Drawing.Size(1054, 503)
        Me.tpgEmpCtble.TabIndex = 9
        Me.tpgEmpCtble.Text = "EmpresaCtble"
        Me.tpgEmpCtble.UseVisualStyleBackColor = True
        '
        'btnActEmpCtble
        '
        Me.btnActEmpCtble.BackColor = System.Drawing.Color.LightGray
        Me.btnActEmpCtble.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActEmpCtble.Image = CType(resources.GetObject("btnActEmpCtble.Image"), System.Drawing.Image)
        Me.btnActEmpCtble.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActEmpCtble.Location = New System.Drawing.Point(4, 3)
        Me.btnActEmpCtble.Name = "btnActEmpCtble"
        Me.btnActEmpCtble.Size = New System.Drawing.Size(99, 33)
        Me.btnActEmpCtble.TabIndex = 9
        Me.btnActEmpCtble.Text = "&Actualizar"
        Me.btnActEmpCtble.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnActEmpCtble.UseVisualStyleBackColor = False
        '
        'chlbEmpCtble
        '
        Me.chlbEmpCtble.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chlbEmpCtble.CheckOnClick = True
        Me.chlbEmpCtble.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chlbEmpCtble.FormattingEnabled = True
        Me.chlbEmpCtble.Location = New System.Drawing.Point(5, 40)
        Me.chlbEmpCtble.Name = "chlbEmpCtble"
        Me.chlbEmpCtble.Size = New System.Drawing.Size(418, 276)
        Me.chlbEmpCtble.TabIndex = 8
        '
        'tpgGRTSeries
        '
        Me.tpgGRTSeries.Controls.Add(Me.SplitContainer3)
        Me.tpgGRTSeries.Location = New System.Drawing.Point(4, 23)
        Me.tpgGRTSeries.Name = "tpgGRTSeries"
        Me.tpgGRTSeries.Size = New System.Drawing.Size(1054, 503)
        Me.tpgGRTSeries.TabIndex = 10
        Me.tpgGRTSeries.Text = "GRT Series"
        Me.tpgGRTSeries.UseVisualStyleBackColor = True
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.tv_GRTS_Permisos)
        Me.SplitContainer3.Panel1.Controls.Add(Me.btnActualizaGRTSeries)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.tv_GRTS_Opciones)
        Me.SplitContainer3.Size = New System.Drawing.Size(1054, 503)
        Me.SplitContainer3.SplitterDistance = 524
        Me.SplitContainer3.TabIndex = 15
        '
        'tv_GRTS_Permisos
        '
        Me.tv_GRTS_Permisos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tv_GRTS_Permisos.BackColor = System.Drawing.Color.White
        Me.tv_GRTS_Permisos.Location = New System.Drawing.Point(-4, 42)
        Me.tv_GRTS_Permisos.Name = "tv_GRTS_Permisos"
        Me.tv_GRTS_Permisos.Size = New System.Drawing.Size(525, 461)
        Me.tv_GRTS_Permisos.TabIndex = 57
        '
        'btnActualizaGRTSeries
        '
        Me.btnActualizaGRTSeries.BackColor = System.Drawing.Color.LightGray
        Me.btnActualizaGRTSeries.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizaGRTSeries.Image = CType(resources.GetObject("btnActualizaGRTSeries.Image"), System.Drawing.Image)
        Me.btnActualizaGRTSeries.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActualizaGRTSeries.Location = New System.Drawing.Point(3, 3)
        Me.btnActualizaGRTSeries.Name = "btnActualizaGRTSeries"
        Me.btnActualizaGRTSeries.Size = New System.Drawing.Size(99, 33)
        Me.btnActualizaGRTSeries.TabIndex = 12
        Me.btnActualizaGRTSeries.Text = "&Actualizar"
        Me.btnActualizaGRTSeries.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnActualizaGRTSeries.UseVisualStyleBackColor = False
        '
        'tv_GRTS_Opciones
        '
        Me.tv_GRTS_Opciones.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tv_GRTS_Opciones.CheckBoxes = True
        Me.tv_GRTS_Opciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tv_GRTS_Opciones.Location = New System.Drawing.Point(0, 0)
        Me.tv_GRTS_Opciones.Name = "tv_GRTS_Opciones"
        Me.tv_GRTS_Opciones.Size = New System.Drawing.Size(526, 503)
        Me.tv_GRTS_Opciones.TabIndex = 56
        '
        'tpgVentaSeries
        '
        Me.tpgVentaSeries.Controls.Add(Me.SplitContainer4)
        Me.tpgVentaSeries.Location = New System.Drawing.Point(4, 23)
        Me.tpgVentaSeries.Name = "tpgVentaSeries"
        Me.tpgVentaSeries.Size = New System.Drawing.Size(1054, 503)
        Me.tpgVentaSeries.TabIndex = 11
        Me.tpgVentaSeries.Text = "Venta Series"
        Me.tpgVentaSeries.UseVisualStyleBackColor = True
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer4.Name = "SplitContainer4"
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.tv_VtaS_Permisos)
        Me.SplitContainer4.Panel1.Controls.Add(Me.btnAtualizarVtaSeries)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.tv_VtaS_Opciones)
        Me.SplitContainer4.Size = New System.Drawing.Size(1054, 503)
        Me.SplitContainer4.SplitterDistance = 524
        Me.SplitContainer4.TabIndex = 15
        '
        'tv_VtaS_Permisos
        '
        Me.tv_VtaS_Permisos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tv_VtaS_Permisos.BackColor = System.Drawing.Color.White
        Me.tv_VtaS_Permisos.Location = New System.Drawing.Point(-4, 42)
        Me.tv_VtaS_Permisos.Name = "tv_VtaS_Permisos"
        Me.tv_VtaS_Permisos.Size = New System.Drawing.Size(525, 461)
        Me.tv_VtaS_Permisos.TabIndex = 57
        '
        'btnAtualizarVtaSeries
        '
        Me.btnAtualizarVtaSeries.BackColor = System.Drawing.Color.LightGray
        Me.btnAtualizarVtaSeries.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAtualizarVtaSeries.Image = CType(resources.GetObject("btnAtualizarVtaSeries.Image"), System.Drawing.Image)
        Me.btnAtualizarVtaSeries.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAtualizarVtaSeries.Location = New System.Drawing.Point(3, 3)
        Me.btnAtualizarVtaSeries.Name = "btnAtualizarVtaSeries"
        Me.btnAtualizarVtaSeries.Size = New System.Drawing.Size(99, 33)
        Me.btnAtualizarVtaSeries.TabIndex = 12
        Me.btnAtualizarVtaSeries.Text = "&Actualizar"
        Me.btnAtualizarVtaSeries.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAtualizarVtaSeries.UseVisualStyleBackColor = False
        '
        'tv_VtaS_Opciones
        '
        Me.tv_VtaS_Opciones.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tv_VtaS_Opciones.CheckBoxes = True
        Me.tv_VtaS_Opciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tv_VtaS_Opciones.Location = New System.Drawing.Point(0, 0)
        Me.tv_VtaS_Opciones.Name = "tv_VtaS_Opciones"
        Me.tv_VtaS_Opciones.Size = New System.Drawing.Size(526, 503)
        Me.tv_VtaS_Opciones.TabIndex = 56
        '
        'tpgVentaGrupoOS
        '
        Me.tpgVentaGrupoOS.Controls.Add(Me.btnActualizaVOSG)
        Me.tpgVentaGrupoOS.Controls.Add(Me.chlbVOSG)
        Me.tpgVentaGrupoOS.Location = New System.Drawing.Point(4, 23)
        Me.tpgVentaGrupoOS.Name = "tpgVentaGrupoOS"
        Me.tpgVentaGrupoOS.Size = New System.Drawing.Size(1054, 503)
        Me.tpgVentaGrupoOS.TabIndex = 12
        Me.tpgVentaGrupoOS.Text = "Vta.O.S. Grupo"
        Me.tpgVentaGrupoOS.UseVisualStyleBackColor = True
        '
        'btnActualizaVOSG
        '
        Me.btnActualizaVOSG.BackColor = System.Drawing.Color.LightGray
        Me.btnActualizaVOSG.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizaVOSG.Image = CType(resources.GetObject("btnActualizaVOSG.Image"), System.Drawing.Image)
        Me.btnActualizaVOSG.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActualizaVOSG.Location = New System.Drawing.Point(4, 8)
        Me.btnActualizaVOSG.Name = "btnActualizaVOSG"
        Me.btnActualizaVOSG.Size = New System.Drawing.Size(99, 33)
        Me.btnActualizaVOSG.TabIndex = 13
        Me.btnActualizaVOSG.Text = "&Actualizar"
        Me.btnActualizaVOSG.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnActualizaVOSG.UseVisualStyleBackColor = False
        '
        'chlbVOSG
        '
        Me.chlbVOSG.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chlbVOSG.CheckOnClick = True
        Me.chlbVOSG.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chlbVOSG.FormattingEnabled = True
        Me.chlbVOSG.Location = New System.Drawing.Point(4, 44)
        Me.chlbVOSG.Name = "chlbVOSG"
        Me.chlbVOSG.Size = New System.Drawing.Size(417, 259)
        Me.chlbVOSG.TabIndex = 12
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(577, -1)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(48, 53)
        Me.ToolStrip1.TabIndex = 9
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'frmOtrosAccesos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Beige
        Me.ClientSize = New System.Drawing.Size(1071, 588)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tabOtrosAccesos)
        Me.Name = "frmOtrosAccesos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OtrosAccesos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tabOtrosAccesos.ResumeLayout(False)
        Me.tpgAlmacenes.ResumeLayout(False)
        Me.scAlmacenes.Panel1.ResumeLayout(False)
        Me.scAlmacenes.Panel2.ResumeLayout(False)
        Me.scAlmacenes.Panel2.PerformLayout()
        Me.scAlmacenes.ResumeLayout(False)
        Me.tpgCajas.ResumeLayout(False)
        Me.tpgSubAlm.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.tpgEmpCajas.ResumeLayout(False)
        Me.tpgEmpCompras.ResumeLayout(False)
        Me.tpgSeriesGRT.ResumeLayout(False)
        Me.tpgAsistOpEstablec.ResumeLayout(False)
        Me.SplitContainer5.Panel1.ResumeLayout(False)
        Me.SplitContainer5.Panel2.ResumeLayout(False)
        Me.SplitContainer5.ResumeLayout(False)
        Me.SplitContainer6.Panel1.ResumeLayout(False)
        Me.SplitContainer6.Panel2.ResumeLayout(False)
        Me.SplitContainer6.ResumeLayout(False)
        CType(Me.dgvAsistResumPlla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgCtaBco.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.tpgEmpCtble.ResumeLayout(False)
        Me.tpgGRTSeries.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        Me.tpgVentaSeries.ResumeLayout(False)
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        Me.SplitContainer4.ResumeLayout(False)
        Me.tpgVentaGrupoOS.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRol As System.Windows.Forms.Label
    Friend WithEvents cbxUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents lblPersona As System.Windows.Forms.Label
    Friend WithEvents tabOtrosAccesos As System.Windows.Forms.TabControl
    Friend WithEvents tpgAlmacenes As System.Windows.Forms.TabPage
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tpgCajas As System.Windows.Forms.TabPage
    Friend WithEvents btnActualizarC As System.Windows.Forms.Button
    Friend WithEvents chlbCajas As System.Windows.Forms.CheckedListBox
    Friend WithEvents tpgSubAlm As System.Windows.Forms.TabPage
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents chlbAlmacenes As System.Windows.Forms.CheckedListBox
    Friend WithEvents scAlmacenes As System.Windows.Forms.SplitContainer
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblAlmacen As System.Windows.Forms.Label
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAsignarCCosto As System.Windows.Forms.Button
    Friend WithEvents ucCtrlCCostos As ModuloCentral.ucCentroCostos
    Friend WithEvents tpgEmpCajas As System.Windows.Forms.TabPage
    Friend WithEvents tpgEmpCompras As System.Windows.Forms.TabPage
    Friend WithEvents btnActEmpCaja As System.Windows.Forms.Button
    Friend WithEvents chlbEmpCajas As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnActEmpComp As System.Windows.Forms.Button
    Friend WithEvents chlbEmpCompra As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnActSubAlm As System.Windows.Forms.Button
    Friend WithEvents tvw_SMO As System.Windows.Forms.TreeView
    Friend WithEvents tvwPermisos As System.Windows.Forms.TreeView
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents tpgSeriesGRT As System.Windows.Forms.TabPage
    Friend WithEvents BtnActualizarSeriesGRT As System.Windows.Forms.Button
    Friend WithEvents chkSeriesGRT As System.Windows.Forms.CheckedListBox
    Friend WithEvents tpgCtaBco As System.Windows.Forms.TabPage
    Friend WithEvents btnActualizaCtaBco As System.Windows.Forms.Button
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents tv_CBD As System.Windows.Forms.TreeView
    Friend WithEvents tv_CBA As System.Windows.Forms.TreeView
    Friend WithEvents tpgEmpCtble As System.Windows.Forms.TabPage
    Friend WithEvents btnActEmpCtble As System.Windows.Forms.Button
    Friend WithEvents chlbEmpCtble As System.Windows.Forms.CheckedListBox
    Friend WithEvents tpgGRTSeries As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents tv_GRTS_Permisos As System.Windows.Forms.TreeView
    Friend WithEvents btnActualizaGRTSeries As System.Windows.Forms.Button
    Friend WithEvents tv_GRTS_Opciones As System.Windows.Forms.TreeView
    Friend WithEvents tpgVentaSeries As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer4 As System.Windows.Forms.SplitContainer
    Friend WithEvents tv_VtaS_Permisos As System.Windows.Forms.TreeView
    Friend WithEvents btnAtualizarVtaSeries As System.Windows.Forms.Button
    Friend WithEvents tv_VtaS_Opciones As System.Windows.Forms.TreeView
    Friend WithEvents tpgVentaGrupoOS As System.Windows.Forms.TabPage
    Friend WithEvents btnActualizaVOSG As System.Windows.Forms.Button
    Friend WithEvents chlbVOSG As System.Windows.Forms.CheckedListBox
    Friend WithEvents tpgAsistOpEstablec As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer5 As System.Windows.Forms.SplitContainer
    Friend WithEvents tv_AOE_Acceso As System.Windows.Forms.TreeView
    Friend WithEvents btnActualizaAOE As System.Windows.Forms.Button
    Friend WithEvents tv_AOE_Lista As System.Windows.Forms.TreeView
    Friend WithEvents SplitContainer6 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvAsistResumPlla As System.Windows.Forms.DataGridView
    Friend WithEvents btnAsistResumPlla As System.Windows.Forms.Button
End Class
