<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreManager.Master" AutoEventWireup="true" CodeBehind="SM_EditItem.aspx.cs" Inherits="Team09LogicU.Pages.SM_EditItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Edit Item
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <form id="form1" runat="server">
      
                <div class="row">
                    <div class="col-md-12">
                        <div class="card">

                            <div class="content">
                                <div class="row">

                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Item code</label><%-- value=""--%><br />
                                            <%--<asp:Label ID="Label_itemcode" runat="server" Text=""></asp:Label>--%>
                                             <asp:TextBox ID="TextBox_itemcode" runat="server" class="form-control disabled" ReadOnly="true" Width="200px"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Category</label><br />
                                            <%--<asp:Label ID="Label_category" runat="server" Text=""></asp:Label>--%>
                                            <asp:TextBox ID="TextBox_category" runat="server" class="form-control disabled" ReadOnly="true" Width="200px"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Qty on Hand </label><br />
                                            <%--<asp:Label ID="Label_qty" runat="server" Text=""></asp:Label>--%>
                                            <asp:TextBox ID="TextBox_qty" runat="server" class="form-control disabled" ReadOnly="true" Width="200px"></asp:TextBox>
                                            <%-- value=""--%>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Description</label>
                                            <asp:TextBox ID="TextBox_Description" runat="server" class="form-control" Width="200px"></asp:TextBox>
                                            <%-- value=""--%>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>ReorderLevel </label>
                                            <asp:TextBox ID="TextBox_ReorderLevel" runat="server" class="form-control " Width="200px"></asp:TextBox>
                                            <%-- value=""--%>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Reorder Qty </label>

                                            <asp:TextBox ID="TextBox_ReorderQty" runat="server" class="form-control " Width="200px"></asp:TextBox>
                                            <%-- value=""--%>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Unit of Measure</label>
                                            <asp:DropDownList ID="dropdownlist_unitofmeasure" runat="server" class="form-control" Width="200px">
                                                <asp:ListItem>Box</asp:ListItem>
                                                <asp:ListItem>Dozen</asp:ListItem>
                                                <asp:ListItem>Each</asp:ListItem>
                                                <asp:ListItem>Set</asp:ListItem>
                                                <asp:ListItem>Packet</asp:ListItem>
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Location </label>

                                            <asp:TextBox ID="TextBox_location" runat="server" class="form-control " Width="200px"></asp:TextBox>
                                            <%-- value=""--%>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Supplier1</label>
                                            <asp:DropDownList ID="dropdownlist_Supplier1" runat="server" class="form-control" Width="200px"></asp:DropDownList>
                                            <label>Price</label>
                                            <asp:TextBox ID="TextBox_price1" runat="server" class="form-control " Width="200px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Supplier2</label>
                                            <asp:DropDownList ID="dropdownlist_Supplier2" runat="server" class="form-control" Width="200px"></asp:DropDownList>
                                            <label>Price</label>
                                            <asp:TextBox ID="TextBox_price2" runat="server" class="form-control " Width="200px"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Supplier3</label>
                                            <asp:DropDownList ID="dropdownlist_Supplier3" runat="server" class="form-control" Width="200px"></asp:DropDownList>
                                            <label>Price</label>
                                            <asp:TextBox ID="TextBox_price3" runat="server" class="form-control" Width="200px"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
         

        <asp:Button ID="Btn_Update" runat="server" Text="Update" CssClass="btn btn-primary btn-fill btn-wd " OnClick="Btn_Update_Click" />
        <asp:Button ID="Btn_Back" runat="server" Text="Back" CssClass="btn btn-default  btn-fill btn-wd" OnClick="Btn_Back_Click" />

    </form>
</asp:Content>
