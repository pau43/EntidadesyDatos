Imports System.Windows.Forms
Imports GEACEntidades

Public Class frmSistemas

    Private oWFSistema As New WFSistema
    Private dtSistema As DataTable
    Private dtSucursal As DataTable
    Private dtConexion As DataTable

    Dim wIDSistema As Integer
    Dim wCrear As Boolean
    Dim wEditar As Boolean
    Dim wCrearCnx As Boolean
    Dim wEditarCnx As Boolean
    Dim wModuloPadre As String

    Private Sub frmSistemas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        wModuloPadre = Me.Tag
        ' bloquea ingreso de datos 
        udfActivarCampos(False)
        udfBotones(True)
        dtSucursal = oWFSistema.udfVerSucursal
        If dtSucursal Is Nothing Then
            MsgBox("No existen Sucursales en la Empresa." & vbCrLf & "Debe existir al menos una para ingresar los datos de Conexión", MsgBoxStyle.Information, "Sucursales")
        Else
            cbx_Sucursal.DataSource = dtSucursal
            cbx_Sucursal.DisplayMember = dtSucursal.Columns("Sucursal").ColumnName '& ", " & dtAlmacen.Columns("CodAlmacen").ColumnName
            cbx_Sucursal.ValueMember = dtSucursal.Columns("IDSucursal").ColumnName
            If dtSucursal.Rows.Count > 0 Then
                cbx_Sucursal.SelectedValue = dtSucursal.Rows.Item(0)("IDSucursal")
            End If
        End If
        'dgvSistemas.ColumnHeadersDefaultCellStyle=  

        tsbRecargar.PerformClick()
    End Sub

    Private Sub udfCargaDeDatos(ByVal pCargar As Boolean)
        If pCargar And Not dtSistema Is Nothing And dtSistema.Rows.Count > 0 Then
            Dim xRow As Integer
            Dim xXML As String
            xRow = dgvSistemas.CurrentCell.RowIndex
            txtIDSistema.Text = dtSistema.Rows.Item(xRow)("IDSistema")
            txtDescripcion.Text = dtSistema.Rows.Item(xRow)("Descripcion")
            txtCadenaConexion.Text = dtSistema.Rows.Item(xRow)("CadenaConexion")
            txtConexionRemota.Text = dtSistema.Rows.Item(xRow)("ConexionRemota")
            chkActivo.Checked = dtSistema.Rows.Item(xRow)("Activo")
            lblSistema.Text = txtIDSistema.Text + "-" + txtDescripcion.Text
            xXML = dtSistema.Rows.Item(xRow)("XMLCadCnx").ToString
            udfCargaConexion(True, xXML)
        Else
            txtIDSistema.Text = ""
            txtDescripcion.Text = ""
            txtCadenaConexion.Text = ""
            txtConexionRemota.Text = ""
            chkActivo.Checked = True
            udfCargaConexion(False)
        End If
    End Sub

    Private Sub udfRecargaCadCnx()
        '-- Cuando se Crea / Edita la Cadena de Conexión (Login)
        '   Se vuelve a jalar los datos de la BD
        '   SOLO DEL IDSISTEMA DE LA FILA ACTUAL.
        dtConexion = oWFSistema.udfVerLoginConexion(CInt(txtIDSistema.Text))
        If Not dtConexion Is Nothing AndAlso dtConexion.Rows.Count > 0 Then
            ' Convertir tabla a XML para anexarlo en campo de Sistemas
            Dim xXML As String
            xXML = oWFSistema.DataTableAXML(dtConexion)
            dtSistema.Rows.Item(dgvSistemas.CurrentCell.RowIndex)("XMLCadCnx") = xXML
            dgv_TipoConexion.DataSource = dtConexion
        End If
    End Sub


    Private Sub udfCargaConexion(ByVal pCargar As Boolean, Optional ByVal pXML As String = "")
        If pCargar Then 'And pXML.Length > 0 Then
            dtConexion = oWFSistema.XMLADataTable(pXML) '.udfVerLoginConexion(CInt(txtIDSistema.Text))
            If Not dtConexion Is Nothing Then 'And dtConexion.Rows.Count > 0 Then
                dgv_TipoConexion.DataSource = dtConexion
                udfColumnasConexion()
                'udfCargaDeDatosCnx(True)
            Else
                pCargar = False
            End If
        End If

        If Not pCargar Then
            dgv_TipoConexion.DataSource = Nothing
            udfCargaDeDatosCnx(False)
        End If
    End Sub

    Private Sub udfColumnasConexion()
        If dtConexion.Rows.Count > 0 Then
            With dgv_TipoConexion
                .Columns("IDSistema").Visible = False
                .Columns("IDSucursal").Visible = False
                .Columns("UserId").Visible = True
                .Columns("Password").Visible = True
                .Columns("Remoto").Visible = True
            End With
        End If
    End Sub

    Private Sub udfCargaDeDatosCnx(ByVal pCarga As Boolean)
        If Not pCarga OrElse dtConexion Is Nothing OrElse dtConexion.Rows.Count = 0 Then
            cbx_Sucursal.SelectedValue = -1
            txt_UserId.Text = ""
            txt_Password.Text = ""
            rbtn_Local.Checked = True
        Else
            Dim xLin As Integer
            Dim xID As Integer
            xLin = dgv_TipoConexion.CurrentCell.RowIndex
            xID = dtConexion.Rows.Item(xLin)("IDSucursal")
            cbx_Sucursal.SelectedValue = xID
            txt_UserId.Text = dtConexion.Rows.Item(dgv_TipoConexion.CurrentCell.RowIndex)("UserId")
            txt_Password.Text = dtConexion.Rows.Item(dgv_TipoConexion.CurrentCell.RowIndex)("Password")
            rbtn_Remoto.Checked = dtConexion.Rows.Item(dgv_TipoConexion.CurrentCell.RowIndex)("Remoto")
            rbtn_Local.Checked = Not rbtn_Remoto.Checked
        End If
    End Sub

    Private Sub udfBotonesCnx(ByVal pHabilitar As Boolean)
        tsb_Crear.Enabled = pHabilitar
        tsb_Editar.Enabled = pHabilitar
        tsb_Deshacer.Enabled = Not pHabilitar
        tsb_Grabar.Enabled = Not pHabilitar
        '-- inabilitando botones principales
        tsbCrear.Enabled = pHabilitar
        tsbEditar.Enabled = pHabilitar
        tsbRecargar.Enabled = pHabilitar
        tsbSalir.Enabled = pHabilitar
        dgvSistemas.Enabled = pHabilitar
    End Sub

    Private Sub udfActivarCamposCnx(ByVal pActivar As Boolean)
        If wCrearCnx And pActivar Then
            cbx_Sucursal.Enabled = True
        Else
            cbx_Sucursal.Enabled = False
        End If
        txt_UserId.Enabled = pActivar
        txt_Password.Enabled = pActivar
        rbtn_Local.Enabled = pActivar
        rbtn_Remoto.Enabled = pActivar
    End Sub

    Private Sub udfActivarCampos(ByVal pActivar As Boolean)
        'txtIDSistema.Enabled = pActivar
        txtDescripcion.Enabled = pActivar
        txtCadenaConexion.Enabled = pActivar
        txtConexionRemota.Enabled = pActivar
        chkActivo.Enabled = pActivar
    End Sub

    Private Sub udfBotones(ByVal pHabilitar As Boolean)
        tsbCrear.Enabled = IIf(pHabilitar, SesionUsuario.udfActivarOpcion(wModuloPadre, "21"), False)
        tsbEditar.Enabled = IIf(pHabilitar, SesionUsuario.udfActivarOpcion(wModuloPadre, "22"), False)
        tsbDeshacer.Enabled = Not pHabilitar
        tsbGrabar.Enabled = Not pHabilitar
        tsbRecargar.Enabled = pHabilitar
        tsbSalir.Enabled = pHabilitar
        dgvSistemas.Enabled = pHabilitar
        gbxTipoConexion.Enabled = pHabilitar
    End Sub

    Private Sub tsbCrear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCrear.Click, tsbEditar.Click, tsbDeshacer.Click, tsbGrabar.Click, tsbSalir.Click, tsbRecargar.Click
        Select Case CType(sender, ToolStripButton).Name.ToString
            Case "tsbCrear"
                wCrear = True
                wEditar = False
                udfActivarCampos(True)
                udfCargaDeDatos(False)
                udfBotones(False)
                txtDescripcion.Focus()
            Case "tsbEditar"
                wEditar = True
                wCrear = False
                udfActivarCampos(True)
                udfBotones(False)
                txtDescripcion.Focus()
            Case "tsbDeshacer"
                wCrear = False
                wEditar = False
                udfActivarCampos(False)
                udfCargaDeDatos(True)
                udfBotones(True)
            Case "tsbGrabar"
                ' validar datos
                If txtDescripcion.Text.Length = 0 Then
                    MsgBox("Falta Descripción del Sistema.")
                    txtDescripcion.Focus()
                    Exit Sub
                End If
                If txtCadenaConexion.Text.Length = 0 And txtConexionRemota.Text.Length = 0 Then
                    MsgBox("Defina al menos una Conexión.")
                    txtCadenaConexion.Focus()
                    Exit Sub
                End If

                '-- Grabar datos Nuevos / Editados
                If wCrear Then
                    Dim xIDSistema As Integer
                    If oWFSistema.udfCrearSistema(txtDescripcion.Text, txtCadenaConexion.Text.Trim, txtConexionRemota.Text.Trim, xIDSistema) Then
                        '-- Agrega datos de forma Local --
                        Dim xDr As DataRow = dtSistema.NewRow
                        xDr("IDSistema") = xIDSistema
                        xDr("Descripcion") = txtDescripcion.Text
                        xDr("CadenaConexion") = txtCadenaConexion.Text.Trim
                        xDr("ConexionRemota") = txtConexionRemota.Text.Trim
                        xDr("Activo") = chkActivo.Checked
                        dtSistema.Rows.Add(xDr)
                        '-- Posicionando en la nueva fila
                        dgvSistemas.CurrentCell = dgvSistemas.Rows(dgvSistemas.Rows.Count - 1).Cells("IDSistema")

                    Else
                        Exit Sub
                    End If
                ElseIf wEditar Then
                    If oWFSistema.udfEditarSistema(txtIDSistema.Text, txtDescripcion.Text, txtCadenaConexion.Text, txtConexionRemota.Text, chkActivo.Checked) Then
                        '-- Actualiza los datos de forma local --
                        Dim xLin As Integer
                        xLin = dgvSistemas.CurrentCell.RowIndex
                        With dtSistema
                            .Rows(xLin)("Descripcion") = txtDescripcion.Text
                            .Rows(xLin)("CadenaConexion") = txtCadenaConexion.Text
                            .Rows(xLin)("ConexionRemota") = txtConexionRemota.Text
                            .Rows(xLin)("Activo") = chkActivo.Checked
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
                dtSistema = oWFSistema.udfVerSistema()
                dgvSistemas.DataSource = dtSistema
                '-- Configura columnas --
                If Not dtSistema Is Nothing Then
                    dgvSistemas.Columns("XMLCadCnx").Visible = False
                End If

            Case "tsbSalir"
                If wCrear Or wEditar Then
                    If MsgBox("Aun no termina ingreso de datos." & vbCrLf & "¿Esta seguro de Salir?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Sistemas") = MsgBoxResult.Yes Then
                        Me.Close()
                    End If
                Else
                    Me.Close()
                End If
        End Select
    End Sub

    Private Sub dgvSistemas_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSistemas.CellEnter
        If dtSistema.Rows.Count > 0 Then
            wIDSistema = dtSistema.Rows.Item(dgvSistemas.CurrentCell.RowIndex)("IDSistema")
            udfCargaDeDatos(True)
        Else
            udfCargaDeDatos(False)
        End If
    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        If Asc(e.KeyChar) = Keys.Return Then
            txtCadenaConexion.Focus()
        End If
    End Sub

    Private Sub txtCadenaConexion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCadenaConexion.KeyPress
        If Asc(e.KeyChar) = Keys.Return Then
            txtConexionRemota.Focus()
        End If
    End Sub

    Private Sub txtConexionRemota_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConexionRemota.KeyPress
        If Asc(e.KeyChar) = Keys.Return Then
            chkActivo.Focus()
        End If
    End Sub

    Private Sub chkActivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkActivo.KeyPress
        If Asc(e.KeyChar) = Keys.Return Then
            'txtCadenaConexion.Focus()
            ToolStrip1.Focus()
            tsbGrabar.Select()
        End If
    End Sub

    Private Sub tsb_Crear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_Crear.Click, tsb_Editar.Click, tsb_Deshacer.Click, tsb_Grabar.Click
        Select Case CType(sender, ToolStripButton).Name.ToString
            Case "tsb_Crear"
                wCrearCnx = True
                wEditarCnx = False
                udfActivarCamposCnx(True)
                udfCargaDeDatosCnx(False)
                udfBotonesCnx(False)
                cbx_Sucursal.Focus()
            Case "tsb_Editar"
                If dtConexion Is Nothing Or _
                    dtConexion.Rows.Count = 0 Then
                    MsgBox("No existe conexión a Editar", MsgBoxStyle.Exclamation)
                Else
                    wEditarCnx = True
                    wCrearCnx = False
                    udfActivarCamposCnx(True)
                    udfBotonesCnx(False)
                    txt_UserId.Focus()
                End If

            Case "tsb_Deshacer"
                wCrearCnx = False
                wEditarCnx = False
                udfActivarCamposCnx(False)
                udfCargaDeDatosCnx(True)
                udfBotonesCnx(True)
            Case "tsb_Grabar"
                ' validar datos
                If cbx_Sucursal.SelectedValue <= 0 Then
                    MsgBox("Falta Sucursal para la Conexión.")
                    cbx_Sucursal.Focus()
                    Exit Sub
                End If
                If txt_UserId.Text.Length = 0 Then
                    MsgBox("Falta ID de Usuario de la Conexión.")
                    txt_UserId.Focus()
                    Exit Sub
                End If
                If txt_Password.Text.Length = 0 Then
                    MsgBox("Falta Password de la Conexión.")
                    txt_Password.Focus()
                    Exit Sub
                End If

                '-- Grabar datos Nuevos / Editados
                If wCrearCnx Then
                    If oWFSistema.udfCrearLoginConexion(txtIDSistema.Text, cbx_Sucursal.SelectedValue, txt_UserId.Text, txt_Password.Text, rbtn_Remoto.Checked) Then
                    Else
                        Exit Sub
                    End If
                ElseIf wEditarCnx Then
                    If oWFSistema.udfEditarLoginConexion(txtIDSistema.Text, cbx_Sucursal.SelectedValue, txt_UserId.Text, txt_Password.Text, rbtn_Remoto.Checked) Then
                    Else
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
                ' jala conexiones actualizadas desde la BD.
                udfRecargaCadCnx()

                wCrearCnx = False
                wEditarCnx = False
                'tsbRecargar.PerformClick()
                udfActivarCamposCnx(False)
                udfCargaDeDatosCnx(True)
                udfBotonesCnx(True)
        End Select
    End Sub


    Private Sub rbtn_Local_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtn_Local.CheckedChanged

        pic_Local.Visible = rbtn_Local.Checked
        pic_Remoto.Visible = Not rbtn_Local.Checked

    End Sub

    Private Sub dgv_TipoConexion_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_TipoConexion.CellEnter
        If dtConexion.Rows.Count > 0 Then
            udfCargaDeDatosCnx(True)
        Else
            udfCargaDeDatosCnx(False)
        End If
    End Sub

    Private Sub cbx_Sucursal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbx_Sucursal.KeyPress
        If Asc(e.KeyChar) = Keys.Return Then
            txt_UserId.Focus()
        End If
    End Sub

    Private Sub txt_UserId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_UserId.KeyPress
        If Asc(e.KeyChar) = Keys.Return Then
            txt_Password.Focus()
        End If
    End Sub

    Private Sub rbtn_Local_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbtn_Local.KeyPress, rbtn_Remoto.KeyPress
        If Asc(e.KeyChar) = Keys.Return Then
            ToolStrip2.Focus()
            tsb_Grabar.Select()
        End If
    End Sub

    Private Sub txt_Password_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Password.KeyPress
        If Asc(e.KeyChar) = Keys.Return Then
            rbtn_Local.Focus()
        End If
    End Sub
End Class