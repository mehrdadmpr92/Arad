<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Pages/MasterPage/MasterPage.Master" CodeBehind="Slab_Archive.aspx.vb" Inherits="Arad.Slab_Archive" %>

<%@ Register Src="~/Components/Message/Message.ascx" TagPrefix="uc1" TagName="Message" %>
<%@ Register Src="~/Components/File_Upload/File_Upload.ascx" TagPrefix="uc1" TagName="File_Upload" %>





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

	<uc1:Message runat="server" ID="Message" />
	<asp:MultiView runat="server" ID="MultiView1">

		<asp:View runat="server" ID="ArchiveArchive">
			<div>
				<h2>آرشیو تمامی قطعات</h2>
			</div>
			<hr />

			<asp:GridView runat="server" ID="DG_Archive" SkinID="GV_Skin" Width="100%" AutoGenerateColumns="false">

				<Columns>
					<asp:BoundField DataField="SlabId" HeaderText="شماره قطعه" />
					<asp:BoundField DataField="SlabName" HeaderText="نام قطعه" />
					<asp:BoundField DataField="SlabNameEng" HeaderText="نام فارسی قطعه" />
					<asp:BoundField DataField="Description" HeaderText="توضیحات قطعه" />

					<asp:TemplateField HeaderText="ابزار">
						<ItemTemplate>
							<asp:LinkButton runat="server" ID="LbtEdit_Click" CssClass="btn btn-link"
								OnClick="LbtEdit_Click_Click" CommandArgument='Eval("SlabId")'>ویرایش</asp:LinkButton>

							<asp:LinkButton runat="server" ID="Delete_Btn" OnClientClick="var a_href = $(this).attr('href'); $.confirmLinkButtonDelete('آیا حذف داده را تایید می کنید؟',a_href,	function () {$.msg('شما انصراف دادید',{header:'عدم تایید'});});  return false;" OnClick="Delete_Btn_Click" CommandArgument='Eval("SlabId")' Text="حذف" />
						</ItemTemplate>
					</asp:TemplateField>

				</Columns>
			</asp:GridView>
			<div class="col-md-12 col-12">
				<asp:Button runat="server" ID="Return_Btn" CssClass="bouton-contact" Text="بازگشت" OnClick="Return_Btn_Click" />
			</div>
		</asp:View>




	</asp:MultiView>
</asp:Content>
