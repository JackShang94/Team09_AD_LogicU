<%@ Page Title="" Language="C#" MasterPageFile="~/pages/DepartmentHead.Master" AutoEventWireup="true" CodeBehind="DH_ChangeDeptRep.aspx.cs" Inherits="Team09LogicU.pages.DH_ChangeDepartmentRepresentative" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        Change Department Representative
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <form runat="server">
    <asp:Label ID="Label1" runat="server" Text="Current Representative:"></asp:Label><br>
    <asp:TextBox ID="txtCurrentRep" runat="server"></asp:TextBox><br>
    <asp:Label ID="Label2" runat="server" Text="Select New Representative:"></asp:Label><br>
    <asp:DropDownList ID="DropDownList_Emp" runat="server"></asp:DropDownList> <br>       
    </form>
</asp:Content>
