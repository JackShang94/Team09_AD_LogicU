<%@ Page Title="" Language="C#" MasterPageFile="~/pages/DepartmentHead.Master" AutoEventWireup="true" CodeBehind="DH_ChangeDepartmentRepresentative.aspx.cs" Inherits="Team09LogicU.pages.DH_ChangeDepartmentRepresentative" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        Change Department Representative
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <form runat="server">
    <asp:Label ID="lblDisplay1" runat="server" Text="Current Representative:"></asp:Label><br>
    <asp:Label ID="lblCurrentRep" runat="server" Text=""></asp:Label><br>
    <asp:Label ID="lblDisplay2" runat="server" Text="Select New Representative:"></asp:Label><br>
    <asp:DropDownList ID="ddlEmp" runat="server"></asp:DropDownList> <br>  
    <asp:Button ID="btnUpdateRep" runat="server" Text="Update Rep" OnClick="btnUpdateRep_Click" />      
        <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
    </form>
</asp:Content>
