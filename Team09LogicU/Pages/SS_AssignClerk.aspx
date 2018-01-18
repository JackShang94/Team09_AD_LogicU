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
                                            <select name="clerk" class="selectpicker" data-title="Single Select" data-style="btn-default btn-block" data-menu-style="dropdown-blue">
                                                <option value="id">Mike</option>
                                                <option value="ms">Melayu</option>
                                                <option value="ca">Català</option>                              
                                            </select>



                                            <asp:Label ID="Label_CollectionPoint2" runat="server" Text=" CollectionPoint2:"></asp:Label>
                                            <select name="clerk" class="selectpicker" data-title="Single Select" data-style="btn-default btn-block" data-menu-style="dropdown-blue">
                                                <option value="id">Mike</option>
                                                <option value="ms">Melayu</option>
                                                <option value="ca">Català</option>                              
                                            </select>


                                            <asp:Label ID="Label_CollectionPoint3" runat="server" Text=" CollectionPoint3:"></asp:Label>
                                            <select name="clerk" class="selectpicker" data-title="Single Select" data-style="btn-default btn-block" data-menu-style="dropdown-blue">
                                                <option value="id">Mike</option>
                                                <option value="ms">Melayu</option>
                                                <option value="ca">Català</option>                              
                                            </select>


                                            <asp:Label ID="Label_CollectionPoint4" runat="server" Text=" CollectionPoint4:"></asp:Label>
                                            <select name="clerk" class="selectpicker" data-title="Single Select" data-style="btn-default btn-block" data-menu-style="dropdown-blue">
                                                <option value="id">Mike</option>
                                                <option value="ms">Melayu</option>
                                                <option value="ca">Català</option>                              
                                            </select>


                                            <asp:Label ID="Label_CollectionPoint5" runat="server" Text=" CollectionPoint5:"></asp:Label>
                                            <select name="clerk" class="selectpicker" data-title="Single Select" data-style="btn-default btn-block" data-menu-style="dropdown-blue">
                                                <option value="id">Mike</option>
                                                <option value="ms">Melayu</option>
                                                <option value="ca">Català</option>                              
                                            </select>


                                            <asp:Label ID="Label_CollectionPoint6" runat="server" Text=" CollectionPoint6:"></asp:Label>
                                            <select name="clerk" class="selectpicker" data-title="Single Select" data-style="btn-default btn-block" data-menu-style="dropdown-blue">
                                                <option value="id">Mike</option>
                                                <option value="ms">Melayu</option>
                                                <option value="ca">Català</option>                              
                                            </select>
                                        </div>
                                        </div>
         <button type="submit" class="btn btn-fill btn-info">Submit</button>
                <button type="submit" class="btn btn-fill btn-info">Back</button>
        </div>
 
          </form>
</asp:Content>
