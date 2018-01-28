<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_PurchaseOrderHistoryDetail.aspx.cs" Inherits="Team09LogicU.Pages.SC_PurchaseOrderHistoryDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

        <div class="row">
            <div class="col-lg-12">
                <div class="card">
                    <div class="header">
                        <p class="category">
                            <asp:Label ID="Label_poID" runat="server" Text="Purchase Order ID: "></asp:Label>
                            <asp:Label ID="lblpoID" runat="server"></asp:Label>
                        <p class="category">
                            <asp:Label ID="Label_SupplierName" runat="server" Text="Supplier: "></asp:Label>
                            <asp:Label ID="lblSupplierName" runat="server"></asp:Label>
                        <p class="category">
                            <asp:Label ID="Label_Name" runat="server" Text="Order By: "></asp:Label>
                            <asp:Label ID="lblName" runat="server"></asp:Label>

                        <p class="category">
                            <asp:Label ID="Label_Date" runat="server" Text="Order Date: "></asp:Label>
                            <asp:Label ID="lblOrderDate" runat="server"></asp:Label>
                    </div>
                    <div class=" container">
                        <div class="col-lg-10">
                            <div class="col-lg-3" style="margin-top: 20px">
                            </div>
                            <div class="col-lg-3" style="margin-top: 20px">
                            </div>
                            <div class="col-lg-6" style="margin-top: 20px">



                                <br>
                            </div>
                            <div class="col-lg-3" style="margin-bottom: 40px">
                            </div>
                        </div>

                        <div class="col-lg-10" style="margin-bottom: 20px">
                            <asp:GridView ID="GridView_PODetail" runat="server" CssClass="table bootstrap-table table-hover table-striped" HeaderStyle-CssClass=" content text-uppercase  " AutoGenerateColumns="False" EditRowStyle-CssClass="btn btn-warning btn-fill fa fa-edit" CellPadding="4" ForeColor="#333333" GridLines="None">
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

                            <p class="category">
                                <asp:Label ID="lblDisplay" runat="server" Text="Total: "></asp:Label>
                                <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                <br>
                                <br>

                                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-primary btn-fill btn-wd " OnClick="btnBack_Click" />
                        </div>
                    </div>
                    <!-- end content-->
                </div>
                <!--  end card  -->
            </div>
            <!-- end col-md-12 -->
        </div>
        <!-- end row -->
</asp:Content>
