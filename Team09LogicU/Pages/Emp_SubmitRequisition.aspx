<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Employee.Master" AutoEventWireup="true" CodeBehind="Emp_SubmitRequisition.aspx.cs" Inherits="Team09LogicU.pages.Emp_SubmitRequisition"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 Submit Requisition
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <form id="catalogueForm" runat="server">
        
        

        
        <%--<asp:UpdatePanel ID="viewCatalogueUpdatePanel" runat="server" UpdateMode="Conditional">
            
            <ContentTemplate>--%>
                <asp:TextBox ID="item_searchText" runat="server"></asp:TextBox>
                <asp:Button ID="item_searchBtn" runat="server" Text="search" OnClick="item_searchBtn_Click" />
                 <asp:Repeater ID="catalogueRepeater" runat="server" OnItemCommand="catalogueRepeater_ItemCommand">
                        <HeaderTemplate>
                            <table>
                        </HeaderTemplate>
        
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <!--<asp:Label ID="itemIDLabel" runat="server" Text='<%# Eval("itemID") %>'  Visible="False"></asp:Label>-->
                                        <!--<asp:Image ID="Image" runat="server"  ImageUrl='<%# Eval("itemID") %>'/>-->
                                        <div>
                    
                                                <asp:Label ID="descLabel" runat="server" Text='<%# Eval("description") %>'></asp:Label>
                                                <asp:Button ID='addBtn'  runat="server" Text="Add"  Onclick="addBtn_Click" CommandName="add"  CommandArgument='<%# Eval("itemID")+"&"+Eval("description") %>'  ClientIDMode="AutoID"/><!--CommandName="add" -->
                                        </div>
                                </td>
                  
              
                            </tr>

                        </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
         
                </asp:Repeater>
                <script>
  
                </script>
            <%--</ContentTemplate>
            

        </asp:UpdatePanel>--%>
   
    
   <div><!--Cart-->
       <asp:Button ID="Submit" runat="server" Text="Checkout" OnClick="Submit_Click"/>
       <asp:ScriptManager ID="viewCatalogueScriptManager" runat="server"></asp:ScriptManager>
       <asp:UpdatePanel ID="cartUpdatePanel" runat="server" UpdateMode="Conditional">
           <ContentTemplate>
                 <asp:Repeater ID="cartRepeater" runat="server" OnItemCommand="cartRepeater_ItemCommand" >
                   <HeaderTemplate>
                       <table>
                           <tr>
                               <td>Description</td>
                               <td>amount</td>
                               <td>&nbsp; </td>
                           </tr>
    
                   </HeaderTemplate>
                   <ItemTemplate>
                            <tr>
                                <asp:Label ID="cartitemIDLabel" runat="server" Text='<%# Eval("itemID") %>'  Visible="False"></asp:Label>
                                <td><%#Eval("description") %></td>
                                <td><asp:TextBox ID="cart_qtyTextBox" runat="server" Text='<%#Eval("Qty") %>'   ></asp:TextBox></td>
                                <td><asp:Button ID="cart_deleteBtn" runat="server" Text="delete"  OnClick="cart_deleteBtn_Click"  CommandName="delete" CommandArgument='<%# Eval("itemID")+"&"+ Eval("Qty") %>'/></td><!--CommandName="delete"-->
                               
                            </tr>
                   </ItemTemplate>
                   <FooterTemplate>
                       </table>
                   </FooterTemplate>
            
               </asp:Repeater>
               <%--<script>
                   var price = <%= this. %>
               </script>--%>

           </ContentTemplate>
           
       </asp:UpdatePanel>
       
     
   </div>
    </form>
    
    
</asp:Content>
