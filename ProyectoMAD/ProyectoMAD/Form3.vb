Public Class Form3


    Dim fu As New EnlaceBD
    Dim eu As New UsuarioVS


    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim Obj As New EnlaceBD
        'Dim TablaEmpleados As DataTable

        Dim dt As New DataTable

        eu._users = User
        eu._passwords = Pass
        dt = fu.validarusuario(eu)
        Dim RFC As String
        RFC = dt.Rows(0)("RFC")
        Label12.Text = RFC.ToString()

        Label11.Text = Today


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim PrimerNombre As String
        Dim SegundoNombre As String
        Dim ApellidoPaterno As String
        Dim ApellidoMaterno As String
        Dim CURP As String
        Dim Genero As Char
        Dim Email As String
        Dim Usuario As String
        Dim Contraseña As String
        Dim FK_RFC As String
        Dim FechaNacimiento As Date
        Dim objeto As New EnlaceBD
        Dim msg As String = ""

        FK_RFC = Label12.Text.ToString()
        Email = TextBox8.Text.ToString()
        SegundoNombre = TextBox2.Text.ToString()
        CURP = TextBox6.Text.ToString()
        Genero = TextBox5.Text.ToString()

        Usuario = TextBox11.Text.ToString()
        Contraseña = TextBox10.Text.ToString()

        FechaNacimiento = MonthCalendar1.SelectionStart

        If IsNumeric(TextBox1.Text) Then
            MessageBox.Show("Nombre ingresado incorrecto", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            PrimerNombre = TextBox1.Text.ToString()
        End If

        If IsNumeric(TextBox4.Text) Then
            MessageBox.Show("Apellido Paterno ingresado incorrecto", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            ApellidoPaterno = TextBox4.Text.ToString()
        End If

        If IsNumeric(TextBox3.Text) Then
            MessageBox.Show("Apellido Materno incorrecto", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            ApellidoMaterno = TextBox3.Text.ToString()
        End If
        If Email <> "" And CURP <> "" And Genero <> "" And Usuario <> "" And Contraseña <> "" And PrimerNombre <> "" And ApellidoPaterno <> "" And ApellidoMaterno <> "" Then

            If objeto.Actualiza_Cliente("I", Email, CURP, FechaNacimiento, Genero, Usuario, Contraseña, FK_RFC, PrimerNombre, SegundoNombre, ApellidoPaterno, ApellidoMaterno) Then
                msg = "Cliente agregado Exitosamente"
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox3.Text = ""
                TextBox6.Text = ""
                TextBox8.Text = ""
                TextBox11.Text = ""
                TextBox10.Text = ""
                MonthCalendar1.SetDate(Today)

            Else
                msg = "Empleado NO agregado"
            End If

        Else
            msg = "Llenar todo los campos"

        End If
        MessageBox.Show(msg, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Me.Close()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress


        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub
End Class