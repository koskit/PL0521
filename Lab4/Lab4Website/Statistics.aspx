<%@ Page Title="Statistics" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Statistics.aspx.cs" Inherits="Lab4Website.Statistics" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="customContainer">
        <asp:Label ID="CurrentUsersLabel" runat="server"></asp:Label>
        <br />
        <asp:TextBox runat="server" ID="OriginalTextbox"></asp:TextBox>
        <asp:TextBox runat="server" ID="CopiedTextbox"></asp:TextBox>
        <br />
        <asp:Button runat="server" ID="CopyText" OnClick="CopyText_Click" Text="Copy Text" />
        <br />
        <asp:Label ID="PreviousClicksLabel" runat="server"></asp:Label>
        <br />
        <asp:Label ID="CurrentClicksLabel" runat="server"></asp:Label>
        <br />
        <asp:Label ID="TotalClicksLabel" runat="server"></asp:Label>
        <br />
    </div>
</asp:Content>
