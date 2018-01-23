<%@ Page Title="" Language="C#" MasterPageFile="~/pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_RO_DisbursementList.aspx.cs" Inherits="Team09LogicU.pages.SC_RO_DisbursementList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Disbursement List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <form id="form1" runat="server">
    <div class="row">
         <div class="col-lg-12">
        <div class="card">
                <div class=" container">
                    <div class="col-lg-12">
                   <div class="col-lg-3" style="margin-top:20px">
                    <asp:Label ID="Label1" runat="server" Text="Select a Department:" CssClass="category"></asp:Label>
                       <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                   </div>
                    <div class="col-lg-10">
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">View Disbursement List History</asp:LinkButton>
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-hover " OnRowEditing="GridView1_RowEditing" EmptyDataText="There is no disbursement">
                            
                        </asp:GridView>
                        <div class="col-lg-10">
                        <asp:Label ID="Label2" runat="server" Text="Label">Collection Point:</asp:Label>
                          </div>  </div></div>
                        <div class="col-lg-3" style=" margin-top:40px;margin-bottom:20px">
                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-wd btn-fill" Text="Inform representative" />
                       </div>
                     <div class="col-lg-3 " style="margin-top:40px;margin-bottom:20px">
                        <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary btn-wd " Text="Generate QR Code" />
                       </div>
                       </div>
                    
                </div>
            
        </div>
    </div>
    </form>
</asp:Content>
