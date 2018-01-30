<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreManager.Master" AutoEventWireup="true" CodeBehind="SM_ViewSupplierDetail.aspx.cs" Inherits="Team09LogicU.Pages.SM_ViewSupplierDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    View Supplier Detail
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
                            <label>SupplierCode (disabled)</label>
                                             <asp:Label ID="Label_SupplierCode" runat="server" Text="Label"></asp:Label>
                             
                             </div>
                              </div>

                                <div class="col-md-12">
                                         <div class="form-group">
                            <label>SupplierName </label>
                                
                               <asp:Label ID="Label_SupplierName" runat="server" Text="SupplierName"></asp:Label>
                             </div>
                              </div>

                              <div class="col-md-12">
                                         <div class="form-group">
                            <label>GSTRegistrationNo </label>
                                
                          
                                     <asp:Label ID="Label_GSTRegistrationNo" runat="server" Text="GSTRegistrationNo"></asp:Label>
                             </div>
                              </div>

                        <div class="col-md-12">
                                         <div class="form-group">
                            <label>ContactName</label>
                                 <asp:Label ID="Label_ContactName" runat="server" Text="ContactName"></asp:Label>
                              
                             </div>
                              </div>

                               <div class="col-md-12">
                                         <div class="form-group">
                               <label>Phone (disabled)</label>
                                <asp:Label ID="Label_Phone" runat="server" Text="Phone"></asp:Label>
                                  
                             </div>
                              </div>
                              
                                        <div class="col-md-12">
                                         <div class="form-group">
                               <label>Fax</label>
                                 <asp:Label ID="Label_Fax" runat="server" Text="Fax"></asp:Label>
                             </div>
                              </div>

                           
                                                      <div class="col-md-12">
                                         <div class="form-group">
                               <label>Address</label>
                                  <asp:Label ID="Label_Address" runat="server" Text="_Address"></asp:Label>
                               
                             </div>
                              </div>

                        
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
