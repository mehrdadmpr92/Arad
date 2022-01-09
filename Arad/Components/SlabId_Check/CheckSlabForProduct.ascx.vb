Public Class CheckSlabForProduct
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            DIV1.Visible = False
        End If
    End Sub


    Public Property Flag() As Boolean
        Get
            Return Me.ViewState("Flag")
        End Get
        Set(ByVal value As Boolean)
            Me.ViewState("Flag") = value
        End Set
    End Property

    Public Property Alert() As String
        Get
            Return Alert_Label.Text
        End Get
        Set(ByVal value As String)
            Alert_Label.Text = value
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

    Public Property Version() As Boolean
        Get
            Return Me.ViewState("Version")
        End Get
        Set(value As Boolean)

        End Set
    End Property

    Sub restore()
        TextBox1.Style.Add("background-color", "white")
        TextBox1.Style.Add("color", "dimgray")
        TextBox1.Text = String.Empty
        Flag = False
        DIV1.Visible = False
        Alert_Label.Text = ""
    End Sub

    Protected Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        check_SlabID()
    End Sub

    Sub check_SlabID()
        Try
            Alert_Label.Text = ""
            DIV1.Visible = False
            If (Not TextBox1.Text.Length = 10) Then

                Alert_Label.Text = "تعداد کاراکتر های شماره قطعه باید 10 رقمی باشد."
                RejectPolicies()
                Exit Sub
            End If

            Dim Table As New Data.DataTable
            Dim Products As New Products
            Table = Products.SlabSelectForProduct(TextBox1.Text)
            If Table.Rows.Count <= 0 Then

                Alert_Label.Text = "کد قطعه وارد شده جهت ثبت محصول نادرست می باشد."
                RejectPolicies()
                Exit Sub
            End If


            If Table.Rows(0).Item("slabId").ToString.Length > 0 Then

                Alert_Label.Text = "کد قطعه وارد شده قبلا به عنوان محصول ثبت گردیده است . "
                RejectPolicies()

            ElseIf Not Table.Rows(0).Item("slabType").ToString = 3 Then

                Alert_Label.Text = "کد قطعه وارد شده ، اسمبلی نمی باشد . "
                RejectPolicies()

            ElseIf Table.Rows(0).Item("opcOperationsCount").ToString <= 0 Then

                Alert_Label.Text = "برای قطعه وارد شده مراحل ساخت ثبت نگردیده است . "
                RejectPolicies()

            ElseIf Not Table.Rows(0).Item("sarparastSlabFlag").ToString = "Y" Then

                Alert_Label.Text = "کد قطعه وارد شده توسط سرپرست تایید نگردیده است ."
                RejectPolicies()

            ElseIf Not Table.Rows(0).Item("sarparastOPCFlag").ToString = "Y" Then

                Alert_Label.Text = "مراحل ساخت کد قطعه وارد شده توسط سرپرست تایید نگردیده است ."
                RejectPolicies()

            Else
                TextBox1.Focus()
                TextBox1.Style.Add("background-color", "Green")
                TextBox1.Style.Add("color", "white")
                Alert_Label.Style.Add("color", "Green")
                Flag = True
            End If

            Me.ViewState("Subs") = Table.Rows(0).Item("Sub_Slabs").ToString
            Dim notification As String = ""
            Dim notification_Submit As String = ""
            notification = Alert_Label.Text + "<br/>"
            Me.ViewState("Mode") = "True"


            Dim Tbl As New Data.DataTable
            Tbl = Products.SubSlabsStatusSelectForProduct(Me.ViewState("Sub_Slabs"))
            Dim i As Integer
            For i = 0 To Tbl.Rows.Count - 1
                notification += Tbl.Rows(i).Item("SubSlabs_Status").ToString
                notification_Submit += Tbl.Rows(i).Item("Slab_Saraparast_Status").ToString
                If Tbl.Rows(i).Item("SubSlabs_Flag").ToString = "False" Then
                    Me.ViewState("Mode") = "False"
                End If

                If Tbl.Rows(i).Item("Slab_Saraparast_Flag").ToString = "False" Then
                    Me.ViewState("Mode") = "False"
                End If
            Next

            If Me.ViewState("Mode") = "False" Then
                TextBox1.Focus()
                TextBox1.Style.Add("background-color", "Red")
                TextBox1.Style.Add("color", "white")
                Alert_Label.Text = notification_Submit + notification
                Alert_Label.Style.Add("color", "Red")

                DIV1.Visible = False
                Flag = False

            ElseIf Me.ViewState("Mode") = "True" Then
                DIV1.Visible = True
                Me.Label2.Text = Table.Rows(0).Item("SlabName").ToString
                Me.Label4.Text = Table.Rows(0).Item("SlabNameEng").ToString
                Me.Label6.Text = Table.Rows(0).Item("SlabType_Status").ToString
                Me.Label8.Text = Table.Rows(0).Item("CodeMohandesi").ToString
                Me.ViewState("Version") = Table.Rows(0).Item("version").ToString


                TextBox1.Style.Add("background-color", "Green")
                TextBox1.Style.Add("color", "white")

                Alert_Label.Text = "شماره قطعه جهت ثبت محصول مجاز می باشد ."
                Alert_Label.Style.Add("color", "Green")


                Flag = True

            End If

            Table.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RejectPolicies()

        TextBox1.Focus()
        TextBox1.Style.Add("background-color", "Red")
        TextBox1.Style.Add("color", "white")
        Alert_Label.Style.Add("color", "Red")
        Flag = False
    End Sub
End Class