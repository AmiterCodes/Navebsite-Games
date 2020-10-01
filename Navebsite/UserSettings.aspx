<%@ Page Title="" Language="C#" MasterPageFile="~/Missy.Master" AutoEventWireup="true" CodeBehind="UserSettings.aspx.cs" Inherits="Navebsite.UserSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Navebsite" runat="server">
    
    <!-- BALANCE -->
    <div class="balance tuple_vert">
        <h3>Account Balance: </h3>
        <asp:Label Text="00.00" CssClass="balance_value" ID="CurrentBalance" runat="server" />
        <div class="tuple">
            <asp:TextBox placeholder="0.00" runat="server" CssClass="input" ID="AddBalance" />
            <asp:Button Text="Add To Balance" runat="server" CssClass="button" ID="AddBalanceButton" OnClick="AddBalanceButton_OnClick" />
        </div>
        <asp:RangeValidator MinimumValue="5" MaximumValue="1000" Type="Double" ErrorMessage="You must input at least 5 dollars and less than 1000 dollars" ControlToValidate="AddBalance" ValidationGroup="Balance" runat="server" />
        <asp:RequiredFieldValidator ErrorMessage="You must input money to add" ControlToValidate="AddBalance" ValidationGroup="Balance" runat="server" />
    </div>

    <!-- BANNER -->
    <asp:Panel CssClass="tuple_vert" runat="server" DefaultButton="UploadBackground">
        <asp:Image runat="server" ID="CurrentBackground" CssClass="image_preview"/>
        <asp:FileUpload ID="Background" runat="server" CssClass="input"/>
        <asp:RequiredFieldValidator ErrorMessage="You must upload an image" ControlToValidate="Background" ValidationGroup="Background" runat="server" />
        <asp:Button ID="UploadBackground" Text="Update Background" runat="server" CssClass="button" OnClick="UploadBackground_OnClick"/>
    </asp:Panel>
    
    <!-- PROFILE PICTURE -->

    <asp:Panel CssClass="tuple_vert" runat="server" DefaultButton="UploadProfile">
        <asp:Image runat="server" ID="CurrentProfilePicture" CssClass="image_preview"/>
        
        <asp:FileUpload ID="ProfilePicture" runat="server" CssClass="input"/>
        <asp:RequiredFieldValidator ErrorMessage="You must upload an image" ControlToValidate="ProfilePicture" ValidationGroup="ProfilePicture" runat="server" />
        <asp:Button ID="UploadProfile" Text="Update Profile Picture" runat="server" CssClass="button" OnClick="UploadProfile_OnClick"/>
    </asp:Panel>
    
    <!-- BIO -->

    <asp:Panel CssClass="tuple_vert" runat="server" DefaultButton="UpdateBio">
        <asp:TextBox ID="Bio" TextMode="MultiLine" runat="server" CssClass="input" placeholder="Bio Here..."/>
        <asp:Button Text="Update Bio" ID="UpdateBio" runat="server" CssClass="button" OnClick="UpdateBio_OnClick"/>
        <asp:RequiredFieldValidator ErrorMessage="You must put a bio to update" ControlToValidate="Bio" ValidationGroup="Bio" runat="server" />
    </asp:Panel>

    <asp:Panel CssClass="tuple_vert" runat="server" DefaultButton="UpdatePassword">
        
        <asp:TextBox ID="OldPassword" runat="server" CssClass="input" placeholder="Old Password" TextMode="Password"/>
        <asp:TextBox ID="Password" runat="server" CssClass="input" placeholder="Password" TextMode="Password"/>
        <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="input" placeholder="Confirm Password" TextMode="Password"/>
        <asp:Button Text="Update Password" ID="UpdatePassword" runat="server" CssClass="button" OnClick="UpdatePassword_OnClick"/>
        
        <!-- VALIDATORS -->
        <asp:RequiredFieldValidator ErrorMessage="You must put a password" ControlToValidate="Password" ValidationGroup="ChangePassword" runat="server" />
        <asp:RegularExpressionValidator ErrorMessage="Password must be at least 6 letters, with at least one capital letter, lowercase letter and one number" ControlToValidate="Password" ValidationGroup="ChangePassword" ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{6,}$" runat="server" />
        <asp:RequiredFieldValidator ErrorMessage="You must confirm your password" ControlToValidate="ConfirmPassword" ValidationGroup="ChangePassword" runat="server" />        
        <asp:CompareValidator ErrorMessage="Password confirmation must be the same as password" ControlToValidate="ConfirmPassword" ControlToCompare="Password" runat="server" />
        <asp:Label runat="server" ID="ErrorBox"></asp:Label>
    </asp:Panel>
    <!-- IMAGE -->

    <asp:Panel class="tuple_vert" runat="server" DefaultButton="UploadImage">
        <asp:FileUpload ID="ImageUpload" runat="server" CssClass="input"/>
        <asp:RequiredFieldValidator ErrorMessage="You must upload an image" ControlToValidate="ImageUpload" ValidationGroup="Image" runat="server" />
        <asp:Button ID="UploadImage" Text="Add Image to user gallery" runat="server" CssClass="button" OnClick="UploadImage_OnClick"/>
    </asp:Panel>

</asp:Content>