<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreManager.Master" AutoEventWireup="true" CodeBehind="SM_SearchSupplier.aspx.cs" Inherits="Team09LogicU.Pages.SM_SearchSupplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    View Supplier
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row">
        <div class="col-lg-10">
            <div class="card">
                <div class=" container">
                    <div class="col-lg-10">
                        <div class="col-lg-6" style="margin-top: 20px;margin-bottom:20px">
                            <asp:TextBox ID="textbox_Search" runat="server" placeholder="Search" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-lg-3" style="margin-top: 20px;margin-bottom:20px">
                            <asp:Button ID="Button_Search" runat="server"  Text="Search" CssClass="btn btn-primary btn-fill btn-wd" OnClick="Button_Search_Click" />
                        </div>
                    </div>
                    </div></div></div></div>

                     <div class="row">
        <div class="col-lg-10">
            <div class="card">
                        <asp:GridView ID="GridView_supplierList" runat="server" OnRowEditing="GridView_supplierList_RowEditing" CssClass="table bootstrap-table table-hover table-striped" HeaderStyle-CssClass=" content text-uppercase  " AllowPaging="True" EditRowStyle-CssClass="btn btn-warning btn-fill fa fa-edit"
                            CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="Edit" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Edit" runat="server" CssClass="btn btn-xs btn-warning" CommandName="Edit" OnClientClick="Edit?" Text="Edit"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="supplierID" HeaderText=" Supplier ID" />
                                <asp:BoundField DataField="supplierName" HeaderText="Name" />
                                <asp:BoundField DataField="address" HeaderText="Address" />
                                <asp:BoundField DataField="contactName" HeaderText="Contact Name" />
                                <asp:BoundField DataField="phone" HeaderText="Phone No." />
                                

                            </Columns>
                            <EditRowStyle CssClass="btn btn-warning btn-fill fa fa-edit"></EditRowStyle>

                            <HeaderStyle CssClass=" content text-uppercase  "></HeaderStyle>
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>

                </div></div>
                    </div>
                   
                        <asp:Button ID="Button_Add" runat="server" Text="Add New Supplier" CssClass="btn btn-warning btn-fill btn-wd " OnClick="Button_Add_Click" />
               

               

</asp:Content>
