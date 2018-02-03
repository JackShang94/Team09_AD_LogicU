﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreSupervisor.Master" AutoEventWireup="true" CodeBehind="SS_ViewAdjustmentDetail.aspx.cs" Inherits="Team09LogicU.Pages.SS_ViewAdjustmentDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    View Adjustment Detail
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="row">
        <div class="col-lg-10">
            <div class="card">
                <div class=" container">
                    <div class=" col-lg-3" style="margin-top: 20px">
                        <asp:Label ID="Labeltxtadjv" CssClass="category" runat="server" Text="Adjustment Voucher ID: "></asp:Label>
                        <asp:Label ID="lblAdjvID" CssClass="h6" runat="server"></asp:Label>
                    </div>
                    <div class=" col-lg-3" style="margin-top: 20px">
                        <asp:Label ID="LabelTXTStaffid" CssClass="category" runat="server" Text="Store Staff: "></asp:Label>
                        <asp:Label ID="Label_StoreStafID" CssClass="h6" runat="server"></asp:Label>
                    </div>
                    <div class=" col-lg-4" style="margin-top: 20px">
                        <asp:Label ID="LabeltxtAutBy" CssClass="category" runat="server" Text="Authorised By: "></asp:Label>
                        <asp:Label ID="Label_Authorisedby" CssClass="h6" runat="server"></asp:Label>
                    </div>

                    <div class=" col-lg-3" style="margin-top: 20px">
                        <asp:Label ID="LabeltxtadjvDate" CssClass="category" runat="server" Text="Request Date: "></asp:Label>
                        <asp:Label ID="lblDate" CssClass="h6" runat="server"></asp:Label>
                    </div>

                    <div class=" col-lg-3" style="margin-top: 20px">
                        <asp:Label ID="Labeltxtstatus" CssClass="category" runat="server" Text="Status: "></asp:Label>
                        <asp:Label ID="lblStatus" CssClass="h6" runat="server"></asp:Label>
                    </div>
                    <div class=" col-lg-10" style="margin-bottom: 20px; margin-top: 20px">
                        <asp:GridView ID="GridView_detailList" runat="server" AllowPaging="true" OnPageIndexChanging="GridView_detailList_PageIndexChanging" OnRowCommand="GridView_detailList_RowCommand" CssClass="table table-hover table-striped" HeaderStyle-CssClass=" content text-uppercase  " EmptyDataText="There is no record!" EditRowStyle-CssClass="btn btn-warning btn-fill fa fa-edit" AutoGenerateDeleteButton="False" AutoGenerateEditButton="False" AutoGenerateSelectButton="False" CellPadding="4" ForeColor="#333333" GridLines="None">
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
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </div>
                    <div class="col-lg-10" style="margin-bottom: 20px">
                        <div class="col-lg-9">
                            <asp:Label ID="label4" runat="server" CssClass="category" Text=" Remarks:"></asp:Label>
                        </div>
                        <div class=" col-lg-6" style="margin-top: 20px">
                            <asp:TextBox ID="TextBox_Remarks" Style="resize: none" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>

                </div>

                <div class="col-lg-10" style="margin-top: 20px">
                    <div class="col-lg-2">
                        <asp:Button ID="btn_Back" runat="server" Text="Back" CssClass="btn btn-default btn-fill btn-wd " OnClick="btn_Back_Click" />
                    </div>
                    <div class="col-lg-2">
                        <asp:Button ID="button_Approve" runat="server" Text="Approve" CssClass="btn btn-primary btn-fill btn-wd" OnClick="btn_Approve_Click" />
                    </div>
                    <div class="col-lg-2">
                        <asp:Button ID="button_Reject" Style="display: block;" runat="server" Text="Reject" CssClass="btn btn-danger btn-fill btn-wd " OnClick="btn_Reject_Click" />
                    </div>
                    <div class="col-lg-2">
                        <asp:Button ID="button_SendtoManager" Style="display: none;" runat="server" Text="Send to Manager" CssClass="btn btn-primary btn-fill btn-wd " OnClick="btn_SendToManager_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
