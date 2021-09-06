<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="File_Upload.ascx.vb" Inherits="Arad.File_Upload" %>

<table border="0" cellpadding="0" cellspacing="0" style="direction: rtl; text-align: right; display: inline; vertical-align: top; padding-right: 5%;">
	<tr>
		<td style="height: 22px;">
			<input id="File1" runat="server" type="file"
				style="border: gainsboro 1px solid; font-size: 13px; width: 415px; vertical-align: middle; padding-top: 6px; color: navy; font-family: 'B Nazanin'; height: 40px; margin-left: -10px;" />
		</td>

		<td colspan="2" style="height: 22px">&nbsp; &nbsp;
			<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="File1"
				ErrorMessage="وارد کردن این فیلد الزامی می باشد." SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
		</td>
	</tr>

	<tr>
		<td colspan="3">
			<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="File1"
				ErrorMessage="شما فقط می توانید فایل هایی با پسوندهایی pdf , doc , docx , zip , rar , png , jpg وارد نمایید."
				SetFocusOnError="true" Style="font-size: 8px; color: red; font-family: 'B Nazanin';" Display="Dynamic"
				ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.zip|.rar|.doc|.docs|.pdf|.jpg|.png)$"></asp:RegularExpressionValidator>
		</td>
	</tr>

</table>

<asp:HyperLink ID="HyperLink1" Visible="false" Target="_blank" runat="server">HyperLink`</asp:HyperLink>