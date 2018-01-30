<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_GenerateReorderReport.aspx.cs" Inherits="Team09LogicU.Pages.SC_GenerateReorderReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  Reorder Report
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
     <div class="row">
           <div class="col-lg-10">
                <div class="card">
                    <div class=" container">
        
            <div class="col-lg-3" style="margin-top: 20px;margin-bottom:20px">
                <asp:Label ID="lblDisplay1" runat="server" Text=" Please select the month" CssClass="category"></asp:Label>
                
                <asp:TextBox ID="txtMonth" runat="server" CssClass="form-control" TextMode="Month"></asp:TextBox>
            </div>
            <div class="col-lg-3 pull-right" style="margin-top:40px;margin-bottom:20px;margin-right:20px">
            <asp:Button ID="btnView" runat="server" Text="View" CssClass="btn btn-warning btn-fill btn-wd " OnClick="btnView_Click" />
            </div>
           <div class="col-lg-10">
              
            <asp:GridView ID="GridView_ReorderReport" runat="server" CssClass="table bootstrap-table table-hover table-striped" HeaderStyle-CssClass=" content text-uppercase  " AutoGenerateColumns="False" EditRowStyle-CssClass="btn btn-warning btn-fill fa fa-edit" CellPadding="4" ForeColor="#333333" GridLines="None" EmptyDataText="There are no Item">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="poID" HeaderText="PO ID" />
                    <asp:BoundField DataField="orderDate" HeaderText="Order Date" />
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
           <div class="col-lg-10" style="margin:20px 0 20px 0">
                <asp:Label ID="lblDisplay2" runat="server" Text="Total: " CssClass="h5" Visible="False"></asp:Label>
                <asp:Label ID="lblTotal" runat="server" CssClass="h5"></asp:Label>
               </div></div></div>
                    </div></div></div>
    <div class="col-lg-10">
                <asp:Button ID="btnGenerate" runat="server" Text="Generate Report" CssClass="btn btn-primary btn-fill btn-wd " OnClick="btnGenerate_Click" Visible="False" />
       </div>

   
</asp:Content>
