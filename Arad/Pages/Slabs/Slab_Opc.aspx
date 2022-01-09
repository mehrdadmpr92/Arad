<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Pages/MasterPage/MasterPage.Master" CodeBehind="Slab_Opc.aspx.vb" Inherits="Arad.Slab_Opc" Theme="Admin"%>

<%@ Register Src="~/Components/Message/Message.ascx" TagPrefix="uc1" TagName="Message" %>
<%@ Register Src="~/Components/SlabId_Check/CheckSlabCode.ascx" TagPrefix="uc1" TagName="CheckSlabCode" %>
<%@ Register Src="~/Components/Validations/IntValidation.ascx" TagPrefix="uc1" TagName="IntValidation" %>




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
        <asp:View runat="server" ID="OpcSubmit_check">

            <div>

                <h2>مراحل ساخت قطعه</h2>
            </div>
            <hr />

            <div class="contentform col-md-7 col-7 float-none m-auto">

                <div id="sendmessage">Your message has been sent successfully. Thank you. </div>

                <div>
                    <div class="form-group">
                        <label>شماره قطعه : </label>
                        <span class="icon-case"><i class="fa fa-cogs"></i></span>

                        <uc1:CheckSlabCode runat="server" ID="SlabId_Txt" MaxLength="10" />
                    </div>


                    <div class="col-md-12 col-12">
                        <asp:Button runat="server" ID="Continue_Btn" CssClass="bouton-contact" Text="ادامه" OnClick="Continue_Btn_Click" />
                    </div>
                </div>
            </div>
        </asp:View>





        <asp:View runat="server" ID="OpcSubmit">

            <div>
                <h2>مراحل ساخت قطعه</h2>
            </div>
            <hr />
            <div class="form-group">
                <label>شماره ردیف:</label>
                <span class="icon-case"><i class="fa fa-etsy"></i></span>
                <asp:TextBox runat="server" ID="OPCRow" name="prenom" data-rule="required" />
                
      

                <div class="validation"></div>
            </div>
            <div class="form-group">
                <label>عنوان عملیات :</label>
                <%--<span class="icon-case"><i class="fa fa-cog"></i></span>
                <asp:TextBox runat="server" ID="OperationTitle_Txt" AutoPostBack="true"></asp:TextBox>--%>
                <asp:DropDownList runat="server" ID="OperationTitle_DD" ></asp:DropDownList>

                <div class="validation"></div>
            </div>

            <div class="form-group">
                <label>شرح عملیات :</label>
                <span class="icon-case"><i class="fa fa-commenting"></i></span>
                <asp:TextBox runat="server" name="OpcDescription" ID="OpcDesc_Txt"  ValidationGroup="Sub1" />
                <div class="validation"></div>
            </div>


            <div class="form-group">
                <label>ابزار :</label>
                <span class="icon-case"><i class="fa fa-font"></i></span>
                <asp:TextBox runat="server" type="text" name="ville" ID="Tools_Txt"  />
                <div class="validation"></div>
            </div>
            <div class="form-group">
                <label>فیکسچر :</label>
                <span class="icon-case"><i class="fa fa-font"></i></span>
                <asp:TextBox runat="server" type="text" name="ville" ID="Fixcher" AutoPostBack="true" />
                <div style="color:red; font-size:12px;">
                    <asp:Label runat="server" id ="Fixcher_Validation_Lbl" Visible="false"></asp:Label>
                </div>
            </div>


            <div class="form-group">
                <label>تعرفه کارگری :</label>
                <span class="icon-case"><i class="fa fa-caret-down"></i></span>
                <asp:TextBox runat="server" type="text" name="ville" ID="TarefehWorker_Txt" data-rule="required"  ValidationGroup="Sub1"/>
            </div>

            <div class="form-group">
                <label>تعدادکارگر :</label>
                <span class="icon-case"><i class="fa fa-caret-down"></i></span>
                <asp:TextBox runat="server" type="text" name="ville" ID="NumWorker_Txt" data-rule="required"  ValidationGroup="Sub1"/>
                <div class="validation"></div>
            </div>

            <div class="form-group">
                <label>زمان تنظیم :</label>
                <span class="icon-case"><i class="fa fa-caret-down"></i></span>
                <asp:TextBox runat="server" type="text" name="ville" ID="TanzimTime_Txt" data-rule="required"  ValidationGroup="Sub1"/>
                <div class="validation"></div>
            </div>

            <div class="form-group">
                <label>زمان قطعه :</label>
                <span class="icon-case"><i class="fa fa-caret-down"></i></span>
                <asp:TextBox runat="server" type="text" name="ville" ID="SlabTime_Txt" data-rule="required" ValidationGroup="Sub1"  />
                <div class="validation"></div>
            </div>

            <asp:Button CssClass="btn btn-light mb-1" runat="server" ID="addToList" Text="افزودن به لیست" OnClick="addToList_Click" />

            <asp:GridView ID="OPCList_GV" runat="server" SkinID="GV_Skin" AutoGenerateColumns="false">

                <Columns>
                    <asp:BoundField DataField="RowNo" HeaderText="شماره ردیف" />
					<asp:BoundField DataField="OperationTitle" HeaderText="عنوان عملیات" />
					<asp:BoundField DataField="OperationDesc" HeaderText="شرح عملیات" />
                    <asp:BoundField DataField="Tools" HeaderText="ابزار" />
					<asp:BoundField DataField="FixcherName" HeaderText="فیکسچر" />
					<asp:BoundField DataField="TarefeWorker" HeaderText="تعرفه کارگری" />
					<asp:BoundField DataField="NumWorker" HeaderText="تعداد کارگر" />
                    <asp:BoundField DataField="TanzimTime" HeaderText="زمان تنظیم" />
                    <asp:BoundField DataField="SlabTime" HeaderText="زمان قطعه" />

                    <asp:TemplateField HeaderText="ویرایش">
                        <ItemTemplate>
                            <asp:LinkButton ID="Delete_LBtn" runat="server" CommandArgument='<%#Eval("SlabOpcSubId") %>' Font-Underline="false"
                                OnClick="Delete_LBtn_Click">حذف</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>

            </asp:GridView>

            <div class="col-md-12 col-12">
                <asp:Button runat="server" ID="OPCSubmit_Btn" CssClass="bouton-contact" Text="ثبت نهایی" OnClick="OPCSubmit_Btn_Click" ValidationGroup="Sub" />
            </div>

        </asp:View>
    </asp:MultiView>



</asp:Content>
