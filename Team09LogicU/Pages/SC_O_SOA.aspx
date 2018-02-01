<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_O_SOA.aspx.cs" Inherits="Team09LogicU.Pages.SC_O_SOA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    SOA Report
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row">
        <div class="col-lg-10">
            <div class="card">
                <div class=" container">

                    <div class="col-lg-3" style="margin-top: 20px">
                        <asp:Label ID="lblFrom" runat="server" Text=" From:" CssClass="category"></asp:Label>
                        <asp:TextBox ID="txtFrom" runat="server" CssClass="form-control " TextMode="Date"></asp:TextBox>
                        <br>
                    </div>
                    <div class="col-lg-3" style="margin-top: 20px">
                        <asp:Label ID="lblTo" runat="server" Text=" To:" CssClass="category"></asp:Label>
                        <br>
                        <asp:TextBox ID="txtTo" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        <br>
                    </div>
                    <div class="col-lg-6" style="margin-top: 20px">
                        <asp:Label ID="lblSelect" runat="server" Text=" Select Department:" CssClass="category"></asp:Label>

                        <asp:DropDownList ID="ddlDepartment" runat="server" Width="40%" CssClass="form-control"></asp:DropDownList>
                        <br>
                    </div>
                    <div class="col-lg-6" style="margin-bottom: 20px">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-warning btn-fill btn-wd" OnClick="btnSearch_Click" />
                        <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-primary btn-fill btn-wd" OnClientClick="return Print();" />

                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="PrintContent" runat="server">
        <div class="row">
            <div class="col-lg-10">
                <div class="card">

                    <asp:GridView ID="GridView_SOA" runat="server" CssClass="table  table-hover table-striped" HeaderStyle-CssClass=" content text-uppercase  " AutoGenerateColumns="False" EditRowStyle-CssClass="btn btn-warning btn-fill fa fa-edit"
                        CellPadding="4" ForeColor="#333333" GridLines="None" ShowHeaderWhenEmpty="true" EmptyDataText="There are no SOA  record">
                        <AlternatingRowStyle BackColor="White" />

                        <HeaderStyle CssClass=" content text-uppercase"></HeaderStyle>
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
                <asp:TemplateField HeaderText="Sold Quantity">
                    <ItemTemplate>
                        <asp:Label ID="Location" runat="server" Text='<%# Eval("soldQuantity") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Unit Price">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="Unitofmeasurement" Text='<%#Eval("unitPrice") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Price">
                    <ItemTemplate>
                        <asp:Label ID="Quantityonhand" runat="server" Text='<%# Eval("totalPrice") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="Label1" runat="server" Text=" TotalPrice : $" CssClass="category" ></asp:Label>
                    <asp:Label ID="TotalPrice" runat="server" Text="0"></asp:Label>
                </div>
            </div>
        </div>
        <!-- end content-->
    </div>
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
