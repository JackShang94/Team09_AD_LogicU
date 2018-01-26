﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_ViewAdjustmentVoucher.aspx.cs" Inherits="Team09LogicU.Pages.SC_ViewAdjustmentVoucher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    View AdjustmentVoucher
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

     <form id="form1" runat="server">
      
                <div class="row">
                    <div class="col-md-12">
                        <div class="card">
                            <div class="content">
                            <div class="header">
                                <h4 class="title">View Adjustment Voucher</h4>
                               
                            </div><div class="container">
                                                <asp:Label ID="lblMessage" CssClass="category" runat="server" Text=""></asp:Label>
                                                        <div class ="col-lg-6" style="margin-top:20px">
                                                         <div class="col-lg-3">
                                                    <asp:Label ID="Label2" runat="server" Text=" Search by Status:"  Width=300px CssClass="category" ></asp:Label>
                                                             </div>
                                                               <div class="col-lg-3">
                                                    <asp:TextBox ID="TextBox_SearchById" runat="server" Width=300px CssClass="form-control"></asp:TextBox>
                                                                   </div>
                                                         </div>
                                                              <div class ="col-lg-6" style="margin-top:20px">
                                                                <asp:Button ID="btnSearch" runat="server" Width=200px Text="Search" CssClass="btn btn-primary btn-fill btn-wd" OnClick="btnSearch_Click" />                              
                                                                </div>
                                                <asp:GridView ID="GridView_ViewAdjustmentVoucher" runat="server" AllowPaging="true" OnPageIndexChanging="GridView_ViewAdjustmentVoucher_PageIndexChanging" OnRowCommand="GridView_ViewAdjustmentVoucher_RowCommand"  AutoGenerateColumns="False" CssClass="table bootstrap-table table-hover table-striped" HeaderStyle-CssClass=" content text-uppercase  " EmptyDataText="There are no record!" EditRowStyle-CssClass="btn btn-warning btn-fill fa fa-edit" AutoGenerateDeleteButton="false" AutoGenerateEditButton="False" AutoGenerateSelectButton="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Adjustment Voucher ID" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="label_ADJVID" runat="server" Text='<%# Bind("adjVID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="adjVID" HeaderText="Adjustment VoucherId" />
                                                        <asp:BoundField DataField="storeStaffID" HeaderText="Requested Staff" />
                                                        <asp:BoundField DataField="authorisedBy" HeaderText="authorisedBy" />
                                                        <asp:BoundField DataField="adjDate" HeaderText="adjDate" />
                                                        <asp:BoundField DataField="status" HeaderText="Status" />
                                                        <asp:TemplateField HeaderText="Action" ShowHeader="False">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton_View" runat="server" CausesValidation="False" CommandName="Select" Text="View" OnClick="LinkButton_View_Click"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                     <PagerTemplate>
                                                        <br />
                                                          <div class="col-lg-12 text-center">
                                                         <div class="col-lg-1" style="width:100px">
                                                         <asp:Label ID="lblPage" runat="server" Text='<%# "Page:" + (((GridView)Container.NamingContainer).PageIndex + 1)  + "/" + (((GridView)Container.NamingContainer).PageCount)  %> '></asp:Label></div>
                                                         <div class="col-lg-1" style="width:40px">
                                                         <asp:LinkButton ID="lbnFirst" runat="Server" Text="First" CssClass="btn btn-xs btn-success"   Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="First" ></asp:LinkButton></div>
                                                        <div class="col-lg-1" style="width:40px" >
                                                        <asp:LinkButton ID="lbnPrev" runat="server" Text="<<"  CssClass="btn btn-xs btn-success"  Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="Prev"  ></asp:LinkButton></div>
                                                         <div class="col-lg-1" style="width:40px;height:80px;margin-right:-10px;margin-left:-5px;margin-top:-10px" >
                                                            <asp:TextBox runat="server" CssClass="form-control text-center " Width="40px"  ID="inPageNum"></asp:TextBox></div>
                                                        <div class="col-lg-1" style="width:40px; margin-left:20px" >
                                                            <asp:LinkButton ID="lbnNext" runat="Server" Text=">>"  CssClass="btn btn-xs btn-success"  Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next" ></asp:LinkButton>
                                                         </div><div class="col-lg-1" style="width:40px;margin-left:-10px">
                                                            <asp:LinkButton ID="lbnLast" runat="Server" Text="Last"  CssClass="btn btn-xs btn-success"   Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last" ></asp:LinkButton></div>
                                                              <div class="col-lg-1" style="width:40px">
                                                             <asp:Button ID="Button1" CommandName="go"  CssClass="btn btn-xs btn-success"  Text="GO" runat="server" />
                                                         </div><br />
                                                     </PagerTemplate>

                                                    <HeaderStyle CssClass=" content text-uppercase"></HeaderStyle>
                                                </asp:GridView>
                                           
                                        </div>
                                   </div>
                              </div>
                            </div>
                      
                    </div>
              
           
      
    </form>
     <link href="../css/window.css" rel="stylesheet" />
    <script src="../js/jquery-1.7.1.min.js"></script>
    <script src="../js/window.js"></script>


</asp:Content>