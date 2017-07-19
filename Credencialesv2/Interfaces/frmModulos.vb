Imports System.Windows.Forms
Imports GEACEntidades

Public Class frmModulos

    Private oWFModulo As New WFModulo
    Private dtModulo As DataTable

    Private oWFSistema As New WFSistema
    Private dtModuloAsignado As DataTable
    Private dtSistema As DataTable

    Dim wCrear As Boolean
    Dim wEditar As Boolean
    Dim wModuloPadre As String
    Dim wIDSistema As Integer

    Private Sub frmModulos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        wModuloPadre = Me.Tag
        tsbRecargar.PerformClick()

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


        udfBotones(True)
        'dtModulo = oWFModulo.udfVerModulo
        'If Not dtModulo Is Nothing Then
        '    dgvModulos.DataSource = dtModulo
        'End If

    End Sub

    Private Sub udfCargaDeDatos(ByVal pCarga As Boolean)
        If Not pCarga OrElse dtModulo Is Nothing OrElse dtModulo.Rows.Count = 0 Then
            txtCodModulo.Text = ""
            txtDescripcion.Text = ""
        Else
            txtCodModulo.Text = dtModulo.Rows.Item(dgvModulos.CurrentCell.RowIndex)("CodModulo")
            txtDescripcion.Text = dtModulo.Rows.Item(dgvModulos.CurrentCell.RowIndex)("Descripcion")
        End If
    End Sub

    Private Sub udfBotones(ByVal pHabilitar As Boolean)
        tsbCrear.Enabled = IIf(pHabilitar, SesionUsuario.udfActivarOpcion(wModuloPadre, "31"), False)
        tsbEditar.Enabled = IIf(pHabilitar, SesionUsuario.udfActivarOpcion(wModuloPadre, "32"), False)
        tsbDeshacer.Enabled = Not pHabilitar
        tsbGrabar.Enabled = Not pHabilitar
        tsbRecargar.Enabled = pHabilitar
        tsbSalir.Enabled = pHabilitar
        dgvModulos.Enabled = pHabilitar
    End Sub

    Private Sub udfActivarCampos(ByVal pActivar As Boolean)
        If pActivar And wCrear Then
            txtCodModulo.Enabled = True
        Else
            txtCodModulo.Enabled = False
        End If
        txtDescripcion.Enabled = pActivar
    End Sub

    Private Sub tsbCrear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCrear.Click, tsbEditar.Click, tsbDeshacer.Click, tsbGrabar.Click, tsbRecargar.Click, tsbSalir.Click
        Select Case CType(sender, ToolStripButton).Name.ToString
            Case "tsbCrear"
                wCrear = True
                wEditar = False
                udfActivarCampos(True)
                udfCargaDeDatos(False)
                udfBotones(False)
                txtCodModulo.Focus()
            Case "tsbEditar"
                If txtCodModulo.Text.Length > 0 Then
                    wEditar = True
                    wCrear = False
                    udfActivarCampos(True)
                    udfBotones(False)
                    txtDescripcion.Focus()
                Else
                    MsgBox("No existe Módulo a Editar")
                End If
            Case "tsbDeshacer"
                wCrear = False
                wEditar = False
                udfActivarCampos(False)
                udfCargaDeDatos(True)
                udfBotones(True)
            Case "tsbGrabar"
                ' validar datos
                If txtCodModulo.Text.Length = 0 Then
                    MsgBox("Defina un Código para el Módulo.")
                    txtCodModulo.Focus()
                    Exit Sub
                End If
                If txtDescripcion.Text.Length = 0 Then
                    MsgBox("Falta Descripción del Módulo.")
                    txtDescripcion.Focus()
                    Exit Sub
                End If


                '-- Grabar datos Nuevos / Editados
                If wCrear Then
                    If oWFModulo.udfCrearModulo(txtCodModulo.Text, txtDescripcion.Text) Then
                        '-- Agrega datos de forma Local --
                        Dim xDr As DataRow = dtModulo.NewRow
                        xDr("CodModulo") = txtCodModulo.Text
                        xDr("Descripcion") = txtDescripcion.Text
                        dtModulo.Rows.Add(xDr)
                        '-- Verifica referencia a DataGridView
                        If dgvModulos.DataSource Is Nothing Then
                            dgvModulos.DataSource = dtModulo
                            dgvModulos.AutoResizeColumns()
                        End If
                        '-- Posicionando en la nueva fila
                        dgvModulos.CurrentCell = dgvModulos.Rows(dgvModulos.Rows.Count - 1).Cells("CodModulo")
                    Else
                        Exit Sub
                    End If
                ElseIf wEditar Then
                    If oWFModulo.udfEditarModulo(txtCodModulo.Text, txtDescripcion.Text) Then
                        '-- Actualiza los datos de forma local --
                        Dim xLin As Integer
                        xLin = dgvModulos.CurrentCell.RowIndex
                        With dtModulo
                            .Rows(xLin)("Descripcion") = txtDescripcion.Text
                        End With
                    Else
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
                wCrear = False
                wEditar = False
                udfActivarCampos(False)
                udfCargaDeDatos(True)
                udfBotones(True)

            Case "tsbRecargar"
                dtModulo = oWFModulo.udfVerModulo()
                If Not dtModulo Is Nothing Then
                    dgvModulos.DataSource = dtModulo
                    dgvModulos.AutoResizeColumns()
                End If

            Case "tsbSalir"
                If wCrear Or wEditar Then
                    If MsgBox("Aun no termina ingreso de datos." & vbCrLf & "¿Esta seguro de Salir?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Modulos") = MsgBoxResult.Yes Then
                        Me.Close()
                    End If
                Else
                    Me.Close()
                End If
        End Select
    End Sub

    Private Sub txtCodModulo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodModulo.KeyPress
        If Asc(e.KeyChar) = Keys.Return Then
            txtDescripcion.Focus()
        End If
    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        If Asc(e.KeyChar) = Keys.Return Then
            ToolStrip1.Focus()
            tsbGrabar.Select()
        End If
    End Sub

    Private Sub dgvModulos_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvModulos.CellEnter
        If dtModulo.Rows.Count > 0 Then
            'wIDSistema = dtSistema.Rows.Item(dgvSistemas.CurrentCell.RowIndex)("IDSistema")
            udfCargaDeDatos(True)
        Else
            udfCargaDeDatos(False)
        End If
    End Sub

    Private Sub cbxSistemas_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbxSistemas.SelectedValueChanged
        '-- cuando cambia de sistema, vuelve a cargar de la BD sus Opciones.
        'If Not wPrimeraVez Then
        If cbxSistemas.ValueMember.ToString.Length > 0 Then
            wIDSistema = cbxSistemas.SelectedValue
            'dt = oWFOrdenC.XMLADataTable(CType(cbxPedidosAptos.SelectedItem, DataRowView).Item("XMLDetallePedido").ToString)
            dtModuloAsignado = oWFSistema.XMLADataTable(CType(cbxSistemas.SelectedItem, DataRowView).Item("XMLModulos").ToString)
            If dtModuloAsignado IsNot Nothing Then
                dgvModuloAsignado.DataSource = dtModuloAsignado
                dgvModuloAsignado.AutoResizeColumns()
            Else
                dgvModuloAsignado.DataSource = Nothing
            End If

            'dtOpcion_O = oWFOpcion.udfVerOpcion(wIDSistema)
            'dgvOpciones.DataSource = Nothing
            ''-- creando indices del PK en tabla Origen
            'Dim xCols(2) As DataColumn
            'With dtOpcion_O
            '    If Not .Columns("IDSistema") Is Nothing And _
            '        Not .Columns("CodModulo") Is Nothing And _
            '        Not .Columns("CodNivel") Is Nothing Then
            '        ' indexa columna
            '        xCols(0) = .Columns("IDSistema")
            '        xCols(1) = .Columns("CodModulo")
            '        xCols(2) = .Columns("CodNivel")
            '        .PrimaryKey = xCols
            '    End If
            'End With
            '                dtOpcion = dtOpcion_O.Copy

            'udfVerOpcionesDeModulo()
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
        'End If
    End Sub

    Private Sub btnIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIn.Click
        With dgvModulos
            If .Rows.Count > 0 And wIDSistema > 0 Then
                Dim xCodModulo As String
                Dim xDescripcion As String
                xCodModulo = .Rows(.CurrentCell.RowIndex).Cells("CodModulo").Value.ToString
                xDescripcion = .Rows(.CurrentCell.RowIndex).Cells("Descripcion").Value.ToString
                If oWFSistema.udfInOutModuloSistema(wIDSistema, xCodModulo, True) Then
                    Dim xDr As DataRow = dtModuloAsignado.NewRow

                    xDr("CodModulo") = xCodModulo
                    xDr("Descripcion") = xDescripcion
                    dtModuloAsignado.Rows.Add(xDr)
                    '-- Agrega a XML en Sistemas
                    dtSistema.Rows(cbxSistemas.SelectedIndex)("XMLModulos") = oWFSistema.DataTableAXML(dtModuloAsignado).ToString
                End If
            End If
        End With
    End Sub

    Private Sub btnOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOut.Click
        With dgvModuloAsignado
            If .Rows.Count > 0 Then
                'Dim xIDSistema As Integer
                Dim xCodModulo As String
                Dim xDr() As DataRow
                'xIDSistema = .Rows(.CurrentCell.RowIndex).Cells("IDSistema").Value
                xCodModulo = .Rows(.CurrentCell.RowIndex).Cells("CodModulo").Value.ToString
                If oWFSistema.udfInOutModuloSistema(wIDSistema, xCodModulo, False) Then
                    xDr = dtModuloAsignado.Select("CodModulo='" & xCodModulo & "'", "")
                    If xDr.Length > 0 Then
                        dtModuloAsignado.Rows.Remove(xDr(0))
                        dtSistema.Rows(cbxSistemas.SelectedIndex)("XMLModulos") = oWFSistema.DataTableAXML(dtModuloAsignado).ToString
                    End If
                End If
            End If
        End With
    End Sub
End Class