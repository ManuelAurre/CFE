Public Class UsuarioVS

    Private users As String
    Private passwords As String
    Private nivel As String
    Private RFC As String
    Private num_medidor As Integer
    Private tipoServicio As String
    Dim Basico As New Integer
    Dim Intermedio As New Integer
    Dim Exedente As New Integer

    Public Property _Basico
        Get
            Return Basico
        End Get
        Set(value)
            Basico = value
        End Set
    End Property

    Public Property _Intermedio
        Get
            Return Intermedio
        End Get
        Set(value)
            Intermedio = value
        End Set
    End Property

    Public Property _Exedente
        Get
            Return Exedente
        End Get
        Set(value)
            Exedente = value
        End Set
    End Property

    Public Property _users
        Get
            Return users
        End Get
        Set(value)
            users = value
        End Set
    End Property

    Public Property _tipoServicio
        Get
            Return tipoServicio
        End Get
        Set(value)
            tipoServicio = value
        End Set
    End Property
    Public Property _num_medidor
        Get
            Return num_medidor
        End Get
        Set(value)
            num_medidor = value
        End Set
    End Property
    Public Property _passwords
        Get
            Return passwords
        End Get
        Set(value)
            passwords = value
        End Set
    End Property
    Public Property _nivel
        Get
            Return nivel
        End Get
        Set(value)
            nivel = value
        End Set
    End Property

    Public Property _RFC
        Get
            Return RFC
        End Get
        Set(value)
            RFC = value
        End Set
    End Property
    Public Sub New()

    End Sub




End Class
