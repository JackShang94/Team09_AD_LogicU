<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreSupervisor.Master" AutoEventWireup="true" CodeBehind="SS_ViewAdjustmentDetail.aspx.cs" Inherits="Team09LogicU.Pages.SS_ViewAdjustmentDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    View Adjustment Detail
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <form runat="server">
     <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Pages/SS_ViewAdjustment.aspx">View My Adjustment </asp:HyperLink> / <i class="fa fa-file"></i> Adjustment Details
     <table>
     <tr><td>
            <asp:Label ID="Label_VoucherId" runat="server" Text="Voucher: "></asp:Label>
         <br />
            <asp:Label ID="Label_DateIssued" runat="server" Text=" Date Issued:"></asp:Label>
         <br />
            <asp:Label ID="Label1_SubmittedEmployee" runat="server" Text="Submitted Employee: "></asp:Label>
        </td>
             </tr>
            </table>
                <table><tr>
        <asp:GridView ID="GridView_AdjustmentDetail" runat="server"  >
            <Columns>
                <asp:BoundField DataField="itemCode" HeaderText="ItemCode" SortExpression="itemCode" />
                <asp:BoundField DataField="adjustedQTY" HeaderText="adjustedQTY" SortExpression="adjustedQTY" />
                <asp:BoundField DataField="unitPrice" HeaderText="UnitPrice" SortExpression="unitPrice" />
                 <asp:BoundField DataField="reason" HeaderText="Reason" SortExpression="reason" />
            </Columns>
        </asp:GridView>
                   
                </tr>
                 </table>

    <asp:Button ID="Btn_Approve"  runat="server" Text="Approve"  />
    <asp:Button ID="Btn_Reject"  runat="server" Text="Reject"  />
    <asp:Button ID="Btn_Back"  runat="server" Text="Back"  />
    <%-- <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="Data Source=(local);Initial Catalog=LogicU;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [itemId], [categoryId], [description], [unitOfMeasure] FROM [Items] WHERE ([categoryId] = @categoryId)">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddl_Category" Name="categoryId" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>--%> <%--链接数据库？？？？--%>
        </form>
</asp:Content>
