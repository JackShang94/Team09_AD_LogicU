<%@ Page Title="" Language="C#" MasterPageFile="~/pages/DepartmentHead.Master" AutoEventWireup="true" CodeBehind="DH_DelegateHeadRole.aspx.cs" Inherits="Team09LogicU.pages.DH_DelegateHeadRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Delegate Head Role
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <div class="card">
                <div class=" container">
                    <div class="col-lg-12">
                        <div class="h4">
                            Current Role:
       <asp:Label ID="Label_logInRole" runat="server" CssClass="h5" Text="" EnableViewState="true"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:Panel ID="Panel_submitDelegate" runat="server">

                            <div class="col-lg-3 ">
                                <label class="category">Employee: </label>
                                <asp:DropDownList ID="employee_dropList" CssClass="form-control" Width="80%" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-lg-3">
                                <label class="category">From:</label>
                                <asp:TextBox ID="textBox_startDate" runat="server" Width="80%" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            </div>
                            <div class="col-lg-3">
                                <label class="category">To:</label>
                                <asp:TextBox ID="textBox_endDate" runat="server" Width="80%" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            </div>

                            <div class="col-lg-8" style="margin-top: 20px">
                                <asp:Button ID="submit_button" runat="server" CssClass="btn btn-primary btn-wd btn-fill" Text="SUBMIT" OnClick="submit_button_Click" />
                            </div>
                        </asp:Panel>
                    </div>

                    <div class="col-lg-12">
                        <h4>Delegate History:</h4>
                    </div>
                    <div class="col-lg-10">
                        <asp:GridView ID="GridView_dHistory" AllowPaging="true" PageSize="5" HeaderStyle-CssClass="text-uppercase" OnPageIndexChanging="GridView_dHistory_PageIndexChanging" OnRowCommand="GridView_dHistory_RowCommand" CssClass="table table-striped table-hover" runat="server" EmptyDataText="No delegation record">
                            <PagerTemplate>
                                <br />
                                <div class="col-lg-12 text-center">
                                    <div class="col-lg-1" style="width: 100px">
                                        <asp:Label ID="lblPage" runat="server" Text='<%# "Page:" + (((GridView)Container.NamingContainer).PageIndex + 1)  + "/" + (((GridView)Container.NamingContainer).PageCount)  %> '></asp:Label>
                                    </div>
                                    <div class="col-lg-1" style="width: 40px">
                                        <asp:LinkButton ID="lbnFirst" runat="Server" Text="First" CssClass="btn btn-xs btn-success" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="First"></asp:LinkButton>
                                    </div>
                                    <div class="col-lg-1" style="width: 40px">
                                        <asp:LinkButton ID="lbnPrev" runat="server" Text="<<" CssClass="btn btn-xs btn-success" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="Prev"></asp:LinkButton>
                                    </div>
                                    <div class="col-lg-1" style="width: 40px; height: 80px; margin-right: -10px; margin-left: -5px; margin-top: -10px">
                                        <asp:TextBox runat="server" CssClass="form-control text-center " Width="40px" ID="inPageNum"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-1" style="width: 40px; margin-left: 20px">
                                        <asp:LinkButton ID="lbnNext" runat="Server" Text=">>" CssClass="btn btn-xs btn-success" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next"></asp:LinkButton>
                                    </div>
                                    <div class="col-lg-1" style="width: 40px; margin-left: -10px">
                                        <asp:LinkButton ID="lbnLast" runat="Server" Text="Last" CssClass="btn btn-xs btn-success" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last"></asp:LinkButton>
                                    </div>
                                    <div class="col-lg-1" style="width: 40px">
                                        <asp:Button ID="Button1" CommandName="go" CssClass="btn btn-xs btn-success" Text="GO" runat="server" />
                                    </div>
                                    <br />
                            </PagerTemplate>
                            <Columns>
                                <asp:ButtonField CommandName="Select" ControlStyle-ForeColor="#0066ff" ControlStyle-CssClass=" text-center btn-xs btn-default" Text="select this record" />
                            </Columns>
                            <SelectedRowStyle BackColor="#e4e4e4" />
                        </asp:GridView>
                        <div class="col-lg-10" style="margin-top: 20px; margin-bottom: 30px">
                            <asp:Button ID="terminate_button" runat="server" Text="TERMINATE" CssClass="btn btn-wd btn-danger" OnClick="terminate_button_Click" />
                            <asp:Label ID="label_terminateDlgt" runat="server" Text=""></asp:Label>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>




</asp:Content>
