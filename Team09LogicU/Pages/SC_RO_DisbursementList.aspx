<%@ Page Title="" Language="C#" MasterPageFile="~/pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_RO_DisbursementList.aspx.cs" Inherits="Team09LogicU.pages.SC_RO_DisbursementList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Disbursement List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <form id="form1" runat="server">
				<div class="row">
					 <div class="col-lg-12">
							<div class="card">
										<div class="container">
											<div class=" col-md-12" style="margin-left:-20px;">
												 <div class="col-lg-3" style="margin-top:20px">
														<asp:Label ID="selectDepLabel" runat="server" Text="Select a Department:" CssClass="category"></asp:Label>
														<asp:DropDownList ID="deptDropDownList" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="deptDropDownList_SelectedIndexChanged" Width="100px"></asp:DropDownList>
												 </div> 
												<%-- <div class="col-lg-12" style="margin-top:20px">
														<asp:LinkButton ID="LinkButton1" runat="server" >View Current Disbursement By Department</asp:LinkButton>
												 </div>--%>
												<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
												<div class="col-lg-10">
																 <asp:UpdatePanel ID="disburseUpdatePanel" runat="server">
																		<ContentTemplate>
																			<asp:GridView ID="disburseGridView" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="disburseGridView_SelectedIndexChanged">
																				<Columns>
																					<asp:TemplateField Visible="false">
																						<ItemTemplate>
																							<asp:Label runat="server" ID="disburseIDLabel" Text='<%#Eval("disbursementID") %>'></asp:Label>
																						</ItemTemplate>
																					</asp:TemplateField>
																					<asp:TemplateField>
																						<ItemTemplate>
																							<%#Container.DataItemIndex+1 %>
																						</ItemTemplate>
																					</asp:TemplateField>
																					<asp:BoundField DataField="disburseDate"  HeaderText="Date"/>
																					<asp:BoundField DataField="status"  HeaderText="Status"/>
																					<asp:CommandField  ShowSelectButton="true" SelectText="view" ButtonType="Button"/>
																				</Columns>
																			</asp:GridView>
																		</ContentTemplate>
																</asp:UpdatePanel>
												</div>
												 <div class="col-lg-10">
																 <asp:UpdatePanel ID="disburseItemUpdatePanel" runat="server">
																	 <ContentTemplate>
																				<asp:GridView ID="disburseItemGridView" runat="server" CssClass="table table-striped table-hover " HeaderStyle-CssClass=" content text-uppercase " DataKeyNames="itemDescription" AutoGenerateColumns="False"  OnRowEditing ="disburseItemGridView_RowEditing" OnRowUpdating="disburseItemGridView_RowUpdating" OnRowCancelingEdit="disburseItemGridView_RowCancelingEdit" CellPadding="4" ForeColor="#333333" GridLines="None" EnableViewState="True"   EmptyDataText="There is no disbursement">
																					 <Columns>
																								<asp:TemplateField Visible="false">
																										  <ItemTemplate>
																											  <asp:Label ID="itemIDLabel" runat="server" Text='<%#Eval("itemID") %>'></asp:Label>
																										  </ItemTemplate>
																								</asp:TemplateField>
																								<asp:TemplateField HeaderText="ItemDescription" SortExpression="SortedAscendingHeaderStyle">
																											<ItemTemplate>
																												<asp:Label ID="ItemDescription" runat="server" Text='<%# Eval("itemDescription") %>'></asp:Label>
																											</ItemTemplate>
																								</asp:TemplateField>
																								<asp:TemplateField HeaderText="Expected">
																											<ItemTemplate>
																												<asp:Label ID="Expected" runat="server" Text='<%# Eval("expectedc") %>'></asp:Label>
																											</ItemTemplate>
																								</asp:TemplateField>
																								<asp:TemplateField HeaderText="Actual">
																											<ItemTemplate>
																												<asp:Label ID="lblActual" runat="server" Text='<%# Eval("actual") %>'></asp:Label>
																											</ItemTemplate>
																											<EditItemTemplate>                          
																												<asp:TextBox ID="Actual" CssClass="form-control" Text='<%# Eval("actual") %>' runat="server" BackColor="Azure"></asp:TextBox>                        
																											</EditItemTemplate>
																								</asp:TemplateField>
																								<asp:TemplateField>
																											<ItemTemplate>
																												<asp:Button ID="btnEdit" CssClass="btn btn-xs btn-default" runat="server" CommandName="Edit" Text="Edit"  CommandArgument='<%#Eval("itemID")+"&"+(Eval("actual")).ToString() %>'/>
																											</ItemTemplate>
																											<EditItemTemplate>
																												<asp:Button ID="btnUpdate" CssClass="btn btn-xs btn-success" runat="server" CommandName="Update" Text="Update" />
																												<asp:Button ID="btnCancel" CssClass="btn btn-xs btn-default" runat="server" CommandName="Cancel" Text="Cancel" />
																											</EditItemTemplate>
																								</asp:TemplateField>
																						 </Columns>
																				</asp:GridView>
																		 </ContentTemplate>
																 </asp:UpdatePanel>
															<div class="col-lg-10">
																<asp:Label ID="collectionpointLabel" runat="server" Text="Label">Collection Point:</asp:Label>
															</div>  
												 </div>
											</div>
											<div class="col-lg-3" style=" margin-top:40px;margin-bottom:20px">
													<asp:Button ID="NotifyButton" runat="server" CssClass="btn btn-primary btn-wd btn-fill" Text="Send Email representative" />
											</div>
											<div class="col-lg-3 " style="margin-top:40px;margin-bottom:20px">
													<asp:Button ID="QRcodeButton" runat="server" CssClass="btn btn-primary btn-wd " Text="Generate QR Code" />
											</div>
											<div class="col-lg-3 " style="margin-top:40px;margin-bottom:20px">
													<asp:Button ID="Button3" runat="server" CssClass="btn btn-primary btn-wd " Text="Confirm"  OnClick="Button3_Click"/>
											</div>
										</div>
                    
							</div>
            
						</div>
				</div>
    </form>
</asp:Content>
