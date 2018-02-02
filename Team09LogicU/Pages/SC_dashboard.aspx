<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_dashboard.aspx.cs" Inherits="Team09LogicU.Pages.SC_dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Dashboard
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <script src="../js/googlechart.js"></script>
    <p runat="server" id="chartData"></p>
    <div class="row">
        <div class="col-lg-5">
            <div class="card">
                <div class=" container"  >
                             <div  class=" col-lg-5 " style="margin:20px 0 20px 0">
                                 <asp:Label ID="Labeltxtadjv" CssClass="category" runat="server" Text="Choose Department: "></asp:Label>
                                  <asp:DropDownList ID="dept_dropList" CssClass="form-control" Width="50%"   runat="server" OnSelectedIndexChanged="deptDropDownList_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                             <div class=" col-lg-5" id="chart1"></div></div>
                  
                    
            </div></div>
        </div>
   
        <div class="col-lg-5">
            <div class="card">
                <div class=" container"  >
                            
                                <div class=" col-lg-6" id="piechart" style="margin:20px 0 20px 0"></div>
                   
                    
            </div></div>
        </div>
  <div class="col-lg-5">
            <div class="card">
                <div class=" container"  >
                            
                                <div class=" col-lg-6" id="repTable" style="margin:20px 0 20px 0" ></div>
                   
                    
            </div></div>
        </div>
        <div class="col-lg-5">
            <div class="card">
                <div class=" container"  >
                             <div  class=" col-lg-6 " style="margin:20px 0 20px 0">
                                <div class=" col-lg-6" id="outstandingChart"></div></div>
                    
                   
            </div></div>
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
                   var data = google.visualization.arrayToDataTable(dataChart);
                   var piedata = google.visualization.arrayToDataTable(pieData);
                   var repdata = google.visualization.arrayToDataTable(deptRepData);
                   var outdata = google.visualization.arrayToDataTable(outstandingData);

                   // Set chart options
                   var options = {
                       'title': 'Trend Analysis Report',
                       'width': 400,
                       'height': 300
                   };
                   var optionpie = {
                       'title': 'Category Pie Chart',
                       'width': 450,
                       'height': 400
                   };
                   var optionTable = {
                       'title': 'Department Rep Information',
                       'width': 450,
                       'height': 400
                   };
                   var optionOut = {
                       'title': 'Department Rep Information',
                       'width': 400,
                       'height': 300
                   };

                   // Instantiate and draw our chart, passing in some options.
                   var chart = new google.visualization.LineChart(document.getElementById('chart1'));
                   chart.draw(data, options);
                   var Piechart = new google.visualization.PieChart(document.getElementById('piechart'));
                   Piechart.draw(piedata, optionpie);
                   var Table = new google.visualization.Table(document.getElementById('repTable'));
                   Table.draw(repdata, optionTable);
                   var Barchart = new google.visualization.BarChart(document.getElementById('outstandingChart'));
                   Barchart.draw(outdata, optionOut);
                  
               }
    </script>
</asp:Content>
