<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_ViewCatalog.aspx.cs" Inherits="Team09LogicU.Pages.SC_ViewCatalog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    View Catalog
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

      
        <div class="row">
           <div class="col-lg-12">
                <div class="card">
                    <div class=" container">

                        <div class ="col-lg-6" style="margin-top:20px">
                                 <div class="col-lg-3">
                            <asp:Label ID="Label2" runat="server" Text=" Select Catalog:"  Width=300px CssClass="category" ></asp:Label>
                                     </div>
                                       <div class="col-lg-3">
                            <asp:TextBox ID="TextBox_SearchByID" runat="server" Width=300px CssClass="form-control"></asp:TextBox>
                                           </div>
<%--                           <asp:DropDownList ID="ddlCategory" runat="server" Width=300px CssClass="form-control"></asp:DropDownList><br>--%>
                           </div>
                        <div class ="col-lg-6" style="margin-top:20px">
                                    <asp:Button ID="btnSearch" runat="server" Width=200px Text="Search" CssClass="btn btn-primary btn-fill btn-wd" OnClick="btnSearch_Click" />
                                
                            </div>

     <div class="col-lg-10" style="margin-bottom:20px">
                                            <asp:GridView ID="GridView_CatalogList" runat="server" CssClass="table bootstrap-table table-hover table-striped" HeaderStyle-CssClass=" content text-uppercase  " AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" EmptyDataText="There are no Item" AllowPaging="True" onpageindexchanging="GridView_CatalogList_PageIndexChanging">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                 
                                                    <asp:BoundField DataField="itemID" HeaderText="item ID:" />
                                                    <asp:BoundField DataField="categoryID" HeaderText="categoryID:" />
                                                    <asp:BoundField DataField="location" HeaderText="location:" />
                                                    <asp:BoundField DataField="description" HeaderText="description:" />
                                                    <asp:BoundField DataField="reorderLevel" HeaderText="reorder Level:" />
                                                    <asp:BoundField DataField="reorderQty" HeaderText="reorder Qty:" />
                                                    <asp:BoundField DataField="unitOfMeasure" HeaderText="unit Of Measure:" />
                                                    <asp:BoundField DataField="qtyOnHand" HeaderText="qtyOnHand:" />
                                                    
                                                </Columns>
                                                <HeaderStyle CssClass=" content text-uppercase"></HeaderStyle>
                                            </asp:GridView>

     </div>
                                    </div>
                                    <!-- end content-->
                                     </div>
                                        <!--  end card  -->
                                </div>
                                 <!-- end col-md-12 -->
                            </div>                    
                    
</asp:Content>
