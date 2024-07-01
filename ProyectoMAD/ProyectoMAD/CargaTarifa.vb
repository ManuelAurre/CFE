Imports System.IO

Public Class CargaTarifa
    Dim fu As New EnlaceBD
    Dim eu As New UsuarioVS
    Dim clien As New UsuarioVS
    Dim serv As New UsuarioVS
    Dim tipe As New UsuarioVS
    Dim tables As DataTableCollection
    Private Sub CargaTarifa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim obj As New EnlaceBD
        Dim obj2 As New EnlaceBD

        Dim tablaClientes As New DataTable
        Dim tablaServicio As New DataTable
        Dim dt As New DataTable
        Dim ValidacionClientes As New DataTable

        Dim obj0 As New EnlaceBD


        eu._users = User
        eu._passwords = Pass
        dt = fu.validarusuario(eu)
        Dim RFC As String
        RFC = dt.Rows(0)("RFC")

        Label2.Text = RFC.ToString()

        clien._users = Label2.Text
        ValidacionClientes = obj0.validarcliente(clien)
        Dim Cliente As String
        Cliente = ValidacionClientes.Rows(0)("CURP_Cliente")


        If obj.CONSULTAR_Servicio("B", 0) Then
            tablaClientes = obj.tabla
            ComboBox1.ValueMember = "num_medidor"
            ComboBox1.DisplayMember = "Ubicacion"
            ComboBox1.DataSource = tablaClientes

        End If


        If obj2.CONSULTAR_Servicio("C", 0) Then
            tablaServicio = obj2.tabla
            DataGridView2.DataSource = tablaServicio


        End If

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click



        Dim Basico As Decimal
        Dim intermedio As Decimal
        Dim Excedente As Decimal
        Dim FK_RFC As String
        Dim FK_NUM_MEDIDOR As Integer
        Dim PeriodoFactura As Date

        Dim objeto As New EnlaceBD
        Dim msg As String = ""
        Dim obj1 As New EnlaceBD
        Dim ValidacionServicio As New DataTable


        PeriodoFactura = MonthCalendar1.SelectionStart
        FK_RFC = Label2.Text.ToString()
        FK_NUM_MEDIDOR = ComboBox1.SelectedValue


        serv._num_medidor = FK_NUM_MEDIDOR
        serv._users = Label2.Text.ToString()
        ValidacionServicio = obj1.validarServicio(serv)
        Dim Vservicio As String
        Vservicio = ValidacionServicio.Rows(0)("tipo_servicio")

        If TextBox1.Text <> "" And txtinter.Text <> "" And txtexcedent.Text <> "" Then
            Basico = TextBox1.Text
            intermedio = txtinter.Text
            Excedente = txtexcedent.Text
            If objeto.Actualiza_Tarifas("I", Basico, intermedio, Excedente, FK_RFC, FK_NUM_MEDIDOR, PeriodoFactura, Vservicio) Then
                msg = "Tarifa agregado Exitosamente"
                txtinter.Text = ""
                TextBox1.Text = ""
                txtexcedent.Text = ""
                MonthCalendar1.SetDate(Today)



            Else
                msg = "Tarifa NO agregado"
            End If
        Else
            msg = "Llenar todo los campos"
        End If
        MessageBox.Show(msg, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click


        If OpenFileDialog1.ShowDialog Then

            DataGridView1.Columns.Clear() 'LIMPIA DE RESULTADOS ANTERIORES

            'CABECERA
            If OpenFileDialog1.FileName = "OpenFileDialog1" Then
                MessageBox.Show("No agregaste la direccion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else

                Dim CABECERA As String = IO.File.ReadLines(OpenFileDialog1.FileName)(0) 'PRIMERA LINEA DEL ARCHIVO COMO CABECERA
                Dim COLUMNAS As String() = CABECERA.Split(",")
                DataGridView1.ColumnCount = COLUMNAS.Count
                For I = 0 To COLUMNAS.Count - 1
                    DataGridView1.Columns(I).Name = COLUMNAS(I)
                Next

                'RESTO DE FILAS
                For I = 1 To IO.File.ReadLines(OpenFileDialog1.FileName).Count - 1
                    Dim FILA As String() = IO.File.ReadLines(OpenFileDialog1.FileName)(I).Split(",")
                    DataGridView1.Rows.Add(FILA)
                Next

            End If
        End If

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click

        Dim obj As New EnlaceBD
        Dim FK_RFC As String
        Dim obj1 As New EnlaceBD
        Dim ValidacionTipoServicio As New DataTable


        FK_RFC = Label2.Text.ToString()
        If DataGridView1.Rows.Count = 0 Then
            Return
        End If






        For Each row2 As DataGridViewRow In DataGridView2.Rows

            serv._num_medidor = CStr(row2.Cells("num_medidor").Value)
            serv._users = Label2.Text.ToString()
            ValidacionTipoServicio = obj1.validarServicio(serv)
            Dim Vservicio As String
            Vservicio = ValidacionTipoServicio.Rows(0)("tipo_servicio")


            For Each row As DataGridViewRow In DataGridView1.Rows
                Dim control As String
                Dim cont As String
                Dim fecha As Date
                Dim Año As String
                Dim Mes As String
                Dim FechaString As String

                '"05/05/2005"
                'Convert.ToDateTime(CStr(row.Cells("Ano").Value))

                Año = CStr(row.Cells("Ano").Value)
                Mes = CStr(row.Cells("Mes").Value)

                FechaString = "01/" & Mes & "/" & Año
                fecha = Convert.ToDateTime(FechaString)

                control = CStr(row.Cells("Servicio").Value)
                cont = CStr(row.Cells("Servicio").Value)


                If Vservicio = control Then
                    obj.Actualiza_Tarifas("I", CStr(row.Cells("Basico").Value),
                                           CStr(row.Cells("Intermedio").Value),
                                           CStr(row.Cells("Excedente").Value),
                                           FK_RFC,
                                           serv._num_medidor,
                                           fecha,
                                           CStr(row.Cells("Servicio").Value))
                End If

            Next

        Next
        DataGridView1.Columns.Clear()
        MessageBox.Show("Listo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        ''for each de arriba cambiarlo a que sea un datagridview donde estare poniendo los medidores, modo desactivado para no verlo y ahora si correr las listas simultaneamente




    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not (Char.IsControl(e.KeyChar) OrElse Char.IsDigit(e.KeyChar)) _
            AndAlso (Not e.KeyChar = "." Or TextBox1.Text.Contains(".")) Then
            e.Handled = True
        End If

    End Sub

    Private Sub txtexcedent_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtexcedent.KeyPress
        If Not (Char.IsControl(e.KeyChar) OrElse Char.IsDigit(e.KeyChar)) _
          AndAlso (Not e.KeyChar = "." Or txtexcedent.Text.Contains(".")) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtinter_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtinter.KeyPress
        If Not (Char.IsControl(e.KeyChar) OrElse Char.IsDigit(e.KeyChar)) _
          AndAlso (Not e.KeyChar = "." Or txtexcedent.Text.Contains(".")) Then
            e.Handled = True
        End If
    End Sub
End Class