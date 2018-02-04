<%@ Page Title="" Language="C#" MasterPageFile="~/pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_RO_OutstandingRequisition.aspx.cs" Inherits="Team09LogicU.pages.SC_RO_OutstandingRequisition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Outstanding Requisition
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="row">
        <div class="col-lg-12">
            <div class="card">
                <div class=" container">


                    <div class="col-lg-3" style="margin: 20px 0 20px 0">
                        <asp:Label ID="deptLabel" runat="server" Text="Select a Department:" CssClass="category"></asp:Label>
                        <asp:DropDownList ID="deptDropDownList" CssClass="form-control" runat="server" OnSelectedIndexChanged="deptDropDownList_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>

                    </div>
                    <div class="col-lg-10" style="margin-bottom: 20px">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <%--<asp:LinkButton ID="viewHisButton" runat="server">View Disbursement List History</asp:LinkButton>--%>
                                <asp:GridView ID="outstandingGridView" Width="90%" runat="server" CssClass="table table-striped table-hover " AutoGenerateColumns="false" EmptyDataText="There is no outstanding requisitions">
                                    <Columns>
                                        <asp:BoundField DataField="itemDesc" HeaderText="item" />
                                        <asp:BoundField DataField="unit" HeaderText="unit" />
                                        <asp:BoundField DataField="needed" HeaderText="expectedQuantity" />
                                        <asp:BoundField DataField="disburseDate" HeaderText="DisburseDate" />
                                    </Columns>
                                </asp:GridView>
                                <%--	<div class="col-lg-10">
																
																<asp:Label ID="Label" runat="server" Text="Collection Point:"></asp:Label>
																<asp:Label ID="collectionpointLabel" runat="server" Text=""></asp:Label>
															  </div> --%>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
