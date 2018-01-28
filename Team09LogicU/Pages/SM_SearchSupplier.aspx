<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreManager.Master" AutoEventWireup="true" CodeBehind="SM_SearchSupplier.aspx.cs" Inherits="Team09LogicU.Pages.SM_SearchSupplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    View Supplier
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

   



        <div class="row">
            <div class="col-md-8 container-fluid">
                <div class="card">
                    <div class="content">
                        <div class=" form-group" style="height: 25px; width: 100%">
                            <div class="pull-left search" style="width: 75%">
                                <asp:TextBox ID="textbox_Search" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="pull-right" style="width: 20%">
                                <asp:Button ID="Button_Search" runat="server" Width="100%" Text="Search" CssClass="btn btn-primary btn-fill btn-wd" OnClick="Button_Search_Click" />
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>


        <div class="content">
            <div class="container-fluid">
                <div class="content">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="card">
                                <div class="content">
                                    <div class="container-fluid">
                                        <div class="content">

                                            <asp:Button ID="Button_Add" runat="server" Text="Add New Supplier" CssClass="btn btn-danger btn-fill btn-wd " OnClick="Button_Add_Click" />
                                            
                                            <asp:GridView ID="GridView_supplierList" runat="server" OnRowEditing="GridView_supplierList_RowEditing" CssClass="table bootstrap-table table-hover table-striped" HeaderStyle-CssClass=" content text-uppercase  " AllowPaging="True" EditRowStyle-CssClass="btn btn-warning btn-fill fa fa-edit"
                                                CellPadding="4" ForeColor="#333333" GridLines="None">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Edit" ItemStyle-CssClass="text-center">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="Edit" runat="server" CssClass="fa fa-edit" CommandName="Edit" OnClientClick="Edit?" ForeColor="OrangeRed"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EditRowStyle CssClass="btn btn-warning btn-fill fa fa-edit"></EditRowStyle>

                                                <HeaderStyle CssClass=" content text-uppercase  "></HeaderStyle>
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>



                                        </div>
                                    </div>
                                    <!-- end content-->
                                </div>
                                <!--  end card  -->
                            </div>
                            <!-- end col-md-12 -->
                        </div>
                        <!-- end row -->

                    </div>
                </div>
            </div>

        </div>









   


</asp:Content>
