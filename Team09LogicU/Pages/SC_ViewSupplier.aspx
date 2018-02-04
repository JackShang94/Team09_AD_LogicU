<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_ViewSupplier.aspx.cs" Inherits="Team09LogicU.Pages.SC_ViewSupplier" %>
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
                        <asp:GridView ID="GridView_supplierList" runat="server"  CssClass="table bootstrap-table table-hover table-striped" HeaderStyle-CssClass=" content text-uppercase  " 
                           ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                            <Columns>
                                
                                <asp:BoundField DataField="supplierID" HeaderText=" Supplier ID" />
                                <asp:BoundField DataField="supplierName" HeaderText="Name" />
                                <asp:BoundField DataField="address" HeaderText="Address" />
                                <asp:BoundField DataField="contactName" HeaderText="Contact Name" />
                                <asp:BoundField DataField="phone" HeaderText="Phone No." />
                                

                            </Columns>

                            <HeaderStyle CssClass=" content text-uppercase  "></HeaderStyle>
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>

                </div></div>
                    </div>
                   
               
</asp:Content>
