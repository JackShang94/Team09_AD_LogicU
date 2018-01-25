﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_Inv_AdjVoucherDetail.aspx.cs" Inherits="Team09LogicU.Pages.SC_Inv_AdjVoucherDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    AdjustmentVoucher Deatail
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <form id ="form1" runat="server">
        
           
                <div class="row"> 
                    <div class="col-lg-12">
                        <div class="card">
                             <div class=" container" style="margin-left:-10px">
                             <div  class=" col-lg-3" style="margin-top:20px">
                                 <asp:Label ID="Labeltxtadjv" CssClass="h4" runat="server" Text="Adjustment Voucher ID: "></asp:Label>
                                 <asp:Label ID="lblAdjvID" CssClass="h5" runat="server"></asp:Label> 
                                 </div>
                              <div class=" col-lg-4" style="margin-bottom:30px ; margin-top:20px">
                                  <asp:Label ID="LabelTXTStaffid" CssClass="h4" runat="server" Text="Store Staff: "></asp:Label>  
                                  <asp:Label ID="Label_StoreStafID" CssClass="h5" runat="server"></asp:Label></div>
                                 <div class=" col-lg-4" style="margin-bottom:30px ; margin-top:20px">
                                  <asp:Label ID="LabeltxtAutBy" CssClass="h4" runat="server" Text="Authorised By: "></asp:Label>  
                                  <asp:Label ID="Label_Authorisedby" CssClass="h5" runat="server"></asp:Label></div>
                                 <div  class=" col-lg-3" style="margin-left:-60px ; margin-top:20px">
                                 <asp:Label ID="LabeltxtadjvDate" CssClass="h4" runat="server" Text="Request Date: "></asp:Label>
                                 <asp:Label ID="lblDate" CssClass="h5" runat="server"></asp:Label> 
                                 </div>
                                 <div class=" col-lg-4" style="margin-bottom:30px ; margin-top:20px">
                                  <asp:Label ID="Labeltxtstatus" CssClass="h4" runat="server" Text="Status: "></asp:Label>  
                                  <asp:Label ID="lblStatus" CssClass="h5" runat="server"></asp:Label></div>




                                 <div class=" col-lg-10" style="margin-bottom:30px ">
                                  <asp:GridView ID="GridView_detailList" runat="server" AllowPaging="true" OnPageIndexChanging="GridView_detailList_PageIndexChanging" OnRowCommand="GridView_detailList_RowCommand" CssClass="table table-hover table-striped" HeaderStyle-CssClass=" content text-uppercase  " EmptyDataText="There are no record!" EditRowStyle-CssClass="btn btn-warning btn-fill fa fa-edit" AutoGenerateDeleteButton="False" AutoGenerateEditButton="False" AutoGenerateSelectButton="False" CellPadding="4" ForeColor="#333333" GridLines="None" >
                                      
                                       <Columns>
                                                    <asp:BoundField DataField="adjVItemID" HeaderText="Adjustment Voucher ID:" />
                                                    <asp:BoundField DataField="itemID" HeaderText="itemID:" />
                                                    <asp:BoundField DataField="quantity" HeaderText="quantity:" />         
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
                                            <asp:TextBox runat="server" CssClass="form-control text-center " Width="40px"  ID="inPageNum"></asp:TextBox></div>
                                        <div class="col-lg-1" style="width:40px; margin-left:20px" >
                                            <asp:LinkButton ID="lbnNext" runat="Server" Text=">>"  CssClass="btn btn-xs btn-success"  Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next" ></asp:LinkButton>
                                         </div><div class="col-lg-1" style="width:40px;margin-left:-10px">
                                            <asp:LinkButton ID="lbnLast" runat="Server" Text="Last"  CssClass="btn btn-xs btn-success"   Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last" ></asp:LinkButton></div>
                                              <div class="col-lg-1" style="width:40px">
                                             <asp:Button ID="Button1" CommandName="go"  CssClass="btn btn-xs btn-success"  Text="GO" runat="server" />
                                         </div><br />
                                     </PagerTemplate>
                                      <AlternatingRowStyle BackColor="White" />
                                </asp:GridView> <asp:Label ID="label4" runat="server" CssClass="category" Text=" Remarks:"></asp:Label>
                                     <p></p>
                                 <asp:TextBox ID="TextBox_Remarks" style="resize:none" CssClass="form-control" runat="server" TextMode="MultiLine" ></asp:TextBox>
                               </div>  </div>
                             <div  class=" col-lg-10" style="margin-top:20px">
                              
                             
                            <asp:Button ID="Btn_Back"  runat="server" Text="Back"  CssClass="btn btn-danger btn-fill btn-wd " OnClick="Btn_Back_Click" />
                             </div>
                          </div>
                          </div>
                          </div>
        </form>
</asp:Content>
