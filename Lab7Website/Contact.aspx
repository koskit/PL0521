<%@ Page Title="Στοιχεία Εταιρίας" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Lab7Website.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/GridPagination.css">
    <br />
    <br />
    <asp:GridView
        ID="CompaniesData" runat="server"
        AllowSorting="true" AutoGenerateColumns="false" DataKeyNames="CompanyId,Name,Description"
        Width="80%" CssClass="table table-striped"
        ItemType="Lab7Website.Models.Company"
        OnSelectedIndexChanged="CompaniesData_SelectedIndexChanged"
        SelectMethod="CompaniestData_GetItem"
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
            <asp:CommandField ShowSelectButton="true" />
        </Columns>
    </asp:GridView>

    <asp:FormView
        ID="CompaniesContactData" runat="server"
        AutoGenerateColumns="false" DataKeyNames="CompanyId,Name,Description,StartDate,Limit"
        Width="80%" CssClass="table table-striped"
        ItemType="Lab7Website.Models.Company"
        SelectMethod="CompaniesContactData_GetItem"
        InsertMethod="CompaniesContactData_InsertItem"
        DeleteMethod="CompaniesContactData_DeleteItem"
        UpdateMethod="CompaniesContactData_UpdateItem">
        <InsertItemTemplate>
            <table class="table table-bordered table-striped">
                <tr>
                    <td colspan="2">
                        <h3>Στοιχεία Εταιρίας</h3>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <h6>To company id χρησιμοποιείται σαν primary key και δεν μπορεί να γίνει edit.</h6>
                    </td>
                </tr>
                <tr>
                    <td>CompanyId</td>
                    <td>*Id is updated automatically in database*</td>
                </tr>
                <tr>
                    <td>Name</td>
                    <td>
                        <asp:TextBox ID="NameEditTextBox" Text='<%#Eval("Name") %>' runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Description</td>
                    <td>
                        <asp:TextBox ID="DescriptionEditTextBox" Text='<%#Eval("Description") %>' runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>StartDate</td>
                    <td>
                        <asp:TextBox ID="StartDateEditTextBox" runat="server" Text='<%#Eval("StartDate") %>'></asp:TextBox>
                        <asp:CompareValidator ID="StartDateEditTextBoxValidator" runat="server"
                            ControlToValidate="StartDateEditTextBox"
                            Type="Date"
                            Operator="DataTypeCheck" SetFocusOnError="true" ErrorMessage="Invalid Date" Font-Bold="true" ForeColor="red" />
                    </td>
                </tr>
                <tr>
                    <td>Limit</td>
                    <td>
                        <asp:TextBox ID="LimitEditTextBox" Text='<%#Eval("Limit") %>' runat="server" />
                        <asp:RegularExpressionValidator ID="LimitEditTextBoxValidator" runat="server"
                            ControlToValidate="LimitEditTextBox"
                            ValidationExpression="[0-9]+(\.[0-9]*)?"
                            ErrorMessage="Invalid Limit Amount" Font-Bold="true" ForeColor="red" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="InsertButton"
                            Text="Insert"
                            CommandName="Insert"
                            runat="server" />
                        <asp:LinkButton ID="CancelButton"
                            Text="Cancel"
                            CommandName="Cancel"
                            runat="server" />
                    </td>
                </tr>
            </table>
        </InsertItemTemplate>
        <ItemTemplate>
            <table class="table table-bordered table-striped fixed" style="table-layout: fixed;">
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
                        <asp:LinkButton ID="New"
                            Text="New"
                            CommandName="New"
                            runat="server" />
                        <asp:LinkButton ID="Edit"
                            Text="Edit"
                            CommandName="Edit"
                            runat="server" />
                        <asp:LinkButton ID="Delete"
                            Text="Delete"
                            CommandName="Delete"
                            runat="server" />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
        <EditItemTemplate>
            <table class="table table-bordered table-striped">
                <tr>
                    <td colspan="2">
                        <h3>Στοιχεία Εταιρίας</h3>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <h6>To company id χρησιμοποιείται σαν primary key και δεν μπορεί να γίνει edit.</h6>
                    </td>
                </tr>
                <tr>
                    <td>CompanyId</td>
                    <td><%#Eval("CompanyId") %></td>
                </tr>
                <tr>
                    <td>Name</td>
                    <td>
                        <asp:TextBox ID="NameEditTextBox" Text='<%# Bind("Name") %>' runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Description</td>
                    <td>
                        <asp:TextBox ID="DescriptionEditTextBox" Text='<%# Bind("Description") %>' runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>StartDate</td>
                    <td>
                        <asp:TextBox ID="StartDateEditTextBox" runat="server" Text='<%#Bind("StartDate","{0:dd-MM-yyyy}")%>'></asp:TextBox>
                        <asp:CompareValidator ID="StartDateEditTextBoxValidator" runat="server"
                            ControlToValidate="StartDateEditTextBox"
                            Type="Date"
                            Operator="DataTypeCheck" SetFocusOnError="true" ErrorMessage="Invalid Date" Font-Bold="true" ForeColor="red" />
                    </td>
                </tr>
                <tr>
                    <td>Limit</td>
                    <td>
                        <asp:TextBox ID="LimitEditTextBox" Text='<%# Bind("Limit") %>' runat="server" />
                        <asp:RegularExpressionValidator ID="LimitEditTextBoxValidator" runat="server"
                            ControlToValidate="LimitEditTextBox"
                            ValidationExpression="[0-9]+(\.[0-9]*)?"
                            ErrorMessage="Invalid Limit Amount" Font-Bold="true" ForeColor="red" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="UpdateButton"
                            Text="Update"
                            CommandName="Update"
                            runat="server" />
                        <asp:LinkButton ID="CancelButton"
                            Text="Cancel"
                            CommandName="Cancel"
                            runat="server" />
                    </td>
                </tr>
            </table>
        </EditItemTemplate>
    </asp:FormView>
    <label>Last message: </label>
    <asp:Label ID="actionOutcome" runat="server"></asp:Label>
</asp:Content>
