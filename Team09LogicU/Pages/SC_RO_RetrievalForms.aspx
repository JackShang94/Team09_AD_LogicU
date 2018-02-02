<%@ Page Title="" Language="C#" MasterPageFile="~/pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_RO_RetrievalForms.aspx.cs" Inherits="Team09LogicU.pages.SC_RO_RetrievalForms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
Retrieval Forms
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
       <div class="row">
           <div class="col-lg-8">
                <div class="card">
                    <div class="container ">
                        <div class="col-lg-8" style="margin:20px 0px 20px 0px">
		<label class="category text-uppercase">Following are the Retrievals before : </label>
                            <asp:Label runat="server" ID="dateLablel" CssClass="h6" Text=""> </asp:Label></div> 
                            <div class="col-lg-8 " style="margin:0px 0px 20px 0px" >
		<asp:Button ID="confirmBtn" CssClass="btn btn-wd btn-warning btn-fill"   runat="server"  Text="confirm" OnClick="confirmBtn_Click"/></div>
        
<div class="col-lg-8">
		<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
		<asp:UpdatePanel ID="retrievalUpdatePanel" runat="server" UpdateMode="Conditional">
			<ContentTemplate>
				<asp:GridView ID="retrievalGridView" style="margin:0px 0px 20px 0px" Width="85%" HeaderStyle-CssClass="text-uppercase" CssClass="table table-striped table-hover" runat="server" OnRowDataBound="retrievalGridView_RowDataBound"  AutoGenerateColumns="false" OnRowCommand="retrievalGridView_RowCommand" OnSelectedIndexChanged="retrievalGridView_SelectedIndexChanged"  EmptyDataText="There is no information"
				 SelectedRowStyle-BackColor="#eef2fd">
					<columns>
						<asp:TemplateField>
							<ItemTemplate>
								<%# Container.DataItemIndex+1 %>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField Visible="false">
							<ItemTemplate>
								<asp:Label ID="itemIDLabel" runat="server" Text='<%#Eval("itemID") %>'></asp:Label>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Satationery Description">
							<ItemTemplate>
								<asp:Label runat="server" Text='<%#Eval("ItemDescription") %>'></asp:Label>
							</ItemTemplate>
						</asp:TemplateField >
						<asp:TemplateField HeaderText="Needed">
							<ItemTemplate>
								<asp:Label runat="server" Text='<%#Eval("Needed") %>'></asp:Label>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Retrieved">
							<ItemTemplate>
								<asp:Label runat="server" Text='<%#Eval("Actual") %>'></asp:Label>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Location">
							<ItemTemplate>
								<asp:Label runat="server" Text='<%#Eval("location") %>'></asp:Label>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:CommandField ShowSelectButton="true" HeaderStyle-Font-Names="Action" ControlStyle-CssClass=" text-center btn btn-xs btn-primary"  SelectText="view" ButtonType="Button"/>
						
					</columns>
				</asp:GridView>
				</ContentTemplate>
			
		</asp:UpdatePanel>
		</div></div></div></div>
    
		<asp:UpdatePanel ID="breakdownUpdatePanel" runat="server" UpdateMode="Conditional">
			<ContentTemplate>
				
           <div class="col-lg-4">
                <div class="card">
                    <div class="container ">
                        <div class="col-lg-4" style="margin:20px 0px 20px 0px">
				<asp:GridView ID="breakdownGridView" EmptyDataText="There is no information" Width="85%" CssClass="table table-striped table-hover"  HeaderStyle-CssClass="text-uppercase" runat="server" AutoGenerateColumns="false" OnRowEditing="breakdownGridView_RowEditing" OnRowUpdating="breakdownGridView_RowUpdating" OnRowCancelingEdit="breakdownGridView_RowCancelingEdit" SelectedRowStyle-Height="100px" OnRowUpdated="breakdownGridView_RowUpdated">
					<Columns>
						<asp:TemplateField HeaderText="Dept name">
							<ItemTemplate>
								<asp:label runat="server" id="deptID"  Text='<%#Eval("deptID")%>'></asp:label>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Needed">
							<ItemTemplate>
								<asp:label runat="server" id="needed"  Text='<%#Eval("needed") %>'></asp:label>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Actual">
							<ItemTemplate>
								<asp:Label runat="server" ID="actualLabel" Text='<%#Eval("actual") %>'></asp:Label>							
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox runat="server" ID="actualTextBox" CssClass="form-control" Width="50%" Text='<%#Eval("actual") %>'></asp:TextBox>
								<asp:RegularExpressionValidator runat="server" ControlToValidate="actualTextBox" ValidationExpression="^[1-9]\d*|0$" ErrorMessage="Invalid quantity!!"></asp:RegularExpressionValidator>
							</EditItemTemplate>
						</asp:TemplateField>
						<%--<asp:BoundField DataField="actual" HeaderText="Actual"/>--%>
						<asp:TemplateField HeaderText="action">
								<EditItemTemplate>
									<asp:LinkButton ID="actual_qtyUpdate" runat="server" Text="update" CssClass="btn btn-xs btn-danger"  CommandName="Update" CommandArgument='<%#Eval("deptID") %>'  EnableViewState="True" ></asp:LinkButton><!-- -->
									<asp:LinkButton ID="actual_qtyCancel" runat="server" Text="Cancel" CssClass="btn btn-xs btn-default" CommandName="Cancel" CommandArgument='<%#Eval("deptID") %>' EnableViewState="True"></asp:LinkButton>
							</EditItemTemplate>
							<ItemTemplate>
								<asp:LinkButton ID="actual_qtyEdit" CssClass="btn btn-xs btn-warning" Text="Edit" runat="server"  CommandName="edit" CommandArgument='<%#Eval("deptID") %>' EnableViewState="True"></asp:LinkButton>
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
				</asp:GridView> 
               </div></div></div></div></div>
				</ContentTemplate>
		</asp:UpdatePanel>
   </div>
</asp:Content>
