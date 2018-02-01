<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_ViewPurchaseOrderHistory.aspx.cs" Inherits="Team09LogicU.Pages.SC_ViewPurchaseOrderHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    View Purchase Order History
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

        <div class="row">
            <div class="col-lg-10">
                <div class="card">
                    <div class=" container">
                        
                            <div class="col-lg-3" style="margin-top: 20px">
                                <asp:label id="lblFrom" runat="server" text=" From:" cssclass="category"></asp:label>
                                <asp:textbox id="txtFrom" runat="server" cssclass="form-control " TextMode="Date" ></asp:textbox>
                                <br>
                            </div>
                            <div class="col-lg-3" style="margin-top: 20px">
                                <asp:label id="lblTo" runat="server" text=" To:" cssclass="category"></asp:label>
                                <br>
                                <asp:textbox id="txtTo" runat="server" cssclass="form-control" TextMode="Date"></asp:textbox>
                                <br>
                            </div>
                            <div class="col-lg-6" style="margin-top: 20px">
                                <asp:label id="lblSelect" runat="server" text=" Select Supplier:" cssclass="category"></asp:label>

                                <asp:dropdownlist id="ddlSupplier" runat="server" width="40%" cssclass="form-control"></asp:dropdownlist>
                                <br>
                            </div>
                            <div class="col-lg-3" style="margin-bottom: 20px">
                                <asp:button id="btnSearch" runat="server"  text="Search" cssclass="btn btn-warning btn-fill btn-wd" onclick="btnSearch_Click" />

                            </div>
                        </div></div></div></div>

                       <div class="row">
            <div class="col-lg-10">
                <div class="card">
                            <asp:gridview id="GridView_PurchaseOrder" runat="server" cssclass="table bootstrap-table table-hover table-striped" headerstyle-cssclass=" content text-uppercase  " autogeneratecolumns="False" editrowstyle-cssclass="btn btn-warning btn-fill fa fa-edit" cellpadding="4" forecolor="#333333" gridlines="None" emptydatatext="There are no Purchase Order history record">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="PO ID" Visible="True">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblpoID" runat="server" Text='<%# Bind("poID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="supplierID" HeaderText="Supplier Name" />
                                                    <asp:BoundField DataField="orderBy" HeaderText="Order By" />
                                                    <asp:BoundField DataField="orderDate" HeaderText="Order Date" />
                                                    <asp:TemplateField HeaderText="Action" ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton_View" runat="server" CausesValidation="False" CommandName="Select" Text="View" OnClick="LinkButton_View_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass=" content text-uppercase"></HeaderStyle>
                                            </asp:gridview>

                        </div>
                    </div>
                    <!-- end content-->
                </div>
            
     
</asp:Content>
