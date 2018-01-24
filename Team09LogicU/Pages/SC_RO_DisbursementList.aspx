<%@ Page Title="" Language="C#" MasterPageFile="~/pages/StoreClerk.Master" AutoEventWireup="true" CodeBehind="SC_RO_DisbursementList.aspx.cs" Inherits="Team09LogicU.pages.SC_RO_DisbursementList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Disbursement List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <form id="form1" runat="server">
    <div class="row">
         <div class="col-lg-12">
        <div class="card">
                <div class="container">
                    <div class=" col-md-12" style="margin-left:-20px;">
                   <div class="col-lg-3" style="margin-top:20px">
                    <asp:Label ID="Label1" runat="server" Text="Select a Department:" CssClass="category"></asp:Label>
                       <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="100px"></asp:DropDownList>
                   </div> 
                         <div class="col-lg-12" style="margin-top:20px">
                        <asp:LinkButton ID="LinkButton1" runat="server">View Disbursement List History</asp:LinkButton>
                         </div>
                    <div class="col-lg-10">
                       
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-hover " HeaderStyle-CssClass=" content text-uppercase " DataKeyNames="itemDescription" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" CellPadding="4" ForeColor="#333333" GridLines="None" EnableViewState="False"   EmptyDataText="There is no disbursement">
                             <Columns>
                                                        <asp:TemplateField HeaderText="ItemDescription" SortExpression="SortedAscendingHeaderStyle">
                                                            <ItemTemplate>
                                                                <asp:Label ID="ItemDescription" runat="server" Text='<%# Eval("itemDescription") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Expected">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Expected" runat="server" Text='<%# Eval("expectedc") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Actual">
                                     <ItemTemplate>
                                                                <asp:Label ID="lblActual" runat="server" Text='<%# Eval("actual") %>'></asp:Label>
                                                            </ItemTemplate>
                                  <EditItemTemplate>                          
                                   <asp:TextBox ID="Actual" CssClass="form-control" Text='<%# Eval("actual") %>' runat="server" BackColor="Azure"></asp:TextBox>                        
                                   </EditItemTemplate>
                                   </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Disburstime">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Disburstime" runat="server" Text='<%# Eval("disburstime") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Status" runat="server" Text='<%# Eval("status") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                  
                                   <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnEdit" CssClass="btn btn-xs btn-default" runat="server" CommandName="Edit" Text="Edit" EnableViewState="True" />
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:Button ID="btnUpdate" CssClass="btn btn-xs btn-success" runat="server" CommandName="Update" Text="Update" />
                                                                <asp:Button ID="btnCancel" CssClass="btn btn-xs btn-default" runat="server" CommandName="Cancel" Text="Cancel" />
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                 </Columns>
                        </asp:GridView>
                        <div class="col-lg-10">
                        <asp:Label ID="Label2" runat="server" Text="Label">Collection Point:</asp:Label>
                          </div>  </div></div>
                        <div class="col-lg-3" style=" margin-top:40px;margin-bottom:20px">
                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-wd btn-fill" Text="Inform representative" />
                       </div>
                     <div class="col-lg-3 " style="margin-top:40px;margin-bottom:20px">
                        <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary btn-wd " Text="Generate QR Code" />
                       </div>
                       </div>
                    
                </div>
            
        </div>
    </div>
    </form>
</asp:Content>
