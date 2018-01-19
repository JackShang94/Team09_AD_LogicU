<%@ Page Title="" Language="C#" MasterPageFile="~/pages/DepartmentHead.Master" AutoEventWireup="true" CodeBehind="DH_DelegateHeadRole.aspx.cs" Inherits="Team09LogicU.pages.DH_DelegateHeadRole" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Delegate Head Role
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <form id="form1" runat="server">
        <div class="row">
        <div class="col-lg-12">
            <div class="card">
                <div class="container-fluid">
                    <div class="content">
        <asp:Label ID="Label1" runat="server" Text="Label" CssClass="title"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Label" CssClass="title"></asp:Label>
         <h3 class="category">Delegate to: <asp:Label ID="delegateStf_label" runat="server" Text="Label"></asp:Label></h3></div>
                    <div class="content">
  Employee:  <asp:DropDownList ID="employee_dropList" runat="server" CssClass="dropdown-menu"></asp:DropDownList>
  From:      
         <asp:TextBox ID="textBox_startDate" runat="server" Width="20%" TextMode="Date" CssClass="form-control"></asp:TextBox>
  To:        
         <asp:TextBox ID="textBox_endDate" runat="server" Width="20%" TextMode="Date" CssClass="form-control"></asp:TextBox>
            
            <br /> <asp:Button ID="submit_button" runat="server" Text="SUBMIT" CssClass="btn btn-primary btn-fill" OnClick="submit_button_Click" />
         
         <asp:Label ID="delegateStatus_Label" runat="server" Text="Label"></asp:Label>
         
    </div></div>
               <div class="container-fluid">
    <h3>Delegate History</h3> 
          <div class="content">
            <div class="container-fluid">

                <div class="row">
                    <div class="col-md-12">
                        <div class="card">

                            <div class="toolbar">
                                <!--        Here you can write extra buttons/actions for the toolbar              -->
                            </div>

                            <table id="bootstrap-table" class="table table-hover">
                                <thead>
                                    <th></th>
                                    <th data-field="state" data-checkbox="true"></th>
                                    <th data-field="TimeRange">Time Range</th>
                                	<th data-field="Delegateion" data-sortable="true">Delegateion</th>
                                	
                                	</thead>
                                <tbody>
                                    <%for (int i = 0; i <dList.Count; i++) { %>
                                    <tr>
                                        <td><asp:CheckBox ID="CheckBox1" runat="server" CssClass="bs-checkbox" Font-Names="<%=dList[i].delegateID %>" /></td>
                                        
                                    	<td><%=dList[i].startDate %>--<%=dList[i].endDate %></td>
                                    	<td><%=dList[i].staffID%></td>
                                    	
                                    	
                                    	
                                    </tr>
                                    <%} %>
                                     </tbody>
                            </table>
                        </div><!--  end card  -->
                    </div> <!-- end col-md-12 -->
                </div> <!-- end row -->

                <asp:GridView ID="GridView1" runat="server">
                    <Columns>
                        <asp:CheckBoxField />
                        <asp:BoundField />
                    </Columns>
                </asp:GridView>
                   </div>
                </div>
            </div></div>
         <asp:Button ID="terminate_button" runat="server" Text="TERMINATE" OnClick="terminate_button_Click" />
        <asp:Label ID="label_terminateDlgt" runat="server" Text="Label"></asp:Label>
    </form>
    
</asp:Content>
