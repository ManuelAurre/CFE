Public Class MenuCliente
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim Salir As String
        Salir = MessageBox.Show("Deseas Salir?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Salir = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ConsultaDeReciboCliente.ShowDialog()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        ConsumoHistórico.ShowDialog()
    End Sub
End Class