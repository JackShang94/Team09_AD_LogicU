<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Employee.Master" AutoEventWireup="true" CodeBehind="Emp_MyRequisition.aspx.cs" Inherits="Team09LogicU.pages.Emp_MyRequisition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    My Requisition
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
   <div class="col-md-12">
                        <div class="card">

                            <div class="toolbar">
                                <!--        Here you can write extra buttons/actions for the toolbar              -->
                            </div> <form id="form1" runat="server">
                                <div class="content" >
                            <h4 class=" panel-title">Search by Request Date:<asp:TextBox ID="TextBox1" runat="server" CssClass="search" TextMode="Date"></asp:TextBox></h4>
                                    
                           
                            </div> 
                                <table id="bootstrap-table" class="table">
                                <thead >
                                    <th></th>
                                    <th data-field="id">requisition ID</th>
                                	<th data-field="name" data-sortable="true">employee</th>
                                	<th data-field="salary" data-sortable="true">date</th>
                                	<th data-field="country" data-sortable="true">status</th>
                                	
                                	<th data-field="actions" class="td-actions text-center" data-events="operateEvents" data-formatter="operateFormatter">Actions</th>
                                </thead>
                                    <tbody>
                                    <tr>
                                        <td></td>
                                    	<td>1</td>
                                    	<td>Employee1</td>
                                    	<td>2017-01-01</td>
                                    	<td>Pending</td>
                                    	
                                        <td class="td-actions text-center" style="">
                                            <a rel="tooltip" title="View" class="btn btn-simple btn-info btn-icon table-action view" href="javascript:void(0)">
                                            <i class="fa fa-image"></i></a>
                                             <a rel="tooltip" title="Edit" class="btn btn-simple btn-warning btn-icon table-action edit" href="javascript:void(0)">
                                            <i class="fa fa-edit"></i></a>
                                             <a rel="tooltip" title="Delete" class="btn btn-simple btn-danger  btn-icon table-action remove" href="javascript:void(0)">
                                            <i class="fa fa-remove "></i></a>
                                       </td>
                                    </tr>
                  </tbody>
             </table>
    </form>
                            </div>
       </div>

  
</asp:Content>

