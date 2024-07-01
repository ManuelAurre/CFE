Public Class MenuAdmin

    Dim fu As New EnlaceBD
    Dim eu As New UsuarioVS
    Dim ActivarE As New UsuarioVS
    Dim tablaEmpleados As New DataTable
    Dim ent As New Integer

    Dim dt As New DataTable
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim Salir As String
        Salir = MessageBox.Show("Deseas Salir?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Salir = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs)
        Form3.ShowDialog()

    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Form4.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        ReporteDeConsumos.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        CargaConsumos.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        ConsultaDeReciboEmpleados.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        NuevoContrato.ShowDialog()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        ReporteGeneral.ShowDialog()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        ReporteDeTarifas.ShowDialog()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        CargaTarifa.ShowDialog()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)
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

        Label1.Text = RFC.ToString()

        If obj.Consulta_Empleados("B", 0, 0) Then
            tablaEmpleados = obj.tabla
            ComboBox1.ValueMember = "usuario"
            ComboBox1.DisplayMember = "NombreCompleto"
            ComboBox1.DataSource = tablaEmpleados
            ent = ComboBox1.Items.Count
        End If


        If ent <> 0 Then
            Button16.Enabled = True
        End If

    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Dim act As New EnlaceBD
        Dim Activar As New DataTable
        Dim obj As New EnlaceBD

        ActivarE._users = ComboBox1.SelectedValue

        Activar = act.Desactivar("D", ActivarE)
        MsgBox("Empleado Reactivado", MsgBoxStyle.Critical, "SISTEMA")


        If obj.Consulta_Empleados("B", 0, 0) Then
            tablaEmpleados = obj.tabla
            ComboBox1.ValueMember = "usuario"
            ComboBox1.DisplayMember = "NombreCompleto"
            ComboBox1.DataSource = tablaEmpleados
            ent = ComboBox1.Items.Count
        End If


        If ent = 0 Then
            Button16.Enabled = False
        End If

    End Sub
End Class