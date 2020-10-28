<%@ Page Title="" Language="C#" MasterPageFile="~/Missy.Master" AutoEventWireup="true" CodeBehind="AddReview.aspx.cs" Inherits="Navebsite.AddReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Navebsite" runat="server">
    <div class="review_form">
        <asp:Label Text="Review" runat="server" ID="reviewTitle"/>
        <asp:TextBox runat="server" ID="reviewContent" TextMode="MultiLine" Rows="10" CssClass="input review_form_text" placeholder="Write your Review here"/>
        <asp:RequiredFieldValidator ErrorMessage="You cannot submit an empty Review" ControlToValidate="reviewContent" runat="server"/>

        Rating
        <fieldset class="rating">
            <input id="demo-1" type="radio" name="demo" value="1">
            <label for="demo-1">1 star</label>
            <input id="demo-2" type="radio" name="demo" value="2">
            <label for="demo-2">2 stars</label>
            <input id="demo-3" type="radio" name="demo" value="3" checked="checked">
            <label for="demo-3">3 stars</label>
            <input id="demo-4" type="radio" name="demo" value="4">
            <label for="demo-4">4 stars</label>
            <input id="demo-5" type="radio" name="demo" value="5">
            <label for="demo-5">5 stars</label>

            <div class="stars">
                <label for="demo-1" aria-label="1 star" title="1 star"></label>
                <label for="demo-2" aria-label="2 stars" title="2 stars"></label>
                <label for="demo-3" aria-label="3 stars" title="3 stars"></label>
                <label for="demo-4" aria-label="4 stars" title="4 stars"></label>
                <label for="demo-5" aria-label="5 stars" title="5 stars"></label>
            </div>
        </fieldset>
        <asp:Button Text="Submit Review!" runat="server" ID="submit" OnClick="submit_Click" CssClass="button"/>
        <asp:Label Text="" runat="server" ID="errorBox"/>
    </div>
</asp:Content>