<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreSupervisor.Master" AutoEventWireup="true" CodeBehind="SS_AssignClerk.aspx.cs" Inherits="Team09LogicU.Pages.SS_AssignClerk" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <form runat="server">


    <div class="col-md-6">
                                <legend>Clerk Select</legend>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <asp:Label ID="Label_CollectionPoint1" runat="server" Text=" CollectionPoint1:"></asp:Label>
                                           
                                      
                                   <asp:dropdownlist ID="dropdownlist1" runat="server" class="form-control"    Width="200px"></asp:dropdownlist>
                                  



                                            <asp:Label ID="Label_CollectionPoint2" runat="server" Text=" CollectionPoint2:"></asp:Label>
                                           
                                   <asp:dropdownlist ID="dropdownlist2" runat="server" class="form-control"  Width="200px"></asp:dropdownlist>
                                  


                                            <asp:Label ID="Label_CollectionPoint3" runat="server" Text=" CollectionPoint3:"></asp:Label>
                                            
                                   <asp:dropdownlist ID="dropdownlist3" runat="server" class="form-control"   Width="200px"></asp:dropdownlist>
                                    


                                            <asp:Label ID="Label_CollectionPoint4" runat="server" Text=" CollectionPoint4:"></asp:Label>
                                           
                                   <asp:dropdownlist ID="dropdownlist4" runat="server" class="form-control"    Width="200px"></asp:dropdownlist>
                                 


                                            <asp:Label ID="Label_CollectionPoint5" runat="server" Text=" CollectionPoint5:"></asp:Label>
                                            
                                      
                                   <asp:dropdownlist ID="dropdownlist5" runat="server" class="form-control"  Width="200px"></asp:dropdownlist>
                                  


                                            <asp:Label ID="Label_CollectionPoint6" runat="server" Text=" CollectionPoint6:"></asp:Label>
                                            
                                      
                                   <asp:dropdownlist ID="dropdownlist6" runat="server" class="form-control"    Width="200px"></asp:dropdownlist>
                                    
                                        </div>
                                        </div>
          <asp:Button ID="Btn_Approve"  runat="server" Text="Approve" CssClass="btn btn-primary btn-fill btn-wd " /> 
        <asp:Button ID="Btn_Back"  runat="server"  Text="Back"  CssClass="btn btn-default  btn-fill btn-wd"   />
        </div>
 
          </form>
</asp:Content>
