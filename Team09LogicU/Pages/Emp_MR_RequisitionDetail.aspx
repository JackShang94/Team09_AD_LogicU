<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Employee.Master" AutoEventWireup="true" CodeBehind="Emp_MR_RequisitionDetail.aspx.cs" Inherits="Team09LogicU.Pages.Emp_MR_RequisitionDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
Requisition Detail
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
	<div class="col-md-12">
                        <div class="card">
								<div class="toolbar">
									<!--        Here you can write extra buttons/actions for the toolbar              -->
								</div>
							
									
								<form id ="viewRequisitionDetailForm" runat="server">
									<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
									<asp:UpdatePanel ID="reqDetailUpdatePanel" runat="server" UpdateMode="Always">
										<ContentTemplate>
												<asp:gridview id="requisitionItemListGridView" runat="server" allowpaging="True" allowsorting="true"  autogeneratecolumns="False" datakeynames="reqItemID" CssClass="table" OnRowDataBound="requisitionItemListGridView_RowDataBound"  OnRowCommand="requisitionItemListGridView_RowCommand" OnRowCancelingEdit="requisitionItemListGridView_RowCancelingEdit" OnRowUpdating="requisitionItemListGridView_RowUpdating" OnRowEditing="requisitionItemListGridView_RowEditing" OnRowDeleting="requisitionItemListGridView_RowDeleting" EnableViewState="False">
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
															<%--<asp:BoundField DataField="reqItemID" headerText="RequisitionID" Visible="false"/>
															<asp:BoundField DataField="itemID" headerText="itemID"/>--%>
															<asp:BoundField DataField="requisitionQty" HeaderText="requisitionQty" ItemStyle-Width="100px"  />
															<asp:TemplateField>
																 <EditItemTemplate>
																	 <asp:LinkButton ID="reqDetailUpdate" runat="server" Text="update"  CommandName="Update" CommandArgument='<%#Eval("reqItemID") %>'  ></asp:LinkButton><!-- -->
																	<asp:LinkButton ID="reqDetailCancel" runat="server" CommandName="Cancel" Text="Cancel" CommandArgument='<%#Eval("reqItemID") %>'></asp:LinkButton>
															   </EditItemTemplate>
																<ItemTemplate>
																	<asp:LinkButton ID="reqDetailEdit" runat="server"  CommandName="edit" CommandArgument='<%#Eval("reqItemID") %>'><i class="fa fa-edit"></i></asp:LinkButton>
																	<asp:LinkButton ID="reqDetailDelete" runat="server"  CommandName="delete" CommandArgument='<%#Eval("reqItemID") %>' EnableViewState="False"> <i class="fa fa-remove "></i></asp:LinkButton>
																	
																</ItemTemplate>
															</asp:TemplateField>
															
														</columns>
												</asp:gridview>
											</ContentTemplate>
										</asp:UpdatePanel>
									<asp:LinkButton ID="backToReqBtn" runat="server" OnClick="backToReqBtn_Click">Back</asp:LinkButton>
									<%--<asp:Button ID="reSubmitReqBtn" runat="server" Text="Update" OnClick="reSubmitReqBtn_Click" />--%>
									
								</form>
								
						</div>
		</div>

</asp:Content>
