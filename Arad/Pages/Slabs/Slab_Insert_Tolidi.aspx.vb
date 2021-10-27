Public Class Slab_Insert_Tolidi
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.Title = "ثبت قطعه تولیدی"
            Me.MultiView1.SetActiveView(TolidiSubmit)
            If (Page.IsPostBack = False) Then
                Slab_Avvaliye_DD_Fill()
                SlabBorade_DD_Fill()
            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub Slab_Avvaliye_DD_Fill()
        Dim tbl As New Data.DataTable
        Dim slab As New Slabs
        Dim general As New General
        Dim slabType = 0
        tbl = slab.SlabsSelectByType(slabType)
        If tbl.Rows.Count > 0 Then
            general.DropDownFill(Avvaliye_DD, "FullName", "SlabId", tbl)
        End If
    End Sub

    Private Sub SlabBorade_DD_Fill()
        Dim tbl As New Data.DataTable
        Dim slab As New Slabs
        Dim general As New General
        tbl = slab.SlabBoradeSelect()
        If tbl.Rows.Count > 0 Then
            general.DropDownFill(TabageyeBorade_DD, "BoradeName", "SabetId", tbl)
        End If
    End Sub

    Protected Sub Submit_Btn_Click(sender As Object, e As EventArgs)
        Try
            Dim slab As New Slabs
            Dim tbl As New Data.DataTable
            Dim tbl2 As New Data.DataTable
            Dim dateSelector As New DateSelector

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

            If (SlabIdCheck_Txt.Text.Length <> 10) Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "شماره قطعه بایستی ده رقمی باشد."
                Exit Sub
            End If


            tbl = slab.SlabSelect_BySlabId(SlabIdCheck_Txt.Text)
            If (tbl.Rows.Count > 0) Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "شماره قطعه وارده در سیستم موجود می باشد."
                Exit Sub
            End If

            tbl2 = slab.SlabSelect_BySlabId(Avvaliye_DD.SelectedValue)
            If (tbl2.Rows.Count = 0) Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "  کد ماده اولیه در سیستم موجود نمی باشد."
                Exit Sub
            End If

            If SlabFile.fileselect Then


                Me.ViewState("SlabFile") = "..\..\..\Uploads\Slabs\" & Date.Now.Hour.ToString & Date.Now.Minute.ToString + "_" + SlabFile.filename + SlabFile.filetype

            Else
                Me.ViewState("SlabFile") = "0"
            End If






            Dim slabType As String = 1

            Dim err As String = slab.Slab_Tolidi_Insert(SlabIdCheck_Txt.Text, PerSlabName_Txt.Text, slabType,
                                                        SlabName_Txt.Text, Convert.ToDecimal(Megdar_Txt.Text),
                                                        Convert.ToDecimal(VazneMasrafi_Txt.Text), Convert.ToDecimal(VazneKhales_Txt.Text),
                                                        TabageyeBorade_DD.SelectedValue, Convert.ToDecimal(TedadeHasele_Txt.Text),
                                                        Me.ViewState("SlabFile"), SlabDesc_Txt.Text, dateSelector.today_Date_Fa,
                                                        Avvaliye_DD.SelectedValue.ToString)


            If err = 0 Then
                SlabFile.File.PostedFile.SaveAs(Server.MapPath(".\Temp\") + "..\..\..\Uploads\Slabs\" &
                                                Date.Now.Hour.ToString &
                                                Date.Now.Minute.ToString +
                                                "_" +
                                                SlabFile.filename +
                                                SlabFile.filetype
                                                )

                SlabIdCheck_Txt.restore()
                SlabIdCheck_Txt.Text = ""
                PerSlabName_Txt.Text = ""
                SlabName_Txt.Text = ""
                SlabDesc_Txt.Text = ""
                Megdar_Txt.Text = ""
                VazneMasrafi_Txt.Text = ""
                VazneKhales_Txt.Text = ""
                Me.ViewState("SlabFile") = "0"
                TedadeHasele_Txt.Text = ""
                Slab_Avvaliye_DD_Fill()



                Me.Message.ErrMessages(Arad.Message.MessageType.Success) = "ثبت با موفقیت انجام شد."
            Else
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "ثبت با مشکل مواجه شد."
            End If
        Catch ex As Exception
            Me.Session("ErrorMsg") = ex.Message.ToString
        End Try
    End Sub




    Protected Sub Return_Btn_Click(sender As Object, e As EventArgs)
        Me.MultiView1.SetActiveView(TolidiSubmit)
    End Sub


    Protected Sub AvvaliyehSearch_Txt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AvvaliyehSearch_Txt.TextChanged

        Dim table As New Data.DataTable
        Dim slab As New Slabs
        Dim general As New General
        Me.ViewState("SlabIdAvvaliyeh") = Avvaliye_DD.SelectedValue.ToString


        If (AvvaliyehSearch_Txt.Text = "") Then
            Avvaliye_DD.SelectedValue = Me.ViewState("SlabIdAvvaliyeh")
        Else
            table = slab.SlabSelect_LikeSlabId(AvvaliyehSearch_Txt.Text)
            general.DropDownFill(Avvaliye_DD, "FullName", "SlabId", table)

        End If
    End Sub
End Class
