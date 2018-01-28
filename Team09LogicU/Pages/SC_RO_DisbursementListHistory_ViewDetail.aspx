<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_RO_DisbursementListHistory_ViewDetail.aspx.cs" Inherits="Team09LogicU.Pages.SC_RO_DisbursementListHistory_ViewDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
	
		<asp:GridView ID="disburseItem_HisGridView" runat="server"></asp:GridView>
		<asp:LinkButton ID="backButton" runat="server" Text="Button"  OnClick="backButton_Click"  />

</asp:Content>
