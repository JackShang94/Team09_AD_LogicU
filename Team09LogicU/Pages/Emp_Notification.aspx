<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Employee.Master" AutoEventWireup="true" CodeBehind="Emp_Notification.aspx.cs" Inherits="Team09LogicU.pages.Emp_Notification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
Notification
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="col-md-8">
                        <div class="card">
                            <div class="header">
                                <h4 class="title">Collapsible Accordion</h4>
                                <p class="category">Bootstrap default style</p>
                            </div>
                            <div class="content">
                                <div class="panel-group" id="accordion">
                                   <%-- <asp:Repeater ID="notice_Repeater"   runat="server" ViewStateMode="Enabled">
                                         <HeaderTemplate>
                                        </HeaderTemplate>
                                         <ItemTemplate>--%>
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <h4 class="panel-title">
                                                <a data-target="#collapseOne" href="#" data-toggle="collapse">
                                                    Datetime1

                                                    <b class="caret"></b>
                                                </a>
                                            </h4>
                                        </div>
                                        <div id="collapseOne" class="panel-collapse collapse">
                                            <div class="panel-body">
                                                Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                            </div>
                                        </div>
                                    </div>
                                           <%--  </ItemTemplate>
                                         <FooterTemplate>
                                        </FooterTemplate>
                                    </asp:Repeater>--%>
                                </div>
                            </div>

                        </div>
                    </div>
</asp:Content>
