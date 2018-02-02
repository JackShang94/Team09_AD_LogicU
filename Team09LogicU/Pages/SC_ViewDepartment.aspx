<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_ViewDepartment.aspx.cs" Inherits="Team09LogicU.Pages.SC_ViewDepartment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    View Department
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
  
        <div class="row">
           <div class="col-lg-10">
                <div class="card">
                    
     
                                            <asp:GridView ID="GridView_DepList" runat="server" CssClass="table bootstrap-table table-hover table-striped" HeaderStyle-CssClass=" content text-uppercase  " AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" EmptyDataText="There are no Department List">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                 
                                                    <asp:BoundField DataField="deptID" HeaderText="Department Code:" />
                                                    <asp:BoundField DataField="deptName" HeaderText="Department Name:" />
                                                    <asp:BoundField DataField="staffName" HeaderText="Contact Name:" />
                                                    <asp:BoundField DataField="phone" HeaderText="Telephone No.:" />
                                                    <asp:BoundField DataField="fax" HeaderText="Fax No.:" />
                                                    <asp:BoundField DataField="headName" HeaderText="Head's Name.:" />
                                                    <asp:BoundField DataField="collectionPointID" HeaderText="Collection Point:" />
                                                    <asp:BoundField DataField="reqName" HeaderText="Representative Name:" />
                                                    
                                                </Columns>
                                                <HeaderStyle CssClass=" content text-uppercase"></HeaderStyle>
                                            </asp:GridView></div>
                                   
                                </div>
                                 <!-- end col-md-12 -->
                            </div>                    
                        <!-- end row -->

</asp:Content>
