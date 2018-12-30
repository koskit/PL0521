<%@ Page Title="Advanced Dbase Issues" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Companies.aspx.cs" Inherits="Lab7Website.Companies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/GridPagination.css">
    <h1><%: Page.Title %></h1>
    <h6>To company id χρησιμοποιείται σαν primary key και δεν μπορεί να γίνει edit.</h6>
    <asp:GridView
        ID="CompaniesData" runat="server"
        AllowSorting="true" AutoGenerateColumns="false" DataKeyNames="CompanyId,Name,Description"
        Width="80%" CssClass="table table-striped"
        ItemType="Lab7Website.Models.Company"
        SelectMethod="CompaniesData_GetData"
        UpdateMethod="CompaniesData_UpdateItem"
        DeleteMethod="CompaniesData_DeleteItem"
        AllowPaging="True" PageSize="3"
        PagerStyle-CssClass="paginationGrid"
        PagerStyle-HorizontalAlign="Center"
        PagerSettings-NextPageText="Επόμενη>"
        PagerSettings-PreviousPageText="<Προηγούμενη"
        PagerSettings-FirstPageText="<<Αρχή"
        PagerSettings-LastPageText="Τέλος>>"
        PagerSettings-Mode="NextPreviousFirstLast">
        <Columns>
            <asp:DynamicField DataField="CompanyId" HeaderText="CompanyId" ReadOnly="true" />
            <asp:DynamicField DataField="Name" HeaderText="Επωνυμία" />
            <asp:DynamicField DataField="Description" HeaderText="Περιγραφή" />
            <asp:CommandField ShowEditButton="true" />
            <asp:CommandField ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="actionOutcome" runat="server"></asp:Label>
</asp:Content>
