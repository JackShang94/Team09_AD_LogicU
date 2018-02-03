<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreManager.Master" ClientIDMode="Static" AutoEventWireup="true" CodeBehind="SM_AddItem.aspx.cs" Inherits="Team09LogicU.Pages.SM_AddItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Add Item
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


    <div class="row">
        <div class="col-lg-10">
            <div class="card">
                <div class="container">
                    <div class="col-lg-4" style="margin-top: 20px">
                        <div class="form-group">
                            <label>Item code</label><asp:TextBox ID="TextBox_ItemNumber" runat="server" class="form-control " Width="60%" CausesValidation="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="submit1" ControlToValidate="TextBox_ItemNumber" runat="server" ForeColor="#ff3300" ErrorMessage="required"></asp:RequiredFieldValidator><%-- value=""--%>
                        </div>
                    </div>

                    <div class="col-lg-4" style="margin-top: 20px; margin-bottom: 20px">
                        <div class="form-group">
                            <label>Category</label>
                            <asp:DropDownList ID="dropdownlist_Catagory" runat="server" class="form-control" Width="60%"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-4" style="margin-top: 20px; margin-bottom: 20px">
                        <div class="form-group">
                            <label>Unit of Measure</label>
                            <asp:DropDownList ID="dropdownlist_unitofmeasure" runat="server" class="form-control" Width="60%">
                                <asp:ListItem>Box</asp:ListItem>
                                <asp:ListItem>Dozen</asp:ListItem>
                                <asp:ListItem>Each</asp:ListItem>
                                <asp:ListItem>Set</asp:ListItem>
                                <asp:ListItem>Packet</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="form-group">
                            <label>Quantity on Hand </label>

                            <asp:TextBox ID="TextBox_qty" runat="server" class="form-control " Width="60%"></asp:TextBox>
                            <%--                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationExpression="^[1-9]\d*|0$" ValidationGroup="submit1" ControlToValidate="TextBox_qty" runat="server" ForeColor="#ff3300" ErrorMessage="required"></asp:RequiredFieldValidator>--%>
                            <asp:RegularExpressionValidator runat="server" ForeColor="Red" ID="text_box_qty_alert" ValidationGroup="submit1" ControlToValidate="TextBox_qty" ValidationExpression="^[1-9]\d*|0$" ErrorMessage="Invalid quantity!!"></asp:RegularExpressionValidator>

                            <%-- value=""--%>
                        </div>
                    </div>

                    <div class="col-lg-4">
                        <div class="form-group">
                            <label>Reorder Level </label>

                            <asp:TextBox ID="TextBox_ReorderLevel" runat="server" class="form-control " Width="60%"></asp:TextBox>
                            <asp:RegularExpressionValidator runat="server" ForeColor="Red" ID="text_box_level_alert" ValidationGroup="submit1" ControlToValidate="TextBox_ReorderLevel" ValidationExpression="^[1-9]\d*$" ErrorMessage="Invalid quantity!!"></asp:RegularExpressionValidator>
                            <%--                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator3"  ValidationGroup="submit1" ControlToValidate="TextBox_ReorderLevel" ValidationExpression="^[1-9]\d*$" runat="server" ForeColor="#ff3300" ErrorMessage="required"></asp:RequiredFieldValidator>--%>
                            <%-- value=""--%>
                        </div>
                    </div>

                    <div class="col-lg-4">
                        <div class="form-group">
                            <label>Reorder Quantity </label>

                            <asp:TextBox ID="TextBox_ReorderQty" runat="server" class="form-control " Width="60%"></asp:TextBox>
                            <%--                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="submit1" ControlToValidate="TextBox_ReorderQty" runat="server" ForeColor="#ff3300" ErrorMessage="required"></asp:RequiredFieldValidator>--%>
                            <asp:RegularExpressionValidator ID="text_box_reorderqty_alert" runat="server" ForeColor="Red" ValidationGroup="submit1" ControlToValidate="TextBox_ReorderQty" ValidationExpression="^[1-9]\d*$" ErrorMessage="Invalid quantity!!"></asp:RegularExpressionValidator>
                            <%-- value=""--%>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="form-group">
                            <label>Description</label>

                            <asp:TextBox ID="TextBox_Description" runat="server" class="form-control " Width="60%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="submit1" ControlToValidate="TextBox_Description" runat="server" ForeColor="#ff3300" ErrorMessage="required"></asp:RequiredFieldValidator>
                            <%-- value=""--%>
                        </div>
                    </div>

                    <div class="col-lg-7">
                        <div class="form-group">
                            <label>Location </label>

                            <asp:TextBox ID="TextBox_location" runat="server" class="form-control " Width="93%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="submit1" ControlToValidate="TextBox_location" runat="server" ForeColor="#ff3300" ErrorMessage="required"></asp:RequiredFieldValidator>
                            <%-- value=""--%>
                        </div>
                    </div>


                    <div class="col-lg-4" style="margin-top: 20px; margin-bottom: 20px">
                        <div class="form-group">
                            <label>Supplier1</label>
                            <asp:DropDownList ID="dropdownlist_Supplier1" runat="server" class="form-control" Width="60%"></asp:DropDownList>
                            <label>Price</label>
                            <asp:TextBox ID="TextBox_price1" runat="server" class="form-control " Width="60%"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="text_box_Supplier1_alert" runat="server" ForeColor="Red" ValidationGroup="submit1" ControlToValidate="TextBox_price1" ValidationExpression="^[+]{0,1}(\d+)$|^[+]{0,1}(\d+\.\d+)$" ErrorMessage="Invalid quantity!!"></asp:RegularExpressionValidator>
                            <%--                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationExpression="^[1-9]\d*\.\d*|0\.\d*[1-9]\d*$" ValidationGroup="submit1" ControlToValidate="TextBox_price1" runat="server" ForeColor="#ff3300" ErrorMessage="required"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <div class="col-lg-4" style="margin-top: 20px; margin-bottom: 20px">
                        <div class="form-group">
                            <label>Supplier2</label>
                            <asp:DropDownList ID="dropdownlist_Supplier2" runat="server" class="form-control" Width="60%"></asp:DropDownList>
                            <label>Price</label>
                            <asp:TextBox ID="TextBox_price2" runat="server" class="form-control " Width="60%"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="text_box_Supplier2_alert" runat="server" ForeColor="Red" ValidationGroup="submit1" ControlToValidate="TextBox_price2" ValidationExpression="^[+]{0,1}(\d+)$|^[+]{0,1}(\d+\.\d+)$" ErrorMessage="Invalid quantity!!"></asp:RegularExpressionValidator>
                            <%--                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationExpression="^([1-9]/d*/./d*|0/./d+|[1-9]/d*|0)$" ValidationGroup="submit1" ControlToValidate="TextBox_price2" runat="server" ForeColor="#ff3300" ErrorMessage="required"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>

                    <div class="col-lg-4" style="margin-top: 20px; margin-bottom: 20px">
                        <div class="form-group">
                            <label>Supplier3</label>
                            <asp:DropDownList ID="dropdownlist_Supplier3" runat="server" class="form-control" Width="60%"></asp:DropDownList>
                            <label>Price</label>
                            <asp:TextBox ID="TextBox_price3" runat="server" class="form-control" Width="60%"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="text_box_Supplier3_alert" runat="server" ForeColor="Red" ValidationGroup="submit1" ControlToValidate="TextBox_price3" ValidationExpression="^[+]{0,1}(\d+)$|^[+]{0,1}(\d+\.\d+)$" ErrorMessage="Invalid quantity!!"></asp:RegularExpressionValidator>
                            <%--                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationExpression="^[1-9]\d*\.\d*|0\.\d*[1-9]\d*$" ValidationGroup="submit1" ControlToValidate="TextBox_price3" runat="server" ForeColor="#ff3300" ErrorMessage="required"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <div>
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn btn-warning btn-fill btn-wd " />
                    </div>
                </div>

            </div>
        </div>
    </div>


    <div class="col-lg-4">
        <asp:Button ID="Btn_Submit" runat="server" Text="Submit" ValidationGroup="submit1" CssClass="btn btn-warning btn-fill btn-wd " OnClientClick="if(!notEmpty()) return false;" OnClick="Btn_Submit_Click" />
        <asp:Button ID="Btn_Back" runat="server" Text="Back" CssClass="btn btn-default   btn-wd" OnClick="Btn_Back_Click" />
    </div>


    <script type="text/javascript">
        $().ready(function () {

            $('#registerFormValidation').validate();
            $('#loginFormValidation').validate();
            $('#allInputsFormValidation').validate();
        });
        function notEmpty() {
            var not_empty = true;
            if (!$('#TextBox_qty').val()) {
                $('#text_box_qty_alert').text('Input can not be empty.').css('visibility', 'visible');
            }
            if (!$('#TextBox_ReorderLevel').val()) {
                $('#text_box_level_alert').text('Input can not be empty.').css('visibility', 'visible');
            }
            if (!$('#TextBox_ReorderQty').val()) {
                $('#text_box_reorderqty_alert').text('Input can not be empty.').css('visibility', 'visible');
            }
            if (!$('#TextBox_price1').val()) {
                $('#text_box_Supplier1_alert').text('Input can not be empty.').css('visibility', 'visible');
            }
            if (!$('#TextBox_price2').val()) {
                $('#text_box_Supplier2_alert').text('Input can not be empty.').css('visibility', 'visible');
            }
            if (!$('#TextBox_price3').val()) {
                $('#text_box_Supplier3_alert').text('Input can not be empty.').css('visibility', 'visible');
            }
            if (!$('#TextBox_qty').val() || !$('#TextBox_ReorderLevel').val() || !$('#TextBox_ReorderQty').val() || !$('#TextBox_price1').val() || !$('#TextBox_price2').val() || !$('#TextBox_price3').val()) {
                not_empty = false;
            }
            //console.log(not_empty)
            return not_empty;
        }
    </script>

</asp:Content>
