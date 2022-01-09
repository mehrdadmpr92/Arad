<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Pages/MasterPage/MasterPage.Master" CodeBehind="Fixcher_Insert.aspx.vb" Inherits="Arad.Fixcher_Insert" %>

<%@ Register Src="~/Components/Validations/IntValidation.ascx" TagPrefix="uc1" TagName="IntValidation" %>
<%@ Register Src="~/Components/Message/Message.ascx" TagPrefix="uc1" TagName="Message" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Message runat="server" ID="Message" />
    <div>
        <h2>ثبت فیکسچر</h2>
    </div>
    <hr />

    <div class="contentform col-md-7 col-7 float-none m-auto ">

        <div>
            <div class="form-group">
                <label>فیکسچر : </label>
                <span class="icon-case"><i class="fa fa-cogs"></i></span>
                <asp:TextBox runat="server" ID="FixcherName_Txt" required="required"></asp:TextBox>

            </div>

            <div class="form-group">
                <label>کد فیکسچر:</label>
                <span class="icon-case"><i class="fa fa-etsy"></i></span>
                <asp:TextBox runat="server" ID="FixcherCode_Txt"  required="required"></asp:TextBox>

            </div>

            <div class="form-group">
                <label>تعداد مجاز :</label>
                <span class="icon-case"><i class="fa fa-font"></i></span>
                <uc1:IntValidation runat="server" ID="FixcherTedadMojaz_Txt" />
            </div>

        </div>
    </div>
    <div class="col-md-12 col-12">
        <asp:Button runat="server" ID="Submit_Btn" CssClass="bouton-contact" Text="ثبت" OnClick="Submit_Btn_Click" />
    </div>

</asp:Content>
