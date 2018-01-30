<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreManager.Master" AutoEventWireup="true" CodeBehind="SM_AddSupplier.aspx.cs" Inherits="Team09LogicU.Pages.SM_AddSupplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Add Supplier
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
  
    
     <div class="row">
                    <div class="col-lg-10">
                        <div class="card">
                            <div class="container">
                               <div class="col-lg-10" style="margin-top:20px;margin-bottom:20px;margin-left:-40px">

                             <div class="col-lg-4">
                                        <div class="form-group">
                            <label>SupplierCode</label>
                                
                                  <asp:TextBox ID="TextBox_SupplierCode" runat="server" Text="" class="form-control " Width="200px"></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                                <div class="col-lg-4">
                                         <div class="form-group">
                            <label>SupplierName </label>
                                
                                  <asp:TextBox ID="TextBox_SupplierName" runat="server" Text="" class="form-control " Width="200px"></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                            <div class="col-lg-4">
                                         <div class="form-group">
                            <label>GSTRegistrationNo</label>
                                
                                  <asp:TextBox ID="TextBox_GSTRegistrationNo" runat="server" Text="" class="form-control " Width="200px"></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                       <div class="col-lg-4">
                                         <div class="form-group">
                            <label>ContactName</label>
                                
                                  <asp:TextBox ID="TextBox_ContactName" runat="server" Text="" class="form-control " Width="200px"></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                                <div class="col-lg-4">
                                         <div class="form-group">
                               <label>Phone</label>
                                
                                  <asp:TextBox ID="TextBox_Phone" runat="server" Text="" class="form-control " Width="200px"></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>
                              
                                       <div class="col-lg-4">
                                         <div class="form-group">
                               <label>Fax</label>
                                
                                  <asp:TextBox ID="TextBox_Fax" runat="server" Text="" class="form-control " Width="200px"></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                           
                                                      <div class="col-lg-4">
                                         <div class="form-group">
                               <label>Address</label>
                                
                                  <asp:TextBox ID="TextBox_Address" runat="server" Text="" class="form-control " Width="400px" TextMode="MultiLine" style="resize:none"></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                        
                            </div> 
                              </div> 
                        </div> 
                    </div> 
                </div> 
            
    <div class="col-lg-10" style="margin-left:20px">
            <div class="col-lg-2">
                                  <asp:Button ID="Btn_Submit"  runat="server" Text="Submit" CssClass="btn btn-warning btn-fill btn-wd " OnClick="Btn_Submit_Click" /> 
                 </div>
        <div class="col-lg-2">
                                 <asp:Button ID="Btn_Back"  runat="server"  Text="Back"  CssClass="btn btn-default  btn-fill btn-wd" OnClick="Btn_Back_Click"   />
             </div>
        </div>
                               
</asp:Content>
