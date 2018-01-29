<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_Inv_AdjustmentVoucher.aspx.cs" Inherits="Team09LogicU.Pages.SC_Inv_AdjustmentVoucher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
Adjustment Voucher
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

     
      
                      <div class="row">
                    <div class="col-md-9 container-fluid">
                        <div class="card">
                        <div class="content" >
                            <div class=" form-group" style="height: 50px; width: 100%">
                                <div class="pull-left search" style="width: 75%">
                                    <div class="col-lg-3" style="margin-top: 20px; margin-bottom: 20px">
                                        <asp:Label ID="Label3" runat="server" CssClass="category" Text=" Category:"></asp:Label>
                                        <asp:DropDownList ID="DropDownList_cat" runat="server" CssClass="form-control" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_cat_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>


                            </div>
                        </div>
                        </div>
                         </div>
                      </div>
   

    <div class="content">
            <div class="container-fluid">       
                <div class="content">
                <div class="row">
                    <div class="col-lg-12">
                            <div class="content">
                                  <asp:ScriptManager ID="ScriptManager1" runat="server">                 
                                       </asp:ScriptManager>
                                  <asp:UpdatePanel ID="catalogueUpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="True" EnableViewState="True">
                                      <ContentTemplate>
                                      <div>
                                  <div class="container-fluid">							
                            <%-- <asp:LinkButton ID="LinkButton_ViewAllADJvoucherList" runat="server" Text="ViewADJList">LinkButton</asp:LinkButton>--%>
                          <%--  <asp:label ID="label" runat="server" text="Label"></asp:label>--%>
                                   
                                      <asp:GridView ID="GridView_CatalogList" OnRowCommand =" GridView_CatalogList_RowCommand" runat="server" CssClass="table bootstrap-table table-hover table-striped" HeaderStyle-CssClass=" content text-uppercase  " AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"  EmptyDataText="There are no Item" AllowPaging="True"  >      
                                                <Columns>
                                                    <asp:BoundField DataField="itemID" HeaderText="item ID:" />
                                                    <asp:BoundField DataField="categoryID" HeaderText="categoryID:" />
                                                    <asp:BoundField DataField="description" HeaderText="description:" />
                                                    <asp:BoundField DataField="unitOfMeasure" HeaderText="unit Of Measure:" />
                                                     <asp:TemplateField HeaderText="Action" ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton_Add" runat="server" CausesValidation="False" Text="Add"  CommandName="Add"  CommandArgument='<%# Eval("itemID") %>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                               <%-- <HeaderStyle CssClass=" content text-uppercase"></HeaderStyle>--%>
                                            </asp:GridView>
                                            
        				        </div>  
                                 </div>
                                          </ContentTemplate>
                                        </asp:UpdatePanel>
                            </div><!-- end content-->
                    </div> <!-- end col-md-12 -->
                </div> <!-- end row -->
            </div>
        </div>                          

    </div>

          <div class="col-lg-4">
                         <div class="card">
                           <div class="text-center">
                               <div class ="content">
                                   <asp:Button ID="Submit" runat="server" Text="Checkout" OnClick="Submit_Click" EnableViewState="False" />
                               </div>
                               <div class="content">
                                   
                                    <asp:UpdatePanel ID="cartUpdatePanel" runat="server" UpdateMode="Conditional" ViewStateMode="Inherit" EnableViewState="False">
                                        <ContentTemplate>
                                              <asp:Repeater ID="cartRepeater" runat="server" OnItemCommand="cartRepeater_ItemCommand" ViewStateMode="Disabled" >
                                                <HeaderTemplate>
													   <table class="table">
																				<tr class="category">
																				<td></td>
                                    											<td>ItemID</td>
                                    											<td>Amount</td>
                                                                                <td>Record</td>
																				<td class="text-right">Action</td>
																			</tr>
                                                   </HeaderTemplate>
                                                   <ItemTemplate>
                                                                        <tr>
                                                                            <td></td>
                                    	                                    <td>   <%#Eval("itemID") %></td>
                                    	                                    <td class="text-center" style="width:30%">
                                                                                <asp:TextBox ID="cart_qtyTextBox" runat="server"  CssClass=" form-control"  Text='<%#Eval("Qty") %>' >                                                                              
                                                                                </asp:TextBox> </td>
                                                                              <asp:RegularExpressionValidator runat="server" ControlToValidate="cart_qtyTextBox" ValidationExpression="^[1-9]\d*|0$" ErrorMessage="Invalid quantity!!"></asp:RegularExpressionValidator>
                                    	                                    
                                                                             <td class="text-center" style="width:30%">
                                                                              <asp:TextBox ID="cart_recordTextBox" runat="server"  CssClass=" form-control"  Text='<%#Eval("Record") %>' >
                                                                                    
                                                                              </asp:TextBox>
                                    	                                    </td>
                                                                            <td class="td-actions text-right" style="">
                                                                                <asp:LinkButton ID="cart_deleteButton" runat="server" Text="delete"  CssClass=" fa fa-times"  OnClick="cart_deleteBtn_Click"  CommandName="delete" CommandArgument='<%# Eval("itemID") %>' ></asp:LinkButton>
                                                                        <%--   <i class="fa fa-times"></i>--%>
                                                                            </td>
                                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                                        
                                                                    </table>
                                                    </FooterTemplate> 
                                                 </asp:Repeater>
                                            
                                            </ContentTemplate>
                                           
                                        </asp:UpdatePanel>              
                               </div>
                             </div>
                         </div>
                     </div>       
</asp:Content>
