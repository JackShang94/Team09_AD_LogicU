<%@ Page Title="" Language="C#" MasterPageFile="~/pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_RO_RetrievalForms.aspx.cs" Inherits="Team09LogicU.pages.SC_RO_RetrievalForms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
Retrieval Forms
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <form id="form1" runat="server">
		<label>Following are the Retrievals before :</label><asp:Label runat="server" ID="dateLablel" Text=""> </asp:Label>
<%--		<asp:TextBox ID="beforeDate" runat="server" TextMode="Date"></asp:TextBox>
		<asp:Button ID="searchBtn" runat="server" Text="search" OnClick="searchBtn_Click" />--%>
		<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
		<asp:UpdatePanel ID="retrievalUpdatePanel" runat="server" UpdateMode="Conditional">
			<ContentTemplate>
				<asp:GridView ID="retrievalGridView" runat="server" OnRowDataBound="retrievalGridView_RowDataBound"  AutoGenerateColumns="false" OnRowCommand="retrievalGridView_RowCommand" OnSelectedIndexChanged="retrievalGridView_SelectedIndexChanged"  EmptyDataText="There is no information"
				 SelectedRowStyle-BackColor="Red">
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
						<asp:CommandField ShowSelectButton="true"  SelectText="view" ButtonType="Button"/>
						
					</columns>
				</asp:GridView>
				</ContentTemplate>
			
		</asp:UpdatePanel>
		
		<asp:UpdatePanel ID="breakdownUpdatePanel" runat="server" UpdateMode="Conditional">
			<ContentTemplate>
				<%--need to highlight the selected row--%>
				<asp:GridView ID="breakdownGridView" runat="server" AutoGenerateColumns="false" OnRowEditing="breakdownGridView_RowEditing" OnRowUpdating="breakdownGridView_RowUpdating" OnRowCancelingEdit="breakdownGridView_RowCancelingEdit" SelectedRowStyle-Height="100px" OnRowUpdated="breakdownGridView_RowUpdated">
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
								<asp:TextBox runat="server" ID="actualTextBox" Text='<%#Eval("actual") %>'></asp:TextBox>
								<asp:RegularExpressionValidator runat="server" ControlToValidate="actualTextBox" ValidationExpression="^[1-9]\d*|0$" ErrorMessage="Invalid quantity!!"></asp:RegularExpressionValidator>
							</EditItemTemplate>
						</asp:TemplateField>
						<%--<asp:BoundField DataField="actual" HeaderText="Actual"/>--%>
						<asp:TemplateField HeaderText="action">
								<EditItemTemplate>
									<asp:LinkButton ID="actual_qtyUpdate" runat="server" Text="update"  CommandName="Update" CommandArgument='<%#Eval("deptID") %>'  EnableViewState="True" ></asp:LinkButton><!-- -->
									<asp:LinkButton ID="actual_qtyCancel" runat="server" Text="Cancel" CommandName="Cancel" CommandArgument='<%#Eval("deptID") %>' EnableViewState="True"></asp:LinkButton>
							</EditItemTemplate>
							<ItemTemplate>
								<asp:LinkButton ID="actual_qtyEdit" runat="server"  CommandName="edit" CommandArgument='<%#Eval("deptID") %>' EnableViewState="True"><i class="fa fa-edit"></i></asp:LinkButton>
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
				</asp:GridView>
				</ContentTemplate>
		</asp:UpdatePanel>
		<asp:Button ID="confirmBtn"  runat="server" Text="confirm" OnClick="confirmBtn_Click"/>
    </form>
</asp:Content>
