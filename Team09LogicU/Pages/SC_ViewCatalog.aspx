<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_ViewCatalog.aspx.cs" Inherits="Team09LogicU.Pages.SC_ViewCatalog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    View Catalog
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

      
        <div class="row">
           <div class="col-lg-10">
                <div class="card">
                    <div class=" container">
                            <div class="col-lg-7" style="margin:20px 0 20px 0">
                            <asp:TextBox ID="TextBox_Search" Width="90%" runat="server" CssClass="form-control" PlaceHolder ="Search by Item ID or Description "></asp:TextBox></div>
<%--                           <asp:DropDownList ID="ddlCategory" runat="server" Width=300px CssClass="form-control"></asp:DropDownList><br>--%>
                           <div class="col-lg-1" style="margin:20px 0 20px 0"><asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-warning btn-fill btn-wd" OnClick="btnSearch_Click" /></div>
                        </div></div></div>
      
           <div class="col-lg-10">
                <div class="card">
                                            <asp:GridView ID="GridView_CatalogList" runat="server" CssClass="table bootstrap-table table-hover table-striped"
                                                HeaderStyle-CssClass=" content text-uppercase  " AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"
                                                EmptyDataText="There are no Item" AllowPaging="True" OnRowCommand="GridView_CatalogList_RowCommand" PageSize="5" 
                                                onpageindexchanging="GridView_CatalogList_PageIndexChanging"  >
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                 
                                                    <asp:BoundField DataField="itemID" HeaderText="item ID" />
                                                    <asp:BoundField DataField="categoryID" HeaderText="category ID" />
                                                    <asp:BoundField DataField="description" HeaderText="description" />
                                                    <asp:BoundField DataField="unitOfMeasure" HeaderText="unit Of Measure" />
                                                    <asp:BoundField DataField="location" HeaderText="location" />
                                                    <asp:BoundField DataField="reorderLevel" HeaderText="reorder Level" />
                                                    <asp:BoundField DataField="reorderQty" HeaderText="reorder Quantity" />
                                                    <asp:BoundField DataField="qtyOnHand" HeaderText="Stock" />
                                                    
                                                </Columns>
                                                <HeaderStyle CssClass=" content text-uppercase"></HeaderStyle>
                                                 <AlternatingRowStyle BackColor="White" />

                                                <PagerTemplate>
                                <br />
                                <div class="col-lg-12 ">
                                    <div class="col-lg-3 " style="width:19%">
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
                                            </asp:GridView>

     </div></div></div>
                             
                                              
                    
</asp:Content>
