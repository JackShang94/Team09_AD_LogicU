<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_RO_DisbursementListHistory.aspx.cs" Inherits="Team09LogicU.Pages.SC_RO_DisbursementListHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Disbursement List History
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
   
    <div class="row">
         <div class="col-lg-10">
        <div class="card">
                <div class=" container">
             
					   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <div class="col-lg-3" style="margin-top:20px" >
						<asp:Label ID="dateLabel" runat="server" Text="From:" CssClass="category"></asp:Label>
                       <asp:TextBox ID="fromTextBox" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox></div>
                        <div class="col-lg-3" style="margin-top:20px"  >
					   <asp:Label ID="Label1" runat="server" Text="To:" CssClass="category"></asp:Label>
                           <asp:TextBox ID="toTextBox" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox></div>
                         <div class="col-lg-3" style="margin-top:20px" >
						<asp:Label ID="deptLabel" runat="server" Text="Select a Department:" CssClass="category"></asp:Label>
                        <asp:DropDownList ID="deptDropDownList" CssClass="form-control" runat="server"></asp:DropDownList></div>
                    <div class="col-lg-10" style="margin-top:20px" >
					   <asp:Button ID="searchBtn" runat="server" Text="search" CssClass="btn btn-warning btn-wd btn-fill" OnClick="searchBtn_Click"></asp:Button></div>
                   
                    <div class="col-lg-10" style="margin:20px 0 20px 0">
                        
                        <asp:GridView ID="disburseHisGridView" runat="server" CssClass="table table-striped table-hover " OnSelectedIndexChanged="disburseHisGridView_SelectedIndexChanged" AutoGenerateColumns="false" EmptyDataText="There is no record">
							<Columns>
								<asp:TemplateField>
									<ItemTemplate>
										<%#Container.DataItemIndex+1 %>
									</ItemTemplate>
								</asp:TemplateField>
								<asp:TemplateField HeaderText="disbursementID">
									<ItemTemplate>
										<asp:Label runat="server" ID="disIDLabel"  Text='<%#Eval("disbursementID") %>'></asp:Label>
									</ItemTemplate>
								</asp:TemplateField>
								
								<asp:BoundField DataField="storeStaffID" HeaderText="storeStaffID"/>
								<asp:BoundField DataField="disburseDate" HeaderText="DisburseDate" />
								<asp:CommandField ShowSelectButton="true" HeaderStyle-Font-Names="Action" ControlStyle-CssClass=" text-center btn btn-xs btn-primary" ButtonType="Button" SelectText="Detail"/>
							</Columns>
                        </asp:GridView>
                          </div>

                    </div>
                     
                    
                      
                </div>
            
        </div>
    </div>
   
</asp:Content>
