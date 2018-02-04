<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreSupervisor.Master" AutoEventWireup="true" CodeBehind="SS_TrendAnalysisReport.aspx.cs" Inherits="Team09LogicU.Pages.SS_TrendAnalysisReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
Trend Analysis Report
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <script src="../js/googlechart.js"></script>
     <div class="row"> 
                    <div class="col-lg-10">
                        <div class="card">
                             <div class=" container" >
                             <div  class=" col-lg-3" style="margin:20px 0 20px 0">
                                 <asp:Label ID="Labeltxtadjv" CssClass="category" runat="server" Text="Choose Department: "></asp:Label>
                                  <asp:DropDownList ID="dept_dropList" CssClass="form-control" Width="100%"   runat="server" OnSelectedIndexChanged="deptDropDownList_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                             </div>
                                 <div  class=" col-lg-4 " style="margin:40px 0 20px 0">                                                        
                                 <asp:Button ID="btnPrint" runat="server" Text="Print Report" CssClass="btn btn-primary btn-fill btn-wd "  OnClientClick="return Print();"  />    
                                 </div>
                             </div></div></div></div>
     
    <p runat="server" id="chartData"></p>
    <div id="PrintContent"  runat="server">
       
     <div class="col-lg-10 text-center" id="div2"  runat="server">
               <asp:Label ID="title_" CssClass="h4" runat="server" Text="Trend Analysis Report"></asp:Label><br />
                <asp:Label ID="date_" CssClass=" category" runat="server">Dep: <%=dept_dropList.SelectedValue %></asp:Label>
    </div>
          <div class="col-lg-10" style="margin-top:10px;margin-right:10px">
    <div id="chart1"></div></div>
        <div class="col-lg-10" style="margin-top:10px">
    <div id="chart2"></div></div>
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
            var data = google.visualization.arrayToDataTable(chartData);

            // Set chart options
            var options = {
                'title': 'Trend Analysis Report',
                'width': 900,
                'height': 400
            };

            // Instantiate and draw our chart, passing in some options.
            var chart1 = new google.visualization.BarChart(document.getElementById('chart1'));
            chart1.draw(data, options);
            var chart2 = new google.visualization.Table(document.getElementById('chart2'));
            chart2.draw(data, { showRowNumber: true, width: 900, height: 400 });
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
