<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="FileUpload.ascx.vb" Inherits="Arad.FileUpload" %>
<table border="0" cellpadding="0" cellspacing="0" style="direction: rtl; text-align: right">
    <tr>
        <td style="height: 22px">
            <input id="File1" runat="server" style="border-right: gainsboro 1px solid; border-top: gainsboro 1px solid; font-size: 8pt; border-left: gainsboro 1px solid; width: 275px; color: olive; border-bottom: gainsboro 1px solid; font-family: tahoma; height: 20px"
                type="file" />&nbsp;
            <asp:LinkButton ID="Lbtn_Upload_Movaggat" runat="server" Font-Underline="False" Visible="False">آپلود موقت</asp:LinkButton>
            <asp:LinkButton ID="Lbtn_New_UP" runat="server" Font-Underline="False" Visible="False">انتخاب مجدد فایل</asp:LinkButton>
            <asp:LinkButton ID="Lbt_Sho_File" runat="server" Font-Underline="False" Visible="False">نمایش فایل</asp:LinkButton>&nbsp;
        </td>
        <td colspan="2" style="height: 22px">&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="File1"
                ErrorMessage="وارد کردن این بخش الزامی می باشد" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;</td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="File1"
                ErrorMessage="شما فقط قادر هستید فایلهایی با پسوند pdf,doc,docx,zip,rar,png,jpg ارسال نمائید!"
                SetFocusOnError="True" Style="font-size: 8pt; color: #3399ff; font-family: tahoma"
                ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.zip|.rar|.doc|.docs|.pdf|.jpg|.png)$" Visible="False"></asp:RegularExpressionValidator></td>
    </tr>

</table>
<asp:HyperLink ID="HyperLink1" Visible="false" Target="_blank" runat="server">HyperLink</asp:HyperLink>