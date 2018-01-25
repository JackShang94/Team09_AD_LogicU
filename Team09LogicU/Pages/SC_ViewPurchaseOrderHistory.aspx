<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_ViewPurchaseOrderHistory.aspx.cs" Inherits="Team09LogicU.Pages.SC_ViewPurchaseOrderHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    View Purchase Order History
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <link href="../css/window.css" rel="stylesheet" />
    <script src="../js/jquery-1.7.1.min.js"></script>
    <script src="../js/window.js"></script>

    <form id="form1" runat="server">
        <div class="row">
            <div class="col-lg-12">
                <div class="card">
                    <div class=" container">
                        <div class="col-lg-10">
                            <div class="col-lg-3" style="margin-top: 20px">
                                <asp:label id="lblFrom" runat="server" text=" From:" cssclass="category"></asp:label>
                                <asp:textbox id="txtFrom" runat="server" width="90%" cssclass="form-control datepicker"></asp:textbox>
                                <br>
                            </div>
                            <div class="col-lg-3" style="margin-top: 20px">
                                <asp:label id="lblTo" runat="server" text=" To:" cssclass="category"></asp:label>
                                <br>
                                <asp:textbox id="txtTo" runat="server" width="90%" cssclass="form-control datepicker"></asp:textbox>
                                <br>
                            </div>
                            <div class="col-lg-6" style="margin-top: 20px">
                                <asp:label id="lblSelect" runat="server" text=" Select Supplier:" cssclass="category"></asp:label>

                                <asp:dropdownlist id="ddlSupplier" runat="server" width="40%" cssclass="form-control"></asp:dropdownlist>
                                <br>
                            </div>
                            <div class="col-lg-3" style="margin-bottom: 40px">
                                <asp:button id="btnSearch" runat="server" width="90%" text="Search" cssclass="btn btn-primary btn-fill btn-wd" onclick="btnSearch_Click" />

                            </div>
                        </div>

                        <div class="col-lg-10" style="margin-bottom: 20px">
                            <asp:gridview id="GridView_PurchaseOrder" runat="server" allowpaging="true" onpageindexchanging="GridView_PurchaseOrder_PageIndexChanging" onrowcommand="GridView_PurchaseOrder_RowCommand" cssclass="table bootstrap-table table-hover table-striped" headerstyle-cssclass=" content text-uppercase  " autogeneratecolumns="False" editrowstyle-cssclass="btn btn-warning btn-fill fa fa-edit" cellpadding="4" forecolor="#333333" gridlines="None" emptydatatext="There are no Purchase Order history record">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="PO ID" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblReqId" runat="server" Text='<%# Bind("poID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="supplierID" HeaderText="Supplier Name" />
                                                    <asp:BoundField DataField="orderBy" HeaderText="Order By" />
                                                    <asp:BoundField DataField="orderDate" HeaderText="Order Date" />
                                                    <asp:TemplateField HeaderText="Action" ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton_View" runat="server" CausesValidation="False" CommandName="Select" Text="View" OnClick="LinkButton_View_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
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
                                                        <asp:TextBox runat="server" CssClass="form-control text-center " Width="40px"  ID="inPageNum"></asp:TextBox></div>
                                                    <div class="col-lg-1" style="width:40px; margin-left:20px" >
                                                        <asp:LinkButton ID="lbnNext" runat="Server" Text=">>"  CssClass="btn btn-xs btn-success"  Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next" ></asp:LinkButton>
                                                     </div><div class="col-lg-1" style="width:40px;margin-left:-10px">
                                                        <asp:LinkButton ID="lbnLast" runat="Server" Text="Last"  CssClass="btn btn-xs btn-success"   Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last" ></asp:LinkButton></div>
                                                          <div class="col-lg-1" style="width:40px">
                                                         <asp:Button ID="Button1" CommandName="go"  CssClass="btn btn-xs btn-success"  Text="GO" runat="server" />
                                                     </div><br />
                                                 </PagerTemplate>
                                                <HeaderStyle CssClass=" content text-uppercase"></HeaderStyle>
                                            </asp:gridview>

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
