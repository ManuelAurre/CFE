
Public Class Form1

    Dim fu As New EnlaceBD
    Dim ct As New EnlaceBD
    Dim eu As New UsuarioVS
    Dim cu As New UsuarioVS
    Dim auxusuario As String
    Dim act As New EnlaceBD
    Dim Uact As New UsuarioVS
    Dim intento As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        auxusuario = 1
        intento = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim usuario As String
        Dim Contraseña As String
        Dim datatableActivos As New DataTable
        Dim activo As String

        usuario = TextBox1.Text.ToString()
        Contraseña = TextBox2.Text.ToString()



        Try

            If usuario <> "" And Contraseña <> "" Then
                Dim dt As New DataTable
                Dim dtC As New DataTable
                Dim aux As New DataTable

                eu._users = usuario
                eu._passwords = Contraseña
                dt = fu.validarusuario(eu)

                cu._users = usuario
                cu._passwords = Contraseña
                dtC = ct.validarloginCliente(cu)

                If dt.Rows.Count > 0 Then

                    Dim nivel As String
                    nivel = dt.Rows(0)("administrador")
                    Uact._users = usuario
                    datatableActivos = act.Activos("E", Uact)
                    activo = datatableActivos.Rows(0)("activo")
                    If nivel = 0 And activo = 1 Then

                        GlobalVar.User = usuario
                        GlobalVar.Pass = Contraseña

                        Menu_Empleado.ShowDialog()

                    ElseIf nivel = 1 And activo = 1 Then

                        GlobalVar.User = usuario
                        GlobalVar.Pass = Contraseña
                        MenuAdmin.ShowDialog()

                    Else
                        MsgBox("Usuario Bloqueado", MsgBoxStyle.Critical, "SISTEMA")

                    End If
                ElseIf dtC.Rows.Count > 0 Then
                    Uact._users = usuario
                    datatableActivos = act.Activos("C", Uact)
                    activo = datatableActivos.Rows(0)("activo")
                    If activo = 1 Then
                        GlobalVar.User = usuario
                        GlobalVar.Pass = Contraseña
                        MenuCliente.ShowDialog()
                    Else
                        MsgBox("Usuario Bloqueado", MsgBoxStyle.Critical, "SISTEMA")

                    End If

                Else
                    Dim controlE As Boolean
                    Dim controlC As Boolean
                    Uact._users = usuario

                    aux = act.Activos("E", Uact)
                    If aux.Rows.Count > 0 Then

                        ' Dim auxexisteE As String
                        'auxexisteE = aux.Rows(0)("usuario")

                        controlE = True
                    End If
                    aux = act.Activos("C", Uact)
                    If aux.Rows.Count > 0 Then
                        ' Dim auxexisteC As String
                        ' auxexisteC = aux.Rows(0)("usuario")

                        controlC = True
                    End If

                    If auxusuario = Label1.Text Then
                            Label1.Text = usuario.ToString()
                            intento = intento + 1
                            MsgBox("estimado usuario te quedan " & (3 - intento) & " intentos")
                            If intento = 3 Then

                            If controlE Then
                                datatableActivos = act.Desactivar("E", eu)
                                MsgBox("Empleado Bloqueado", MsgBoxStyle.Critical, "SISTEMA")

                            ElseIf controlC Then

                                datatableActivos = act.Desactivar("C", cu)
                                MsgBox("Cliente Bloqueado", MsgBoxStyle.Critical, "SISTEMA")
                            Else
                                MsgBox("No existe el Usuario", MsgBoxStyle.Critical, "SISTEMA")
                                End If

                                intento = 0


                            End If
                        ElseIf usuario = Label1.Text Then

                            intento = intento + 1
                            MsgBox("estimado usuario te quedan " & (3 - intento) & " intentos")
                            If intento = 3 Then

                            If controlE Then
                                datatableActivos = act.Desactivar("E", eu)
                                MsgBox("Empleado Bloqueado", MsgBoxStyle.Critical, "SISTEMA")

                            ElseIf controlC Then

                                datatableActivos = act.Desactivar("C", cu)
                                MsgBox("Cliente Bloqueado", MsgBoxStyle.Critical, "SISTEMA")
                            Else
                                MsgBox("No existe el Usuario", MsgBoxStyle.Critical, "SISTEMA")
                            End If

                            intento = 0


                        End If
                        Else
                            intento = 0
                            intento = intento + 1
                            MsgBox("estimado usuario te quedan " & (3 - intento) & " intentos")
                            If intento = 3 Then

                            If controlE Then
                                datatableActivos = act.Desactivar("E", eu)
                                MsgBox("Empleado Bloqueado", MsgBoxStyle.Critical, "SISTEMA")

                            ElseIf controlC Then

                                datatableActivos = act.Desactivar("C", cu)
                                MsgBox("Cliente Bloqueado", MsgBoxStyle.Critical, "SISTEMA")
                            Else
                                MsgBox("No existe el Usuario", MsgBoxStyle.Critical, "SISTEMA")
                            End If

                            intento = 0


                        End If
                            Label1.Text = usuario.ToString()
                        End If

                    End If
                End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SQL", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub


End Class
