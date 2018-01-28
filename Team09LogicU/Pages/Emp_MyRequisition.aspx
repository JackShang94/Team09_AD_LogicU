<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Employee.Master" AutoEventWireup="true" CodeBehind="Emp_MyRequisition.aspx.cs" Inherits="Team09LogicU.pages.Emp_MyRequisition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    My Requisition
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
	
	<div class="col-md-12">
		
            <div class="row">
                        <div class="col-lg-12">
                            <div class="card">
                                    <div class=" container" >
								<asp:ScriptManager ID="myReqScriptManager" runat="server"></asp:ScriptManager>
							<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
								<ContentTemplate>
										<div class="header">
											<h4 class=" panel-title">Pending Requisition</h4>
										</div>
                                    <div class="col-lg-10" style="margin-bottom:20px" >
										<asp:GridView ID="requisitionListGridView" runat="server" AllowPaging="True"  AllowSorting="true" AutoGenerateColumns="false"  DataKeyNames="requisitionID" CssClass="table table-striped table-hover" OnRowDeleting="requisitionListGridView_RowDeleting"  OnRowCommand="requisitionListGridView_RowCommand" EmptyDataText="There is no pending requisition">
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
												
													<asp:TemplateField >
														<ItemTemplate>
                                                            <div style="margin-left:10px;margin-right:-10px">
																<asp:LinkButton ID="viewReqDetailBtn" runat="server"  Text="Edit" CommandName="editview"  CommandArgument='<%# Eval("requisitionID") %>'  OnClick="editReqDetailBtn_Click" ControlStyle-CssClass="btn btn-xs btn-default"></asp:LinkButton>
																
																<asp:LinkButton ID="deleteReqBtn" runat="server" Text="delete" CommandName="delete" CommandArgument='<%# Eval("requisitionID") %>' ControlStyle-CssClass="btn btn-simple btn-danger btn-icon table-action remove" EnableViewState="False"><i class="fa fa-remove "></i></asp:LinkButton>
														</div>

														</ItemTemplate>
													</asp:TemplateField>
												
												</columns>
										</asp:GridView></div>
									</ContentTemplate>
								</asp:UpdatePanel></div>
							</div></div></div>
            <div class="row">
                        <div class="col-lg-12">
							<div class="card">
								 <div class=" container" >
								<asp:UpdatePanel ID="reqHisUpdatePanel" runat="server">
									<ContentTemplate>
										<div class="header">
                                            
											<h4 class=" panel-title">Search by Request Date:</h4>
                                            <div class="col-lg-3" ><asp:Label ID="label1" runat="server" CssClass="category" >From</asp:Label><asp:TextBox ID="fromDate" runat="server"  CssClass="form-control datepicker" ></asp:TextBox></div>
											<div class="col-lg-3"><asp:Label ID="label2" runat="server" CssClass="category" >To</asp:Label><asp:TextBox ID="toDate" runat="server"  CssClass="form-control datepicker" ></asp:TextBox></div>
                                             <div class="col-lg-3" style="margin-top:30px"><asp:Button ID="searchButton" CssClass="btn btn-primary btn-wd btn-fill" runat="server" Text="Search" OnClick="searchButton_Click" EnableViewState="False" /></div>
											
										</div> 
										 <div class="col-lg-10" style="margin-bottom:20px;margin-top:20px" >
										<asp:GridView ID="requisitionHistoryGridView"  runat="server" AllowPaging="True" AllowSorting="true" AutoGenerateColumns="false"  DataKeyNames="requisitionID" CssClass="table table-striped table-hover" EmptyDataText="There is no history">
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
															<asp:LinkButton ID="viewReqDetailBtn_h" runat="server"  Text="view" CommandName="view"  CommandArgument='<%# Eval("requisitionID") %>'  OnClick="viewReqDetailBtn_h_Click" ControlStyle-CssClass="btn btn-xs btn-default"></asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateField>
											</Columns>

										</asp:GridView>
                                             </div>
									</ContentTemplate>
								</asp:UpdatePanel></div>
								</div>
							</div></div>
		
		</div>

</asp:Content>

