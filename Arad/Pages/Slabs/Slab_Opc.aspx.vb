Public Class Slab_Opc
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.Title = " ثبت مراحل ساخت قطعه"
            If Page.IsPostBack = False Then
                Me.MultiView1.SetActiveView(OpcSubmit_check)
                OpcOperatios_DD_Fill()
            End If


        Catch ex As Exception
        End Try
    End Sub

    Private Sub OpcOperatios_DD_Fill()
        Dim tbl As New Data.DataTable
        Dim Opc As New OPC
        Dim general As New General
        tbl = Opc.OpcOperationSelect()
        If tbl.Rows.Count > 0 Then
            general.DropDownFill(OperationTitle_DD, "OperationTitle", "SabetId", tbl)
        End If
    End Sub
    Private Function createTableSlabOPC() As Object
        Try
            Dim tableOPC As New Data.DataTable
            Dim OpcRow As New Data.DataColumn("شماره ردیف", System.Type.GetType("System.Decimal"))
            tableOPC.Columns.Add(OpcRow)
            Dim OperationTitle As New Data.DataColumn("عنوان عملیات")
            tableOPC.Columns.Add(OperationTitle)
            Dim OpcDesc As New Data.DataColumn("شرح عملیات")
            tableOPC.Columns.Add(OpcDesc)
            Dim Tools As New Data.DataColumn("ابزار")
            tableOPC.Columns.Add(Tools)
            Dim Fixcher As New Data.DataColumn("فیکسچر")
            tableOPC.Columns.Add(Fixcher)
            Dim TarefehWorker As New Data.DataColumn("تعرفه کارگری")
            tableOPC.Columns.Add(TarefehWorker)
            Dim NumWorker As New Data.DataColumn("تعدادکارگر")
            tableOPC.Columns.Add(NumWorker)
            Dim TanzimTime As New Data.DataColumn("زمان تنظیم")
            tableOPC.Columns.Add(TanzimTime)
            Dim SlabTime As New Data.DataColumn("زمان قطعه")
            tableOPC.Columns.Add(SlabTime)


            Return tableOPC

        Catch ex As Exception

        End Try

    End Function



    Protected Sub Continue_Btn_Click(sender As Object, e As EventArgs)
        Try
            Dim slab As New Slabs
            Dim Opc As New OPC
            Dim Opctbl As New Data.DataTable
            Dim dateSelector As New DateSelector

            If (SlabId_Txt.Text.Length <> 10) Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "شماره قطعه بایستی ده رقمی باشد."
                Exit Sub
            End If

            Opctbl = slab.SlabSelect_BySlabId(SlabId_Txt.Text)
            If (Opctbl.Rows.Count > 0) Then

            Else
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "قطعه وارد شده یافت نشد."
                Exit Sub
            End If

            Me.MultiView1.SetActiveView(OpcSubmit)
            Load_OPCList_GV(SlabId_Txt.Text)
            Load_OPC_Row()

        Catch ex As Exception
            Me.Session("ErrorMsg") = ex.Message.ToString
        End Try
    End Sub
    Protected Sub addToList_Click(sender As Object, e As EventArgs)
        Try


            If OPCRow.text = String.Empty Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "شماره ردیف بایستی وارد گردد."
                Exit Sub
            End If

            If OpcDesc_Txt.Text = String.Empty Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "شرح عملیات بایستی وارد گردد."
                Exit Sub
            End If

            If TarefehWorker_Txt.Text = String.Empty Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "تعرفه کارگری بایستی وارد گردد."
                Exit Sub
            End If



            If NumWorker_Txt.Text = String.Empty Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "تعداد کارگر بایستی وارد گردد."
                Exit Sub
            End If


            If TanzimTime_Txt.Text = String.Empty Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "زمان تنظیم بایستی وارد گردد."
                Exit Sub
            End If


            If SlabTime_Txt.Text = String.Empty Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "زمان قطعه بایستی وارد گردد."
                Exit Sub
            End If


            Dim opc As New OPC
            If Fixcher.Text.Length > 0 Then
                Dim tbl As New Data.DataTable
                tbl = opc.Fixcher_Select(Fixcher.Text)
                If Not tbl.Rows.Count > 0 Then
                    Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "کد فیکسچر وارد شده معتبر نمی باشد."
                    Exit Sub
                End If
                Me.ViewState("FixcherId") = tbl.Rows(0).Item("SabetId").ToString()
            End If


            For i = 0 To OPCList_GV.Rows.Count - 1
                If OPCRow.text = OPCList_GV.Rows(i).Cells(0).Text Then
                    Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "شماره ردیف مراحل ساخت تکراری می باشد."
                    Exit Sub
                End If
            Next

            If Fixcher.Text = "" Then
                Fixcher.Text = 0
            End If

            Dim val As String = OperationTitle_DD.SelectedItem.ToString


            Dim dateSelector As New DateSelector

            Dim Err As String
                Err = opc.Slab_Opc_Insert(SlabId_Txt.Text, OPCRow.Text, OperationTitle_DD.SelectedValue, OpcDesc_Txt.Text, Tools_Txt.Text, Fixcher.Text,
                                        TarefehWorker_Txt.Text, NumWorker_Txt.Text, TanzimTime_Txt.Text, SlabTime_Txt.Text, 1, dateSelector.today_Date_Fa)

                If Err = 0 Then
                Load_OPCList_GV(SlabId_Txt.Text)
                OPCRow.text = ""
                OpcDesc_Txt.Text = ""
                Tools_Txt.Text = ""
                Fixcher.Text = ""
                TarefehWorker_Txt.Text = ""
                NumWorker_Txt.Text = ""
                TanzimTime_Txt.Text = ""
                SlabTime_Txt.Text = ""

                Load_OPC_Row()


                Me.Message.ErrMessages(Arad.Message.MessageType.Success) = "OPC مورد نظر با موفقیت به لیست اضافه گردید."
            Else
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "OPC مورد نظر با مشکل مواجه گردید."
            End If

        Catch ex As Exception

        End Try


    End Sub

    Protected Sub Fixcher_TextChanged(sender As Object, e As EventArgs) Handles Fixcher.TextChanged
        Dim tbl As New Data.DataTable
        Dim opc As New OPC

        If Fixcher.Text.Length > 0 Then
            tbl = opc.Fixcher_Select(Fixcher.Text)
            If Not tbl.Rows.Count > 0 Then
                Fixcher_Validation_Lbl.Text = "فیکسچر وارد شده در سیستم موجود نمی باشد"
                Fixcher_Validation_Lbl.Visible = True
            End If
        End If

    End Sub

    Private Sub Load_OPCList_GV(text As String)
        Dim tbl As New Data.DataTable
        Dim opc As New OPC

        tbl = opc.Slab_OPC_Select(SlabId_Txt.Text)

        If tbl.Rows.Count > 0 Then
            Me.OPCList_GV.DataSource = tbl
            OPCList_GV.DataBind()
            Me.MultiView1.SetActiveView(OpcSubmit)

        End If

        tbl.Dispose()
        tbl = Nothing


    End Sub

    Private Sub Load_OPC_Row()
        Try
            If OPCList_GV.Rows.Count = 0 Then
                OPCRow.text = 10
            Else
                OPCRow.text = (Convert.ToInt64(
                                               Mid(OPCList_GV.Rows(OPCList_GV.Rows.Count - 1).Cells(0).Text, 1, OPCList_GV.Rows(OPCList_GV.Rows.Count - 1).
                                                   Cells(0).Text.Length - 1)
                                                   ) _
                                                   + 1) _
                                                   * 10
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub OPCSubmit_Btn_Click(sender As Object, e As EventArgs)
        Dim opc As New OPC
        Dim Err As String

        'Dim finish_Flaq As Boolean = True
        'Err = opc.Slab_Opc_Insert_Finish(SlabId_Txt.Text, finish_Flaq)
        'If (Err = 0) Then
        '    Me.Message.ErrMessages(Arad.Message.MessageType.Success) = "ثبت OPC قطعه مورد نظر با موفقیت پایان پذیرفت."
        'End If

        Me.MultiView1.SetActiveView(OpcSubmit_check)
        SlabId_Txt.Text = String.Empty
    End Sub

    Protected Sub Delete_LBtn_Click(sender As Object, e As EventArgs)
        Try
            Dim linkBtn As New LinkButton
            linkBtn = sender
            Dim Err As String
            Dim Opc As New OPC
            Me.ViewState("SlabOpcSubId") = linkBtn.CommandArgument

            Err = Opc.Slab_Opc_Sub_Delete(linkBtn.CommandArgument)

            If Err = 0 Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Success) = "حذف عملیات قطعه مورد نظر با موفقیت صورت پذیرفت."
                Load_OPCList_GV(SlabId_Txt.Text)
            Else
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "حذف عملیات قطعه مورد نظر با مشکل مواجه گردید."
            End If


        Catch ex As Exception

        End Try



    End Sub


    'Protected Sub OPCSubmit_Btn_Click(sender As Object, e As EventArgs)

    '    Dim slab As New Slabs
    '    Dim Opc As New OPC
    '    Dim Opctbl2 As New Data.DataTable
    '    Dim dateSelector As New DateSelector


    '    If CType(ViewState("tableOPC"), Data.DataTable).Rows.Count = 0 Then
    '        Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "لطفا مراحل ساخت قطعه را وارد نمایید."
    '        Exit Sub
    '    End If


    '    Dim slabType As String = 3
    '    Dim version As Decimal = 0

    '    Dim err As String = Opc.Slab_Opc_Insert(CType(ViewState("tableOPC"), Data.DataTable),
    '                                            SlabId_Txt.Text,
    '                                            slabType,
    '                                            version,
    '                                            dateSelector.today_Date_Fa)


    '    If err = 0 Then

    '        SlabId_Txt.restore()
    '        SlabId_Txt.Text = ""
    '        OPCRow.text = ""
    '        OpcDesc_Txt.Text = ""
    '        Tools_Txt.Text = ""
    '        Fixcher.Text = ""
    '        TarefehWorker_Txt.Text = ""
    '        NumWorker_Txt.Text = ""
    '        TanzimTime_Txt.Text = ""
    '        SlabTime_Txt.Text = ""
    '        OpcOperatios_DD_Fill()

    '        Me.ViewState("tableOPC") = Nothing
    '        Me.ViewState("tableOPC") = createTableSlabOPC()
    '        Me.ViewState("tableOPC").clone()




    '        Me.OPCList_GV.DataSource = CType(Me.ViewState("tableOPC"), Data.DataTable)
    '        Me.OPCList_GV.DataBind()
    '        Me.MultiView1.SetActiveView(OpcSubmit_check)



    '        Me.Message.ErrMessages(Arad.Message.MessageType.Success) = "ثبت با موفقیت انجام شد."
    '    Else
    '        Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "ثبت با مشکل مواجه شد."
    '    End If

    'End Sub

End Class