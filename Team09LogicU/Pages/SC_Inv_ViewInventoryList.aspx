<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="SC_Inv_ViewInventoryList.aspx.cs" Inherits="Team09LogicU.Pages.SC_Inv_StockManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    View Inventory List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

 
        <div class="row">
            <div class="col-lg-10">
                <div class="card">
                    <div class="container">
                        
                                <div class="col-lg-3" style=" margin-top:20px;margin-bottom:20px">
                                    <asp:Label ID="Label3" runat="server" CssClass="category" Text=" Category:"></asp:Label>
                                    <asp:DropDownList ID="DropDownList_cat" runat="server" CssClass="form-control"  AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_cat_SelectedIndexChanged" ></asp:DropDownList>
                                </div>
                    <div class="col-lg-10">
                                        <asp:GridView ID="GridView_stock" runat="server" PageSize="5" OnPageIndexChanging="GridView_stock_PageIndexChanging"
                                            OnRowCommand="GridView_stock_RowCommand"  OnRowEditing="GridView_stock_RowEditing"
                                            CssClass="table bootstrap-table table-hover table-striped" HeaderStyle-CssClass=" content text-uppercase  " 
                                            AllowPaging="True" EditRowStyle-CssClass="btn btn-warning btn-fill fa fa-edit"
                                            CellPadding="4" ForeColor="#333333" GridLines="None" >
                                            <Columns>
                                                <asp:TemplateField HeaderText="View" ItemStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="View" Text="Stock Card" runat="server" CssClass="btn btn-default btn-xs" CommandName="Edit" OnClientClick="Edit?"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle CssClass=" content text-uppercase  "></HeaderStyle>
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
                                        </asp:GridView>
        
                                    </div>  
                    </div>
                  
                </div>
                </div>
           
        </div>
    
</asp:Content>
