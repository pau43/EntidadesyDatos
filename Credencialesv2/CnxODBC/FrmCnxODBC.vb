Imports GEACEntidades.SesionUsuario

Public Class frmODBC
    Private Declare Function SQLConfigDataSource Lib "ODBCCP32.DLL" (ByVal hwndParent As Integer, ByVal fRequest As Integer, ByVal lpszDriver As String, ByVal lpszAttributes As String) As Integer
    Private Const vbAPINull As Integer = 0 ' NULL Pointer
    Private Const ODBC_ADD_DSN As Short = 1 ' Add data source
    Private Const ODBC_CONFIG_DSN As Short = 2 ' Add data source
    Private Const ODBC_REMOVE_DSN As Short = 3 ' Add data source
    Private Const ODBC_ADD_SYS_DSN As Short = 4 ' Add data source
    Private Const ODBC_CONFIG_SYS_DSN As Short = 5    'Configure (edit) data source
    Private Const ODBC_REMOVE_SYS_DSN As Short = 6    'Remove data source
    Dim wTipoODBC As Byte = 0   '(0):Datos,  (1):Reportes/Consultas
    Dim wConODBC_Rpt As Boolean
    Dim wUsuario As String = ""


    Private Sub frmODBC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If Me.Tag IsNot Nothing AndAlso Me.Tag.ToString.Length > 0 Then            
        '    wConODBC_Rpt = True
        '    wUsuario = GEACEntidades.SesionUsuario.Usuario
        '    CreateUserDSN_Rpt(False)
        '    CreateUserDSN_Rpt(True)
        'Else
        cbxRutaCnx.Visible = True
        wConODBC_Rpt = False
        picRpt.Visible = False
        'End If
    End Sub

    ''Public Sub CreateUserDSN(ByVal pCreaBorra As Boolean)
    ''    Dim intRet As Integer
    ''    Dim Driver As String
    ''    Dim Attributes As String
    ''    Dim xIP As String
    ''    Dim xDSN As String
    ''    Dim xRutaCnx As String
    ''    'Set the driver to SQL Server because it is most common.
    ''    If cbDriver.SelectedIndex = 0 Then
    ''        Driver = "SQL Server"
    ''    Else
    ''        Driver = "SQL Native Client"
    ''    End If
    ''    'Set the attributes delimited by null.
    ''    'See driver documentation for a complete
    ''    'list of supported attributes.
    ''    xRutaCnx = cbxRutaCnx.Text
    ''    If xRutaCnx = "Local_1" Then   'rbLocal.Checked Then
    ''        xIP = "100.100.100.202"
    ''        xDSN = "CnnGEAC"
    ''    ElseIf xRutaCnx = "R:Claro_5" Then   'rbRemoto.Checked Then
    ''        xIP = "190.81.24.129"
    ''        xDSN = "CnnGEAC"
    ''    ElseIf xRutaCnx = "L:Milton" Then   'rbMilton.Checked Then
    ''        xIP = "100.100.100.13\sqlserver2008"
    ''        xDSN = "CnnGEAC_2"
    ''    ElseIf xRutaCnx = "L:Irving" Then   'rbIrving.Checked Then
    ''        xIP = "100.100.100.176\developer"
    ''        xDSN = "CnnGEAC_1"
    ''    ElseIf xRutaCnx = "R:Movistar_2" Then   'rbRemotoMovistar.Checked Then
    ''        xIP = "190.40.69.144"
    ''        xDSN = "CnnGEAC"
    ''    ElseIf xRutaCnx = "R:Movistar_3" Then   'rbRemoto.Checked Then
    ''        xIP = "190.40.69.79"
    ''        xDSN = "CnnGEAC"
    ''    ElseIf xRutaCnx = "R:Movistar_4" Then   'rbRemoto.Checked Then
    ''        xIP = "190.40.69.82"
    ''        xDSN = "CnnGEAC"
    ''    ElseIf xRutaCnx = "R:Claro_6" Then   'rbRemoto.Checked Then
    ''        xIP = "190.116.184.227"
    ''        xDSN = "CnnGEAC"
    ''    Else
    ''        MsgBox("Nombre del SERVER no definido.", MsgBoxStyle.Critical, Me.Text)
    ''        Me.Close()
    ''    End If
    ''    'Attributes = "SERVER=" & IIf(rbLocal.Checked, "100.100.100.202", "190.81.24.129") & Chr(0)
    ''    Attributes = "SERVER=" & xIP & Chr(0)
    ''    Attributes = Attributes & "DESCRIPTION=New DSN" & Chr(0)
    ''    Attributes = Attributes & "DSN=" & xDSN & Chr(0)
    ''    'Attributes = Attributes & "DATABASE=TRC" & Chr(0)
    ''    'To show dialog, use Form1.Hwnd instead of vbAPINull.
    ''    intRet = SQLConfigDataSource(vbAPINull, IIf(pCreaBorra, ODBC_ADD_DSN, ODBC_REMOVE_DSN), Driver, Attributes)
    ''    If intRet <> 0 Then
    ''        lblMsg.Text = "Se ha " & IIf(pCreaBorra, "creado", "borrado") & " el DSN."
    ''    Else
    ''        lblMsg.Text = "No se ha podido " & IIf(pCreaBorra, "crear", "borrar") & " el DSN."
    ''    End If
    ''End Sub

    'Public Sub CreateUserDSN_Rpt(ByVal pCreaBorra As Boolean)
    '    Dim intRet As Integer
    '    Dim Driver As String
    '    Dim Attributes As String
    '    Dim xIP As String
    '    Dim xDSN As String

    '    Driver = "SQL Server"
    '    xDSN = "CnnGEAC"
    '    xIP = Me.Tag.ToString

    '    Attributes = "SERVER=" & xIP & Chr(0)
    '    Attributes = Attributes & "DESCRIPTION=New DSN" & Chr(0)
    '    Attributes = Attributes & "DSN=" & xDSN & Chr(0)
    '    intRet = SQLConfigDataSource(vbAPINull, IIf(pCreaBorra, ODBC_ADD_DSN, ODBC_REMOVE_DSN), Driver, Attributes)
    '    If intRet <> 0 Then
    '        lblMsg.Text = "Se ha " & IIf(pCreaBorra, "creado", "borrado") & " el DSN."
    '    Else
    '        lblMsg.Text = "No se ha podido " & IIf(pCreaBorra, "crear", "borrar") & " el DSN."
    '    End If
    'End Sub

    Public Sub CreateUserDSN(ByVal pCreaBorra As Boolean)
        Dim intRet As Integer
        Dim Driver As String
        Dim Attributes As String
        Dim xIP As String
        Dim xDSN As String
        Dim xRutaCnx As String
        'Set the driver to SQL Server because it is most common.
        'If cbDriver.SelectedIndex = 0 Then
        Driver = "SQL Server"
        'Else
        '    Driver = "SQL Native Client"
        'End If
        'Set the attributes delimited by null.
        'See driver documentation for a complete
        'list of supported attributes.
        xRutaCnx = cbxRutaCnx.Text
        xDSN = "CnnLogin"
        Select Case xRutaCnx
            Case "Local_1"          'rbLocal.Checked Then
                xIP = "100.100.100.202"
            Case "R:Movistar_2"     'rbRemotoMovistar.Checked Then
                xIP = "190.40.69.144"
            Case "R:Movistar_3"     'rbRemoto.Checked Then
                xIP = "190.40.69.79"
            Case "R:Claro_5"        'rbRemoto.Checked Then
                xIP = "190.81.24.129"
            Case "R:Claro_6"        'rbRemoto.Checked Then
                xIP = "190.116.184.227"
            Case Else
                MsgBox("Nombre del SERVER no definido.", MsgBoxStyle.Critical, Me.Text)
                Me.Close()
        End Select

        'Attributes = "SERVER=" & IIf(rbLocal.Checked, "100.100.100.202", "190.81.24.129") & Chr(0)
        Attributes = "SERVER=" & xIP & Chr(0)
        Attributes = Attributes & "DESCRIPTION=New DSN" & Chr(0)
        Attributes = Attributes & "DSN=" & xDSN & Chr(0)
        'Attributes = Attributes & "DATABASE=TRC" & Chr(0)
        'To show dialog, use Form1.Hwnd instead of vbAPINull.
        intRet = SQLConfigDataSource(vbAPINull, IIf(pCreaBorra, ODBC_ADD_DSN, ODBC_REMOVE_DSN), Driver, Attributes)
        If intRet <> 0 Then
            lblMsg.Text = "Se ha " & IIf(pCreaBorra, "creado", "borrado") & " el DSN."
        Else
            lblMsg.Text = "No se ha podido " & IIf(pCreaBorra, "crear", "borrar") & " el DSN."
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If btnAceptar.Text = "Cerrar" Then
            Me.Close()
        End If
        'If wConODBC_Rpt Then
        '    CreateUserDSN_Rpt(False)
        '    CreateUserDSN_Rpt(True)
        'Else
        CreateUserDSN(False)
        CreateUserDSN(True) 
        'End If

        btnAceptar.Text = "Cerrar"
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        With cbxRutaCnx.Items
            .Add("Local_1")
            .Add("R:Movistar_2")
            .Add("R:Movistar_3")
            '.Add("R:Movistar_4")
            .Add("R:Claro_5")
            .Add("R:Claro_6")
            '.Add("L:Milton")
            '.Add("L:Irving")
        End With
        cbxRutaCnx.SelectedIndex = 0


    End Sub

    Private Sub cbxRutaCnx_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbxRutaCnx.SelectedIndexChanged

        If Microsoft.VisualBasic.Left(cbxRutaCnx.Text, 1) = "L" Then
            picLocal.Visible = True
            picRemoto.Visible = False
        Else
            picLocal.Visible = False
            picRemoto.Visible = True
        End If
    End Sub
End Class
