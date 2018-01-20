<%@ Page Title="" Language="C#" MasterPageFile="~/pages/DepartmentHead.Master" AutoEventWireup="true" CodeBehind="DH_ChangeDepartmentRepresentative.aspx.cs" Inherits="Team09LogicU.pages.DH_ChangeDepartmentRepresentative" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        Change Department Representative
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div class="row">
        <div class="col-lg-12">
            <div class="card">
                <div class="content">
    <form runat="server">
         <div class="col-lg-12">
    <asp:Label ID="lblDisplay1" runat="server" CssClass="h4" Text="Current Representative:"></asp:Label>
    <asp:Label ID="lblCurrentRep" runat="server" CssClass="h5" Text=""></asp:Label></div>
     <br>
     
    <asp:Label ID="lblDisplay2" runat="server"  CssClass=" category" Text="Select New Representative:" ></asp:Label><br>
    <asp:DropDownList ID="ddlEmp" runat="server" CssClass="form-control" Width="40%"></asp:DropDownList> <br>  
    <asp:Button ID="btnUpdateRep" runat="server" CssClass="btn btn-primary btn-wd btn-fill" Text="Update Rep" OnClick="btnUpdateRep_Click" />      
        <asp:Label ID="lblMessage" runat="server" Text=" "></asp:Label>
      
    </form>
                    </div>
                </div>
            </div>
         </div>
</asp:Content>
