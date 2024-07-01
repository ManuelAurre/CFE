Imports System.Data
Imports System.Data.SqlClient
Public Class EnlaceBD

    Private aux As String

    Private conexion As SqlConnection
    Private adaptador As SqlDataAdapter = New SqlDataAdapter
    Private comandosql As SqlCommand = New SqlCommand

    Public tabla As DataTable = New DataTable
    Public tablita As DataTable = New DataTable

    Private Sub conectar()
        'Dim DBConnection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("SQL").ConnectionString)        
        conexion = New SqlConnection(Configuration.ConfigurationManager.ConnectionStrings("SQL").ConnectionString)
        conexion.Open()
    End Sub

    Private Sub desconectar()
        conexion.Close()
    End Sub



    Public Function validarusuario(ByVal dts As UsuarioVS) As DataTable

        conectar()
        comandosql = New SqlCommand("SP_LOGINE")
        comandosql.CommandType = CommandType.StoredProcedure
        comandosql.Connection = conexion

        comandosql.Parameters.AddWithValue("@usuario", dts._users)
        comandosql.Parameters.AddWithValue("@contraseña", dts._passwords)


        If comandosql.ExecuteNonQuery Then
            Using dt As New DataTable
                Using da As New SqlDataAdapter(comandosql)
                    da.Fill(dt)
                    Return dt
                End Using
            End Using
        Else
            Return Nothing
        End If
    End Function



    Public Function Activos(ByVal opc As String,
                            ByVal dts As UsuarioVS) As DataTable

        conectar()
        comandosql = New SqlCommand("SP_ACTIVO")
        comandosql.CommandType = CommandType.StoredProcedure
        comandosql.Connection = conexion


        comandosql.Parameters.AddWithValue("@usuario", dts._users)

        Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
        parametro1.Value = opc

        If comandosql.ExecuteNonQuery Then
            Using dt As New DataTable
                Using da As New SqlDataAdapter(comandosql)
                    da.Fill(dt)
                    Return dt
                End Using
            End Using
        Else
            Return Nothing
        End If
    End Function


    Public Function Desactivar(ByVal opc As String,
                               ByVal dts As UsuarioVS) As DataTable

        conectar()
        comandosql = New SqlCommand("SP_DESACTIVAR")
        comandosql.CommandType = CommandType.StoredProcedure
        comandosql.Connection = conexion


        Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
        parametro1.Value = opc

        comandosql.Parameters.AddWithValue("@usuario", dts._users)


        If comandosql.ExecuteNonQuery Then
            Using dt As New DataTable
                Using da As New SqlDataAdapter(comandosql)
                    da.Fill(dt)
                    Return dt
                End Using
            End Using
        Else
            Return Nothing
        End If
    End Function




    Public Function validarloginCliente(ByVal dts As UsuarioVS) As DataTable

        conectar()
        comandosql = New SqlCommand("SP_LOGINC")
        comandosql.CommandType = CommandType.StoredProcedure
        comandosql.Connection = conexion

        comandosql.Parameters.AddWithValue("@usuario", dts._users)
        comandosql.Parameters.AddWithValue("@contraseña", dts._passwords)


        If comandosql.ExecuteNonQuery Then
            Using dt As New DataTable
                Using da As New SqlDataAdapter(comandosql)
                    da.Fill(dt)
                    Return dt
                End Using
            End Using
        Else
            Return Nothing
        End If
    End Function

    Public Function validarcliente(ByVal dts As UsuarioVS) As DataTable

        conectar()
        comandosql = New SqlCommand("SP_VALIDACION_CLIENTES")
        comandosql.CommandType = CommandType.StoredProcedure
        comandosql.Connection = conexion

        comandosql.Parameters.AddWithValue("@FK_RFC", dts._users)



        If comandosql.ExecuteNonQuery Then
            Using dt As New DataTable
                Using da As New SqlDataAdapter(comandosql)
                    da.Fill(dt)
                    Return dt
                End Using
            End Using
        Else
            Return Nothing
        End If
    End Function

    Public Function ClienteConectado(ByVal dts As UsuarioVS) As DataTable

        conectar()
        comandosql = New SqlCommand("SP_CLIENTE_ACTUAL")
        comandosql.CommandType = CommandType.StoredProcedure
        comandosql.Connection = conexion

        comandosql.Parameters.AddWithValue("@usuario", dts._users)



        If comandosql.ExecuteNonQuery Then
            Using dt As New DataTable
                Using da As New SqlDataAdapter(comandosql)
                    da.Fill(dt)
                    Return dt
                End Using
            End Using
        Else
            Return Nothing
        End If
    End Function



    Public Function validarTarifa(ByVal dts As UsuarioVS) As DataTable

        conectar()
        comandosql = New SqlCommand("SP_VALIDACION_TARIFA")
        comandosql.CommandType = CommandType.StoredProcedure
        comandosql.Connection = conexion

        comandosql.Parameters.AddWithValue("@FK_NUM_MEDIDOR", dts._num_medidor)



        If comandosql.ExecuteNonQuery Then
            Using dt As New DataTable
                Using da As New SqlDataAdapter(comandosql)
                    da.Fill(dt)
                    Return dt
                End Using
            End Using
        Else
            Return Nothing
        End If
    End Function


    Public Function validarConsumos(ByVal dts As UsuarioVS) As DataTable

        conectar()
        comandosql = New SqlCommand("SP_VALIDACION_CONSUMO")
        comandosql.CommandType = CommandType.StoredProcedure
        comandosql.Connection = conexion

        comandosql.Parameters.AddWithValue("@FK_NUM_MEDIDOR", dts._num_medidor)



        If comandosql.ExecuteNonQuery Then
            Using dt As New DataTable
                Using da As New SqlDataAdapter(comandosql)
                    da.Fill(dt)
                    Return dt
                End Using
            End Using
        Else
            Return Nothing
        End If
    End Function


    Public Function validarServicio(ByVal dts As UsuarioVS) As DataTable

        conectar()
        comandosql = New SqlCommand("SP_VALIDACION_SERVICIO")
        comandosql.CommandType = CommandType.StoredProcedure
        comandosql.Connection = conexion

        comandosql.Parameters.AddWithValue("@num_medidor", dts._num_medidor)


        If comandosql.ExecuteNonQuery Then
            Using dt As New DataTable
                Using da As New SqlDataAdapter(comandosql)
                    da.Fill(dt)
                    Return dt
                End Using
            End Using
        Else
            Return Nothing
        End If
    End Function


    Public Function validarServicioTipo(ByVal dts As UsuarioVS) As DataTable

        conectar()
        comandosql = New SqlCommand("SP_VALIDACION_SERVICIO_TIPO")
        comandosql.CommandType = CommandType.StoredProcedure
        comandosql.Connection = conexion

        comandosql.Parameters.AddWithValue("@tipo_servicio", dts._tipoServicio)


        If comandosql.ExecuteNonQuery Then
            Using dt As New DataTable
                Using da As New SqlDataAdapter(comandosql)
                    da.Fill(dt)
                    Return dt
                End Using
            End Using
        Else
            Return Nothing
        End If
    End Function



    Public Function Consulta_Empleados(ByVal Opc As String, ByVal RFC As String, ByVal activo As String) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("SP_EMPLEADO_CONSULTAR", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
            parametro1.Value = Opc
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@RFC", SqlDbType.VarChar, 55)
            parametro2.Value = RFC
            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@activo", SqlDbType.Char)
            parametro3.Value = activo


            adaptador.SelectCommand = comandosql
            adaptador.Fill(tabla)

        Catch ex As SqlException
            estado = False
            MessageBox.Show(ex.Message, "SQL SERVER", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            desconectar()
        End Try
        Return estado
    End Function


    Public Function Actualiza_Empleado(
                                      ByVal Opc As String,
                                      ByVal RFC As String,
                                      ByVal CURP_empleado As String,
                                      ByVal fecha_nacimiento As Date,
                                      ByVal fecha_alta_mod As Date,
                                      ByVal usuario As String,
                                      ByVal contraseña As String,
                                      ByVal administrador As String,
                                      ByVal nombre1 As String,
                                      ByVal nombre2 As String,
                                      ByVal a_paterno As String,
                                      ByVal a_materno As String
                                      ) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("SP_EMPLEADOS", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
            parametro1.Value = Opc
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@RFC", SqlDbType.VarChar, 55)
            parametro2.Value = RFC
            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@CURP_empleado", SqlDbType.VarChar, 18)
            parametro3.Value = CURP_empleado
            Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@fecha_nacimiento", SqlDbType.Date)
            parametro4.Value = fecha_nacimiento
            Dim parametro5 As SqlParameter = comandosql.Parameters.Add("@usuario", SqlDbType.VarChar, 55)
            parametro5.Value = usuario
            Dim parametro6 As SqlParameter = comandosql.Parameters.Add("@contraseña", SqlDbType.VarChar, 55)
            parametro6.Value = contraseña
            Dim parametro12 As SqlParameter = comandosql.Parameters.Add("@administrador", SqlDbType.Char)
            parametro12.Value = administrador

            Dim parametro7 As SqlParameter = comandosql.Parameters.Add("@nombre1", SqlDbType.VarChar, 55)
            parametro7.Value = nombre1
            Dim parametro8 As SqlParameter = comandosql.Parameters.Add("@nombre2", SqlDbType.VarChar, 55)
            parametro8.Value = nombre2
            Dim parametro9 As SqlParameter = comandosql.Parameters.Add("@a_paterno", SqlDbType.VarChar, 55)
            parametro9.Value = a_paterno
            Dim parametro10 As SqlParameter = comandosql.Parameters.Add("@a_materno", SqlDbType.VarChar, 55)
            parametro10.Value = a_materno
            Dim parametro11 As SqlParameter = comandosql.Parameters.Add("@fecha_alta_mod", SqlDbType.Date)
            parametro11.Value = fecha_alta_mod

            adaptador.InsertCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As SqlException
            estado = False
            MessageBox.Show(ex.Message, "SQL SERVER", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            desconectar()
        End Try
        Return estado
    End Function

    Public Function Actualiza_Cliente(
                                      ByVal Opc As String,
                                      ByVal Email As String,
                                      ByVal CURP_empleado As String,
                                      ByVal fecha_nacimiento As Date,
                                      ByVal Genero As Char,
                                      ByVal usuario As String,
                                      ByVal contraseña As String,
                                      ByVal FK_RFC As String,
                                      ByVal nombre1 As String,
                                      ByVal nombre2 As String,
                                      ByVal a_paterno As String,
                                      ByVal a_materno As String
                                      ) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("SP_CLIENTES", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
            parametro1.Value = Opc
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@Email", SqlDbType.VarChar, 55)
            parametro2.Value = Email
            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@CURP_Cliente", SqlDbType.VarChar, 18)
            parametro3.Value = CURP_empleado
            Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@fecha_nacimiento", SqlDbType.SmallDateTime, 15)
            parametro4.Value = fecha_nacimiento
            Dim parametro5 As SqlParameter = comandosql.Parameters.Add("@genero", SqlDbType.Char, 1)
            parametro5.Value = Genero

            Dim parametro6 As SqlParameter = comandosql.Parameters.Add("@usuario", SqlDbType.VarChar, 55)
            parametro6.Value = usuario
            Dim parametro7 As SqlParameter = comandosql.Parameters.Add("@contraseña", SqlDbType.VarChar, 55)
            parametro7.Value = contraseña
            Dim parametro8 As SqlParameter = comandosql.Parameters.Add("@FK_RFC", SqlDbType.VarChar, 55)
            parametro8.Value = FK_RFC

            Dim parametro9 As SqlParameter = comandosql.Parameters.Add("@nombre1", SqlDbType.VarChar, 55)
            parametro9.Value = nombre1
            Dim parametro10 As SqlParameter = comandosql.Parameters.Add("@nombre2", SqlDbType.VarChar, 55)
            parametro10.Value = nombre2
            Dim parametro11 As SqlParameter = comandosql.Parameters.Add("@a_paterno", SqlDbType.VarChar, 55)
            parametro11.Value = a_paterno
            Dim parametro12 As SqlParameter = comandosql.Parameters.Add("@a_materno", SqlDbType.VarChar, 55)
            parametro12.Value = a_materno

            adaptador.InsertCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As SqlException
            estado = False
            MessageBox.Show(ex.Message, "SQL SERVER", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            desconectar()
        End Try
        Return estado
    End Function

    Public Function Actualiza_Servicios(
                                      ByVal Opc As String,
                                      ByVal calle As String,
                                      ByVal numero As Integer,
                                      ByVal colonia As String,
                                      ByVal cpp As Integer,
                                      ByVal municipio As String,
                                      ByVal tipo_servicio As String,
                                      ByVal FK_CURP_Cliente As String,
                                      ByVal FK_RFC As String
                                      ) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("SP_SERVICIOS", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
            parametro1.Value = Opc
            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@calle", SqlDbType.VarChar, 55)
            parametro3.Value = calle
            Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@numero", SqlDbType.Int)
            parametro4.Value = numero
            Dim parametro5 As SqlParameter = comandosql.Parameters.Add("@colonia", SqlDbType.VarChar, 55)
            parametro5.Value = colonia

            Dim parametro6 As SqlParameter = comandosql.Parameters.Add("@cpp", SqlDbType.Int)
            parametro6.Value = cpp
            Dim parametro7 As SqlParameter = comandosql.Parameters.Add("@municipio", SqlDbType.VarChar, 55)
            parametro7.Value = municipio
            Dim parametro8 As SqlParameter = comandosql.Parameters.Add("@tipo_servicio", SqlDbType.VarChar, 55)
            parametro8.Value = tipo_servicio
            Dim parametro9 As SqlParameter = comandosql.Parameters.Add("@FK_CURP_Cliente", SqlDbType.VarChar, 55)
            parametro9.Value = FK_CURP_Cliente
            Dim parametro10 As SqlParameter = comandosql.Parameters.Add("@FK_RFC", SqlDbType.VarChar, 55)
            parametro10.Value = FK_RFC

            adaptador.InsertCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As SqlException
            estado = False
            MessageBox.Show(ex.Message, "SQL SERVER", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            desconectar()
        End Try
        Return estado
    End Function

    Public Function CONSULTAR_Clientes(
                                      ByVal Opc As String,
                                      ByVal CURP_Cliente As String,
                                      ByVal activo As String) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("SP_CLIENTES_CONSULTAR", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
            parametro1.Value = Opc
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@CURP_Cliente", SqlDbType.VarChar, 18)
            parametro2.Value = CURP_Cliente
            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@activo", SqlDbType.Char)
            parametro3.Value = activo

            adaptador.SelectCommand = comandosql
            adaptador.Fill(tabla)

        Catch ex As SqlException
            estado = False
            MessageBox.Show(ex.Message, "SQL SERVER", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            desconectar()
        End Try
        Return estado
    End Function

    Public Function CONSULTAR_Servicio(
                                      ByVal Opc As String,
                                      ByVal CURP_Cliente As String
                                      ) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("SP_SERVICIO_CONSULTAR", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
            parametro1.Value = Opc
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@FK_CURP_Cliente", SqlDbType.VarChar, 18)
            parametro2.Value = CURP_Cliente


            adaptador.SelectCommand = comandosql
            adaptador.Fill(tabla)

        Catch ex As SqlException
            estado = False
            MessageBox.Show(ex.Message, "SQL SERVER", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            desconectar()
        End Try
        Return estado
    End Function

    Public Function REPORTE_Tarifas(
                                      ByVal Opc As String,
                                      ByVal periodo_factura As Date
                                      ) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("SP_TARIFA_VIEW", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
            parametro1.Value = Opc
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@periodo_factura", SqlDbType.Date)
            parametro2.Value = periodo_factura


            adaptador.SelectCommand = comandosql
            adaptador.Fill(tabla)

        Catch ex As SqlException
            estado = False
            MessageBox.Show(ex.Message, "SQL SERVER", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            desconectar()
        End Try
        Return estado
    End Function


    Public Function REPORTE_Consumos(
                                      ByVal Opc As String,
                                      ByVal periodo_consumo As Date
                                      ) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("SP_CONSUMO_VIEW", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
            parametro1.Value = Opc
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@periodo_consumo", SqlDbType.Date)
            parametro2.Value = periodo_consumo


            adaptador.SelectCommand = comandosql
            adaptador.Fill(tabla)

        Catch ex As SqlException
            estado = False
            MessageBox.Show(ex.Message, "SQL SERVER", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            desconectar()
        End Try
        Return estado
    End Function



    Public Function Consumos_Historico(
                                      ByVal Opc As String,
                                      ByVal periodo_factura As Date,
                                      ByVal FK_NUM_MEDIDOR As Integer,
                                      ByVal tipo_servicio As String
                                      ) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("SP_CONSUMO_HISTORICO_VIEW", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
            parametro1.Value = Opc
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@periodo_factura", SqlDbType.Date)
            parametro2.Value = periodo_factura
            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@FK_NUM_MEDIDOR", SqlDbType.Int)
            parametro3.Value = FK_NUM_MEDIDOR
            Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@tipo_servicio", SqlDbType.VarChar, 55)
            parametro4.Value = tipo_servicio

            adaptador.SelectCommand = comandosql
            adaptador.Fill(tabla)

        Catch ex As SqlException
            estado = False
            MessageBox.Show(ex.Message, "SQL SERVER", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            desconectar()
        End Try
        Return estado
    End Function


    Public Function Reporte_General(
                                      ByVal Opc As String,
                                      ByVal periodo_factura As Date,
                                      ByVal tipo_servicio As String
                                      ) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("SP_REPORTE_GENERAL", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
            parametro1.Value = Opc
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@periodo_factura", SqlDbType.Date)
            parametro2.Value = periodo_factura
            Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@tipo_servicio", SqlDbType.VarChar, 55)
            parametro4.Value = tipo_servicio

            adaptador.SelectCommand = comandosql
            adaptador.Fill(tabla)

        Catch ex As SqlException
            estado = False
            MessageBox.Show(ex.Message, "SQL SERVER", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            desconectar()
        End Try
        Return estado
    End Function


    Public Function Consultar_Recibo(
                                      ByVal Opc As String,
                                      ByVal periodo_factura As Date,
                                      ByVal FK_NUM_MEDIDOR As Integer
                                      ) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("SP_RECIBO_VIEW", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
            parametro1.Value = Opc
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@periodo_factura", SqlDbType.Date)
            parametro2.Value = periodo_factura
            Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@FK_NUM_MEDIDOR", SqlDbType.Int)
            parametro4.Value = FK_NUM_MEDIDOR

            adaptador.SelectCommand = comandosql
            adaptador.Fill(tabla)

        Catch ex As SqlException
            estado = False
            MessageBox.Show(ex.Message, "SQL SERVER", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            desconectar()
        End Try
        Return estado
    End Function


    Public Function CONSULTAR_Tarifas(
                                      ByVal Opc As String,
                                      ByVal tipo_servicio As String
                                      ) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("SP_TARIFA_CONSULTAR", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
            parametro1.Value = Opc
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@tipo_servicio", SqlDbType.VarChar, 55)
            parametro2.Value = tipo_servicio


            adaptador.SelectCommand = comandosql
            adaptador.Fill(tabla)

        Catch ex As SqlException
            estado = False
            MessageBox.Show(ex.Message, "SQL SERVER", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            desconectar()
        End Try
        Return estado
    End Function

    Public Function CONSULTAR_Consumos(
                                      ByVal Opc As String,
                                      ByVal CURP_Cliente As String
                                      ) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("SP_CONSUMOS_CONSULTAR", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
            parametro1.Value = Opc
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@FK_NUM_MEDIDOR", SqlDbType.VarChar, 55)
            parametro2.Value = CURP_Cliente


            adaptador.SelectCommand = comandosql
            adaptador.Fill(tabla)

        Catch ex As SqlException
            estado = False
            MessageBox.Show(ex.Message, "SQL SERVER", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            desconectar()
        End Try
        Return estado
    End Function

    Public Function Actualiza_Recibos(
                                      ByVal Opc As String,
                                      ByVal periodo_factura As Date,
                                      ByVal pendiente_pago As Byte,
                                      ByVal FK_NUM_MEDIDOR As Integer,
                                      ByVal FK_NUM_CONSUMO As Integer,
                                      ByVal FK_NUM_TARIFA As Integer
                                      ) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("SP_RECIBOS", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
            parametro1.Value = Opc

            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@periodo_factura", SqlDbType.Date)
            parametro2.Value = periodo_factura
            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@pendiente_pago", SqlDbType.Bit)
            parametro3.Value = pendiente_pago
            Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@FK_NUM_MEDIDOR", SqlDbType.Int)
            parametro4.Value = FK_NUM_MEDIDOR
            Dim parametro5 As SqlParameter = comandosql.Parameters.Add("@FK_NUM_CONSUMO", SqlDbType.Int)
            parametro5.Value = FK_NUM_CONSUMO
            Dim parametro6 As SqlParameter = comandosql.Parameters.Add("@FK_NUM_TARIFA", SqlDbType.Int)
            parametro6.Value = FK_NUM_TARIFA

            adaptador.InsertCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As SqlException
            estado = False
            MessageBox.Show(ex.Message, "SQL SERVER", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            desconectar()
        End Try
        Return estado
    End Function

    Public Function Recibo_Pagado(ByVal periodo_factura As Date,
                                      ByVal pendiente_pago As Byte,
                                      ByVal FK_NUM_MEDIDOR As Integer
                                      ) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("SP_PAGAR", conexion)
            comandosql.CommandType = CommandType.StoredProcedure


            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@periodo_factura", SqlDbType.Date)
            parametro2.Value = periodo_factura
            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@pendiente_pago", SqlDbType.Bit)
            parametro3.Value = pendiente_pago
            Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@FK_NUM_MEDIDOR", SqlDbType.Int)
            parametro4.Value = FK_NUM_MEDIDOR

            adaptador.InsertCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As SqlException
            estado = False
            MessageBox.Show(ex.Message, "SQL SERVER", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            desconectar()
        End Try
        Return estado
    End Function


    Public Function Actualiza_Cliente(
                                      ByVal Opc As String,
                                      ByVal num_consumo As Integer,
                                      ByVal Cons_Basico As Integer,
                                      ByVal Cons_Intermedio As Integer,
                                      ByVal Cons_Excedente As Integer
                                      ) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("SP_CLIENTES", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
            parametro1.Value = Opc
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@num_consumo", SqlDbType.Int)
            parametro2.Value = num_consumo
            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@Cons_Basico", SqlDbType.Int)
            parametro3.Value = Cons_Basico
            Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@Cons_Intermedio", SqlDbType.Int)
            parametro4.Value = Cons_Intermedio
            Dim parametro5 As SqlParameter = comandosql.Parameters.Add("@Cons_Excedente", SqlDbType.Int)
            parametro5.Value = Cons_Excedente

            adaptador.InsertCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As SqlException
            estado = False
            MessageBox.Show(ex.Message, "SQL SERVER", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            desconectar()
        End Try
        Return estado
    End Function

    Public Function Actualiza_Tarifas(
                                      ByVal Opc As String,
                                      ByVal Tarifa_Básico As Decimal,
                                      ByVal Tarifa_Intermedio As Decimal,
                                      ByVal Tarifa_Excedente As Decimal,
                                      ByVal FK_RFC As String,
                                      ByVal FK_NUM_MEDIDOR As Integer,
                                      ByVal periodo_factura As Date,
                                      ByVal tipo_servicio As String
                                      ) As Boolean
        Dim estado As Boolean = True
        Try

            conectar()
            comandosql = New SqlCommand("SP_TARIFAS", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
            parametro1.Value = Opc
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@Tarifa_Básico", SqlDbType.Float)
            parametro2.Value = Tarifa_Básico
            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@Tarifa_Intermedio", SqlDbType.Float)
            parametro3.Value = Tarifa_Intermedio
            Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@Tarifa_Excedente", SqlDbType.Float)
            parametro4.Value = Tarifa_Excedente
            Dim parametro5 As SqlParameter = comandosql.Parameters.Add("@FK_RFC", SqlDbType.VarChar, 55)
            parametro5.Value = FK_RFC
            Dim parametro6 As SqlParameter = comandosql.Parameters.Add("@FK_NUM_MEDIDOR", SqlDbType.Int)
            parametro6.Value = FK_NUM_MEDIDOR
            Dim parametro7 As SqlParameter = comandosql.Parameters.Add("@periodo_factura", SqlDbType.DateTime)
            parametro7.Value = periodo_factura
            Dim parametro8 As SqlParameter = comandosql.Parameters.Add("@tipo_servicio", SqlDbType.VarChar, 55)
            parametro8.Value = tipo_servicio

            adaptador.InsertCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As SqlException
            estado = False
            MessageBox.Show(ex.Message, "SQL SERVER", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            desconectar()
        End Try
        Return estado
    End Function

    Public Function Actualiza_Consumos(
                                      ByVal Opc As String,
                                      ByVal Consumo_Básico As Integer,
                                      ByVal Consumo_Intermedio As Integer,
                                      ByVal Consumo_Excedente As Integer,
                                      ByVal FK_CURP_Cliente As String,
                                      ByVal FK_RFC As String,
                                      ByVal FK_NUM_MEDIDOR As Integer,
                                      ByVal periodo_consumo As Date,
                                       ByVal FK_NUM_TARIFA As Integer
                                      ) As Boolean
        Dim estado As Boolean = True
        Try

            conectar()
            comandosql = New SqlCommand("SP_CONSUMOS", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
            parametro1.Value = Opc
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@Cons_Basico", SqlDbType.Int)
            parametro2.Value = Consumo_Básico
            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@Cons_Intermedio", SqlDbType.Int)
            parametro3.Value = Consumo_Intermedio
            Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@Cons_Excedente", SqlDbType.Int)
            parametro4.Value = Consumo_Excedente
            Dim parametro5 As SqlParameter = comandosql.Parameters.Add("@FK_CURP_Cliente", SqlDbType.VarChar, 55)
            parametro5.Value = FK_CURP_Cliente
            Dim parametro6 As SqlParameter = comandosql.Parameters.Add("@FK_RFC", SqlDbType.VarChar, 55)
            parametro6.Value = FK_RFC
            Dim parametro7 As SqlParameter = comandosql.Parameters.Add("@FK_NUM_MEDIDOR", SqlDbType.Int)
            parametro7.Value = FK_NUM_MEDIDOR
            Dim parametro8 As SqlParameter = comandosql.Parameters.Add("@periodo_consumo", SqlDbType.DateTime)
            parametro8.Value = periodo_consumo
            Dim parametro9 As SqlParameter = comandosql.Parameters.Add("@FK_NUM_TARIFA", SqlDbType.Int)
            parametro9.Value = FK_NUM_TARIFA

            adaptador.InsertCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As SqlException
            estado = False
            MessageBox.Show(ex.Message, "SQL SERVER", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            desconectar()
        End Try
        Return estado
    End Function


    '------------------------------------------------------------------------------------------------------------
    'no se que hace lo de abajo
    '---------------------------------------------------------------------------------------------------------
    Public ReadOnly Property obtenertabla() As DataTable
        Get
            Return tabla
        End Get
    End Property
    Public Function Consulta_Academia(ByVal Opc As String,
                                      ByVal Clave As String) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("sp_Academias", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Oper", SqlDbType.Char, 1)
            parametro1.Value = Opc
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@Clave", SqlDbType.VarChar, 4)
            parametro2.Value = Clave

            adaptador.SelectCommand = comandosql
            adaptador.Fill(tablita)

        Catch ex As SqlException
            estado = False
        Finally
            desconectar()
        End Try
        Return estado
    End Function
    Public Function ObtenDatosArchivo(ByVal CveOperacion As String, ByVal TipoPago As Integer, ByVal DiaPago As String) As Boolean
        Dim estado As Boolean = True
        Dim qry As String
        'qry = "dbo.CtlInt_PagoNomina_pUP"
        qry = "dbo.sp_pruebas"
        Try
            conectar()
            comandosql = New SqlCommand(qry, conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@pCveOperacion", SqlDbType.VarChar, 4)
            parametro1.Value = CveOperacion
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@pTipoPago", SqlDbType.SmallInt, 4)
            parametro2.Value = TipoPago
            If CveOperacion <> "HEDS" Then
                Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@pDiaPago", SqlDbType.VarChar, 15)
                parametro3.Value = DiaPago
            End If
            adaptador.SelectCommand = comandosql
            adaptador.Fill(tabla)

        Catch ex As SqlException
            estado = False
        Finally
            desconectar()
        End Try
        Return estado
    End Function
    Public Function ObtenDatosPago(ByVal CveOperacion As String, ByVal TipoPago As Integer, ByVal DiaPago As String) As Boolean
        Dim estado As Boolean = True

        Try
            conectar()
            comandosql = New SqlCommand("dbo.sp_Pruebas", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@pCveOperacion", SqlDbType.VarChar, 4)
            parametro1.Value = CveOperacion
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@pTipoPago", SqlDbType.SmallInt, 4)
            parametro2.Value = TipoPago
            If CveOperacion = "DETS" Then
                Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@pDiaPago", SqlDbType.VarChar, 15)
                parametro3.Value = DiaPago
            End If
            adaptador.SelectCommand = comandosql
            adaptador.Fill(tabla)

        Catch ex As SqlException
            estado = False
        Finally
            desconectar()
        End Try
        Return estado
    End Function
End Class
