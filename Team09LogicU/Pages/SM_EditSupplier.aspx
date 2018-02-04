<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreManager.Master" AutoEventWireup="true" CodeBehind="SM_EditSupplier.aspx.cs" Inherits="Team09LogicU.Pages.SM_EditSupplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Edit Supplier
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


    <div class="row">
        <div class="col-lg-10">
            <div class="card">

                <div class="content">
                    <div class="row">

                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Supplier Code</label>
                                <asp:TextBox ID="TextBox_SupplierCode" class="form-control disabled" runat="server" ReadOnly="True" Width="200px"></asp:TextBox>
                                <%-- value=""--%>
                                <%--                                   <asp:RequiredFieldValidator  ValidationGroup="submit1" ControlToValidate="TextBox_SupplierCode" runat="server" ForeColor="#ff3300" ErrorMessage="required"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>

                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Supplier Name</label>

                                <asp:TextBox ID="TextBox_SupplierName" class="form-control disabled" runat="server" ReadOnly="True" Width="200px"></asp:TextBox>
                                <%-- value=""--%>
                                <%--                                   <asp:RequiredFieldValidator  ValidationGroup="submit1" ControlToValidate="TextBox_SupplierName" runat="server" ForeColor="#ff3300" ErrorMessage="required"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>

                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>GST Registration No.</label>

                                <asp:TextBox ID="TextBox_GSTRegistrationNo" class="form-control" runat="server" Width="200px"></asp:TextBox>
                                <%-- value=""--%>
                                <asp:RequiredFieldValidator ValidationGroup="submit1" ControlToValidate="TextBox_GSTRegistrationNo" runat="server" ForeColor="#ff3300" ErrorMessage="required"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Contact Name</label>

                                <asp:TextBox ID="TextBox_ContactName" class="form-control" runat="server" Width="200px"></asp:TextBox>
                                <%-- value=""--%>
                                <asp:RequiredFieldValidator ValidationGroup="submit1" ControlToValidate="TextBox_ContactName" runat="server" ForeColor="#ff3300" ErrorMessage="required"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Phone</label>

                                <asp:TextBox ID="TextBox_Phone" class="form-control" runat="server" Width="200px"></asp:TextBox>
                                <%-- value=""--%>
                                <asp:RegularExpressionValidator ID="text_box_phone_alert" runat="server" ForeColor="Red" ValidationGroup="submit1" ControlToValidate="TextBox_Phone" ValidationExpression="^(\([0-9]+\))?[0-9]{7,8}$" ErrorMessage="Invalid phone nmber!!"></asp:RegularExpressionValidator>

                            </div>
                        </div>

                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Fax </label>

                                <asp:TextBox ID="TextBox_Fax" class="form-control" runat="server" Width="200px"></asp:TextBox>
                                <%-- value=""--%>
                                <asp:RegularExpressionValidator ID="text_box_fax_alert" runat="server" ForeColor="Red" ValidationGroup="submit1" ControlToValidate="TextBox_Fax" ValidationExpression="^(\([0-9]+\))?[0-9]{7,8}$" ErrorMessage="Invalid fax number!!"></asp:RegularExpressionValidator>
                            </div>
                        </div>


                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>Address</label>

                                <asp:TextBox ID="TextBox_Address" runat="server" class="form-control" TextMode="MultiLine" Style="resize: none"></asp:TextBox>
                                <%-- value=""--%>
                                <asp:RequiredFieldValidator ValidationGroup="submit1" ControlToValidate="TextBox_Address" runat="server" ForeColor="#ff3300" ErrorMessage="required"></asp:RequiredFieldValidator>
                            </div>
                        </div>


                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:Button ID="Btn_Submit" runat="server" ValidationGroup="submit1" Text="Submit" CssClass="btn btn-warning btn-fill btn-wd "  OnClick="Btn_Submit_Click" />
    <asp:Button ID="Btn_Back" runat="server" Text="Back" CssClass="btn btn-default  btn-fill btn-wd" OnClick="Btn_Back_Click" />

    <script type="text/javascript">
        $().ready(function () {

            $('#registerFormValidation').validate();
            $('#loginFormValidation').validate();
            $('#allInputsFormValidation').validate();

        });
        function notEmpty() {
            var not_empty = true;

            if (!$('#TextBox_Phone').val()) {
                $('#text_box_level_alert').text('Input can not be empty.').css('visibility', 'visible');
            }
            if (!$('#TextBox_Fax').val()) {
                $('#text_box_reorderqty_alert').text('Input can not be empty.').css('visibility', 'visible');
            }
            if (!$('#text_box_phone_alert').val() || !$('#text_box_fax_alert').val()) {
                not_empty = false;
            }
            //console.log(not_empty)
            return not_empty;
        }
    </script>
</asp:Content>
