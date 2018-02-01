<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_O_SOA.aspx.cs" Inherits="Team09LogicU.Pages.SC_O_SOA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 SOA Report
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div class="row">
            <div class="col-lg-10">
                <div class="card">
                    <div class=" container">
                        
                            <div class="col-lg-3" style="margin-top: 20px">
                                <asp:label id="lblFrom" runat="server" text=" From:" cssclass="category"></asp:label>
                                <asp:textbox id="txtFrom" runat="server" cssclass="form-control " TextMode="Date" ></asp:textbox>
                                <br>
                            </div>
                            <div class="col-lg-3" style="margin-top: 20px">
                                <asp:label id="lblTo" runat="server" text=" To:" cssclass="category"></asp:label>
                                <br>
                                <asp:textbox id="txtTo" runat="server" cssclass="form-control" TextMode="Date"></asp:textbox>
                                <br>
                            </div>
                            <div class="col-lg-6" style="margin-top: 20px">
                                <asp:label id="lblSelect" runat="server" text=" Select Department:" cssclass="category"></asp:label>

                                <asp:dropdownlist id="ddlDepartment" runat="server" width="40%" cssclass="form-control"></asp:dropdownlist>
                                <br>
                            </div>
                            <div class="col-lg-6" style="margin-bottom: 20px">
                                <asp:button id="btnSearch" runat="server"  text="Search" cssclass="btn btn-warning btn-fill btn-wd"  />
                                <asp:button id="btnPrint" runat="server"  text="Print" cssclass="btn btn-primary btn-fill btn-wd"  />

                            </div>
                        </div></div></div></div>
    <div id="PrintContent"  runat="server">
             <div class="row">
            <div class="col-lg-10">
                <div class="card">
                   
                            <asp:gridview id="GridView_SOA" runat="server" cssclass="table  table-hover table-striped" headerstyle-cssclass=" content text-uppercase  " autogeneratecolumns="False" editrowstyle-cssclass="btn btn-warning btn-fill fa fa-edit" 
                                cellpadding="4" forecolor="#333333" gridlines="None" ShowHeaderWhenEmpty="true" emptydatatext="There are no SOA  record">
                                                <AlternatingRowStyle BackColor="White" />
                                               
                                                <HeaderStyle CssClass=" content text-uppercase"></HeaderStyle>
                                            </asp:gridview>
                        </div>
                        </div>
                    </div>
                    <!-- end content-->
                </div>
    <script type="text/javascript">
function Print() { 
var pc = document.getElementById("<%=PrintContent.ClientID%>"); 
var pw = window.open('', '', 'width=1000,height=800'); 
pw.document.write(pc.innerHTML); 
pw.document.close(); 
setTimeout(function () { pw.print(); }, 500); 
return false; 
} 
</script>
</asp:Content>
