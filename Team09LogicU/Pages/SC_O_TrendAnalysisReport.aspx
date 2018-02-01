<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_O_TrendAnalysisReport.aspx.cs" Inherits="Team09LogicU.Pages.SC_O_TrendAnalysisReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
Trend Analysis Report
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script src="../js/googlechart.js"></script>
     <asp:Button ID="btnGenerate" runat="server" Text="Print Report" CssClass="btn btn-primary btn-fill btn-wd "  OnClientClick="return Print();"  />    
    <p runat="server" id="chartData"></p>
    <div id="PrintContent"  runat="server">
    <div id="chart1"></div>
    </div>
    <script>
        // Load the Visualization API and the corechart package.
        google.charts.load('current', { 'packages': ['corechart'] });

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
                'width': 800,
                'height': 600
            };

            // Instantiate and draw our chart, passing in some options.
            var chart = new google.visualization.BarChart(document.getElementById('chart1'));
            chart.draw(data, options);
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
