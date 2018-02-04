<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_O_InventoryStatusReport.aspx.cs" Inherits="Team09LogicU.Pages.SC_O_InventoryStatusReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Inventory Status Report
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script src="../js/googlechart.js"></script>
        <p runat="server" id="chartData"></p>
    <div class="row">
    <div class="col-lg-10">
        <div class="card">
        <asp:GridView ID="InventoryStatusGridView"  runat="server" PageSize="4" AllowPaging="true"  OnRowCommand="InventoryStatusGridView_RowCommand" OnPageIndexChanging="InventoryStatusGridView_PageIndexChanging"  AutoGenerateColumns="false"  HeaderStyle-CssClass="text-uppercase" CssClass="table table-striped table-hover" OnSelectedIndexChanged="inventoryStatusGridView_SelectedIndexChanged" EmptyDataText="There is no information" SelectedRowStyle-BackColor="#eef2fd">
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
             <PagerTemplate>
                                <br />
                                <div class="col-lg-10">
                                    <div class="col-lg-3 " style="width:18%">
                                     <asp:Label ID="lblPage" runat="server" Text='<%# "Page:" + (((GridView)Container.NamingContainer).PageIndex + 1)  + "/" + (((GridView)Container.NamingContainer).PageCount)  %> '></asp:Label>
                                     <asp:LinkButton ID="lbnFirst" runat="Server" Text="First" CssClass="btn btn-xs btn-default" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="First"></asp:LinkButton>
                                    <asp:LinkButton ID="lbnPrev" runat="server" Text="<<" CssClass="btn btn-xs btn-default" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="Prev"></asp:LinkButton>
                                   </div><div class="col-lg-1" style="Width:15%"><asp:TextBox runat="server" CssClass="form-control text-center "  ID="inPageNum" Text='<%# ((GridView)Container.NamingContainer).PageIndex +1 %>'></asp:TextBox>
                                    </div><div class="col-lg-3 ">
                                       <asp:LinkButton ID="lbnNext" runat="Server" Text=">>" CssClass="btn btn-xs btn-default" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next"></asp:LinkButton>
                                   <asp:LinkButton ID="lbnLast" runat="Server" Text="Last" CssClass="btn btn-xs btn-default" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last"></asp:LinkButton>
                                     <asp:Button ID="Button1" CommandName="go" CssClass="btn btn-xs btn-default" Text="GO" runat="server" />
                                    </div></div>
                                    
                            </PagerTemplate>
        </asp:GridView>
            </div></div>
    
    
    <div class="col-lg-8 pull-left  "><div id="PrintContent"  runat="server">
     <asp:Label ID="title_" CssClass="h4 " runat="server" Text="Inventory Status Report"></asp:Label><br />
        
    <div id="chart1" style="margin:20px 0 20px 0"></div></div>
  <asp:Button ID="Button1" runat="server" Text="Print Report" CssClass="btn btn-primary btn-fill btn-wd "  OnClientClick="return Print();" />    
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
            var data = google.visualization.arrayToDataTable(chart1Data);

            // Set chart options
            var options = {
                'title': 'Inventory Status Report',
                'width': 600,
                'height': 400
            };

            // Instantiate and draw our chart, passing in some options.
            var chart1 = new google.visualization.LineChart(document.getElementById('chart1'));
            chart1.draw(data, options);
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
