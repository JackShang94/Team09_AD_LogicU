<%@ Page Title="" Language="C#" MasterPageFile="~/pages/DepartmentHead.Master" AutoEventWireup="true" CodeBehind="DH_ChangeDepartmentRepresentative.aspx.cs" Inherits="Team09LogicU.pages.DH_ChangeDepartmentRepresentative" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        Change Department Representative
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
    <div class="row">
         <div class="col-lg-10">
        <div class="card">
                <div class=" container">
                <div class="col-lg-10" style="margin-top:20px">
                <asp:Label ID="lblDisplay1" runat="server" CssClass="category text-uppercase" Text="Current Representative:"></asp:Label>  
                    <br />                   
                <asp:Label ID="lblCurrentRep" runat="server" CssClass="h6" Text=""></asp:Label>
                 </div>
                          <div class="col-lg-3" style="margin-top:20px ">
                                         <asp:Label ID="lblDisplay2" runat="server"  CssClass=" category text-uppercase" Text="Select New Representative:" ></asp:Label>
                                        <br />
                                         <asp:DropDownList ID="ddlEmp" runat="server" CssClass="form-control" ></asp:DropDownList> 
                          </div>
                     <div class="col-lg-10" style="margin-top:20px;margin-bottom:20px">
                         <asp:Button ID="btnUpdateRep" runat="server" CssClass="btn btn-primary btn-wd btn-fill" Text="Update Rep" OnClick="btnUpdateRep_Click" />    
                    </div>

           </div>
          </div>
       </div>
    </div>
</asp:Content>
