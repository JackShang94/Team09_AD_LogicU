<%@ Page Title="" Language="C#" MasterPageFile="~/pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_RO_DisbursementList.aspx.cs" Inherits="Team09LogicU.pages.SC_RO_DisbursementList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Disbursement List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="row">
        <div class="col-lg-12">
            <div class="card">
                <div class="container">

                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="disburseUpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="col-lg-3" style="margin-top: 20px">
                                <asp:Label ID="selectDepLabel" runat="server" Text="Select a Department:" CssClass="category text-uppercase"></asp:Label>
                                <asp:DropDownList ID="deptDropDownList" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="deptDropDownList_SelectedIndexChanged"></asp:DropDownList>
                            </div>


                            <div class="col-lg-12">

                                <asp:GridView ID="disburseGridView" Width="80%" runat="server" AutoGenerateColumns="false" Style="margin: 20px 0px 20px 0px" HeaderStyle-CssClass="text-uppercase" CssClass="table table-striped table-hover" OnSelectedIndexChanged="disburseGridView_SelectedIndexChanged" EmptyDataText="There is no information" SelectedRowStyle-BackColor="#eef2fd">
                                    <Columns>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="disburseIDLabel" Text='<%#Eval("disbursementID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="disburseDate" HeaderText="Date" />
                                        <asp:BoundField DataField="status" HeaderText="Status" />
                                        <asp:CommandField ShowSelectButton="true" HeaderStyle-Font-Names="Action" ControlStyle-CssClass=" text-center btn btn-xs btn-primary" SelectText="view" ButtonType="Button" />
                                    </Columns>
                                </asp:GridView>

                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:UpdatePanel ID="disburseItemUpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="col-lg-12">
                                <asp:GridView ID="disburseItemGridView" Width="80%"  runat="server" CssClass="table table-striped table-hover " HeaderStyle-CssClass=" content text-uppercase " AutoGenerateColumns="False" OnRowEditing="disburseItemGridView_RowEditing" OnRowUpdating="disburseItemGridView_RowUpdating" OnRowCancelingEdit="disburseItemGridView_RowCancelingEdit" OnRowCommand="disburseItemGridView_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None" EnableViewState="True" EmptyDataText="There is no disbursement">
                                    <Columns>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>

                                                <asp:Label ID="itemIDLabel" runat="server" Text='<%#Eval("iD") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ItemDescription" SortExpression="SortedAscendingHeaderStyle">
                                            <ItemTemplate>
                                                <asp:Label ID="ItemDescription" runat="server" Text='<%# Eval("description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Expected">
                                            <ItemTemplate>
                                                <asp:Label ID="Expected" runat="server" Text='<%# Eval("expected") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Actual">
                                            <ItemTemplate>
                                                <asp:Label ID="lblActual" runat="server" Text='<%# Eval("actual") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="Actual" CssClass="form-control" Text='<%# Eval("actual") %>' runat="server" Width="50%"></asp:TextBox>
                                                <asp:RegularExpressionValidator runat="server" ControlToValidate="Actual" ValidationExpression="^[1-9]\d*|0$" ErrorMessage="Invalid quantity!!"></asp:RegularExpressionValidator>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnEdit" CssClass="btn btn-xs btn-default" runat="server" CommandName="Edit" Text="Edit" CommandArgument='<%#Eval("itemID") %>' />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Button ID="btnUpdate" CssClass="btn btn-xs btn-danger" runat="server" CommandName="Update" Text="Update" />
                                                <asp:Button ID="btnCancel" CssClass="btn btn-xs btn-default" runat="server" CommandName="Cancel" Text="Cancel" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div class="col-lg-10" style="margin-top: 20px">
                                <asp:Label ID="label_Collection" CssClass=" category text-uppercase" runat="server">Collection Point:</asp:Label><br />
                                <asp:Label ID="collectionpointLabel" runat="server" CssClass="h6" Text=" "></asp:Label>
                            </div>
                            <div class="col-lg-10" style="margin-bottom: 20px; margin-top: 20px">
                                <asp:Button ID="ConfirmBtn" runat="server" CssClass="btn btn-warning btn-wd btn-fill " Text="Confirm" OnClick="Button3_Click" Enabled="False" />
                           
                                <asp:Button ID="NotifyButton" runat="server" CssClass="btn btn-primary btn-fill btn-wd" Text="Send Email" OnClick="NotifyButton_Click" Enabled="False" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div class="col-lg-10" style="margin-top: 20px">
                   
                        <asp:LinkButton ID="viewHisBtn" runat="server" CssClass="btn btn-success btn-fill btn-wd " Text="View History" PostBackUrl="~/Pages/SC_RO_DisbursementListHistory.aspx" />
                   
                </div>


            </div>

        </div>
    </div>


</asp:Content>
