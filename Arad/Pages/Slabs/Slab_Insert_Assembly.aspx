<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Pages/MasterPage/MasterPage.Master" CodeBehind="Slab_Insert_Assembly.aspx.vb" Inherits="Arad.Slab_Insert_Assembly" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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

        .SlabIdLabel{
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


    <asp:MultiView runat="server" ID="MultiView1">
        <asp:View runat="server" ID="AssemblySubmit">
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
                        <asp:TextBox runat="server" TextMode="Number" name="nom" ID="SlabId_Txt" data-rule="required" />
                        <div class="validation"></div>
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
                        <asp:FileUpload runat="server" ID="SlabFile_File" Style="padding-top: 5px" />
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
                <asp:Button runat="server" ID="Submit_Btn" CssClass="bouton-contact" Text="ثبت" OnClick="Submit_Btn_Click" />
            </div>
        </asp:View>





        <asp:View runat="server" ID="AssemblyArchive">
            <div>
                <h2>آرشیو تمامی قطعات</h2>
            </div>
            <hr />
            <asp:GridView runat="server" ID="DG_Archive" Width="100%" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="SlabId" HeaderText="شماره قطعه" />
                    <asp:BoundField DataField="SlabName" HeaderText="نام قطعه" />
                    <asp:BoundField DataField="SlabNameEng" HeaderText="نام فارسی قطعه" />
                    <asp:BoundField DataField="Description" HeaderText="توضیحات قطعه" />

                    <asp:TemplateField HeaderText="ابزار">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="LbtEdit_Click" CssClass="btn btn-link" 
                                OnClick="LbtEdit_Click_Click" CommandArgument='<%#Eval("SlabId") %>'>ویرایش</asp:LinkButton>

                            <asp:LinkButton runat="server" ID="Delete_Btn" OnClientClick="var a_href = $(this).attr('href'); $.confirmLinkButtonDelete('آیا حذف داده را تایید می کنید؟',a_href,	function () {$.msg('شما انصراف دادید',{header:'عدم تایید'});});  return false;" OnClick="Delete_Btn_Click" CommandArgument='<%#Eval("SlabId") %>' Text="حذف" />
                        </ItemTemplate> 
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
            <div class="col-md-12 col-12">
                <asp:Button runat="server" ID="Return_Btn" CssClass="bouton-contact" Text="بازگشت" OnClick="Return_Btn_Click" />
            </div>
        </asp:View>



        <asp:View runat="server" ID="ViewEdit">
            <div>
                <h2>ویرایش قطعات</h2>
            </div>
            <hr />
            <div class="contentform col-md-7 col-7 float-none m-auto ">
                <div id="sendmessage">Your message has been sent successfully. Thank you. </div>


                <div>
                    <div class="form-group">
                        <label>شماره قطعه : </label>
                        <span class="icon-case"><i class="fa fa-cogs"></i></span>
                        <asp:Label runat="server" Enabled="false" CssClass="SlabIdLabel" name="nom" ID="SlabIdEdit_Txt" data-rule="required"></asp:Label>
                        <div class="validation"></div>
                    </div>

                    <div class="form-group">
                        <label>نام قطعه:</label>
                        <span class="icon-case"><i class="fa fa-etsy"></i></span>
                        <asp:TextBox runat="server" ID="SlabNameEdit_Txt" name="prenom" data-rule="required" />
                        <div class="validation"></div>
                    </div>

                    <div class="form-group">
                        <label>نام فارسی قطعه :</label>
                        <span class="icon-case"><i class="fa fa-font"></i></span>
                        <asp:TextBox runat="server" type="text" name="ville" ID="PerSlabNameEdit_Txt" data-rule="required" />
                        <div class="validation"></div>
                    </div>


                    <div class="form-group">
                        <label>توضیحات :</label>
                        <span class="icon-case"><i class="fa fa-commenting"></i></span>
                        <asp:TextBox runat="server" name="Description" ID="SlabDescEdit_Txt" data-rule="maxlen:10" />
                        <div class="validation"></div>
                    </div>
                </div>
            </div>

         
            <div class="col-md-12 col-12">
                <asp:Button runat="server" ID="Edit_Btn" CssClass="bouton-contact" Text="ذخیره" OnClick="Edit_Btn_Click" />
            </div>
            
        </asp:View>
    </asp:MultiView>
</asp:Content>
