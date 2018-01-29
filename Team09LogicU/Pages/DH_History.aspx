<%@ Page Title="" Language="C#" MasterPageFile="~/pages/DepartmentHead.Master" AutoEventWireup="true" CodeBehind="DH_History.aspx.cs" Inherits="Team09LogicU.pages.DH_History" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    History
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script src="../js/window.js"></script>
    <script src="../js/jquery-1.7.1.min.js"></script>
    <link href="../css/window.css" rel="stylesheet" />
        <div class="row">
           <div class="col-lg-12">
                <div class="card">
                    <div class=" container">
                        <div class="col-lg-10">
                      <div class ="col-lg-3" style="margin-top:20px">
                       <asp:Label ID="Label1" runat="server" Text=" From:" CssClass="category" ></asp:Label>
                        <asp:TextBox ID="txtFrom" runat="server" Width="90%" CssClass="form-control datepicker"></asp:TextBox><br>
                       </div> <div class ="col-lg-3" style="margin-top:20px">
                          <asp:Label ID="lblTo" runat="server" Text=" To:" CssClass="category"></asp:Label><br>
                          <asp:TextBox ID="txtTo" runat="server" Width="90%" CssClass="form-control datepicker"></asp:TextBox><br>
                           </div> <div class ="col-lg-6" style="margin-top:20px">
                       <asp:Label ID="Label2" runat="server" Text=" Select Name:" CssClass="category" ></asp:Label>

                           <asp:DropDownList ID="ddlStaff" runat="server" Width="40%" CssClass="form-control"></asp:DropDownList><br>
                           </div>
                        <div class ="col-lg-3" style="margin-bottom:40px">
                                    <asp:Button ID="btnSearch" runat="server" Width="90%" Text="Search" CssClass="btn btn-primary btn-fill btn-wd" OnClick="btnSearch_Click" />
                                
                            </div></div>
                           
                                        <div class="col-lg-10" style="margin-bottom:20px">
                                            <asp:GridView ID="GridView_ReqHistory" runat="server" PageSize="3" AllowPaging="true" OnPageIndexChanging="GridView_ReqHistory_PageIndexChanging" OnRowCommand="GridView_ReqHistory_RowCommand" CssClass="table bootstrap-table table-hover table-striped" HeaderStyle-CssClass=" content text-uppercase  " AutoGenerateColumns="False" EditRowStyle-CssClass="btn btn-warning btn-fill fa fa-edit" CellPadding="4" ForeColor="#333333" GridLines="None" EmptyDataText="There are no Requisitions history record">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Requisition ID" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblReqId" runat="server" Text='<%# Bind("requisitionID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="staffName" HeaderText="Requested Staff" />
                                                    <asp:BoundField DataField="requisitionDate" HeaderText="Date Submitted" />
                                                    <asp:BoundField DataField="status" HeaderText="Status" />
                                                    <asp:TemplateField HeaderText="Action" ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton_Select" runat="server" CausesValidation="False" CommandName="Select" Text="View" OnClick="LinkButton_View_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerTemplate>
                                                    <br />
                                                      <div class="col-lg-12 text-center">
                                                     <div class="col-lg-1" style="width:100px">
                                                     <asp:Label ID="lblPage" runat="server" Text='<%# "Page:" + (((GridView)Container.NamingContainer).PageIndex + 1)  + "/" + (((GridView)Container.NamingContainer).PageCount)  %> '></asp:Label></div>
                                                     <div class="col-lg-1" style="width:40px">
                                                     <asp:LinkButton ID="lbnFirst" runat="Server" Text="First" CssClass="btn btn-xs btn-success"   Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="First" ></asp:LinkButton></div>
                                                    <div class="col-lg-1" style="width:40px" >
                                                    <asp:LinkButton ID="lbnPrev" runat="server" Text="<<"  CssClass="btn btn-xs btn-success"  Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="Prev"  ></asp:LinkButton></div>
                                                     <div class="col-lg-1" style="width:40px;height:80px;margin-right:-10px;margin-left:-5px;margin-top:-10px" >
                                                        <asp:TextBox runat="server" CssClass="form-control text-center " Width="40px" Text='<%# (((GridView)Container.NamingContainer).PageIndex + 1) %>'  ID="inPageNum"></asp:TextBox></div>
                                                    <div class="col-lg-1" style="width:40px; margin-left:20px" >
                                                        <asp:LinkButton ID="lbnNext" runat="Server" Text=">>"  CssClass="btn btn-xs btn-success"  Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next" ></asp:LinkButton>
                                                     </div><div class="col-lg-1" style="width:40px;margin-left:-10px">
                                                        <asp:LinkButton ID="lbnLast" runat="Server" Text="Last"  CssClass="btn btn-xs btn-success"   Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last" ></asp:LinkButton></div>
                                                          <div class="col-lg-1" style="width:40px">
                                                         <asp:Button ID="Button1" CommandName="go"  CssClass="btn btn-xs btn-success"  Text="GO" runat="server" />
                                                     </div><br />
                                                 </PagerTemplate>
                                                <HeaderStyle CssClass=" content text-uppercase"></HeaderStyle>
                                            </asp:GridView>

                                        </div>
                                    </div>
                                    <!-- end content-->
                                </div>
                                <!--  end card  -->
                            </div>
                            <!-- end col-md-12 -->
                        </div>
                        <!-- end row -->

               
    

    

         
   
</asp:Content>
