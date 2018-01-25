<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreManager.Master" AutoEventWireup="true" CodeBehind="SM_SearchItem.aspx.cs" Inherits="Team09LogicU.Pages.SM_SearchItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    View Item
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-md-8">
                <div class="card">
                    <div class="content">
                        <div class="form-group" style="height: 25px; width: 100%">
                            <div class="pull-left search" style="width: 75%">
                                <asp:TextBox ID="textbox_Search" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="pull-right" style="width: 20%">
                                <asp:Button ID="Button_search" runat="server" Width="100%" Text="Search" CssClass="btn btn-primary btn-fill btn-wd" OnClick="Button_search_Click" />
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>

        

                <div class="row">
                    <div class="col-md-12">
                        <div class="card">
                            <div class=" container">
                                <div class="col-lg-10" style="margin:20px 0 0 -40px">
                                <asp:Button ID="Btn_Add" runat="server" Text="Add New Item" CssClass="btn btn-warning btn-fill btn-wd " OnClick="Btn_Add_Click" />
                                </div>
                                <div class="col-lg-12" style="margin-top:20px;margin-left:-40px">
                                <asp:GridView  ID="GridView_itemList" runat="server" OnPageIndexChanging="GridView_itemList_PageIndexChanging" OnRowCommand="GridView_itemList_RowCommand" PageSize="5" OnRowEditing="GridView_itemList_RowEditing"
                                    CssClass="table bootstrap-table table-hover table-striped" HeaderStyle-CssClass=" content text-uppercase  " AllowPaging="True" EditRowStyle-CssClass="btn btn-warning btn-fill fa fa-edit"
                                    CellPadding="4" ForeColor="#333333" GridLines="None">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Edit" ItemStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="Edit" runat="server" CssClass="btn btn-xs btn-default" Text="Edit" CommandName="Edit" OnClientClick="Edit?" ></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    
                                    <HeaderStyle CssClass=" content text-uppercase  "></HeaderStyle>
                                    <AlternatingRowStyle BackColor="White" />
                                    <PagerTemplate>
        <br />
          <div class="col-lg-12 pull-left">
         <div class="col-lg-1" style="width:100px">
         <asp:Label ID="lblPage" runat="server" Text='<%# "Page:" + (((GridView)Container.NamingContainer).PageIndex + 1)  + "/" + (((GridView)Container.NamingContainer).PageCount)  %> '></asp:Label></div>
         <div class="col-lg-1" style="width:40px">
         <asp:LinkButton ID="lbnFirst" runat="Server" Text="First" CssClass="btn btn-xs btn-warning"   Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="First" ></asp:LinkButton></div>
        <div class="col-lg-1" style="width:40px" >
        <asp:LinkButton ID="lbnPrev" runat="server" Text="<<"  CssClass="btn btn-xs btn-warning"  Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="Prev"  ></asp:LinkButton></div>
         <div class="col-lg-1" style="width:45px;height:80px;margin-right:-10px;margin-left:-5px;margin-top:-10px" >
            <asp:TextBox runat="server" CssClass="form-control text-left " Width="45px"  ID="inPageNum"></asp:TextBox></div>
        <div class="col-lg-1" style="width:40px; margin-left:20px" >
            <asp:LinkButton ID="lbnNext" runat="Server" Text=">>"  CssClass="btn btn-xs btn-warning"  Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next" ></asp:LinkButton>
         </div><div class="col-lg-1" style="width:40px;margin-left:-10px">
            <asp:LinkButton ID="lbnLast" runat="Server" Text="Last"  CssClass="btn btn-xs btn-warning"   Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last" ></asp:LinkButton></div>
              <div class="col-lg-1" style="width:40px">
             <asp:Button ID="Button1" CommandName="go"  CssClass="btn btn-xs btn-warning"  Text="GO" runat="server" />
         </div><br />
     </PagerTemplate>
                                </asp:GridView>

                                </div>



                            </div>

                        </div>
                    </div>
                    <!-- end content-->
                </div>
                <!--  end card  -->
            </div>
            <!-- end col-md-12 -->
        </div>
        <!-- end row -->

       

   



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
