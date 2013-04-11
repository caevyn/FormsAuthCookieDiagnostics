<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CookieTest35._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <div>I'm <%=User.Identity.IsAuthenticated ? "Authenticated" : "Not authenticated"%></div>
            
           <% if(HasCookie)
            {%>
                <div><%= DecryptResult%></div>
            <%}
            else
            { %>
                <div>I didn't get an auth cookie.</div>
            <%} %>
            <table>
                <tr><th>Setting</th><th>Value</th></tr>
                <tr>
                    <td>Installed .net version:</td>
                    <td><%=InstalledDotNetVersion %></td>
                </tr>
                <tr>
                    <td>Target Runtime:</td>
                    <td><%=TargetRuntime%></td>
                </tr>
                <tr>
                    <td>Compatibility mode:</td>
                    <td><%=CompatibilityMode%></td>
                </tr>
                <tr>
                    <td>ValidationAlgorithm:</td>
                    <td><%=ValidationAlgorithm %></td>
                </tr>
                <tr>
                    <td>ValidationKey:</td>
                    <td><%=ValidationKey%></td>
                </tr>
                <tr>
                    <td>DecryptionAlgorithm:</td>
                    <td><%=DecryptionAlgorithm%></td>
                </tr>
                <tr>
                    <td>DecryptionKey:</td>
                    <td><%=DecryptionKey%></td>
                </tr>
                 <tr>
                    <td>System.Web:</td>
                    <td><%=SystemWeb.ToString()%></td>
                </tr>
            </table>
           
    </div>
    <asp:TextBox ID="loginTextBox" runat="server" />
    <asp:Button ID="loginButton" OnClick="loginButton_Click" Text="get auth cookie" runat="server" />
    </form>
</body>
</html>
