<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Employee.Master" AutoEventWireup="true" CodeBehind="Emp_Rep_DisbursementHistory.aspx.cs" Inherits="Team09LogicU.pages.Emp_Rep_RequisitionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 Requisition History
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <form id="form1" runat="server">
         <div class="col-lg-10" style="margin-bottom: 20px">
                   <asp:gridview id="deptDisbursementList" runat="server" cssclass="table bootstrap-table table-hover table-striped" headerstyle-cssclass=" content text-uppercase  " autogeneratecolumns="False" editrowstyle-cssclass="btn btn-warning btn-fill fa fa-edit" cellpadding="4" forecolor="#333333" gridlines="None" emptydatatext="There are no Purchase Order history record" OnSelectedIndexChanged="deptDisbursementList_SelectedIndexChanged">
                      <AlternatingRowStyle BackColor="White" />
                         <Columns>
                            <asp:TemplateField HeaderText="Disbursement ID" Visible="True">
                                 <ItemTemplate>
                                      <asp:Label ID="disbID" runat="server" Text='<%# Bind("disbursementID") %>'></asp:Label>
                                  </ItemTemplate>
                             </asp:TemplateField>
                              <asp:BoundField DataField="disburseDate" HeaderText="Disbursement Date" />
                              <asp:BoundField DataField="status" HeaderText="Status" />
                              <asp:TemplateField HeaderText="Action" ShowHeader="False">
                              <ItemTemplate>
                              <asp:LinkButton ID="LinkButton_View" runat="server" CausesValidation="False" Text="View" OnClick="LinkButton_View_Click"></asp:LinkButton>
                              </ItemTemplate>
                              </asp:TemplateField>
                              </Columns>
                              <HeaderStyle CssClass=" content text-uppercase"></HeaderStyle>
                              </asp:gridview>
                </div><p>  
                        <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
                        </p>  
                 <div style="margin-left:5%">

            </div>
      </form>
</asp:Content>
