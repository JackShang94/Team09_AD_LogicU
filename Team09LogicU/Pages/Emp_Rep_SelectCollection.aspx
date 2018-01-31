<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Employee.Master" AutoEventWireup="true" CodeBehind="Emp_Rep_SelectCollection.aspx.cs" Inherits="Team09LogicU.pages.Emp_Rep_SelectCollection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Select Collection
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
   
      <div class="row">
                        <div class="col-lg-10">
							<div class="card">
								 <div class=" container" >
                  
                    <div class=" col-lg-10" style="margin:20px 0 20px 0">
                    <asp:Label ID="Label1" runat="server" Text="Current Collection Point: " CssClass="category"></asp:Label>
                      <br />
                        <asp:Label ID="lblCurrentCP" runat="server" Text="" CssClass="h5"></asp:Label>
                        </div>
     
     <div class=" col-lg-3 category" style="margin:20px 0 20px 0">
    <asp:Label ID="Label3" CssClass="category" runat="server" Text="Select New Collection Point:"></asp:Label>
     <asp:DropDownList ID="ddlCP" runat="server"  CssClass="form-control "   > 
    </asp:DropDownList>
      </div>
        </div>
        </div></div>
    </div>
   
         <asp:Button ID="btnUpdateCP" runat="server" Text="Update Collection Point" CssClass="btn btn-primary btn-fill" OnClick="btnUpdateCP_Click" />   
       
   
</asp:Content>
