<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_PurchaseOrderHistoryDetail.aspx.cs" Inherits="Team09LogicU.Pages.SC_PurchaseOrderHistoryDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <link href="../css/window.css" rel="stylesheet" />
    <script src="../js/jquery-1.7.1.min.js"></script>
    <script src="../js/window.js"></script>

    <form id="form1" runat="server">
        <div class="row">
            <div class="col-lg-12">
                <div class="card">
                    <div class="header">
                        <p class="category">
                            <asp:Label ID="Label_poID" runat="server" Text="Purchase Order ID: "></asp:Label>
                            <asp:Label ID="lblpoID" runat="server"></asp:Label>
                        <p class="category">
                            <asp:Label ID="Label_SupplierName" runat="server" Text="Supplier: "></asp:Label>
                            <asp:Label ID="lblSupplierName" runat="server"></asp:Label>
                        <p class="category">
                            <asp:Label ID="Label_Name" runat="server" Text="Order By: "></asp:Label>
                            <asp:Label ID="lblName" runat="server"></asp:Label>

                        <p class="category">
                            <asp:Label ID="Label_Date" runat="server" Text="Order Date: "></asp:Label>
                            <asp:Label ID="lblOrderDate" runat="server"></asp:Label>
                    </div>
                    <div class=" container">
                        <div class="col-lg-10">
                            <div class="col-lg-3" style="margin-top: 20px">
                            </div>
                            <div class="col-lg-3" style="margin-top: 20px">
                            </div>
                            <div class="col-lg-6" style="margin-top: 20px">



                                <br>
                            </div>
                            <div class="col-lg-3" style="margin-bottom: 40px">
                            </div>
                        </div>

                        <div class="col-lg-10" style="margin-bottom: 20px">
                            <asp:GridView ID="GridView_PODetail" runat="server" CssClass="table bootstrap-table table-hover table-striped" HeaderStyle-CssClass=" content text-uppercase  " AutoGenerateColumns="False" EditRowStyle-CssClass="btn btn-warning btn-fill fa fa-edit" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Item ID" Visible="True">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemID" runat="server" Text='<%# Bind("itemID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="description" HeaderText="Description" />
                                    <asp:BoundField DataField="orderQty" HeaderText="Order Quantity" />
                                    <asp:BoundField DataField="price" HeaderText="Price" />
                                    <asp:BoundField DataField="totalAmount" HeaderText="Total Amount" />
                                </Columns>
                                <HeaderStyle CssClass=" content text-uppercase"></HeaderStyle>
                            </asp:GridView>

                            <p class="category">
                                <asp:Label ID="lblDisplay" runat="server" Text="Total: "></asp:Label>
                                <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                <br>
                                <br>

                                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-primary btn-fill btn-wd " OnClick="btnBack_Click" />
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
        $().ready(function () {

            // Init DatetimePicker
            demo.initFormExtendedDatetimepickers();
            //init alert


        });
    </script>
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-46172202-1', 'auto');
        ga('send', 'pageview');

    </script>
</asp:Content>
