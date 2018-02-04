<%@ Page Title="" Language="C#" MasterPageFile="~/pages/welcome.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Team09LogicU.pages.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">
        <div class="card card-hidden ">
            <div class="header text-center">Login</div>
            <div class="content">
                <div class="form-group">
                    <label>Username</label>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Password</label>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="message" runat="server" Text="" ForeColor="Red"></asp:Label>
                </div>
               
            </div>
            <div class="footer text-center">

                <asp:Button ID="Button1" runat="server" CssClass="btn btn-warning btn-wd btn-fill" Text="Login" OnClick="Button1_Click" EnableViewState="False" />
            </div>
        </div>

    </form>

</asp:Content>
