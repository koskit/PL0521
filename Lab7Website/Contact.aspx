<%@ Page Title="Στοιχεία Εταιρίας" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Lab7Website.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/GridPagination.css">
    <asp:FormView
        ID="CompaniesContactData" runat="server"
        AutoGenerateColumns="false" DataKeyNames="CompanyId,Name,Description"
        Width="80%" CssClass="table table-striped"
        ItemType="Lab7Website.Models.Company"
        SelectMethod="CompaniesContactData_GetItem"
        InsertMethod="CompaniesContactData_InsertItem"
        DeleteMethod="CompaniesContactData_DeleteItem"
        UpdateMethod="CompaniesContactData_UpdateItem"
        AllowPaging="True" PageSize="1"
        PagerStyle-CssClass="paginationGrid">
        <ItemTemplate>
            <table class="table table-bordered table-striped">
                <tr>
                    <td colspan="2">
                        <h3>Στοιχεία Εταιρίας</h3>
                    </td>
                </tr>
                <tr>
                    <td>CompanyId</td>
                    <td><%#Eval("CompanyId") %></td>
                </tr>
                <tr>
                    <td>Name</td>
                    <td><%#Eval("Name") %></td>
                </tr>
                <tr>
                    <td>Description</td>
                    <td><%#Eval("Description") %></td>
                </tr>
                <tr>
                    <td>StartDate</td>
                    <td><%#DateTime.Parse(Eval("StartDate").ToString()).ToShortDateString()%></td>
                </tr>
                <tr>
                    <td>Limit</td>
                    <td><%#Eval("Limit") %></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="Edit"
                            Text="Edit"
                            CommandName="Edit"
                            runat="server" />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
        <EditItemTemplate>
        </EditItemTemplate>
    </asp:FormView>
    <asp:Label ID="actionOutcome" runat="server"></asp:Label>
</asp:Content>
