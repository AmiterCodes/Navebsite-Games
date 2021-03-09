<%@ Page Title="" Language="C#" MasterPageFile="~/Missy.Master" AutoEventWireup="true" CodeBehind="RequestsPage.aspx.cs" Inherits="Navebsite.RequestsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Navebsite" runat="server">
    <asp:GridView
        Caption="Incoming Friend Requests"

        ID="IncomingFriendRequests"
        runat="server"
        AutoGenerateColumns="False"
        ShowHeader="False"
        EmptyDataText=""
        BorderWidth="0"
        BorderColor="Transparent"
        DataKeyNames="Id"
        OnRowCommand="IncomingFriendRequests_OnRowCommand"
        OnRowDataBound="OnRowDataBound">
        
        <EmptyDataTemplate>
            <div class="empty_temp">

            <i class="far fa-sad-tear"></i> Seems like there are no incoming friend requests.
            </div>
        </EmptyDataTemplate>
        <Columns>

            <asp:ImageField DataImageUrlField="ProfilePictureUrl" ItemStyle-CssClass="profile_table"/>
            <asp:HyperLinkField DataTextField="Username"/>
            <asp:ButtonField CommandName="Accept" Text="Accept" ItemStyle-CssClass="button_table"/>
            <asp:ButtonField CommandName="Deny" Text="Deny" ItemStyle-CssClass="button_table"/>
        </Columns>
    </asp:GridView>
    <asp:GridView
        Caption="Outgoing Friend Requests"
        ID="OutgoingFriendRequests"
        runat="server"
        AutoGenerateColumns="False"
        ShowHeader="False"
        BorderWidth="0"
        BorderColor="Transparent"
        DataKeyNames="Id"
        OnRowCommand="OutgoingFriendRequests_OnRowCommand"
        OnRowDataBound="OnRowDataBound">

        <EmptyDataTemplate>
            <div class="empty_temp">

            <i class="far fa-sad-tear"></i> Seems like there are no outgoing friend requests.
            </div>
        </EmptyDataTemplate>
        <Columns>

            <asp:ImageField DataImageUrlField="ProfilePictureUrl" ItemStyle-CssClass="profile_table"/>
            <asp:HyperLinkField DataTextField="Username"/>
            <asp:ButtonField Text="Cancel" ItemStyle-CssClass="button_table" CommandName="Cancel"/>
        </Columns>
    </asp:GridView>
    
    <asp:GridView
        Caption="Incoming Developer Requests"
        ID="IncomingDeveloperRequests"
        runat="server"
        AutoGenerateColumns="False"
        ShowHeader="False"
        BorderColor="Transparent"
        BorderWidth="0"
        DataKeyNames="Id"
        OnRowCommand="IncomingDeveloperRequests_OnRowCommand"
        OnRowDataBound="IncomingDeveloperRequests_OnRowDataBound">

        <EmptyDataTemplate>
            <div class="empty_temp">

            <i class="far fa-sad-tear"></i> Seems like there are no incoming developer requests.
            </div>
        </EmptyDataTemplate>
        <Columns>

            <asp:ImageField DataImageUrlField="IconUrl" ItemStyle-CssClass="profile_table"/>
            <asp:HyperLinkField DataTextField="DeveloperName"/>
            <asp:ButtonField CommandName="Accept" Text="Accept" ItemStyle-CssClass="button_table"/>
            <asp:ButtonField CommandName="Deny" Text="Deny" ItemStyle-CssClass="button_table"/>
        </Columns>
    </asp:GridView>
    <asp:GridView
        Caption="Outgoing Developer Requests"
        ID="OutgoingDeveloperRequests"
        runat="server"
        AutoGenerateColumns="False"
        Visible="False"
        ShowHeader="False"
        BorderColor="Transparent"
        BorderWidth="0"
        DataKeyNames="Id"
        OnRowCommand="OutgoingDeveloperRequests_OnRowCommand"
        OnRowDataBound="OnRowDataBound">

        <EmptyDataTemplate>
            <div class="empty_temp">
            <i class="far fa-sad-tear"></i> Seems like there are no outgoing developer requests.
            </div>
        </EmptyDataTemplate>
        <Columns>

            <asp:ImageField DataImageUrlField="ProfilePictureUrl" ItemStyle-CssClass="profile_table"/>
            <asp:HyperLinkField DataTextField="Username"/>
            <asp:ButtonField Text="Cancel" ItemStyle-CssClass="button_table" CommandName="Cancel"/>
        </Columns>
    </asp:GridView>

</asp:Content>
