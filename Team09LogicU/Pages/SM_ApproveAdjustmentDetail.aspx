﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreManager.Master" AutoEventWireup="true" CodeBehind="SM_ApproveAdjustmentDetail.aspx.cs" Inherits="Team09LogicU.Pages.SM_ApproveAdjustmentDetail" %>
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
                                   <asp:Label ID="label_VoucherId" runat="server" Text="12233 "></asp:Label>  </p> 
                              <p class="category">   
                                  <asp:Label ID="label2" runat="server" Text=" Date Issued:"></asp:Label>
                                    <asp:Label ID="label_DateIssued" runat="server" Text="11/12/2017: "></asp:Label> </p> 
         
                              <p class="category">    
                                  <asp:Label ID="Label3" runat="server" Text="Submitted Employee: "></asp:Label>
                                 <asp:Label ID="label_SubmittedEmployee" runat="server" Text="Mike "></asp:Label></p>   
                            </div> 
                            <p>
                       
                                <asp:GridView ID="GridView1" runat="server" CssClass="table bootstrap-table table-hover table-striped" HeaderStyle-CssClass=" content text-uppercase  "  AllowPaging="True" EditRowStyle-CssClass="btn btn-warning btn-fill fa fa-edit" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" GridLines="None" >


                                     <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>

                            </p>
                     </div>
         
        </div>
     </div>
   </div>
 </div>                         
  
    <asp:Button ID="Btn_Approve"  runat="server" Text="Approve" CssClass="btn btn-primary btn-fill btn-wd " /> 
    <asp:Button ID="Btn_Reject"  runat="server" Text="Reject"  CssClass="btn btn-danger btn-fill btn-wd " />
    <asp:Button ID="Btn_Back"  runat="server"  Text="Back"  CssClass="btn btn-default  btn-fill btn-wd"   />

        </form>
</asp:Content>