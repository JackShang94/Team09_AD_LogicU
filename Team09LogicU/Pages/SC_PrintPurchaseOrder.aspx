<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_PrintPurchaseOrder.aspx.cs" Inherits="Team09LogicU.Pages.SC_PrintPurchaseOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <form id="form1" runat="server">
        <asp:GridView ID="GridView_PurchaseOrder" runat="server" CssClass="table bootstrap-table table-hover table-striped" HeaderStyle-CssClass=" content text-uppercase  "
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <Columns>
                <asp:TemplateField HeaderText="Item ID" Visible="True">
                    <ItemTemplate>
                        <asp:Label ID="lblItemID" runat="server" Text='<%# Eval("itemID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description" Visible="True">
                    <ItemTemplate>
                        <asp:Label ID="lblDes" runat="server" Text='<%# Eval("description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Order Quantity" Visible="True">
                    <ItemTemplate>
                        <asp:Label ID="lblOrderQty" runat="server" Text='<%# Eval("orderQty") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price" Visible="True">
                    <ItemTemplate>
                        <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("price") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Amount" Visible="True">
                    <ItemTemplate>
                        <asp:Label ID="lblTotal" runat="server" Text='<%# Eval("totalAmount") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass=" content text-uppercase  " />
        </asp:GridView>
        <asp:Button ID="btnPrintPO" runat="server" Text="Print" CssClass="btn btn-primary btn-fill btn-wd " OnClick="btnPrintPO_Click" />
    </form>
</asp:Content>
