<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Employee.Master" AutoEventWireup="true" CodeBehind="Emp_SR_CheckOut.aspx.cs" Inherits="Team09LogicU.Pages.Emp_SR_CheckOut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 Cart Detail
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
                            <form id="form1" runat="server">
                                <div class="col-md-12">
                        <div class="card">

                            <div class="toolbar">
                                <!--        Here you can write extra buttons/actions for the toolbar              -->
                            </div>
                                <div class="content">
                                <h4 class="title">Summary of Requested Item</h4>
                                <p class="category">Requisition No： DCS/222/11</p>
                            </div>
                                <div class="content">
                                <table id="bootstrap-table" class="table table-striped">
                                <thead >
                                    
                                    <th data-field="description">Item Description</th>
                                	
                                	<th data-field="amount" class="text-center">Amount</th>
                                	
                                	
                                	<th data-field="actions" class="td-actions text-right" data-events="operateEvents" data-formatter="operateFormatter">Actions</th>
                                </thead>
                                    <tbody>
                                    <tr>
                                        
                                    	<td>Clips Double</td>
                                    	<td class="text-center">20</td>
                                    	
                                    	
                                    <td class="td-actions text-right" style="">
                                        <a rel="tooltip" title="Remove" class="btn btn-simple btn-danger btn-icon " href="javascript:void(0)">
                                        <i class="fa fa-remove"></i></a>
                                       </td>
                                    </tr>
                                    <tr>
                                        
                                    	<td>Clips Double</td>
                                    	<td class="text-center">20</td>
                                    	
                                    	
                                    <td class="td-actions text-right" style="">
                                        <a rel="tooltip" title="Remove" class="btn btn-simple btn-danger btn-icon " href="javascript:void(0)">
                                        <i class="fa fa-remove"></i></a>
                                       </td>
                                    </tr>
                                    <tr>
                                        
                                    	<td>Clips Double</td>
                                    	<td class="text-center">20</td>
                                    	
                                    	
                                    <td class="td-actions text-right" style="">
                                        <a rel="tooltip" title="Remove" class="btn btn-simple btn-danger btn-icon " href="javascript:void(0)">
                                        <i class="fa fa-remove"></i></a>
                                       </td>
                                    </tr>
                                    <tr>
                                        
                                    	<td>Clips Double</td>
                                    	<td class="text-center">20</td>
                                    	
                                    	
                                    <td class="td-actions text-right" style="">
                                        <a rel="tooltip" title="Remove" class="btn btn-simple btn-danger btn-icon " href="javascript:void(0)">
                                        <i class="fa fa-remove"></i></a>
                                       </td>
                                    </tr>
                  </tbody>
             </table>
             </div>
                            </div>
       </div>
                               
                                    <div class="row button-container buttons-with-margin">
                                        <div>
                                            <div style="margin-left:2%">
                                        <asp:Button ID="Button1" runat="server" Width="12%" Text="Back to Add Item" CssClass="btn btn-warning btn-fill" PostBackUrl="~/Pages/Emp_SubmitRequisition.aspx" />
                                          
                                        <asp:Button ID="Button2" runat="server" Width="12%" Text="Submit" CssClass="btn btn-primary btn-fill" PostBackUrl="~/Pages/Emp_MyRequisition.aspx" /> 
                                       
                                             <asp:Button ID="Button3" runat="server" Width="12%" Text="Cancel" CssClass="btn btn-wd btn-default" PostBackUrl="~/Pages/Emp_SubmitRequisition.aspx" />
                                    </div>
                                           </div>
                                    </div>
                                       
                            
            
                                
    </form>
      
</asp:Content>
