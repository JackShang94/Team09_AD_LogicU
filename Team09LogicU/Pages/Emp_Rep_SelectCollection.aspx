<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Employee.Master" AutoEventWireup="true" CodeBehind="Emp_Rep_SelectCollection.aspx.cs" Inherits="Team09LogicU.pages.Emp_Rep_SelectCollection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Select Collection
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <form runat="server">
    <asp:Label ID="Label1" runat="server" Text="Current Collection Point: "></asp:Label>
    <asp:Label ID="lblCurrentCP" runat="server" Text=""></asp:Label><br>
    <asp:Label ID="Label3" runat="server" Text="Select New Collection Point:"></asp:Label><br>
    <asp:DropDownList ID="ddlCP" runat="server"></asp:DropDownList> <br>  
    <asp:Button ID="btnUpdateCP" runat="server" Text="Update Collection Point" OnClick="btnUpdateCP_Click" />      
    </form>
</asp:Content>
