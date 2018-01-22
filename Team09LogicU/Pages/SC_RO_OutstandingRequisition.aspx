<%@ Page Title="" Language="C#" MasterPageFile="~/pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_RO_OutstandingRequisition.aspx.cs" Inherits="Team09LogicU.pages.SC_RO_OutstandingRequisition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
Outstanding Requisition
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <form id="form1" runat="server">
    <div class="row">
         <div class="col-lg-12">
        <div class="card">
                <div class=" container">
                    <div class="col-lg-12">
                   <div class="col-lg-3" style="margin-top:20px">
                    <asp:Label ID="Label1" runat="server" Text="Select a Date:" CssClass="category"></asp:Label>
                       <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control datepicker"></asp:TextBox>
                   </div>
                           <div class="col-lg-3" style="margin-top:20px">
                    <asp:Label ID="Label3" runat="server" Text="Select a Department:" CssClass="category"></asp:Label>
                       <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server"></asp:DropDownList>
                   </div>
                    <div class="col-lg-10">
                        <asp:LinkButton ID="LinkButton1" runat="server">View Disbursement List History</asp:LinkButton>
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-hover "></asp:GridView>
                        <div class="col-lg-10">
                        <asp:Label ID="Label2" runat="server" Text="Label">Collection Point:</asp:Label>
                          </div>  </div></div>
                        <div class="col-lg-3" style=" margin-top:40px;margin-bottom:20px">
                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-wd btn-fill" Text="Print" />
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
