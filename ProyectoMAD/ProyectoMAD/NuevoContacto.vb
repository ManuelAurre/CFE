Public Class NuevoContrato
    Dim fu As New EnlaceBD
    Dim eu As New UsuarioVS

    Private Sub NuevoContacto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim obj As New EnlaceBD
        Dim tablaClientes As New DataTable
        Dim dt As New DataTable


        If obj.CONSULTAR_Clientes("C", 0, 1) Then
            tablaClientes = obj.tabla
            ComboBox1.ValueMember = "CURP_Cliente"
            ComboBox1.DisplayMember = "nombrecompleto"
            ComboBox1.DataSource = tablaClientes

        End If


        eu._users = User
        eu._passwords = Pass
        dt = fu.validarusuario(eu)
        Dim RFC As String
        RFC = dt.Rows(0)("RFC")

        Label7.Text = RFC.ToString()




    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim calle As String
        Dim numero As Integer
        Dim colonia As String
        Dim cpp As Integer
        Dim municipio As String
        Dim fk_rfc As String
        Dim fk_CURP_cliente As String
        Dim tipo_servicio As String
        Dim objeto As New EnlaceBD
        Dim msg As String = ""



        calle = TextBox1.Text.ToString()

        colonia = TextBox3.Text.ToString()

        municipio = TextBox5.Text.ToString()

        fk_rfc = Label7.Text.ToString()
        fk_CURP_cliente = ComboBox1.SelectedValue

        If RadioButton1.Checked = True Then
            tipo_servicio = "Domestico"
        ElseIf RadioButton2.Checked = True Then
            tipo_servicio = "Industrial"
        Else
            msg = "Servicio NO agregado, seleccione un  tipo de servicio"

        End If
        If calle <> "" And TextBox2.Text <> "" And colonia <> "" And TextBox4.Text <> "" And municipio <> "" Then
            numero = TextBox2.Text
            cpp = TextBox4.Text
            If objeto.Actualiza_Servicios("I", calle, numero, colonia, cpp, municipio, tipo_servicio, fk_CURP_cliente, fk_rfc) Then
                msg = "Servicio agregado Exitosamente"
                TextBox2.Text = ""
                TextBox1.Text = ""
                TextBox3.Text = ""
                TextBox5.Text = ""
                TextBox4.Text = ""


            Else
                msg = "Servicio NO agregado"
            End If

        Else
            msg = "Llenar todo los campos"

        End If
        MessageBox.Show(msg, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Char.IsNumber(e.KeyChar) Then
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
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
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

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
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