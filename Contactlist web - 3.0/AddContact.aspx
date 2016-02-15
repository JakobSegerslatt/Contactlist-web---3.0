<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="AddContact.aspx.cs" Inherits="Contactlist_web___3._0.WebForm4" %>


<asp:Content ID="Content4" ContentPlaceHolderID="mainbody" runat="server">
    <table>
        <tr>
            <td>
                <h2>Add Contact</h2>
                <asp:Label ID="lblFirstname" runat="server" Text="Firstname"></asp:Label><br />
                <asp:TextBox ID="tboxFirstnameAdd" runat="server"></asp:TextBox><br />
                <asp:Label ID="lblLastname" runat="server" Text="Lastname"></asp:Label><br />
                <asp:TextBox ID="tboxLastnameAdd" runat="server"></asp:TextBox><br />
                <asp:Label ID="lblSSN" runat="server" Text="SSN"></asp:Label><br />
                <asp:TextBox ID="tboxSSNAdd" runat="server"></asp:TextBox><br /><br />
                <asp:Button ID="btnAdd" runat="server" Text="Add Contact" OnClick="btnAdd_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

