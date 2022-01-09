Public Class Fixcher_Insert
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Submit_Btn_Click(sender As Object, e As EventArgs)
        Try
            Dim sabetha As New Sabetha
            Dim tbl As New Data.DataTable
            tbl = sabetha.FixcherCode_Check(FixcherCode_Txt.Text)


            If String.IsNullOrWhiteSpace(FixcherName_Txt.Text) Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Warning) = "نام فیکسچر الزامی می باشد ."
                Exit Sub

            ElseIf String.IsNullOrEmpty(FixcherName_Txt.Text) Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Warning) = "نام فیکسچر الزامی می باشد ."
                Exit Sub

            ElseIf String.IsNullOrWhiteSpace(FixcherCode_Txt.Text) Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Warning) = "کد فیکسچر الزامی می باشد ."
                Exit Sub

            ElseIf String.IsNullOrEmpty(FixcherCode_Txt.Text) Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Warning) = "کد فیکسچر الزامی می باشد ."
                Exit Sub

            ElseIf FixcherCode_Txt.Text.Length <> 10 Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Warning) = "کد فیکسچر بایستی ده رقمی باشد ."
                Exit Sub

            ElseIf String.IsNullOrEmpty(FixcherTedadMojaz_Txt.Text) Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Warning) = "تعداد مجاز فیکسچر الزامی می باشد ."
                Exit Sub


            ElseIf String.IsNullOrWhiteSpace(FixcherTedadMojaz_Txt.Text) Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Warning) = "تعداد مجاز فیکسچر الزامی می باشد ."
                Exit Sub

            ElseIf FixcherTedadMojaz_Txt.Text = "0" Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Warning) = "تعداد مجاز فیکسچر نبایستی صفر باشد ."
                Exit Sub

            ElseIf IsNumeric(FixcherTedadMojaz_Txt.text) = False Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Warning) = "تعداد مجاز فیکسچر بایستی بصورت عددی باشد ."
                Exit Sub

            ElseIf tbl.Rows.Count > 0 Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Warning) = "کد فیکسچر وارد شده قبلا در سیستم ثبت شده است ."
                Exit Sub

            End If



            Dim err As String = sabetha.Fixcher_Insert(FixcherName_Txt.Text, FixcherCode_Txt.Text, FixcherTedadMojaz_Txt.text)

            If err = 0 Then
                FixcherName_Txt.Text = String.Empty
                FixcherCode_Txt.Text = String.Empty
                FixcherTedadMojaz_Txt.text = 0

                Me.Message.ErrMessages(Arad.Message.MessageType.Success) = "فیکسچر مورد نظر با موفقیت ثبت گردید ."
            Else
                Me.Message.ErrMessages(Arad.Message.MessageType.Success) = "فیکسچر مورد نظر با موفقیت ثبت گردید ."
            End If



        Catch ex As Exception

        End Try
    End Sub
End Class