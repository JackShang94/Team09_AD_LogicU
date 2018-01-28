<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="SC_Inv_ViewInventoryList.aspx.cs" Inherits="Team09LogicU.Pages.SC_Inv_StockManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Stock Management
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <form id="form1" runat="server">

        <div class="row">
            <div class="col-lg-12">
                <div class="card">
                    <div class="container">
                        
                                <div class="col-lg-3" style=" margin-top:20px;margin-bottom:20px">
                                    <asp:Label ID="Label3" runat="server" CssClass="category" Text=" Category:"></asp:Label>
                                    <asp:DropDownList ID="DropDownList_cat" runat="server" CssClass="form-control"  AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_cat_SelectedIndexChanged" ></asp:DropDownList>
                                </div>
                    <div class="col-lg-10">
                                        <asp:GridView ID="GridView_stock" runat="server" PageSize="5" OnPageIndexChanging="GridView_stock_PageIndexChanging" OnRowCommand="GridView_stock_RowCommand"  OnRowEditing="GridView_stock_RowEditing" CssClass="table bootstrap-table table-hover table-striped" HeaderStyle-CssClass=" content text-uppercase  " AllowPaging="True" EditRowStyle-CssClass="btn btn-warning btn-fill fa fa-edit"
                                            CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView_stock_SelectedIndexChanged">
                                            <Columns>
                                                <asp:TemplateField HeaderText="View" ItemStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="View" Text="View" runat="server" CssClass="btn btn-default btn-xs" CommandName="Edit" OnClientClick="Edit?"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerTemplate>
        <br />
          <div class="col-lg-12 pull-left">
         <div class="col-lg-1" style="width:100px">
         <asp:Label ID="lblPage" runat="server" Text='<%# "Page:" + (((GridView)Container.NamingContainer).PageIndex + 1)  + "/" + (((GridView)Container.NamingContainer).PageCount)  %> '></asp:Label></div>
         <div class="col-lg-1" style="width:40px">
         <asp:LinkButton ID="lbnFirst" runat="Server" Text="First" CssClass="btn btn-xs btn-success"   Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="First" ></asp:LinkButton></div>
        <div class="col-lg-1" style="width:40px" >
        <asp:LinkButton ID="lbnPrev" runat="server" Text="<<"  CssClass="btn btn-xs btn-success"  Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="Prev"  ></asp:LinkButton></div>
         <div class="col-lg-1" style="width:40px;height:80px;margin-right:-10px;margin-left:-5px;margin-top:-10px" >
            <asp:TextBox runat="server" CssClass="form-control text-center " Width="40px" Text='<%# (((GridView)Container.NamingContainer).PageIndex + 1) %>'  ID="inPageNum"></asp:TextBox></div>
        <div class="col-lg-1" style="width:40px; margin-left:20px" >
            <asp:LinkButton ID="lbnNext" runat="Server" Text=">>"  CssClass="btn btn-xs btn-success"  Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next" ></asp:LinkButton>
         </div><div class="col-lg-1" style="width:40px;margin-left:-10px">
            <asp:LinkButton ID="lbnLast" runat="Server" Text="Last"  CssClass="btn btn-xs btn-success"   Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last" ></asp:LinkButton></div>
              <div class="col-lg-1" style="width:40px">
             <asp:Button ID="Button1" CommandName="go"  CssClass="btn btn-xs btn-success"  Text="GO" runat="server" />
         </div><br />
     </PagerTemplate>
                                        </asp:GridView>
                                        <alternatingrowstyle backcolor="White" />
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
