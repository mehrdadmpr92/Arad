Public Class Slab_Insert_Masrafi
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.Title = "ثبت قطعه مصرفی"
            Me.MultiView1.SetActiveView(MasrafiSubmit)


        Catch ex As Exception
        End Try

    End Sub

    Protected Sub Submit_Btn_Click(sender As Object, e As EventArgs)
        Try
            Dim slab As New Slabs
            Dim tbl As New Data.DataTable


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

            tbl = slab.SlabSelect_BySlabId(SlabIdCheck_Txt.Text)
            If (tbl.Rows.Count > 0) Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "شماره قطعه وارده در سیستم موجود می باشد."
                Exit Sub
            End If



            If SlabFile.fileselect Then

                Me.ViewState("SlabFile") = "..\..\..\Uploads\Slabs\" + SlabFile.filename + "500" + SlabFile.filetype

            Else
                Me.ViewState("SlabFile") = "0"
            End If

            If (SlabFile.filename.ToString <> SlabIdCheck_Txt.Text) Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Success) = "نام فایل بایستی با شماره قطعه یکی باشد."
                Exit Sub

            End If


            Dim slabType As String = 5

            Dim err As String = slab.Slab_Masrafi_Insert(SlabIdCheck_Txt.Text, PerSlabName_Txt.Text, slabType,
                                                        SlabName_Txt.Text, SlabDesc_Txt.Text, Me.ViewState("SlabFile"))

            If err = 0 Then
                SlabFile.File.PostedFile.SaveAs(Server.MapPath(".\Temp\") + "..\..\..\Uploads\Slabs\" + SlabFile.filename + "500" +
                                                SlabFile.filetype
                                                )

                SlabIdCheck_Txt.restore()
                SlabIdCheck_Txt.Text = ""
                PerSlabName_Txt.Text = ""
                SlabName_Txt.Text = ""
                SlabDesc_Txt.Text = ""
                Me.ViewState("SlabFile") = "0"



                Me.Message.ErrMessages(Arad.Message.MessageType.Success) = "ثبت با موفقیت انجام شد."
            Else
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "ثبت با مشکل مواجه شد."
            End If
        Catch ex As Exception
            Me.Session("ErrorMsg") = ex.Message.ToString
        End Try



    End Sub
End Class