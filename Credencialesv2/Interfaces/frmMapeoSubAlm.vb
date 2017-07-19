Public Class frmMapeoSubAlm

    Private oWFUsuario As New WFUsuario
    Friend dtAlmacen As DataTable
    Friend dtSubAlm As DataTable
    Private dtSubAlmacenes As DataTable
    Friend _Almacen As String
    Friend _CodAlm As String
    Private dtSubAlmacenCheck As DataTable

    Private Sub frmMapeoSubAlm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If dtAlmacen Is Nothing Then
            If Not CargarControles() Then Return
        End If

        If btnGuardar.Text.Equals("Modificar") Then
            cbAlmacen.Text = _Almacen
            cbAlmacen.SelectedValue = _CodAlm
            cbAlmacen.Enabled = False

            LlenarSubAlmacenes()

            If dtSubAlm Is Nothing OrElse dtSubAlm.Rows.Count = 0 Then
                Me.Close()
            End If

            For Each dr As DataRow In dtSubAlm.Rows
                For i As Integer = 0 To dgvSubAlmacenes.Rows.Count - 1
                    With dgvSubAlmacenes.Rows(i)
                        If dr("Descripcion").Equals(.Cells("Descripcion").Value) Then
                            .Cells("RW1").Value = CBool(dr("RW"))
                            .Cells("Check").Value = True
                            .DefaultCellStyle.BackColor = Drawing.Color.LightGoldenrodYellow
                        End If
                    End With
                Next
            Next
        Else
            cbAlmacen.Enabled = False
            If btnGuardar.Text.Equals("Guardar") Then
                cbAlmacen.Enabled = True
                cbAlmacen.SelectedIndex = 0
                LlenarSubAlmacenes()
            End If
        End If



    End Sub

    Private Function CargarControles() As Boolean
        dtAlmacen = oWFUsuario.udfCargarAlmacenes

        If dtAlmacen Is Nothing OrElse dtAlmacen.Rows.Count = 0 Then
            MsgBox("No se encontraron 'Almacenes' registrados.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            Return False
        Else
            With cbAlmacen
                .DataSource = dtAlmacen
                .DisplayMember = dtAlmacen.Columns("Almacenes").ColumnName
                .ValueMember = dtAlmacen.Columns("CodAlmacen").ColumnName
            End With
        End If

        Return True
    End Function

    Private Sub cbAlmacen_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAlmacen.DropDownClosed
        LlenarSubAlmacenes()
        dgvSubAlmacenes.Focus()
    End Sub

    Private Sub LlenarSubAlmacenes()

        dtSubAlmacenes = oWFUsuario.udfVerSubAlmacenes(CType(cbAlmacen.DataSource, DataTable).Rows(cbAlmacen.SelectedIndex)("CodEmpresa"))

        If dtSubAlmacenes Is Nothing OrElse dtSubAlmacenes.Rows.Count = 0 Then
            MsgBox("No se encontraron 'SubAlmacenes' registrados.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            Exit Sub
        Else
            With dgvSubAlmacenes
                .DataSource = dtSubAlmacenes
                .Columns("Descripcion").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns("CodSubAlm").Visible = False
                .Columns("Comentario").Visible = False
                .Columns("RazonSocial").Visible = False
            End With
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Dim xSubAlmacenes As String = String.Empty
        Dim xDr As DataRow

        With dtSubAlmacenCheck
            If Not dtSubAlmacenCheck Is Nothing Then '
                If .Rows.Count > 0 Then
                    .Clear()
                End If
            Else
                Dim _StColumn As New DataColumn
                Dim _StColumnRW As New DataColumn
                'CodSubAlm
                Dim xDt As New DataTable
                With _StColumn
                    .ColumnName = "CodSubAlm"
                    .DataType = GetType(String)
                End With
                xDt.Columns.Add(_StColumn)
                'RW
                With _StColumnRW
                    .ColumnName = "RW"
                    .DataType = GetType(Boolean)
                End With
                xDt.Columns.Add(_StColumnRW)

                dtSubAlmacenCheck = xDt.Clone
            End If
        End With

        With dgvSubAlmacenes
            Dim i As Integer
            If .Rows.Count > 0 Then
                For i = 0 To .Rows.Count - 1
                    If .Rows(i).Cells("Check").Value Then
                        xDr = dtSubAlmacenCheck.NewRow
                        xDr("CodSubAlm") = .Rows(i).Cells("CodSubAlm").Value
                        xDr("RW") = CBool(.Rows(i).Cells("RW1").Value)
                        dtSubAlmacenCheck.Rows.Add(xDr)
                    End If
                Next
                xSubAlmacenes = oWFUsuario.DataTableAXML(dtSubAlmacenCheck)
            End If

            If btnGuardar.Text.Equals("Guardar") Then
                If MsgBox("¿Desea Guardar la configuración de accesos?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                    Return
                End If
                'grabar
                If oWFUsuario.udfGuardarAlmAccesos(lblUsuario.Text, xSubAlmacenes, _
                   CType(cbAlmacen.DataSource, DataTable).Rows(cbAlmacen.SelectedIndex)("CodAlmacen")) = False Then Exit Sub
            Else
                If MsgBox("¿Desea Actualizar la configuración de accesos?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                    Return
                End If
                If oWFUsuario.udfModificarAlmAccesos(lblUsuario.Text, xSubAlmacenes, _
                   CType(cbAlmacen.DataSource, DataTable).Rows(cbAlmacen.SelectedIndex)("CodAlmacen")) = False Then Exit Sub
            End If

            Me.Tag = "Ok"
            Me.Close()
        End With
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub dgvSubAlmacenes_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSubAlmacenes.CellClick
        If e.RowIndex = -1 Then Return
        With dgvSubAlmacenes
            If .Columns(e.ColumnIndex).Name.Equals("Check") Then
                .Rows(e.RowIndex).Cells("Check").Value = Not CBool(.Rows(e.RowIndex).Cells("Check").Value)
                If .Rows(e.RowIndex).Cells("Check").Value Then
                    .Rows(e.RowIndex).DefaultCellStyle.BackColor = Drawing.Color.LightGoldenrodYellow
                Else : .Rows(e.RowIndex).DefaultCellStyle.BackColor = Drawing.Color.White
                End If
            End If
            If .Columns(e.ColumnIndex).Name.Equals("RW1") Then
                .Rows(e.RowIndex).Cells("RW1").Value = Not CBool(.Rows(e.RowIndex).Cells("RW1").Value)
            End If
        End With
    End Sub
End Class