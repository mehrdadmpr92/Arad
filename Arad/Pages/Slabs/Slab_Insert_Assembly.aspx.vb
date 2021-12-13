

Public Class Slab_Insert_Assembly
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Page.Title = "ثبت قطعه اسمبلی"
        If Page.IsPostBack = False Then
            Me.MultiView1.SetActiveView(AssemblySubmit1)


            Me.ViewState("tableA") = createTableSlabSubs()
            Me.ViewState("tableA").clone()
        End If

    End Sub

    Private Function createTableSlabSubs() As Object
        Try
            Dim tableA As New Data.DataTable
            Dim row As New Data.DataColumn("ردیف", System.Type.GetType("System.Decimal"))
            tableA.Columns.Add(row)
            Dim tedad As New Data.DataColumn("تعداد")
            tableA.Columns.Add(tedad)
            Dim slab_Num As New Data.DataColumn("شماره قطعه")
            tableA.Columns.Add(slab_Num)

            Return tableA

        Catch ex As Exception

        End Try
    End Function

    Protected Sub Submit_Btn_Click(sender As Object, e As EventArgs)
        Try
            Dim slab As New Slabs
            Dim tbl As Data.DataTable


            If SlabFile.fileLength = 0 Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Warning) = "وارد کردن فایل پیوستی الزامی می باشد."
                Exit Sub
            End If


            If (SlabFile.filename.ToString <> SlabIdCheck_Txt.Text) Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "نام فایل بایستی با شماره قطعه یکی باشد."
                Exit Sub
            End If

            If (SlabIdCheck_Txt.Text.Length <> 10) Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "شماره قطعه بایستی ده رقمی باشد."
                Exit Sub
            End If

            'If (SlabIdCheck_Txt.Text.Length <> 10) Then
            '    Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "شماره قطعه بایستی ده رقمی باشد."
            '    Exit Sub
            'End If


            tbl = slab.SlabSelect_BySlabId(SlabIdCheck_Txt.Text)
            If (tbl.Rows.Count > 0) Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "شماره قطعه وارده در سیستم موجود می باشد."
                Exit Sub
            End If

            'tbl2 = slab.SlabSelect_BySlabId(Avvaliye_DD.SelectedValue)
            'If (tbl2.Rows.Count = 0) Then
            '    Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "  کد ماده اولیه در سیستم موجود نمی باشد."
            '    Exit Sub
            'End If




            If SlabFile.fileselect Then

                Me.ViewState("SlabFile") = "..\..\..\Uploads\Slabs\" + SlabFile.filename + "300" + SlabFile.filetype


                SlabFile.File.PostedFile.SaveAs(Server.MapPath(".\Temp\") + "..\..\..\Uploads\Slabs\" &
                                               SlabFile.filename +
                                               "300" +
                                               SlabFile.filetype
                                               )

                Me.ViewState("filename") = SlabFile.filename
                Me.ViewState("filetype") = SlabFile.filetype

            Else
                Me.ViewState("SlabFile") = "0"
            End If


            Dim table As New Data.DataTable

            table = slab.SlabSelect_BySlabId(SlabIdCheck_Txt.Text)

            If table.Rows.Count > 0 Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "شماره قطعه وارد شده قبلا در سیستم ثبت شده است."
                Exit Sub
            End If





            Me.SlabId2_Lbl.Text = SlabIdCheck_Txt.Text
            Me.SlabName2_Lbl.Text = SlabName_Txt.Text
            Me.PerSlabName2_Lbl.Text = PerSlabName_Txt.Text
            Me.MultiView1.SetActiveView(AssemblySubmit2)




            'Dim slabFileWithCodeMohandesi As String = Me.ViewState("SlabFile") + "300"
            'Dim slabType As String = 3

            'Dim err As String = slab.Slab_Assembly_Insert(SlabIdCheck_Txt.Text, PerSlabName_Txt.Text,
            '                                          SlabName_Txt.Text, SlabDesc_Txt.Text, slabFileWithCodeMohandesi)

            'If err = 0 Then
            '    SlabIdCheck_Txt.Text = ""
            '    PerSlabName_Txt.Text = ""
            '    SlabName_Txt.Text = ""
            '    SlabDesc_Txt.Text = ""
            '    Me.ViewState("SlabFile") = "0"

            '    FillDataGrid()

            '    Me.Message.ErrMessages(Arad.Message.MessageType.Success) = "ثبت با موفقیت انجام شد."
            'Else
            '    Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "ثبت با مشکل مواجه شد."
            'End If
        Catch ex As Exception
            Me.Session("ErrorMsg") = ex.Message.ToString
        End Try
    End Sub

    Protected Sub Delete_LBtn_Click(sender As Object, e As EventArgs)
        Try
            Dim Lbtn As New LinkButton
            Lbtn = sender

            Dim i As Integer
            For i = 0 To CType(ViewState("tableA"), Data.DataTable).Rows.Count - 1
                If CType(ViewState("tableA"), Data.DataTable).Rows(i).Item("شماره قطعه").ToString = Lbtn.CommandArgument Then
                    CType(ViewState("tableA"), Data.DataTable).Rows.RemoveAt(i)

                    slabsList_GV.DataSource = CType(ViewState("tableA"), Data.DataTable)
                    slabsList_GV.DataBind()
                    Exit Sub
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Edit_LBtn_Click(sender As Object, e As EventArgs)

        Dim Lbtn As New LinkButton
            Lbtn = sender
            Dim i As Integer

            For i = 0 To CType(ViewState("tableA"), Data.DataTable).Rows.Count - 1
                If CType(ViewState("tableA"), Data.DataTable).Rows(i).Item("شماره قطعه").ToString = Lbtn.CommandArgument Then
                slabsList_GV.EditIndex = i
                slabsList_GV.DataSource = CType(ViewState("tableA"), Data.DataTable)
                    slabsList_GV.DataBind()

                    DirectCast(slabsList_GV.Rows(i).FindControl("Delete_LBtn"), LinkButton).Visible = False
                    DirectCast(slabsList_GV.Rows(i).FindControl("Edit_LBtn"), LinkButton).Visible = False
                    DirectCast(slabsList_GV.Rows(i).FindControl("Update_LBtn"), LinkButton).Visible = True

                    Exit Sub
                End If
            Next

    End Sub

    Protected Sub Update_LBtn_Click(sender As Object, e As EventArgs)
        Try
            Dim LBtn As New LinkButton
            LBtn = sender


            Dim i As Integer
            For i = 0 To CType(ViewState("tableA"), Data.DataTable).Rows.Count - 1
                If CType(ViewState("tableA"), Data.DataTable).Rows(i).Item("شماره قطعه").ToString = LBtn.CommandArgument Then
                    Exit For
                End If
            Next


            Dim j As Integer
            For j = 0 To CType(ViewState("tableA"), Data.DataTable).Rows.Count - 1
                If i <> j And CType(ViewState("tableA"), Data.DataTable).Rows(j).Item("ردیف").ToString =
                DirectCast(slabsList_GV.Rows(i).FindControl("Row_Txt"), TextBox).Text Then
                    Dim row2 As String = DirectCast(slabsList_GV.Rows(i).FindControl("Row_Txt"), TextBox).Text
                    Dim row1 As String = CType(ViewState("tableA"), Data.DataTable).Rows(i).Item("ردیف").ToString

                    CType(ViewState("tableA"), Data.DataTable).Rows(i).Item("ردیف") = row2
                    CType(ViewState("tableA"), Data.DataTable).Rows(j).Item("ردیف") = row1

                    Exit For
                End If
            Next


            DirectCast(slabsList_GV.Rows(i).FindControl("Delete_LBtn"), LinkButton).Visible = True
            DirectCast(slabsList_GV.Rows(i).FindControl("Edit_LBtn"), LinkButton).Visible = True
            DirectCast(slabsList_GV.Rows(i).FindControl("Update_LBtn"), LinkButton).Visible = False

            Dim row As String = DirectCast(slabsList_GV.Rows(i).FindControl("Row_Txt"), TextBox).Text
            Dim shomareGate As String = DirectCast(slabsList_GV.Rows(i).FindControl("ShomareGate_Txt"), TextBox).Text
            Dim tedad As String = DirectCast(slabsList_GV.Rows(i).FindControl("Tedad_Txt"), TextBox).Text

            CType(ViewState("tableA"), Data.DataTable).Rows(i).Item("ردیف") = row
            CType(ViewState("tableA"), Data.DataTable).Rows(i).Item("تعداد") = tedad
            CType(ViewState("tableA"), Data.DataTable).Rows(i).Item("شماره قطعه") = shomareGate


            slabsList_GV.EditIndex = -1
            Dim datatable As New Data.DataTable
            datatable = TryCast(Me.ViewState("tableA"), Data.DataTable)
            If Not datatable Is Nothing Then
                Dim dataView As New Data.DataView(datatable)
                dataView.Sort = "ردیف"
                Me.ViewState("tableA") = dataView.Table
                slabsList_GV.DataSource = dataView
                slabsList_GV.DataBind()
            End If



        Catch ex As Exception

        End Try

    End Sub

    Protected Sub addToList_Click(sender As Object, e As EventArgs) Handles addToList.Click
        Try
            Dim tbl As New Data.DataTable
            Dim slab As New Slabs
            tbl = slab.SlabSelect_BySlabId(Check_SlabId.Text)
            If tbl.Rows.Count > 0 Then
                'If (tbl.Rows(0).Item("Sarparast_Flag").ToString ="N") And tbl.Rows(0).Item("SlabType").ToString=3
                'Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "قطعه مونتاژی وارد شده شما، توسط سرپرست رد شده است."
                'If (tbl.Rows(0).Item("Sarparast_Flag").ToString ="Z") And tbl.Rows(0).Item("SlabType").ToString=3
                'Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "قطعه مونتاژی وارد شده شما، توسط سرپرست بررسی نشده است."
                'Exit Sub

            Else
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "قطعه وارد شده یافت نشد."
                Exit Sub
            End If

            Dim i As Integer
            For i = 0 To slabsList_GV.Rows.Count - 1
                If CType(ViewState("tableA"), Data.DataTable).Rows(i).Item("شماره قطعه").ToString = Check_SlabId.Text Then
                    Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "قطعه وارد شده قبلا به لیست اضافه گردیده است."
                    Exit Sub

                ElseIf CType(ViewState("tableA"), Data.DataTable).Rows(i).Item("ردیف").ToString = rowNumber.text Then
                    Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "ردیف وارد شده قبلا به لیست اضافه گردیده است."
                    Exit Sub
                End If
            Next


            Dim drNewRow As Data.DataRow
            drNewRow = CType(ViewState("tableA"), Data.DataTable).NewRow()
            drNewRow.Item("ردیف") = rowNumber.text
            drNewRow.Item("شماره قطعه") = Check_SlabId.Text
            drNewRow.Item("تعداد") = tedad_Txt.Text

            CType(ViewState("tableA"), Data.DataTable).Rows.Add(drNewRow)



            Dim dataTable As New Data.DataTable
            dataTable = TryCast(Me.ViewState("tableA"), Data.DataTable)
            If Not dataTable Is Nothing Then
                Dim dataView As New Data.DataView(dataTable)
                dataView.Sort = "ردیف"

                Me.ViewState("tableA") = dataView.Table
                slabsList_GV.DataSource = dataView
                slabsList_GV.DataBind()
            End If


            rowNumber.text = ""
            Check_SlabId.Text = ""
            tedad_Txt.Text = ""

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub AssemblySubmit_Btn_Click(sender As Object, e As EventArgs)
        Dim slab As New Slabs
        Dim dateSelector As New DateSelector


        If CType(ViewState("tableA"), Data.DataTable).Rows.Count = 0 Then
            Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "لطفا زیر قطعات مربوط به قطعه اسمبلی را وارد نمایید."
            Exit Sub
        End If

        Dim slabType As Decimal = 3
        Dim version As Decimal = 0

        Dim err As String = slab.Slab_Assembly_Insert(CType(ViewState("tableA"), Data.DataTable), SlabIdCheck_Txt.Text,
                                                     SlabName_Txt.Text, PerSlabName_Txt.Text, Me.ViewState("SlabFile"), SlabDesc_Txt.Text,
                                                     dateSelector.today_Date_Fa, version, slabType)

        If err = 0 Then
            SlabDesc_Txt.Text = ""
            Me.ViewState("tableA") = Nothing
            Me.ViewState("tableA") = createTableSlabSubs()
            Me.ViewState("tableA").clone()
            Me.ViewState("filename") = ""
            Me.ViewState("filetype") = ""


            Me.slabsList_GV.DataSource = CType(Me.ViewState("tableA"), Data.DataTable)
            Me.slabsList_GV.DataBind()
            Me.MultiView1.SetActiveView(AssemblySubmit1)

            Me.Message.ErrMessages(Arad.Message.MessageType.Success) = "اطلاعات قطعه اسمبلی با موفقیت ثبت گردید."
        Else
            Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "ثبت اطلاعات قطعه اسمبلی با مشکل مواجه گردید."

        End If


    End Sub


    Protected Sub SlabFile2_LBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SlabFile2_LBtn.Click

        Response.Write("<script type='text/javascript'>window.open('" + "../../Uploads/Slabs/" & Me.ViewState("filename") + "300" & Me.ViewState("filetype") + "');</script>")

    End Sub
    Public Property url

    Protected Sub Eslah_Btn_Click(sender As Object, e As EventArgs)
        Me.MultiView1.SetActiveView(AssemblySubmit1)
    End Sub
End Class

