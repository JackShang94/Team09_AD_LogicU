<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_Inv_StockCardDetail.aspx.cs" Inherits="Team09LogicU.Pages.SC_Inv_StockCardDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Stock Card Detail
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

   
                <div class="row">
                    <div class="col-md-9">
                        <div class="card">
                            <div class="header">
                                <p class="category">
                                    <asp:Label ID="label" runat="server" Text="Item Code: "></asp:Label>
                                    <asp:Label ID="label_itemcode" runat="server" Text=""></asp:Label>
                                </p>
                                <p class="category">
                                    <asp:Label ID="Label3" runat="server" Text="Item Description: "></asp:Label>
                                    <asp:Label ID="label_description" runat="server" Text=""></asp:Label>
                                </p>
                                <p class="category">
                                    <asp:Label ID="label2" runat="server" Text=" Unit of mesaure:"></asp:Label>
                                    <asp:Label ID="label_measure" runat="server" Text=""></asp:Label>
                            </div>
                            <p>
                                <asp:GridView ID="GridView_ItemStock" runat="server" CssClass="table bootstrap-table table-hover table-striped" HeaderStyle-CssClass=" content text-uppercase  " 
                                    EmptyDataText="No Stock Card Record." AllowPaging="True" AutoGenerateColumns="false" EditRowStyle-CssClass="btn btn-warning btn-fill fa fa-edit" CellPadding="4" ForeColor="#333333" GridLines="None">


                                     <Columns>
                                                    <asp:BoundField DataField="date" HeaderText="date" />
                                                    <asp:BoundField DataField="quantity" HeaderText="quantity" />
                                                    <asp:BoundField DataField="balance" HeaderText="balance" />
                                                    <asp:BoundField DataField="record" HeaderText="record" />
                                                </Columns>


                                </asp:GridView>
                                
                            </p>
                        </div>

                    </div>
                </div>
           
        <asp:Button ID="Btn_Back" runat="server" Text="Back" CssClass="btn btn-default  btn-fill btn-wd" OnClick="Btn_Back_Click" />
   
</asp:Content>
