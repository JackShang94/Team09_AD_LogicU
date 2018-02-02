<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreManager.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="SM_SearchItem.aspx.cs" Inherits="Team09LogicU.Pages.SM_SearchItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    View Item
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="row">
        <div class="col-md-8">
            <div class="card">
                <div class="content">
                    <div class="form-group" style="height: 25px; width: 100%">
                        <div class="pull-left search" style="width: 75%">
                            <asp:TextBox ID="textbox_Search" placeholder="Search" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="pull-right" style="width: 20%">
                            <asp:Button ID="Button_search" runat="server" Width="100%" Text="Search" CssClass="btn btn-primary btn-fill btn-wd" OnClick="Button_search_Click" />
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>



    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class=" container">
                    <div class="col-lg-10" style="margin: 20px 0 0 -40px">
                        <asp:Button ID="Btn_Add" runat="server" Text="Add New Item" CssClass="btn btn-warning btn-fill btn-wd " OnClick="Btn_Add_Click" />
                    </div>
                    <div class="col-lg-12" style="margin-top: 20px; margin-left: -40px">
                        <asp:GridView ID="GridView_itemList" runat="server" OnRowCommand="GridView_itemList_RowCommand" OnPageIndexChanging="GridView_itemList_PageIndexChanging" PageSize="5" OnRowEditing="GridView_itemList_RowEditing"
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
                                <div class="col-lg-12 text-center">
                                    <div class="col-lg-1" style="width: 100px">
                                        <asp:Label ID="lblPage" runat="server" Text='<%# "Page:" + (((GridView)Container.NamingContainer).PageIndex + 1)  + "/" + (((GridView)Container.NamingContainer).PageCount)  %> '></asp:Label>
                                    </div>
                                    <div class="col-lg-1" style="width: 40px">
                                        <asp:LinkButton ID="lbnFirst" runat="Server" Text="First" CssClass="btn btn-xs btn-success" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="First"></asp:LinkButton>
                                    </div>
                                    <div class="col-lg-1" style="width: 40px">
                                        <asp:LinkButton ID="lbnPrev" runat="server" Text="<<" CssClass="btn btn-xs btn-success" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="Prev"></asp:LinkButton>
                                    </div>
                                    <div class="col-lg-1" style="width: 40px; height: 80px; margin-right: -10px; margin-left: -5px; margin-top: -10px">
                                        <asp:TextBox runat="server" CssClass="form-control text-center " Width="40px" ID="inPageNum" Text='<%#(((GridView)Container.NamingContainer).PageIndex + 1)%>'></asp:TextBox>
                                    </div>
                                    <div class="col-lg-1" style="width: 40px; margin-left: 20px">
                                        <asp:LinkButton ID="lbnNext" runat="Server" Text=">>" CssClass="btn btn-xs btn-success" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next"></asp:LinkButton>
                                    </div>
                                    <div class="col-lg-1" style="width: 40px; margin-left: -10px">
                                        <asp:LinkButton ID="lbnLast" runat="Server" Text="Last" CssClass="btn btn-xs btn-success" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last"></asp:LinkButton>
                                    </div>
                                    <div class="col-lg-1" style="width: 40px">
                                        <asp:Button ID="go" CommandName="go" CssClass="btn btn-xs btn-success" Text="GO" runat="server" CausesValidation="false" />
                                    </div>
                                    <br />
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
