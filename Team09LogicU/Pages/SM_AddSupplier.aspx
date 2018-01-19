<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreManager.Master" AutoEventWireup="true" CodeBehind="SM_AddSupplier.aspx.cs" Inherits="Team09LogicU.Pages.SM_AddSupplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Add Supplier
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
                            <label>SupplierCode</label>
                                
                                  <asp:TextBox ID="TextBox_SupplierCode" runat="server" Text=""></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                                <div class="col-md-12">
                                         <div class="form-group">
                            <label>SupplierName </label>
                                
                                  <asp:TextBox ID="TextBox_SupplierName" runat="server" Text=""></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                              <div class="col-md-12">
                                         <div class="form-group">
                            <label>GSTRegistrationNo</label>
                                
                                  <asp:TextBox ID="TextBox_GSTRegistrationNo" runat="server" Text=""></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                        <div class="col-md-12">
                                         <div class="form-group">
                            <label>ContactName</label>
                                
                                  <asp:TextBox ID="TextBox_ContactName" runat="server" Text=""></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                               <div class="col-md-12">
                                         <div class="form-group">
                               <label>Phone</label>
                                
                                  <asp:TextBox ID="TextBox_Phone" runat="server" Text=""></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>
                              
                                        <div class="col-md-12">
                                         <div class="form-group">
                               <label>Fax</label>
                                
                                  <asp:TextBox ID="TextBox_Fax" runat="server" Text=""></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                           
                                                      <div class="col-md-12">
                                         <div class="form-group">
                               <label>Address</label>
                                
                                  <asp:TextBox ID="TextBox_Address" runat="server" Text=""></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                        
                            </div> 
                              </div> 
                        </div> 
                    </div> 
                </div> 
             </div> 

            </div> 

                                  <asp:Button ID="Btn_Submit"  runat="server" Text="Submit" CssClass="btn btn-primary btn-fill btn-wd " OnClick="Btn_Submit_Click" /> 
                                 <asp:Button ID="Btn_Clear"  runat="server"  Text="Clear"  CssClass="btn btn-default  btn-fill btn-wd" OnClick="Btn_Clear_Click"   />

                                 </form>

</asp:Content>
