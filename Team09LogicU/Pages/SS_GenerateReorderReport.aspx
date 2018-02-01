<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreSupervisor.Master" AutoEventWireup="true" CodeBehind="SS_GenerateReorderReport.aspx.cs" Inherits="Team09LogicU.Pages.SS_GenerateReorderReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Reorder Report
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script src="../js/googlechart.js"></script>
    <div class="row">
        <div class="col-lg-8">
            <div class="card">
                <div class=" container">
                    <div class=" col-lg-3" style="margin: 20px 0 20px 0">
                        <asp:Label ID="Labeltxtadjv" CssClass="category" runat="server" Text="Adjustment Voucher ID: "></asp:Label>
                        <asp:TextBox ID="txtMonth" CssClass=" form-control" runat="server" Width="90%" TextMode="Date"></asp:TextBox>
                    </div>
                    <div class=" col-lg-4 " style="margin: 40px 0 20px 0">
                        <asp:Button ID="btnSearch" runat="server" Text="View" CssClass="btn btn-warning btn-fill btn-wd " OnClick="btnView_Click" />
                        <asp:Button ID="btnPrint" runat="server" Text="Print Report" CssClass="btn btn-primary btn-fill btn-wd " OnClientClick="return Print();" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <p runat="server" id="chartData"></p>
    <div id="PrintContent" runat="server">
        <div class="col-lg-4">
            <div id="chart1"></div>
        </div>
        <div class="col-lg-4">
            <div id="chart2"></div>
        </div>
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
            var columnChartData = google.visualization.arrayToDataTable(chart1Data);
            var tableChartData = google.visualization.arrayToDataTable(chart2Data);
            // Set chart options
            var options = {
                'title': 'How Much Pizza I Ate Last Night',
                'width': 400,
                'height': 300
            };
            // Instantiate and draw our chart, passing in some options.
            var chart1 = new google.visualization.BarChart(document.getElementById('chart1'));
            chart1.draw(columnChartData, options);
            var chart2 = new google.visualization.Table(document.getElementById('chart2'));
            chart2.draw(tableChartData, { showRowNumber: true, width: 400, height: 300 });
        }
    </script>
    <script type="text/javascript">
        function Print() {
            var pc = document.getElementById("<%=PrintContent.ClientID%>");
            var pw = window.open('', '', 'width=1000,height=800');
            pw.document.write(pc.innerHTML);
            pw.document.close();
            setTimeout(function () { pw.print(); }, 500);
            return false;
        }
    </script>
</asp:Content>
