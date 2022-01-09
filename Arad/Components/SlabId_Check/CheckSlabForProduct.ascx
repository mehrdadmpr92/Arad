<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CheckSlabForProduct.ascx.vb" Inherits="Arad.CheckSlabForProduct" %>

<table border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" onblur="upperCase_Code(this)" onfocus="Textbox_onfocus_Code(this)" AutoPostBack="True" onkeypress="keyDownNumber(this)" Style="text-align: left; direction: ltr;"></asp:TextBox></td>
        <td>&nbsp;&nbsp;</td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox1"
                ErrorMessage="وارد کردن این فیلد اجباری می باشد."></asp:RequiredFieldValidator></td>
    </tr>
</table>
<div id="DIV1" runat="server" style="width: 368px; direction: rtl; line-height: 22pt;">
    <asp:Label ID="Label1" runat="server" Text="نام فارسی:" ></asp:Label>
    <asp:Label ID="Label2" runat="server" ></asp:Label>
    <br />
    <asp:Label ID="Label3" runat="server" Text="نام قطعه:" SkinID="Lbl_Admin_grey"></asp:Label>
    <asp:Label ID="Label4" runat="server" ></asp:Label><br />
    <asp:Label ID="Label5" runat="server" Text="نوع قطعه: " ></asp:Label>
    <asp:Label ID="Label6" runat="server" ></asp:Label>
    <br />
    <asp:Label ID="Label7" runat="server" Text="کد مهندسی: " ></asp:Label>
    <asp:Label ID="Label8" runat="server" ></asp:Label>
</div>

<asp:Label ID="Alert_Label" runat="server" Style="font-size:10px; font-family:'B Nazanin'; line-height:16px; " ></asp:Label>