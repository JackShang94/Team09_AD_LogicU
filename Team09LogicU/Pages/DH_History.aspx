<%@ Page Title="" Language="C#" MasterPageFile="~/pages/DepartmentHead.Master" AutoEventWireup="true" CodeBehind="DH_History.aspx.cs" Inherits="Team09LogicU.pages.DH_History" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    History
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <form id="form1" runat="server">
        <div class="row">
            <div class="col-md-9 container-fluid" style="left: 0px; top: 0px; width: 179px; height: 185px">
                <div class="card">
                    <div class="content">
                        <div class=" form-group">
                            <div class="pull-left search">
                                <div class="header">
                                    <p class="category">
                                            <asp:TextBox ID="txtFrom" runat="server" TextMode="Date"></asp:TextBox><br>

                                            <asp:Label ID="lblTo" runat="server" Text=" To:"></asp:Label><br>
                                            <asp:TextBox ID="txtTo" runat="server" TextMode="Date"></asp:TextBox><br>

                                            <asp:DropDownList ID="ddlStaff" runat="server"></asp:DropDownList><br>
                                    </p>
       

                                <div class="pull-right" style="width: 20%">
                                    <asp:Button ID="btnSearch" runat="server" Width="100%" Text="Search" CssClass="btn btn-primary btn-fill btn-wd" OnClick="btnSearch_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="content">
            <div class="container-fluid">
                <div class="content">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="card">
                                <div class="content">
                                    <div class="container-fluid">
                                        <div class="content">
                                            <asp:GridView ID="GridView_ReqHistory" runat="server" CssClass="table bootstrap-table table-hover table-striped" HeaderStyle-CssClass=" content text-uppercase  " AutoGenerateColumns="False" AllowPaging="True" EditRowStyle-CssClass="btn btn-warning btn-fill fa fa-edit" CellPadding="4" ForeColor="#333333" GridLines="None" EmptyDataText="There are no Requisitions history record">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Requisition ID" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblReqId" runat="server" Text='<%# Bind("requisitionID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="staffName" HeaderText="Requested Staff" />
                                                    <asp:BoundField DataField="requisitionDate" HeaderText="Date Submitted" />
                                                    <asp:BoundField DataField="status" HeaderText="Status" />
                                                    <asp:TemplateField HeaderText="Action" ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton_Select" runat="server" CausesValidation="False" CommandName="Select" Text="View" OnClick="LinkButton_View_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass=" content text-uppercase"></HeaderStyle>
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

                    </div>
                </div>
            </div>

        </div>

        <div class="fixed-plugin">
            <div class="dropdown">
                <a href="#" data-toggle="dropdown">
                    <i class="fa fa-cog fa-2x"></i>
                </a>
                <ul class="dropdown-menu">
                    <li class="header-title">Configuration</li>
                    <li class="adjustments-line">
                        <a href="javascript:void(0)" class="switch-trigger">
                            <p>Sidebar Image</p>
                            <div class="switch switch-sidebar-image"
                                data-on-label="ON"
                                data-off-label="OFF">
                                <input type="checkbox" checked />
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
                                <input type="checkbox" />
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
                                <input type="checkbox" />
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
                        <button id="twitter" class="btn btn-social btn-twitter btn-round"><i class="fa fa-twitter"></i>&middot; 182</button>
                        <button id="facebook" class="btn btn-social btn-facebook btn-round"><i class="fa fa-facebook-square">&middot; 270</i></button>
                    </li>

                </ul>
            </div>
        </div>



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
            $(document).ready(function () {
                $('#datatables').DataTable({
                    "pagingType": "full_numbers",
                    "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                    responsive: true,
                    language: {
                        search: "_INPUT_",
                        searchPlaceholder: "Search records",
                    }

                });


                var table = $('#datatables').DataTable();

                // Edit record
                table.on('click', '.edit', function () {
                    $tr = $(this).closest('tr');

                    var data = table.row($tr).data();
                    alert('You press on Row: ' + data[0] + ' ' + data[1] + ' ' + data[2] + '\'s row.');
                });

                // Delete a record
                table.on('click', '.remove', function (e) {
                    $tr = $(this).closest('tr');
                    table.row($tr).remove().draw();
                    e.preventDefault();
                });

                //Like record
                table.on('click', '.like', function () {
                    alert('You clicked on Like button');
                });
            });

        </script>



    </form>


</asp:Content>
