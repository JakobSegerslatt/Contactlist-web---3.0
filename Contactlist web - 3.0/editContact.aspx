<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="editContact.aspx.cs" Inherits="Contactlist_web___3._0.WebForm1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="mainbody" runat="server">
    <asp:Literal ID="phoneLit" runat="server"></asp:Literal>
    <script>
        function editPhone(id, type, phonenumber) {
            $('input.tboxPhonenumber').val(phonenumber);
            $('input.ddphonetypEdit').val(type).change();
            $('input.hiddenID').val(id);
            $('#editModal').modal();
        }
    </script>
    
    <!-- Trigger the modal with a button -->
<button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Add Phone</button>

<!-- Modal -->
<div id="myModal" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
         <h4 class="modal-title">Modal Header</h4>
      </div>
      <div class="modal-body">
          <asp:DropDownList ID="ddTypePhone" runat="server">
              <asp:ListItem>Hem</asp:ListItem>
              <asp:ListItem>Jobb</asp:ListItem>
              <asp:ListItem>Fritid</asp:ListItem>
          </asp:DropDownList>
          <asp:Label ID="lblAddPhone" runat="server" Text="Phonenumber"></asp:Label>
          <asp:TextBox ID="tboxPhonenumber" runat="server"></asp:TextBox><br />
          <asp:Button ID="btnaddPhone" runat="server" Text="Add Phone" OnClick="btnaddPhone_Click" />
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>

  </div>
</div>

<!--Modal-->
 <div id="editModal" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
         <h4 class="modal-title">Modal Header</h4>
      </div>
      <div class="modal-body">
          <asp:TextBox CssClass="hiddenID" ID="TextBox1" runat="server" hidden="true"></asp:TextBox><br />
          <asp:DropDownList ID="ddPhoneTypeEdit" runat="server">
              <asp:ListItem>Hem</asp:ListItem>
              <asp:ListItem>Jobb</asp:ListItem>
              <asp:ListItem>Fritid</asp:ListItem>
          </asp:DropDownList>
          <asp:Label ID="Label1" runat="server" Text="Phonenumber"></asp:Label>
          <asp:TextBox CssClass="tboxPhonenumber" ID="tboxPhone" runat="server"></asp:TextBox><br />
          <asp:Button ID="Button1" runat="server" Text="Edit Phone" OnClick="Button1_Click"/>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>

  </div>
</div>
</asp:Content>
