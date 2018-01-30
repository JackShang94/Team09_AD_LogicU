<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreManager.Master" AutoEventWireup="true" CodeBehind="SM_AddCatalog.aspx.cs" Inherits="Team09LogicU.Pages.SM_AddCatalog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Add Catalog
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
   
        <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-12">
                        <div class="card">
                           
                            <div class="content">
                                    <div class="row">

                              <div class="col-md-12">
                                         <div class="form-group">
                            <label>Catagory Id </label>
                                
                                  <asp:TextBox ID="TextBox_CatagoryId" runat="server" class="form-control "  Width="200px"></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                                <div class="col-md-12">
                                         <div class="form-group">
                            <label>Category Name </label>
                                
                                  <asp:TextBox ID="TextBox_CategoryName" runat="server" class="form-control "  Width="500px"></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                                        <div class="col-md-12">
                                         <div class="form-group">
                            <label>Description </label>
                                
                                  <asp:TextBox ID="TextBox_Description" runat="server" class="form-control "  Width="383px" Height="158px" TextMode="MultiLine"></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                           



                        </div> 
                    </div> 
                </div> 
             </div> 

            </div> 

                                  <asp:Button ID="Btn_Submit"  runat="server" Text="Submit" CssClass="btn btn-primary btn-fill btn-wd " />
                                 <asp:Button ID="Btn_Back"  runat="server"  Text="Back"  CssClass="btn btn-default  btn-fill btn-wd"   />
                            
</asp:Content>
