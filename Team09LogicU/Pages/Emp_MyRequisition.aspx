<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Employee.Master" AutoEventWireup="true" CodeBehind="Emp_MyRequisition.aspx.cs" Inherits="Team09LogicU.pages.Emp_MyRequisition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	My Requisition
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">



	<div class="row">
		<div class="col-lg-12">
			<div class="card">
				<div class=" container">
					<asp:ScriptManager ID="myReqScriptManager" runat="server"></asp:ScriptManager>
					<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
						<ContentTemplate>
							<div class=" col-lg-12" style="margin-top: 20px">
								<h4 class=" panel-title">Pending Requisition</h4>
							</div>
							<div class="col-lg-12" style="margin-bottom: 20px">
								<asp:GridView ID="requisitionListGridView" Width="80%" HeaderStyle-BackColor="#e8e8e8" runat="server" HeaderStyle-CssClass=" content text-uppercase " AllowSorting="true" AutoGenerateColumns="false" DataKeyNames="requisitionID" CssClass="table table-striped table-hover" OnRowDeleting="requisitionListGridView_RowDeleting" OnRowCommand="requisitionListGridView_RowCommand" EmptyDataText="There is no pending requisition">
									<Columns>
										<%--<asp:TemplateField>
														<ItemTemplate>
															<asp:Label ID="req_autoID" runat="server" ><%# Container.DataItemIndex+1 %></asp:Label>
														</ItemTemplate>
													</asp:TemplateField>--%>
										<asp:BoundField DataField="requisitionID" HeaderText="ID" Visible="false" />
										<asp:BoundField DataField="requisitionDate" HeaderText="Date" />
										<%--	<asp:BoundField DataField="approvedDate" headerText="ApprovedDate" ConvertEmptyStringToNull="true"/>--%>
										<asp:BoundField DataField="status" HeaderText="status" />

										<asp:TemplateField HeaderText="Action">
											<ItemTemplate>

												<asp:LinkButton ID="viewReqDetailBtn" runat="server" CssClass="btn btn-xs btn-warning" Text="edit" CommandName="editview" CommandArgument='<%# Eval("requisitionID") %>' OnClick="editReqDetailBtn_Click"></asp:LinkButton>

												<asp:LinkButton ID="deleteReqBtn" runat="server" ForeColor="Red" Text="delete" CommandName="delete" CommandArgument='<%# Eval("requisitionID") %>' EnableViewState="False"><i class="fa fa-remove "></i></asp:LinkButton>


											</ItemTemplate>
										</asp:TemplateField>

									</Columns>
								</asp:GridView>
							</div>
						</ContentTemplate>
					</asp:UpdatePanel>
				</div>
			</div>
		</div>
	</div>
	<div class="row">
		<div class="col-lg-12">
			<div class="card">
				<div class=" container">
					<asp:UpdatePanel ID="reqHisUpdatePanel" runat="server">
						<ContentTemplate>


							<div class="col-md-10" style="margin-top: 20px; margin-bottom: 20px">
								<h4 class=" panel-title">Search by Request Date:</h4>
							</div>
							<div class="col-md-3">
								<asp:Label ID="label1" runat="server" CssClass="category">From</asp:Label><asp:TextBox ID="fromDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox></div>
							<div class="col-md-3">
								<asp:Label ID="label2" runat="server" CssClass="category">To</asp:Label><asp:TextBox ID="toDate" runat="server" CssClass="form-control " TextMode="Date"></asp:TextBox></div>
							<div class="col-md-10" style="margin-top: 20px">
								<asp:Button ID="searchButton" CssClass="btn btn-primary btn-wd btn-fill" runat="server" Text="Search" OnClick="searchButton_Click" EnableViewState="False" /></div>


							<div class="col-lg-12" style="margin-bottom: 20px; margin-top: 20px">
								<asp:GridView ID="requisitionHistoryGridView" Width="80%" HeaderStyle-BackColor="#e8e8e8" runat="server" AllowPaging="True" AllowSorting="true"
									AutoGenerateColumns="false" DataKeyNames="requisitionID" CssClass="table table-striped table-hover" HeaderStyle-CssClass=" content text-uppercase  "
									OnPageIndexChanging="requisitionHistoryGridView_PageIndexChanging" PageSize="5" OnRowCommand="requisitionHistoryGridView_RowCommand"
									EmptyDataText="There is no history" CellPadding="4" GridLines="None">
									<Columns>
										<asp:TemplateField>
											<ItemTemplate>
												<asp:Label ID="req_history_autoLabel" runat="server"><%# Container.DataItemIndex+1 %></asp:Label>
											</ItemTemplate>
										</asp:TemplateField>
										<asp:BoundField DataField="requisitionID" HeaderText="ID" Visible="false" />
										<asp:BoundField DataField="requisitionDate" HeaderText="Requisition Date" />
										<asp:BoundField DataField="approvedDate" HeaderText="Approved Date" ConvertEmptyStringToNull="true" />
										<asp:BoundField DataField="status" HeaderText="Status" />
										<asp:TemplateField>
											<ItemTemplate>
												<asp:LinkButton ID="viewReqDetailBtn_h" runat="server" Text="view" CommandName="view" CommandArgument='<%# Eval("requisitionID") %>' OnClick="viewReqDetailBtn_h_Click" ControlStyle-CssClass="btn btn-xs btn-primary"></asp:LinkButton>
											</ItemTemplate>
										</asp:TemplateField>
									</Columns>
									<AlternatingRowStyle BackColor="White" />
									<PagerTemplate>
										<br />
										<div class="col-lg-12 ">
											<div class="col-lg-3 " style="width: 20%">
												<asp:Label ID="lblPage" runat="server" Text='<%# "Page:" + (((GridView)Container.NamingContainer).PageIndex + 1)  + "/" + (((GridView)Container.NamingContainer).PageCount)  %> '></asp:Label>
												<asp:LinkButton ID="lbnFirst" runat="Server" Text="First" CssClass="btn btn-xs btn-default" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="First"></asp:LinkButton>
												<asp:LinkButton ID="lbnPrev" runat="server" Text="<<" CssClass="btn btn-xs btn-default" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="Prev"></asp:LinkButton>
											</div>
											<div class="col-lg-1" style="width: 10%">
												<asp:TextBox runat="server" CssClass="form-control text-center " ID="inPageNum" Text='<%# ((GridView)Container.NamingContainer).PageIndex +1 %>'></asp:TextBox>
											</div>
											<div class="col-lg-3 ">
												<asp:LinkButton ID="lbnNext" runat="Server" Text=">>" CssClass="btn btn-xs btn-default" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next"></asp:LinkButton>
												<asp:LinkButton ID="lbnLast" runat="Server" Text="Last" CssClass="btn btn-xs btn-default" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last"></asp:LinkButton>
												<asp:Button ID="Button1" CommandName="go" CssClass="btn btn-xs btn-default" Text="GO" runat="server" />
											</div>
										</div>

									</PagerTemplate>
								</asp:GridView>
							</div>
						</ContentTemplate>
					</asp:UpdatePanel>
				</div>
			</div>
		</div>
	</div>



</asp:Content>

