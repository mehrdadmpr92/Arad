Public Class IntValidation
    Inherits System.Web.UI.UserControl


    Public Property text() As String
        Get
            Return Me.TextBox1.Text
        End Get
        Set(value As String)
            TextBox1.Text = value
        End Set
    End Property

    Public Property SetMaxLength() As String
        Get
            Return Me.TextBox1.MaxLength
        End Get
        Set(value As String)
            TextBox1.MaxLength = value
        End Set
    End Property

    Public Property RequiredField_Validate() As String
        Get
            Return RequiredFieldValidator.Visible
        End Get
        Set(value As String)
            RequiredFieldValidator.Visible = value
        End Set
    End Property


    Public Property ValidationGroup() As String
        Get
            Return RequiredFieldValidator.ValidationGroup
        End Get
        Set(value As String)
            RequiredFieldValidator.ValidationGroup = value
        End Set
    End Property


    Public Property ValidationText() As String
        Get
            Return RequiredFieldValidator.Text
        End Get
        Set(value As String)
            RequiredFieldValidator.Text = value
        End Set
    End Property




End Class