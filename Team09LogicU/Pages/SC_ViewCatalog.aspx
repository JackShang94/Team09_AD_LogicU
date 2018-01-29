<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_ViewCatalog.aspx.cs" Inherits="Team09LogicU.Pages.SC_ViewCatalog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    View Catalog
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

      <form id="form1" runat="server">
        <div class="row">
           <div class="col-lg-12">
                <div class="card">
                    <div class=" container">

                        <div class ="col-lg-6" style="margin-top:20px">

                                       <div class="col-lg-3">
                            <asp:TextBox ID="TextBox_Search" runat="server" Width=300px CssClass="form-control"></asp:TextBox>
                                           </div>
<%--                           <asp:DropDownList ID="ddlCategory" runat="server" Width=300px CssClass="form-control"></asp:DropDownList><br>--%>
                           </div>
                        <div class ="col-lg-6" style="margin-top:20px">
                                    <asp:Button ID="btnSearch" runat="server" Width=200px Text="Search" CssClass="btn btn-primary btn-fill btn-wd" OnClick="btnSearch_Click" />
                                
                            </div>

     <div class="col-lg-10" style="margin-bottom:20px">
                                            <asp:GridView ID="GridView_CatalogList" runat="server" CssClass="table bootstrap-table table-hover table-striped"
                                                HeaderStyle-CssClass=" content text-uppercase  " AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"
                                                EmptyDataText="There are no Item" AllowPaging="True" OnRowCommand="GridView_CatalogList_RowCommand" PageSize="5" 
                                                onpageindexchanging="GridView_CatalogList_PageIndexChanging"  >
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                 
                                                    <asp:BoundField DataField="itemID" HeaderText="item ID:" />
                                                    <asp:BoundField DataField="categoryID" HeaderText="categoryID:" />
                                                    <asp:BoundField DataField="location" HeaderText="location:" />
                                                    <asp:BoundField DataField="description" HeaderText="description:" />
                                                    <asp:BoundField DataField="reorderLevel" HeaderText="reorder Level:" />
                                                    <asp:BoundField DataField="reorderQty" HeaderText="reorder Qty:" />
                                                    <asp:BoundField DataField="unitOfMeasure" HeaderText="unit Of Measure:" />
                                                    <asp:BoundField DataField="qtyOnHand" HeaderText="qtyOnHand:" />
                                                    
                                                </Columns>
                                                <HeaderStyle CssClass=" content text-uppercase"></HeaderStyle>
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
                                    </div>
                                    <!-- end content-->
                                     </div>
                                        <!--  end card  -->
                                </div>
                                 <!-- end col-md-12 -->
                            </div>                    
                        <!-- end row -->

               
    

    </form>
    <div class="fixed-plugin">
    <div class="dropdown">
        <a href="#" data-toggle="dropdown">
        <i class="fa fa-cog fa-2x"> </i>
        </a>
        <ul class="dropdown-menu">
            <li class="header-title">Configuration</li>
            <li class="adjustments-line">
                <a href="javascript:void(0)" class="switch-trigger">
                    <p>Sidebar Image</p>
                    <div class="switch switch-sidebar-image"
                        data-on-label="ON"
                        data-off-label="OFF">
                        <input type="checkbox" checked/>
                    </div>
                    <div class="clearfix"></div>
                </a>
            </li>
			<li class="adjustments-line">
                <a href="javascript:void(0)" class="switch-trigger">
                    <p>Sidebar Mini</p>
                    <div class="switch  switch-sidebar-mini"
                        data-on-label="ON"
                        data-off-label="OFF">
                        <input type="checkbox"/>
                    </div>
                    <div class="clearfix"></div>
                </a>
            </li>
			<li class="adjustments-line">
                <a href="javascript:void(0)" class="switch-trigger">
                    <p>Fixed Navbar</p>
                    <div class="switch  switch-navbar-fixed"
                        data-on-label="ON"
                        data-off-label="OFF">
                        <input type="checkbox"/>
                    </div>
                    <div class="clearfix"></div>
                </a>
            </li>
            <li class="adjustments-line">
                <a href="javascript:void(0)" class="switch-trigger">
                    <p>Filters</p>
                    <div class="pull-right">
                        <span class="badge filter" data-color="black"></span>
                        <span class="badge filter badge-azure" data-color="azure"></span>
                        <span class="badge filter badge-green" data-color="green"></span>
                        <span class="badge filter badge-orange active" data-color="orange"></span>
                        <span class="badge filter badge-red" data-color="red"></span>
                        <span class="badge filter badge-purple" data-color="purple"></span>
                    </div>
                    <div class="clearfix"></div>
                </a>
            </li>
            <li class="header-title">Sidebar Images</li>
            <li>
                <a class="img-holder switch-trigger" href="javascript:void(0)">
                    <img src="../picture/full-screen-image-1.jpg">
                </a>
            </li>
            <li>
                <a class="img-holder switch-trigger" href="javascript:void(0)">
                    <img src="../picture/full-screen-image-2.jpg">
                </a>
            </li>
            <li class="active">
                <a class="img-holder switch-trigger" href="javascript:void(0)">
                    <img src="../picture/full-screen-image-3.jpg">
                </a>
            </li>
            <li>
                <a class="img-holder switch-trigger" href="javascript:void(0)">
                    <img src="../picture/full-screen-image-4.jpg">
                </a>
            </li>

            <li class="button-container">
                <div class="">
                    <a href="http://www.creative-tim.com/product/light-bootstrap-dashboard" target="_blank" class="btn btn-info btn-block">Get Free Demo</a>
                </div>
                <div class="">
                    <a href="http://www.creative-tim.com/product/light-bootstrap-dashboard-pro" target="_blank" class="btn btn-info btn-block btn-fill">Buy Now!</a>
                </div>
            </li>

            <li class="header-title">Thank you for 452 shares!</li>

            <li class="button-container">
                <button id="twitter" class="btn btn-social btn-twitter btn-round"><i class="fa fa-twitter"></i> &middot; 182</button>
                <button id="facebook" class="btn btn-social btn-facebook btn-round"><i class="fa fa-facebook-square"> &middot; 270</i></button>
            </li>

        </ul>
    </div>
</div>

</body>

    <!--   Core JS Files and PerfectScrollbar library inside jquery.ui   -->
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery-ui.min.js" type="text/javascript"></script>
	<script src="../js/bootstrap.min.js" type="text/javascript"></script>


	<!--  Forms Validations Plugin -->
	<script src="../js/jquery.validate.min.js"></script>

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
        var $table = $('#bootstrap-table');

        function operateFormatter(value, row, index) {
            return [
                '<a rel="tooltip" title="View" class="btn btn-simple btn-info btn-icon table-action view" href="javascript:void(0)">',
                    '<i class="fa fa-image"></i>',
                '</a>',
                '<a rel="tooltip" title="Edit" class="btn btn-simple btn-warning btn-icon table-action edit" href="javascript:void(0)">',
                    '<i class="fa fa-edit"></i>',
                '</a>',
                '<a rel="tooltip" title="Remove" class="btn btn-simple btn-danger btn-icon table-action remove" href="javascript:void(0)">',
                    '<i class="fa fa-remove"></i>',
                '</a>'
            ].join('');
        }

        $().ready(function(){
            window.operateEvents = {
                'click .view': function (e, value, row, index) {
                    info = JSON.stringify(row);

                    swal('You click view icon, row: ', info);
                    console.log(info);
                },
                'click .edit': function (e, value, row, index) {
                    info = JSON.stringify(row);

                    swal('You click edit icon, row: ', info);
                    console.log(info);
                },
                'click .remove': function (e, value, row, index) {
                    console.log(row);
                    $table.bootstrapTable('remove', {
                        field: 'id',
                        values: [row.id]
                    });
                }
            };

            $table.bootstrapTable({
                toolbar: ".toolbar",
                clickToSelect: true,
                showRefresh: true,
                search: true,
                showToggle: true,
                showColumns: true,
                pagination: true,
                searchAlign: 'left',
                pageSize: 8,
                clickToSelect: false,
                pageList: [8,10,25,50,100],

                formatShowingRows: function(pageFrom, pageTo, totalRows){
                    //do nothing here, we don't want to show the text "showing x of y from..."
                },
                formatRecordsPerPage: function(pageNumber){
                    return pageNumber + " rows visible";
                },
                icons: {
                    refresh: 'fa fa-refresh',
                    toggle: 'fa fa-th-list',
                    columns: 'fa fa-columns',
                    detailOpen: 'fa fa-plus-circle',
                    detailClose: 'fa fa-minus-circle'
                }
            });

            //activate the tooltips after the data table is initialized
            $('[rel="tooltip"]').tooltip();

            $(window).resize(function () {
                $table.bootstrapTable('resetView');
            });


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
