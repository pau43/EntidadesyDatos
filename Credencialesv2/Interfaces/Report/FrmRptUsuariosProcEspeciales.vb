Public Class FrmRptUsuariosProcEspeciales

    Private dtSistema As DataTable
    Private dtModulos As DataTable
    Private oWFRol As New WFRol
    Private oWFSistema As New WFSistema
    Private oWFModulo As New WFModulo
    Private oDtTrabajadores As DataTable = Nothing
    Private _PLetra As String = String.Empty
    Private dtUsuarios As New DataTable

    Private Sub FrmRptUsuariosProcEspeciales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarSistema()
        CargarModulos()
    End Sub

    Private Sub CboPersonal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboPersonal.TextChanged
        Dim TextoActual As String = String.Empty

        With CboPersonal
            If .Text.Trim.Length = 0 Then
                _PLetra = String.Empty
            Else
                If _PLetra <> .Text.Substring(0, 1) Then
                    _PLetra = .Text.Substring(0, 1)
                    TextoActual = .Text
                    oDtTrabajadores = oWFRol.fduBuscarPersonasXApellido(.Text.Substring(0, 1))

                    If oDtTrabajadores.Rows.Count = 0 Then
                        MsgBox("No se encontró personal que empiece con: " & .Text.Substring(0, 1), MsgBoxStyle.Critical, Me.Text)
                        Return
                    End If

                    .ValueMember = "IDPersona"
                    .DisplayMember = "Nombre"
                    .DataSource = oDtTrabajadores.Copy()
                    .Text = TextoActual
                    .SelectionStart = .Text.Length()
                End If
            End If
        End With

    End Sub
    Private Sub CboPersonal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboPersonal.LostFocus
        If oDtTrabajadores Is Nothing OrElse oDtTrabajadores.Rows.Count = 0 Then Return
        If Not CboPersonal.SelectedValue Is Nothing Then
            CboPersonal.Text = oDtTrabajadores.Rows(CboPersonal.SelectedIndex)("Nombre").ToString
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
                .DataSource = dtSistema
                .DisplayMember = dtSistema.Columns("Descripcion").ColumnName
                .ValueMember = dtSistema.Columns("IDSistema").ColumnName
                .SelectedIndex = -1
            End With
        End If
    End Sub
    Private Sub CargarModulos()
        dtModulos = oWFModulo.udfVerModulo
        If dtModulos Is Nothing Or dtModulos.Rows.Count = 0 Then
            MsgBox("No se ha definido Modulo.")
            Me.Close()
        End If
        If dtModulos.Rows.Count > 0 Then
            With cbModulo
                .DataSource = dtModulos
                .DisplayMember = dtModulos.Columns("Descripcion").ColumnName
                .ValueMember = dtModulos.Columns("CodModulo").ColumnName
                .SelectedIndex = -1
            End With
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        dgvUsuarios.DataSource = Nothing
        Dim user As String = String.Empty
        Dim idPer As Integer = -1, idSist As Integer = -1
        Dim codModulo As String = String.Empty

        If txtUsuario.Text.Trim.Length > 0 Then user = txtUsuario.Text
        If CboPersonal.SelectedValue <> Nothing Then idPer = CboPersonal.SelectedValue
        If cbSistema.SelectedValue <> Nothing Then idSist = cbSistema.SelectedValue
        If cbModulo.SelectedValue <> Nothing Then codModulo = cbModulo.SelectedValue

        dtUsuarios = oWFRol.fduBuscarUsuarioProcEsp(chbHabilitados.Checked, user, idPer, idSist, codModulo)
        If dtUsuarios Is Nothing OrElse dtUsuarios.Rows.Count = 0 Then
            MsgBox("No se encontró datos para mostrar.", MsgBoxStyle.Critical, Me.Text)
            Return
        End If

        dgvUsuarios.DataSource = dtUsuarios
    End Sub
End Class