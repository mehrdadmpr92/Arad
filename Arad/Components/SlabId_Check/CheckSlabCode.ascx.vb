Public Class CheckSlabCode
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            DIV1.Visible = False
        End If
    End Sub


    Dim code_Flag_ As Boolean
    Public Property code_Flag() As Boolean
        Get
            Return code_Flag_
        End Get
        Set(ByVal value As Boolean)
            code_Flag_ = value
        End Set
    End Property
    Public Property ValidationGroup() As String
        Get
            Return RequiredFieldValidator5.ValidationGroup
        End Get
        Set(ByVal value As String)
            RequiredFieldValidator5.ValidationGroup = value
        End Set

    End Property
    Public ReadOnly Property Sname() As String
        Get
            Return Label2.Text
        End Get
    End Property
    Public Property Text() As String
        Get
            Return TextBox1.Text
        End Get
        Set(ByVal value As String)
            TextBox1.Text = value
        End Set
    End Property
    Public Property MaxLength() As String
        Get
            Return TextBox1.MaxLength
        End Get
        Set(ByVal value As String)
            TextBox1.MaxLength = value
        End Set
    End Property
    Public Property Skin_ID() As String
        Get
            Return TextBox1.SkinID
        End Get
        Set(ByVal value As String)
            TextBox1.SkinID = value
        End Set
    End Property
    Public Property Enabled() As Boolean
        Get
            Return TextBox1.Enabled
        End Get
        Set(ByVal value As Boolean)
            TextBox1.Enabled = value
        End Set
    End Property
    Public Property ReadOnly_() As Boolean
        Get
            Return TextBox1.ReadOnly
        End Get
        Set(ByVal value As Boolean)
            TextBox1.ReadOnly = value
        End Set
    End Property

    Sub check_SlabID()
        Try


            Dim tbl As New Data.DataTable
            Dim Slab As New Slabs
            tbl = Slab.SlabSelect_BySlabId(Me.TextBox1.Text)
            If (Not TextBox1.Text.Length = 10) Then
                Image1.ToolTip = "تعداد کاراکتر های شماره قطعه باید 10 رقمی باشد."
                Image1.Visible = True
                TextBox1.Focus()
                TextBox1.Style.Add("background-color", "Red")
                TextBox1.Style.Add("color", "white")

                code_Flag_ = False
            ElseIf tbl.Rows.Count > 0 Then
                'If (Not tbl.Rows(0).Item("Sarparast_Flag").ToString = "Y") And tbl.Rows(0).Item("SType_Text").ToString = 3 Then
                '    TextBox1.Focus()
                '    TextBox1.Style.Add("background-color", "Red")
                '    TextBox1.Style.Add("color", "white")
                '    Image1.ToolTip = "مجموعه تایید نشده است."
                '    Image1.Visible = True
                '    DIV1.Visible = False
                '    code_Flag_ = False
                'Else
                '    Me.Label2.Text = tbl.Rows(0).Item("SName_Farsi").ToString
                '    Label4.Text = tbl.Rows(0).Item("Sname").ToString
                '    Label6.Text = tbl.Rows(0).Item("SType").ToString

                '    TextBox1.Style.Add("background-color", "green")
                '    TextBox1.Style.Add("color", "white")
                '    Image1.ToolTip = "شماره قطعه وارد شده مجاز می باشد"
                '    Image1.Visible = True
                '    DIV1.Visible = True
                '    code_Flag_ = True
                'End If


            Else
                TextBox1.Focus()
                TextBox1.Style.Add("background-color", "Red")
                TextBox1.Style.Add("color", "white")
                Image1.ToolTip = "شما مجاز به ثبت این شماره قطعه نمی باشید"
                Image1.Visible = True
                DIV1.Visible = False
                code_Flag_ = False

            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub restore()
        TextBox1.Style.Add("background-color", "white")
        TextBox1.Style.Add("color", "dimgray")
        code_Flag_ = False
        DIV1.Visible = False
    End Sub

    Protected Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text.Length = 10 Then
            check_SlabID()
        Else
            Image1.ToolTip = "تعداد کاراکتر های شماره قطعه باید 10 رقمی باشد."
            Image1.Visible = True
            TextBox1.Focus()
            TextBox1.Style.Add("background-color", "Red")
            TextBox1.Style.Add("color", "white")
            code_Flag_ = False

            DIV1.Visible = False
        End If
    End Sub

End Class