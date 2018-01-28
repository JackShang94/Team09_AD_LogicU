<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreManager.Master" AutoEventWireup="true" CodeBehind="SM_EditSupplier.aspx.cs" Inherits="Team09LogicU.Pages.SM_EditSupplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Edit Supplier
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
   
         <asp:Label ID="Label1" runat="server" Text="Label_test"></asp:Label>
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
                                
                                  <asp:TextBox ID="TextBox_SupplierCode" runat="server" ReadOnly="True" ></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                                <div class="col-md-12">
                                         <div class="form-group">
                            <label>SupplierName</label>
                                
                                  <asp:TextBox ID="TextBox_SupplierName" runat="server" ReadOnly="True" ></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                              <div class="col-md-12">
                                         <div class="form-group">
                            <label>GSTRegistrationNo</label>
                                
                                  <asp:TextBox ID="TextBox_GSTRegistrationNo" runat="server" ></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                        <div class="col-md-12">
                                         <div class="form-group">
                            <label>ContactName</label>
                                
                                  <asp:TextBox ID="TextBox_ContactName" runat="server" ></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                               <div class="col-md-12">
                                         <div class="form-group">
                               <label>Phone</label>
                                
                                  <asp:TextBox ID="TextBox_Phone" runat="server" ></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>
                              
                                        <div class="col-md-12">
                                         <div class="form-group">
                               <label>Fax </label>
                                
                                  <asp:TextBox ID="TextBox_Fax" runat="server" ></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                           
                                                      <div class="col-md-12">
                                         <div class="form-group">
                               <label>Address</label>
                                
                                  <asp:TextBox ID="TextBox_Address" runat="server"  TextMode="MultiLine"></asp:TextBox> <%-- value=""--%>
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
                                 <asp:Button ID="Btn_Back"  runat="server"  Text="Back"  CssClass="btn btn-default  btn-fill btn-wd" OnClick="Btn_Back_Click"   />

                               
</asp:Content>
