<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/StoreSupervisor.Master" AutoEventWireup="true" CodeBehind="SS_Notification.aspx.cs" Inherits="Team09LogicU.Pages.SS_Notification" %>
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
                                    <asp:Repeater ID="notice_Repeater"   runat="server" ViewStateMode="Enabled" EnableViewState="False">
                                        
                                         <ItemTemplate>
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <h4 class="panel-title">
                                                <a data-target="#<%# Eval("notificationID") %>" href="#" data-toggle="collapse" >
                                                    <%# Eval("date") %>
                                                   
                                                    <b class="caret" onclick="setDeptNotificationStatusAsOld()"></b>
                                                </a>
                                            </h4>
                                        </div>
                                        <div id="<%# Eval("notificationID") %>" class="panel-collapse collapse">
                                            <div class="panel-body">
                                                <%# Eval("message") %>
                                               </div>
                                        </div>
                                    </div>
                                             </ItemTemplate>
                                        
                                    </asp:Repeater>
                                </div>
                            </div>

                        </div>
                    </div>
</asp:Content>
