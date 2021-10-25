<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Pages/MasterPage/MasterPage.Master" CodeBehind="Slab_Archive.aspx.vb" Inherits="Arad.Slab_Archive" Theme="Admin" %>

<%@ Register Src="~/Components/Message/Message.ascx" TagPrefix="uc1" TagName="Message" %>
<%@ Register Src="~/Components/File_Upload/File_Upload.ascx" TagPrefix="uc1" TagName="File_Upload" %>





<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


	<style>
		label {
			padding-right: 5px;
		}
	</style>

	<uc1:Message runat="server" ID="Message" />
	<asp:MultiView runat="server" ID="MultiView1">

		<asp:View runat="server" ID="ArchiveArchive">
			<div>
				<h3>آرشیو تمامی قطعات</h3>
			</div>
			<hr />

			<div>
				<asp:CheckBox ID="SlabType_Chk" runat="server" Text="نوع قطعه :" />
				<div class="col-11">
					<asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="SlabType_RBtn">
						<asp:ListItem Selected="True" Text="همه" Value="0"></asp:ListItem>
						<asp:ListItem Selected="False" Text="تولیدی" Value='1'></asp:ListItem>
						<asp:ListItem Selected="False" Text="خریدنی" Value='2'></asp:ListItem>
						<asp:ListItem Selected="False" Text="اسمبلی" Value='3'></asp:ListItem>
						<asp:ListItem Selected="False" Text="سفارشی" Value='4'></asp:ListItem>
						<asp:ListItem Selected="False" Text="مصرفی" Value='5'></asp:ListItem>
						<asp:ListItem Selected="False" Text="ابزار" Value='6'></asp:ListItem>
					</asp:RadioButtonList>
				</div>
				</div>

			<div>
				<div class="col-11">
					<asp:CheckBox ID="SlabId_Chk" runat="server" Text="شماره قطعه :" />
					<asp:TextBox runat="server" ID="SlabId_Txt"></asp:TextBox>
				</div>
			</div>
			<br />
			<asp:Button runat="server" Text="جستجو" ID="Search_Btn" OnClick="Search_Btn_Click" CssClass="btn btn-light" Width="80px" />
			<hr />



			<asp:GridView runat="server" ID="DG_Archive" SkinID="GV_Skin" Width="100%" AutoGenerateColumns="false" CssClass="text-center">

				<Columns>
					<asp:BoundField DataField="SlabId" HeaderText="شماره قطعه" />
					<asp:BoundField DataField="SlabName" HeaderText="نام قطعه" />
					<asp:BoundField DataField="SlabNameEng" HeaderText="نام فارسی قطعه" />
					<asp:BoundField DataField="SlabTypePer" HeaderText="نوع قطعه" />
					<asp:BoundField DataField="CodeMohandesi" HeaderText="کد مهندسی" />
					<asp:BoundField DataField="Description" HeaderText="توضیحات قطعه" />
					<%-- وضعیت قطعه --%>
				</Columns>
			</asp:GridView>
		</asp:View>




	</asp:MultiView>
</asp:Content>
