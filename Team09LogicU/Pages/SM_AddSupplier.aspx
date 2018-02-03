<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreManager.Master" AutoEventWireup="true" CodeBehind="SM_AddSupplier.aspx.cs" Inherits="Team09LogicU.Pages.SM_AddSupplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Add Supplier
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


    <div class="row">
        <div class="col-lg-10">
            <div class="card">
                <div class="container">
                    <div class="col-lg-10" style="margin-top: 20px; margin-bottom: 20px; margin-left: -40px">

                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Supplier Code</label>

                                <asp:TextBox ID="TextBox_SupplierCode" runat="server" Text="" class="form-control " Width="200px"></asp:TextBox>
                                <%-- value=""--%>
                                <asp:RequiredFieldValidator  ValidationGroup="submit1" ControlToValidate="TextBox_SupplierCode" runat="server" ForeColor="#ff3300" ErrorMessage="required"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Supplier Name </label>

                                <asp:TextBox ID="TextBox_SupplierName" runat="server" Text="" class="form-control " Width="200px"></asp:TextBox>
                                <%-- value=""--%>
                                <asp:RequiredFieldValidator ValidationGroup="submit1" ControlToValidate="TextBox_SupplierName" runat="server" ForeColor="#ff3300" ErrorMessage="required"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>GST Registration No.</label>

                                <asp:TextBox ID="TextBox_GSTRegistrationNo" runat="server" Text="" class="form-control " Width="200px"></asp:TextBox>
                                <%-- value=""--%>
                                <asp:RequiredFieldValidator ValidationGroup="submit1" ControlToValidate="TextBox_GSTRegistrationNo" runat="server" ForeColor="#ff3300" ErrorMessage="required"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Contact Name</label>

                                <asp:TextBox ID="TextBox_ContactName" runat="server" Text="" class="form-control " Width="200px"></asp:TextBox>
                                <%-- value=""--%>
                                <asp:RequiredFieldValidator ValidationGroup="submit1" ControlToValidate="TextBox_ContactName" runat="server" ForeColor="#ff3300" ErrorMessage="required"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Phone</label>

                                <asp:TextBox ID="TextBox_Phone" runat="server" Text="" class="form-control " Width="200px"></asp:TextBox>
                                <%-- value=""--%>
                                <asp:RegularExpressionValidator ID="text_box_phone_alert" runat="server" ForeColor="Red" ValidationGroup="submit1" ControlToValidate="TextBox_Phone" ValidationExpression="^(\([0-9]+\))?[0-9]{7,8}$" ErrorMessage="Invalid phone number!!"></asp:RegularExpressionValidator>
                            </div>
                        </div>

                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Fax</label>

                                <asp:TextBox ID="TextBox_Fax" runat="server" Text="" class="form-control " Width="200px"></asp:TextBox>
                                <%-- value=""--%>
                                <asp:RegularExpressionValidator ID="text_box_fax_alert" runat="server" ForeColor="Red" ValidationGroup="submit1" ControlToValidate="TextBox_Fax" ValidationExpression="^(\([0-9]+\))?[0-9]{7,8}$" ErrorMessage="Invalid fax number!!"></asp:RegularExpressionValidator>
                            </div>
                        </div>


                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Address</label>

                                <asp:TextBox ID="TextBox_Address" runat="server" Text="" class="form-control " Width="400px" TextMode="MultiLine" Style="resize: none"></asp:TextBox>
                                <%-- value=""--%>
                                <asp:RequiredFieldValidator ValidationGroup="submit1" ControlToValidate="TextBox_Address" runat="server" ForeColor="#ff3300" ErrorMessage="required"></asp:RequiredFieldValidator>
                            </div>
                        </div>


                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="col-lg-10" style="margin-left: 20px">
        <div class="col-lg-2">
            <asp:Button ID="Btn_Submit" runat="server" Text="Submit" CssClass="btn btn-warning btn-fill btn-wd "  OnClick="Btn_Submit_Click" />
        </div>
        <div class="col-lg-2">
            <asp:Button ID="Btn_Back" runat="server" Text="Back" CssClass="btn btn-default  btn-fill btn-wd" OnClick="Btn_Back_Click" />
        </div>
    </div>

    <script type="text/javascript">
        $().ready(function () {

            $('#registerFormValidation').validate();
            $('#loginFormValidation').validate();
            $('#allInputsFormValidation').validate();

        });
        function notEmpty() {
            var not_empty = true;
          
            if (!$('#TextBox_Phone').val()) {
                $('#text_box_phone_alert').text('Input can not be empty.').css('visibility', 'visible');
            }
            if (!$('#TextBox_Fax').val()) {
                $('#text_box_fax_alert').text('Input can not be empty.').css('visibility', 'visible');
            }
            if (!$('#text_box_phone_alert').val() || !$('#text_box_fax_alert').val() ) {
                not_empty = false;
            }
            //console.log(not_empty)
            return not_empty;
        }
    </script>
</asp:Content>
