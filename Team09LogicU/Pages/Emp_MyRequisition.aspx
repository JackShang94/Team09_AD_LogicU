<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Employee.Master" AutoEventWireup="true" CodeBehind="Emp_MyRequisition.aspx.cs" Inherits="Team09LogicU.pages.Emp_MyRequisition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    My Requisition
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
	
	<div class="col-md-12">
		<form id ="viewRequisitionForm" runat="server">
                        <div class="card">
								<div class="toolbar">
									<!--        Here you can write extra buttons/actions for the toolbar              -->
								</div>
								<asp:ScriptManager ID="myReqScriptManager" runat="server"></asp:ScriptManager>
							<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
								<ContentTemplate>
										<div class="content" >
											<h4 class=" panel-title">Pending Requisition</h4>
										</div> 
										<asp:GridView ID="requisitionListGridView" runat="server" AllowPaging="True"  AllowSorting="true" AutoGenerateColumns="false"  DataKeyNames="requisitionID" CssClass="table" OnRowDeleting="requisitionListGridView_RowDeleting"  OnRowCommand="requisitionListGridView_RowCommand" EmptyDataText="There is no pending requisition">
												<columns>
													<asp:TemplateField>
														<ItemTemplate>
															<asp:Label ID="req_autoID" runat="server" ><%# Container.DataItemIndex+1 %></asp:Label>
														</ItemTemplate>
													</asp:TemplateField>
													<asp:BoundField DataField="requisitionID" headerText="RequisitionID" Visible="false"/>
													<asp:BoundField DataField="requisitionDate" headerText="RequisitionDate"/>
													<asp:BoundField DataField="approvedDate" headerText="ApprovedDate" ConvertEmptyStringToNull="true"/>
													<asp:BoundField DataField="status" headerText ="status"/>
												
													<asp:TemplateField>
														<ItemTemplate>
																<asp:LinkButton ID="viewReqDetailBtn" runat="server"  Text="Edit" CommandName="editview"  CommandArgument='<%# Eval("requisitionID") %>'  OnClick="editReqDetailBtn_Click" ControlStyle-CssClass="btn btn-simple btn-info btn-icon table-action edit"><i class="fa fa-edit"></i></asp:LinkButton>
																
																<asp:LinkButton ID="deleteReqBtn" runat="server" Text="delete" CommandName="delete" CommandArgument='<%# Eval("requisitionID") %>' ControlStyle-CssClass="btn btn-simple btn-warning btn-icon table-action remove" EnableViewState="False"><i class="fa fa-remove "></i></asp:LinkButton>
														</ItemTemplate>
													</asp:TemplateField>
												
												</columns>
										</asp:GridView>
									</ContentTemplate>
								</asp:UpdatePanel>
							</div>	
							<div class="card">
								
								<asp:UpdatePanel ID="reqHisUpdatePanel" runat="server">
									<ContentTemplate>
										<div class="content" >
											<h4 class=" panel-title">Search by Request Date:<asp:TextBox ID="fromDate" runat="server"  CssClass="search" TextMode="Date"></asp:TextBox>
												<asp:TextBox ID="toDate" runat="server"  CssClass="search" TextMode="Date"></asp:TextBox><asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click"/></h4>
											
										</div> 
										
										<asp:GridView ID="requisitionHistoryGridView" runat="server" AllowPaging="True"  AllowSorting="true" AutoGenerateColumns="false"  DataKeyNames="requisitionID" CssClass="table" EmptyDataText="There is no history">
											<Columns>
												<asp:TemplateField>
													<ItemTemplate>
														<asp:Label ID="req_history_autoLabel" runat="server"><%# Container.DataItemIndex+1 %></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
												<asp:BoundField DataField="requisitionID" headerText="RequisitionID" Visible="false"/>
												<asp:BoundField DataField="requisitionDate" headerText="RequisitionDate"/>
												<asp:BoundField DataField="approvedDate" headerText="ApprovedDate" ConvertEmptyStringToNull="true"/>
												<asp:BoundField DataField="status" headerText ="status"/>
												<asp:TemplateField>
													<ItemTemplate>
															<asp:LinkButton ID="viewReqDetailBtn_h" runat="server"  Text="view" CommandName="view"  CommandArgument='<%# Eval("requisitionID") %>'  OnClick="viewReqDetailBtn_h_Click" ControlStyle-CssClass="btn btn-simple btn-info btn-icon table-action view"><i class="fa fa-image"></i></asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateField>
											</Columns>
										</asp:GridView>
									</ContentTemplate>
								</asp:UpdatePanel>
								
							</div>
			</form>
		</div>
   <%--<div class="col-md-12">
                        <div class="card">

                            <div class="toolbar">
                                <!--        Here you can write extra buttons/actions for the toolbar              -->
                            </div>
							 <form id="form1" runat="server">
									<div class="content" >
									<h4 class=" panel-title">Search by Request Date:<asp:TextBox ID="TextBox1" runat="server" CssClass="search" TextMode="Date"></asp:TextBox></h4>
                                    
                           
									</div> 
									<table id="bootstrap-table" class="table">
									<thead >
										<th></th>
										<th data-field="id">requisition ID</th>
                                		<th data-field="name" data-sortable="true">employee</th>
                                		<th data-field="salary" data-sortable="true">date</th>
                                		<th data-field="country" data-sortable="true">status</th>
                                	
                                		<th data-field="actions" class="td-actions text-center" data-events="operateEvents" data-formatter="operateFormatter">Actions</th>
									</thead>
										<tbody>
												<tr>
													<td></td>
                                    				<td>1</td>
                                    				<td>Employee1</td>
                                    				<td>2017-01-01</td>
                                    				<td>Pending</td>
                                    	
												<td class="td-actions text-center" style="">
													<a rel="tooltip" title="View" class="btn btn-simple btn-info btn-icon table-action view" href="javascript:void(0)">
													<i class="fa fa-image"></i></a>
													 <a rel="tooltip" title="Edit" class="btn btn-simple btn-warning btn-icon table-action edit" href="javascript:void(0)">
													<i class="fa fa-edit"></i></a>
													 <a rel="tooltip" title="Delete" class="btn btn-simple btn-danger  btn-icon table-action remove" href="javascript:void(0)">
													<i class="fa fa-remove "></i></a>
												   </td>
												</tr>
									  </tbody>
									</table>
							</form>
                            </div>
			</div>--%>

  
</asp:Content>

