<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Employee.Master" AutoEventWireup="true" CodeBehind="Emp_MyRequisition.aspx.cs" Inherits="Team09LogicU.pages.Emp_MyRequisition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    My Requisition
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
	
	<div class="col-md-12">
		<form id ="viewRequisitionForm" runat="server">
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
                                           <%--  <PagerTemplate>
        <br />
          <div class="col-lg-12 text-center">
         <div class="col-lg-1" style="width:100px">
         <asp:Label ID="lblPage" runat="server" Text='<%# "Page:" + (((GridView)Container.NamingContainer).PageIndex + 1)  + "/" + (((GridView)Container.NamingContainer).PageCount)  %> '></asp:Label></div>
         <div class="col-lg-1" style="width:40px">
         <asp:LinkButton ID="lbnFirst" runat="Server" Text="First" CssClass="btn btn-xs btn-success"   Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="First" ></asp:LinkButton></div>
        <div class="col-lg-1" style="width:40px" >
        <asp:LinkButton ID="lbnPrev" runat="server" Text="<<"  CssClass="btn btn-xs btn-success"  Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="Prev"  ></asp:LinkButton></div>
         <div class="col-lg-1" style="width:40px;height:80px;margin-right:-10px;margin-left:-5px;margin-top:-10px" >
            <asp:TextBox runat="server" CssClass="form-control text-center " Width="40px"  ID="inPageNum"></asp:TextBox></div>
        <div class="col-lg-1" style="width:40px; margin-left:20px" >
            <asp:LinkButton ID="lbnNext" runat="Server" Text=">>"  CssClass="btn btn-xs btn-success"  Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next" ></asp:LinkButton>
         </div><div class="col-lg-1" style="width:40px;margin-left:-10px">
            <asp:LinkButton ID="lbnLast" runat="Server" Text="Last"  CssClass="btn btn-xs btn-success"   Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last" ></asp:LinkButton></div>
              <div class="col-lg-1" style="width:40px">
             <asp:Button ID="Button1" CommandName="go"  CssClass="btn btn-xs btn-success"  Text="GO" runat="server" />
         </div><br />
     </PagerTemplate>--%>
										</asp:GridView>
                                             </div>
									</ContentTemplate>
								</asp:UpdatePanel></div>
								</div>
							</div></div>
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
               



	   <!--   Core JS Files and PerfectScrollbar library inside jquery.ui   -->
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery-ui.min.js" type="text/javascript"></script>
	<script src="../js/bootstrap.min.js" type="text/javascript"></script>


	<!--  Forms Validations Plugin -->
	<script src="../js/jquery.validate.min.js"></script>
         


    <!--  Date Time Picker Plugin is included in this js file -->
    <script src="../js/bootstrap-datetimepicker.js"></script>

    <!--  Select Picker Plugin -->
    <script src="../js/bootstrap-selectpicker.js"></script>

	<!--  Plugin for Date Time Picker and Full Calendar Plugin-->
	<script src="../js/moment.min.js"></script>

    <!--  Date Time Picker Plugin is included in this js file -->
    <script src="../js/bootstrap-datetimepicker.js"></script>

    <!--  Select Picker Plugin -->
    <script src="../js/bootstrap-selectpicker.js"></script>

	<!--  Checkbox, Radio, Switch and Tags Input Plugins -->
	<script src="../js/bootstrap-checkbox-radio-switch-tags.js"></script>

	<!--  Charts Plugin -->
	<script src="../js/chartist.min.js"></script>

    <!--  Notifications Plugin    -->
    <script src="../js/bootstrap-notify.js"></script>

    <!-- Sweet Alert 2 plugin -->
	<script src="../js/sweetalert2.js"></script>

    <!-- Vector Map plugin -->
	<script src="../js/jquery-jvectormap.js"></script>

    <!--  Google Maps Plugin    -->
    <script src="../js/aa743e8f448a4792bad10d201a7080f6.js"></script>

	<!-- Wizard Plugin    -->
    <script src="../js/jquery.bootstrap.wizard.min.js"></script>

	<!--  Bootstrap Table Plugin    -->
	<script src="../js/bootstrap-table.js"></script>

	<!--  Plugin for DataTables.net  -->
	<script src="../js/jquery.datatables.js"></script>

    <!--  Full Calendar Plugin    -->
    <script src="../js/fullcalendar.min.js"></script>

    <!-- Light Bootstrap Dashboard Core javascript and methods -->
	<script src="../js/light-bootstrap-dashboard.js"></script>

	<!--   Sharrre Library    -->
    <script src="../js/jquery.sharrre.js"></script>

	<!-- Light Bootstrap Dashboard DEMO methods, don't include it in your project! -->
	<script src="../js/demo.js"></script>
          <script type="text/javascript">
              $().ready(function () {

                  // Init Sliders
                  demo.initFormExtendedSliders();

                  // Init DatetimePicker
                  demo.initFormExtendedDatetimepickers();
              });
    </script>
    <script>
      (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
      (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
      m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
      })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

      ga('create', 'UA-46172202-1', 'auto');
      ga('send', 'pageview');

    </script>
  
</asp:Content>

