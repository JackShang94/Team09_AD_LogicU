<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_Inv_ManageReorder.aspx.cs" Inherits="Team09LogicU.Pages.SC_Inv_ManageReorder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Reorder
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <form id="form1" runat="server">

        <div class="row">
            <div class="col-md-9 container-fluid">
                <div class="card">
                    <div class="content">
                        <div class=" form-group" style="height: 25px; width: 100%">

                            <asp:CheckBox ID="CheckBox1" runat="server" CssClass="checkbox" AutoPostBack="true" BackColor="Azure" Text="Select the items with stock below Reorder Level" OnCheckedChanged="CheckBox1_CheckedChanged" Style="left: 0px; top: 0px" />

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

                            <div class="content">
                                <div class="container-fluid">
                                    <div class="content">
                                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                        <asp:GridView ID="GridView_reorderList" runat="server" CssClass="table bootstrap-table table-hover table-striped" HeaderStyle-CssClass=" content text-uppercase  " AllowPaging="True" 
                                            DataKeyNames="itemID" AutoGenerateColumns="False" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating" OnRowDataBound="RowDataBound"
                                            CellPadding="4" ForeColor="#333333" GridLines="None" EnableViewState="False">

                                            <Columns>
                                                <asp:TemplateField HeaderText="ItemID" SortExpression="SortedAscendingHeaderStyle">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblItemID" runat="server" Text='<%# Eval("itemID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Description">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("description") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Unit of Measure">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUnitOfMeasure" runat="server" Text='<%# Eval("unitOfMeasure") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Current Stock">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblQtyOnHand" runat="server" Text='<%# Eval("qtyOnHand") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Reorder Level">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReorderLevel" runat="server" Text='<%# Eval("reorderLevel") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Reorder Quantity">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReorderQty" runat="server" Text='<%# Eval("reorderQty") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Order Quantity">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOrderQty" runat="server" Text='0'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlSuppliers" runat="server"></asp:DropDownList>
                                                        <asp:TextBox ID="txtOrderQty" CssClass="form-control" Text ="0" runat="server" BackColor="Azure"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                            ControlToValidate="txtOrderQty" ForeColor="Red" Display="Dynamic"
                                                            ErrorMessage="RequiredFieldValidator">Quantity is required.</asp:RequiredFieldValidator>
                                                        <asp:CompareValidator ID="cv" runat="server" ControlToValidate="txtOrderQty" Type="Integer"
                                                            Operator="DataTypeCheck" Display="Dynamic" ErrorMessage="Quantity entered must be a whole number" ForeColor="Red" />
                                                        <asp:RangeValidator ID="RangeValidator1" runat="server" Display="Dynamic"
                                                            ErrorMessage="RangeValidator" ControlToValidate="txtOrderQty"
                                                            ForeColor="Red" Type="Integer"
                                                            MaximumValue="10000" MinimumValue="0">Please Check Quantity.</asp:RangeValidator>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnEdit" CssClass="btn btn-xs btn-default" runat="server" CommandName="Edit" Text="Edit" EnableViewState="True" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Button ID="btnUpdate" CssClass="btn btn-xs btn-success" runat="server" CommandName="Update" Text="Update" />
                                                        <asp:Button ID="btnCancel" CssClass="btn btn-xs btn-default" runat="server" CommandName="Cancel" Text="Cancel" />
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                        </asp:GridView>
                                        <alternatingrowstyle backcolor="White" />

                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>

                            </div>
                            <!-- end content-->

                        </div>
                        <!-- end col-md-12 -->
                    </div>
                    <!-- end row -->

                </div>
            </div>
            <asp:Button ID="BtnSubmit" runat="server" Text="Add to Reorder List" CssClass="btn btn-primary btn-fill btn-wd " />
            <asp:Button ID="BtnCancel" runat="server" Text="Cancel" CssClass="btn btn-default  btn-fill btn-wd" />

        </div>
    </form>

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

</asp:Content>
