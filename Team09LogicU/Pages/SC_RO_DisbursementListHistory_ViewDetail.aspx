<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_RO_DisbursementListHistory_ViewDetail.aspx.cs" Inherits="Team09LogicU.Pages.SC_RO_DisbursementListHistory_ViewDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 View Detail
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
	  <div class="row">
         <div class="col-lg-10">
        <div class="card">
                <div class=" container">
                    <div class="col-lg-10" style="margin:20px 0 20px 0">
		<asp:GridView ID="disburseItem_HisGridView" runat="server"></asp:GridView>
                        </div>
                    
                    </div></div></div></div>
    <div class="col-lg-10" style="margin-top:20px">
		<asp:LinkButton ID="backButton" runat="server" Text="Button" CssClass="btn btn-wd btn-default" OnClick="backButton_Click"  />
                        </div>

</asp:Content>
