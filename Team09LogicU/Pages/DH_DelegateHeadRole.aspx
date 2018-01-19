<%@ Page Title="" Language="C#" MasterPageFile="~/pages/DepartmentHead.Master" AutoEventWireup="true" CodeBehind="DH_DelegateHeadRole.aspx.cs" Inherits="Team09LogicU.pages.DH_DelegateHeadRole" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Delegate Head Role
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <form runat="server">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
         <h3>Delegate to: <asp:Label ID="delegateStf_label" runat="server" Text="Label"></asp:Label></h3> 
  Employee:  <asp:DropDownList ID="employee_dropList" runat="server"></asp:DropDownList>
  From:      
         <asp:TextBox ID="textBox_startDate" runat="server" TextMode="Date"></asp:TextBox>
  To:        
         <asp:TextBox ID="textBox_endDate" runat="server" TextMode="Date"></asp:TextBox>
            
            <br /> <asp:Button ID="submit_button" runat="server" Text="SUBMIT" OnClick="submit_button_Click" />
         
         <asp:Label ID="delegateStatus_Label" runat="server" Text="Label"></asp:Label>
         
    <br />
    <h3>Delegate History</h3> 
        <asp:ListBox ID="ListBox_delegateHistory" runat="server"></asp:ListBox>
        <br />
         <asp:Button ID="terminate_button" runat="server" Text="TERMINATE" OnClick="terminate_button_Click" />
        <asp:Label ID="label_terminateDlgt" runat="server" Text="Label"></asp:Label>
    </form>
    
</asp:Content>
