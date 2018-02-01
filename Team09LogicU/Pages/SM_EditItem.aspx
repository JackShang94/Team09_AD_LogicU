<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreManager.Master" AutoEventWireup="true" CodeBehind="SM_EditItem.aspx.cs" Inherits="Team09LogicU.Pages.SM_EditItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Edit Item
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

   
      
                <div class="row">
                    <div class="col-md-12">
                        <div class="card">

                            <div class="content">
                                <div class="row">

                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Item code</label><br />                                           
                                             <asp:TextBox ID="TextBox_itemcode" runat="server" class="form-control disabled" ReadOnly="true" Width="200px"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Category</label><br />                                           
                                            <asp:TextBox ID="TextBox_category" runat="server" class="form-control disabled" ReadOnly="true" Width="200px"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Qty on Hand </label><br />
                                            
                                            <asp:TextBox ID="TextBox_qty" runat="server" class="form-control disabled" ReadOnly="true" Width="200px"></asp:TextBox>
                                            <asp:RegularExpressionValidator runat="server" ForeColor="Red"  ValidationGroup="submit1"  ControlToValidate="TextBox_qty" ValidationExpression="^[1-9]\d*|0$" ErrorMessage="Invalid quantity!!"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Description</label>
                                            <asp:TextBox ID="TextBox_Description" runat="server" class="form-control" Width="200px" ></asp:TextBox>
                                            <asp:RequiredFieldValidator  ValidationGroup="submit1" ControlToValidate="TextBox_Description" runat="server" ForeColor="#ff3300" ErrorMessage="required"></asp:RequiredFieldValidator>
                                           
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>ReorderLevel </label>
                                            <asp:TextBox ID="TextBox_ReorderLevel" TextMode="Number" runat="server" class="form-control " Width="200px"></asp:TextBox>
                                             <asp:RegularExpressionValidator runat="server" ForeColor="Red"  id="text_box_level_alert" ValidationGroup="submit1"  ControlToValidate="TextBox_ReorderLevel" ValidationExpression="^[1-9]\d*$" ErrorMessage="Invalid quantity!!"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Reorder Qty </label>
                                            <asp:TextBox ID="TextBox_ReorderQty" TextMode="Number" runat="server" class="form-control " Width="200px"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="text_box_reorderqty_alert" runat="server" ForeColor="Red"  ValidationGroup="submit1"  ControlToValidate="TextBox_ReorderQty" ValidationExpression="^[1-9]\d*$" ErrorMessage="Invalid quantity!!"></asp:RegularExpressionValidator>

                                        </div>
                                    </div>

                                    <div class="col-md-3">
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
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Location </label>

                                            <asp:TextBox ID="TextBox_location" runat="server" class="form-control " Width="200px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="submit1" ControlToValidate="TextBox_location" runat="server" ForeColor="#ff3300" ErrorMessage="required"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Supplier1</label>
                                            <asp:DropDownList ID="dropdownlist_Supplier1" runat="server" class="form-control" Width="200px"></asp:DropDownList>
                                            <label>Price</label>
                                            <asp:TextBox ID="TextBox_price1" number="number" runat="server" class="form-control " Width="200px"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="text_box_Supplier1_alert" runat="server" ForeColor="Red"  ValidationGroup="submit1"  ControlToValidate="TextBox_price1" ValidationExpression="^[+]{0,1}(\d+)$|^[+]{0,1}(\d+\.\d+)$" ErrorMessage="Invalid quantity!!"></asp:RegularExpressionValidator>
                                            </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Supplier2</label>
                                            <asp:DropDownList ID="dropdownlist_Supplier2" runat="server" class="form-control" Width="200px"></asp:DropDownList>
                                            <label>Price</label>
                                            <asp:TextBox ID="TextBox_price2" runat="server" class="form-control " Width="200px"></asp:TextBox>
                                             <asp:RegularExpressionValidator ID="text_box_Supplier2_alert" runat="server" ForeColor="Red"  ValidationGroup="submit1"  ControlToValidate="TextBox_price2" ValidationExpression="^[+]{0,1}(\d+)$|^[+]{0,1}(\d+\.\d+)$" ErrorMessage="Invalid quantity!!"></asp:RegularExpressionValidator>
                                            </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Supplier3</label>
                                            <asp:DropDownList ID="dropdownlist_Supplier3" runat="server" class="form-control" Width="200px"></asp:DropDownList>
                                            <label>Price</label>
                                            <asp:TextBox ID="TextBox_price3" runat="server" class="form-control" Width="200px"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="text_box_Supplier3_alert" runat="server" ForeColor="Red"  ValidationGroup="submit1"  ControlToValidate="TextBox_price3" ValidationExpression="^[+]{0,1}(\d+)$|^[+]{0,1}(\d+\.\d+)$" ErrorMessage="Invalid quantity!!"></asp:RegularExpressionValidator>
                                            </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
    
        <asp:Button ID="Btn_Update" runat="server" Text="Update" ValidationGroup="submit1" CssClass="btn btn-primary btn-fill btn-wd "  OnClientClick="if(!notEmpty()) return false;" OnClick="Btn_Update_Click"  />
        <asp:Button ID="Btn_Back" runat="server" Text="Back" CssClass="btn btn-default  btn-fill btn-wd" OnClick="Btn_Update_Click"  />
          <script type="text/javascript">
        $().ready(function(){

            $('#registerFormValidation').validate();
            $('#loginFormValidation').validate();
            $('#allInputsFormValidation').validate();

              });
              function notEmpty() {
                  var not_empty = true;

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
                  if (!$('#TextBox_ReorderLevel').val() || !$('#TextBox_ReorderQty').val() || !$('#TextBox_price1').val() || !$('#TextBox_price2').val() || !$('#TextBox_price3').val())
                  {
                      not_empty = false;
                  }
                  //console.log(not_empty)
                  return not_empty;
              }
    </script>
</asp:Content>
