<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditModal.ascx.cs" Inherits="Contactlist_web___3._0.WebUserControl1" %>

      <script>
          function editContact(id, firstname, lastname, ssn) {
              $('input.tboxFirstname').val(firstname);
              $('input.tboxLastname').val(lastname);
              $('input.tboxSSN').val(ssn);
              $('input.hiddenID').val(id);
              $('#btnUpdate').attr('Text').val(Update);
              $('#editContactModal').modal();
              
          }
          
      </script>
    
    
 
    <!-- Modal -->
<div id="editContactModal" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
         <h4 class="modal-title">Modal Header</h4>
      </div>
      <div class="modal-body">
          <asp:TextBox ID="hiddenID" CssClass="hiddenID" hidden="true" runat="server"></asp:TextBox>
          <asp:Label ID="lblFirstname" runat="server" Text="Firstname"></asp:Label><br />
          <asp:TextBox ID="tboxFirstName" CssClass="tboxFirstName" runat="server"></asp:TextBox><br />
          <asp:Label ID="lblLastName" runat="server" Text="Lastname"></asp:Label><br />
          <asp:TextBox ID="tboxLastName" CssClass="tboxLastname" runat="server"></asp:TextBox><br />
          <asp:Label ID="lblSSN" runat="server" Text="SSN"></asp:Label><br />
          <asp:TextBox ID="tboxSSN" CssClass="tboxSSN" runat="server"></asp:TextBox><br />
          <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"/>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>

  </div>
</div>

            
