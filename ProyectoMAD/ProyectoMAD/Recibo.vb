Public Class Recibo
    Dim fu As New EnlaceBD
    Dim eu As New UsuarioVS
    Dim taf As New UsuarioVS
    Private Sub Recibo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim obj As New EnlaceBD
        Dim tablaClientes As New DataTable
        Dim dt As New DataTable
        Dim obj2 As New EnlaceBD
        Dim tablaServicio As New DataTable
        Dim obj3 As New EnlaceBD
        Dim tablaConsumos As New DataTable




        If obj2.CONSULTAR_Tarifas("A", 0) Then
            tablaServicio = obj2.tabla
            DataGridView1.DataSource = tablaServicio


        End If

        If obj3.CONSULTAR_Consumos("A", 0) Then
            tablaConsumos = obj3.tabla
            DataGridView2.DataSource = tablaConsumos


        End If


    End Sub


    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim obj As New EnlaceBD
        Dim FK_RFC As String
        Dim obj2 As New EnlaceBD
        Dim ValidacionTipoServicio As New DataTable
        ' Dim FK_NUM_MEDIDOR As Integer
        Dim kW As New Integer

        Dim ValidacionClientes As New DataTable
        Dim obj0 As New EnlaceBD
        Dim Validaciontarifa As New DataTable



        FK_RFC = Label2.Text.ToString()
        If DataGridView1.Rows.Count = 0 Then
            Return
        End If

        Dim fechosoStrin As String
        Dim fechoso
        fechosoStrin = MonthCalendar1.SelectionStart.ToString()

        fechosoStrin = fechosoStrin.Substring(3, 8)
        fechosoStrin = "01/" & fechosoStrin

        fechoso = Convert.ToDateTime(fechosoStrin)


        If RadioButton1.Checked = True Then

            For Each row2 As DataGridViewRow In DataGridView2.Rows



                Dim VMedidor As Integer
                VMedidor = CStr(row2.Cells("FK_NUM_MEDIDOR").Value)


                Dim Perido_factura As String
                Perido_factura = CStr(row2.Cells("periodo_consumo").Value)

                Dim Perido_facturaCast As Date
                Perido_facturaCast = Convert.ToDateTime(Perido_factura)


                Dim numconsumo As Integer
                numconsumo = CStr(row2.Cells("num_consumo").Value)

                For Each row As DataGridViewRow In DataGridView1.Rows
                    Dim control As Integer

                    Dim fecha As String
                    fecha = CStr(row.Cells("periodo_factura").Value)


                    Dim fechascast As Date
                    fechascast = Convert.ToDateTime(fecha)

                    control = CStr(row.Cells("FK_NUM_MEDIDOR").Value)

                    Dim tarifa As Integer
                    tarifa = CStr(row.Cells("num_tarifa").Value)

                    Dim tiposer As String
                    tiposer = CStr(row.Cells("tipo_servicio").Value)



                    '''''''cambiar el tipo de srivicio en el if por medidor
                    If VMedidor = control And fechascast = Perido_facturaCast And tiposer = "Domestico" And fechoso = fechascast Then
                        obj.Actualiza_Recibos("I",
                                          fechascast,
                                          1,
                                          VMedidor,
                                          numconsumo,
                                          tarifa)
                    End If

                Next

            Next
            MessageBox.Show("Listo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()


        ElseIf RadioButton2.Checked = True Then


            For Each row2 As DataGridViewRow In DataGridView2.Rows



                Dim VMedidor As Integer
                VMedidor = CStr(row2.Cells("FK_NUM_MEDIDOR").Value)


                Dim Perido_factura As String
                Perido_factura = CStr(row2.Cells("periodo_consumo").Value)

                Dim Perido_facturaCast As Date
                Perido_facturaCast = Convert.ToDateTime(Perido_factura)


                Dim numconsumo As Integer
                numconsumo = CStr(row2.Cells("num_consumo").Value)

                For Each row As DataGridViewRow In DataGridView1.Rows
                    Dim control As Integer

                    Dim fecha As String
                    fecha = CStr(row.Cells("periodo_factura").Value)


                    Dim fechascast As Date
                    fechascast = Convert.ToDateTime(fecha)

                    control = CStr(row.Cells("FK_NUM_MEDIDOR").Value)

                    Dim tarifa As Integer
                    tarifa = CStr(row.Cells("num_tarifa").Value)

                    Dim tiposer As String
                    tiposer = CStr(row.Cells("tipo_servicio").Value)



                    '''''''cambiar el tipo de srivicio en el if por medidor
                    If VMedidor = control And fechascast = Perido_facturaCast And tiposer = "Industrial" And fechoso = fechascast Then
                        obj.Actualiza_Recibos("I",
                                          fechascast,
                                          1,
                                          VMedidor,
                                          numconsumo,
                                          tarifa)
                    End If

                Next

            Next
            MessageBox.Show("Listo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        ElseIf RadioButton3.Checked = True Then

            For Each row2 As DataGridViewRow In DataGridView2.Rows



                Dim VMedidor As Integer
                VMedidor = CStr(row2.Cells("FK_NUM_MEDIDOR").Value)


                Dim Perido_factura As String
                Perido_factura = CStr(row2.Cells("periodo_consumo").Value)

                Dim Perido_facturaCast As Date
                Perido_facturaCast = Convert.ToDateTime(Perido_factura)


                Dim numconsumo As Integer
                numconsumo = CStr(row2.Cells("num_consumo").Value)

                For Each row As DataGridViewRow In DataGridView1.Rows
                    Dim control As Integer

                    Dim fecha As String
                    fecha = CStr(row.Cells("periodo_factura").Value)


                    Dim fechascast As Date
                    fechascast = Convert.ToDateTime(fecha)

                    control = CStr(row.Cells("FK_NUM_MEDIDOR").Value)

                    Dim tarifa As Integer
                    tarifa = CStr(row.Cells("num_tarifa").Value)

                    Dim tiposer As String
                    tiposer = CStr(row.Cells("tipo_servicio").Value)



                    '''''''cambiar el tipo de srivicio en el if por medidor
                    If VMedidor = control And fechascast = Perido_facturaCast And fechoso = fechascast Then
                        obj.Actualiza_Recibos("I",
                                          fechascast,
                                          1,
                                          VMedidor,
                                          numconsumo,
                                          tarifa)
                    End If

                Next

            Next
            MessageBox.Show("Listo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else


        End If







    End Sub
End Class