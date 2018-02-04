<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_Inv_AdjustmentVoucher.aspx.cs" Inherits="Team09LogicU.Pages.SC_Inv_AdjustmentVoucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Submit Adjustment Voucher
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">



    <div class="row">
        <div class="col-lg-8">
            <div class="card">
                <div class=" container">

                    <div class="col-lg-5" style="margin-top: 20px; margin-bottom: 20px">
                        <asp:Label ID="Label3" runat="server" CssClass="category" Text=" Category:"></asp:Label>
                        <asp:DropDownList Width="40%" ID="DropDownList_cat" runat="server" CssClass="form-control" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_cat_SelectedIndexChanged"></asp:DropDownList>

                    </div>
                    <div class="col-lg-8">

                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <asp:UpdatePanel ID="catalogueUpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="True" EnableViewState="True">
                            <ContentTemplate>

                                <asp:GridView ID="GridView_CatalogList" Width="90%" OnRowCommand=" GridView_CatalogList_RowCommand"
                                    runat="server" CssClass="table table-hover table-striped"
                                    HeaderStyle-CssClass=" content text-uppercase  " AutoGenerateColumns="False"
                                    CellPadding="4" ForeColor="#333333" GridLines="None" EmptyDataText="There are no Item" AllowPaging="True"
                                    OnPageIndexChanging="GridView_CatalogList_PageIndexChanging" PageSize="5">
                                    <Columns>
                                        <asp:BoundField DataField="itemID" HeaderText="Item ID:" />
                                        <asp:BoundField DataField="categoryID" HeaderText="Category ID:" />
                                        <asp:BoundField DataField="description" HeaderText="Description:" />
                                        <asp:BoundField DataField="unitOfMeasure" HeaderText="unit Of Measure:" />
                                        <asp:TemplateField HeaderText="Action" ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton_Add" runat="server" CssClass="btn btn-xs btn-warning" CausesValidation="False" Text="Add" CommandName="Add" CommandArgument='<%# Eval("itemID") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass=" text-uppercase  "></HeaderStyle>
                                    <AlternatingRowStyle BackColor="White" />

                                  <PagerTemplate>
                                <br />
                                <div class="col-lg-10 ">
                                    <div class="col-lg-3 " style="width:33%">
                                     <asp:Label ID="lblPage" runat="server" Text='<%# "Page:" + (((GridView)Container.NamingContainer).PageIndex + 1)  + "/" + (((GridView)Container.NamingContainer).PageCount)  %> '></asp:Label>
                                     <asp:LinkButton ID="lbnFirst" runat="Server" Text="First" CssClass="btn btn-xs btn-default" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="First"></asp:LinkButton>
                                    <asp:LinkButton ID="lbnPrev" runat="server" Text="<<" CssClass="btn btn-xs btn-default" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="Prev"></asp:LinkButton>
                                   </div><div class="col-lg-1" style="Width:20%"><asp:TextBox runat="server" CssClass="form-control text-center "  ID="inPageNum" Text='<%# ((GridView)Container.NamingContainer).PageIndex +1 %>'></asp:TextBox>
                                    </div><div class="col-lg-3 ">
                                       <asp:LinkButton ID="lbnNext" runat="Server" Text=">>" CssClass="btn btn-xs btn-default" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next"></asp:LinkButton>
                                   <asp:LinkButton ID="lbnLast" runat="Server" Text="Last" CssClass="btn btn-xs btn-default" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last"></asp:LinkButton>
                                     <asp:Button ID="Button1" CommandName="go" CssClass="btn btn-xs btn-default" Text="GO" runat="server" />
                                    </div></div>
                                    
                            </PagerTemplate>
                                </asp:GridView>



                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-lg-4">
            <div class="card">
                <div class="text-center">
                    <div class="col-lg-3" style="margin: 20px 30% 20px 30%">
                        <asp:Button ID="Submit" runat="server" CssClass="btn btn-wd btn-warning btn-fill" ValidationGroup="submit1" Text="Checkout"  OnClick="Submit_Click" EnableViewState="False" />
                    </div>

                    <asp:UpdatePanel ID="cartUpdatePanel" runat="server" UpdateMode="Conditional" ViewStateMode="Inherit" EnableViewState="False">
                        <ContentTemplate>
                            <asp:Repeater ID="cartRepeater" runat="server" OnItemCommand="cartRepeater_ItemCommand" ViewStateMode="Disabled">
                                <HeaderTemplate>
                                    <table class="table" id="cart_tb">
                                        <tr class="category">

                                            <td>Item ID</td>
                                            <td>Amount</td>
                                            <td></td>
                                            <td>Remarks</td>
                                            <td class="text-right">Action</td>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>

                                        <td><%#Eval("itemID") %></td>
                                        <td class="text-left" style="width: 15%">
                                            <asp:TextBox ID="cart_qtyTextBox" runat="server" CssClass=" form-control" Text='<%#Eval("Qty") %>'>                                                                              
                                            </asp:TextBox>
                                        </td>
                                        <td class="text-left" style="width: 15%">
                                            <asp:RegularExpressionValidator ID="text_box_qty_alert" ClientIDMode="Static" runat="server" ForeColor="Red" ValidationGroup="submit1" ControlToValidate="cart_qtyTextBox" ValidationExpression="^-?[1-9]\d*$" ErrorMessage="Invalid"></asp:RegularExpressionValidator>
                                        </td>
                                      
                                        <td class="text-right" >
                                            <asp:TextBox ID="cart_recordTextBox"  runat="server" CssClass=" form-control" Text='<%#Eval("Record") %>'>
                                                                                    
                                            </asp:TextBox>
                                        </td>
                                        <td class="td-actions text-right">
                                            <asp:LinkButton ID="cart_deleteButton" runat="server" ForeColor="Red" CssClass=" fa fa-times" OnClick="cart_deleteBtn_Click" CommandName="delete" CommandArgument='<%# Eval("itemID") %>'></asp:LinkButton>

                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>

                        </ContentTemplate>

                    </asp:UpdatePanel>
                </div>
            </div>

        </div>
    </div>
    <script type="text/javascript">
        $().ready(function () {

            $('#registerFormValidation').validate();
            $('#loginFormValidation').validate();
            $('#allInputsFormValidation').validate();
        });

        function cartValidate() {
            var valid = true;
            $('#cart_tb tbody > tr:not(:eq(0)) input:even').each(function () {
                if (!$(this).val()) {
                    valid = false;
                    $('#text_box_qty_alert').text('Please input quantity.');
                }
            })
            $('#cart_tb tbody > tr:not(:eq(0)) input:even').each(function () {
                if (Number($(this).val()) % 1 != 0) {
                    valid = false;
                    $('#text_box_qty_alert').text('Input must be integer.');
                }
            })
            return valid;
        }
    </script>
</asp:Content>
