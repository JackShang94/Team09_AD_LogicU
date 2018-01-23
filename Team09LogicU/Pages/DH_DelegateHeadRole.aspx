<%@ Page Title="" Language="C#" MasterPageFile="~/pages/DepartmentHead.Master" AutoEventWireup="true" CodeBehind="DH_DelegateHeadRole.aspx.cs" Inherits="Team09LogicU.pages.DH_DelegateHeadRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Delegate Head Role
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     
                
    <form runat="server">
        <div class="row">
        <div class="col-lg-12">
            <div class="card">
       <div class=" container">
        <div class="col-lg-12">
       <div class="h4"> Current Role:
       <asp:Label ID="Label_logInRole" runat="server" CssClass="h5" Text="" EnableViewState="true"></asp:Label>
       </div></div>
        <div >
            <asp:Panel ID="Panel_submitDelegate" runat="server">
                
              <div class="col-lg-3 "><label class="category">Employee: </label> 
            <asp:DropDownList ID="employee_dropList" CssClass="form-control" Width="80%"  runat="server"></asp:DropDownList>
               </div><div class="col-lg-3"><label class="category"> From:</label>      
         <asp:TextBox ID="textBox_startDate" runat="server"  Width="80%" CssClass="form-control datepicker"></asp:TextBox>
              </div><div class="col-lg-3"><label class="category"> To:</label>          
         <asp:TextBox ID="textBox_endDate" runat="server"  Width="80%" CssClass="form-control datepicker" ></asp:TextBox>
</div>
                
                <div class="col-lg-8" style="margin-top:20px">
                <asp:Button ID="submit_button" runat="server" CssClass="btn btn-primary btn-wd btn-fill" Text="SUBMIT" OnClick="submit_button_Click" />
                    </div>
            </asp:Panel>
        </div>
        
        <div class="col-lg-12">
        <h4>Delegate History:</h4></div>
        <asp:GridView ID="GridView_dHistory" AllowPaging="true" OnPageIndexChanging="GridView_dHistory_PageIndexChanging" OnRowCommand="GridView_dHistory_RowCommand"  CssClass="table table-striped table-hover" runat="server" EmptyDataText="No delegation record">
            <Columns> 
                <asp:ButtonField  CommandName="Select"  ControlStyle-ForeColor="#0066ff" ControlStyle-CssClass=" text-center btn-xs btn-default" Text="select"  />
            </Columns>
            <PagerTemplate>
        <br />
          <div class="col-lg-12">
         <div class="col-lg-1" style="width:100px">
         <asp:Label ID="lblPage" runat="server" Text='<%# "Page:" + (((GridView)Container.NamingContainer).PageIndex + 1)  + "/" + (((GridView)Container.NamingContainer).PageCount)  %> '></asp:Label></div>
         <div class="col-lg-1" style="width:40px">
         <asp:LinkButton ID="lbnFirst" runat="Server" Text="First"   Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="First" ></asp:LinkButton></div>
        <div class="col-lg-1" style="width:40px" >
        <asp:LinkButton ID="lbnPrev" runat="server" Text="<<" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="Prev"  ></asp:LinkButton></div>
         <div class="col-lg-1" style="width:40px" >
            <asp:TextBox runat="server" CssClass="form-control" Width="40px" ID="inPageNum"></asp:TextBox></div>
        <div class="col-lg-1" style="width:40px; margin-left:40px" >
            <asp:LinkButton ID="lbnNext" runat="Server" Text=">>" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next" ></asp:LinkButton>
         </div><div class="col-lg-1" style="width:40px">
            <asp:LinkButton ID="lbnLast" runat="Server" Text="Last"   Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last" ></asp:LinkButton></div>
              <div class="col-lg-1" style="width:40px">
             <asp:Button ID="Button1" CommandName="go" CssClass="btn btn-primary btn-xs btn-fill" Text="GO" runat="server" />
         </div><br />
     </PagerTemplate>
            <SelectedRowStyle BackColor="#e4e4e4" />
        </asp:GridView>
        <div class="col-lg-10" style="margin-top:20px">
        <asp:Button ID="terminate_button" runat="server" Text="TERMINATE" CssClass="btn btn-wd btn-danger" OnClick="terminate_button_Click" />
        <asp:Label ID="label_terminateDlgt" runat="server" Text=""></asp:Label>
    
                    </div>
                </div>
            </div>
         </div></div>
    
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
	<div class="sweet-container">
        <div class="sweet-overlay" tabindex="-1">
        </div><div class="sweet-alert" style="display: none" tabindex="-1">
            <div class="icon error">
                <span class="x-mark">
                    <span class="line left"></span>
                    <span class="line right"></span></span></div>
            <div class="icon warning"> <span class="body"></span>
                <span class="dot"></span> </div> <div class="icon info"></div>
            <div class="icon success"> <span class="line tip"></span>
                <span class="line long"></span> <div class="placeholder"></div>
                <div class="fix"></div> </div>
            <img class="sweet-image"><h2>Title</h2><div class="sweet-content">Text</div>
            <hr class="sweet-spacer">
            <button class="sweet-confirm">OK</button>
            <button class="sweet-cancel">Cancel</button></div></div>

</asp:Content>
