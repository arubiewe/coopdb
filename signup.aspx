<%@ Page Language="C#" AutoEventWireup="true" CodeFile="signup.aspx.cs" Inherits="signup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Table ID="Table1" runat="server" Width="418px" Height="209px">  
    <asp:TableRow>  
        <asp:TableCell>  
            User Name  
        </asp:TableCell>  
        <asp:TableCell>  
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>  
        </asp:TableCell>  
    </asp:TableRow>  
    <asp:TableRow>  
        <asp:TableCell>  
            Password  
        </asp:TableCell>  
        <asp:TableCell>  
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>  
        </asp:TableCell>  
    </asp:TableRow>  
    <asp:TableRow>  
        <asp:TableCell>  
            <asp:Button ID="Button1" runat="server" Text="Sign Up" OnClick="Message_click" />  
        </asp:TableCell>  
        <asp:TableCell>  
            <asp:Button ID="Button2" runat="server" Text="login" OnClick="login_click" />  
        </asp:TableCell>  
        <asp:TableCell>  
            <asp:Label ID="Label1" runat="server" />  
        </asp:TableCell>  
    </asp:TableRow>  
</asp:Table> 
    </form>
</body>
</html>
