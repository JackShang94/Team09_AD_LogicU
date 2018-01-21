<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreManager.Master" AutoEventWireup="true" CodeBehind="SM_EditItem.aspx.cs" Inherits="Team09LogicU.Pages.SM_EditItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Edit Item
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <form id ="form1" runat="server">
        <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-12">
                        <div class="card">
                           
                            <div class="content">
                                    <div class="row">

                              <div class="col-md-12">
                                         <div class="form-group">
                            <label>ItemNumber </label>
                                
                                  <asp:TextBox ID="TextBox_ItemNumber" runat="server" class="form-control "  Width="200px"></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                                <div class="col-md-12">
                                         <div class="form-group">
                            <label>Category</label>
                            <asp:dropdownlist ID="dropdownlist_Catagory" runat="server" class="form-control"  Width="200px"></asp:dropdownlist>
                             </div>
                              </div>

                              <div class="col-md-12">
                                         <div class="form-group">
                            <label>Description</label>
                                
                                  <asp:TextBox ID="TextBox_Description" runat="server" class="form-control " Width="200px"></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                        <div class="col-md-12">
                                         <div class="form-group">
                            <label>ReorderLevel </label>
                                
                                  <asp:TextBox ID="TextBox_ReorderLevel" runat="server" class="form-control " Width="200px"></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                               <div class="col-md-12">
                                         <div class="form-group">
                               <label>Reorder Qty </label>
                                
                                  <asp:TextBox ID="TextBox_ReorderQty" runat="server" class="form-control " Width="200px"></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>
                              
                                <div class="col-md-12">
                                         <div class="form-group">
                               <label>Unit of Measure</label>
                     <asp:dropdownlist ID="dropdownlist_unitofmeasure" runat="server" class="form-control"   Width="200px"></asp:dropdownlist>

                             </div>
                              </div>

                           <div class="col-md-12">
                                         <div class="form-group">
                               <label>Supplier1</label>
                     <asp:dropdownlist ID="dropdownlist_Supplier1" runat="server" class="form-control"   Width="200px"></asp:dropdownlist>

                             </div>
                              </div>
                                        <div class="col-md-12">
                                         <div class="form-group">
                               <label>Supplier2</label>
                     <asp:dropdownlist ID="dropdownlist_Supplier2" runat="server" class="form-control"   Width="200px"></asp:dropdownlist>

                             </div>
                              </div>

                        <div class="col-md-12">
                                         <div class="form-group">
                               <label>Supplier3</label>
                     <asp:dropdownlist ID="dropdownlist_Supplier3" runat="server" class="form-control"   Width="200px"></asp:dropdownlist>

                             </div>
                              </div>
                        
                            </div> 
                              </div> 
                        </div> 
                    </div> 
                </div> 
             </div> 

            </div> 

                                  <asp:Button ID="Btn_Update"  runat="server" Text="Update" CssClass="btn btn-primary btn-fill btn-wd " /> 
                                 <asp:Button ID="Btn_Back"  runat="server"  Text="Back"  CssClass="btn btn-default  btn-fill btn-wd"   />

                                 </form>
</asp:Content>
