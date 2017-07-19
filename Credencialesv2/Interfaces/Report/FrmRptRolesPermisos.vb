Public Class FrmRptRolesPermisos

    Private dtRoles As DataTable
    Private dtSistema As DataTable
    Private dtModulos As DataTable
    Private oWFRol As New WFRol
    Private oWFSistema As New WFSistema
    Private oWFOpcion As New WFOpcion
    Private dtResultado As New DataTable
    Private wColorActivado As Drawing.Color
    Private wColorDesactivado As Drawing.Color

    Private Sub FrmRptRolesPermisos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarRoles()
        CargarSistema()
        'CargarModulos()
        wColorActivado = Drawing.Color.DarkBlue
        wColorDesactivado = Drawing.Color.Olive
    End Sub

    Private Sub CargarRoles()
        dtRoles = oWFRol.udfVerRol(0)
        If dtRoles Is Nothing Or dtRoles.Rows.Count = 0 Then
            MsgBox("No se ha definido Rol alguno.")
            Me.Close()
        End If
        If dtRoles.Rows.Count > 0 Then
            With cbxRol
                .DisplayMember = dtRoles.Columns("Rol").ColumnName
                .ValueMember = dtRoles.Columns("NroRol").ColumnName
                .DataSource = dtRoles
                .SelectedIndex = -1
            End With
        End If
    End Sub
    Private Sub CargarSistema()
        dtSistema = oWFSistema.udfVerSistema()
        If dtSistema Is Nothing Or dtSistema.Rows.Count = 0 Then
            MsgBox("No se ha definido Sistema.")
            Me.Close()
        End If
        If dtSistema.Rows.Count > 0 Then
            With cbSistema
                .DisplayMember = dtSistema.Columns("Descripcion").ColumnName
                .ValueMember = dtSistema.Columns("IDSistema").ColumnName
                .DataSource = dtSistema
                .SelectedIndex = -1
            End With
        End If
    End Sub
    'Private Sub CargarModulos()
    '    dtModulos = oWFModulo.udfVerModulo
    '    If dtModulos Is Nothing Or dtModulos.Rows.Count = 0 Then
    '        MsgBox("No se ha definido Modulo.")
    '        Me.Close()
    '    End If
    '    If dtModulos.Rows.Count > 0 Then
    '        With cbModulo
    '            .DataSource = dtModulos
    '            .DisplayMember = dtModulos.Columns("Descripcion").ColumnName
    '            .ValueMember = dtModulos.Columns("CodModulo").ColumnName
    '            .SelectedIndex = -1
    '        End With
    '    End If
    'End Sub

    Private Sub udfRecargarDatosOpciones()
        dtModulos = oWFOpcion.udfVerSistemaModuloOpcion(cbSistema.SelectedValue)
        If Not dtModulos Is Nothing AndAlso dtModulos.Rows.Count > 0 Then
            'udfCargaDataTreeView_Sistema()
            udfCargaTreeView(tvw_SMO, dtModulos)
        Else
            MsgBox("No existen Opciones registradas para el sistema seleccionado.")
            Me.Close()
        End If
    End Sub

    Dim wIDSistema As Integer
    Dim wCodModulo As String
    Dim wCodNivel As String
    Dim wTnSistema As TreeNode
    Dim wTnModulo As TreeNode
    Dim wTnOpcion As TreeNode
    Dim dtOpcionesNodos As DataTable

    Private Sub udfCargaTreeView(ByVal pTvwOpciones As TreeView, ByVal pDtOpciones As DataTable)
        '-- Limpieza de Nodos anteriores
        pTvwOpciones.Nodes.Clear()
        '-- Validación para carga de datos
        Cursor.Current = Cursors.WaitCursor
        If Not pDtOpciones Is Nothing AndAlso pDtOpciones.Rows.Count > 0 Then
            Dim dtSistemaModulo As DataTable
            Dim xDr() As DataRow

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
            xDr = pDtOpciones.Select("LEN(CodNivel)=1", "IdSistema,CodModulo")
            If xDr.Length > 0 Then
                dtSistemaModulo = xDr.CopyToDataTable
                dtOpcionesNodos = pDtOpciones.Copy

                For Each xR As DataRow In dtSistemaModulo.Rows
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
                        udfCrea_TnOpcion(wTnModulo, "")
                    End If
                Next
            End If
            pTvwOpciones.EndUpdate()
        End If
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub udfCrea_TnSistema(ByRef pTvwOpciones As TreeView, ByVal pIdSistema As Integer, ByVal pSistema As String)
        Dim xKey As String
        xKey = CStr(pIdSistema)
        wTnSistema = New TreeNode(pSistema)
        With wTnSistema
            .Tag = xKey
            .ForeColor = Drawing.Color.Navy
            .NodeFont = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold) ', System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End With
        pTvwOpciones.Nodes.Add(wTnSistema)
        pTvwOpciones.ForeColor = wColorDesactivado
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
        dvOpciones.RowFilter = "IdSistema=" + wIDSistema.ToString + " AND CodModulo='" + wCodModulo + "' AND CodNivel LIKE '" + pCodNivel + "*' AND LEN(CodNivel)=" + xAncho.ToString

        ' Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
        For Each dataRowCurrent As DataRowView In dvOpciones
            Dim nuevoNodo As New TreeNode
            With nuevoNodo
                .Text = dataRowCurrent("Opcion").ToString().Trim()
                xKey = dataRowCurrent("IdSistema").ToString().Trim() + ":"
                xKey += dataRowCurrent("CodModulo").ToString().Trim() + "-"
                xKey += dataRowCurrent("CodNivel").ToString().Trim()
                .Tag = xKey
                .ForeColor = Drawing.Color.Navy
                .NodeFont = New System.Drawing.Font("Tahoma", 8.75!, System.Drawing.FontStyle.Regular) ', System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            End With
            pNodeOp.Nodes.Add(nuevoNodo)
            pNodeOp.Expand()
            ' Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.
            udfCrea_TnOpcion(nuevoNodo, dataRowCurrent("CodNivel").ToString().Trim())
        Next dataRowCurrent
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        dgvRoles.DataSource = Nothing
        Dim xmlOpciones As String = String.Empty
        Dim nroRol As Integer = -1, idSist As Integer = -1

        If cbxRol.SelectedValue <> Nothing Then nroRol = cbxRol.SelectedValue
        If cbSistema.SelectedValue <> Nothing Then idSist = cbSistema.SelectedValue
        If (GetOpcionesABuscar()).Trim.Length > 0 Then xmlOpciones = GetOpcionesABuscar()

        dtResultado = oWFRol.fduBuscarRolesPermisos(nroRol, idSist, xmlOpciones)
        If dtResultado Is Nothing OrElse dtResultado.Rows.Count = 0 Then
            MsgBox("No se encontró datos para mostrar.", MsgBoxStyle.Critical, Me.Text)
            Return
        End If

        dgvRoles.DataSource = dtResultado
    End Sub

    Private Sub cbSistema_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSistema.SelectedIndexChanged
        If cbSistema.SelectedValue = Nothing Then
            tvw_SMO.Nodes.Clear()
            Return
        End If
        If cbSistema.SelectedIndex = -1 Then
            tvw_SMO.Nodes.Clear()
            Return
        End If
        udfRecargarDatosOpciones()
    End Sub

    Private Sub tvw_SMO_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvw_SMO.AfterCheck
        ' Merca/Desmarca Niveles de Acceso a modificar para el ROL.
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
            Checkhijos(CurrentNode, EstadoCheck)

            'Pone el Check a los padres
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

    Private dtOpciones As New DataTable
    Private Function GetOpcionesABuscar() As String
        With tvw_SMO
            '... Copia estructura
            dtOpciones = dtModulos.Clone
            dtOpciones.Clear()
            Dim xOpc As String = String.Empty
            If .Nodes.Count > 0 Then
                Dim j As Int32
                For j = 0 To .Nodes.Count - 1
                    Dim xNode As TreeNode
                    xNode = .Nodes(j)
                    '... Check Permiso en Nodos subordinados
                    udfCopyDataNode(xNode)
                Next
                xOpc = oWFRol.DataTableAXML(dtOpciones)
            End If
            Return xOpc
        End With
    End Function

    Private Sub udfCopyDataNode(ByVal Node As TreeNode)
        Dim i As Integer
        Dim nodX As TreeNode

        If Node.GetNodeCount(False) <> 0 Then
            nodX = Node.FirstNode
            For i = 0 To Node.GetNodeCount(False) - 1
                If nodX.Checked Then
                    '... Extrae códigos
                    udfExtraeCodigos(nodX)
                    If wIDSistema > 0 And wCodModulo.Length > 0 And wCodNivel.Length > 0 Then
                        'Agregar Registro a tabla
                        Dim xDr As DataRow = dtOpciones.NewRow
                        xDr("IDSistema") = wIDSistema
                        xDr("CodModulo") = wCodModulo
                        xDr("CodNivel") = wCodNivel
                        dtOpciones.Rows.Add(xDr)
                    End If
                End If
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

        wIDSistema = cbSistema.SelectedValue
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

    Private Sub btnOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOut.Click
        gbModulo.Height = 565
        btnOut.Visible = False
    End Sub
    Private Sub btnIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIn.Click
        gbModulo.Height = 251
        btnOut.Visible = True
    End Sub
End Class