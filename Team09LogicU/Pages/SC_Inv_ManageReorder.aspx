<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_Inv_ManageReorder.aspx.cs" Inherits="Team09LogicU.Pages.SC_Inv_ManageReorder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Manage Reorder
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div class="row">
            <div class="col-lg-10">
                <asp:LinkButton ID="LinkButton_history" runat="server" text="Click here to view history" BorderStyle="None" Font-Overline="False" Font-Strikeout="False" Font-Underline="True" ForeColor="#666666" Font-Bold="False" OnClick="LinkButton_history_Click"></asp:LinkButton>
                    </div></div>
    <br />
      <div class="row">
            <div class="col-lg-10">
                <div class="card">
                                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                
                                                <asp:GridView ID="GridView_reorderList" runat="server" CssClass="table bootstrap-table table-hover table-striped" HeaderStyle-CssClass=" content text-uppercase  "
                                                    DataKeyNames="itemID" AutoGenerateColumns="False" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating" OnRowDataBound="RowDataBound"
                                                    CellPadding="4" ForeColor="#333333" GridLines="None" EnableViewState="False">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Item ID" SortExpression="SortedAscendingHeaderStyle">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblItemID" runat="server" Text='<%# Eval("itemID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Description">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("description") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Unit of Measure">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblUnitOfMeasure" runat="server" Text='<%# Eval("unitOfMeasure") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Stock">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblQtyOnHand" runat="server" Text='<%# Eval("qtyOnHand") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Reorder Level">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblReorderLevel" runat="server" Text='<%# Eval("reorderLevel") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Reorder Quantity">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblReorderQty" runat="server" Text='<%# Eval("reorderQty") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Order Quantity">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblOrderQty" runat="server" Text='<%# Eval("orderQty") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:DropDownList ID="ddlSuppliers" runat="server"></asp:DropDownList>
                                                                <asp:TextBox ID="txtOrderQty" CssClass="form-control" Width="50%" runat="server" BackColor="Azure"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                                    ControlToValidate="txtOrderQty" ForeColor="Red" Display="Dynamic"
                                                                    ErrorMessage="RequiredFieldValidator">Quantity is required.</asp:RequiredFieldValidator>
                                                                <asp:CompareValidator ID="cv" runat="server" ControlToValidate="txtOrderQty" Type="Integer"
                                                                    Operator="DataTypeCheck" Display="Dynamic" ErrorMessage="Quantity entered must be a whole number" ForeColor="Red" />
                                                                <asp:RangeValidator ID="RangeValidator1" runat="server" Display="Dynamic"
                                                                    ErrorMessage="RangeValidator" ControlToValidate="txtOrderQty"
                                                                    ForeColor="Red" Type="Integer"
                                                                    MaximumValue="10000" MinimumValue="0">Please Check Quantity.</asp:RangeValidator>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnEdit" CssClass="btn btn-xs btn-warning" runat="server" CommandName="Edit" Text="Edit" EnableViewState="True" />
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:Button ID="btnUpdate" CssClass="btn btn-xs btn-danger" runat="server" CommandName="Update" Text="Update" />
                                                                <asp:Button ID="btnCancel" CssClass="btn btn-xs btn-default" runat="server" CommandName="Cancel" Text="Cancel" />
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>

                                                    <HeaderStyle CssClass=" content text-uppercase  " />

                                                </asp:GridView>
                                                <alternatingrowstyle backcolor="White" />

                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>

                            </div>
                  
            <asp:Button ID="BtnSubmit" runat="server" Text="Add to Reorder List" CssClass="btn btn-primary btn-fill btn-wd " OnClick="BtnSubmit_Click" />

       

</asp:Content>
