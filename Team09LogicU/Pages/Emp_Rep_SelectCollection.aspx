<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Employee.Master" AutoEventWireup="true" CodeBehind="Emp_Rep_SelectCollection.aspx.cs" Inherits="Team09LogicU.pages.Emp_Rep_SelectCollection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Select Collection
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
    <form id="form1" runat="server">
        <div class="row">
              <div class="col-md-8 container-fluid">
                        <div class="card">
                        <div class="content" >
                            <h4 class="title">Select and Update Collection Point:</h4>
                                <p class="category">Current Colletction Point: Collection Point2</p>
                            </div> 
                             <div class="content" >
                            
                                <p class="category" style="color:red">Any change made after on .....</p>
                                 
                            </div> 
                            <asp:Button ID="Button1" runat="server" Text="Button" />
                            </div>
                  </div>

        </div>
        
    </form>
    
</asp:Content>
