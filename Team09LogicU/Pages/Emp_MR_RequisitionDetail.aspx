<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Employee.Master" AutoEventWireup="true" CodeBehind="Emp_MR_RequisitionDetail.aspx.cs" Inherits="Team09LogicU.Pages.Emp_MR_RequisitionDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
Requisition Detail
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
	<div class="row">
                        <div class="col-lg-10">
							<div class="card">
									<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
									<asp:UpdatePanel ID="reqDetailUpdatePanel" runat="server" UpdateMode="Always">
										<ContentTemplate>
												<asp:gridview id="requisitionItemListGridView"  runat="server" allowpaging="True" allowsorting="true"  autogeneratecolumns="False" datakeynames="reqItemID" CssClass="table" OnRowDataBound="requisitionItemListGridView_RowDataBound"  OnRowCommand="requisitionItemListGridView_RowCommand" OnRowCancelingEdit="requisitionItemListGridView_RowCancelingEdit" OnRowUpdating="requisitionItemListGridView_RowUpdating" OnRowEditing="requisitionItemListGridView_RowEditing" OnRowDeleting="requisitionItemListGridView_RowDeleting" EnableViewState="False">
														<columns>
															<asp:TemplateField>
																<ItemTemplate>
																	<asp:Label ID="req_autoID" runat="server" ><%# Container.DataItemIndex+1 %></asp:Label>
																</ItemTemplate>
															</asp:TemplateField>
															<asp:TemplateField HeaderText="reqItemID" Visible="false">
																<ItemTemplate>
																	<asp:Label ID="reqItemQty" runat="server" Text='<%#Eval("reqItemID" )%>' ></asp:Label>
																	
																</ItemTemplate>
															</asp:TemplateField>
															<asp:TemplateField HeaderText="Description">
																<ItemTemplate>
																	<asp:Label ID="desc" runat="server" Text='<%#Eval("desc" )%>' ></asp:Label>
																</ItemTemplate>
															</asp:TemplateField>
															<asp:TemplateField HeaderText="Unit">
																	<ItemTemplate>
																		<asp:Label ID="unit" runat="server" Text='<%#Eval("unit" )%>' ></asp:Label>
																	</ItemTemplate>
															</asp:TemplateField>
															<asp:TemplateField HeaderText="requisitionQuantity">
																<ItemTemplate>
																	<asp:Label ID="reqQty" runat="server" Text='<%#Eval("requisitionQty" )%>' ></asp:Label>
																</ItemTemplate>
																<EditItemTemplate>
																	<asp:TextBox runat="server" CssClass="form-control" Width="50%" ID="reqQtyTextBox" Text='<%#Eval("requisitionQty") %>'></asp:TextBox>
																	<asp:RegularExpressionValidator runat="server" ControlToValidate="reqQtyTextBox" ValidationExpression="^[0-9]*[1-9][0-9]*$" ErrorMessage="Invalid Input!!!"></asp:RegularExpressionValidator>
																</EditItemTemplate>
															</asp:TemplateField>
															<%--<asp:BoundField DataField="requisitionQty" HeaderText="requisitionQty" ItemStyle-Width="100px"  />--%>
															
														<asp:TemplateField HeaderText="Action" >
																 <EditItemTemplate>
																	 <asp:LinkButton ID="reqDetailUpdate" runat="server" CssClass="btn btn-xs btn-danger" Text="update"  CommandName="Update" CommandArgument='<%#Eval("reqItemID") %>'  ></asp:LinkButton><!-- -->
																	<asp:LinkButton ID="reqDetailCancel" runat="server" CommandName="Cancel" CssClass="btn btn-xs btn-default" Text="Cancel" CommandArgument='<%#Eval("reqItemID") %>'></asp:LinkButton>
															   </EditItemTemplate>
																<ItemTemplate>
																	<asp:LinkButton ID="reqDetailEdit" runat="server" CssClass="btn btn-xs btn-warning"  CommandName="edit" CommandArgument='<%#Eval("reqItemID") %>' EnableViewState="False" Text="Edit"></asp:LinkButton>
																	<asp:LinkButton ID="reqDetailDelete" ForeColor="Red"  runat="server"  CommandName="delete" CommandArgument='<%#Eval("reqItemID") %>' EnableViewState="False"> <i class="fa fa-remove "></i></asp:LinkButton>
																	
																</ItemTemplate>
															</asp:TemplateField>
															
														</columns>
												</asp:gridview>
											</ContentTemplate>
										</asp:UpdatePanel>
                                </div></div></div>
									<div class="col-lg-4"><asp:Button  runat="server" ID="reSubmit" Text="Resubmit" CssClass="btn btn-wd btn-primary btn-fill" EnableViewState="False" OnClick="reSubmit_Click" />
    <asp:LinkButton ID="backToReqBtn"  runat="server" CssClass="btn btn-wd btn-default" OnClick="backToReqBtn_Click">Back</asp:LinkButton></div>
								
									
							
								
		

</asp:Content>
