<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Employee.Master" AutoEventWireup="true" CodeBehind="Emp_Rep_SelectCollection.aspx.cs" Inherits="Team09LogicU.pages.Emp_Rep_SelectCollection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Select Collection
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
   
    <div class="row">
        <div class="col-lg-12">
            <div class="card">
                <div class="content">
                  
                    <div class="h4"><a class="btn btn-primary btn-simple" ><i class="fa fa-home" ></i></a>
                    <asp:Label ID="Label1" runat="server" Text="Current Collection Point: " BorderWidth="8px" BorderColor="White"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblCurrentCP" runat="server" Text="" CssClass="h5"></asp:Label>
                        </div>
     
     <div class=" category" style="margin-left:5%">
    <asp:Label ID="Label3" runat="server" Text="Select New Collection Point:"></asp:Label>
     <asp:DropDownList ID="ddlCP" runat="server"  CssClass="form-control border-gray" Width="20%"   > 
    </asp:DropDownList>
      </div><p>  
                        <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
                    </p>  
       <div style="margin-left:5%">
    <asp:Button ID="btnUpdateCP" runat="server" Text="Update Collection Point" CssClass="btn btn-primary btn-fill" OnClick="btnUpdateCP_Click" />   
          </div> 
             <p><br />
                    </p>         
           </div>
        </div></div>
    </div>
       
   
</asp:Content>
