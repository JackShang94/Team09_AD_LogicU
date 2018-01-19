<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreManager.Master" AutoEventWireup="true" CodeBehind="SM_AddItem.aspx.cs" Inherits="Team09LogicU.Pages.SM_AddItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Add Item
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
                                
                                  <asp:TextBox ID="TextBox_ItemNumber" runat="server" Text="13134 "></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                                <div class="col-md-12">
                                         <div class="form-group">
                            <label>Category</label>
                                
                                  <asp:TextBox ID="TextBox_Category" runat="server" Text="13134 "></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                              <div class="col-md-12">
                                         <div class="form-group">
                            <label>Description (disabled)</label>
                                
                                  <asp:TextBox ID="TextBox_Description" runat="server" Text="13134 "></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                        <div class="col-md-12">
                                         <div class="form-group">
                            <label>ReorderLevel </label>
                                
                                  <asp:TextBox ID="TextBox_ReorderLevel" runat="server" Text="13134 "></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>

                               <div class="col-md-12">
                                         <div class="form-group">
                               <label>Reorder Qty </label>
                                
                                  <asp:TextBox ID="TextBox_ReorderQty" runat="server" Text="13134 "></asp:TextBox> <%-- value=""--%>
                             </div>
                              </div>
                              
                                        <div class="col-md-12">
                                         <div class="form-group">
                               <label>Unit of Measure</label>
                                
                                  <asp:TextBox ID="TextBox_UnitofMeasure" runat="server" Text="13134 "></asp:TextBox> <%-- value=""--%>
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

                                 </form>

</asp:Content>
