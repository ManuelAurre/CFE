Public Class CargaConsumos
    Dim fu As New EnlaceBD
    Dim eu As New UsuarioVS
    Dim clien As New UsuarioVS
    Dim serv As New UsuarioVS

    Dim ConsumoBIE As New UsuarioVS


    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Me.Close()

    End Sub

    Private Sub CargaConsumos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim obj As New EnlaceBD
        Dim tablaClientes As New DataTable
        Dim dt As New DataTable
        Dim obj2 As New EnlaceBD
        Dim tablaServicio As New DataTable
        Dim ValidacionClientes As New DataTable
        Dim obj0 As New EnlaceBD


        ConsumoBIE._Basico = 120
        ConsumoBIE._Intermedio = 175

        eu._users = User
        eu._passwords = Pass
        dt = fu.validarusuario(eu)
        Dim RFC As String
        RFC = dt.Rows(0)("RFC")

        Label2.Text = RFC.ToString()





        If obj.CONSULTAR_Servicio("B", 0) Then
            tablaClientes = obj.tabla
            ComboBox1.ValueMember = "num_medidor"
            ComboBox1.DisplayMember = "Ubicacion"
            ComboBox1.DataSource = tablaClientes



        End If


        If obj2.CONSULTAR_Tarifas("A", 0) Then
            tablaServicio = obj2.tabla
            DataGridView2.DataSource = tablaServicio


        End If



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim Consumo_Básico As Decimal
        Dim Consumo_Intermedio As Decimal
        Dim Consumo_Excedente As Decimal
        Dim FK_CURP_Cliente As String
        Dim FK_RFC As String
        Dim FK_NUM_MEDIDOR As Integer
        Dim FK_NUM_TARIFA As Integer
        Dim PeriodoConsumo As Date

        Dim objeto As New EnlaceBD
        Dim msg As String = ""
        Dim ValidacionClientes As New DataTable
        Dim Validaciontarifa As New DataTable
        Dim obj0 As New EnlaceBD
        Dim obj1 As New EnlaceBD
        Dim kW As New Integer




        FK_RFC = Label2.Text.ToString()


        FK_NUM_MEDIDOR = ComboBox1.SelectedValue

        clien._num_medidor = ComboBox1.SelectedValue
        ValidacionClientes = obj0.validarServicio(clien)
        Dim Cliente As String
        Cliente = ValidacionClientes.Rows(0)("FK_CURP_Cliente")

        Label3.Text = Cliente.ToString()

        FK_CURP_Cliente = Label3.Text.ToString()


        serv._num_medidor = FK_NUM_MEDIDOR
        Validaciontarifa = obj1.validarTarifa(serv)
        If Validaciontarifa.ToString() <> "" Then
            Dim tarifa As Integer
            tarifa = Validaciontarifa.Rows(0)("num_tarifa")
            Label7.Text = tarifa
            FK_NUM_TARIFA = Label7.Text
        Else
            Me.Close()

        End If


        PeriodoConsumo = MonthCalendar1.SelectionStart

        If FK_NUM_TARIFA <> 0 And TextBox1.Text <> "" Then



            kW = TextBox1.Text

            If kW <= ConsumoBIE._Basico Then
                Consumo_Básico = kW
                Consumo_Intermedio = 0
                Consumo_Excedente = 0
            Else
                Consumo_Básico = ConsumoBIE._Basico
                kW = kW - ConsumoBIE._Basico
                If kW <= ConsumoBIE._Intermedio Then
                    Consumo_Intermedio = kW
                    Consumo_Excedente = 0
                Else
                    Consumo_Intermedio = ConsumoBIE._Intermedio
                    kW = kW - ConsumoBIE._Intermedio
                    Consumo_Excedente = kW
                End If

            End If

            If objeto.Actualiza_Consumos("I", Consumo_Básico, Consumo_Intermedio, Consumo_Excedente, FK_CURP_Cliente, FK_RFC, FK_NUM_MEDIDOR, PeriodoConsumo, FK_NUM_TARIFA) Then
                msg = "Consumos agregado Exitosamente"

                TextBox1.Text = ""

            Else
                msg = "Consumos NO agregado"
            End If
        Else

            msg = "Faltan datos o NO hay tarifas Cargadas"
        End If
        MessageBox.Show(msg, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
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

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click


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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim obj As New EnlaceBD
        Dim FK_RFC As String
        Dim obj2 As New EnlaceBD
        Dim ValidacionTipoServicio As New DataTable
        ' Dim FK_NUM_MEDIDOR As Integer
        Dim kW As New Integer
        Dim Consumo_Básico As Decimal
        Dim Consumo_Intermedio As Decimal
        Dim Consumo_Excedente As Decimal
        Dim ValidacionClientes As New DataTable
        Dim obj0 As New EnlaceBD
        Dim Validaciontarifa As New DataTable



        FK_RFC = Label2.Text.ToString()
        If DataGridView1.Rows.Count = 0 Then
            Return
        End If








        For Each row2 As DataGridViewRow In DataGridView2.Rows



            Dim tarifa As Integer
            tarifa = CStr(row2.Cells("num_tarifa").Value)

            Dim VMedidor As String
            VMedidor = CStr(row2.Cells("FK_NUM_MEDIDOR").Value)
            'serv._num_medidor = VMedidor
            'Validaciontarifa = obj2.validarTarifa(serv)
            'Dim tarifa As Integer
            'tarifa = Validaciontarifa.Rows(0)("num_tarifa")

            Dim Perido_factura As Date
            Perido_factura = CStr(row2.Cells("periodo_factura").Value)


            serv._num_medidor = VMedidor
            Validaciontarifa = obj2.validarServicio(serv)
            Dim Cliente As String
            Cliente = Validaciontarifa.Rows(0)("FK_CURP_Cliente")



            For Each row As DataGridViewRow In DataGridView1.Rows
                Dim control As String

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

                control = CStr(row.Cells("Medidor").Value)

                kW = CStr(row.Cells("Consumo (kW)").Value)

                If kW <= ConsumoBIE._Basico Then
                    Consumo_Básico = kW
                    Consumo_Intermedio = 0
                    Consumo_Excedente = 0
                Else
                    Consumo_Básico = ConsumoBIE._Basico
                    kW = kW - ConsumoBIE._Basico
                    If kW <= ConsumoBIE._Intermedio Then
                        Consumo_Intermedio = kW
                        Consumo_Excedente = 0
                    Else
                        Consumo_Intermedio = ConsumoBIE._Intermedio
                        kW = kW - ConsumoBIE._Intermedio
                        Consumo_Excedente = kW
                    End If

                End If


                '''''''cambiar el tipo de srivicio en el if por medidor
                If VMedidor = control And fecha = Perido_factura Then
                    obj.Actualiza_Consumos("I", Consumo_Básico,
                                                  Consumo_Intermedio,
                                                  Consumo_Excedente,
                                                  Cliente,
                                                  FK_RFC,
                                                  VMedidor,
                                                  fecha,
                                                  tarifa)
                End If

            Next

        Next
        DataGridView1.Columns.Clear()
        MessageBox.Show("Listo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        ''for each de arriba cambiarlo a que sea un datagridview donde estare poniendo los medidores, modo desactivado para no verlo y ahora si correr las listas simultaneamente


    End Sub
End Class