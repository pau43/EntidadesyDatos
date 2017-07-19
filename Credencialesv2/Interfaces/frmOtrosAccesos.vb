Imports System.Windows.Forms
Imports GEACEntidades

Public Class frmOtrosAccesos
    Dim dtUsuarios As DataTable
    Dim dtUsuario_OA As DataTable
    Dim dtAlmacenes As DataTable
    Dim dtSeriesGRT As DataTable
    Dim dtSeriesGRTCheck As DataTable
    Dim dtAlmacenCheck As DataTable
    Dim dtEmpresas As DataTable
    Dim dtEmpCajaCheck As DataTable
    Dim dtEmpCompraCheck As DataTable
    Dim dtCajas As DataTable
    Dim dtCajaCheck As DataTable
    Dim dtSubAlmXEmp As DataTable
    Dim dtOpAsistencia As DataTable
    Dim dtEmpCtble As DataTable

    Private oWFUsuario As New WFUsuario
    Private _dtAlmacenes As DataTable = Nothing
    Private dtSubAlmacenes As DataTable

    Dim wEditar As Boolean
    Dim wUsuario As String
    Dim wModuloPadre As String

    Dim w_CodEmp As String
    Dim w_CodAlm As String
    Dim w_CodSubAlm As String
    Dim w_Nodo As String




    Dim dtPermisoCtaBco As DataTable
    Dim dtPermisoCtaBcoNuevos As DataTable
    Dim dtCtaBco As DataTable
    Dim w_CodEmpBco As String
    Dim w_IdBanco As Integer
    Dim w_NroCta As Integer

    '-- Operaciones de Asistencia --
    Dim dtPermisoAOE As DataTable
    Dim dtPermisoAOENuevos As DataTable
    Dim w_CodEmpAOE As String
    Dim w_IdEstablecAOE As Integer
    Dim w_IdOperacAOE As Integer
    '-- fin AOE --

    Dim dtOpcionesNodos As DataTable
    Dim wTn_Empresa As TreeNode
    Dim wTn_Almacen As TreeNode
    Dim wTn_SubAlmacen As TreeNode
    Dim wTn_Nodo As TreeNode

    Dim wTn_EmpBco As TreeNode
    Dim wTn_Banco As TreeNode
    Dim wTn_BcoCta As TreeNode

    Dim wTn_EmpAOE As TreeNode
    Dim wTn_EstablecAOE As TreeNode
    Dim wTn_OperacAOE As TreeNode

    Dim dtPermisosNuevos As DataTable
    Dim dtPermisos As DataTable

    

    Dim aEmpresa() As String
    Dim aAlmacen() As String
    Dim aSubAlm() As String
    Dim aRW() As String

    Dim aEmpresaBco() As String
    Dim aEmpresaAOE() As String
    'Dim aBanco() As Integer
    Dim aCuenta() As Integer

    Dim wColorActivado As Drawing.Color
    Dim wColorDesactivado As Drawing.Color

    Dim w_EmpFound As String
    Dim w_AlmFound As String
    Dim w_SubFound As String
    Dim w_RWFound As String

    Dim w_BcoFound As Integer
    Dim w_NCtaFound As Integer

    Private Sub frmOtrosAccesos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        wModuloPadre = Me.Tag
        wColorActivado = Drawing.Color.Blue
        wColorDesactivado = Drawing.Color.Olive

        '.. carga todos los Almacenes
        dtAlmacenes = oWFUsuario.udfVerAlmacenes
        
        If Not dtAlmacenes Is Nothing Then
            If dtAlmacenes.Rows.Count > 0 Then
                With chlbAlmacenes
                    .DataSource = dtAlmacenes
                    .DisplayMember = dtAlmacenes.Columns("Almacen").ColumnName
                    .ValueMember = dtAlmacenes.Columns("CodAlmacen").ColumnName
                End With
            Else
                MsgBox("No se encontrarón 'Almacenes' registrados." & vbCrLf & "Agregue registros antes de comenzar a trabajar..." & vbCrLf, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            End If
        Else
            MsgBox("se produjo un error en la capa Datos...", MsgBoxStyle.Critical)
        End If

        '.. Cargar Empresa
        dtEmpresas = oWFUsuario.udfVerEmpresas
        If Not dtEmpresas Is Nothing Then
            If dtEmpresas.Rows.Count > 0 Then
                'Para liquidacion Cajas
                With chlbEmpCajas
                    .DataSource = dtEmpresas
                    .DisplayMember = dtEmpresas.Columns("Empresa").ColumnName
                    .ValueMember = dtEmpresas.Columns("CodEmpresa").ColumnName
                End With
                'Para Fact. Compra
                With chlbEmpCompra
                    .DataSource = dtEmpresas
                    .DisplayMember = dtEmpresas.Columns("Empresa").ColumnName
                    .ValueMember = dtEmpresas.Columns("CodEmpresa").ColumnName
                End With
                'Para Empresas de Contabilidad
                With chlbEmpCtble
                    .DataSource = dtEmpresas
                    .DisplayMember = dtEmpresas.Columns("Empresa").ColumnName
                    .ValueMember = dtEmpresas.Columns("CodEmpresa").ColumnName
                End With
            Else : MsgBox("No se encontraron 'Empresas'." & vbCrLf & "Agregue registros antes de comenzar a trabajar..." & vbCrLf, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            End If
        Else : MsgBox("se produjo un error...", MsgBoxStyle.Critical)
        End If


        '.. Carga todas las Cajas
        dtCajas = oWFUsuario.udfVerCajas
        If Not dtCajas Is Nothing Then
            If dtCajas.Rows.Count > 0 Then
                With chlbCajas
                    .DataSource = dtCajas
                    .DisplayMember = dtCajas.Columns("Caja").ColumnName
                    .ValueMember = dtCajas.Columns("CodCaja").ColumnName
                End With
            Else
                MsgBox("No se encontrarón 'Cajas' registrados." & vbCrLf & "Agregue registros antes de comenzar a trabajar..." & vbCrLf, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)

            End If
        Else
            MsgBox("se produjo un error en la capa Datos...", MsgBoxStyle.Critical)
        End If

        '.. Carga todas las Series GRT-Barrick
        dtSeriesGRT = oWFUsuario.udfVerSeriesGRT
        If Not dtSeriesGRT Is Nothing Then
            If dtSeriesGRT.Rows.Count > 0 Then
                With chkSeriesGRT
                    .DataSource = dtSeriesGRT
                    .DisplayMember = dtSeriesGRT.Columns("Descripcion").ColumnName
                    .ValueMember = dtSeriesGRT.Columns("IDSerieGRT").ColumnName
                End With
            Else
                MsgBox("No se encontrarón 'Series GRT' registrados." & vbCrLf & "Agregue registros antes de comenzar a trabajar..." & vbCrLf, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)

            End If
        Else
            MsgBox("se produjo un error en la capa Datos...", MsgBoxStyle.Critical)
        End If

        ''.. Carga todas las Operaciones de Asistencia
        'dtOpAsistencia = oWFUsuario.udfVerOpAsistencia
        'If Not dtOpAsistencia Is Nothing Then
        '    If dtOpAsistencia.Rows.Count > 0 Then
        '        With chlbOpAsistencia
        '            .DataSource = dtOpAsistencia
        '            .DisplayMember = dtOpAsistencia.Columns("Operacion").ColumnName
        '            .ValueMember = dtOpAsistencia.Columns("IdOperacion").ColumnName
        '        End With
        '    Else
        '        MsgBox("No se encontrarón 'Op.Asistencia' registradas." & vbCrLf & "Agregue registros antes de comenzar a trabajar..." & vbCrLf, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
        '    End If
        'Else
        '    MsgBox("se produjo un error en la capa Datos...", MsgBoxStyle.Critical)
        'End If

        'If False Then
        '-- Nueva version de SubAlmacenes por Empresa
        pdu_CargarSubAlmacenes()
        'Else
        '.. (Antigua version) carga todos los Almacenes para Mapeo con SubAlmacen
        '-- _dtAlmacenes = oWFUsuario.udfCargarAlmacenes
        'End If

        '-- Cargar Cuentas Bancarias existentes
        pdu_Cargar_CuentasBancos()

        '-- Cargar Series de GRT del Grupo A.C.t.
        pdu_Cargar_GRTSeries()

        '-- Cargar Series de Ventas
        pdu_Cargar_VtaSeries()

        '-- Cargar Asistencia-Operac-Establec
        pdu_Cargar_AOE()

        '-- Cargar Grupos de OS-Ventas
        Dim xDtGrupo As DataTable
        xDtGrupo = oWFUsuario.fdu_OA_VtaGrupo_Listado
        If Not xDtGrupo Is Nothing Then
            With chlbVOSG
                .DataSource = xDtGrupo
                .DisplayMember = xDtGrupo.Columns("Grupo").ColumnName
                .ValueMember = xDtGrupo.Columns("NroGrupo").ColumnName
            End With
        End If

        udfRecargarDatosUsuario()

        ''.. Carga DGV SubAlmacenes
        'LlenarDGVSubAlmacenes()
        scAlmacenes.Panel2Collapsed = True

    End Sub

    Private Sub pdu_CargarSubAlmacenes()
        dtSubAlmXEmp = oWFUsuario.udf_CS_VerSubAlm_PorEmpresa
        If Not dtSubAlmXEmp Is Nothing AndAlso dtSubAlmXEmp.Rows.Count > 0 Then
            '-- Cargar el TreeView
            udfCargaTreeView(tvw_SMO, dtSubAlmXEmp)
        Else
            MsgBox("No existen Sub Almacenes registrados.")
            'Me.Close()
        End If
    End Sub

    Private Sub udfCargaTreeView(ByVal pTvwOpciones As TreeView, ByVal pDtOpciones As DataTable)
        '-- Limpieza de Nodos anteriores
        pTvwOpciones.Nodes.Clear()
        '-- Validación para carga de datos
        Cursor.Current = Cursors.WaitCursor
        If Not pDtOpciones Is Nothing AndAlso pDtOpciones.Rows.Count > 0 Then
            Dim dtEmp_Alm_SubAlm As DataTable
            Dim xDr() As DataRow

            w_CodEmp = ""
            w_CodAlm = ""
            w_CodSubAlm = ""

            '-- configura TreeView
            With pTvwOpciones
                .BeginUpdate()
                .ShowLines = True
                .ShowPlusMinus = True
                .ShowRootLines = True
                .HideSelection = False
                .HotTracking = False
            End With

            '-- Filtra Empresa, Almacen y Sub Almacen para creacion recursiva de Opciones
            xDr = pDtOpciones.Select("LEN(RW)>0", "CodEmpresa,CodAlmacen,CodSubAlm")
            If xDr.Length > 0 Then
                dtEmp_Alm_SubAlm = xDr.CopyToDataTable

                'dtOpcionesNodos = pDtOpciones.Copy
                '-- En recorrido, segun encuentre va creando los nodos
                For Each xR As DataRow In dtEmp_Alm_SubAlm.Rows ' pDtOpciones.Rows
                    If xR.Item("CodEmpresa") <> w_CodEmp Then
                        w_CodEmp = xR.Item("CodEmpresa")
                        udfCrea_TnEmpresa(pTvwOpciones, w_CodEmp, xR.Item("Empresa"))
                        w_CodAlm = ""
                    End If
                    If w_CodAlm <> xR.Item("CodAlmacen") Then
                        w_CodAlm = xR.Item("CodAlmacen")
                        udfCrea_TnAlmacen(w_CodEmp, w_CodAlm, xR.Item("Almacen"))
                        w_CodSubAlm = ""
                    End If
                    If w_CodSubAlm <> xR.Item("CodSubAlm") Then
                        w_CodSubAlm = xR.Item("CodSubAlm")
                        udfCrea_TnSubAlmacen(w_CodEmp, w_CodAlm, w_CodSubAlm, xR.Item("SubAlmacen"))
                        w_Nodo = ""
                    End If
                    If w_Nodo <> xR.Item("RW") Then
                        w_Nodo = xR.Item("RW")
                        udfCrea_TnNodo(w_CodEmp, w_CodAlm, w_CodSubAlm, xR.Item("RW"))
                    End If
                Next
            End If
            pTvwOpciones.EndUpdate()
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub udfCrea_TnEmpresa(ByRef pTvwOpciones As TreeView, ByVal pCodEmpresa As String, ByVal pEmpresa As String)
        Dim xKey As String
        'Dim xTnSistema As TreeNode
        xKey = pCodEmpresa
        wTn_Empresa = New TreeNode(pEmpresa)
        With wTn_Empresa
            .Tag = xKey
            .ForeColor = Drawing.Color.Navy
            .NodeFont = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold) ', System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End With
        pTvwOpciones.Nodes.Add(wTn_Empresa)
        'pTvwOpciones.ExpandAll()
        'tvw_SMO.Nodes.Item(
    End Sub

    Private Sub udfCrea_TnAlmacen(ByVal pCodEmpresa As String, ByVal pCodAlmacen As String, ByVal pAlmacen As String)
        Dim xKey As String
        xKey = pCodEmpresa & ":" & pCodalmacen
        wTn_Almacen = New TreeNode(pAlmacen)
        With wTn_Almacen
            .Tag = xKey
            .ForeColor = Drawing.Color.Navy
            .NodeFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold) ', System.Drawing.GraphicsUnit.Point, CType(0, Byte))            
        End With
        wTn_Empresa.Nodes.Add(wTn_Almacen)
        wTn_Empresa.Expand()
    End Sub

    Private Sub udfCrea_TnSubAlmacen(ByVal pCodEmpresa As String, ByVal pCodAlmacen As String, ByVal pCodSubAlm As String, ByVal pSubAlmacen As String)
        Dim xKey As String
        xKey = pCodEmpresa & ":" & pCodAlmacen & "-" & pCodSubAlm
        wTn_SubAlmacen = New TreeNode(pSubAlmacen)
        With wTn_SubAlmacen
            .Tag = xKey
            .ForeColor = Drawing.Color.Navy
            .NodeFont = New System.Drawing.Font("Tahoma", 8.75!, System.Drawing.FontStyle.Regular) ', System.Drawing.GraphicsUnit.Point, CType(0, Byte))            
        End With
        wTn_Almacen.Nodes.Add(wTn_SubAlmacen)
        wTn_Almacen.Expand()
    End Sub

    Private Sub udfCrea_TnNodo(ByVal pCodEmpresa As String, ByVal pCodAlmacen As String, ByVal pCodSubAlm As String, ByVal pNodo As String)
        Dim xKey As String
        xKey = pCodEmpresa & ":" & pCodAlmacen & "-" & pCodSubAlm & "/" & pNodo
        wTn_Nodo = New TreeNode(pNodo)
        With wTn_Nodo
            .Tag = xKey
            .ForeColor = Drawing.Color.Navy
            .NodeFont = New System.Drawing.Font("Tahoma", 7.75!, System.Drawing.FontStyle.Regular) ', System.Drawing.GraphicsUnit.Point, CType(0, Byte))            
        End With
        wTn_SubAlmacen.Nodes.Add(wTn_Nodo)
        wTn_SubAlmacen.Expand()
    End Sub

    ' ''Private Sub udfCrea_TnSubAlmacen(ByVal pCodEmpresa As String, ByVal pCodAlmacen As String, ByVal pCodSubAlm As String)
    ' ''    Dim xKey As String
    ' ''    'Dim xNewOpcion As String
    ' ''    Dim dvOpciones As DataView
    ' ''    Dim xAncho As Byte

    ' ''    xAncho = pCodNivel.Length + 1
    ' ''    dvOpciones = New DataView(dtOpcionesNodos)
    ' ''    dvOpciones.RowFilter = "IdSistema=" + wIDSistema.ToString + " AND CodModulo='" + wCodModulo + "' AND CodNivel LIKE '" + pCodNivel + "*' AND LEN(CodNivel)=" + xAncho.ToString

    ' ''    ' Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
    ' ''    For Each dataRowCurrent As DataRowView In dvOpciones
    ' ''        Dim nuevoNodo As New TreeNode
    ' ''        With nuevoNodo
    ' ''            .Text = dataRowCurrent("Opcion").ToString().Trim()
    ' ''            xKey = dataRowCurrent("IdSistema").ToString().Trim() + ":"
    ' ''            xKey += dataRowCurrent("CodModulo").ToString().Trim() + "-"
    ' ''            xKey += dataRowCurrent("CodNivel").ToString().Trim()
    ' ''            .Tag = xKey
    ' ''            .ForeColor = Drawing.Color.Navy
    ' ''            .NodeFont = New System.Drawing.Font("Tahoma", 8.75!, System.Drawing.FontStyle.Regular) ', System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    ' ''        End With
    ' ''        pNodeOp.Nodes.Add(nuevoNodo)
    ' ''        pNodeOp.Expand()
    ' ''        ' Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.
    ' ''        udfCrea_TnOpcion(nuevoNodo, dataRowCurrent("CodNivel").ToString().Trim())
    ' ''    Next dataRowCurrent
    ' ''End Sub



    Private Sub LlenarDGVSubAlmacenes()
        'dtSubAlmacenes = oWFUsuario.udfLlenarDGVSubAlmacenes(cbxUsuario.Text)
        'If Not dtSubAlmacenes Is Nothing AndAlso dtSubAlmacenes.Rows.Count > 0 Then
        '    With dgvSubAlmacenes
        '        .DataSource = dtSubAlmacenes
        '        .Columns("Almacenes").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '        .Columns("CodAlmacen").Visible = False
        '        .Columns("SubAlmacenes").Visible = False
        '    End With
        'Else
        '    dgvSubAlmacenes.DataSource = Nothing
        '    '    MsgBox("No se encontraron SubAlmacenes mapeados a este usuario.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
        'End If
    End Sub

    Private Sub udfRecargarDatosUsuario() 'Optional ByVal pNroRol As Integer = 0)
        ' Carga el Rol y sus Permisos
        dtUsuarios = oWFUsuario.udfVerUsuarios
        If dtUsuarios Is Nothing Then
            MsgBox("No se ha definido Usuario alguno.")
            Me.Close()
        End If
        If dtUsuarios.Rows.Count > 0 Then
            ' carga el ComboBox de Usuarios
            '-- Cargando datos de Sistemas --
            With cbxUsuario
                ' Bloquea carga errada de datos del combo de Roles
                wEditar = True
                .DataSource = dtUsuarios
                .DisplayMember = dtUsuarios.Columns("Usuario").ColumnName
                .ValueMember = dtUsuarios.Columns("Usuario").ColumnName
                .SelectedIndex = -1
                'wPrimeraVez = False
                wEditar = False
                'If pNroRol > 0 Then
                '    .SelectedValue = pNroRol
                '    wUsuario = pNroRol
                'Else
                .SelectedIndex = 0
                '    wUsuario = .SelectedValue
                'End If
                ' carga de Permisos
                'udfCargaCampos(True)
            End With
        Else
            'udfCargaCampos(False)
        End If
    End Sub

    Private Sub udfCargaCampos(ByVal bVal As Boolean)
        '>> Limpia Check de Accesos anteriores
        '   ----------------------------------
        '-- Almacenes en General
        With chlbAlmacenes
            Dim i As Integer
            If .CheckedItems.Count > 0 Then
                For i = 0 To .Items.Count - 1
                    If .GetItemChecked(i) Then
                        .SetItemChecked(i, False)
                    End If
                Next
            End If
            '-- Color de Fondo que indique actualizado
            .BackColor = Drawing.Color.White
        End With

        '-- Cajas de Despacho
        With chlbCajas
            'Dim i As Integer
            If .CheckedItems.Count > 0 Then
                For i = 0 To .Items.Count - 1
                    If .GetItemChecked(i) Then
                        .SetItemChecked(i, False)
                    End If
                Next
            End If
            '-- Color de Fondo que indique actualizado
            .BackColor = Drawing.Color.White
        End With

        '-- Empresas de Cajas de Despacho
        With chlbEmpCajas
            'Dim i As Integer
            If .CheckedItems.Count > 0 Then
                For i = 0 To .Items.Count - 1
                    If .GetItemChecked(i) Then
                        .SetItemChecked(i, False)
                    End If
                Next
            End If
            '-- Color de Fondo que indique actualizado
            .BackColor = Drawing.Color.White
        End With

        '-- Empresas de Compras
        With chlbEmpCompra
            'Dim i As Integer
            If .CheckedItems.Count > 0 Then
                For i = 0 To .Items.Count - 1
                    If .GetItemChecked(i) Then
                        .SetItemChecked(i, False)
                    End If
                Next
            End If
            '-- Color de Fondo que indique actualizado
            .BackColor = Drawing.Color.White
        End With

        ''-- Operaciones de Asistencia
        'With chlbOpAsistencia
        '    'Dim i As Integer
        '    If .CheckedItems.Count > 0 Then
        '        For i = 0 To .Items.Count - 1
        '            If .GetItemChecked(i) Then
        '                .SetItemChecked(i, False)
        '            End If
        '        Next
        '    End If
        '    '-- Color de Fondo que indique actualizado
        '    .BackColor = Drawing.Color.White
        'End With

        '-- Empresas de Contabilidad
        With chlbEmpCtble
            'Dim i As Integer
            If .CheckedItems.Count > 0 Then
                For i = 0 To .Items.Count - 1
                    If .GetItemChecked(i) Then
                        .SetItemChecked(i, False)
                    End If
                Next
            End If
            '-- Color de Fondo que indique actualizado
            .BackColor = Drawing.Color.White
        End With

        '-- Venta: Grupo de Orden Servicio --
        With chlbVOSG
            'Dim i As Integer
            If .CheckedItems.Count > 0 Then
                For i = 0 To .Items.Count - 1
                    If .GetItemChecked(i) Then
                        .SetItemChecked(i, False)
                    End If
                Next
            End If
            '-- Color de Fondo que indique actualizado
            .BackColor = Drawing.Color.White
        End With



        '>> Analiza desde la BD, los "Otros Accesos" del Usuario
        '   -----------------------------------------------------
        If bVal And dtUsuarios.Rows.Count > 0 Then
            Dim wAlmacenUsuario As String = String.Empty

            'txtRol.Text = cbxRol.SelectedValue.ToString
            lblPersona.Text = CType(cbxUsuario.SelectedItem, DataRowView).Item("Persona").ToString
            lblRol.Text = CType(cbxUsuario.SelectedItem, DataRowView).Item("Rol").ToString
            'Carga tabla con "Otros Accesos" del Usuario
            dtUsuario_OA = oWFUsuario.udfVerUsuario_OA(wUsuario)
            If dtUsuario_OA IsNot Nothing AndAlso dtUsuario_OA.Rows.Count > 0 Then
                '--- Obtiene Almacenes (en XML)asignados al usuario
                '    ..............................................
                wAlmacenUsuario = dtUsuario_OA.Rows(0)("xAlmacenes").ToString
                If wAlmacenUsuario.Length > 0 Then
                    'Lee Almacen de usuario para marcarlo ListCheckBox
                    dtAlmacenCheck = oWFUsuario.XMLADataTable(wAlmacenUsuario)

                    Dim dvAlmacen As DataView
                    Dim xCodAlm As String
                    Dim i As Integer = -1
                    dvAlmacen = New DataView(dtAlmacenCheck)

                    With chlbAlmacenes
                        wEditar = True
                        For i = 0 To .Items.Count - 1
                            'xCodAlm = CType(.Items(i), DataRowView).Item("CodAlmacen").ToString
                            xCodAlm = .Items(i).Item("CodAlmacen").ToString
                            dvAlmacen.RowFilter = "Codigo='" + xCodAlm + "'"
                            If dvAlmacen.Count > 0 Then
                                'marcar el almacen con Check
                                .SetItemChecked(i, True)
                                '.Items(i).item.backcolor = Drawing.Color.Aqua
                            End If
                        Next
                        wEditar = False
                    End With
                End If

                '--- Obtiene Cajas (en XML)asignados al usuario
                '    ..............................................
                wAlmacenUsuario = dtUsuario_OA.Rows(0)("xCajas").ToString
                If wAlmacenUsuario.Length > 0 Then
                    'Lee Caja de usuario para marcarlo ListCheckBox
                    dtCajaCheck = oWFUsuario.XMLADataTable(wAlmacenUsuario)

                    Dim dvCaja As DataView
                    Dim xCodCaj As String
                    'Dim i As Integer = -1
                    dvCaja = New DataView(dtCajaCheck)

                    With chlbCajas
                        wEditar = True
                        For i = 0 To .Items.Count - 1

                            xCodCaj = .Items(i).Item("CodCaja").ToString
                            dvCaja.RowFilter = "Codigo='" + xCodCaj + "'"
                            If dvCaja.Count > 0 Then
                                'marcar la caja con Check
                                .SetItemChecked(i, True)
                                '.Items(i).item.backcolor = Drawing.Color.Aqua
                            End If
                        Next
                        wEditar = False
                    End With
                End If

                '--- Obtiene EmpLiqCajas asignados al usuario
                '    ..............................................
                wAlmacenUsuario = String.Empty
                wAlmacenUsuario = dtUsuario_OA.Rows(0)("xEmpLiquidaCajas").ToString
                If wAlmacenUsuario.Length > 0 Then
                    dtEmpCajaCheck = New DataTable
                    'Lee Caja de usuario para marcarlo ListCheckBox
                    dtEmpCajaCheck = oWFUsuario.XMLADataTable(wAlmacenUsuario)

                    Dim dvEmpCaja As DataView
                    Dim xCodEmpCaj As String
                    'Dim i As Integer = -1
                    dvEmpCaja = New DataView(dtEmpCajaCheck)

                    With chlbEmpCajas
                        wEditar = True
                        For i = 0 To .Items.Count - 1

                            xCodEmpCaj = .Items(i).Item("CodEmpresa").ToString
                            dvEmpCaja.RowFilter = "Codigo='" + xCodEmpCaj + "'"
                            If dvEmpCaja.Count > 0 Then
                                'marcar la caja con Check
                                .SetItemChecked(i, True)
                                '.Items(i).item.backcolor = Drawing.Color.Aqua
                            End If
                        Next
                        wEditar = False
                    End With
                End If

                '--- Obtiene EmpFactCompras asignados al usuario
                '    ..............................................
                wAlmacenUsuario = String.Empty
                wAlmacenUsuario = dtUsuario_OA.Rows(0)("xEmpFactCompras").ToString
                Dim dvEmpCompra As DataView
                Dim xCodEmpCompra As String

                If wAlmacenUsuario.Length > 0 Then
                    dtEmpCompraCheck = New DataTable
                    'Lee Caja de usuario para marcarlo ListCheckBox
                    dtEmpCompraCheck = oWFUsuario.XMLADataTable(wAlmacenUsuario)

                    
                    'Dim i As Integer = -1
                    dvEmpCompra = New DataView(dtEmpCompraCheck)

                    With chlbEmpCompra
                        wEditar = True
                        For i = 0 To .Items.Count - 1

                            xCodEmpCompra = .Items(i).Item("CodEmpresa").ToString
                            dvEmpCompra.RowFilter = "Cod='" + xCodEmpCompra + "'"
                            If dvEmpCompra.Count > 0 Then
                                'marcar la caja con Check
                                .SetItemChecked(i, True)
                                '.Items(i).item.backcolor = Drawing.Color.Aqua
                            End If
                        Next
                        wEditar = False
                    End With
                End If

                '--- Obtiene las series GRT de Barrick asignadas al usuario
                '    ..............................................
                wAlmacenUsuario = String.Empty
                wAlmacenUsuario = dtUsuario_OA.Rows(0)("xSeriesGRT").ToString
                If wAlmacenUsuario.Length > 0 Then
                    dtSeriesGRTCheck = New DataTable
                    dtSeriesGRTCheck = oWFUsuario.XMLADataTable(wAlmacenUsuario)
                    Dim dvSeriesGRT As DataView
                    dvSeriesGRT = New DataView(dtSeriesGRTCheck)
                    With chkSeriesGRT
                        wEditar = True
                        For i = 0 To .Items.Count - 1
                            dvSeriesGRT.RowFilter = "ID=" + .Items(i).Item("IDSerieGRT").ToString
                            If dvSeriesGRT.Count > 0 Then
                                .SetItemChecked(i, True)
                            End If
                        Next
                        wEditar = False
                    End With
                End If
            End If

            '**** Accesos que ya no estan en XML de tabla Usuarios ***
            '**** Accesos definidos desde tabla independientes ***
            '--- Obtiene los SubAlmacenes asignados al usuario (Nuevo)
            '    ..............................................
            pdu_CargarPermisosSubAlmacenes()

            '--- Obtiene Operaciones(Trafico) de Asistencia para el usuario
            '    .............................................. boorar este bloque comentado ...
            'Dim xDtOpAsistCheck As DataTable
            'xDtOpAsistCheck = oWFUsuario.udf_CS_VerOpAsistencia_X_Usuario(wUsuario)

            'Dim dvOpAsist As DataView
            'Dim xIdOp As String
            ''Dim i As Integer = -1
            'dvOpAsist = New DataView(xDtOpAsistCheck)

            'With chlbOpAsistencia
            '    wEditar = True
            '    For i = 0 To .Items.Count - 1
            '        xIdOp = .Items(i).Item("IdOperacion")
            '        dvOpAsist.RowFilter = "IdOperacion=" + CStr(xIdOp)
            '        If dvOpAsist.Count > 0 Then
            '            'marcar la caja con Check
            '            .SetItemChecked(i, True)
            '            '.Items(i).item.backcolor = Drawing.Color.Aqua
            '        End If
            '    Next
            '    wEditar = False
            'End With

            '-- Obtiene las Ctas.Bancarias asignadas al usuario
            pdu_CargarPermisosCtaBco()

            '-- Obtiene las SeriesGRT(Grupo A.C.), asignadas al Usuario
            pdu_CargarPermisos_SerieGRTS()

            '-- Obtiene las Series de Dcmtos. Ventas, asignadas al Usuario
            pdu_CargarPermisos_SerieVtaS()

            '-- Obtiene las operaciones x sucursal asignadas al Usuario.
            pdu_CargarPermisosAOE()

            '-- Obtiene Empresas Contables asignadas al Usuario
            '    ..............................................
            dtEmpCtble = oWFUsuario.fdu_OA_EmpCtble_VerPorUser(wUsuario)
            Dim dvEmpCtble As DataView
            Dim xCodEmpCtble As String

            If dtEmpCtble IsNot Nothing AndAlso dtEmpCtble.Rows.Count > 0 Then               
                dvEmpCtble = New DataView(dtEmpCtble)
                With chlbEmpCtble
                    wEditar = True
                    For i = 0 To .Items.Count - 1
                        xCodEmpCtble = .Items(i).Item("CodEmpresa").ToString
                        dvEmpCtble.RowFilter = "CodEmpresa='" + xCodEmpCtble + "'"
                        If dvEmpCtble.Count > 0 Then
                            'marcar la caja con Check
                            .SetItemChecked(i, True)
                            '.Items(i).item.backcolor = Drawing.Color.Aqua
                        End If
                    Next
                    wEditar = False
                End With

            End If



            '-- Grupos de Orden Servicio por Ventas --
            '    ..............................................            
            'Lee Grupo-OS-Venta de usuario para marcarlo ListCheckBox
            dtEmpCtble = oWFUsuario.fdu_OA_VtaGrupo_VerPorUser(wUsuario)
            dvEmpCtble = New DataView(dtEmpCtble)

            With chlbVOSG
                wEditar = True
                For i = 0 To .Items.Count - 1
                    xCodEmpCtble = .Items(i).Item("NroGrupo").ToString
                    dvEmpCtble.RowFilter = "NroGrupo=" + xCodEmpCtble
                    If dvEmpCtble.Count > 0 Then
                        'marcar la caja con Check
                        .SetItemChecked(i, True)
                        '.Items(i).item.backcolor = Drawing.Color.Aqua
                    End If
                Next
                wEditar = False
            End With

        Else
            lblPersona.Text = ""
            lblRol.Text = ""
        End If

    End Sub

    Private Sub pdu_CargarPermisosSubAlmacenes()
        'Dim wXML As String
        'wXML = dtUsuario_OA.Rows(0)("xSubAlmEmp").ToString
        dtPermisos = Nothing
        dtPermisos = oWFUsuario.udfVerUsuario_OA_SA(wUsuario)
        If dtPermisos IsNot Nothing Then
            ''-- creando indices del PK en tabla filtrada de Permisos
            Dim xCols(3) As DataColumn
            With dtPermisos
                If Not .Columns("CodEmpresa") Is Nothing And _
                    Not .Columns("CodAlmacen") Is Nothing And _
                    Not .Columns("CodSubAlm") Is Nothing And _
                    Not .Columns("RW") Is Nothing Then
                    ' indexa columna
                    xCols(0) = .Columns("CodEmpresa")
                    xCols(1) = .Columns("CodAlmacen")
                    xCols(2) = .Columns("CodSubAlm")
                    xCols(3) = .Columns("RW")
                    .PrimaryKey = xCols
                End If
            End With
        End If
        If dtPermisos IsNot Nothing AndAlso dtPermisos.Rows.Count > 0 Then

            '... Copia solo estructura datos para agregar Permisos Nuevos
            'dtPermisosNuevos = dtPermisos.Clone

            '-- Rescatando Codigo de Modulos
            Dim xLong As Integer = dtPermisos.Rows.Count - 1
            Dim xCodEmpresa As String = ""
            Dim xCodAlmacen As String = ""
            Dim xCodSubAlm As String = ""
            Dim xRW As String = ""

            Dim xPos As Int16 = -1
            Dim xPos1 As Int16 = -1
            Dim xPos2 As Int16 = -1
            Dim xPos3 As Int16 = -1

            ReDim aEmpresa(xLong)
            ReDim aAlmacen(xLong)
            'ReDim aSubAlm(xLong)
            'ReDim aRW(xLong)

            '--- Rescatando Codigos: Empresa, Almacen, SubAlmacen y RW
            For i = 0 To xLong

                If xCodEmpresa <> dtPermisos.Rows(i).Item("CodEmpresa").ToString Then
                    xPos += 1
                    xCodEmpresa = dtPermisos.Rows(i).Item("CodEmpresa")
                    aEmpresa(xPos) = xCodEmpresa
                End If

                If xCodAlmacen <> dtPermisos.Rows(i).Item("CodAlmacen").ToString Then
                    xPos1 += 1
                    xCodAlmacen = dtPermisos.Rows(i).Item("CodAlmacen").ToString
                    aAlmacen(xPos1) = xCodAlmacen
                End If

                'If xCodSubAlm <> dtPermisos.Rows(i).Item("CodSubAlm").ToString Then
                '    xPos2 += 1
                '    xCodSubAlm = dtPermisos.Rows(i).Item("CodSubAlm").ToString
                '    aSubAlm(xPos2) = xCodSubAlm
                'End If
                'If xRW <> dtPermisos.Rows(i).Item("RW").ToString Then
                '    xPos3 += 1
                '    xRW = dtPermisos.Rows(i).Item("RW").ToString
                '    aRW(xPos3) = xRW
                'End If

            Next
            'xLong = xPos
            ReDim Preserve aEmpresa(xPos)
            ReDim Preserve aAlmacen(xPos1)
            'ReDim Preserve aSubAlm(xPos2)
            'ReDim Preserve aRW(xPos3)

            '-- cargar los Sub Almacenes asignados al Usuario (Crea el arbol)
            udfCargaTreeView(tvwPermisos, dtPermisos)

            '-- Marca los Permisos en Opciones asignadas al ROL (Marca el Check)
            udfMarcaPermisosEnOpciones()

            '-- Color de Fondo que indique actualizado
            tvwPermisos.BackColor = Drawing.Color.White
        Else
            pdu_LimpiarPermisosEnOpciones()
        End If

    End Sub

    Private Sub pdu_LimpiarPermisosEnOpciones()
        '-- Limpieza del TreView de Permisos
        tvwPermisos.Nodes.Clear()
        If tvw_SMO.Nodes.Count > 0 Then
            Dim NodoR As TreeNode
            RemoveHandler tvw_SMO.AfterCheck, AddressOf tvw_SMO_AfterCheck
            For Each NodoR In tvw_SMO.Nodes
                NodoR.Checked = False

                '-- pone formato al nodo.
                udfFormatoCheck(NodoR, NodoR.Checked)

                '... Clear Check Permiso en Nodos subordinados:
                pdu_ClearCheckNode(NodoR)
            Next
            AddHandler tvw_SMO.AfterCheck, AddressOf tvw_SMO_AfterCheck
        End If
    End Sub

    Private Sub pdu_ClearCheckNode(ByVal Node As TreeNode)
        Dim i As Integer
        Dim nodX As TreeNode
        'Dim xDato As String
        If Node.GetNodeCount(False) <> 0 Then
            nodX = Node.FirstNode
            For i = 0 To Node.GetNodeCount(False) - 1
                nodX.Checked = False
                '-- pone formato al nodo.
                udfFormatoCheck(nodX, nodX.Checked)

                pdu_ClearCheckNode(nodX)
                nodX = nodX.NextNode
            Next
        End If
    End Sub

    Private Sub udfMarcaPermisosEnOpciones()
        If tvw_SMO.Nodes.Count > 0 Then
            Dim NodoR As TreeNode
            RemoveHandler tvw_SMO.AfterCheck, AddressOf tvw_SMO_AfterCheck
            For Each NodoR In tvw_SMO.Nodes
                udfExtraeCodigos(NodoR)
                If w_CodEmp > 0 Then
                    If Array.IndexOf(aEmpresa, w_CodEmp) >= 0 Then
                        NodoR.Checked = True
                    Else
                        NodoR.Checked = False
                    End If
                End If
                '-- pone formato al nodo.
                udfFormatoCheck(NodoR, NodoR.Checked)

                '... Check Permiso en Nodos subordinados:
                'wEstadoDeCarga = True

                udfCheckPermisoNode(NodoR)
            Next
            AddHandler tvw_SMO.AfterCheck, AddressOf tvw_SMO_AfterCheck
        End If
    End Sub

    Private Sub udfFormatoCheck(ByVal pNode As TreeNode, ByVal pCheck As Boolean)
        If pCheck Then
            pNode.ForeColor = wColorActivado
        Else
            pNode.ForeColor = wColorDesactivado
        End If
    End Sub

    Private Sub udfCheckPermisoNode(ByVal Node As TreeNode)
        Dim nodX As TreeNode
        Dim xPosEmp As Long
        For Each nodX In Node.Nodes
            '.. extrayendo codigos
            udfExtraeCodigos(nodX)
            If w_CodEmp.Length > 0 And w_CodAlm.Length > 0 And w_CodSubAlm.Length > 0 And w_Nodo.Length > 0 Then
                '... Verifica si Permiso está en Opción: Marca / Desmarca
                nodX.Checked = udfBuscaPermiso(w_CodEmp, w_CodAlm, w_CodSubAlm, w_Nodo)
            ElseIf w_CodEmp.Length > 0 And w_CodAlm.Length > 0 And w_CodSubAlm.Length > 0 Then
                '... Verifica si tiene acceso al sub Almacen
                nodX.Checked = udfBuscaPermisoSA(w_CodEmp, w_CodAlm, w_CodSubAlm)
            ElseIf w_CodEmp.Length > 0 And w_CodAlm.Length > 0 Then
                Dim xPosAlm As Long
                xPosAlm = Array.IndexOf(aAlmacen, w_CodAlm, 0)
                xPosEmp = Array.IndexOf(aEmpresa, w_CodEmp, 0)
                If xPosAlm >= 0 And xPosEmp >= 0 Then
                    nodX.Checked = True
                Else
                    nodX.Checked = False
                End If
            ElseIf w_CodEmp.Length > 0 Then
                xPosEmp = Array.IndexOf(aEmpresa, w_CodEmp, 0)
                If Array.IndexOf(aEmpresa, w_CodEmp) >= 0 Then
                    nodX.Checked = True
                Else
                    nodX.Checked = False
                End If
            End If
            '-- pone formato al nodo.
            udfFormatoCheck(nodX, nodX.Checked)
            '... invocación recursiva
            udfCheckPermisoNode(nodX)
        Next
    End Sub

    Private Function udfBuscaPermisoSA(ByVal pCodEmp As String, ByVal pCodAlm As String, ByVal pCodSub As String) As Boolean
        '-- Busca si SubAlmacen esta asignado al usuario
        Dim xDr() As DataRow
        xDr = dtPermisos.Select("CodEmpresa='" & pCodEmp & "' AND CodAlmacen='" & pCodAlm & "' AND CodSubAlm='" & pCodSub & "'")
        If xDr.Length > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function udfBuscaPermiso(ByVal pCodEmp As String, ByVal pCodAlm As String, ByVal pCodSub As String, ByVal pCodRW As String) As Boolean
        w_EmpFound = ""
        w_AlmFound = ""
        w_SubFound = ""
        w_RWFound = ""

        '... crear indices (PK) 
        Dim xBuscarPK(3) As Object
        xBuscarPK(0) = pCodEmp
        xBuscarPK(1) = pCodAlm
        xBuscarPK(2) = pCodSub
        xBuscarPK(3) = pCodRW

        '... busca PK
        Dim xFoundRow As DataRow = dtPermisos.Rows.Find(xBuscarPK)
        If Not (xFoundRow Is Nothing) Then
            '... PK encontrado
            w_EmpFound = pCodEmp
            w_AlmFound = pCodAlm
            w_SubFound = pCodSub
            w_Nodo = pCodRW
            Return True
        Else
            Return False
        End If
        'End If
    End Function


    

    Private Sub chlbAlmacenes_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chlbAlmacenes.ItemCheck
        If Not wEditar Then
            chlbAlmacenes.BackColor = Drawing.Color.LightSteelBlue
        End If
    End Sub

    Private Sub chlbAlmacenes_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chlbAlmacenes.SelectedValueChanged
        chlbAlmacenes.BackColor = Drawing.Color.LightSteelBlue
    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        ' recolectar Almacenes elegidos
        Dim xAlmacenes As String = String.Empty
        Dim xDr As DataRow


        With dtAlmacenCheck
            If Not dtAlmacenCheck Is Nothing Then ' .Columns.Contains("Codigo") Then
                If .Rows.Count > 0 Then
                    .Clear()
                End If
            Else
                '.. crea columna para el código del Almacén
                Dim _StColumn As New DataColumn
                Dim xDt As New DataTable
                With _StColumn
                    .ColumnName = "Codigo"
                    .DataType = GetType(String)
                End With
                xDt.Columns.Add(_StColumn)
                dtAlmacenCheck = xDt.Clone

            End If
        End With

        With chlbAlmacenes

            Dim i As Integer
            If .CheckedItems.Count > 0 Then
                For i = 0 To .CheckedItems.Count - 1
                    xDr = dtAlmacenCheck.NewRow
                    'xCodAlm = .Items(i).Item("CodAlmacen").ToString
                    xDr("Codigo") = .CheckedItems(i).Item("CodAlmacen").ToString
                    dtAlmacenCheck.Rows.Add(xDr)
                Next
                xAlmacenes = oWFUsuario.DataTableAXML(dtAlmacenCheck)
            End If
            '.. grabar cambios de almacenes
            If oWFUsuario.udfEditarAlmacen_OA(wUsuario, xAlmacenes) Then
                '-- Color de Fondo que indique actualizado
                .BackColor = Drawing.Color.White
            End If
        End With


    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

  
    Private Sub cbxUsuario_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbxUsuario.SelectedValueChanged
        If Not (wEditar) And cbxUsuario.SelectedIndex >= 0 Then
            ' Si no esta en Edición, Cargar Procesos del Usuario
            wUsuario = cbxUsuario.SelectedValue
            udfCargaCampos(True)
        End If
    End Sub

    Private Sub chlbCajas_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chlbCajas.ItemCheck
        If Not wEditar Then
            chlbCajas.BackColor = Drawing.Color.LightSteelBlue
        End If
    End Sub

    Private Sub chlbCajas_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chlbCajas.SelectedValueChanged
        chlbCajas.BackColor = Drawing.Color.LightSteelBlue
    End Sub

    Private Sub btnActualizarC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnActualizarC.Click
        ' ===  C A J A S  ===
        ' recolectar Almacenes elegidos
        Dim xCajas As String = String.Empty
        Dim xDr As DataRow

        With dtCajaCheck
            If Not dtCajaCheck Is Nothing Then ' .Columns.Contains("Codigo") Then
                If .Rows.Count > 0 Then
                    .Clear()
                End If
            Else
                '.. crea columna para el código del Almacén
                Dim _StColumn As New DataColumn
                Dim xDt As New DataTable
                With _StColumn
                    .ColumnName = "Codigo"
                    .DataType = GetType(String)
                End With
                xDt.Columns.Add(_StColumn)
                dtCajaCheck = xDt.Clone

            End If
        End With

        With chlbCajas

            Dim i As Integer
            If .CheckedItems.Count > 0 Then
                For i = 0 To .CheckedItems.Count - 1
                    xDr = dtCajaCheck.NewRow
                    'xCodAlm = .Items(i).Item("CodAlmacen").ToString
                    xDr("Codigo") = .CheckedItems(i).Item("CodCaja").ToString
                    dtCajaCheck.Rows.Add(xDr)
                Next
                xCajas = oWFUsuario.DataTableAXML(dtCajaCheck)
            End If
            '.. grabar cambios de Cajas
            If oWFUsuario.udfEditarCaja_OA(wUsuario, xCajas) Then
                '-- Color de Fondo que indique actualizado
                .BackColor = Drawing.Color.White
            End If
        End With
    End Sub

    Private Sub QuitarSubAlmacenesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If dgvSubAlmacenes.DataSource Is Nothing Then Return
        'If dgvSubAlmacenes.CurrentRow Is Nothing Then
        '    MsgBox("Seleccione la fila que desea quitar.", MsgBoxStyle.Exclamation, Me.Text)
        '    dgvSubAlmacenes.Focus()
        '    Return
        'End If

        'If MsgBox("¿Desea eliminar la fila seleccionada?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
        '    Return
        'End If

        'Dim CodAlm As String = dgvSubAlmacenes.CurrentRow.Cells("CodAlmacen").Value
        'If oWFUsuario.udfQuitarAlmAccesos(cbxUsuario.Text, CodAlm) Then
        '    Dim dtSA As DataTable
        '    dtSA = CType(dgvSubAlmacenes.DataSource, DataTable)
        '    '
        '    Dim Cols(1) As DataColumn
        '    Cols(0) = dtSA.Columns("CodAlmacen")
        '    dtSA.PrimaryKey = Cols
        '    dtSA.Rows.Find(CodAlm).Delete()
        '    dtSA.AcceptChanges()
        'End If
    End Sub

    Private Sub VerSubAlmacenesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If dgvSubAlmacenes.DataSource Is Nothing Then Return
        'If dgvSubAlmacenes.CurrentRow Is Nothing Then
        '    MsgBox("Seleccione la fila que desea Visualizar.", MsgBoxStyle.Exclamation, Me.Text)
        '    dgvSubAlmacenes.Focus()
        '    Return
        'End If

        'Dim ofrmMapeoSubAlm As New frmMapeoSubAlm
        'With ofrmMapeoSubAlm
        '    .btnGuardar.Visible = False
        '    .lblUsuario.Text = cbxUsuario.Text
        '    .dtSubAlm = oWFUsuario.XMLADataTable(dgvSubAlmacenes.CurrentRow.Cells("SubAlmacenes").Value)
        '    ._CodAlm = dgvSubAlmacenes.CurrentRow.Cells("CodAlmacen").Value
        '    ._Almacen = dgvSubAlmacenes.CurrentRow.Cells("Almacenes").Value
        '    .dgvSubAlmacenes.DataSource = .dtSubAlm
        '    .dgvSubAlmacenes.Columns("Check").Visible = False
        '    .dgvSubAlmacenes.Columns("RW1").Visible = False
        '    .dgvSubAlmacenes.Columns("CodSubAlm").Visible = False
        '    .dgvSubAlmacenes.Columns("Descripcion").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '    .ShowDialog()
        'End With

    End Sub

    Private Sub ModificarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If dgvSubAlmacenes.DataSource Is Nothing Then Return
        'If dgvSubAlmacenes.CurrentRow Is Nothing Then
        '    MsgBox("Seleccione la fila que desea Modificar.", MsgBoxStyle.Exclamation, Me.Text)
        '    dgvSubAlmacenes.Focus()
        '    Return
        'End If

        'Dim ofrmMapeoSubAlm As New frmMapeoSubAlm
        'With ofrmMapeoSubAlm
        '    .btnGuardar.Visible = True
        '    .btnGuardar.Text = "Modificar"
        '    .lblUsuario.Text = cbxUsuario.Text
        '    .dtAlmacen = _dtAlmacenes
        '    If Not _dtAlmacenes Is Nothing AndAlso _dtAlmacenes.Rows.Count > 0 Then
        '        With .cbAlmacen
        '            .DataSource = _dtAlmacenes
        '            .DisplayMember = _dtAlmacenes.Columns("Almacenes").ColumnName
        '            .ValueMember = _dtAlmacenes.Columns("CodAlmacen").ColumnName
        '        End With
        '    End If

        '    .dtSubAlm = oWFUsuario.XMLADataTable(dgvSubAlmacenes.CurrentRow.Cells("SubAlmacenes").Value)
        '    ._CodAlm = dgvSubAlmacenes.CurrentRow.Cells("CodAlmacen").Value
        '    ._Almacen = dgvSubAlmacenes.CurrentRow.Cells("Almacenes").Value

        '    .ShowDialog()
        '    If Not .Tag Is Nothing AndAlso .Tag = "Ok" Then
        '        LlenarDGVSubAlmacenes()
        '    End If
        'End With

    End Sub

    Private Sub AgregarSubAlmacenesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim ofrmMapeoSubAlm As New frmMapeoSubAlm
        'With ofrmMapeoSubAlm
        '    .btnGuardar.Visible = True
        '    .btnGuardar.Text = "Guardar"
        '    .lblUsuario.Text = cbxUsuario.Text
        '    .dtAlmacen = _dtAlmacenes
        '    If Not _dtAlmacenes Is Nothing AndAlso _dtAlmacenes.Rows.Count > 0 Then
        '        With .cbAlmacen
        '            .DataSource = _dtAlmacenes
        '            .DisplayMember = _dtAlmacenes.Columns("Almacenes").ColumnName
        '            .ValueMember = _dtAlmacenes.Columns("CodAlmacen").ColumnName
        '        End With
        '    End If
        '    .ShowDialog()
        '    If Not .Tag Is Nothing AndAlso .Tag = "Ok" Then
        '        LlenarDGVSubAlmacenes()
        '    End If
        'End With
    End Sub

    Private Sub btnAsignarCCosto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignarCCosto.Click
        scAlmacenes.Panel2Collapsed = False
        btnAsignarCCosto.Enabled = False
        chlbAlmacenes.Enabled = False

        lblAlmacen.Text = chlbAlmacenes.Items(chlbAlmacenes.SelectedIndex).Item("Almacen")
        lblAlmacen.Tag = chlbAlmacenes.Items(chlbAlmacenes.SelectedIndex).Item("CodAlmacen")

        ucCtrlCCostos.Inicializar()
        ucCtrlCCostos.IDCCostoN1V1 = CInt(chlbAlmacenes.Items(chlbAlmacenes.SelectedIndex).Item("IDCCostoN1"))
        ucCtrlCCostos.IDCCostoN2V1 = CInt(chlbAlmacenes.Items(chlbAlmacenes.SelectedIndex).Item("IDCCostoN2"))
        ucCtrlCCostos.IDCCostoN3V1 = CInt(chlbAlmacenes.Items(chlbAlmacenes.SelectedIndex).Item("IDCCostoN3"))
        ucCtrlCCostos.IDCCostoN4V1 = CInt(chlbAlmacenes.Items(chlbAlmacenes.SelectedIndex).Item("IDCCostoN4"))

        ucCtrlCCostos.CentroCostos_LLenarCtrl(chlbAlmacenes.Items(chlbAlmacenes.SelectedIndex).Item("CodEmpresa"))
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        Dim IDCCostoN1V1 As Integer = ucCtrlCCostos.IDCCostoN1V1
        Dim IDCCostoN2V1 As Integer = ucCtrlCCostos.IDCCostoN2V1
        Dim IDCCostoN3V1 As Integer = ucCtrlCCostos.IDCCostoN3V1
        Dim IDCCostoN4V1 As Integer = ucCtrlCCostos.IDCCostoN4V1

        If IDCCostoN4V1 > 0 And IDCCostoN3V1 <= 0 Then
            MsgBox("Es necesario CCosto nivel 3", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        If IDCCostoN3V1 > 0 And IDCCostoN2V1 <= 0 Then
            MsgBox("Es necesario CCosto nivel 2", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        If IDCCostoN2V1 > 0 And IDCCostoN1V1 <= 0 Then
            MsgBox("Es necesario CCosto nivel 1", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If

        'Grabar
        If oWFUsuario.udfAsignarCCostoAlmacen(lblAlmacen.Tag, IDCCostoN1V1, IDCCostoN2V1, _
                                             IDCCostoN3V1, IDCCostoN4V1) Then
            scAlmacenes.Panel2Collapsed = True
            btnAsignarCCosto.Enabled = True
            chlbAlmacenes.Enabled = True
        Else
            MsgBox("Error al Grabar", MsgBoxStyle.Exclamation, Me.Text)
        End If

    End Sub

    Public Sub SalirCtrlCentroCostos() Handles ucCtrlCCostos.SalirDelControl
        ucCtrlCCostos.IDCCostoN1V1 = -1
        ucCtrlCCostos.IDCCostoN2V1 = -1
        chlbAlmacenes.Focus()
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        scAlmacenes.Panel2Collapsed = True
        btnAsignarCCosto.Enabled = True
        chlbAlmacenes.Enabled = True
    End Sub

    'Private _estado As Boolean = False
    'Private Sub chlbAlmacenes_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chlbAlmacenes.MouseDoubleClick
    '    _estado = Not _estado
    '    Me.chlbAlmacenes.SetItemChecked(chlbAlmacenes.SelectedIndex, _estado)
    'End Sub

    Private Sub cbxUsuario_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbxUsuario.KeyDown
        If e.KeyCode = Keys.Return Then
            If Not (wEditar) And cbxUsuario.SelectedIndex >= 0 Then
                ' Si no esta en Edición, Cargar Procesos del Usuario
                wUsuario = cbxUsuario.SelectedValue
                udfCargaCampos(True)
            End If
        End If
    End Sub

    Private Sub btnActEmpCaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActEmpCaja.Click
        Dim xDr As DataRow
        With dtEmpCajaCheck
            If Not dtEmpCajaCheck Is Nothing Then
                If .Rows.Count > 0 Then
                    .Clear()
                End If
            Else
                '.. crea columna
                Dim _StColumn As New DataColumn
                Dim xDt As New DataTable
                With _StColumn
                    .ColumnName = "Codigo"
                    .DataType = GetType(String)
                End With
                xDt.Columns.Add(_StColumn)
                dtEmpCajaCheck = xDt.Clone
            End If
        End With

        With chlbEmpCajas

            Dim i As Integer
            If .CheckedItems.Count > 0 Then
                For i = 0 To .CheckedItems.Count - 1
                    xDr = dtEmpCajaCheck.NewRow
                    xDr("Codigo") = .CheckedItems(i).Item("CodEmpresa").ToString
                    dtEmpCajaCheck.Rows.Add(xDr)
                Next
            End If
            '.. grabar cambios
            Dim xEmp As String = String.Empty
            With chlbEmpCajas
                If .CheckedItems.Count > 0 Then
                    xEmp = oWFUsuario.DataTableAXML(dtEmpCajaCheck)
                End If
                If oWFUsuario.udfEditarEmpresa(wUsuario, xEmp, True) Then
                    .BackColor = Drawing.Color.White
                End If
            End With
        End With
    End Sub

    Private Sub btnActEmpComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActEmpComp.Click
        Dim xDr As DataRow
        With dtEmpCompraCheck
            If Not dtEmpCompraCheck Is Nothing Then
                If .Rows.Count > 0 Then
                    .Clear()
                End If
            Else
                '.. crea columna
                Dim _StColumn As New DataColumn
                Dim xDt As New DataTable
                With _StColumn
                    .ColumnName = "Cod"
                    .DataType = GetType(String)
                End With
                xDt.Columns.Add(_StColumn)
                dtEmpCompraCheck = xDt.Clone
            End If
        End With

        With chlbEmpCompra

            Dim i As Integer
            If .CheckedItems.Count > 0 Then
                For i = 0 To .CheckedItems.Count - 1
                    xDr = dtEmpCompraCheck.NewRow
                    xDr("Cod") = .CheckedItems(i).Item("CodEmpresa").ToString
                    dtEmpCompraCheck.Rows.Add(xDr)
                Next
            End If
            '.. grabar cambios
            Dim xEmp As String = String.Empty
            'With chlbEmpCajas
            If .CheckedItems.Count > 0 Then
                xEmp = oWFUsuario.DataTableAXML(dtEmpCompraCheck)
            End If
            If oWFUsuario.udfEditarEmpresa(wUsuario, xEmp, False) Then
                .BackColor = Drawing.Color.White
            End If
            'End With
        End With
    End Sub

    Private Sub btnActSubAlm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActSubAlm.Click
        With tvw_SMO
            'dtPermisosNuevos.Clear()
            dtPermisosNuevos = dtPermisos.Clone
            ' Elimina columnas innecesarias            
            dtPermisosNuevos.Columns.Remove("Empresa")
            dtPermisosNuevos.Columns.Remove("Almacen")
            dtPermisosNuevos.Columns.Remove("SubAlmacen")

            If .Nodes.Count > 0 Then
                Dim j As Int32
                Dim xXML As String

                For j = 0 To .Nodes.Count - 1
                    Dim xNode As TreeNode
                    xNode = .Nodes(j)
                    '... Check Permiso en Nodos subordinados
                    udfCopyDataNode(xNode)
                Next
                '... Convertir Tabla a XML
                xXML = oWFUsuario.DataTableAXML(dtPermisosNuevos)
                '... Grabar Data en BD
                If oWFUsuario.fdu_CS_EditarSubAlmacenAcceso(wUsuario, xXML) Then
                    udfCargaCampos(True)
                    tvwPermisos.BackColor = Drawing.Color.White
                End If
            End If
        End With
    End Sub

    Private Sub udfCopyDataNode(ByVal Node As TreeNode)
        Dim i As Integer
        Dim nodX As TreeNode

        If Node.GetNodeCount(False) <> 0 Then
            nodX = Node.FirstNode
            For i = 0 To Node.GetNodeCount(False) - 1
                'nodX.Checked = bCheck
                If nodX.Checked Then
                    '... Extrae códigos
                    udfExtraeCodigos(nodX)
                    If w_CodEmp.Length > 0 And w_CodAlm.Length > 0 And w_CodSubAlm.Length > 0 And w_Nodo.Length > 0 Then
                        'Agregar Registro a tabla
                        Dim xDr As DataRow = dtPermisosNuevos.NewRow
                        xDr("CodEmpresa") = w_CodEmp
                        xDr("CodAlmacen") = w_CodAlm
                        xDr("CodSubAlm") = w_CodSubAlm
                        If w_Nodo = "R" Then
                            xDr("RW") = "0"
                        Else
                            xDr("RW") = "1"
                        End If

                        dtPermisosNuevos.Rows.Add(xDr)
                        If w_Nodo = "W" Then
                            '-- eliminar fila con "R"
                            '... crear indices (PK) 
                            Dim xBuscarPK(3) As Object
                            xBuscarPK(0) = w_CodEmp
                            xBuscarPK(1) = w_CodAlm
                            xBuscarPK(2) = w_CodSubAlm
                            xBuscarPK(3) = "0"
                            '... Si es 1er. registro, crear Primary Key
                            'If dtPermisosNuevos.Rows.Count = 1 Then
                            '    ''-- creando indices del PK en tabla filtrada de Permisos
                            '    Dim xCols(3) As DataColumn
                            '    With dtPermisosNuevos
                            '        If Not .Columns("CodEmpresa") Is Nothing And _
                            '            Not .Columns("CodAlmacen") Is Nothing And _
                            '            Not .Columns("CodSubAlm") Is Nothing And _
                            '            Not .Columns("RW") Is Nothing Then
                            '            ' indexa columna
                            '            xCols(0) = .Columns("CodEmpresa")
                            '            xCols(1) = .Columns("CodAlmacen")
                            '            xCols(2) = .Columns("CodSubAlm")
                            '            xCols(3) = .Columns("RW")
                            '            .PrimaryKey = xCols
                            '        End If
                            '    End With
                            'End If
                            '... busca PK
                            Dim xFoundRow As DataRow = dtPermisosNuevos.Rows.Find(xBuscarPK)
                            If Not (xFoundRow Is Nothing) Then
                                dtPermisosNuevos.Rows.Remove(xFoundRow)
                            End If
                        End If
                    End If
                End If
                '-- Aplicar Recursividad
                udfCopyDataNode(nodX)
                nodX = nodX.NextNode
            Next
        End If
    End Sub

    Private Sub udfExtraeCodigos(ByRef xNode As TreeNode)
        Dim xCodigos As String
        Dim xPos1 As Integer = 0
        Dim xPos2 As Integer = 0
        Dim xPos3 As Integer = 0
        Dim xAncho As Integer = 0

        w_CodEmp = ""
        w_CodAlm = ""
        w_CodSubAlm = ""
        w_Nodo = ""

        xCodigos = xNode.Tag
        xPos1 = InStr(xCodigos, ":")
        xPos2 = InStr(xCodigos, "-")
        xPos3 = InStr(xCodigos, "/")
        ' 01:A17-S1/W
        '   3   7  0
        If xPos1 = 0 And xPos2 = 0 And xPos3 = 0 Then
            w_CodEmp = xCodigos.Trim
        Else
            w_CodEmp = xCodigos.Substring(0, xPos1 - 1)
        End If

        If xPos1 > 0 And xPos2 = 0 And xPos3 = 0 Then
            xAncho = xCodigos.Length - xPos1
            w_CodAlm = xCodigos.Substring(xPos1, xAncho)
        End If

        If xPos1 > 0 And xPos2 > 0 And xPos3 = 0 Then
            w_CodAlm = xCodigos.Substring(xPos1, xPos2 - (xPos1 + 1))
            xAncho = xCodigos.Length - xPos2
            w_CodSubAlm = xCodigos.Substring(xPos2, xAncho)
        End If

        'If w_CodAlm = "A7" Then
        '    w_CodAlm = "A7"
        'End If

        If xPos1 > 0 And xPos2 > 0 And xPos3 > 0 Then
            w_CodAlm = xCodigos.Substring(xPos1, xPos2 - (xPos1 + 1))
            w_CodSubAlm = xCodigos.Substring(xPos2, xPos3 - (xPos2 + 1))
            'w_Nodo = xCodigos.Substring(xPos3, xPos2 - (xPos1 + 1))
            xAncho = xCodigos.Length - xPos3
            'xPos2 = xPos2
            w_Nodo = xCodigos.Substring(xPos3, xAncho)
        End If
    End Sub

    Private Sub tvw_SMO_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvw_SMO.AfterCheck
        ' Merca/Desmarca Niveles de Acceso a modificar para el ROL.
        tvwPermisos.BackColor = Drawing.Color.LightSteelBlue
        TreeCheckBoxes(tvw_SMO, e.Node)
    End Sub

    Public Sub TreeCheckBoxes(ByVal TR As TreeView, ByVal CurrentNode As TreeNode)
        'Procedimiento que asigna check a los hijos y padres de un treeView
        Dim lParentNode As TreeNode
        Dim EstadoCheck As Boolean
        Static noEntraNode As Boolean

        If noEntraNode Then Exit Sub
        noEntraNode = True

        EstadoCheck = CurrentNode.Checked
        udfFormatoCheck(CurrentNode, EstadoCheck)

        '-- Deshabilitar Check recurrente en la CARGA de Datos


        If CurrentNode.Checked = True Then 'Node con Check
            'da Check a los Hijos
            'If Not wEstadoDeCarga Then
            Checkhijos(CurrentNode, EstadoCheck)
            'End If

            'Pone el Chek as los padres
            lParentNode = CurrentNode
            Do While Not lParentNode.Parent Is Nothing
                lParentNode.Checked = EstadoCheck
                udfFormatoCheck(lParentNode, EstadoCheck)
                lParentNode = lParentNode.Parent
            Loop
            lParentNode.Checked = EstadoCheck
            udfFormatoCheck(lParentNode, EstadoCheck)
        Else
            'Quita el check a los hijos
            'If Not wEstadoDeCarga Then
            Checkhijos(CurrentNode, EstadoCheck)
            'End If

            'verifica si algun hijo tiene check sino quita el check  los padres
            CheckPadre(CurrentNode, EstadoCheck)
        End If

        noEntraNode = False

    End Sub


    Private Sub Checkhijos(ByVal Node As TreeNode, ByVal bCheck As Boolean)
        'Procedimiento que asigna check a los hijos de un treeView
        Dim i As Short
        Dim nodX As TreeNode
        udfFormatoCheck(Node, bCheck)
        If Node.GetNodeCount(False) <> 0 Then
            nodX = Node.FirstNode
            For i = 0 To Node.GetNodeCount(False) - 1
                nodX.Checked = bCheck
                udfFormatoCheck(nodX, bCheck)
                Checkhijos(nodX, bCheck)
                nodX = nodX.NextNode
            Next
        End If
    End Sub

    Private Sub CheckPadre(ByVal Node As TreeNode, ByVal bCheck As Boolean)
        'Procedimiento que asigna check a los Padres de un treeView
        Dim i As Short
        Dim nodX As TreeNode

        If Node.Parent Is Nothing Then
            Node.Checked = bCheck

            udfFormatoCheck(Node, bCheck)
            Exit Sub
        End If

        If Node.Parent.GetNodeCount(False) = 1 Then
            nodX = Node.Parent
            nodX.Checked = bCheck

            udfFormatoCheck(nodX, bCheck)
            CheckPadre(nodX, bCheck)
        End If
        If Node.Parent.GetNodeCount(False) > 1 Then
            Dim NodeHermano As TreeNode = Nothing
            Dim QuitaNode As Boolean

            If Not Node.Parent.FirstNode Is Nothing Then
                NodeHermano = Node.Parent.FirstNode
            End If

            QuitaNode = True
            For i = 0 To NodeHermano.Parent.GetNodeCount(False) - 1

                If NodeHermano.Checked Then
                    If Node.Level = NodeHermano.Level And Node.Index <> NodeHermano.Index Then
                        QuitaNode = False
                        Exit For
                    End If
                End If
                udfFormatoCheck(NodeHermano, bCheck)
                NodeHermano = NodeHermano.NextNode
            Next
            If QuitaNode Then
                Node.Parent.Checked = bCheck
                udfFormatoCheck(Node.Parent, bCheck)
                CheckPadre(Node.Parent, bCheck)
            End If
        End If
    End Sub


    Private Sub BtnActualizarSeriesGRT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizarSeriesGRT.Click
        ' ===  C A J A S  ===
        ' recolectar Almacenes elegidos
        Dim xSeriesGRT As String = String.Empty
        Dim xDr As DataRow

        With dtSeriesGRTCheck
            If Not dtSeriesGRTCheck Is Nothing Then ' .Columns.Contains("Codigo") Then
                If .Rows.Count > 0 Then
                    .Clear()
                End If
            Else
                '.. crea columna para el código del Almacén
                Dim _StColumn As New DataColumn
                Dim xDt As New DataTable
                With _StColumn
                    .ColumnName = "ID"
                    .DataType = GetType(Integer)
                End With
                xDt.Columns.Add(_StColumn)
                dtSeriesGRTCheck = xDt.Clone
            End If
        End With

        With chkSeriesGRT
            Dim i As Integer
            If .CheckedItems.Count > 0 Then
                For i = 0 To .CheckedItems.Count - 1
                    xDr = dtSeriesGRTCheck.NewRow
                    xDr("ID") = .CheckedItems(i).Item("IDSerieGRT").ToString
                    dtSeriesGRTCheck.Rows.Add(xDr)
                Next
                xSeriesGRT = oWFUsuario.DataTableAXML(dtSeriesGRTCheck)
            End If
            If oWFUsuario.udfEditarSeriesGRT_OA(wUsuario, xSeriesGRT) Then
                '-- Color de Fondo que indique actualizado
                .BackColor = Drawing.Color.White
            End If
        End With
    End Sub

    'Private Sub btnActOpAsistencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Dim xDt As New DataTable
    '    xDt.Columns.Add("IdOperacion")

    '    For Each chb As DataRowView In chlbOpAsistencia.CheckedItems
    '        xDt.Rows.Add(chb.Item("IdOperacion"))
    '    Next

    '    Dim xmlDatos As String = ""
    '    If xDt.Rows.Count > 0 Then
    '        xmlDatos = oWFUsuario.DataTableAXML(xDt)
    '    End If

    '    If oWFUsuario.fdu_CS_EditarOpAsistencia_X_Usuario(wUsuario, xmlDatos) Then
    '        chlbOpAsistencia.BackColor = Drawing.Color.White
    '    End If

    'End Sub

    'Private Sub chlbOpAsistencia_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs)
    '    If Not wEditar Then
    '        chlbOpAsistencia.BackColor = Drawing.Color.LightSteelBlue
    '    End If
    'End Sub


#Region "Cuentas Bancos"
    
    Private Sub pdu_Cargar_CuentasBancos()
        dtCtaBco = oWFUsuario.fdu_OA_CtaBcos_Listar
        If Not dtCtaBco Is Nothing AndAlso dtCtaBco.Rows.Count > 0 Then
            '-- Cargar el TreeView
            udfCarga_tvCBD(tv_CBD, dtCtaBco)
        Else
            MsgBox("No existen Cta-Bancos registrados.")
            'Me.Close()
        End If
    End Sub

    Private Sub udfCarga_tvCBD(ByVal pTvwOpciones As TreeView, ByVal pDtOpciones As DataTable)
        '-- Limpieza de Nodos anteriores
        pTvwOpciones.Nodes.Clear()
        '-- Validación para carga de datos
        Cursor.Current = Cursors.WaitCursor
        If Not pDtOpciones Is Nothing AndAlso pDtOpciones.Rows.Count > 0 Then
            Dim dtEmp_Bco_Cta As DataTable
            Dim xDr() As DataRow

            w_CodEmpBco = ""
            w_IdBanco = 0
            w_NroCta = 0

            '-- configura TreeView
            With pTvwOpciones
                .BeginUpdate()
                .ShowLines = True
                .ShowPlusMinus = True
                .ShowRootLines = True
                .HideSelection = False
                .HotTracking = False
            End With

            '-- Filtra Empresa, Almacen y Sub Almacen para creacion recursiva de Opciones
            xDr = pDtOpciones.Select("NroCuenta>0", "CodEmpresa,Banco,Cuenta")
            If xDr.Length > 0 Then
                dtEmp_Bco_Cta = xDr.CopyToDataTable

                'dtOpcionesNodos = pDtOpciones.Copy
                '-- En recorrido, segun encuentre va creando los nodos
                For Each xR As DataRow In dtEmp_Bco_Cta.Rows ' pDtOpciones.Rows
                    If xR.Item("CodEmpresa") <> w_CodEmpBco Then
                        w_CodEmpBco = xR.Item("CodEmpresa")
                        udfCrea_TnEmpBco(pTvwOpciones, w_CodEmpBco, xR.Item("Empresa"))
                        w_IdBanco = 0
                    End If
                    If w_IdBanco <> xR.Item("IdBanco") Then
                        w_IdBanco = xR.Item("IdBanco")
                        udfCrea_TnBanco(w_CodEmpBco, w_IdBanco, xR.Item("Banco"))
                        w_NroCta = 0
                    End If
                    'If w_CodSubAlm <> xR.Item("CodSubAlm") Then
                    '    w_CodSubAlm = xR.Item("CodSubAlm")
                    '    udfCrea_TnSubAlmacen(w_CodEmpBco, w_CodAlm, w_CodSubAlm, xR.Item("SubAlmacen"))
                    '    w_Nodo = ""
                    'End If
                    If w_NroCta <> xR.Item("NroCuenta") Then
                        w_NroCta = xR.Item("NroCuenta")
                        udfCrea_TnCtaBco(w_CodEmpBco, w_IdBanco, w_NroCta, xR.Item("Cuenta"))
                    End If
                Next
            End If
            pTvwOpciones.EndUpdate()
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub udfCrea_TnEmpBco(ByRef pTvwOpciones As TreeView, ByVal pCodEmpresa As String, ByVal pEmpresa As String)
        Dim xKey As String        
        xKey = pCodEmpresa
        wTn_EmpBco = New TreeNode(pEmpresa)
        With wTn_EmpBco
            .Tag = xKey
            .ForeColor = Drawing.Color.Navy
            .NodeFont = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold) ', System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End With
        pTvwOpciones.Nodes.Add(wTn_EmpBco)        
    End Sub

    Private Sub udfCrea_TnBanco(ByVal pCodEmpresa As String, ByVal pIdBanco As Integer, ByVal pBanco As String)
        Dim xKey As String
        xKey = pCodEmpresa & ":" & pIdBanco.ToString
        wTn_Banco = New TreeNode(pBanco)
        With wTn_Banco
            .Tag = xKey
            .ForeColor = Drawing.Color.Navy
            .NodeFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold) ', System.Drawing.GraphicsUnit.Point, CType(0, Byte))            
        End With
        wTn_EmpBco.Nodes.Add(wTn_Banco)
        wTn_EmpBco.Expand()
    End Sub

    Private Sub udfCrea_TnCtaBco(ByVal pCodEmpresa As String, ByVal pIdBanco As Integer, ByVal pNroCuenta As Integer, ByVal pCuenta As String)
        Dim xKey As String
        xKey = pCodEmpresa & ":" & pIdBanco.ToString & "-" & pNroCuenta.ToString
        wTn_BcoCta = New TreeNode(pCuenta)
        With wTn_BcoCta
            .Tag = xKey
            .ForeColor = Drawing.Color.Navy
            .NodeFont = New System.Drawing.Font("Tahoma", 7.75!, System.Drawing.FontStyle.Regular) ', System.Drawing.GraphicsUnit.Point, CType(0, Byte))            
        End With
        wTn_Banco.Nodes.Add(wTn_BcoCta)
        wTn_Banco.Expand()
    End Sub

    Private Sub udfCheck_PermisoCtaBco(ByVal Node As TreeNode)
        Dim nodX As TreeNode
        'Dim xPosEmp As Long
        For Each nodX In Node.Nodes
            '.. extrayendo codigos
            udfExtraeCodigos_CtaBcos(nodX)
            If w_CodEmpBco.Length > 0 And w_IdBanco > 0 And w_NroCta > 0 Then
                '... Verifica si Permiso está en Opción: Marca / Desmarca
                nodX.Checked = udfBuscaPermiso_CtaBco(w_CodEmpBco, w_IdBanco, w_NroCta)
            ElseIf w_CodEmpBco.Length > 0 And w_IdBanco > 0 Then
                '... Verifica si tiene acceso al sub Almacen
                nodX.Checked = udfBuscaPermiso_Banco(w_CodEmpBco, w_IdBanco)
            ElseIf w_CodEmpBco.Length > 0 Then
                '    Dim xPosAlm As Long
                '    xPosAlm = Array.IndexOf(aAlmacen, w_CodAlm, 0)
                '    xPosEmp = Array.IndexOf(aEmpresa, w_CodEmpBco, 0)
                '    If xPosAlm >= 0 And xPosEmp >= 0 Then
                '        nodX.Checked = True
                '    Else
                '        nodX.Checked = False
                '    End If
                'ElseIf w_CodEmpBco.Length > 0 Then
                'xPosEmp = Array.IndexOf(aEmpresaBco, w_CodEmpBco, 0)
                If Array.IndexOf(aEmpresaBco, w_CodEmpBco, 0) >= 0 Then
                    nodX.Checked = True
                Else
                    nodX.Checked = False
                End If
            End If
            '-- pone formato al nodo.
            udfFormatoCheck(nodX, nodX.Checked)
            '... invocación recursiva
            udfCheck_PermisoCtaBco(nodX)
        Next
    End Sub

    Private Sub udfExtraeCodigos_CtaBcos(ByRef xNode As TreeNode)
        Dim xCodigos As String
        Dim xPos1 As Integer = 0
        Dim xPos2 As Integer = 0
        Dim xPos3 As Integer = 0
        Dim xAncho As Integer = 0

        w_CodEmpBco = ""
        w_IdBanco = 0
        w_NroCta = 0


        xCodigos = xNode.Tag
        xPos1 = InStr(xCodigos, ":")
        xPos2 = InStr(xCodigos, "-")

        ' 01:A17-S1/W
        '   3   7  0
        If xPos1 = 0 And xPos2 = 0 Then
            w_CodEmpBco = xCodigos.Trim
        Else
            w_CodEmpBco = xCodigos.Substring(0, xPos1 - 1)
        End If

        If xPos1 > 0 And xPos2 = 0 Then
            xAncho = xCodigos.Length - xPos1
            w_IdBanco = Convert.ToInt32(xCodigos.Substring(xPos1, xAncho))
        End If

        'If xPos1 > 0 And xPos2 > 0 And xPos3 = 0 Then
        '    w_CodAlm = xCodigos.Substring(xPos1, xPos2 - (xPos1 + 1))
        '    xAncho = xCodigos.Length - xPos2
        '    w_CodSubAlm = xCodigos.Substring(xPos2, xAncho)
        'End If

        'If w_CodAlm = "A7" Then
        '    w_CodAlm = "A7"
        'End If

        If xPos1 > 0 And xPos2 > 0 Then
            w_IdBanco = xCodigos.Substring(xPos1, xPos2 - (xPos1 + 1))         
            xAncho = xCodigos.Length - xPos2
            w_NroCta = xCodigos.Substring(xPos2, xAncho)
        End If
    End Sub



    Private Function udfBuscaPermiso_CtaBco(ByVal pCodEmp As String, ByVal pIdBanco As Integer, ByVal pNroCta As Integer) As Boolean
        w_EmpFound = ""
        w_BcoFound = 0
        w_NCtaFound = 0


        '... crear indices (PK) 
        Dim xBuscarPK(2) As Object
        xBuscarPK(0) = pCodEmp
        xBuscarPK(1) = pIdBanco
        xBuscarPK(2) = pNroCta


        '... busca PK
        Dim xFoundRow As DataRow = dtPermisoCtaBco.Rows.Find(xBuscarPK)
        If Not (xFoundRow Is Nothing) Then
            '... PK encontrado
            w_EmpFound = pCodEmp
            w_BcoFound = pIdBanco
            w_NCtaFound = pNroCta

            Return True
        Else
            Return False
        End If
        'End If
    End Function

    Private Function udfBuscaPermiso_Banco(ByVal pCodEmp As String, ByVal pIdBanco As Integer) As Boolean
        '-- Busca si Banco esta asignado al usuario
        Dim xDr() As DataRow
        xDr = dtPermisoCtaBco.Select("CodEmpresa='" & pCodEmp & "' AND IdBanco=" & pIdBanco)
        If xDr.Length > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub pdu_CargarPermisosCtaBco()
        
        dtPermisoCtaBco = Nothing
        dtPermisoCtaBco = oWFUsuario.fdu_OA_CtaBcos_VerPorUser(wUsuario)
        If dtPermisoCtaBco IsNot Nothing Then
            ''-- creando indices del PK en tabla filtrada de Permisos
            Dim xCols(3) As DataColumn
            With dtPermisoCtaBco
                If Not .Columns("CodEmpresa") Is Nothing And _
                    Not .Columns("IdBanco") Is Nothing And _
                    Not .Columns("NroCuenta") Is Nothing Then
                    ' indexa columna
                    xCols(0) = .Columns("CodEmpresa")
                    xCols(1) = .Columns("IdBanco")
                    xCols(2) = .Columns("NroCuenta")                    
                    .PrimaryKey = xCols
                End If
            End With
        End If
        If dtPermisoCtaBco IsNot Nothing AndAlso dtPermisoCtaBco.Rows.Count > 0 Then

            '... Copia solo estructura datos para agregar Permisos Nuevos
            'dtPermisosNuevos = dtPermisos.Clone

            '-- Rescatando Codigo de Modulos
            Dim xLong As Integer = dtPermisoCtaBco.Rows.Count - 1
            Dim xCodEmpresa As String = ""
            'Dim xIdBanco As Integer = 0
            'Dim xNroCuenta As Integer = 0


            Dim xPos As Int16 = -1
            'Dim xPos1 As Int16 = -1
            'Dim xPos2 As Int16 = -1
            'Dim xPos3 As Int16 = -1

            ReDim aEmpresaBco(xLong)
            'ReDim aBanco(xLong)

            '--- Rescatando Codigos: Empresa, Almacen, SubAlmacen y RW
            For i = 0 To xLong
                If xCodEmpresa <> dtPermisoCtaBco.Rows(i).Item("CodEmpresa").ToString Then
                    xPos += 1
                    xCodEmpresa = dtPermisoCtaBco.Rows(i).Item("CodEmpresa")
                    aEmpresaBco(xPos) = xCodEmpresa
                End If
            Next

            ReDim Preserve aEmpresaBco(xPos)
            'ReDim Preserve aBanco(xPos1)
            
            '-- cargar las Cuentas de Bancos asignados al Usuario (Crea el arbol)
            udfCarga_tvCBD(tv_CBA, dtPermisoCtaBco)

            '-- Marca los Permisos de Cuentas asignadas al usuario (Marca el Check)
            udfMarcaPermisosEnCtaBcos()

            '-- Color de Fondo que indique actualizado
            tvwPermisos.BackColor = Drawing.Color.White
        Else
            pdu_LimpiarPermisosEnCtaBcos()
        End If

    End Sub

    Private Sub udfMarcaPermisosEnCtaBcos()
        If tv_CBD.Nodes.Count > 0 Then
            Dim NodoR As TreeNode
            RemoveHandler tv_CBD.AfterCheck, AddressOf tv_CBD_AfterCheck
            For Each NodoR In tv_CBD.Nodes
                udfExtraeCodigos_CtaBcos(NodoR)
                If w_CodEmpBco > 0 Then
                    If Array.IndexOf(aEmpresaBco, w_CodEmpBco) >= 0 Then
                        NodoR.Checked = True
                    Else
                        NodoR.Checked = False
                    End If
                End If
                '-- pone formato al nodo.
                udfFormatoCheck(NodoR, NodoR.Checked)

                '... Check Permiso en Nodos subordinados:
                'wEstadoDeCarga = True

                udfCheck_PermisoCtaBco(NodoR)
            Next
            AddHandler tv_CBD.AfterCheck, AddressOf tv_CBD_AfterCheck
        End If
    End Sub

    Private Sub pdu_LimpiarPermisosEnCtaBcos()
        '-- Limpieza del TreView de CtaBcos
        tv_CBA.Nodes.Clear()
        If tv_CBD.Nodes.Count > 0 Then
            Dim NodoR As TreeNode
            RemoveHandler tv_CBD.AfterCheck, AddressOf tv_CBD_AfterCheck
            For Each NodoR In tv_CBD.Nodes
                NodoR.Checked = False

                '-- pone formato al nodo.
                udfFormatoCheck(NodoR, NodoR.Checked)

                '... Clear Check Permiso en Nodos subordinados:
                pdu_ClearCheckNode(NodoR)
            Next
            AddHandler tv_CBD.AfterCheck, AddressOf tv_CBD_AfterCheck
        End If
    End Sub

    Private Sub tv_CBD_AfterCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tv_CBD.AfterCheck
        ' Merca/Desmarca Niveles de Acceso a modificar para el ROL.
        tv_CBA.BackColor = Drawing.Color.LightSteelBlue
        TreeCheckBoxes(tv_CBD, e.Node)
    End Sub

    Private Sub udfCopyDataCtaBco(ByVal Node As TreeNode)
        Dim i As Integer
        Dim nodX As TreeNode

        If Node.GetNodeCount(False) <> 0 Then
            nodX = Node.FirstNode
            For i = 0 To Node.GetNodeCount(False) - 1
                'nodX.Checked = bCheck
                If nodX.Checked Then
                    '... Extrae códigos
                    udfExtraeCodigos_CtaBcos(nodX)
                    If w_CodEmpBco.Length > 0 And w_IdBanco > 0 And w_NroCta > 0 Then
                        'Agregar Registro a tabla
                        Dim xDr As DataRow = dtPermisoCtaBcoNuevos.NewRow
                        xDr("CodEmpresa") = w_CodEmpBco
                        xDr("IdBanco") = w_IdBanco
                        xDr("NroCuenta") = w_NroCta
                        dtPermisoCtaBcoNuevos.Rows.Add(xDr)
                    End If
                End If
                '-- Aplicar Recursividad
                udfCopyDataCtaBco(nodX)
                nodX = nodX.NextNode
            Next
        End If
    End Sub



    Private Sub btnActualizaCtaBco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizaCtaBco.Click
        With tv_CBD

            dtPermisoCtaBcoNuevos = dtPermisoCtaBco.Clone
            ' Elimina columnas innecesarias            
            dtPermisoCtaBcoNuevos.Columns.Remove("Empresa")
            dtPermisoCtaBcoNuevos.Columns.Remove("Banco")
            dtPermisoCtaBcoNuevos.Columns.Remove("Cuenta")

            If .Nodes.Count > 0 Then
                Dim j As Int32
                Dim xXML As String

                For j = 0 To .Nodes.Count - 1
                    Dim xNode As TreeNode
                    xNode = .Nodes(j)
                    '... Check Permiso en Nodos subordinados
                    udfCopyDataCtaBco(xNode)
                Next
                '... Convertir Tabla a XML
                xXML = oWFUsuario.DataTableAXML(dtPermisoCtaBcoNuevos)
                '... Grabar Data en BD
                If oWFUsuario.fdu_OA_CtaBcos_EditarAcceso(wUsuario, xXML) Then
                    udfCargaCampos(True)
                    tv_CBA.BackColor = Drawing.Color.White
                End If
            End If
        End With
    End Sub

#End Region

#Region "Asistencia"
    Private Sub pdu_Cargar_AOE()
        dtCtaBco = oWFUsuario.fdu_OA_Asiste_Op_Y_Establec_Listar
        If Not dtCtaBco Is Nothing AndAlso dtCtaBco.Rows.Count > 0 Then
            '-- Cargar el TreeView
            udfCarga_tvAOE(tv_AOE_Lista, dtCtaBco)
        Else
            MsgBox("No existen Cta-Bancos registrados.")
            'Me.Close()
        End If
    End Sub

    Private Sub udfCarga_tvAOE(ByVal pTvwOpciones As TreeView, ByVal pDtOpciones As DataTable)
        '-- Limpieza de Nodos anteriores
        pTvwOpciones.Nodes.Clear()
        '-- Validación para carga de datos
        Cursor.Current = Cursors.WaitCursor
        If Not pDtOpciones Is Nothing AndAlso pDtOpciones.Rows.Count > 0 Then
            Dim dtEmp_Bco_Cta As DataTable
            Dim xDr() As DataRow

            w_CodEmpAOE = ""
            w_IdEstablecAOE = 0
            w_IdOperacAOE = 0

            '-- configura TreeView
            With pTvwOpciones
                .BeginUpdate()
                .ShowLines = True
                .ShowPlusMinus = True
                .ShowRootLines = True
                .HideSelection = False
                .HotTracking = False
            End With

            '-- Filtra Empresa, Almacen y Sub Almacen para creacion recursiva de Opciones
            xDr = pDtOpciones.Select("IdOperacion>0", "Empresa,Establecimiento,Operacion")
            If xDr.Length > 0 Then
                dtEmp_Bco_Cta = xDr.CopyToDataTable

                '-- En recorrido, segun encuentre va creando los nodos
                For Each xR As DataRow In dtEmp_Bco_Cta.Rows ' pDtOpciones.Rows
                    If xR.Item("CodEmpresa") <> w_CodEmpAOE Then
                        w_CodEmpAOE = xR.Item("CodEmpresa")
                        udfCrea_TnEmpAOE(pTvwOpciones, w_CodEmpAOE, xR.Item("Empresa"))
                        w_IdEstablecAOE = 0
                    End If
                    If w_IdEstablecAOE <> xR.Item("IDEstablec") Then
                        w_IdEstablecAOE = xR.Item("IDEstablec")
                        udfCrea_TnEstablecAOE(w_CodEmpAOE, w_IdEstablecAOE, xR.Item("Establecimiento"))
                        w_IdOperacAOE = 0
                    End If
                    If w_IdOperacAOE <> xR.Item("IdOperacion") Then
                        w_IdOperacAOE = xR.Item("IdOperacion")
                        udfCrea_TnOperacAOE(w_CodEmpAOE, w_IdEstablecAOE, w_IdOperacAOE, xR.Item("Operacion"))
                    End If
                Next
            End If
            pTvwOpciones.EndUpdate()
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub udfCrea_TnEmpAOE(ByRef pTvwOpciones As TreeView, ByVal pCodEmpresa As String, ByVal pEmpresa As String)
        Dim xKey As String
        xKey = pCodEmpresa
        wTn_EmpAOE = New TreeNode(pEmpresa)
        With wTn_EmpAOE
            .Tag = xKey
            .ForeColor = Drawing.Color.Navy
            .NodeFont = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold) ', System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End With
        pTvwOpciones.Nodes.Add(wTn_EmpAOE)
    End Sub

    Private Sub udfCrea_TnEstablecAOE(ByVal pCodEmpresa As String, ByVal pIdBanco As Integer, ByVal pBanco As String)
        Dim xKey As String
        xKey = pCodEmpresa & ":" & pIdBanco.ToString
        wTn_EstablecAOE = New TreeNode(pBanco)
        With wTn_EstablecAOE
            .Tag = xKey
            .ForeColor = Drawing.Color.Navy
            .NodeFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold) ', System.Drawing.GraphicsUnit.Point, CType(0, Byte))            
        End With
        wTn_EmpAOE.Nodes.Add(wTn_EstablecAOE)
        wTn_EmpAOE.Expand()
    End Sub

    Private Sub udfCrea_TnOperacAOE(ByVal pCodEmpresa As String, ByVal pIdBanco As Integer, ByVal pNroCuenta As Integer, ByVal pCuenta As String)
        Dim xKey As String
        xKey = pCodEmpresa & ":" & pIdBanco.ToString & "-" & pNroCuenta.ToString
        wTn_OperacAOE = New TreeNode(pCuenta)
        With wTn_OperacAOE
            .Tag = xKey
            .ForeColor = Drawing.Color.Navy
            .NodeFont = New System.Drawing.Font("Tahoma", 7.75!, System.Drawing.FontStyle.Regular) ', System.Drawing.GraphicsUnit.Point, CType(0, Byte))            
        End With
        wTn_EstablecAOE.Nodes.Add(wTn_OperacAOE)
        wTn_EstablecAOE.Expand()
    End Sub

    Private Sub udfCheck_PermisoAOE(ByVal Node As TreeNode)
        Dim nodX As TreeNode
        'Dim xPosEmp As Long
        For Each nodX In Node.Nodes
            '.. extrayendo codigos
            udfExtraeCodigos_AOE(nodX)
            If w_CodEmpAOE.Length > 0 And w_IdEstablecAOE > 0 And w_IdOperacAOE > 0 Then
                '... Verifica si Permiso está en Opción: Marca / Desmarca
                nodX.Checked = udfBuscaPermiso_OperacAOE(w_CodEmpAOE, w_IdEstablecAOE, w_IdOperacAOE)
            ElseIf w_CodEmpAOE.Length > 0 And w_IdEstablecAOE > 0 Then
                '... Verifica si tiene acceso al sub Almacen
                nodX.Checked = udfBuscaPermiso_EstablecAOE(w_CodEmpAOE, w_IdEstablecAOE)
            ElseIf w_CodEmpAOE.Length > 0 Then
                If Array.IndexOf(aEmpresaAOE, w_CodEmpAOE, 0) >= 0 Then
                    nodX.Checked = True
                Else
                    nodX.Checked = False
                End If
            End If
            '-- pone formato al nodo.
            udfFormatoCheck(nodX, nodX.Checked)
            '... invocación recursiva
            udfCheck_PermisoAOE(nodX)
        Next
    End Sub

    Private Sub udfExtraeCodigos_AOE(ByRef xNode As TreeNode)
        Dim xCodigos As String
        Dim xPos1 As Integer = 0
        Dim xPos2 As Integer = 0
        Dim xPos3 As Integer = 0
        Dim xAncho As Integer = 0

        w_CodEmpAOE = ""
        w_IdEstablecAOE = 0
        w_IdOperacAOE = 0


        xCodigos = xNode.Tag
        xPos1 = InStr(xCodigos, ":")
        xPos2 = InStr(xCodigos, "-")

        ' 01:A17-S1/W
        '   3   7  0
        If xPos1 = 0 And xPos2 = 0 Then
            w_CodEmpAOE = xCodigos.Trim
        Else
            w_CodEmpAOE = xCodigos.Substring(0, xPos1 - 1)
        End If

        If xPos1 > 0 And xPos2 = 0 Then
            xAncho = xCodigos.Length - xPos1
            w_IdEstablecAOE = Convert.ToInt32(xCodigos.Substring(xPos1, xAncho))
        End If

        If xPos1 > 0 And xPos2 > 0 Then
            w_IdEstablecAOE = xCodigos.Substring(xPos1, xPos2 - (xPos1 + 1))
            xAncho = xCodigos.Length - xPos2
            w_IdOperacAOE = xCodigos.Substring(xPos2, xAncho)
        End If
    End Sub

    Private Function udfBuscaPermiso_OperacAOE(ByVal pCodEmp As String, ByVal pIdEstablec As Integer, ByVal pIdOperac As Integer) As Boolean
        w_EmpFound = ""
        w_BcoFound = 0
        w_NCtaFound = 0

        '... crear indices (PK) 
        Dim xBuscarPK(2) As Object
        xBuscarPK(0) = pCodEmp
        xBuscarPK(1) = pIdEstablec
        xBuscarPK(2) = pIdOperac


        '... busca PK
        Dim xFoundRow As DataRow = dtPermisoAOE.Rows.Find(xBuscarPK)
        If Not (xFoundRow Is Nothing) Then
            '... PK encontrado
            w_EmpFound = pCodEmp
            w_BcoFound = pIdEstablec
            w_NCtaFound = pIdOperac

            Return True
        Else
            Return False
        End If
        'End If
    End Function

    Private Function udfBuscaPermiso_EstablecAOE(ByVal pCodEmp As String, ByVal pIdEstablec As Integer) As Boolean
        '-- Busca si Banco esta asignado al usuario
        Dim xDr() As DataRow
        xDr = dtPermisoAOE.Select("CodEmpresa='" & pCodEmp & "' AND IDEstablec=" & pIdEstablec)
        If xDr.Length > 0 Then
            Return True
        Else
            Return False
        End If
    End Function


    Private Sub pdu_CargarPermisosAOE() ' Asistencia de Operación x Establecimiento.
        dtPermisoAOE = Nothing
        dtPermisoAOE = oWFUsuario.fdu_OA_Asiste_Op_Y_Establec_VerPorUser(wUsuario)
        If dtPermisoAOE IsNot Nothing Then
            ''-- creando indices del PK en tabla filtrada de Permisos
            Dim xCols(3) As DataColumn
            With dtPermisoAOE
                If Not .Columns("IDEstablec") Is Nothing And _
                    Not .Columns("IdOperacion") Is Nothing And _
                    Not .Columns("CodEmpresa") Is Nothing Then
                    ' indexa columna
                    xCols(0) = .Columns("CodEmpresa")
                    xCols(1) = .Columns("IDEstablec")
                    xCols(2) = .Columns("IdOperacion")
                    .PrimaryKey = xCols
                End If
            End With
        End If
        If dtPermisoAOE IsNot Nothing AndAlso dtPermisoAOE.Rows.Count > 0 Then
            '-- Rescatando Codigo de Modulos
            Dim xLong As Integer = dtPermisoAOE.Rows.Count - 1
            Dim xCodEmpresa As String = ""
            Dim xPos As Int16 = -1

            ReDim aEmpresaAOE(xLong)
            'ReDim aBanco(xLong)

            '--- Rescatando Codigos: Empresa, Almacen, SubAlmacen y RW
            For i = 0 To xLong
                If xCodEmpresa <> dtPermisoAOE.Rows(i).Item("CodEmpresa").ToString Then
                    xPos += 1
                    xCodEmpresa = dtPermisoAOE.Rows(i).Item("CodEmpresa")
                    aEmpresaAOE(xPos) = xCodEmpresa
                End If
            Next

            ReDim Preserve aEmpresaAOE(xPos)
            'ReDim Preserve aBanco(xPos1)

            '-- cargar las Cuentas de Bancos asignados al Usuario (Crea el arbol)
            udfCarga_tvAOE(tv_AOE_Acceso, dtPermisoAOE)

            '-- Marca los Permisos de Cuentas asignadas al usuario (Marca el Check)
            udfMarcaPermisosEnAOE()

            '-- Color de Fondo que indique actualizado
            tv_AOE_Acceso.BackColor = Drawing.Color.White
        Else
            pdu_LimpiarPermisosEnAOE()
        End If

        '-- Cargar Resumen por Plla de Asistencia por Operaciones por usuario.
        pdu_DgvAsistResumPlla_Cargar()
        'Dim xDtResum As DataTable = oWFUsuario.fdu_OA_Asiste_ResumPlla_VerPorUser(wUsuario)
        'If xDtResum IsNot Nothing Then
        '    dgvAsistResumPlla.DataSource = xDtResum
        '    pdu_DgvAsistResumPlla_Format()
        'Else
        '    dgvAsistResumPlla.DataSource = Nothing
        'End If
    End Sub

    Private Sub udfMarcaPermisosEnAOE()
        If tv_AOE_Lista.Nodes.Count > 0 Then
            Dim NodoR As TreeNode
            RemoveHandler tv_AOE_Lista.AfterCheck, AddressOf tv_AOE_Lista_AfterCheck
            For Each NodoR In tv_AOE_Lista.Nodes
                udfExtraeCodigos_AOE(NodoR)
                If w_CodEmpAOE > 0 Then
                    If Array.IndexOf(aEmpresaAOE, w_CodEmpAOE) >= 0 Then
                        NodoR.Checked = True
                    Else
                        NodoR.Checked = False
                    End If
                End If
                '-- pone formato al nodo.
                udfFormatoCheck(NodoR, NodoR.Checked)

                '... Check Permiso en Nodos subordinados:
                'wEstadoDeCarga = True

                udfCheck_PermisoAOE(NodoR)
            Next
            AddHandler tv_AOE_Lista.AfterCheck, AddressOf tv_AOE_Lista_AfterCheck
        End If
    End Sub

    Private Sub pdu_LimpiarPermisosEnAOE()
        '-- Limpieza del TreView de Asistencia-Op-Est
        tv_AOE_Acceso.Nodes.Clear()
        If tv_AOE_Lista.Nodes.Count > 0 Then
            Dim NodoR As TreeNode
            RemoveHandler tv_AOE_Lista.AfterCheck, AddressOf tv_AOE_Lista_AfterCheck
            For Each NodoR In tv_AOE_Lista.Nodes
                NodoR.Checked = False
                '-- pone formato al nodo.
                udfFormatoCheck(NodoR, NodoR.Checked)
                '... Clear Check Permiso en Nodos subordinados:
                pdu_ClearCheckNode(NodoR)
            Next
            AddHandler tv_AOE_Lista.AfterCheck, AddressOf tv_AOE_Lista_AfterCheck
        End If
    End Sub

    Private Sub tv_AOE_Lista_AfterCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tv_AOE_Lista.AfterCheck
        ' Merca/Desmarca Niveles de Acceso a modificar para el ROL.
        tv_AOE_Acceso.BackColor = Drawing.Color.LightSteelBlue
        TreeCheckBoxes(tv_AOE_Lista, e.Node)
    End Sub

    Private Sub udfCopyDataAOE(ByVal Node As TreeNode)
        Dim i As Integer
        Dim nodX As TreeNode

        If Node.GetNodeCount(False) <> 0 Then
            nodX = Node.FirstNode
            For i = 0 To Node.GetNodeCount(False) - 1
                'nodX.Checked = bCheck
                If nodX.Checked Then
                    '... Extrae códigos
                    udfExtraeCodigos_AOE(nodX)
                    If w_CodEmpAOE.Length > 0 And w_IdEstablecAOE > 0 And w_IdOperacAOE > 0 Then
                        'Agregar Registro a tabla
                        Dim xDr As DataRow = dtPermisoAOENuevos.NewRow
                        xDr("CodEmpresa") = w_CodEmpAOE
                        xDr("IDEstablec") = w_IdEstablecAOE
                        xDr("IdOperacion") = w_IdOperacAOE
                        dtPermisoAOENuevos.Rows.Add(xDr)
                    End If
                End If
                '-- Aplicar Recursividad
                udfCopyDataAOE(nodX)
                nodX = nodX.NextNode
            Next
        End If
    End Sub



    Private Sub btnActualizaAOE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizaAOE.Click
        With tv_AOE_Lista

            dtPermisoAOENuevos = dtPermisoAOE.Clone
            ' Elimina columnas innecesarias            
            dtPermisoAOENuevos.Columns.Remove("Empresa")
            dtPermisoAOENuevos.Columns.Remove("Establecimiento")
            dtPermisoAOENuevos.Columns.Remove("Operacion")

            If .Nodes.Count > 0 Then
                Dim j As Int32
                Dim xXML As String

                For j = 0 To .Nodes.Count - 1
                    Dim xNode As TreeNode
                    xNode = .Nodes(j)
                    '... Check Permiso en Nodos subordinados
                    udfCopyDataAOE(xNode)
                Next
                '... Convertir Tabla a XML
                xXML = oWFUsuario.DataTableAXML(dtPermisoAOENuevos)
                '... Grabar Data en BD
                If oWFUsuario.fdu_OA_Asiste_Op_Y_Establec_EditarAcceso(wUsuario, xXML) Then
                    udfCargaCampos(True)
                    tv_AOE_Acceso.BackColor = Drawing.Color.White
                End If
            End If
        End With
    End Sub

    

#End Region

    
    
    Private Sub chlbEmpCajas_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chlbEmpCajas.ItemCheck
        If Not wEditar Then
            chlbEmpCajas.BackColor = Drawing.Color.LightSteelBlue
        End If
    End Sub

    Private Sub chlbEmpCompra_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chlbEmpCompra.ItemCheck
        If Not wEditar Then
            chlbEmpCompra.BackColor = Drawing.Color.LightSteelBlue
        End If
    End Sub

    Private Sub chlbEmpCtble_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chlbEmpCtble.ItemCheck
        If Not wEditar Then
            chlbEmpCtble.BackColor = Drawing.Color.LightSteelBlue
        End If
    End Sub

    Private Sub btnActEmpCtble_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActEmpCtble.Click

        Dim xDt As New DataTable
        xDt.Columns.Add("CodEmpresa")

        For Each chb As DataRowView In chlbEmpCtble.CheckedItems
            xDt.Rows.Add(chb.Item("CodEmpresa"))
        Next

        Dim xmlDatos As String = ""
        If xDt.Rows.Count > 0 Then
            xmlDatos = oWFUsuario.DataTableAXML(xDt)
        End If

        If oWFUsuario.fdu_OA_EmpCtble_EditarAcceso(wUsuario, xmlDatos) Then
            chlbEmpCtble.BackColor = Drawing.Color.White
        End If
    End Sub

    Private Sub chkSeriesGRT_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chkSeriesGRT.ItemCheck
        If Not wEditar Then
            chkSeriesGRT.BackColor = Drawing.Color.LightSteelBlue
        End If
    End Sub

    
#Region "GRT Series"
    Dim dtGRTSeries As DataTable
    Dim dtEmp_GRTS As DataTable
    Dim w_CodEmpGRTS As String
    Dim w_IdEstablecGRTS As Integer
    Dim w_SerieGRTS As Integer
    Dim wTn_EmpGRTS As TreeNode
    Dim wTn_EstablecGRTS As TreeNode
    Dim wTn_AgenteGRTS As TreeNode
    Dim aEmpresaGRTS() As String

    Dim w_EstablecGRTFound As Integer
    Dim w_SerieGRTFound As Integer

    Dim dtPermisoGRTS As DataTable
    Dim dtPermisoGRTNuevos As DataTable

    Private Sub pdu_Cargar_GRTSeries()
        dtGRTSeries = oWFUsuario.fdu_OA_GRTSeries_Listado
        If Not dtGRTSeries Is Nothing AndAlso dtGRTSeries.Rows.Count > 0 Then
            '-- Cargar el TreeView
            udfCarga_tvGRTSeries(tv_GRTS_Opciones, dtGRTSeries)
        Else
            MsgBox("No existen GRT-Series registrados.")
            'Me.Close()
        End If
    End Sub

    Private Sub udfCarga_tvGRTSeries(ByVal pTvwOpciones As TreeView, ByVal pDtOpciones As DataTable)
        '-- Limpieza de Nodos anteriores
        pTvwOpciones.Nodes.Clear()
        '-- Validación para carga de datos
        Cursor.Current = Cursors.WaitCursor
        If Not pDtOpciones Is Nothing AndAlso pDtOpciones.Rows.Count > 0 Then
            Dim dtEmp_GRTS As DataTable
            Dim xDr() As DataRow

            w_CodEmpGRTS = ""
            w_IdEstablecGRTS = 0
            w_SerieGRTS = 0

            '-- configura TreeView
            With pTvwOpciones
                .BeginUpdate()
                .ShowLines = True
                .ShowPlusMinus = True
                .ShowRootLines = True
                .HideSelection = False
                .HotTracking = False
            End With

            '-- Filtra Empresa, Establecimiento y GRTSeries para creacion recursiva de Opciones
            xDr = pDtOpciones.Select("IDEstablec>0", "CodEmpresa,IDEstablec,SerieGRT")
            If xDr.Length > 0 Then
                dtEmp_GRTS = xDr.CopyToDataTable

                'dtOpcionesNodos = pDtOpciones.Copy
                '-- En recorrido, segun encuentre va creando los nodos
                For Each xR As DataRow In dtEmp_GRTS.Rows ' pDtOpciones.Rows
                    If xR.Item("CodEmpresa") <> w_CodEmpGRTS Then
                        w_CodEmpGRTS = xR.Item("CodEmpresa")
                        udfCrea_TnEmpGRTS(pTvwOpciones, w_CodEmpGRTS, xR.Item("Empresa"))
                        w_IdEstablecGRTS = 0
                    End If
                    If w_IdEstablecGRTS <> xR.Item("IdEstablec") Then
                        w_IdEstablecGRTS = xR.Item("IdEstablec")
                        udfCrea_TnEstablecGRTS(w_CodEmpGRTS, w_IdEstablecGRTS, xR.Item("Establecimiento"))
                        w_SerieGRTS = 0
                    End If
                    'If w_CodSubAlm <> xR.Item("CodSubAlm") Then
                    '    w_CodSubAlm = xR.Item("CodSubAlm")
                    '    udfCrea_TnSubAlmacen(w_CodEmpBco, w_CodAlm, w_CodSubAlm, xR.Item("SubAlmacen"))
                    '    w_Nodo = ""
                    'End If
                    If w_SerieGRTS <> xR.Item("SerieGRT") Then
                        w_SerieGRTS = xR.Item("SerieGRT")
                        udfCrea_TnAgenteGRTS(w_CodEmpGRTS, w_IdEstablecGRTS, w_SerieGRTS, xR.Item("AgenteGRT"))
                    End If
                Next
            End If
            pTvwOpciones.EndUpdate()
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub udfCrea_TnEmpGRTS(ByRef pTvwOpciones As TreeView, ByVal pCodEmpresa As String, ByVal pEmpresa As String)
        Dim xKey As String
        xKey = pCodEmpresa
        wTn_EmpGRTS = New TreeNode(pEmpresa)
        With wTn_EmpGRTS
            .Tag = xKey
            .ForeColor = Drawing.Color.Navy
            .NodeFont = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold) ', System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End With
        pTvwOpciones.Nodes.Add(wTn_EmpGRTS)
    End Sub

    Private Sub udfCrea_TnEstablecGRTS(ByVal pCodEmpresa As String, ByVal pIdEstablec As Integer, ByVal pEstablec As String)
        Dim xKey As String
        xKey = pCodEmpresa & ":" & pIdEstablec.ToString
        wTn_EstablecGRTS = New TreeNode(pEstablec)
        With wTn_EstablecGRTS
            .Tag = xKey
            .ForeColor = Drawing.Color.Navy
            .NodeFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold) ', System.Drawing.GraphicsUnit.Point, CType(0, Byte))            
        End With
        wTn_EmpGRTS.Nodes.Add(wTn_EstablecGRTS)
        wTn_EmpGRTS.Expand()
    End Sub

    Private Sub udfCrea_TnAgenteGRTS(ByVal pCodEmpresa As String, ByVal pIdEstablec As Integer, ByVal pSerieGRT As Integer, ByVal pAgenteGRT As String)
        Dim xKey As String
        xKey = pCodEmpresa & ":" & pIdEstablec.ToString & "-" & pSerieGRT.ToString
        wTn_AgenteGRTS = New TreeNode(pAgenteGRT)
        With wTn_AgenteGRTS
            .Tag = xKey
            .ForeColor = Drawing.Color.Navy
            .NodeFont = New System.Drawing.Font("Tahoma", 7.75!, System.Drawing.FontStyle.Regular) ', System.Drawing.GraphicsUnit.Point, CType(0, Byte))            
        End With
        wTn_EstablecGRTS.Nodes.Add(wTn_AgenteGRTS)
        wTn_EstablecGRTS.Expand()
    End Sub

    Private Sub udfCheck_PermisoGRT(ByVal Node As TreeNode)
        Dim nodX As TreeNode
        'Dim xPosEmp As Long
        For Each nodX In Node.Nodes
            '.. extrayendo codigos
            udfExtraeCodigos_SerieGRTS(nodX)
            If w_CodEmpGRTS.Length > 0 And w_IdEstablecGRTS > 0 And w_SerieGRTS > 0 Then
                '... Verifica si Permiso está en Opción: Marca / Desmarca
                nodX.Checked = udfBuscaPermiso_SerieGRTS(w_CodEmpGRTS, w_IdEstablecGRTS, w_SerieGRTS)
            ElseIf w_CodEmpGRTS.Length > 0 And w_IdEstablecGRTS > 0 Then
                '... Verifica si tiene acceso al sub Almacen
                nodX.Checked = udfBuscaPermiso_EstablecGRT(w_CodEmpGRTS, w_IdEstablecGRTS)
            ElseIf w_CodEmpGRTS.Length > 0 Then
                '    Dim xPosAlm As Long
                '    xPosAlm = Array.IndexOf(aAlmacen, w_CodAlm, 0)
                '    xPosEmp = Array.IndexOf(aEmpresa, w_CodEmpBco, 0)
                '    If xPosAlm >= 0 And xPosEmp >= 0 Then
                '        nodX.Checked = True
                '    Else
                '        nodX.Checked = False
                '    End If
                'ElseIf w_CodEmpBco.Length > 0 Then
                'xPosEmp = Array.IndexOf(aEmpresaGRTS, w_CodEmpGRTS, 0)
                If Array.IndexOf(aEmpresaGRTS, w_CodEmpGRTS, 0) >= 0 Then
                    nodX.Checked = True
                Else
                    nodX.Checked = False
                End If
            End If
            '-- pone formato al nodo.
            udfFormatoCheck(nodX, nodX.Checked)
            '... invocación recursiva
            udfCheck_PermisoGRT(nodX)
        Next
    End Sub

    Private Sub udfExtraeCodigos_SerieGRTS(ByRef xNode As TreeNode)
        Dim xCodigos As String
        Dim xPos1 As Integer = 0
        Dim xPos2 As Integer = 0
        Dim xPos3 As Integer = 0
        Dim xAncho As Integer = 0

        w_CodEmpGRTS = ""
        w_IdEstablecGRTS = 0
        w_SerieGRTS = 0


        xCodigos = xNode.Tag
        xPos1 = InStr(xCodigos, ":")
        xPos2 = InStr(xCodigos, "-")

        ' 01:A17-S1/W
        '   3   7  0
        If xPos1 = 0 And xPos2 = 0 Then
            w_CodEmpGRTS = xCodigos.Trim
        Else
            w_CodEmpGRTS = xCodigos.Substring(0, xPos1 - 1)
        End If

        If xPos1 > 0 And xPos2 = 0 Then
            xAncho = xCodigos.Length - xPos1
            w_IdEstablecGRTS = Convert.ToInt32(xCodigos.Substring(xPos1, xAncho))
        End If

        'If xPos1 > 0 And xPos2 > 0 And xPos3 = 0 Then
        '    w_CodAlm = xCodigos.Substring(xPos1, xPos2 - (xPos1 + 1))
        '    xAncho = xCodigos.Length - xPos2
        '    w_CodSubAlm = xCodigos.Substring(xPos2, xAncho)
        'End If

        'If w_CodAlm = "A7" Then
        '    w_CodAlm = "A7"
        'End If

        If xPos1 > 0 And xPos2 > 0 Then
            w_IdEstablecGRTS = xCodigos.Substring(xPos1, xPos2 - (xPos1 + 1))
            xAncho = xCodigos.Length - xPos2
            w_SerieGRTS = xCodigos.Substring(xPos2, xAncho)
        End If
    End Sub

    Private Function udfBuscaPermiso_SerieGRTS(ByVal pCodEmp As String, ByVal pIdEstablec As Integer, ByVal pSerieGRT As Integer) As Boolean
        w_EmpFound = ""
        w_EstablecGRTFound = 0
        w_SerieGRTFound = 0

        '... crear indices (PK) 
        Dim xBuscarPK(2) As Object
        xBuscarPK(0) = pCodEmp
        xBuscarPK(1) = pIdEstablec
        xBuscarPK(2) = pSerieGRT

        '... busca PK
        Dim xFoundRow As DataRow = dtPermisoGRTS.Rows.Find(xBuscarPK)
        If Not (xFoundRow Is Nothing) Then
            '... PK encontrado
            w_EmpFound = pCodEmp
            w_EstablecGRTFound = pIdEstablec
            w_SerieGRTFound = pSerieGRT
            Return True
        Else
            Return False
        End If        
    End Function

    Private Function udfBuscaPermiso_EstablecGRT(ByVal pCodEmp As String, ByVal pIdEstablec As Integer) As Boolean
        '-- Busca si Estableceimiento esta asignado al usuario
        Dim xDr() As DataRow
        xDr = dtPermisoGRTS.Select("CodEmpresa='" & pCodEmp & "' AND IdEstablec=" & pIdEstablec)
        If xDr.Length > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub pdu_CargarPermisos_SerieGRTS()

        dtPermisoGRTS = Nothing
        dtPermisoGRTS = oWFUsuario.fdu_OA_GRTSeries_VerPorUser(wUsuario)
        If dtPermisoGRTS IsNot Nothing Then
            ''-- creando indices del PK en tabla filtrada de Permisos
            Dim xCols(3) As DataColumn
            With dtPermisoGRTS
                If Not .Columns("CodEmpresa") Is Nothing And _
                    Not .Columns("IdEstablec") Is Nothing And _
                    Not .Columns("SerieGRT") Is Nothing Then
                    ' indexa columna
                    xCols(0) = .Columns("CodEmpresa")
                    xCols(1) = .Columns("IdEstablec")
                    xCols(2) = .Columns("SerieGRT")
                    .PrimaryKey = xCols
                End If
            End With
        End If
        If dtPermisoGRTS IsNot Nothing AndAlso dtPermisoGRTS.Rows.Count > 0 Then
            '... Copia solo estructura datos para agregar Permisos Nuevos
            'dtPermisosNuevos = dtPermisos.Clone

            '-- Rescatando Codigo de Modulos
            Dim xLong As Integer = dtPermisoGRTS.Rows.Count - 1
            Dim xCodEmpresa As String = ""
            'Dim xIdEstablec As Integer = 0
            'Dim xSerieGRT As Integer = 0


            Dim xPos As Int16 = -1
            'Dim xPos1 As Int16 = -1
            'Dim xPos2 As Int16 = -1
            'Dim xPos3 As Int16 = -1

            ReDim aEmpresaGRTS(xLong)
            'ReDim aBanco(xLong)

            '--- Rescatando Codigos: Empresa, Establecimiento y SerieGRT
            For i = 0 To xLong
                If xCodEmpresa <> dtPermisoGRTS.Rows(i).Item("CodEmpresa").ToString Then
                    xPos += 1
                    xCodEmpresa = dtPermisoGRTS.Rows(i).Item("CodEmpresa")
                    aEmpresaGRTS(xPos) = xCodEmpresa
                End If
            Next

            ReDim Preserve aEmpresaGRTS(xPos)
            'ReDim Preserve aBanco(xPos1)

            '-- cargar las Cuentas de Bancos asignados al Usuario (Crea el arbol)
            udfCarga_tvGRTSeries(tv_GRTS_Permisos, dtPermisoGRTS)

            '-- Marca los Permisos de Cuentas asignadas al usuario (Marca el Check)
            udfMarcaPermisosEnSeriesGRT()

            '-- Color de Fondo que indique actualizado
            tvwPermisos.BackColor = Drawing.Color.White
        Else
            pdu_LimpiarPermisosEnSeriesGRT()
        End If
    End Sub

    Private Sub udfMarcaPermisosEnSeriesGRT()
        If tv_GRTS_Opciones.Nodes.Count > 0 Then
            Dim NodoR As TreeNode
            RemoveHandler tv_GRTS_Opciones.AfterCheck, AddressOf tv_GRTS_Opciones_AfterCheck
            For Each NodoR In tv_GRTS_Opciones.Nodes
                udfExtraeCodigos_SerieGRTS(NodoR)
                If w_CodEmpGRTS > 0 Then
                    If Array.IndexOf(aEmpresaGRTS, w_CodEmpGRTS) >= 0 Then
                        NodoR.Checked = True
                    Else
                        NodoR.Checked = False
                    End If
                End If
                '-- pone formato al nodo.
                udfFormatoCheck(NodoR, NodoR.Checked)

                '... Check Permiso en Nodos subordinados:
                'wEstadoDeCarga = True

                udfCheck_PermisoGRT(NodoR)
            Next
            AddHandler tv_GRTS_Opciones.AfterCheck, AddressOf tv_GRTS_Opciones_AfterCheck
        End If
    End Sub

    Private Sub pdu_LimpiarPermisosEnSeriesGRT()
        '-- Limpieza del TreView de Permisos en GRTs
        tv_GRTS_Permisos.Nodes.Clear()
        If tv_GRTS_Opciones.Nodes.Count > 0 Then
            Dim NodoR As TreeNode
            RemoveHandler tv_GRTS_Opciones.AfterCheck, AddressOf tv_GRTS_Opciones_AfterCheck
            For Each NodoR In tv_GRTS_Opciones.Nodes
                NodoR.Checked = False

                '-- pone formato al nodo.
                udfFormatoCheck(NodoR, NodoR.Checked)

                '... Clear Check Permiso en Nodos subordinados:
                pdu_ClearCheckNode(NodoR)
            Next
            AddHandler tv_GRTS_Opciones.AfterCheck, AddressOf tv_GRTS_Opciones_AfterCheck
        End If
    End Sub

    Private Sub tv_GRTS_Opciones_AfterCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tv_GRTS_Opciones.AfterCheck
        ' Merca/Desmarca Niveles de Acceso a modificar para el ROL.
        tv_GRTS_Permisos.BackColor = Drawing.Color.LightSteelBlue
        TreeCheckBoxes(tv_GRTS_Opciones, e.Node)
    End Sub

    Private Sub udfCopyDataSerieGRT(ByVal Node As TreeNode)
        Dim i As Integer
        Dim nodX As TreeNode

        If Node.GetNodeCount(False) <> 0 Then
            nodX = Node.FirstNode
            For i = 0 To Node.GetNodeCount(False) - 1
                'nodX.Checked = bCheck
                If nodX.Checked Then
                    '... Extrae códigos
                    udfExtraeCodigos_SerieGRTS(nodX)
                    If w_CodEmpGRTS.Length > 0 And w_IdEstablecGRTS > 0 And w_SerieGRTS > 0 Then
                        'Agregar Registro a tabla
                        Dim xDr As DataRow = dtPermisoGRTNuevos.NewRow
                        xDr("CodEmpresa") = w_CodEmpGRTS
                        xDr("IdEstablec") = w_IdEstablecGRTS
                        xDr("SerieGRT") = w_SerieGRTS
                        dtPermisoGRTNuevos.Rows.Add(xDr)
                    End If
                End If
                '-- Aplicar Recursividad
                udfCopyDataSerieGRT(nodX)
                nodX = nodX.NextNode
            Next
        End If
    End Sub

    Private Sub btnActualizaGRTSeries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizaGRTSeries.Click
        If dtPermisoGRTS Is Nothing Then Return
        With tv_GRTS_Opciones
            dtPermisoGRTNuevos = dtPermisoGRTS.Clone
            ' Elimina columnas innecesarias             
            dtPermisoGRTNuevos.Columns.Remove("Empresa")
            dtPermisoGRTNuevos.Columns.Remove("Establecimiento")
            dtPermisoGRTNuevos.Columns.Remove("AgenteGRT")

            If .Nodes.Count > 0 Then
                Dim j As Int32
                Dim xXML As String

                For j = 0 To .Nodes.Count - 1
                    Dim xNode As TreeNode
                    xNode = .Nodes(j)
                    '... Check Permiso en Nodos subordinados
                    udfCopyDataSerieGRT(xNode)
                Next
                '... Convertir Tabla a XML
                xXML = oWFUsuario.DataTableAXML(dtPermisoGRTNuevos)
                '... Grabar Data en BD
                If oWFUsuario.fdu_OA_GRTSeries_EditarAcceso(wUsuario, xXML) Then
                    udfCargaCampos(True)
                    tv_GRTS_Permisos.BackColor = Drawing.Color.White
                End If
            End If
        End With
    End Sub

#End Region


#Region "Venta Series"
    Dim dtVtaSeries As DataTable
    Dim dtEmp_Vta As DataTable
    Dim w_CodEmpVtaS As String
    Dim w_IdEstablecVtaS As Integer
    Dim w_CodDoctoVtaS As String
    Dim w_SerieVtaS As Integer
    Dim wTn_EmpVtaS As TreeNode
    Dim wTn_EstablecVtaS As TreeNode
    Dim wTn_DcmtoVtaS As TreeNode
    Dim wTn_SerieVtaS As TreeNode
    Dim aEmpresaVtaS() As String

    Dim w_EstablecVtaFound As Integer
    Dim w_CodDoctoVtaFound As String
    Dim w_SerieVtaFound As Integer

    Dim dtPermisoVtaS As DataTable
    Dim dtPermisoVtaNuevos As DataTable

    Private Sub pdu_Cargar_VtaSeries()
        dtVtaSeries = oWFUsuario.fdu_OA_VtaSeries_Listado
        If Not dtVtaSeries Is Nothing AndAlso dtVtaSeries.Rows.Count > 0 Then
            '-- Cargar el TreeView
            udfCarga_tvVtaSeries(tv_VtaS_Opciones, dtVtaSeries)
        Else
            MsgBox("No existen Vta-Series registrados.")
            'Me.Close()
        End If
    End Sub

    Private Sub udfCarga_tvVtaSeries(ByVal pTvwOpciones As TreeView, ByVal pDtOpciones As DataTable)
        '-- Limpieza de Nodos anteriores
        pTvwOpciones.Nodes.Clear()
        '-- Validación para carga de datos
        Cursor.Current = Cursors.WaitCursor
        If Not pDtOpciones Is Nothing AndAlso pDtOpciones.Rows.Count > 0 Then
            Dim dtEmp_VtaS As DataTable
            Dim xDr() As DataRow

            w_CodEmpVtaS = ""
            w_IdEstablecVtaS = 0
            w_CodDoctoVtaS = ""
            w_SerieVtaS = 0

            '-- configura TreeView
            With pTvwOpciones
                .BeginUpdate()
                .ShowLines = True
                .ShowPlusMinus = True
                .ShowRootLines = True
                .HideSelection = False
                .HotTracking = False
            End With

            '-- Filtra Empresa, Establecimiento y GRTSeries para creacion recursiva de Opciones
            xDr = pDtOpciones.Select("IDEstablec>0", "CodEmpresa,IDEstablec,CodDocto,SerieDoc")
            If xDr.Length > 0 Then
                dtEmp_VtaS = xDr.CopyToDataTable

                'dtOpcionesNodos = pDtOpciones.Copy
                '-- En recorrido, segun encuentre va creando los nodos
                For Each xR As DataRow In dtEmp_VtaS.Rows ' pDtOpciones.Rows
                    If xR.Item("CodEmpresa") <> w_CodEmpVtaS Then
                        w_CodEmpVtaS = xR.Item("CodEmpresa")
                        udfCrea_TnEmpVtaS(pTvwOpciones, w_CodEmpVtaS, xR.Item("Empresa"))
                        w_IdEstablecVtaS = 0
                    End If
                    If w_IdEstablecVtaS <> xR.Item("IdEstablec") Then
                        w_IdEstablecVtaS = xR.Item("IdEstablec")
                        udfCrea_TnEstablecVtaS(w_CodEmpVtaS, w_IdEstablecVtaS, xR.Item("Establecimiento"))
                        w_CodDoctoVtaS = ""
                    End If
                    If w_CodDoctoVtaS <> xR.Item("CodDocto") Then
                        w_CodDoctoVtaS = xR.Item("CodDocto")
                        udfCrea_TnDcmtoVtaS(w_CodEmpVtaS, w_IdEstablecVtaS, w_CodDoctoVtaS, xR.Item("Documento"))
                        w_SerieVtaS = 0
                    End If
                    If w_SerieVtaS <> xR.Item("SerieDoc") Then
                        w_SerieVtaS = xR.Item("SerieDoc")
                        udfCrea_TnSerieVtaS(w_CodEmpVtaS, w_IdEstablecVtaS, w_CodDoctoVtaS, w_SerieVtaS, xR.Item("SerieVenta"))
                    End If
                Next
            End If
            pTvwOpciones.EndUpdate()
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub udfCrea_TnEmpVtaS(ByRef pTvwOpciones As TreeView, ByVal pCodEmpresa As String, ByVal pEmpresa As String)
        Dim xKey As String
        xKey = pCodEmpresa
        wTn_EmpVtaS = New TreeNode(pEmpresa)
        With wTn_EmpVtaS
            .Tag = xKey
            .ForeColor = Drawing.Color.Navy
            .NodeFont = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold) ', System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End With
        pTvwOpciones.Nodes.Add(wTn_EmpVtaS)
    End Sub

    Private Sub udfCrea_TnEstablecVtaS(ByVal pCodEmpresa As String, ByVal pIdEstablec As Integer, ByVal pEstablec As String)
        Dim xKey As String
        xKey = pCodEmpresa & ":" & pIdEstablec.ToString
        wTn_EstablecVtaS = New TreeNode(pEstablec)
        With wTn_EstablecVtaS
            .Tag = xKey
            .ForeColor = Drawing.Color.Navy
            .NodeFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold) ', System.Drawing.GraphicsUnit.Point, CType(0, Byte))            
        End With
        wTn_EmpVtaS.Nodes.Add(wTn_EstablecVtaS)
        wTn_EmpVtaS.Expand()
    End Sub

    Private Sub udfCrea_TnDcmtoVtaS(ByVal pCodEmpresa As String, ByVal pIdEstablec As Integer, ByVal pCodDocto As String, ByVal pDocumento As String)
        Dim xKey As String
        xKey = pCodEmpresa & ":" & pIdEstablec.ToString & "-" & pCodDocto
        wTn_DcmtoVtaS = New TreeNode(pDocumento)
        With wTn_DcmtoVtaS
            .Tag = xKey
            .ForeColor = Drawing.Color.Navy
            .NodeFont = New System.Drawing.Font("Tahoma", 7.75!, System.Drawing.FontStyle.Regular) ', System.Drawing.GraphicsUnit.Point, CType(0, Byte))            
        End With
        wTn_EstablecVtaS.Nodes.Add(wTn_DcmtoVtaS)
        wTn_EstablecVtaS.Expand()
    End Sub

    Private Sub udfCrea_TnSerieVtaS(ByVal pCodEmpresa As String, ByVal pIdEstablec As Integer, ByVal pCodDocto As String, ByVal pSerieVta As Integer, ByVal pSerieVenta As String)
        Dim xKey As String
        xKey = pCodEmpresa & ":" & pIdEstablec.ToString & "-" & pCodDocto & "/" & pSerieVta.ToString
        wTn_SerieVtaS = New TreeNode(pSerieVenta)
        With wTn_SerieVtaS
            .Tag = xKey
            .ForeColor = Drawing.Color.Navy
            .NodeFont = New System.Drawing.Font("Tahoma", 7.75!, System.Drawing.FontStyle.Regular) ', System.Drawing.GraphicsUnit.Point, CType(0, Byte))            
        End With
        wTn_DcmtoVtaS.Nodes.Add(wTn_SerieVtaS)
        wTn_DcmtoVtaS.Expand()
    End Sub

    Private Sub udfCheck_PermisoVta(ByVal Node As TreeNode)
        Dim nodX As TreeNode
        'Dim xPosEmp As Long
        For Each nodX In Node.Nodes
            '.. extrayendo codigos
            udfExtraeCodigos_SerieVtaS(nodX)
            If w_CodEmpVtaS.Length > 0 And w_IdEstablecVtaS > 0 And w_CodDoctoVtaS.Length > 0 And w_SerieVtaS > 0 Then
                '... Verifica si Permiso está en Opción: Marca / Desmarca
                nodX.Checked = udfBuscaPermiso_SerieVta(w_CodEmpVtaS, w_IdEstablecVtaS, w_CodDoctoVtaS, w_SerieVtaS)
            ElseIf w_CodEmpVtaS.Length > 0 And w_IdEstablecVtaS > 0 And w_CodDoctoVtaS.Length > 0 Then
                '... Verifica si Permiso está en Opción: Marca / Desmarca
                nodX.Checked = udfBuscaPermiso_CodDoctoVta(w_CodEmpVtaS, w_IdEstablecVtaS, w_CodDoctoVtaS)
            ElseIf w_CodEmpVtaS.Length > 0 And w_IdEstablecVtaS > 0 Then
                '... Verifica si tiene acceso al sub Almacen
                nodX.Checked = udfBuscaPermiso_EstablecVta(w_CodEmpVtaS, w_IdEstablecVtaS)
            ElseIf w_CodEmpVtaS.Length > 0 Then
                'xPosEmp = Array.IndexOf(aEmpresaVtaS, w_CodEmpVtaS, 0)
                If Array.IndexOf(aEmpresaVtaS, w_CodEmpVtaS, 0) >= 0 Then
                    nodX.Checked = True
                Else
                    nodX.Checked = False
                End If
            End If
            '-- pone formato al nodo.
            udfFormatoCheck(nodX, nodX.Checked)
            '... invocación recursiva
            udfCheck_PermisoVta(nodX)
        Next
    End Sub

    Private Sub udfExtraeCodigos_SerieVtaS(ByRef xNode As TreeNode)
        Dim xCodigos As String
        Dim xPos1 As Integer = 0
        Dim xPos2 As Integer = 0
        Dim xPos3 As Integer = 0
        Dim xAncho As Integer = 0

        w_CodEmpVtaS = ""
        w_IdEstablecVtaS = 0
        w_CodDoctoVtaS = ""
        w_SerieVtaS = 0


        xCodigos = xNode.Tag
        xPos1 = InStr(xCodigos, ":")
        xPos2 = InStr(xCodigos, "-")
        xPos3 = InStr(xCodigos, "/")

        ' 01:A17-S1/W
        '   3   7  0
        If xPos1 = 0 And xPos2 = 0 And xPos3 = 0 Then
            w_CodEmpVtaS = xCodigos.Trim
        Else
            w_CodEmpVtaS = xCodigos.Substring(0, xPos1 - 1)
        End If

        If xPos1 > 0 And xPos2 = 0 And xPos3 = 0 Then
            xAncho = xCodigos.Length - xPos1
            w_IdEstablecVtaS = Convert.ToInt32(xCodigos.Substring(xPos1, xAncho))
        End If

        If xPos1 > 0 And xPos2 > 0 And xPos3 = 0 Then
            w_IdEstablecVtaS = xCodigos.Substring(xPos1, xPos2 - (xPos1 + 1))
            xAncho = xCodigos.Length - xPos2
            w_CodDoctoVtaS = xCodigos.Substring(xPos2, xAncho)
        End If

        If xPos1 > 0 And xPos2 > 0 And xPos3 > 0 Then
            w_IdEstablecVtaS = xCodigos.Substring(xPos1, xPos2 - (xPos1 + 1))
            w_CodDoctoVtaS = xCodigos.Substring(xPos2, xPos3 - (xPos2 + 1))
            xAncho = xCodigos.Length - xPos3
            w_SerieVtaS = xCodigos.Substring(xPos3, xAncho)
        End If
    End Sub

    Private Function udfBuscaPermiso_SerieVta(ByVal pCodEmp As String, ByVal pIdEstablec As Integer, ByVal pCodDocto As String, ByVal pSerieVta As Integer) As Boolean
        w_EmpFound = ""
        w_EstablecVtaFound = 0
        w_CodDoctoVtaFound = ""
        w_SerieVtaFound = 0

        '... crear indices (PK) 
        Dim xBuscarPK(3) As Object
        xBuscarPK(0) = pCodEmp
        xBuscarPK(1) = pIdEstablec
        xBuscarPK(2) = pCodDocto
        xBuscarPK(3) = pSerieVta

        '... busca PK
        Dim xFoundRow As DataRow = dtPermisoVtaS.Rows.Find(xBuscarPK)
        If Not (xFoundRow Is Nothing) Then
            '... PK encontrado
            w_EmpFound = pCodEmp
            w_EstablecVtaFound = pIdEstablec
            w_CodDoctoVtaFound = pCodDocto
            w_SerieVtaFound = pSerieVta
            Return True
        Else
            Return False
        End If
    End Function

    Private Function udfBuscaPermiso_CodDoctoVta(ByVal pCodEmp As String, ByVal pIdEstablec As Integer, ByVal pCodDocto As String) As Boolean
        '-- Busca si Estableceimiento esta asignado al usuario
        Dim xDr() As DataRow
        xDr = dtPermisoVtaS.Select("CodEmpresa='" & pCodEmp & "' AND IdEstablec=" & pIdEstablec & " AND CodDocto='" & pCodDocto & "'")
        If xDr.Length > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function udfBuscaPermiso_EstablecVta(ByVal pCodEmp As String, ByVal pIdEstablec As Integer) As Boolean
        '-- Busca si Estableceimiento esta asignado al usuario
        Dim xDr() As DataRow
        xDr = dtPermisoVtaS.Select("CodEmpresa='" & pCodEmp & "' AND IdEstablec=" & pIdEstablec)
        If xDr.Length > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub pdu_CargarPermisos_SerieVtaS()

        dtPermisoVtaS = Nothing
        dtPermisoVtaS = oWFUsuario.fdu_OA_VtaSeries_VerPorUser(wUsuario)
        If dtPermisoVtaS IsNot Nothing Then
            ''-- creando indices del PK en tabla filtrada de Permisos
            Dim xCols(3) As DataColumn
            With dtPermisoVtaS
                If Not .Columns("CodEmpresa") Is Nothing And _
                    Not .Columns("IdEstablec") Is Nothing And _
                    Not .Columns("CodDocto") Is Nothing And _
                    Not .Columns("SerieDoc") Is Nothing Then
                    ' indexa columna
                    xCols(0) = .Columns("CodEmpresa")
                    xCols(1) = .Columns("IdEstablec")
                    xCols(2) = .Columns("CodDocto")
                    xCols(3) = .Columns("SerieDoc")
                    .PrimaryKey = xCols
                End If
            End With
        End If

        If dtPermisoVtaS IsNot Nothing AndAlso dtPermisoVtaS.Rows.Count > 0 Then
            '... Copia solo estructura datos para agregar Permisos Nuevos
            'dtPermisosNuevos = dtPermisos.Clone

            '-- Rescatando Codigo de Modulos
            Dim xLong As Integer = dtPermisoVtaS.Rows.Count - 1
            Dim xCodEmpresa As String = ""
            'Dim xIdEstablec As Integer = 0
            'Dim xCodDocto As String = ""
            'Dim xSerieVta As Integer = 0


            Dim xPos As Int16 = -1
            'Dim xPos1 As Int16 = -1
            'Dim xPos2 As Int16 = -1
            'Dim xPos3 As Int16 = -1

            ReDim aEmpresaVtaS(xLong)
            'ReDim aBanco(xLong)

            '--- Rescatando Codigos: Empresa, Establecimiento y SerieGRT
            For i = 0 To xLong
                If xCodEmpresa <> dtPermisoVtaS.Rows(i).Item("CodEmpresa").ToString Then
                    xPos += 1
                    xCodEmpresa = dtPermisoVtaS.Rows(i).Item("CodEmpresa")
                    aEmpresaVtaS(xPos) = xCodEmpresa
                End If
            Next

            ReDim Preserve aEmpresaVtaS(xPos)
            'ReDim Preserve aBanco(xPos1)

            '-- cargar las Series de Dcmtos.Ventas, asignados al Usuario (Crea el arbol)
            udfCarga_tvVtaSeries(tv_VtaS_Permisos, dtPermisoVtaS)

            '-- Marca los Permisos de Cuentas asignadas al usuario (Marca el Check)
            udfMarcaPermisosEnSeriesVta()

            '-- Color de Fondo que indique actualizado
            tvwPermisos.BackColor = Drawing.Color.White
        Else
            pdu_LimpiarPermisosEnSeriesVta()
        End If
    End Sub

    Private Sub udfMarcaPermisosEnSeriesVta()
        If tv_VtaS_Opciones.Nodes.Count > 0 Then
            Dim NodoR As TreeNode
            RemoveHandler tv_VtaS_Opciones.AfterCheck, AddressOf tv_VtaS_Opciones_AfterCheck
            For Each NodoR In tv_VtaS_Opciones.Nodes
                udfExtraeCodigos_SerieVtaS(NodoR)
                If w_CodEmpVtaS > 0 Then
                    If Array.IndexOf(aEmpresaVtaS, w_CodEmpVtaS) >= 0 Then
                        NodoR.Checked = True
                    Else
                        NodoR.Checked = False
                    End If
                End If
                '-- pone formato al nodo.
                udfFormatoCheck(NodoR, NodoR.Checked)

                '... Check Permiso en Nodos subordinados:
                'wEstadoDeCarga = True

                udfCheck_PermisoVta(NodoR)
            Next
            AddHandler tv_VtaS_Opciones.AfterCheck, AddressOf tv_VtaS_Opciones_AfterCheck
        End If
    End Sub

    Private Sub pdu_LimpiarPermisosEnSeriesVta()
        '-- Limpieza del TreView de Permisos en GRTs
        tv_VtaS_Permisos.Nodes.Clear()
        If tv_VtaS_Opciones.Nodes.Count > 0 Then
            Dim NodoR As TreeNode
            RemoveHandler tv_VtaS_Opciones.AfterCheck, AddressOf tv_VtaS_Opciones_AfterCheck
            For Each NodoR In tv_VtaS_Opciones.Nodes
                NodoR.Checked = False

                '-- pone formato al nodo.
                udfFormatoCheck(NodoR, NodoR.Checked)

                '... Clear Check Permiso en Nodos subordinados:
                pdu_ClearCheckNode(NodoR)
            Next
            AddHandler tv_VtaS_Opciones.AfterCheck, AddressOf tv_VtaS_Opciones_AfterCheck
        End If
    End Sub

    Private Sub tv_VtaS_Opciones_AfterCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tv_VtaS_Opciones.AfterCheck
        ' Merca/Desmarca Niveles de Acceso a modificar para el ROL.
        tv_VtaS_Permisos.BackColor = Drawing.Color.LightSteelBlue
        TreeCheckBoxes(tv_VtaS_Opciones, e.Node)
    End Sub

    Private Sub udfCopyDataSerieVta(ByVal Node As TreeNode)
        Dim i As Integer
        Dim nodX As TreeNode

        If Node.GetNodeCount(False) <> 0 Then
            nodX = Node.FirstNode
            For i = 0 To Node.GetNodeCount(False) - 1
                'nodX.Checked = bCheck
                If nodX.Checked Then
                    '... Extrae códigos
                    udfExtraeCodigos_SerieVtaS(nodX)
                    If w_CodEmpVtaS.Length > 0 And w_IdEstablecVtaS > 0 And w_CodDoctoVtaS.Length > 0 And w_SerieVtaS > 0 Then
                        'Agregar Registro a tabla
                        Dim xDr As DataRow = dtPermisoVtaNuevos.NewRow
                        xDr("CodEmpresa") = w_CodEmpVtaS
                        xDr("IdEstablec") = w_IdEstablecVtaS
                        xDr("CodDocto") = w_CodDoctoVtaS
                        xDr("SerieDoc") = w_SerieVtaS
                        dtPermisoVtaNuevos.Rows.Add(xDr)
                    End If
                End If
                '-- Aplicar Recursividad
                udfCopyDataSerieVta(nodX)
                nodX = nodX.NextNode
            Next
        End If
    End Sub

    Private Sub btnAtualizarVtaSeries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtualizarVtaSeries.Click
        If dtPermisoVtaS Is Nothing Then Return
        With tv_VtaS_Opciones
            dtPermisoVtaNuevos = dtPermisoVtaS.Clone
            ' Elimina columnas innecesarias             
            dtPermisoVtaNuevos.Columns.Remove("Empresa")
            dtPermisoVtaNuevos.Columns.Remove("Establecimiento")
            dtPermisoVtaNuevos.Columns.Remove("Documento")
            dtPermisoVtaNuevos.Columns.Remove("SerieVenta")

            If .Nodes.Count > 0 Then
                Dim j As Int32
                Dim xXML As String

                For j = 0 To .Nodes.Count - 1
                    Dim xNode As TreeNode
                    xNode = .Nodes(j)
                    '... Check Permiso en Nodos subordinados
                    udfCopyDataSerieVta(xNode)
                Next
                '... Convertir Tabla a XML
                xXML = oWFUsuario.DataTableAXML(dtPermisoVtaNuevos)
                '... Grabar Data en BD
                If oWFUsuario.fdu_OA_VtaSeries_EditarAcceso(wUsuario, xXML) Then
                    udfCargaCampos(True)
                    tv_VtaS_Permisos.BackColor = Drawing.Color.White
                End If
            End If
        End With
    End Sub

#End Region

    
    
    Private Sub btnActualizaVOSG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizaVOSG.Click

        Dim xDt As New DataTable
        xDt.Columns.Add("NroGrupo")


        For Each chb As DataRowView In chlbVOSG.CheckedItems
            xDt.Rows.Add(chb.Item("NroGrupo"))
        Next

        Dim xmlDatos As String = ""
        If xDt.Rows.Count > 0 Then
            xmlDatos = oWFUsuario.DataTableAXML(xDt)
        End If

        If oWFUsuario.fdu_OA_VtaGrupo_EditarAcceso(wUsuario, xmlDatos) Then
            chlbVOSG.BackColor = Drawing.Color.White
        End If
    End Sub

    Private Sub chlbVOSG_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chlbVOSG.ItemCheck
        If Not wEditar Then
            chlbVOSG.BackColor = Drawing.Color.LightSteelBlue
        End If
    End Sub

    Dim wAsistResumPlla_Cambia As Boolean = False

    Private Sub dgvAsistResumPlla_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAsistResumPlla.CellContentClick

        With dgvAsistResumPlla
            Select Case .Columns(e.ColumnIndex).Name
                Case "PFJ"
                    If .Rows(e.RowIndex).Cells("PFJ").Value Then
                        .Rows(e.RowIndex).Cells("PFJ").Value = False
                    Else
                        .Rows(e.RowIndex).Cells("PFJ").Value = True
                    End If
                    wAsistResumPlla_Cambia = True
                    .DefaultCellStyle.BackColor = Drawing.Color.LightSteelBlue
            End Select
        End With

    End Sub

    Private Sub btnAsistResumPlla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsistResumPlla.Click
        If wAsistResumPlla_Cambia Then
            Dim xXmlPlla As String
            Dim xDt As DataTable
            xDt = WFUsuario.DataGridViewToDataTable(dgvAsistResumPlla)
            If xDt IsNot Nothing AndAlso xDt.Rows.Count > 0 Then
                xDt.Columns.Remove("Planilla")
                xXmlPlla = oWFUsuario.DataTableAXML(xDt)
                If oWFUsuario.fdu_OA_Asiste_ResumPlla_EditarAcceso(wUsuario, xXmlPlla) Then
                    pdu_DgvAsistResumPlla_Cargar()
                End If
            End If            
        End If
    End Sub

    Private Sub pdu_DgvAsistResumPlla_Cargar()
        wAsistResumPlla_Cambia = False
        '-- Cargar Resumen por Plla de Asistencia por Operaciones por usuario.
        Dim xDtResum As DataTable = oWFUsuario.fdu_OA_Asiste_ResumPlla_VerPorUser(wUsuario)
        If xDtResum IsNot Nothing Then
            dgvAsistResumPlla.DataSource = xDtResum
            pdu_DgvAsistResumPlla_Format()
        Else
            dgvAsistResumPlla.DataSource = Nothing
        End If
    End Sub

    Private Sub pdu_DgvAsistResumPlla_Format()
        With dgvAsistResumPlla
            .Columns("CodPlanilla").Visible = False
            .Columns("Planilla").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("PFJ").Width = 50
            .DefaultCellStyle.BackColor = Drawing.Color.White
        End With
    End Sub
End Class