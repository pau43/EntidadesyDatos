Imports System.Windows.Forms
Imports GEACEntidades
Imports ModuloCentral

Public Class frmUsuarios

    Private oWFUsuario As New WFUsuario
    Private oWFRol As New WFRol
    Private oWFSistema As New WFSistema

    Dim dtPersona As New DataTable
    'Dim dtPersona_O As New DataTable
    Dim dtUsuario As New DataTable

    Dim dtSistema As DataTable
    Dim dtSucursal As DataTable
    Dim dtMapeoSistemaSucursal As DataTable

    Dim wTotalPaginas As Integer = 0
    Dim wPaginaActual As Integer = 1
    Dim wItemsPagina As Integer = 50
    Dim wPrimeraVez As Boolean = True
    Dim wCrear As Boolean
    Dim wEditar As Boolean

    Dim wIdPersona As Integer = -1

    Dim wNroRol As Integer
    Dim dtRoles As DataTable
    Dim wModuloPadre As String
    Dim wCargaDataMapeo_Ok As Boolean

    Dim wCambiarRegistroUsuario As Boolean
    Dim wTextoBuscado As String = String.Empty


    Private Sub frmUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'dtPersona = oWFPersona.udfVerPersonaActiva(wItemsPagina, wPaginaActual, wTotalPaginas)
        '' -- copia datos de origen, base para el filtro de datos
        'dtPersona_O = dtPersona.Copy
        wModuloPadre = Me.Tag
        udfBotones(True)
        tsb_Ver.PerformClick()

        If Not dtPersona Is Nothing Then
            udfActivarCampos(False)
        Else
            MsgBox("No existen datos en tabla Personas...", MsgBoxStyle.Critical)
            Me.Close()
        End If

        dtRoles = oWFRol.udfVerRol(0)
        If Not dtRoles Is Nothing Then
            If dtRoles.Rows.Count > 0 Then
                ' carga el ComboBox de Roles
                '-- Cargando datos de Sistemas --
                With cbxRol
                    ' Bloquea carga errada de datos del combo de Roles
                    .DataSource = dtRoles
                    .DisplayMember = dtRoles.Columns("Rol").ColumnName
                    .ValueMember = dtRoles.Columns("NroRol").ColumnName
                End With
            End If
        End If
    End Sub

    Private Sub tsb_Ver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_Ver.Click
        dtPersona = oWFUsuario.udfVerPersonaActiva(wItemsPagina, wPaginaActual, wTotalPaginas, tstxt_Buscar.Text)
        ' -- copia datos de origen, base para el filtro de datos
        'dtPersona_O = dtPersona.Copy

        'If wPrimeraVez Then

        wPrimeraVez = False 'para evitar error en LOAD Form
        tslbl_DePag.Text = "de " + CStr(wTotalPaginas)
        tslbl_PagX.Text = "Pág.(x" & CStr(wItemsPagina) & "):"
        tscbx_Paginas.Items.Clear()
        For i = 1 To wTotalPaginas
            tscbx_Paginas.Items.Add(i)
        Next
        If tscbx_Paginas.Items.Count > 0 Then
            If wPaginaActual > 0 Then
                If wPaginaActual > wTotalPaginas Then
                    wPaginaActual = wTotalPaginas
                End If
                tscbx_Paginas.SelectedIndex = (wPaginaActual - 1)
            End If
        End If
        'tscbxPagina.SelectedIndex = 0
        'End If

        If Not dtPersona Is Nothing Then
            'tstxt_Buscar.Text = ""
            dgvPersonas.DataSource = dtPersona
            udfColumnasPersona()
            dgvPersonas.Focus()
        End If
    End Sub

    Private Sub udfColumnasPersona()
        'configurando columnas del Producto
        With dgvPersonas
            .Columns("IDPersona").Visible = True
            .Columns("ApPaterno").Visible = False
            .Columns("ApMaterno").Visible = False
            .Columns("Nombres").Visible = False
            .Columns("Nombre").Visible = True
            .Columns("Sexo").Visible = False
            .Columns("Activo").Visible = False
            .Columns("RowNumber").Visible = False
            .Columns("RowNumber").HeaderText = "NºOrd."

            '.AutoResizeColumns()
            .Columns("IDPersona").Width = 100
            .Columns("Nombre").Width = 400
            .Columns("RowNumber").Width = 100
        End With
    End Sub

    Private Sub tstxt_Buscar_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tstxt_Buscar.TextChanged

    End Sub
    Private Sub tstxt_Buscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tstxt_Buscar.KeyPress
        If Asc(e.KeyChar) = Keys.Return Then
            If wTextoBuscado <> tstxt_Buscar.Text Then
                wPaginaActual = 1
            End If
            tsb_Ver.PerformClick()
        End If
        'If Asc(e.KeyChar) = Keys.Return Then
        '    If dgvPersonas.Rows.Count > 0 Then
        '        dgvPersonas.Focus()
        '    End If
        'End If
    End Sub

    Private Sub tscbx_Paginas_GiveFeedback(ByVal sender As Object, ByVal e As System.Windows.Forms.GiveFeedbackEventArgs) Handles tscbx_Paginas.GiveFeedback

    End Sub

    'Private Sub tstxt_Buscar_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tstxt_Buscar.TextChanged
    '    'If Not wPrimeraVez Then
    '    '    If tstxt_Buscar.Text.Length > 0 Then
    '    '        Dim drFilter() As DataRow
    '    '        Dim wFiltroPor As String
    '    '        wFiltroPor = "Nombre Like '%" + tstxt_Buscar.Text + "%'"
    '    '        If dtPersona_O.Rows.Count > 0 Then
    '    '            drFilter = dtPersona_O.Select(wFiltroPor, "Nombre")
    '    '            If drFilter.Length > 0 Then
    '    '                dtPersona = drFilter.CopyToDataTable
    '    '            Else
    '    '                dtPersona = Nothing
    '    '            End If
    '    '            dgvPersonas.DataSource = dtPersona
    '    '        End If
    '    '    Else
    '    '        If dtPersona_O.Rows.Count > 0 Then
    '    '            dtPersona = dtPersona_O
    '    '            dgvPersonas.DataSource = dtPersona
    '    '        End If
    '    '    End If
    '    'End If
    'End Sub

    Private Sub tscbx_Paginas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tscbx_Paginas.KeyPress
        'If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then

        'End If
        If Asc(e.KeyChar) = Keys.Return Then
            tsb_Ver.PerformClick()
        End If
    End Sub

    Private Sub tscbx_Paginas_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tscbx_Paginas.TextChanged
        If Not wPrimeraVez Then
            If tscbx_Paginas.Items.Count > 0 Then
                wPaginaActual = Val(tscbx_Paginas.Text)
            End If
        End If
    End Sub

    Private Sub dgvPersonas_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPersonas.CellEnter
        udfCargaUsuariosDePersona()
    End Sub

    Private Sub udfCargaUsuariosDePersona()

        If dtPersona IsNot Nothing AndAlso dtPersona.Rows.Count > 0 Then
            wIdPersona = dgvPersonas.Rows.Item(dgvPersonas.CurrentCell.RowIndex).Cells("IDPersona").Value
            dtUsuario = oWFUsuario.udfVerUserPersona(wIdPersona)
            dgvUsuarios.DataSource = dtUsuario

            'udfCargaDeDatos(True)
            If dtUsuario IsNot Nothing AndAlso dtUsuario.Rows.Count > 0 Then
                With dgvUsuarios

                    If .Rows.Count > 0 Then
                        .CurrentCell = .Rows(0).Cells("Usuario")
                    End If
                    nudUsuarios.Minimum = 1
                    nudUsuarios.Maximum = dtUsuario.Rows.Count
                    nudUsuarios.Value = 1
                End With
            Else
                udfCargaDeDatos(False)
            End If
        Else
            udfCargaDeDatos(False)
        End If
    End Sub

    Private Sub dgvUsuarios_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUsuarios.CellEnter
        If dtPersona IsNot Nothing AndAlso dtPersona.Rows.Count > 0 Then
            If dtUsuario IsNot Nothing AndAlso dtUsuario.Rows.Count > 0 Then
                If Not tsbVolver.Visible Then
                    '-- En Modo USUARIOS --
                    udfCargaDeDatos(True)
                Else
                    '-- En Modo MAPEO --
                    If wEditar Then
                        udfCargaDatosMapeoUsuario()
                    End If
                End If
            End If            
        End If
    End Sub

    'Private Sub udfCargaU()

    Private Sub udfCargaDeDatos(ByVal pCargar As Boolean)
        If pCargar And dtUsuario IsNot Nothing And dtUsuario.Rows.Count > 0 Then
            '-- ver datos del usuario --
            With dgvUsuarios

                txtUsuario.Text = .Rows.Item(.CurrentCell.RowIndex).Cells("Usuario").Value ' dtUsuario.Rows.Item(0)("Usuario").ToString
                nudUsuarios.Value = .CurrentCell.RowIndex + 1
                txtNombre.Text = .Rows.Item(.CurrentCell.RowIndex).Cells("Nombre").Value 'dtUsuario.Rows.Item(0)("Nombre").ToString
                If .Rows.Item(.CurrentCell.RowIndex).Cells("Habilitado").Value Then 'dtUsuario.Rows.Item(0)("Habilitado") Then
                    chkHabilitado.Checked = True
                Else
                    chkHabilitado.Checked = False
                End If

                chbRemoto.Checked = CBool(.Rows.Item(.CurrentCell.RowIndex).Cells("Remoto").Value)

                If Not IsDBNull(.Rows.Item(.CurrentCell.RowIndex).Cells("NroRol").Value) AndAlso _
                    .Rows.Item(.CurrentCell.RowIndex).Cells("NroRol").Value > 0 Then
                    cbxRol.SelectedValue = .Rows.Item(.CurrentCell.RowIndex).Cells("NroRol").Value 'dtUsuario.Rows.Item(0)("NroRol")
                    cbxRol.Tag = .Rows.Item(.CurrentCell.RowIndex).Cells("NroRol").Value
                    chkRol.Checked = True
                Else
                    cbxRol.SelectedIndex = -1
                    cbxRol.Tag = 0
                    chkRol.Checked = False
                End If
                If dgvPersonas.Rows.Item(dgvPersonas.CurrentCell.RowIndex).Cells("Sexo").Value Then
                    'If dtPersona.Rows.Item(0)("Sexo") Then
                    picUserHe.Visible = True
                    picUserShe.Visible = False
                Else
                    picUserHe.Visible = False
                    picUserShe.Visible = True
                End If
            End With

        Else
            txtUsuario.Text = ""
            nudUsuarios.Value = nudUsuarios.Minimum
            txtNombre.Text = ""
            chkHabilitado.Checked = False
            chbRemoto.Checked = False
            picUserHe.Visible = False
            picUserShe.Visible = False
            cbxRol.SelectedIndex = -1
            cbxRol.Tag = 0
            chkRol.Checked = False

        End If
    End Sub

    Private Sub udfCargaDatosMapeoUsuario()
        If dtUsuario IsNot Nothing And dtUsuario.Rows.Count > 0 Then
            With dgvUsuarios
                txtUsuario.Text = .Rows.Item(.CurrentCell.RowIndex).Cells("Usuario").Value
            End With
            dtMapeoSistemaSucursal = oWFUsuario.udfVerAccesoSistemaSucursal(txtUsuario.Text)
            dgvMapeoSistemas.DataSource = dtMapeoSistemaSucursal
            '..ocultando Columnas
            dgvMapeoSistemas.Columns("IDSistema").Visible = False
            dgvMapeoSistemas.Columns("IDSucursal").Visible = False
            If dgvMapeoSistemas.Rows.Count > 0 Then
                dgvMapeoSistemas.AutoResizeColumns()
            End If
        End If
    End Sub

    Private Sub udfActivarCampos(ByVal pHabilitar As Boolean)
        If pHabilitar And wCrear Then
            txtUsuario.Enabled = True
        Else
            txtUsuario.Enabled = False
        End If
        'txtClave.Enabled = False
        txtNombre.Enabled = pHabilitar
        chkHabilitado.Enabled = pHabilitar
        chbRemoto.Enabled = pHabilitar
        chkRol.Enabled = pHabilitar

        If chkRol.Checked And pHabilitar Then
            cbxRol.Enabled = True
        Else
            cbxRol.Enabled = False
        End If
    End Sub

    'Private Sub dgvPersonas_ParentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvPersonas.ParentChanged
    '    ' mensaje de
    '    If dtPersona.Rows.Count > 0 Then
    '        Dim x As Int16
    '        x = 0
    '    End If
    'End Sub

    'Private Sub dgvPersonas_RowStateChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) Handles dgvPersonas.RowStateChanged
    '    If dtPersona.Rows.Count > 0 Then
    '        Dim x As Int16
    '        x = 0
    '    End If
    'End Sub

    Private Sub tsbCrear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCrear.Click, tsbEditar.Click, tsbDeshacer.Click, tsbGrabar.Click, tsbSalir.Click, tsbMapSis.Click, tsbReiniciaClave.Click
        Dim xEditaP As Boolean = False
        'Verifica que botón ha sido presionado
        Select Case CType(sender, ToolStripButton).Name.ToString
            Case "tsbCrear"
                'If txtUsuario.Text.Length > 0 Then
                '    MsgBox("Persona ya tiene asignado un Usuario.")
                'Else
                wCrear = True
                wEditar = False
                udfActivarCampos(True)
                udfCargaDeDatos(False)
                txtNombre.Text = dtPersona.Rows.Item(dgvPersonas.CurrentCell.RowIndex)("Nombre")
                udfBotones(False)
                TabUsuario.TabPages.Remove(tpgListado)
                TabUsuario.SelectedTab = tpgDatos
                txtUsuario.Focus()
                'End If
            Case "tsbEditar"
                If txtUsuario.Text.Length = 0 Then
                    MsgBox("Persona aun no se le asigna un Usuario.")
                Else
                    wEditar = True
                    wCrear = False
                    udfActivarCampos(True)
                    udfBotones(False)
                    TabUsuario.TabPages.Remove(tpgListado)
                    TabUsuario.SelectedTab = tpgDatos
                    txtNombre.Focus()
                End If
            Case "tsbDeshacer"
                With TabUsuario.TabPages
                    '.Remove(tpgDatos)
                    .Add(tpgListado)
                End With
                wCrear = False
                wEditar = False
                udfActivarCampos(False)
                udfCargaDeDatos(True)
                udfBotones(True)
            Case "tsbGrabar"

                ' validar datos
                If txtUsuario.Text.Length = 0 Then
                    MsgBox("Ingresar Usuario")
                    txtUsuario.Focus()
                    Exit Sub
                End If
                'If txtClave.Text.Length = 0 Then
                '    MsgBox("Ingresar Clave")
                '    txtClave.Focus()
                '    Exit Sub
                'End If

                If wCrear Then
                    If oWFUsuario.udfCrearUsuario(txtUsuario.Text, txtNombre.Text, wIdPersona, chbRemoto.Checked, wNroRol) Then
                    Else
                        MsgBox(oWFUsuario.Advertencia, MsgBoxStyle.Exclamation, Me.Text)
                        Exit Sub
                    End If
                ElseIf wEditar Then
                    If oWFUsuario.udfEditarUsuario(txtUsuario.Text, txtNombre.Text, chkHabilitado.Checked, chbRemoto.Checked, wNroRol) Then
                    Else
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
                With TabUsuario.TabPages
                    '.Remove(tpgDatos)
                    .Add(tpgListado)
                    udfCargaUsuariosDePersona()
                End With
                wCrear = False
                wEditar = False
                udfActivarCampos(False)
                '
                udfBotones(True)

            Case "tsbSalir"
                If wCrear Or wEditar Then
                    If MsgBox("Aun no termina ingreso de datos." & vbCrLf & "¿Esta seguro de Salir?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Usuario del Sistema") = MsgBoxResult.Yes Then
                        Me.Close()
                    End If
                Else
                    Me.Close()
                End If

            Case "tsbMapSis"
                If txtUsuario.Text.Length = 0 Then
                    MsgBox("Aun no asigna un Usuario a la Persona.")
                Else
                    wEditar = False
                    wCrear = False

                    udfBotones(False)
                    tsbDeshacer.Enabled = False
                    tsbGrabar.Enabled = False
                    tsbVolver.Visible = True
                    tsbMapSis.Visible = False
                    TabUsuario.TabPages.Remove(tpgDatos)
                    gbxPersonas.Visible = False
                    gbxMapeo.Visible = True
                    udfConfiguraMapeoSistemas()
                    wEditar = True
                    udfCargaDatosMapeoUsuario()
                End If

            Case "tsbReiniciaClave"
                If txtUsuario.Text.Length = 0 Then
                    MsgBox("Aun no asigna un Usuario a la Persona.")
                Else
                    If udfRevalidarAcceso(wModuloPadre, "13") Then
                        If oWFUsuario.udfReiniciaClaveUsuario(txtUsuario.Text) Then
                        End If
                    End If
                End If

        End Select
    End Sub

    Private Sub udfConfiguraMapeoSistemas()
        If Not wCargaDataMapeo_Ok Then
            dtSistema = oWFSistema.udfVerSistema()

            cbxSistemas.DataSource = dtSistema
            If dtSistema Is Nothing OrElse dtSistema.Rows.Count = 0 Then
                MsgBox("No existen Sistemas registrados." & vbCrLf & "Debe existir al menos uno para ingresar Opciones", MsgBoxStyle.Information, "Opciones del Sistema")
            Else
                cbxSistemas.DataSource = dtSistema
                cbxSistemas.DisplayMember = dtSistema.Columns("Descripcion").ColumnName
                cbxSistemas.ValueMember = dtSistema.Columns("IDSistema").ColumnName
            End If

            dtSucursal = oWFSistema.udfVerSucursal
            If dtSucursal Is Nothing Then
                MsgBox("No existen Sucursales en la Empresa." & vbCrLf & "Debe existir al menos una para ingresar los datos de Conexión", MsgBoxStyle.Information, "Sucursales")
            Else
                cbxSucursal.DataSource = dtSucursal
                cbxSucursal.DisplayMember = dtSucursal.Columns("Sucursal").ColumnName '& ", " & dtAlmacen.Columns("CodAlmacen").ColumnName
                cbxSucursal.ValueMember = dtSucursal.Columns("IDSucursal").ColumnName
                If dtSucursal.Rows.Count > 0 Then
                    cbxSucursal.SelectedValue = dtSucursal.Rows.Item(0)("IDSucursal")
                End If
            End If
            wCargaDataMapeo_Ok = True
        End If
    End Sub

    Private Sub udfBotones(ByVal pHabilitar As Boolean)
        tsbCrear.Enabled = IIf(pHabilitar, SesionUsuario.udfActivarOpcion(wModuloPadre, "11"), False)
        tsbEditar.Enabled = IIf(pHabilitar, SesionUsuario.udfActivarOpcion(wModuloPadre, "12"), False)
        tsbMapSis.Enabled = IIf(pHabilitar, SesionUsuario.udfActivarOpcion(wModuloPadre, "13"), False)
        tsbReiniciaClave.Enabled = IIf(pHabilitar, SesionUsuario.udfActivarOpcion(wModuloPadre, "14"), False)
        tsbDeshacer.Enabled = Not pHabilitar
        tsbGrabar.Enabled = Not pHabilitar
        tsbSalir.Enabled = pHabilitar
        gbxPersonas.Enabled = pHabilitar

    End Sub

    Private Sub cbxRol_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxRol.SelectedIndexChanged
        If chkRol.Checked Then
            If cbxRol.SelectedIndex >= 0 AndAlso cbxRol.ValueMember.Length > 0 Then
                wNroRol = cbxRol.SelectedValue
            End If
        Else
            wNroRol = 0
        End If
    End Sub

    Private Sub chkRol_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRol.CheckedChanged
        If cbxRol.Items.Count > 0 And chkRol.Enabled Then
            If chkRol.Checked Then
                cbxRol.Enabled = True
                cbxRol.SelectedValue = cbxRol.Tag
            Else
                cbxRol.SelectedIndex = -1
                cbxRol.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnAsignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignar.Click
        If dtMapeoSistemaSucursal IsNot Nothing And dtMapeoSistemaSucursal.Rows.Count > 0 Then
            Dim xDr() As DataRow
            xDr = dtMapeoSistemaSucursal.Select("IDSistema=" + cbxSistemas.SelectedValue.ToString + " AND IDSucursal=" + cbxSucursal.SelectedValue.ToString)
            If xDr.Length > 0 Then
                MsgBox("Sistema y Sucursal ya estan asignados a Usuario.")
                Exit Sub
            End If
        End If

        If oWFUsuario.udfAsignaSistemaUsuario(txtUsuario.Text, cbxSistemas.SelectedValue, cbxSucursal.SelectedValue) Then
            udfCargaDatosMapeoUsuario()
        End If
    End Sub

    Private Sub dgvMapeoSistemas_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMapeoSistemas.CellContentClick
        If dtMapeoSistemaSucursal IsNot Nothing AndAlso dtMapeoSistemaSucursal.Rows.Count > 0 Then
            If wEditar Then
                Dim xUsuario As String
                Dim xIDSistema As Integer
                Dim xIDSucursal As Integer
                With dgvMapeoSistemas
                    xUsuario = .Rows.Item(.CurrentCell.RowIndex).Cells("Usuario").Value
                    xIDSistema = .Rows.Item(.CurrentCell.RowIndex).Cells("IDSistema").Value
                    xIDSucursal = .Rows.Item(.CurrentCell.RowIndex).Cells("IDSucursal").Value
                End With

                Select Case dgvMapeoSistemas.Columns(e.ColumnIndex).Name
                    Case "Habilitado"
                        If oWFUsuario.udfHabilitarSistemaUsuario(xUsuario, xIDSistema, xIDSucursal) Then
                            With dgvMapeoSistemas.Rows(e.RowIndex).Cells("Habilitado")
                                If .Value Then
                                    .Value = False
                                Else
                                    .Value = True
                                End If
                            End With
                            'wEditar = False
                            'udfCargaDatosMapeoUsuario()
                            'wEditar = True
                        End If
                End Select
            End If
        End If
    End Sub


    Private Sub dgvMapeoSistemas_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMapeoSistemas.CellEnter

    End Sub

    Private Sub tsbVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbVolver.Click
        tsbVolver.Visible = False
        tsbMapSis.Visible = True
        udfBotones(True)
        wEditar = False
        With TabUsuario.TabPages
            .Remove(tpgListado)
            .Add(tpgDatos)
            .Add(tpgListado)
        End With
        gbxMapeo.Visible = False
        gbxPersonas.Visible = True
        udfCargaDeDatos(True)
    End Sub

    Private Sub nudUsuarios_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles nudUsuarios.MouseDown
        If dgvUsuarios.Rows.Count > 0 Then
            Dim xFilaNueva As Integer

            xFilaNueva = nudUsuarios.Value - 1
            With dgvUsuarios
                .CurrentCell = .Rows(xFilaNueva).Cells("Usuario")
            End With
        End If
    End Sub

    Private Sub dgvUsuarios_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUsuarios.CellContentClick

    End Sub

    Private Sub tstxt_Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tstxt_Buscar.Click

    End Sub

    
    Private Sub ToolStripLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel1.Click

    End Sub
End Class