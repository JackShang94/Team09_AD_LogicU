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
            <asp:TextBox runat="server" CssClass="form-control text-center " Width="40px" Text='<%# (((GridView)Container.NamingContainer).PageIndex + 1) %>'  ID="inPageNum"></asp:TextBox></div>
        <div class="col-lg-1" style="width:40px; margin-left:20px" >
            <asp:LinkButton ID="lbnNext" runat="Server" Text=">>"  CssClass="btn btn-xs btn-success"  Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next" ></asp:LinkButton>
         </div><div class="col-lg-1" style="width:40px;margin-left:-10px">
            <asp:LinkButton ID="lbnLast" runat="Server" Text="Last"  CssClass="btn btn-xs btn-success"   Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last" ></asp:LinkButton></div>
              <div class="col-lg-1" style="width:40px">
             <asp:Button ID="go" CommandName="go"  CssClass="btn btn-xs btn-success"  Text="GO" runat="server" CausesValidation="false" />
         </div><br />
     </PagerTemplate>
                                        </asp:GridView>
        
                                    </div>  
                    </div>
                  
                </div>
                </div>
           
        </div>
    
</asp:Content>
