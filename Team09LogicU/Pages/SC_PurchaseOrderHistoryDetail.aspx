<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_PurchaseOrderHistoryDetail.aspx.cs" Inherits="Team09LogicU.Pages.SC_PurchaseOrderHistoryDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    PO History Detail
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div id="PrintContent"  runat="server">
        <div class="row">
            <div class="col-lg-10">
                <div class="card">
                    <div class=" container">
                        <div class=" col-lg-4" style="margin-top:20px">
                            <asp:Label ID="Label_poID" runat="server"  Text="Purchase Order ID: "></asp:Label>
                            <asp:Label ID="lblpoID" runat="server" ></asp:Label></div>
                        <div class=" col-lg-6" style="margin-top:20px">
                            <asp:Label ID="Label_SupplierName"  runat="server" Text="Supplier: "></asp:Label>
                            <asp:Label ID="lblSupplierName"  runat="server"></asp:Label>
                            </div>
                        <div class=" col-lg-4" style="margin-bottom:20px">
                            <asp:Label ID="Label_Name" runat="server"  Text="Order By: "></asp:Label>
                            <asp:Label ID="lblName" runat="server" ></asp:Label>
                            </div>
                        <div class=" col-lg-6" style="margin-bottom:20px">
                            <asp:Label ID="Label_Date" runat="server" Text="Order Date: "></asp:Label>
                            <asp:Label ID="lblOrderDate" runat="server"></asp:Label>
                    </div>
                         <div class="col-lg-10">
                            <asp:GridView ID="GridView_PODetail" runat="server" Width="85%" CssClass="table bootstrap-table table-hover table-striped" HeaderStyle-CssClass=" content text-uppercase  " AutoGenerateColumns="False" EditRowStyle-CssClass="btn btn-warning btn-fill fa fa-edit" CellPadding="4" ForeColor="#333333" GridLines="None">
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
                             </div>
                            <div class=" col-lg-10" style="margin:20px 0 20px 0">
                                <asp:Label ID="lblDisplay" CssClass="h5" runat="server" Text="Total: "></asp:Label>
                                <asp:Label ID="lblTotal" CssClass="h5" runat="server"></asp:Label>
                                <br>
                                 </div></div>
                   </div></div></div>
                    <!-- end content-->
               </div>
    
     <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-primary btn-fill btn-wd " OnClientClick="return Print();"   />
      <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-default  btn-wd " OnClick="btnBack_Click" />   
    
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
