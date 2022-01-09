Public Class New_Product_Insert
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.Title = "ثبت محصول جدید"
            Me.MultiView1.SetActiveView(NewProductSubmit)


        Catch ex As Exception
        End Try
    End Sub

    Protected Sub Submit_Btn_Click(sender As Object, e As EventArgs)
        Try
            Dim slab As New Slabs
            Dim tbl As New Data.DataTable
            Dim Product As New Products
            Dim dateSelector As New DateSelector


            If (SlabIdForProduct.Flag = False) Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = SlabIdForProduct.Alert
                Exit Sub
            End If

            tbl = Product.CheckProductTradeCode(ProductTradeCode_Txt.Text)
            If tbl.Rows.Count > 0 Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "کد تجاری وارد شده شما قبلا در سیستم ثبت شده است"
                Exit Sub
            End If




            If Service_Manual_File.fileLength = 0 Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "وارد کردن فایل سرویس منوال الزامی می باشد."
                Exit Sub
            End If

            If User_Manual_File.fileLength = 0 Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "وارد کردن فایل یوزر منوال الزامی می باشد."
                Exit Sub
            End If

            If Catalog_File.fileLength = 0 Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "وارد کردن فایل کاتالوگ الزامی می باشد."
                Exit Sub
            End If

            If Tech_File.fileLength = 0 Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "وارد کردن فایل تکنیکال الزامی می باشد."
                Exit Sub
            End If

            If Revision_File.fileLength = 0 Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "وارد کردن فایل بازنگری طراحی الزامی می باشد."
                Exit Sub
            End If

            If Confirmation_File.fileLength = 0 Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "وارد کردن فایل تصدیق و صحه گذاری الزامی می باشد."
                Exit Sub
            End If

            If Sales_Guide_File.fileLength = 0 Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "وارد کردن فایل راهنمای فروش الزامی می باشد."
                Exit Sub
            End If

            If Booklets_File.fileLength = 0 Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "وارد کردن فایل دفترچه ها الزامی می باشد."
                Exit Sub
            End If

            If Related_File.fileLength = 0 Then
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "وارد کردن فایل های مرتبط الزامی می باشد."
                Exit Sub
            End If






            If Service_Manual_File.fileselect Then
                Me.ViewState("Service_Manual_File") = "..\..\..\Uploads\Products\" +
                    "Sm_" +
                    Service_Manual_File.filename +
                    Date.Now.Hour.ToString + Date.Now.Minute.ToString +
                    Service_Manual_File.filetype
            Else
                Me.ViewState("Service_Manual_File") = "0"
            End If

            If User_Manual_File.fileselect Then
                Me.ViewState("User_Manual_File") = "..\..\..\Uploads\Products\" +
                     "Um_" +
                   User_Manual_File.filename +
                   Date.Now.Hour.ToString + Date.Now.Minute.ToString +
                    User_Manual_File.filetype
            Else
                Me.ViewState("User_Manual_File") = "0"
            End If

            If Catalog_File.fileselect Then
                Me.ViewState("Catalog_File") = "..\..\..\Uploads\Products\" +
                     "Cf_" +
                    Catalog_File.filename +
                    Date.Now.Hour.ToString + Date.Now.Minute.ToString +
                    Catalog_File.filetype
            Else
                Me.ViewState("Catalog_File") = "0"
            End If

            If Tech_File.fileselect Then
                Me.ViewState("Tech_File") = "..\..\..\Uploads\Products\" +
                     "Tf_" +
                    Tech_File.filename +
                    Date.Now.Hour.ToString + Date.Now.Minute.ToString +
                    Tech_File.filetype
            Else
                Me.ViewState("Tech_File") = "0"
            End If

            If Revision_File.fileselect Then
                Me.ViewState("Revision_File") = "..\..\..\Uploads\Products\" +
                     "Rv_" +
                    Revision_File.filename +
                    Date.Now.Hour.ToString + Date.Now.Minute.ToString +
                    Revision_File.filetype
            Else
                Me.ViewState("Revision_File") = "0"
            End If

            If Confirmation_File.fileselect Then
                Me.ViewState("Confirmation_File") = "..\..\..\Uploads\Products\" +
                     "Cf_" +
                    Confirmation_File.filename +
                    Date.Now.Hour.ToString + Date.Now.Minute.ToString +
                    Confirmation_File.filetype
            Else
                Me.ViewState("Confirmation_File") = "0"
            End If

            If Sales_Guide_File.fileselect Then
                Me.ViewState("Sales_Guide_File") = "..\..\..\Uploads\Products\" +
                     "Sgf_" +
                    Sales_Guide_File.filename +
                    Date.Now.Hour.ToString + Date.Now.Minute.ToString +
                    Sales_Guide_File.filetype
            Else
                Me.ViewState("Sales_Guide_File") = "0"
            End If

            If Booklets_File.fileselect Then
                Me.ViewState("Booklets_File") = "..\..\..\Uploads\Products\" +
                     "Bf_" +
                    Booklets_File.filename +
                    Date.Now.Hour.ToString + Date.Now.Minute.ToString +
                    Booklets_File.filetype
            Else
                Me.ViewState("Booklets_File") = "0"
            End If

            If Related_File.fileselect Then
                Me.ViewState("Related_File") = "..\..\..\Uploads\Products\" +
                     "Rf_" +
                    Related_File.filename +
                    Date.Now.Hour.ToString + Date.Now.Minute.ToString +
                    Related_File.filetype
            Else
                Me.ViewState("Related_File") = "0"
            End If



            Dim err As String = Product.New_Product_Insert(
                SlabIdForProduct.Text,
                ProductTradeName_Txt.Text,
                ProductTradeCode_Txt.Text,
                Me.ViewState("Service_Manual_File"),
                Me.ViewState("User_Manual_File"),
                Me.ViewState("Catalog_File"),
                Me.ViewState("Tech_File"),
                Me.ViewState("Revision_File"),
                Me.ViewState("Confirmation_File"),
                Me.ViewState("Sales_Guide_File"),
                Me.ViewState("Booklets_File"),
                Me.ViewState("Related_File"),
                dateSelector.today_Date_Fa)


            If err = 0 Then

                Service_Manual_File.File.PostedFile.SaveAs(Server.MapPath(".\Temp\") + "..\..\..\Uploads\Products\" & "Sm_" + Service_Manual_File.filename + Date.Now.Hour.ToString + Date.Now.Minute.ToString + Service_Manual_File.filetype)

                User_Manual_File.File.PostedFile.SaveAs(Server.MapPath(".\Temp\") + "..\..\..\Uploads\Products\" & "Um_" + User_Manual_File.filename + Date.Now.Hour.ToString + Date.Now.Minute.ToString + User_Manual_File.filetype)

                Catalog_File.File.PostedFile.SaveAs(Server.MapPath(".\Temp\") + "..\..\..\Uploads\Products\" & "Cf_" + Catalog_File.filename + Date.Now.Hour.ToString + Date.Now.Minute.ToString + Catalog_File.filetype)

                Tech_File.File.PostedFile.SaveAs(Server.MapPath(".\Temp\") + "..\..\..\Uploads\Products\" & "Tf_" + Tech_File.filename + Date.Now.Hour.ToString + Date.Now.Minute.ToString + Tech_File.filetype)

                Revision_File.File.PostedFile.SaveAs(Server.MapPath(".\Temp\") + "..\..\..\Uploads\Products\" & "Rv_" + Revision_File.filename + Date.Now.Hour.ToString + Date.Now.Minute.ToString + Revision_File.filetype)

                Confirmation_File.File.PostedFile.SaveAs(Server.MapPath(".\Temp\") + "..\..\..\Uploads\Products\" & "Cf_" + Confirmation_File.filename + Date.Now.Hour.ToString + Date.Now.Minute.ToString + Confirmation_File.filetype)

                Sales_Guide_File.File.PostedFile.SaveAs(Server.MapPath(".\Temp\") + "..\..\..\Uploads\Products\" & "Sgf_" + Sales_Guide_File.filename + Date.Now.Hour.ToString + Date.Now.Minute.ToString + Sales_Guide_File.filetype)

                Booklets_File.File.PostedFile.SaveAs(Server.MapPath(".\Temp\") + "..\..\..\Uploads\Products\" & "Bf_" + Booklets_File.filename + Date.Now.Hour.ToString + Date.Now.Minute.ToString + Booklets_File.filetype)

                Related_File.File.PostedFile.SaveAs(Server.MapPath(".\Temp\") + "..\..\..\Uploads\Products\" & "Rf_" + Related_File.filename + Date.Now.Hour.ToString + Date.Now.Minute.ToString + Related_File.filetype)





                SlabIdForProduct.restore()
                ProductTradeName_Txt.Text = ""
                ProductTradeCode_Txt.Text = ""
                Me.ViewState("Service_Manual_File") = "0"
                Me.ViewState("User_Manual_File") = "0"
                Me.ViewState("Catalog_File") = "0"
                Me.ViewState("Tech_File") = "0"
                Me.ViewState("Revision_File") = "0"
                Me.ViewState("Confirmation_File") = "0"
                Me.ViewState("Sales_Guide_File") = "0"
                Me.ViewState("Booklets_File") = "0"
                Me.ViewState("Related_File") = "0"



                Me.Message.ErrMessages(Arad.Message.MessageType.Success) = "ثبت محصول با موفقیت انجام شد."
            Else
                Me.Message.ErrMessages(Arad.Message.MessageType.Err) = "ثبت محصول با مشکل مواجه شد."
            End If



        Catch ex As Exception
            Me.Session("ErrorMsg") = ex.Message.ToString
        End Try
    End Sub
End Class