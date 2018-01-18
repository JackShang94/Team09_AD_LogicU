<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreSupervisor.Master" AutoEventWireup="true" CodeBehind="SS_ViewAdjustment.aspx.cs" Inherits="Team09LogicU.Pages.SS_ViewAdjustment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

        <form runat="server">
     <div> 
    <p class="Content1">
                <span>Search：</span><input class="txtwenben" type="number"  id="VoucherId" name="txtanme" placeholder="VoucherId" />
                <button class="btncxan" id="btnchaxun" name="btnchaxun">查询</button>
            </p>
    </div>
     


    <div class="card">
                            <div class="header">SEARCH</div>
                                    <div>
                                        <label class="col-md-3 control-label">Voucher#</label>
                                        <div class="col-md-9">
                                            <input type="number" placeholder="VoucherId" >
                                        </div>
                                            <button type="submit" class="btn btn-fill btn-info">Search</button>
                                       
                                    
                               
                            </div>
       </div> <!-- end card -->


     <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-6">
                        <div class="card">
                            <div class="header">
                                <h4 class="title">Table with Links</h4>
                                <p class="category">Here is a subtitle for this table</p>
                            </div>
                            <div class="content table-responsive table-full-width">
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <th class="text-center">#</th>
                                            <th>Voucher</th>
                                            <th>Submitted Employee</th>
                                            <th class="text-right">Date Issued</th>
                                            <th>status</th>
                                            <th class="text-right">Actions</th>
                                        </tr>
                                    </thead>

                                    <tbody>
                                        <tr>
                                           
                                            <td class="text-center">1</td>
                                            <td>Andrew Mike</td>
                                            <td>Develop</td>
                                            <td class="text-right">&euro; 99,225</td>
                                            <td class="text-right">Pending</td>
                                            <td class="td-actions text-right">
                <%-- ??  这里引用aspx有问题 --%>                          <%--  <a href="#SS_ViewAdjustmentDetail.aspx" rel="tooltip" title="View Profile" class="btn btn-info btn-simple btn-xs">--%>
                                                  <%--  <i class="fa fa-user"></i>
                                                </a>--%>
                                                <asp:LinkButton ID="Linkbutton_View" runat="server" NavigateUrl="SS_ViewAdjustmentDetail.aspx" Text="View"></asp:LinkButton>
                                            </td>
                                        </tr>
                                     </tbody>



                                </table>
                            </div>
             <%--  <div class="content table-responsive table-full-width">
                             <ul style="overflow:hidden;width:100%">--%>
         <%--   <%foreach(  Voucher in Voucherlist) { %>
            <li style="width:33.3333%;float:left;">
                <div >
                     <img src="images/<%=Voucher.VoucherId %>.jpg" class="img-responsive" alt=""/>
                        <div >
						 <p>
                             <a href="SS_ViewAdjustmentDetail.aspx?VoucherId=<%=Voucher.VoucherId%>&Title=<%=Voucher.Title %>&Price=<%=Voucher.Price %>&Stock=<%=Voucher.Stock %>"  class="acount-btn" >View Details</a>
						 </p>
                          
                        
                        </div>
                        </div>
                      </li>
                      <%  } %>
             
        </ul>
                            </div>--%>
                        </div>
                    </div>
                </div>
           </div>
     </div>
             </form>

</asp:Content>
