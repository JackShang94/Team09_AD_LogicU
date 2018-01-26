<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_GenerateReorderReport.aspx.cs" Inherits="Team09LogicU.Pages.SC_GenerateReorderReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="../css/window.css" rel="stylesheet" />
    <script src="../js/jquery-1.7.1.min.js"></script>
    <script src="../js/window.js"></script>
    <form id="form1" runat="server">
        <div class="col-lg-10" style="margin-bottom: 20px">
            <div class="col-lg-3" style="margin-top: 20px">
                <asp:Label ID="lblDisplay1" runat="server" Text=" Please select the month" CssClass="category"></asp:Label>
                <br>
                <asp:TextBox ID="txtMonth" runat="server" Width="90%" CssClass="form-control datepicker" TextMode="Month"></asp:TextBox>
            </div>
            <br>
            <asp:Button ID="btnView" runat="server" Text="View" CssClass="btn btn-primary btn-fill btn-wd " OnClick="btnView_Click" />
            <br>
            <asp:GridView ID="GridView_ReorderReport" runat="server" CssClass="table bootstrap-table table-hover table-striped" HeaderStyle-CssClass=" content text-uppercase  " AutoGenerateColumns="False" EditRowStyle-CssClass="btn btn-warning btn-fill fa fa-edit" CellPadding="4" ForeColor="#333333" GridLines="None" EmptyDataText=" No record found!">
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
            <br>
            <br>
            <p class="category">
                <asp:Label ID="lblDisplay2" runat="server" Text="Total: " Visible="False"></asp:Label>
                <asp:Label ID="lblTotal" runat="server"></asp:Label>
                <br>
                <br>

                <asp:Button ID="btnGenerate" runat="server" Text="Generate Report" CssClass="btn btn-primary btn-fill btn-wd " OnClick="btnGenerate_Click" Visible="False" />
        </div>

    </form>
</asp:Content>
