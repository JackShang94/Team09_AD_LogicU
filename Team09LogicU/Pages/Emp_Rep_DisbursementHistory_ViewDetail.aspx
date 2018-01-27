<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Employee.Master" AutoEventWireup="true" CodeBehind="Emp_Rep_DisbursementHistory_ViewDetail.aspx.cs" Inherits="Team09LogicU.Pages.Emp_Rep_DisbursementHistory_ViewDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <form id="form1" runat="server">
     <div class="col-lg-10" style="margin-bottom: 20px">
                            <asp:GridView ID="disbursementDetail" runat="server" CssClass="table bootstrap-table table-hover table-striped" HeaderStyle-CssClass=" content text-uppercase  " AutoGenerateColumns="False" EditRowStyle-CssClass="btn btn-warning btn-fill fa fa-edit" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="ItemID" Visible="True">
                                        <ItemTemplate>
                                            <asp:Label ID="disItemID" runat="server" Text='<%# Bind("ItemID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ItemDescription" HeaderText="Description" />
                                    <asp:BoundField DataField="Expectedc" HeaderText="Expected Quantity" />
                                    <asp:BoundField DataField="Actual" HeaderText="Actual Quantity" />
                                </Columns>
                                <HeaderStyle CssClass=" content text-uppercase"></HeaderStyle>
                            </asp:GridView>
                                <br>
                                <br>
                                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-primary btn-fill btn-wd " OnClick="btnBack_Click" />
       </div>
    </form>
</asp:Content>
