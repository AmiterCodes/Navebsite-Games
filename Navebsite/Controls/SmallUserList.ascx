<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SmallUserList.ascx.cs" Inherits="Navebsite.Controls.SmallUserList" %>
<div class="user_list_container">
    
    <asp:Label Text="" runat="server" ID="TitleLabel"/>
    <asp:Panel runat="server" ID="userList" CssClass="user_list">
        <asp:Panel runat="server" ID="NoUsersError" Visible="false"><i class="far fa-sad-tear"></i> No friends here...</asp:Panel>
    </asp:Panel>
</div>