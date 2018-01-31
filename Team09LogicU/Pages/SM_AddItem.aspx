<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreManager.Master" AutoEventWireup="true" CodeBehind="SM_AddItem.aspx.cs" Inherits="Team09LogicU.Pages.SM_AddItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Add Item
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
   
   
                <div class="row">
                    <div class="col-lg-10">
                        <div class="card">
                            <div class="container">
                               <div class="col-lg-10" style="margin-top:20px;margin-bottom:20px;margin-left:-40px">

                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <label>Item code</label><asp:TextBox ID="TextBox_ItemNumber"  runat="server" class="form-control " Width="200px" CausesValidation="True"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="submit1" ControlToValidate="TextBox_ItemNumber" runat="server" ForeColor="#ff3300" ErrorMessage="required"></asp:RequiredFieldValidator><%-- value=""--%>
                                        </div>
                                    </div>

                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <label>Category</label>
                                            <asp:DropDownList ID="dropdownlist_Catagory" runat="server" class="form-control" Width="200px"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <label>Unit of Measure</label>
                                            <asp:DropDownList ID="dropdownlist_unitofmeasure" runat="server" class="form-control" Width="200px">
                                                <asp:ListItem>Box</asp:ListItem>
                                                <asp:ListItem>Dozen</asp:ListItem>
                                                <asp:ListItem>Each</asp:ListItem>
                                                <asp:ListItem>Set</asp:ListItem>
                                                <asp:ListItem>Packet</asp:ListItem>
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <label>Qty on Hand </label>

                                            <asp:TextBox ID="TextBox_qty" runat="server" class="form-control " Width="200px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="submit1" ControlToValidate="TextBox_qty" runat="server" ForeColor="#ff3300" ErrorMessage="required"></asp:RequiredFieldValidator>
                                            <%-- value=""--%>
                                        </div>
                                    </div>

                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <label>ReorderLevel </label>

                                            <asp:TextBox ID="TextBox_ReorderLevel" runat="server" class="form-control " Width="200px"></asp:TextBox>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="submit1" ControlToValidate="TextBox_ReorderLevel" runat="server" ForeColor="#ff3300" ErrorMessage="required"></asp:RequiredFieldValidator>
                                             <%-- value=""--%>
                                        </div>
                                    </div>

                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <label>Reorder Qty </label>

                                            <asp:TextBox ID="TextBox_ReorderQty" runat="server" class="form-control " Width="200px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="submit1" ControlToValidate="TextBox_ReorderQty" runat="server" ForeColor="#ff3300" ErrorMessage="required"></asp:RequiredFieldValidator>
                                            <%-- value=""--%>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <label>Description</label>

                                            <asp:TextBox ID="TextBox_Description" runat="server" class="form-control " Width="200px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="submit1" ControlToValidate="TextBox_Description" runat="server" ForeColor="#ff3300" ErrorMessage="required"></asp:RequiredFieldValidator>
                                            <%-- value=""--%>
                                        </div>
                                    </div>
                                   
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <label>Location </label>

                                            <asp:TextBox ID="TextBox_location" runat="server" class="form-control " Width="200px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="submit1" ControlToValidate="TextBox_location" runat="server" ForeColor="#ff3300" ErrorMessage="required"></asp:RequiredFieldValidator>
                                            <%-- value=""--%>
                                        </div>
                                    </div>
                                   <br />
                                   <hr />
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <label>Supplier1</label>
                                            <asp:DropDownList ID="dropdownlist_Supplier1" runat="server" class="form-control" Width="200px"></asp:DropDownList>
                                            <label>Price</label>
                                            <asp:TextBox ID="TextBox_price1" runat="server" class="form-control " Width="200px" ></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="submit1" ControlToValidate="TextBox_price1" runat="server" ForeColor="#ff3300" ErrorMessage="required"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <label>Supplier2</label>
                                            <asp:DropDownList ID="dropdownlist_Supplier2" runat="server" class="form-control" Width="200px"></asp:DropDownList>
                                            <label>Price</label>
                                            <asp:TextBox ID="TextBox_price2" runat="server" class="form-control " Width="200px" ></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="submit1" ControlToValidate="TextBox_price2" runat="server" ForeColor="#ff3300" ErrorMessage="required"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <label>Supplier3</label>
                                            <asp:DropDownList ID="dropdownlist_Supplier3" runat="server" class="form-control" Width="200px"></asp:DropDownList>
                                            <label>Price</label>
                                            <asp:TextBox ID="TextBox_price3" runat="server" class="form-control" Width="200px" ></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="submit1" ControlToValidate="TextBox_price3" runat="server" ForeColor="#ff3300" ErrorMessage="required"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                   </div>
                                </div>
                        </div>
                    </div>
                </div>
     
        <div class="col-lg-10" style="margin-left:20px">
            <div class="col-lg-2">
        <asp:Button ID="Btn_Submit" runat="server" Text="Submit" ValidationGroup="submit1" CssClass="btn btn-warning btn-fill btn-wd " OnClick="Btn_Submit_Click" />
        </div>
        <div class="col-lg-2"><asp:Button ID="Btn_Back" runat="server" Text="Back" CssClass="btn btn-default  btn-fill btn-wd" OnClick="Btn_Back_Click" />
        </div>
        </div>

        <script type="text/javascript">
        $().ready(function(){

            $('#registerFormValidation').validate();
            $('#loginFormValidation').validate();
            $('#allInputsFormValidation').validate();

        });
    </script>
   
</asp:Content>
