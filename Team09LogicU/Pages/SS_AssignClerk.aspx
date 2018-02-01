<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreSupervisor.Master" AutoEventWireup="true" CodeBehind="SS_AssignClerk.aspx.cs" Inherits="Team09LogicU.Pages.SS_AssignClerk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">



    <div class="row">
        <div class="col-lg-10">
            <div class="card">
                <div class=" container">
                    <div class="col-lg-10" style="margin-top: 20px; margin-bottom: 20px">
                        <asp:Label ID="Label3" runat="server" CssClass="h5" Text=" Category:"></asp:Label>
                        <asp:GridView ID="GridView_AssignClerk" CssClass="table table-striped  table-hover" runat="server" ShowHeaderWhenEmpty="false" HeaderStyle-CssClass="text-uppercase" EmptyDataText="There is no disbursement list now!" AutoGenerateColumns="False">

                            <Columns>
                                <asp:TemplateField HeaderText="Collection Point Name" SortExpression="SortedAscendingHeaderStyle">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemID" runat="server" Text='<%# Eval("collectionPointName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Department">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemID" runat="server" Text='<%# Eval("deptID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemID" runat="server" Text='<%# Eval("status") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>

                            <HeaderStyle CssClass=" content text-uppercase  " />

                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-10">
            <div class="card">
                <div class=" container">
                    <div class="col-lg-4" style="margin: 20px 0 20px 0">
                        <asp:Label ID="Label_CollectionPoint1" CssClass="category" runat="server"></asp:Label>

                        <asp:DropDownList ID="dropdownlist1" runat="server" class="form-control" Width="200px"></asp:DropDownList>
                    </div>


                    <div class="col-lg-4" style="margin: 20px 0 20px 0">
                        <asp:Label ID="Label_CollectionPoint2" CssClass="category" runat="server"></asp:Label>

                        <asp:DropDownList ID="dropdownlist2" runat="server" class="form-control" Width="200px"></asp:DropDownList>

                    </div>
                    <div class="col-lg-4" style="margin: 20px 0 20px 0">

                        <asp:Label ID="Label_CollectionPoint3" CssClass="category" runat="server"></asp:Label>

                        <asp:DropDownList ID="dropdownlist3" runat="server" class="form-control" Width="200px"></asp:DropDownList>

                    </div>

                    <div class="col-lg-4" style="margin: 20px 0 20px 0">
                        <asp:Label ID="Label_CollectionPoint4" CssClass="category" runat="server"></asp:Label>

                        <asp:DropDownList ID="dropdownlist4" runat="server" class="form-control" Width="200px"></asp:DropDownList>
                    </div>
                    <div class="col-lg-4" style="margin: 20px 0 20px 0">

                        <asp:Label ID="Label_CollectionPoint5" CssClass="category" runat="server"></asp:Label>


                        <asp:DropDownList ID="dropdownlist5" runat="server" class="form-control" Width="200px"></asp:DropDownList>

                    </div>
                    <div class="col-lg-4" style="margin: 20px 0 20px 0">

                        <asp:Label ID="Label_CollectionPoint6" CssClass="category" runat="server"></asp:Label>


                        <asp:DropDownList ID="dropdownlist6" runat="server" class="form-control" Width="200px"></asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:Button ID="Btn_Approve" runat="server" Text="Approve" CssClass="btn btn-warning btn-fill btn-wd " OnClick="Btn_Approve_Click" />


</asp:Content>
