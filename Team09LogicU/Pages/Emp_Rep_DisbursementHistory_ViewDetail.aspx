<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Employee.Master" AutoEventWireup="true" CodeBehind="Emp_Rep_DisbursementHistory_ViewDetail.aspx.cs" Inherits="Team09LogicU.Pages.Emp_Rep_DisbursementHistory_ViewDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Disbursement History Detail
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
            <div class="row">
                        <div class="col-lg-10">
							<div class="card">
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
                               </div></div> </div>
                                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-default btn-wd " OnClick="btnBack_Click" />
      

</asp:Content>
