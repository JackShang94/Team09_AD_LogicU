<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Employee.Master" AutoEventWireup="true" CodeBehind="Emp_SubmitRequisition.aspx.cs" Inherits="Team09LogicU.pages.Emp_SubmitRequisition"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 Submit Requisition
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
         <div class="row">
                   
                    <div class="col-md-8 container-fluid">
                        <div class="card">
                            <div class="content" >
                                <div class=" form-group" style="height:25px; width:100%">
                                    <div class="pull-left search" style="width:75%">
                                    <asp:TextBox ID="item_searchText" runat="server" CssClass="form-control" PlaceHolder="Search By Item Description"></asp:TextBox>
                                    </div>
                                    <div class="pull-right" >
                                     <asp:Button ID="item_searchBtn" runat="server"  Text="Search"  CssClass="btn btn-wd btn-primary" OnClick="item_searchBtn_Click" EnableViewState="False" ViewStateMode="Inherit" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:ScriptManager ID="viewCatalogueScriptManager" runat="server">
                            
                        </asp:ScriptManager>

                        <asp:UpdatePanel ID="catalogueUpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="True" EnableViewState="True">
                            <ContentTemplate>
                                    <asp:Repeater ID="catalogueRepeater"  runat="server"  OnItemCommand="catalogueRepeater_ItemCommand" ViewStateMode="Enabled" EnableViewState="False">
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="col-sm-8 col-lg-4">
                                                <div class="card card-user">
                                                    <div class="image" style="height:150px" >
                                                        <img src="../picture/<%# Eval("itemID") %>.jpg" />
                                                    </div>
                                                    <div style="margin-top:20px">
                                                            <p class="description text-center " style="margin-left:10px;margin-right:10px"> 
                                                                    <asp:Label ID="descLabel" runat="server" Text='<%# Eval("description") %>'></asp:Label>   
                                                                  
                                                            </p> 
															<p class="description text-center " style="margin-left:10px;margin-right:10px"> 
                                                                    <asp:Label ID="unitLabel" runat="server" Text='<%# Eval("unitOfMeasure") %>'></asp:Label>     
                                                            </p> 
                                                            <hr>
                                                            <div class="text-center" style="margin-bottom:20px">
                                                                <p >
                               
                                                                </p>
                                                                <asp:Button ID="addBtn" CssClass="btn btn-primary btn-fill"  runat="server" Text="Add"  Onclick="addBtn_Click" CommandName="add"  CommandArgument='<%# Eval("itemID")+"&"+Eval("description") %>'  ClientIDMode="AutoID" ViewStateMode="Enabled" EnableViewState="False" UseSubmitBehavior="false" /><!--CommandName="add" -->
                                                                <p>
                                                                    <br />
                                                                </p>
                                                            </div>
                                                        </div>
                                                    </div>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                           
                                        </FooterTemplate>
                                    </asp:Repeater>
                                
                                </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                         <!----------------------------------Cart---------------------------------------------------------->
              
                        <div class="col-lg-3">
                         <div class="card" style="position:fixed;right:2%;width:25%">
                           <div class="text-center">
                               <div class ="content">
                                   <asp:Button ID="Submit" runat="server" CssClass="btn btn-wd btn-warning btn-fill" Text="Checkout" OnClick="Submit_Click" EnableViewState="False" />
                               </div>
                               <div class="content">
                                   
                                    <asp:UpdatePanel ID="cartUpdatePanel" runat="server" UpdateMode="Conditional" ViewStateMode="Inherit" EnableViewState="False">
                                        <ContentTemplate>
                                              <asp:Repeater ID="cartRepeater" runat="server" OnItemCommand="cartRepeater_ItemCommand" ViewStateMode="Disabled" >
                                                <HeaderTemplate>
													   <table class="table">
																				<tr class="category">
																				
                                    											<td>Description</td>
                                    											<td>Amount</td>
																				<td class="text-right">Action</td>
																			</tr>
                                                   </HeaderTemplate>
                                                   <ItemTemplate>
                                                                        <tr>
                                                                            
                                    	                                    <td style=" margin-bottom:-10px">   <%#Eval("description") %>
                                                                                <br /><asp:RegularExpressionValidator runat="server" ForeColor="Red" ControlToValidate="cart_qtyTextBox" ValidationExpression="^[1-9]\d*$" ErrorMessage="Invalid quantity!!"></asp:RegularExpressionValidator>
                                    	                                    </td>
                                    	                                    <td class="text-center" style="width:15%">
                                                                                <asp:TextBox ID="cart_qtyTextBox" runat="server"  CssClass=" form-control"  Text='<%#Eval("Qty") %>' >                                                                                    
                                                                                </asp:TextBox>
                                                                                
                                    	                                    </td>
                                                                            <td class="td-actions text-right" >
                                                                                <asp:LinkButton ID="cart_deleteButton" runat="server"  ForeColor="Red"  CssClass=" fa fa-times"  OnClick="cart_deleteBtn_Click"  CommandName="delete" CommandArgument='<%# Eval("itemID") %>' ></asp:LinkButton>
                                                                                <%--<i class="fa fa-times"></i>--%>
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
    </div>
         
</asp:Content>
