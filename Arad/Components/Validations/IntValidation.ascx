<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="IntValidation.ascx.vb" Inherits="Arad.IntValidation" %>
<script type="text/javascript">
    function keyDownNumber(obj) {
        var key;
        if (navigator.appName == 'Microsoft Internet Explorer')
            key = event.keyCode;
        else
            key.event.which

        if (!(key >= 48 && key <= 57) && key != 8 && key != 46 && key != 36 && key != 37) {
            event.returnValue = false;
        }
    }
</script>

<script type="text/javascript">
    function onlyDotsAndNumbers(event) {
        var charCode = (event.which) ? event.which : event.keyCode
        if (charCode == 46) {
            return true;
        }
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;
        return true;
    }

    function onlyNumbers(event) {
        var charCode = (event.which) ? event.which : event.key
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;
        return true;
    }

    function noAlphabets(event) {
        var charCode = (event.which) ? event.which : event.keyCode
        if ((charCode >= 97) && (charCode <= 122) || (charCode >= 65) && (charCode <= 90))
            return false;
        return true;
    }
</script>

<asp:TextBox ID="TextBox1" runat="server" onkeypress="return onlyNumbers(event)"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="TextBox1" ErrorMessage="این فیلد اجباری می باشد"></asp:RequiredFieldValidator>