<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_ViewReorderReport.aspx.cs" Inherits="Team09LogicU.Pages.SC_ViewReorderReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <form id="form1" runat="server">
        <link href="../css/window.css" rel="stylesheet" />
        <script src="../js/window.js"></script>
        <script src="../js/jquery-1.7.1.min.js"></script>
        <asp:GridView ID="GridView_reorderListBySup" runat="server" CssClass="table bootstrap-table table-hover table-striped" HeaderStyle-CssClass=" content text-uppercase  "
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" EmptyDataText="The Reorder List is Empty!">
            <Columns>
                <asp:TemplateField HeaderText="Supplier ID" Visible="True">
                    <ItemTemplate>
                        <asp:Label ID="lblSupID" runat="server" Text='<%# Eval("supplierID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Staff Name" Visible="True">
                    <ItemTemplate>
                        <asp:Label ID="lblStaff" runat="server" Text='<%# Eval("staffName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Order Date" Visible="True">
                    <ItemTemplate>
                        <asp:Label ID="lblOrderDate" runat="server" Text='<%# Eval("orderDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton_ViewPO" runat="server" CausesValidation="False" CommandName="Select" Text="View Pruchase Order" OnClick="LinkButton_ViewPO_Click"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass=" content text-uppercase  " />
        </asp:GridView>
         <asp:Button ID="btnSubmit" runat="server" Text="Submit Order" CssClass="btn btn-primary btn-fill btn-wd " OnClick="btnSubmit_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel and Back" CssClass="btn btn-primary btn-fill btn-wd " OnClick="btnCancel_Click" />
    </form>

</asp:Content>
