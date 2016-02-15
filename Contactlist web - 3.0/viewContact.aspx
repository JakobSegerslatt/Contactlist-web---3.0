<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="viewContact.aspx.cs" Inherits="Contactlist_web___3._0.WebForm2" %>

<asp:Content ID="Content4" ContentPlaceHolderID="mainbody" runat="server">
    <table>
        <tr>
            <td>
                <asp:Label ID="lblFirstname" runat="server" Text="Ingen"></asp:Label></td>
            <td>
                <asp:Label ID="lblLastname" runat="server" Text="Kontakt"></asp:Label></td>
            <td>
                <asp:Label ID="lblSSN" runat="server" Text="Kontakt"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:TextBox ID="tboxFirstName" runat="server"></asp:TextBox></td>
            <td><asp:TextBox ID="tboxLastname" runat="server"></asp:TextBox></td>
            <td><asp:TextBox ID="tboxSSN" runat="server"></asp:TextBox></td>
        </tr>
    </table>

    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />

</asp:Content>
