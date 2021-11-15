<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Pages/MasterPage/MasterPage.Master" CodeBehind="Slab_Insert_Assembly.aspx.vb" Inherits="Arad.Slab_Insert_Assembly" Theme="Admin" %>

<%@ Register Src="~/Components/Message/Message.ascx" TagPrefix="uc1" TagName="Message" %>
<%@ Register Src="~/Components/File_Upload/File_Upload.ascx" TagPrefix="uc1" TagName="File_Upload" %>
<%@ Register Src="~/Components/SlabId_Check/SlabId_Check.ascx" TagPrefix="uc2" TagName="SlabId_Check" %>
<%@ Register Src="~/Components/Validations/IntValidation.ascx" TagPrefix="uc1" TagName="IntValidation" %>
<%@ Register Src="~/Components/SlabId_Check/CheckSlabCode.ascx" TagPrefix="uc1" TagName="CheckSlabCode" %>







<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--Test--%>
   
    <style>
        .info p {
            text-align: center;
            color: #999;
            text-transform: none;
            font-weight: 600;
            font-size: 15px;
            margin-top: 2px
        }

        .info i {
            color: #F6AA93;
        }



        input {
            border-radius: 0px 5px 5px 0px;
            border: 1px solid #eee;
            margin-bottom: 15px;
            width: 75%;
            height: 40px;
            float: left;
            padding: 0px 15px;
        }

        .SlabIdLabel {
            border-radius: 0px 5px 5px 0px;
            border: 1px solid #eee;
            margin-bottom: 15px;
            width: 75%;
            height: 40px;
            float: left;
            padding: 0px 15px;
        }

        a {
            text-decoration: inherit
        }

        textarea {
            border-radius: 0px 5px 5px 0px;
            border: 1px solid #EEE;
            margin: 0;
            width: 75%;
            height: 130px;
            float: left;
            padding: 0px 15px;
        }

        .form-group {
            overflow: hidden;
            clear: both;
        }

        .icon-case {
            width: 35px;
            float: left;
            border-radius: 5px 0px 0px 5px;
            background: #eeeeee;
            height: 40px;
            position: relative;
            text-align: center;
            line-height: 40px;
        }

        span i {
            color: #555;
        }

        .contentform {
            padding: 40px 30px;
        }

        .bouton-contact {
            background-color: #81BDA4;
            color: #FFF;
            text-align: center;
            width: 15%;
            border: 0;
            padding: 10px 10px;
            border-radius: 5px 5px 5px 5px;
            cursor: pointer;
            font-size: 18px;
            margin-right: 62%;
        }



        .validation {
            display: none;
            margin: 0 0 10px;
            font-weight: 400;
            font-size: 13px;
            color: #DE5959;
        }

        #sendmessage {
            border: 1px solid #fff;
            display: none;
            text-align: center;
            margin: 10px 0;
            font-weight: 600;
            margin-bottom: 30px;
            background-color: #EBF6E0;
            color: #5F9025;
            border: 1px solid #B3DC82;
            padding: 13px 40px 13px 18px;
            border-radius: 3px;
            box-shadow: 0px 1px 1px 0px rgba(0, 0, 0, 0.03);
        }

            #sendmessage.show, .show {
                display: block;
            }
    </style>
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <uc1:Message runat="server" ID="Message" />
    <asp:MultiView runat="server" ID="MultiView1">
        <asp:View runat="server" ID="AssemblySubmit1">

            <div>

                <h2>ثبت قطعه اسمبلی</h2>
            </div>
            <hr />

            <div class="contentform col-md-7 col-7 float-none m-auto ">

                <div id="sendmessage">Your message has been sent successfully. Thank you. </div>

                <div>
                    <div class="form-group">
                        <label>شماره قطعه : </label>
                        <span class="icon-case"><i class="fa fa-cogs"></i></span>

                        <uc2:SlabId_Check runat="server" ID="SlabIdCheck_Txt" MaxLength="10" />
                    </div>

                    <div class="form-group">
                        <label>نام قطعه:</label>
                        <span class="icon-case"><i class="fa fa-etsy"></i></span>
                        <asp:TextBox runat="server" ID="SlabName_Txt" name="prenom" data-rule="required" />
                        <div class="validation"></div>
                    </div>

                    <div class="form-group">
                        <label>نام فارسی قطعه :</label>
                        <span class="icon-case"><i class="fa fa-font"></i></span>
                        <asp:TextBox runat="server" type="text" name="ville" ID="PerSlabName_Txt" data-rule="required" />
                        <div class="validation"></div>
                    </div>

                    <div class="form-group">
                        <label>فایل پیوستی :</label>
                        <span class="icon-case"><i class="fa fa-file-pdf-o"></i></span>
                        <%--   <asp:FileUpload runat="server" ID="SlabFile_File" Style="padding-top: 5px" />--%>
                        <uc1:File_Upload runat="server" ID="SlabFile" />
                        <div class="validation"></div>
                    </div>

                    <div class="form-group">
                        <label>توضیحات :</label>
                        <span class="icon-case"><i class="fa fa-commenting"></i></span>
                        <asp:TextBox runat="server" name="Description" ID="SlabDesc_Txt" data-rule="maxlen:10" />
                        <div class="validation"></div>
                    </div>
                </div>
            </div>
            <div class="col-md-12 col-12">
                <asp:Button runat="server" ID="Submit_Btn" CssClass="bouton-contact" Text="ادامه" OnClick="Submit_Btn_Click" />
            </div>
        </asp:View>


        <asp:View runat="server" ID="AssemblySubmit2">
            <h4>ثبت قطعات زیر مجموعه</h4>
            <table style="width: 100%; direction: rtl">
                <tr>
                    <td style="width: 250px; text-align: center;">
                        <asp:Label runat="server">شماره قطعه : </asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="SlabId2_Lbl"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td style="width: 250px; text-align: center;">
                        <asp:Label runat="server">نام قطعه : </asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="SlabName2_Lbl"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td style="width: 250px; text-align: center;">
                        <asp:Label runat="server">نام فارسی قطعه : </asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="PerSlabName2_Lbl"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td style="width: 250px; text-align: center;"></td>
                    <td>
                        <asp:LinkButton ID="SlabFile2_LBtn" runat="server" Visible="true">فایل ضمیمه</asp:LinkButton>
                    </td>
                </tr>




                <tr>
                    <td style="width: 250px; text-align: center;"></td>
                    <td>
                        <asp:Label runat="server">ثبت قطعات زیر مجموعه</asp:Label>
                    </td>
                </tr>

                <tr>
                    <td style="width: 250px; text-align: center;"></td>
                    <td>
                        <table style="width: 100%; direction: rtl">
                            <tr>
                                <td style="vertical-align: central; width: 140px; text-align: center;">
                                    <asp:Label runat="server">ردیف</asp:Label>
                                </td>
                                <td>
                                    <uc1:IntValidation runat="server" id="rowNumber" />
                                </td>
                            </tr>

                            <tr>
                                <td style="vertical-align: central; width: 140px; text-align: center;">
                                    <asp:Label runat="server">شماره قطعه</asp:Label>
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UP1" runat="server">
                                        <ContentTemplate>
                                            <uc1:CheckSlabCode runat="server" id="Check_SlabId" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>


                            <tr>
                                <td style="vertical-align: central; width: 140px; text-align: center;">
                                    <asp:Label runat="server">تعداد</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="tedad_Txt"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFV1" runat="server" ControlToValidate="tedad_Txt" ErrorMessage="الزامی می باشد"></asp:RequiredFieldValidator>
                                </td>
                            </tr>


                            <tr>
                                <td style="vertical-align: central; width: 140px; text-align: center;"></td>
                                <td>
                                    <asp:Button CssClass="btn btn-light mb-1" runat="server" ID="addToList" Text="افزودن به لیست" OnClick="addToList_Click"/>
                                    <br />
                                    <asp:GridView ID="slabsList_GV" runat="server" SkinID="GV_Skin">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Delete_LBtn" runat="server" CommandArgument='<%#Eval("شماره قطعه") %>' Font-Underline="false"
                                                        OnClick="Delete_LBtn_Click">حذف</asp:LinkButton>
                                                    <br />
                                                    <asp:LinkButton ID="Edit_LBtn" runat="server" CommandArgument='<%#Eval("شماره قطعه") %>' Font-Underline="false"
                                                        OnClick="Edit_LBtn_Click" ValidationGroup="s1">ویرایش</asp:LinkButton>
                                                    <br />
                                                    <asp:LinkButton ID="Update_LBtn" runat="server" CommandArgument='<%#Eval("شماره قطعه") %>' Font-Underline="false"
                                                        OnClick="Update_LBtn_Click" ValidationGroup="s2">بروزرسانی</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="ردیف">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="Row_Txt" runat="server" Text='<%# eval("ردیف") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Row_Lbl" runat="server" Text='<%# eval("ردیف") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="شماره قطعه">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="ShomareGate_Txt" runat="server" Text='<%# eval("شماره قطعه") %>'></asp:TextBox>
                                                </EditItemTemplate>

                                                <ItemTemplate>
                                                    <asp:Label ID="ShomareGate_Lbl" runat="server" Text='<%# eval("شماره قطعه") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="تعداد">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="Tedad_Txt" runat="server" Text='<%# eval("تعداد") %>'></asp:TextBox>
                                                </EditItemTemplate>

                                                <ItemTemplate>
                                                    <asp:Label ID="Tedad_Lbl" runat="server" Text='<%# eval("تعداد") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>

                <tr>
                    <td style="width: 250px; text-align: center;"></td>
                    <td style="height: 110px">
                        <asp:Button CssClass="btn btn-light" runat="server" ID="Eslah_Btn" Text="بازگشت" OnClick="Eslah_Btn_Click" ValidationGroup="s3"></asp:Button>
                        <asp:Button CssClass="btn btn-success" runat="server" ID="AssemblySubmit_Btn" Text="ثبت نهایی" OnClick="AssemblySubmit_Btn_Click"  ValidationGroup="s4" />
                    </td>
                </tr>
            </table>
        </asp:View>

    </asp:MultiView>
</asp:Content>
