<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreManager.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="SM_SearchItem.aspx.cs" Inherits="Team09LogicU.Pages.SM_SearchItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    View Item
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="row">
        <div class="col-lg-10">
            <div class="card">
                <div class=" container">
                    <div class="col-lg-6" style="margin-top:20px;margin-bottom:20px">
                        
                            <asp:TextBox ID="textbox_Search" placeholder="Search" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-lg-1" style="margin-top:20px;margin-bottom:20px" >
                            <asp:Button ID="Button_search" runat="server"  Text="Search" CssClass="btn btn-primary btn-fill btn-wd" OnClick="Button_search_Click" />
                        </div>

                    
                </div>
            </div>
        </div>
    </div>



    <div class="row">
        <div class="col-lg-12">
            <div class="card">
                <div class=" container">
                    <div class="col-lg-10" style="margin: 20px 0 0 0">
                        <asp:Button ID="Btn_Add" runat="server" Text="Add New Item" CssClass="btn btn-warning btn-fill btn-wd " OnClick="Btn_Add_Click" />
                    </div>
                    <div class="col-lg-12" style="margin-top: 20px; ">
                        <asp:GridView ID="GridView_itemList" runat="server" Width="85%" OnRowCommand="GridView_itemList_RowCommand" OnPageIndexChanging="GridView_itemList_PageIndexChanging" PageSize="5" OnRowEditing="GridView_itemList_RowEditing"
                            CssClass="table bootstrap-table table-hover table-striped" HeaderStyle-CssClass=" content text-uppercase  " AllowPaging="True" EditRowStyle-CssClass="btn btn-warning btn-fill fa fa-edit"
                            CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" EmptyDataText ="There is no record!">
                            <Columns>
                                <asp:TemplateField HeaderText="Edit" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Edit" runat="server" CssClass="btn btn-xs btn-warning" Text="Edit" CommandName="Edit" OnClientClick="Edit?"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                            <HeaderStyle CssClass=" content text-uppercase  "></HeaderStyle>
                            <AlternatingRowStyle BackColor="White" />
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
                            <Columns>
                                <asp:BoundField DataField="itemID" HeaderText="ID" />
                                <asp:BoundField DataField="description" HeaderText="Description" />
                                <asp:BoundField DataField="categoryID" HeaderText="Category" />
                                <asp:BoundField DataField="unitOfMeasure" HeaderText="Unit of Measure" />
                                <asp:BoundField DataField="qtyOnHand" HeaderText="Quantity On Hand" />
                            </Columns>
                        </asp:GridView>

                    </div>



                </div>

            </div>
        </div>
        <!-- end content-->
    </div>
    <!--  end card  -->











</asp:Content>
