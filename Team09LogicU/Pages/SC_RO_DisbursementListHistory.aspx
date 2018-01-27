﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_RO_DisbursementListHistory.aspx.cs" Inherits="Team09LogicU.Pages.SC_RO_DisbursementListHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <form id="form1" runat="server">
    <div class="row">
         <div class="col-lg-12">
        <div class="card">
                <div class=" container">
                    <div class="col-lg-12">
                   <div class="col-lg-3" style="margin-top:20px">
					   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
						<asp:Label ID="dateLabel" runat="server" Text="Select a Date:" CssClass="category"></asp:Label>
                       <span>Form:</span><asp:TextBox ID="fromTextBox" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
					   <span>To:</span><asp:TextBox ID="toTextBox" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
					   <asp:Button ID="searchBtn" runat="server" Text="search" OnClick="searchBtn_Click"></asp:Button>
                   </div>
                    <div class="col-lg-3" style="margin-top:20px">
						<asp:Label ID="deptLabel" runat="server" Text="Select a Department:" CssClass="category"></asp:Label>
                        <asp:DropDownList ID="deptDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>
                   </div>
                    <div class="col-lg-10">
                        
                        <asp:GridView ID="disburseHisGridView" runat="server" CssClass="table table-striped table-hover " OnSelectedIndexChanged="disburseHisGridView_SelectedIndexChanged" AutoGenerateColumns="false" EmptyDataText="There is no record">
							<Columns>
								<asp:TemplateField>
									<ItemTemplate>
										<%#Container.DataItemIndex+1 %>
									</ItemTemplate>
								</asp:TemplateField>
								<asp:TemplateField HeaderText="disbursementID">
									<ItemTemplate>
										<asp:Label runat="server" ID="disIDLabel"  Text='<%#Eval("disbursementID") %>'></asp:Label>
									</ItemTemplate>
								</asp:TemplateField>
								
								<asp:BoundField DataField="storeStaffID" HeaderText="storeStaffID"/>
								<asp:BoundField DataField="disburseDate" HeaderText="DisburseDate" />
								<asp:CommandField ShowSelectButton="true"  ButtonType="Button" SelectText="Detail"/>
							</Columns>
                        </asp:GridView>
                          </div>

                    </div>
                     
                    
                       </div>
                    
                </div>
            
        </div>
    </div>
    </form>



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
