<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomCss.aspx.cs" Inherits="Lab4Website.CustomCss" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="maindiv">
        <h1 style="text-align: center">Custom CSS Page</h1>
        <hr />
        <div>
            <table class="tableForCustomCss">
                <tr class="arialFont boldLetters">
                    <td>Description</td>
                    <td>Class Name</td>
                    <td>CSS Rules</td>
                    <td>Outcome</td>
                </tr>
                <tr>
                    <td>Changes the background to the given color.</td>
                    <td>lightblueBackground</td>
                    <td>background-color: lightblue;</td>
                    <td class="lightblueBackground">Example</td>
                </tr>
                <tr>
                    <td>Changes the background to the given color.</td>
                    <td>rosybrownBackground</td>
                    <td>background-color: rosybrown</td>
                    <td class="rosybrownBackground">Example</td>
                </tr>
                <tr>
                    <td>Changes the background to the given color.</td>
                    <td>darkcyanBackground</td>
                    <td>background-color: darkcyan</td>
                    <td class="darkcyanBackground">Example</td>
                </tr>
                <tr>
                    <td>Changes the letters to bold.</td>
                    <td>boldLetters</td>
                    <td>font-weight: bold;</td>
                    <td class="boldLetters">Example</td>
                </tr>
                <tr>
                    <td>Changes the letters to italic.</td>
                    <td>italicLetters</td>
                    <td>font-style: italic</td>
                    <td class="italicLetters">Example</td>
                </tr>
                <tr>
                    <td>Changes the boarder to the given style.</td>
                    <td>boarderDotted</td>
                    <td>border: dotted</td>
                    <td class="boarderDotted">Example</td>
                </tr>
                <tr>
                    <td>Changes the boarder to the given style.</td>
                    <td>boarderDouble</td>
                    <td>border: double</td>
                    <td class="boarderDouble">Example</td>
                </tr>
                <tr>
                    <td>Changes the letters' font.</td>
                    <td>arialFont</td>
                    <td>font-family: Arial</td>
                    <td class="arialFont">Example</td>
                </tr>
                <tr>
                    <td>Changes the letters' font.</td>
                    <td>newTimesRomanFont</td>
                    <td>font-family: 'Times New Roman', Times, serif</td>
                    <td class="newTimesRomanFont">Example</td>
                </tr>
                <tr>
                    <td>Floats the content to left.</td>
                    <td>floatLeft</td>
                    <td>float: left;</td>
                    <td class="floatLeft">Example</td>
                </tr>
                <tr>
                    <td>Floats the content to right.</td>
                    <td>floatRight</td>
                    <td>float: right;</td>
                    <td class="floatRight">Example</td>
                </tr>
            </table>
            <hr />
            <h4>LuckyLabel uses random CSS rules in code behind and applies them to the example below.</h4>
            <asp:Label runat="server" ID="luckyInfo"></asp:Label>
            <br />
            <br />
            <asp:Label runat="server" ID="luckyLabel">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec faucibus urna eget nulla ullamcorper pulvinar.</asp:Label>
        </div>
    </div>
</asp:Content>
