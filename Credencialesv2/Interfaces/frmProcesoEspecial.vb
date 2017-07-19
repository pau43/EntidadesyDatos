Imports System.Windows.Forms
Imports GEACEntidades

Public Class frmProcesoEspecial
    Inherits System.Windows.Forms.Form

    Private oWFProcesoEspecial As New WFProcesoEspecial
    Private oWFOpcion As New WFOpcion
    Private oWFUsuario As New WFUsuario

    Dim wIDSistema As Integer
    Dim wCodModulo As String
    Dim wCodNivel As String

    Dim dtUsuarios As DataTable
    Dim wUsuario As String

    Dim wTnSistema As TreeNode
    Dim wTnModulo As TreeNode
    Dim wTnOpcion As TreeNode

    Dim dtPermisos As DataTable
    Dim dtPermisosNuevos As DataTable
    Dim dtOpcionesNodos As DataTable

    Dim aModulos() As String
    Dim aSistemas() As Integer

    Dim dtOpcionX_MS As DataTable
    Dim wModuloPadre As String

    Dim wEditar As Boolean
    Dim wColorActivado As Drawing.Color
    Dim wColorDesactivado As Drawing.Color

    Private Sub frmProcesoEspecial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        wModuloPadre = Me.Tag
        wColorActivado = Drawing.Color.Blue
        wColorDesactivado = Drawing.Color.Olive

        udfBotones(True)
        udfRecargarDatos()
    End Sub

    Private Sub udfRecargarDatos()
        udfRecargarDatosOpciones()
        udfRecargarDatosUsuario()
    End Sub

    Private Sub udfRecargarDatosOpciones()
        dtOpcionX_MS = oWFOpcion.udfVerOpcionesEspeciales()
        If Not dtOpcionX_MS Is Nothing AndAlso dtOpcionX_MS.Rows.Count > 0 Then
            'udfCargaDataTreeView_Sistema()
            udfCargaTreeView(tvw_SMO, dtOpcionX_MS)
        Else
            MsgBox("No existen Opciones Especiales registradas que puedan ser asignadas a un Usuario.")
            Me.Close()
        End If
    End Sub

    Private Sub udfCargaTreeView(ByVal pTvwOpciones As TreeView, ByVal pDtOpciones As DataTable)
        '-- Limpieza de Nodos anteriores
        pTvwOpciones.Nodes.Clear()
        '-- Validación para carga de datos
        If Not pDtOpciones Is Nothing AndAlso pDtOpciones.Rows.Count > 0 Then
            'Dim dtSistemaModulo As DataTable
            'Dim xDr() As DataRow

            wIDSistema = 0
            wCodModulo = ""
            wCodNivel = ""
            ' carga TreeView con cada uno de los permisos
            With pTvwOpciones
                'configura TreeView
                .BeginUpdate()
                .ShowLines = True
                .ShowPlusMinus = True
                .ShowRootLines = True
                .HideSelection = False
                .HotTracking = False
            End With

            '-- Filtra Sistemas y Modulos para creacion recursiva de Opciones
            'xDr = pDtOpciones.Select("LEN(CodNivel)=1", "IdSistema,CodModulo")
            'If xDr.Length > 0 Then
            '    dtSistemaModulo = xDr.CopyToDataTable

            dtOpcionesNodos = pDtOpciones.Copy


            For Each xR As DataRow In pDtOpciones.Rows
                If xR.Item("IdSistema") <> wIDSistema Then
                    wIDSistema = xR.Item("IdSistema")
                    udfCrea_TnSistema(pTvwOpciones, wIDSistema, xR.Item("Sistema"))
                    wCodModulo = ""
                End If
                If wCodModulo <> xR.Item("CodModulo") Then
                    wCodModulo = xR.Item("CodModulo")
                    udfCrea_TnModulo(wIDSistema, wCodModulo, xR.Item("Modulo"))
                    '--- Crea opciones recursivamente ---
                    wCodNivel = xR.Item("CodNivel")                    
                    udfCrea_TnOpcion(wTnModulo, wCodNivel)
                End If

            Next
            'End If
            pTvwOpciones.EndUpdate()
        End If
    End Sub

    Private Sub udfCrea_TnSistema(ByRef pTvwOpciones As TreeView, ByVal pIdSistema As Integer, ByVal pSistema As String)
        Dim xKey As String
        'Dim xTnSistema As TreeNode
        xKey = CStr(pIdSistema)
        wTnSistema = New TreeNode(pSistema)
        With wTnSistema
            .Tag = xKey
            .ForeColor = Drawing.Color.Navy
            .NodeFont = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold) ', System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End With
        pTvwOpciones.Nodes.Add(wTnSistema)
        'pTvwOpciones.ExpandAll()
        'tvw_SMO.Nodes.Item(
    End Sub

    Private Sub udfCrea_TnModulo(ByVal pIdSistema As Integer, ByVal pCodModulo As String, ByVal pModulo As String)
        Dim xKey As String
        xKey = CStr(pIdSistema) & ":" & pCodModulo
        wTnModulo = New TreeNode(pModulo)
        With wTnModulo
            .Tag = xKey
            .ForeColor = Drawing.Color.Navy
            .NodeFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold) ', System.Drawing.GraphicsUnit.Point, CType(0, Byte))            
        End With
        wTnSistema.Nodes.Add(wTnModulo)
        wTnSistema.Expand()
    End Sub

    

    Private Sub udfCrea_TnOpcion(ByVal pNodeOp As TreeNode, ByVal pCodNivel As String)
        Dim xKey As String
        'Dim xNewOpcion As String
        Dim dvOpciones As DataView
        Dim xAncho As Byte

        xAncho = pCodNivel.Length + 1
        dvOpciones = New DataView(dtOpcionesNodos)
        dvOpciones.RowFilter = "IdSistema=" + wIDSistema.ToString + " AND CodModulo='" + wCodModulo + "'" ' AND CodNivel = '" + pCodNivel + "'" ' AND LEN(CodNivel)=" + xAncho.ToString

        ' Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
        For Each dataRowCurrent As DataRowView In dvOpciones
            Dim nuevoNodo As New TreeNode
            With nuevoNodo
                .Text = dataRowCurrent("Proceso").ToString().Trim()
                xKey = dataRowCurrent("IdSistema").ToString().Trim() + ":"
                xKey += dataRowCurrent("CodModulo").ToString().Trim() + "-"
                xKey += dataRowCurrent("CodNivel").ToString().Trim()
                .Tag = xKey
                .ForeColor = Drawing.Color.Navy
                .NodeFont = New System.Drawing.Font("Tahoma", 8.75!, System.Drawing.FontStyle.Regular) ', System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            End With
            pNodeOp.Nodes.Add(nuevoNodo)
            pNodeOp.Expand()
            '' Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.
            'udfCrea_TnOpcion(nuevoNodo, dataRowCurrent("CodNivel").ToString().Trim())
        Next dataRowCurrent
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
            udfCargaCampos(False)
        End If
    End Sub

    Private Sub udfCargaCampos(ByVal bVal As Boolean)
        If bVal And dtUsuarios.Rows.Count > 0 Then
            'txtRol.Text = cbxRol.SelectedValue.ToString
            lblPersona.Text = CType(cbxUsuario.SelectedItem, DataRowView).Item("Persona").ToString
            lblRol.Text = CType(cbxUsuario.SelectedItem, DataRowView).Item("Rol").ToString
            'Carga los Permisos
            dtPermisos = oWFProcesoEspecial.udfVerProcesoEspecial(wUsuario)

            ''-- creando indices del PK en tabla filtrada de Permisos
            Dim xCols(2) As DataColumn
            With dtPermisos
                If Not .Columns("IDSistema") Is Nothing And _
                    Not .Columns("CodModulo") Is Nothing And _
                    Not .Columns("CodNivel") Is Nothing Then
                    ' indexa columna
                    xCols(0) = .Columns("IDSistema")
                    xCols(1) = .Columns("CodModulo")
                    xCols(2) = .Columns("CodNivel")
                    .PrimaryKey = xCols
                End If
            End With

            '... Copia estructura datos para agregar Permisos Nuevos
            dtPermisosNuevos = dtPermisos.Clone

            '-- Rescatando Codigo de Modulos
            Dim xLong As Integer = dtPermisos.Rows.Count - 1
            Dim xCodModulo As String = ""
            Dim xIDSistema As Integer = 0
            Dim xPos As Int16 = -1
            ReDim aModulos(xLong)
            For i = 0 To xLong
                If xCodModulo <> dtPermisos.Rows(i).Item("CodModulo").ToString Or _
                    xIDSistema <> dtPermisos.Rows(i).Item("IDSistema") Then
                    xIDSistema = dtPermisos.Rows(i).Item("IDSistema")
                    xPos += 1
                    xCodModulo = dtPermisos.Rows(i).Item("CodModulo").ToString
                    aModulos(xPos) = CStr(xIDSistema) + ":" + xCodModulo
                End If
            Next
            'xLong = xPos
            ReDim Preserve aModulos(xPos)

            '-- Rescatando Codigo de Sistemas
            ReDim aSistemas(xPos)
            xIDSistema = 0
            xPos = -1
            For i = 0 To xLong
                If xIDSistema <> dtPermisos.Rows(i).Item("IDSistema").ToString Then
                    xPos += 1
                    xIDSistema = dtPermisos.Rows(i).Item("IDSistema")
                    aSistemas(xPos) = xIDSistema
                End If
            Next
            ReDim Preserve aSistemas(xPos)

            '-- cargar las Opciones asignadas al USUARIO (Crea el arbol)
            udfCargaTreeView(tvwPermisos, dtPermisos)

            '-- Marca los Permisos en Opciones asignados al USUARIO (Marca el Check)
            udfMarcaPermisosEnOpciones()

            '-- Color de Fondo que indique actualizado
            tvwPermisos.BackColor = Drawing.Color.White
        Else
            lblPersona.Text = ""
            lblRol.Text = ""
        End If

    End Sub

    Private Sub udfMarcaPermisosEnOpciones()
        'If tvw_SMO.Nodes.Count > 0 Then
        '    Dim j As Int32

        '    For j = 0 To tvw_SMO.Nodes.Count - 1
        '        Dim xNode As TreeNode
        '        xNode = tvw_SMO.Nodes(j)

        '        '... Desmarca Nodos subordinados
        '        xNode.Checked = False

        '        '... Check Permiso en Nodos subordinados
        '        udfCheckPermisoNode(xNode)
        '    Next

        'End If

        If tvw_SMO.Nodes.Count > 0 Then
            Dim NodoR As TreeNode
            RemoveHandler tvw_SMO.AfterCheck, AddressOf tvw_SMO_AfterCheck
            For Each NodoR In tvw_SMO.Nodes
                udfExtraeCodigos(NodoR)
                If wIDSistema > 0 Then
                    If Array.IndexOf(aSistemas, wIDSistema) >= 0 Then
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

    Private Sub udfCheckPermisoNode(ByVal Node As TreeNode)
        Dim nodX As TreeNode
        For Each nodX In Node.Nodes
            '.. extrayendo codigos
            udfExtraeCodigos(nodX)
            If wIDSistema > 0 And wCodModulo.Length > 0 And wCodNivel.Length > 0 Then
                '... Verifica si Permiso está en Opción: Marca / Desmarca
                nodX.Checked = udfBuscaPermiso(wIDSistema, wCodModulo, wCodNivel)
            ElseIf wIDSistema > 0 And wCodModulo.Length > 0 Then
                'If Array.IndexOf(aModulos, wCodModulo) >= 0 And Array.IndexOf(aSistemas, wIDSistema) >= 0 Then
                If Array.IndexOf(aModulos, CStr(wIDSistema) + ":" + wCodModulo) >= 0 Then
                    nodX.Checked = True
                Else
                    nodX.Checked = False
                End If
            ElseIf wIDSistema > 0 Then
                'xPos = Array.IndexOf(aSistemas, wIDSistema)
                If Array.IndexOf(aSistemas, wIDSistema) >= 0 Then
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

    Private Sub udfExtraeCodigos(ByRef xNode As TreeNode)
        Dim xCodigos As String
        Dim xPos1 As Integer = 0
        Dim xPos2 As Integer = 0
        Dim xPos3 As Integer = 0

        wIDSistema = 0
        wCodModulo = ""
        wCodNivel = ""

        xCodigos = xNode.Tag
        xPos1 = InStr(xCodigos, ":")
        xPos2 = InStr(xCodigos, "-")

        If xPos1 = 0 And xPos2 = 0 Then
            wIDSistema = CInt(Val(xCodigos))
        Else
            wIDSistema = CInt(Val(xCodigos.Substring(0, xPos1 + 1)))
        End If

        If xPos1 > 0 And xPos2 = 0 Then
            xPos3 = xCodigos.Length - xPos1
            wCodModulo = xCodigos.Substring(xPos1, xPos3)
        End If

        If xPos1 > 0 And xPos2 > 0 Then
            wCodModulo = xCodigos.Substring(xPos1, xPos2 - (xPos1 + 1))
            xPos3 = xCodigos.Length - xPos2
            xPos2 = xPos2
            wCodNivel = xCodigos.Substring(xPos2, xPos3)
        End If
    End Sub

    Private Function udfBuscaPermiso(ByVal pIdSistema As Integer, ByVal pCodModulo As String, ByVal pCodNivel As String) As Boolean
        '... crear indices (PK) 
        Dim xBuscarPK(2) As Object
        xBuscarPK(0) = pIdSistema
        xBuscarPK(1) = pCodModulo
        xBuscarPK(2) = pCodNivel

        '... busca PK
        Dim xFoundRow As DataRow = dtPermisos.Rows.Find(xBuscarPK)
        If Not (xFoundRow Is Nothing) Then
            '... PK encontrado            
            Return True
        Else
            Return False
        End If
        'End If
    End Function

    Private Sub udfBotones(ByVal pHabilitar As Boolean)
        tsbAsignar.Enabled = IIf(pHabilitar, SesionUsuario.udfActivarOpcion(wModuloPadre, "61"), False)
        'tsbEditar.Enabled = IIf(pHabilitar, SesionUsuario.udfActivarOpcion(wModuloPadre, "62"), False)
        'tsbDeshacer.Enabled = Not pHabilitar
        'tsbGrabar.Enabled = Not pHabilitar
        'tsbBorrar.Enabled = IIf(pHabilitar, SesionUsuario.udfActivarOpcion(wModuloPadre, "63"), False)
        tsbRecargar.Enabled = pHabilitar
        tsbSalir.Enabled = pHabilitar

        'btnActualizar.Enabled = IIf(pHabilitar, SesionUsuario.udfActivarOpcion(wModuloPadre, "54"), False)
        'tvw_SMO.Enabled = pHabilitar

    End Sub

    Private Sub cbxUsuario_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbxUsuario.SelectedValueChanged
        If Not (wEditar) And cbxUsuario.SelectedIndex >= 0 Then
            ' Si no esta en Edición, Cargar Procesos del Usuario
            wUsuario = cbxUsuario.SelectedValue
            udfCargaCampos(True)

        End If
    End Sub

    Private Sub tsbAsignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAsignar.Click
        Select CType(sender, ToolStripButton).Name.ToString
            Case "tsbAsignar"
                With tvw_SMO
                    dtPermisosNuevos.Clear()
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
                        xXML = oWFOpcion.DataTableAXML(dtPermisosNuevos)
                        '... Grabar Data en BD
                        If oWFProcesoEspecial.udfEditaProcesoEspecial(wUsuario, xXML) Then
                            udfCargaCampos(True)
                        End If
                        tvwPermisos.BackColor = Drawing.Color.White
                    End If
                End With

            Case "tsbRecargar"
                udfRecargarDatos()

            Case "tsbSalir"
                'If wEditar Then
                '    If MsgBox("Aun no termina ingreso de datos." & vbCrLf & "¿Esta seguro de Salir?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Opciones") = MsgBoxResult.Yes Then
                '        Me.Close()
                '    End If
                'Else
                Me.Close()
                'End If
        End Select
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
                    If wIDSistema > 0 And wCodModulo.Length > 0 And wCodNivel.Length > 0 Then
                        'Agregar Registro a tabla
                        Dim xDr As DataRow = dtPermisosNuevos.NewRow
                        xDr("IDSistema") = wIDSistema
                        xDr("CodModulo") = wCodModulo
                        xDr("CodNivel") = wCodNivel
                        dtPermisosNuevos.Rows.Add(xDr)
                    End If
                End If
                udfCopyDataNode(nodX)
                nodX = nodX.NextNode
            Next
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

        If CurrentNode.Checked = True Then 'Node con Check
            'da Check a los Hijos
            Checkhijos(CurrentNode, EstadoCheck)

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
            Checkhijos(CurrentNode, EstadoCheck)
            'verifica si algun hijo tiene check sino quita el check  los padres
            CheckPadre(CurrentNode, EstadoCheck)
        End If
        noEntraNode = False

    End Sub

    Private Sub udfFormatoCheck(ByVal pNode As TreeNode, ByVal pCheck As Boolean)
        If pCheck Then
            pNode.ForeColor = wColorActivado
        Else
            pNode.ForeColor = wColorDesactivado
        End If
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
                'If Node.Parent.Checked Then
                '    Node.Parent.ForeColor = wColorActivado
                'Else
                '    Node.Parent.ForeColor = wColorDesactivado
                'End If
                udfFormatoCheck(Node.Parent, bCheck)

                CheckPadre(Node.Parent, bCheck)
            End If
        End If
    End Sub



    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub
End Class