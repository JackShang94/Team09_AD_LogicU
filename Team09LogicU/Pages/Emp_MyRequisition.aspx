<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Employee.Master" AutoEventWireup="true" CodeBehind="Emp_MyRequisition.aspx.cs" Inherits="Team09LogicU.pages.Emp_MyRequisition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    My Requisition
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
	
	
		
            <div class="row">
                        <div class="col-lg-10">
                            <div class="card">
                                    <div class=" container" >
								<asp:ScriptManager ID="myReqScriptManager" runat="server"></asp:ScriptManager>
							<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
								<ContentTemplate>
										<div class=" col-lg-10" style="margin-top:20px">
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
                                                           
																<asp:LinkButton ID="viewReqDetailBtn" runat="server" CssClass="btn btn-xs btn-warning"  Text="Edit" CommandName="editview"  CommandArgument='<%# Eval("requisitionID") %>'  OnClick="editReqDetailBtn_Click" ></asp:LinkButton>
																
																<asp:LinkButton ID="deleteReqBtn" runat="server" Text="delete" CommandName="delete" CommandArgument='<%# Eval("requisitionID") %>' ControlStyle-CssClass="btn btn-simple btn-danger btn-icon table-action remove" EnableViewState="False"><i class="fa fa-remove "></i></asp:LinkButton>
														

														</ItemTemplate>
													</asp:TemplateField>
												
												</columns>
										</asp:GridView></div>
									</ContentTemplate>
								</asp:UpdatePanel></div>
							</div></div></div>
            <div class="row">
                        <div class="col-lg-10">
							<div class="card">
								 <div class=" container" >
								<asp:UpdatePanel ID="reqHisUpdatePanel" runat="server">
									<ContentTemplate>
										
                                            
											 <div class="col-lg-10" style="margin-top:20px"><h4 class=" panel-title">Search by Request Date:</h4></div>
                                            <div class="col-lg-3" ><asp:Label ID="label1" runat="server" CssClass="category" >From</asp:Label><asp:TextBox ID="fromDate" runat="server"  CssClass="form-control" TextMode="Date" ></asp:TextBox></div>
											<div class="col-lg-3"><asp:Label ID="label2" runat="server" CssClass="category" >To</asp:Label><asp:TextBox ID="toDate" runat="server"  CssClass="form-control " TextMode="Date"></asp:TextBox></div>
                                             <div class="col-lg-3" style="margin-top:20px"><asp:Button ID="searchButton" CssClass="btn btn-primary btn-wd btn-fill" runat="server" Text="Search" OnClick="searchButton_Click" EnableViewState="False" /></div>
											
										
										 <div class="col-lg-10" style="margin-bottom:20px;margin-top:20px" >
										<asp:GridView ID="requisitionHistoryGridView"  runat="server" AllowPaging="True" AllowSorting="true" 
                                            AutoGenerateColumns="false"  DataKeyNames="requisitionID"  CssClass="table table-striped  table-hover " HeaderStyle-CssClass=" content text-uppercase  "
                                         OnPageIndexChanging="requisitionHistoryGridView_PageIndexChanging" PageSize="5"  OnRowCommand="requisitionHistoryGridView_RowCommand"
                                            EmptyDataText="There is no history" CellPadding="4" ForeColor="#333333" GridLines="None">
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
                                  <AlternatingRowStyle BackColor="White" />
                                             <PagerTemplate>
                                   <br />
                                              <div class="col-lg-12 text-center">
                                             <div class="col-lg-1" style="width:100px">
                                             <asp:Label ID="lblPage" runat="server" Text='<%# "Page:" + (((GridView)Container.NamingContainer).PageIndex + 1)  + "/" + (((GridView)Container.NamingContainer).PageCount)  %> '></asp:Label></div>
                                             <div class="col-lg-1" style="width:40px">
                                             <asp:LinkButton ID="lbnFirst" runat="Server" Text="First" CssClass="btn btn-xs btn-success"   Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="First" ></asp:LinkButton></div>
                                            <div class="col-lg-1" style="width:40px" >
                                            <asp:LinkButton ID="lbnPrev" runat="server" Text="<<"  CssClass="btn btn-xs btn-success"  Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="Prev"  ></asp:LinkButton></div>
                                            
                           <div class="col-lg-1" style="width:40px;height:80px;margin-right:-10px;margin-left:-5px;margin-top:-10px" >
                           <asp:TextBox runat="server" CssClass="form-control text-center " Width="40px"  ID="inPageNum" Text='<%#(((GridView)Container.NamingContainer).PageIndex + 1)%>'></asp:TextBox></div>
                                            
                                                  <div class="col-lg-1" style="width:40px; margin-left:20px" >
                                                <asp:LinkButton ID="lbnNext" runat="Server" Text=">>"  CssClass="btn btn-xs btn-success"  Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next" ></asp:LinkButton>
                                             </div><div class="col-lg-1" style="width:40px;margin-left:-10px">
                                                <asp:LinkButton ID="lbnLast" runat="Server" Text="Last"  CssClass="btn btn-xs btn-success"   Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last" ></asp:LinkButton></div>
                                                 <div class="col-lg-1" style="width:40px">
                                                             <asp:Button ID="go" CommandName="go"  CssClass="btn btn-xs btn-success"  Text="GO" runat="server" CausesValidation="false" />
                                               
                                             </div><br />

                                 

                                         </PagerTemplate>
										</asp:GridView>
                                             </div>
									</ContentTemplate>
								</asp:UpdatePanel></div>
								</div>
							</div></div>
		
	

</asp:Content>

