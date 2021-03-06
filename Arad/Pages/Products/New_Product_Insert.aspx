<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Pages/MasterPage/MasterPage.Master" CodeBehind="New_Product_Insert.aspx.vb" Inherits="Arad.New_Product_Insert" %>

<%@ Register Src="~/Components/File_Upload/File_Upload.ascx" TagPrefix="uc1" TagName="File_Upload" %>
<%@ Register Src="~/Components/Message/Message.ascx" TagPrefix="uc1" TagName="Message" %>
<%@ Register Src="~/Components/SlabId_Check/CheckSlabForProduct.ascx" TagPrefix="uc1" TagName="CheckSlabForProduct" %>



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
            border: 1px solid #cbcbcb;
            margin-bottom: 5px;
            width: 75%;
            height: 40px;
            float: left;
            padding: 0px 15px;
        }

        button,
        select {
            text-transform: none;
            /*// Remove the inheritance of text transform in Firefox width: 75%;*/
            height: 40px;
            float: left;
            padding: 0px 60px;
            border-radius: 5px 5px 5px 5px;
            border: 1px solid #9c9c9c80;
            margin: 1px 1px 1px 35px;
        }

        element.style {
            border: gainsboro 1px solid;
            font-size: 13px;
            width: 400px;
            vertical-align: middle;
            padding-top: 6px;
            color: navy;
            font-family: 'B Nazanin';
            height: 40px;
            margin-left: -10px;
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
            margin: 3.5px;
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

    <uc1:Message runat="server" ID="Message" />
    <asp:MultiView runat="server" ID="MultiView1">
        <asp:View runat="server" ID="NewProductSubmit">
            <div>

                <h2>تعریف محصول جدید</h2>
            </div>
            <hr />

            <div class="contentform col-md-7 col-7 float-none m-auto ">
                <div>
                    <div class="form-group">
                        <label>کد فنی محصول(شماره قطعه): </label>
                        <span class="icon-case"><i class="fa fa-cogs"></i></span>
                        <uc1:CheckSlabForProduct runat="server" id="SlabIdForProduct"  MaxLength="10"/>
                    </div>

                    <div class="form-group">
                        <label>نام تجاری محصول:</label>
                        <span class="icon-case"><i class="fa fa-etsy"></i></span>
                        <asp:TextBox runat="server" ID="ProductTradeName_Txt" name="prenom" data-rule="required" />
                    </div>

                    <div class="form-group">
                        <label>کد تجاری محصول:</label>
                        <span class="icon-case"><i class="fa fa-etsy"></i></span>
                        <asp:TextBox runat="server" ID="ProductTradeCode_Txt" name="prenom" data-rule="required" />
                    </div>

                    <div class="form-group">
                        <label>Service Manual :</label>
                        <span class="icon-case"><i class="fa fa-file-pdf-o"></i></span>
                        <uc1:File_Upload runat="server" ID="Service_Manual_File" />
                    </div>

                    <div class="form-group">
                        <label>User Manual :</label>
                        <span class="icon-case"><i class="fa fa-file-pdf-o"></i></span>
                        <uc1:File_Upload runat="server" ID="User_Manual_File" />
                    </div>

                    <div class="form-group">
                        <label>Catalog :</label>
                        <span class="icon-case"><i class="fa fa-file-pdf-o"></i></span>
                        <uc1:File_Upload runat="server" ID="Catalog_File" />
                    </div>

                    <div class="form-group">
                        <label>Tech File :</label>
                        <span class="icon-case"><i class="fa fa-file-pdf-o"></i></span>
                        <uc1:File_Upload runat="server" ID="Tech_File" />
                    </div>

                    <div class="form-group">
                        <label>بازنگری ها :</label>
                        <span class="icon-case"><i class="fa fa-file-pdf-o"></i></span>
                        <uc1:File_Upload runat="server" ID="Revision_File" />
                    </div>

                    <div class="form-group">
                        <label>تصدیق و صحه گذاری :</label>
                        <span class="icon-case"><i class="fa fa-file-pdf-o"></i></span>
                        <uc1:File_Upload runat="server" ID="Confirmation_File" />
                    </div>

                    <div class="form-group">
                        <label>راهنمای فروش :</label>
                        <span class="icon-case"><i class="fa fa-file-pdf-o"></i></span>
                        <uc1:File_Upload runat="server" ID="Sales_Guide_File" />
                    </div>


                    <div class="form-group">
                        <label>دفترچه ها :</label>
                        <span class="icon-case"><i class="fa fa-file-pdf-o"></i></span>
                        <uc1:File_Upload runat="server" ID="Booklets_File" />
                    </div>

                    <div class="form-group">
                        <label>فایل های مرتبط :</label>
                        <span class="icon-case"><i class="fa fa-file-pdf-o"></i></span>
                        <uc1:File_Upload runat="server" ID="Related_File" />
                    </div>

                </div>
            </div>

            <div class="col-md-12 col-12">
				<asp:Button runat="server" ID="Submit_Btn" CssClass="bouton-contact" Text="ثبت محصول" OnClick="Submit_Btn_Click" />
			</div>

        </asp:View>
    </asp:MultiView>



</asp:Content>
