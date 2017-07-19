Public Class FrmRptUsuariosRoles

    Private dtRoles As DataTable
    Private oWFRol As New WFRol
    Private oDtTrabajadores As DataTable = Nothing
    Private _PLetra As String = String.Empty
    Private dtUsuarios As New DataTable

    Private Sub FrmRptUsuariosRoles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarRoles()
    End Sub

    Private Sub CargarRoles()
        dtRoles = oWFRol.udfVerRol(0)
        If dtRoles Is Nothing Or dtRoles.Rows.Count = 0 Then
            MsgBox("No se ha definido Rol alguno.")
            Me.Close()
        End If
        If dtRoles.Rows.Count > 0 Then
            With cbxRol
                '-- Ordena Alfabeticamente
                'dtRoles = dtRoles.Select("NroRol>0", "Rol ASC").CopyToDataTable
                ' Bloquea carga errada de datos del combo de Roles
                .DataSource = dtRoles
                .DisplayMember = dtRoles.Columns("Rol").ColumnName
                .ValueMember = dtRoles.Columns("NroRol").ColumnName
                .SelectedIndex = -1
            End With
        End If
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

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        dgvUsuarios.DataSource = Nothing
        Dim user As String = String.Empty
        Dim idPer As Integer = -1, nroRol As Integer = -1

        If txtUsuario.Text.Trim.Length > 0 Then user = txtUsuario.Text
        If CboPersonal.SelectedValue <> Nothing Then idPer = CboPersonal.SelectedValue
        If cbxRol.SelectedValue <> Nothing Then nroRol = cbxRol.SelectedValue

        dtUsuarios = oWFRol.fduBuscarUsuarioRoles(chbHabilitados.Checked, chbRemotos.Checked, nroRol, user, idPer)
        If dtUsuarios Is Nothing OrElse dtUsuarios.Rows.Count = 0 Then
            MsgBox("No se encontró datos para mostrar.", MsgBoxStyle.Critical, Me.Text)
            Return
        End If

        dgvUsuarios.DataSource = dtUsuarios
    End Sub
End Class