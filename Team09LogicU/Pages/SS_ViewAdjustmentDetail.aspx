﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreSupervisor.Master" AutoEventWireup="true" CodeBehind="SS_ViewAdjustmentDetail.aspx.cs" Inherits="Team09LogicU.Pages.SS_ViewAdjustmentDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    View Adjustment Detail
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <form id ="form1" runat="server">
         <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-9">
                        <div class="card">
                            <div class="header">
                             <p class="category">
                                  <asp:Label ID="label1" runat="server" Text="Voucher: "></asp:Label>
                                   <asp:Label ID="label_VoucherId" runat="server" Text="12233 "></asp:Label>  </p> <%--此处传值--%>
                              <p class="category">   
                                  <asp:Label ID="label2" runat="server" Text=" Date Issued:"></asp:Label>
                                    <asp:Label ID="label_DateIssued" runat="server" Text="11/12/2017: "></asp:Label> </p> <%--此处传值--%>
         
                              <p class="category">    
                                  <asp:Label ID="Label3" runat="server" Text="Submitted Employee: "></asp:Label>
                                 <asp:Label ID="label_SubmittedEmployee" runat="server" Text="Mike "></asp:Label></p>   <%--此处传值--%>
                            </div> 
                            <p>
                        <table id="bootstrap-table" class="table table-hover table-striped">
                                <thead >
                                    <%--此处传值--%>
                                    <th data-field="itemCode" class=" text-center">ItemCode</th>
                                	<th data-field="adjustedQTY" data-sortable="true" class=" text-center">adjustedQTY</th>
                                	<th data-field="unitPrice" data-sortable="true" class=" text-center">UnitPrice</th>
                                	<th data-field="reason" data-sortable="true" class=" text-center">Reason</th>      
                                </thead>

                                    <tbody>
                                    <tr>
                                        <td class=" text-center">123</td>
                                    	<td class=" text-center">1</td>
                                    	<td class=" text-center">12</td>
                                    	<td class=" text-center">Damage</td>                                   
                                    </tr>
                                         <tr>
                                        <td class=" text-center">123</td>
                                    	<td class=" text-center">1</td>
                                    	<td class=" text-center">12</td>
                                    	<td class=" text-center">Damage</td>
                                    </tr>
                                    </tbody>
                         </table>
                            </p>
                     </div>
         
        </div>
     </div>
   </div>
 </div>                         
                          
  
    <asp:Button ID="Btn_Approve"  runat="server" Text="Approve" CssClass="btn btn-primary btn-fill btn-wd " /> <%--此处点击事件--%>
    <asp:Button ID="Btn_Reject"  runat="server" Text="Reject"  CssClass="btn btn-danger btn-fill btn-wd " /><%--此处点击事件--%>
    <asp:Button ID="Btn_Back"  runat="server"  Text="Back"  CssClass="btn btn-default  btn-fill btn-wd"   /><%--此处点击事件--%>
    <%-- <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="Data Source=(local);Initial Catalog=LogicU;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [itemId], [categoryId], [description], [unitOfMeasure] FROM [Items] WHERE ([categoryId] = @categoryId)">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddl_Category" Name="categoryId" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>--%> <%--链接数据库？？？？--%>
        </form>
</asp:Content>
