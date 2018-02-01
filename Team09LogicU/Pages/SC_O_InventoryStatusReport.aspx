<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_O_InventoryStatusReport.aspx.cs" Inherits="Team09LogicU.Pages.SC_O_InventoryStatusReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Inventory Status Report
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="col-lg-10">
        <asp:GridView ID="InventoryStatusGridView" runat="server" AutoGenerateColumns="false" Style="margin: 20px 0px 20px 0px" HeaderStyle-CssClass="text-uppercase" CssClass="table table-striped table-hover" OnSelectedIndexChanged="inventoryStatusGridView_SelectedIndexChanged" EmptyDataText="There is no information" SelectedRowStyle-BackColor="#eef2fd">
            <Columns>
                <asp:TemplateField HeaderText="ItemID">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="ItemID" Text='<%#Eval("itemID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description" SortExpression="SortedAscendingHeaderStyle">
                    <ItemTemplate>
                        <asp:Label ID="ItemDescription" runat="server" Text='<%# Eval("description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Location">
                    <ItemTemplate>
                        <asp:Label ID="Location" runat="server" Text='<%# Eval("location") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Unit of measurement">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="Unitofmeasurement" Text='<%#Eval("unitOfMeasure") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity on hand">
                    <ItemTemplate>
                        <asp:Label ID="Quantityonhand" runat="server" Text='<%# Eval("qtyOnHand") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Reorder level">
                    <ItemTemplate>
                        <asp:Label ID="Reorderlevel" runat="server" Text='<%# Eval("reorderLevel") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowSelectButton="true" HeaderStyle-Font-Names="Action" ControlStyle-CssClass=" text-center btn btn-xs btn-primary" SelectText="show" ButtonType="Button" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="col-lg-10">
        <script src="../js/googlechart.js"></script>
        <p runat="server" id="chartData"></p>
        <div id="chart1"></div>
    </div>
    <script>
        // Load the Visualization API and the corechart package.
        google.charts.load('current', { 'packages': ['table'] });
        google.charts.load('current', { packages: ['corechart', 'bar'] });



        // Set a callback to run when the Google Visualization API is loaded.
        google.charts.setOnLoadCallback(drawChart);

        // Callback that creates and populates a data table,
        // instantiates the pie chart, passes in the data and
        // draws it.
        function drawChart() {

            // Create the data table.
            var data = google.visualization.arrayToDataTable(chart1Data);

            // Set chart options
            var options = {
                'title': 'How Much Pizza I Ate Last Night',
                'width': 1000,
                'height': 600
            };

            // Instantiate and draw our chart, passing in some options.
            var chart1 = new google.visualization.LineChart(document.getElementById('chart1'));
            chart1.draw(data, options);
        }
    </script>
</asp:Content>
