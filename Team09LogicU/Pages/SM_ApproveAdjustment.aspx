﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreManager.Master" AutoEventWireup="true" CodeBehind="SM_ApproveAdjustment.aspx.cs" Inherits="Team09LogicU.Pages.SM_ApproveAdjustment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    View Adjustment
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="row">
        <div class="col-lg-10">
            <div class="card">
                <div class=" container">

                    <div class="col-lg-3" style="margin-top: 20px">
                        <asp:Label ID="Label1" runat="server" Text=" From:" CssClass="category"></asp:Label>
                        <asp:TextBox ID="txtFrom" runat="server" Width="90%" TextMode="Date" CssClass="form-control"></asp:TextBox><br>
                    </div>
                    <div class="col-lg-3" style="margin-top: 20px">
                        <asp:Label ID="lblTo" runat="server" Text=" To:" CssClass="category"></asp:Label><br>
                        <asp:TextBox ID="txtTo" runat="server" Width="90%" TextMode="Date" CssClass="form-control"></asp:TextBox><br>
                    </div>
                    <div class="col-lg-6" style="margin-top: 20px">
                        <asp:Label ID="Label3" runat="server" Text=" Select Name:" CssClass="category"></asp:Label>

                        <asp:DropDownList ID="ddlStatus" runat="server" Width="40%" CssClass="form-control">
                            <asp:ListItem Selected="True">---All---</asp:ListItem>
                            <asp:ListItem>Pending(Supervisor)</asp:ListItem>
                            <asp:ListItem>Approved</asp:ListItem>
                            <asp:ListItem>Rejected</asp:ListItem>
                            <asp:ListItem>Pending(Manager)</asp:ListItem>
                        </asp:DropDownList><br>
                    </div>
                    <div class="col-lg-3">
                        <asp:Button ID="btnSearch" runat="server" Width="90%" Text="Search" CssClass="btn btn-warning btn-fill btn-wd" OnClick="btnSearch_Click" />
                    </div>

                    <div class="col-lg-10" style="margin-top: 20px; margin-bottom: 20px">

                        <asp:GridView ID="GridView_ViewAdjustmentVoucher" runat="server" AllowPaging="true" PageSize="5" OnPageIndexChanging="GridView_ViewAdjustmentVoucher_PageIndexChanging" OnRowCommand="GridView_ViewAdjustmentVoucher_RowCommand" AutoGenerateColumns="False" CssClass="table bootstrap-table table-hover table-striped" HeaderStyle-CssClass=" content text-uppercase  " EmptyDataText="There are no record!" EditRowStyle-CssClass="btn btn-warning btn-fill fa fa-edit" AutoGenerateDeleteButton="false" AutoGenerateEditButton="False" AutoGenerateSelectButton="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="Adjustment Voucher ID" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="label_ADJVID" runat="server" Text='<%# Bind("adjVID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="adjVID" HeaderText="Adjustment Voucher ID" />
                                <asp:BoundField DataField="storeStaffID" HeaderText="Requested Staff" />
                                <asp:BoundField DataField="authorisedBy" HeaderText="Authorised By" />
                                <asp:BoundField DataField="adjDate" HeaderText="Date" />
                                <asp:BoundField DataField="status" HeaderText="Status" />
                                <asp:TemplateField HeaderText="Action" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton_View" runat="server" CausesValidation="False" CommandName="Select" Text="View" OnClick="LinkButton_View_Click" ControlStyle-CssClass=" text-center btn btn-xs btn-primary"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerTemplate>
                                <br />
                                <div class="col-lg-12 ">
                                    <div class="col-lg-3 " style="width:18%">
                                     <asp:Label ID="lblPage" runat="server" Text='<%# "Page:" + (((GridView)Container.NamingContainer).PageIndex + 1)  + "/" + (((GridView)Container.NamingContainer).PageCount)  %> '></asp:Label>
                                     <asp:LinkButton ID="lbnFirst" runat="Server" Text="First" CssClass="btn btn-xs btn-default" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="First"></asp:LinkButton>
                                    <asp:LinkButton ID="lbnPrev" runat="server" Text="<<" CssClass="btn btn-xs btn-default" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="Prev"></asp:LinkButton>
                                   </div><div class="col-lg-1" style="Width:10%"><asp:TextBox runat="server" CssClass="form-control text-center "  ID="inPageNum" Text='<%# ((GridView)Container.NamingContainer).PageIndex +1 %>'></asp:TextBox>
                                    </div><div class="col-lg-3 ">
                                       <asp:LinkButton ID="lbnNext" runat="Server" Text=">>" CssClass="btn btn-xs btn-default" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next"></asp:LinkButton>
                                   <asp:LinkButton ID="lbnLast" runat="Server" Text="Last" CssClass="btn btn-xs btn-default" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last"></asp:LinkButton>
                                     <asp:Button ID="Button1" CommandName="go" CssClass="btn btn-xs btn-default" Text="GO" runat="server" />
                                    </div></div>
                                    
                            </PagerTemplate>

                            <HeaderStyle CssClass=" content text-uppercase"></HeaderStyle>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
