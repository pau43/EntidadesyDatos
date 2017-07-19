Imports ModuloCentral

Module modCredencialSistema

    Public Function udfRevalidarAcceso(ByVal pCodModulo As String, ByVal pCodNivel As String) As Boolean
        Dim oFrmReLogin As New FrmReLogin(pCodModulo, pCodNivel)
        oFrmReLogin.ShowDialog()
        Return oFrmReLogin.ReValidado
    End Function

End Module
