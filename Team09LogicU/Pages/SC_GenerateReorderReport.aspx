<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_GenerateReorderReport.aspx.cs" Inherits="Team09LogicU.Pages.SC_GenerateReorderReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <form id="form1" runat="server">
        <div class="col-lg-10" style="margin-bottom:20px">
                                            <asp:GridView ID="GridView_ReorderReport" runat="server" AllowPaging="true" OnPageIndexChanging="GridView_ReorderReport_PageIndexChanging" OnRowCommand="GridView_ReorderReport_RowCommand" CssClass="table bootstrap-table table-hover table-striped" HeaderStyle-CssClass=" content text-uppercase  " AutoGenerateColumns="False" EditRowStyle-CssClass="btn btn-warning btn-fill fa fa-edit" CellPadding="4" ForeColor="#333333" GridLines="None" EmptyDataText="There are no any record found">
                                                <AlternatingRowStyle BackColor="White" />

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

        </form>
</asp:Content>
