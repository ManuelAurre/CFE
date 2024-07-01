Public Class Menu_Empleado

    Dim fu As New EnlaceBD
    Dim eu As New UsuarioVS
    Dim ActivarC As New UsuarioVS
    Dim tablaClientes As New DataTable
    Dim ent As New Integer
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim Salir As String
        Salir = MessageBox.Show("Deseas Salir?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Salir = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Form3.ShowDialog()

    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs)
        Form4.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ReporteDeConsumos.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CargaConsumos.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ConsultarResibo.ShowDialog()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        NuevoContrato.ShowDialog()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ReporteGeneral.ShowDialog()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ReporteDeTarifas.ShowDialog()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        CargaTarifa.ShowDialog()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        ConsultaDeReciboEmpleados.ShowDialog()
    End Sub

    Private Sub MenuAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim obj As New EnlaceBD
        Dim dt As New DataTable

        eu._users = User
        eu._passwords = Pass
        dt = fu.validarusuario(eu)
        Dim RFC As String
        RFC = dt.Rows(0)("RFC")

        Label2.Text = RFC.ToString()

        If obj.CONSULTAR_Clientes("B", 0, 0) Then
            tablaClientes = obj.tabla
            ComboBox1.ValueMember = "usuario"
            ComboBox1.DisplayMember = "NombreCompleto"
            ComboBox1.DataSource = tablaClientes
            ent = ComboBox1.Items.Count
        End If


        If ent <> 0 Then
            Button15.Enabled = True
        End If


    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Recibo.ShowDialog()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Dim act As New EnlaceBD
        Dim Activar As New DataTable
        Dim obj As New EnlaceBD

        ActivarC._users = ComboBox1.SelectedValue

        Activar = act.Desactivar("F", ActivarC)
        MsgBox("Cliente Reactivado", MsgBoxStyle.Critical, "SISTEMA")


        If obj.CONSULTAR_Clientes("B", 0, 0) Then
            tablaClientes = obj.tabla
            ComboBox1.ValueMember = "usuario"
            ComboBox1.DisplayMember = "NombreCompleto"
            ComboBox1.DataSource = tablaClientes
            ent = ComboBox1.Items.Count
        End If


        If ent = 0 Then
            Button15.Enabled = False
        End If

    End Sub
End Class