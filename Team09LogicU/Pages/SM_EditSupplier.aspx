<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreManager.Master" AutoEventWireup="true" CodeBehind="SM_EditSupplier.aspx.cs" Inherits="Team09LogicU.Pages.SM_EditSupplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Edit Supplier
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
   
        
          <div class="row">
                    <div class="col-lg-10">
                        <div class="card">

                            <div class="content">
                                <div class="row">

                              <div class="col-lg-4">
                                        <div class="form-group">
                            <label>SupplierCode</label>
                                
                                  <asp:TextBox ID="TextBox_SupplierCode" class="form-control disabled" runat="server" ReadOnly="True" Width="200px" ></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                             <div class="col-lg-4">
                                         <div class="form-group">
                            <label>SupplierName</label>
                                
                                  <asp:TextBox ID="TextBox_SupplierName" class="form-control disabled" runat="server" ReadOnly="True"  Width="200px" ></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                               <div class="col-lg-4">
                                         <div class="form-group">
                            <label>GSTRegistrationNo</label>
                                
                                  <asp:TextBox ID="TextBox_GSTRegistrationNo"  class="form-control"  runat="server" Width="200px" ></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                           <div class="col-lg-4">
                                         <div class="form-group">
                            <label>ContactName</label>
                                
                                  <asp:TextBox ID="TextBox_ContactName" class="form-control" runat="server"  Width="200px" ></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                                <div class="col-lg-4">
                                         <div class="form-group">
                               <label>Phone</label>
                                
                                  <asp:TextBox ID="TextBox_Phone" class="form-control" runat="server" Width="200px" ></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>
                              
                                           <div class="col-lg-4">
                                         <div class="form-group">
                               <label>Fax </label>
                                
                                  <asp:TextBox ID="TextBox_Fax" class="form-control" runat="server" Width="200px" ></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                           
                                                        <div class="col-lg-6">
                                         <div class="form-group">
                               <label>Address</label>
                                
                                  <asp:TextBox ID="TextBox_Address" runat="server" class="form-control"  TextMode="MultiLine"   style="resize:none"></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                        
                            </div> 
                              </div> 
                        </div> 
                    </div> 
                </div> 
        
                                  <asp:Button ID="Btn_Submit"  runat="server" Text="Submit" CssClass="btn btn-warning btn-fill btn-wd " OnClick="Btn_Submit_Click" /> 
                                 <asp:Button ID="Btn_Back"  runat="server"  Text="Back"  CssClass="btn btn-default  btn-fill btn-wd" OnClick="Btn_Back_Click"   />

                               
</asp:Content>
