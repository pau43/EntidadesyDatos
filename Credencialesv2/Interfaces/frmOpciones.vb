Imports System.Windows.Forms
Imports GEACEntidades

Public Class frmOpciones

    Private oWFSistema As New WFSistema
    'Private oWFModulo As New WFModulo
    Private oWFOpcion As New WFOpcion

    Private dtSistema As DataTable
    Private dtModulo As DataTable
    Private dtOpcion As DataTable   ' para filtradas
    Private dtOpcion_O As DataTable ' de origen (todas)


    Dim wIDSistema As Integer
    Dim wCodModulo As String
    Dim wCrear As Boolean
    Dim wEditar As Boolean
    Dim wPrimeraVez As Boolean = True
    Dim wModuloPadre As String

    Private Sub frmOpciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        wModuloPadre = Me.Tag
        udfBotones(True)
        '-- Cargando datos de Sistemas --
        dtSistema = oWFSistema.udfVerSistema()
        cbxSistemas.DataSource = dtSistema
        If dtSistema Is Nothing OrElse dtSistema.Rows.Count = 0 Then
            MsgBox("No existen Sistemas registrados." & vbCrLf & "Debe existir al menos uno para ingresar Opciones", MsgBoxStyle.Information, "Opciones del Sistema")
        Else
            cbxSistemas.DataSource = dtSistema
            cbxSistemas.DisplayMember = dtSistema.Columns("Descripcion").ColumnName
            cbxSistemas.ValueMember = dtSistema.Columns("IDSistema").ColumnName
        End If


        ''-- Cargando datos de Módulos --
        'dtModulo = oWFModulo.udfVerModulo()
        'If dtModulo Is Nothing OrElse dtModulo.Rows.Count = 0 Then
        '    MsgBox("No existen Módulos registrados." & vbCrLf & "Debe existir al menos uno para ingresar Opciones", MsgBoxStyle.Information, "Opciones del Sistema")
        'Else
        '    With dgvModulos
        '        .DataSource = dtModulo
        '        .AutoResizeColumns()
        '    End With
        'End If



        If dtSistema.Rows.Count > 0 Then
            cbxSistemas.SelectedValue = dtSistema.Rows.Item(0)("IDSistema")
            cbxSistemas.SelectedIndex = -1
            wPrimeraVez = False
            cbxSistemas.SelectedIndex = 0
        Else
            wPrimeraVez = False
        End If


    End Sub

    Private Sub udfCargaDeDatos(ByVal pCarga As Boolean)
        If Not pCarga OrElse dtOpcion Is Nothing _
            OrElse dtOpcion.Rows.Count = 0 _
            OrElse dgvOpciones.DataSource Is Nothing _
            OrElse dtOpcion.Rows(dgvOpciones.CurrentCell.RowIndex).RowState = DataRowState.Deleted Then
            'lblSistema.Text = ""
            'lblModulo.Text = ""
            'wIDSistema = 0
            'wCodModulo = ""
            'dgvOpciones.DataSource = Nothing
            lblSistema.Text = cbxSistemas.Text
            If dtModulo Is Nothing OrElse dtModulo.Rows.Count = 0 Then
                lblModulo.Text = "?"
            Else
                lblModulo.Text = dtModulo.Rows.Item(dgvModulos.CurrentCell.RowIndex)("Descripcion")
            End If


            txtCodNivel.Text = ""
            txtOpcion.Text = ""
            chkRevalidar.Checked = False
            txtProceso.Text = ""
        Else
            With dgvOpciones '.DataSource = dtOpcion

                wIDSistema = .Rows.Item(.CurrentCell.RowIndex).Cells("IDSistema").Value
                wCodModulo = .Rows.Item(.CurrentCell.RowIndex).Cells("CodModulo").Value

                If wIDSistema = cbxSistemas.SelectedValue Then
                    lblSistema.Text = CStr(wIDSistema) & " | " & cbxSistemas.Text
                Else
                    lblSistema.Text = "?"
                End If

                If wCodModulo = dgvModulos.Rows.Item(dgvModulos.CurrentCell.RowIndex).Cells("CodModulo").Value Then
                    lblModulo.Text = wCodModulo & " | " & dgvModulos.Rows.Item(dgvModulos.CurrentCell.RowIndex).Cells("Descripcion").Value
                Else
                    lblModulo.Text = "?"
                End If

                txtCodNivel.Text = .Rows.Item(.CurrentCell.RowIndex).Cells("CodNivel").Value
                txtOpcion.Text = .Rows.Item(.CurrentCell.RowIndex).Cells("Opcion").Value
                If IsDBNull(.Rows.Item(.CurrentCell.RowIndex).Cells("Revalidar").Value) Then
                    chkRevalidar.Checked = False
                    txtProceso.Text = ""
                Else
                    chkRevalidar.Checked = .Rows.Item(.CurrentCell.RowIndex).Cells("Revalidar").Value
                    If IsDBNull(.Rows.Item(.CurrentCell.RowIndex).Cells("Proceso").Value) Then
                        txtProceso.Text = ""
                    Else
                        txtProceso.Text = .Rows.Item(.CurrentCell.RowIndex).Cells("Proceso").Value
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub udfBotones(ByVal pHabilitar As Boolean)
        tsbCrear.Enabled = IIf(pHabilitar, SesionUsuario.udfActivarOpcion(wModuloPadre, "41"), False)
        tsbEditar.Enabled = IIf(pHabilitar, SesionUsuario.udfActivarOpcion(wModuloPadre, "42"), False)
        tsbDeshacer.Enabled = Not pHabilitar
        tsbGrabar.Enabled = Not pHabilitar
        tsbBorrar.Enabled = IIf(pHabilitar, SesionUsuario.udfActivarOpcion(wModuloPadre, "43"), False)
        tsbRecargar.Enabled = pHabilitar
        tsbSalir.Enabled = pHabilitar
        'dgvModulos.Enabled = pHabilitar
        'cbxSistemas.Enabled = pHabilitar
        gbxSistemas.Enabled = pHabilitar
        gbxModulos.Enabled = pHabilitar
    End Sub

    Private Sub udfActivarCampos(ByVal pActivar As Boolean)
        If pActivar And wCrear Then
            txtCodNivel.Enabled = True
        Else
            txtCodNivel.Enabled = False
        End If
        txtOpcion.Enabled = pActivar
        chkRevalidar.Enabled = pActivar
        txtProceso.Enabled = pActivar
    End Sub

    Private Sub tsbCrear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCrear.Click, tsbEditar.Click, tsbDeshacer.Click, tsbGrabar.Click, tsbBorrar.Click, tsbRecargar.Click, tsbSalir.Click
        Select Case CType(sender, ToolStripButton).Name.ToString
            Case "tsbCrear"
                If dtModulo Is Nothing OrElse dtModulo.Rows.Count = 0 Then
                    MsgBox("Modulo no definido para el sistema")
                Else
                    wCrear = True
                    wEditar = False
                    udfActivarCampos(True)
                    udfCargaDeDatos(False)
                    udfBotones(False)
                    txtCodNivel.Focus()
                End If
            Case "tsbEditar"
                If dtModulo Is Nothing OrElse dtModulo.Rows.Count = 0 Then
                    MsgBox("Modulo no definido para el sistema")
                Else
                    If txtCodNivel.Text.Length > 0 Then
                        wEditar = True
                        wCrear = False
                        udfActivarCampos(True)
                        udfBotones(False)
                        txtOpcion.Focus()
                    Else
                        MsgBox("No existe Opción a Editar")
                    End If
                End If
            Case "tsbDeshacer"
                wCrear = False
                wEditar = False
                udfActivarCampos(False)
                udfCargaDeDatos(True)
                udfBotones(True)
            Case "tsbGrabar"
                ' validar datos
                If wIDSistema <= 0 Then
                    MsgBox("No ha definido Sistema para la Opción.")
                    cbxSistemas.Focus()
                    Exit Sub
                End If
                If wCodModulo.Length = 0 Then
                    MsgBox("No ha definido Módulo para la Opción.")
                    dgvModulos.Focus()
                    Exit Sub
                End If
                If txtCodNivel.Text.Length = 0 Then
                    MsgBox("Defina un Código de Nivel para la Opción.")
                    txtCodNivel.Focus()
                    Exit Sub
                End If
                If txtOpcion.Text.Length = 0 Then
                    MsgBox("Falta Nombre de la Opción.")
                    txtOpcion.Focus()
                    Exit Sub
                End If
                '-- Grabar datos Nuevos / Editados
                If wCrear Then
                    If oWFOpcion.udfCrearOpcion(wIDSistema, wCodModulo, txtCodNivel.Text, txtOpcion.Text, chkRevalidar.Checked, txtProceso.Text) Then
                        '-- Agrega datos de forma Local --
                        Dim xDr As DataRow = dtOpcion_O.NewRow
                        xDr("IDSistema") = wIDSistema
                        xDr("CodModulo") = wCodModulo
                        xDr("CodNivel") = txtCodNivel.Text
                        xDr("Opcion") = txtOpcion.Text
                        xDr("Revalidar") = chkRevalidar.Checked
                        xDr("Proceso") = txtProceso.Text
                        dtOpcion_O.Rows.Add(xDr)
                        'dtOpcion.ImportRow(xDr)

                        '-- Filtra table de Opciones para el Modulo Seleccionado
                        udfVerOpcionesDeModulo()

                        '-- Posicionando en la nueva fila
                        udfPosicionaFila(xDr("CodNivel"))
                        'dgvOpciones.CurrentCell = dgvOpciones.Rows(dgvOpciones.Rows.Count - 1).Cells("CodNivel")
                    Else
                        Exit Sub
                    End If
                ElseIf wEditar Then
                    If oWFOpcion.udfEditarOpcion(wIDSistema, wCodModulo, txtCodNivel.Text, txtOpcion.Text, chkRevalidar.Checked, txtProceso.Text) Then
                        '-- Actualiza los datos de forma local --
                        Dim xLin As Integer
                        xLin = Val(dgvOpciones.CurrentCell.RowIndex.ToString)
                        With dtOpcion
                            .Rows(xLin)("Opcion") = txtOpcion.Text
                            .Rows(xLin)("Revalidar") = chkRevalidar.Checked
                            If chkRevalidar.Checked Then
                                .Rows(xLin)("Proceso") = txtProceso.Text
                            Else
                                .Rows(xLin)("Proceso") = ""
                            End If
                        End With
                        '-- Actualizar tabla Origen
                        '... crear indices (PK) 
                        Dim xBuscarPK(2) As Object
                        xBuscarPK(0) = wIDSistema
                        xBuscarPK(1) = wCodModulo
                        xBuscarPK(2) = txtCodNivel.Text
                        '... busca PK
                        Dim xFoundRow As DataRow = dtOpcion_O.Rows.Find(xBuscarPK)
                        If Not (xFoundRow Is Nothing) Then
                            '... modifica dato
                            xFoundRow("Opcion") = txtOpcion.Text
                            xFoundRow("Revalidar") = chkRevalidar.Checked
                            xFoundRow("Proceso") = txtProceso.Text
                        End If
                    Else
                        Exit Sub
                    End If

                Else
                    Exit Sub
                End If
                wCrear = False
                wEditar = False
                udfActivarCampos(False)

                udfBotones(True)

            Case "tsbRecargar"
                'dtModulo = oWFModulo.udfVerModulo()
                'If Not dtModulo Is Nothing Then
                '    dgvModulos.DataSource = dtModulo
                'End If

            Case "tsbBorrar"
                If MsgBox("Seguro que desea borrar la Opción:" & vbCrLf & txtCodNivel.Text & " - " & txtOpcion.Text, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Borra Opción") = MsgBoxResult.Yes Then
                    If oWFOpcion.udfBorrarOpcion(wIDSistema, wCodModulo, txtCodNivel.Text) Then
                        Dim xBuscarPK(2) As Object
                        xBuscarPK(0) = wIDSistema
                        xBuscarPK(1) = wCodModulo
                        xBuscarPK(2) = txtCodNivel.Text
                        ' buscando PK a eliminar
                        dtOpcion_O.Rows.Find(xBuscarPK).Delete()
                        dtOpcion_O.AcceptChanges()
                        dtOpcion.Rows.Find(xBuscarPK).Delete()
                        dtOpcion.AcceptChanges()
                        'If Not (xFoundRow Is Nothing) Then
                        '    ' elimina Fila de tabla de origen y la actual
                        '    dtOpcion_O.Rows.Remove(xFoundRow)
                        '    dtOpcion.Rows.Remove(xFoundRow)
                    End If
                End If

            Case "tsbSalir"
                If wCrear Or wEditar Then
                    If MsgBox("Aun no termina ingreso de datos." & vbCrLf & "¿Esta seguro de Salir?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Opciones") = MsgBoxResult.Yes Then
                        Me.Close()
                    End If
                Else
                    Me.Close()
                End If
        End Select
    End Sub

    Private Sub udfPosicionaFila(ByVal pCodNivel As String)
        With dgvOpciones
            For i = 0 To dgvOpciones.Rows.Count - 1
                If .Rows(i).Cells("CodNivel").Value.ToString = pCodNivel Then
                    .Rows(i).Selected = True
                    .CurrentCell = .Rows(i).Cells("CodNivel")
                    Exit For
                End If
            Next
        End With
    End Sub

    Private Sub udfVerOpcionesDeModulo()
        If Not wPrimeraVez Then
            If Not dtModulo Is Nothing AndAlso dtModulo.Rows.Count > 0 AndAlso Not dtOpcion_O Is Nothing Then
                wCodModulo = dtModulo.Rows.Item(dgvModulos.CurrentCell.RowIndex)("CodModulo")

                '-- Filtra table de Opciones para el Modulo Seleccionado
                Dim xDr() As DataRow
                xDr = dtOpcion_O.Select("IDSistema=" & wIDSistema & " AND CodModulo='" & wCodModulo & "'", "CodNivel")
                If xDr.Length > 0 Then
                    dtOpcion = xDr.CopyToDataTable
                    '-- creando indices del PK en tabla filtrada de Opciones
                    Dim xCols(2) As DataColumn
                    With dtOpcion
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

                    With dgvOpciones
                        '-- Referencia Datos a la rejilla --
                        .DataSource = dtOpcion
                        '-- Configura columnas
                        .Columns("IDSistema").Visible = False
                        .Columns("CodModulo").Visible = False
                        .AutoResizeColumns()
                        .CurrentCell = .Rows(0).Cells("CodNivel")
                    End With
                    'udfCargaDeDatos(True)

                Else
                    dgvOpciones.DataSource = Nothing
                    udfCargaDeDatos(False)
                End If
            Else
                dgvOpciones.DataSource = Nothing
                udfCargaDeDatos(False)
            End If
        End If
    End Sub

    Private Sub dgvModulos_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvModulos.CellEnter
        udfVerOpcionesDeModulo()
    End Sub

    Private Sub txtCodNivel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodNivel.KeyPress
        If Asc(e.KeyChar) = Keys.Return Then
            txtOpcion.Focus()
        End If
    End Sub

    Private Sub txtOpcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOpcion.KeyPress
        If Asc(e.KeyChar) = Keys.Return Then
            'ToolStrip1.Focus()
            'tsbGrabar.Select()
            chkRevalidar.Focus()
        End If
    End Sub

    Private Sub cbxSistemas_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbxSistemas.SelectedValueChanged
        '-- cuando cambia de sistema, vuelve a cargar de la BD sus Opciones.
        If Not wPrimeraVez Then
            If cbxSistemas.ValueMember.ToString.Length > 0 Then
                wIDSistema = cbxSistemas.SelectedValue
                dtOpcion_O = oWFOpcion.udfVerOpcion(wIDSistema)
                dgvOpciones.DataSource = Nothing
                '-- creando indices del PK en tabla Origen
                Dim xCols(2) As DataColumn
                With dtOpcion_O
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
                '
                '-- carga Modulos asignados al sistema
                dtModulo = oWFSistema.XMLADataTable(CType(cbxSistemas.SelectedItem, DataRowView).Item("XMLModulos").ToString)
                dgvModulos.DataSource = dtModulo

                udfVerOpcionesDeModulo()
                ' ingresa a rejilla de modulos para actualizar datos de opciones.
                'With dgvModulos
                '    If Not .DataSource Is Nothing Then
                '        If .CurrentCell.RowIndex >= 0 Then
                '            '.CurrentCell = 
                '            If .Columns(.CurrentCell.ColumnIndex).Name <> "CodModulo" Then
                '                .CurrentCell = .Rows(0).Cells("CodModulo")
                '            Else
                '                .CurrentCell = .Rows(0).Cells("Descripcion")
                '                .CurrentCell = .Rows(0).Cells("CodModulo")
                '            End If
                '        End If
                '    End If
                'End With
            End If
        End If
    End Sub

    Private Sub cbxSistemas_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbxSistemas.SelectionChangeCommitted
        ''-- cuando cambia de sistema, vuelve a cargar de la BD sus Opciones.
        'If cbxSistemas.SelectedIndex >= 0 Then
        '    wIDSistema = cbxSistemas.SelectedValue
        '    dtOpcion_O = oWFOpcion.udfVerOpcion(wIDSistema)
        '    '-- creando indices del PK en tabla Origen
        '    Dim xCols(2) As DataColumn
        '    With dtOpcion_O
        '        If Not .Columns("IDSistema") Is Nothing And _
        '            Not .Columns("CodModulo") Is Nothing And _
        '            Not .Columns("CodNivel") Is Nothing Then
        '            ' indexa columna
        '            xCols(0) = .Columns("IDSistema")
        '            xCols(1) = .Columns("CodModulo")
        '            xCols(2) = .Columns("CodNivel")
        '            .PrimaryKey = xCols
        '        End If
        '    End With
        'End If
    End Sub

    Private Sub dgvOpciones_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOpciones.CellEnter
        If Not wPrimeraVez Then
            If Not dtOpcion Is Nothing AndAlso dtOpcion.Rows.Count > 0 Then
                udfCargaDeDatos(True)
            Else
                udfCargaDeDatos(False)
            End If
        End If
    End Sub

    Private Sub dgvModulos_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvModulos.Enter
        Dim x As Integer
        x = 1
        'dgvModulos.
    End Sub

    Private Sub chkRevalidar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRevalidar.CheckedChanged
        If chkRevalidar.Checked Then
            'txtProceso.Text = txtProceso.Tag
            txtProceso.Visible = True
        Else
            'txtProceso.Tag = txtProceso.Text
            txtProceso.Text = ""
            txtProceso.Visible = False
        End If
    End Sub

    Private Sub chkRevalidar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkRevalidar.KeyPress
        If Asc(e.KeyChar) = Keys.Return Then
            If chkRevalidar.Checked Then
                txtProceso.Focus()
            Else
                ToolStrip1.Focus()
                tsbGrabar.Select()
            End If
        End If
    End Sub

    Private Sub txtProceso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProceso.KeyPress
        If Asc(e.KeyChar) = Keys.Return Then
            ToolStrip1.Focus()
            tsbGrabar.Select()
        End If
    End Sub

    Private Sub dgvModulos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvModulos.CellContentClick

    End Sub

    Private Sub cbxSistemas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxSistemas.SelectedIndexChanged

    End Sub
End Class