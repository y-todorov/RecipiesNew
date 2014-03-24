<%@ Page Title="Log in" Language="C#" MasterPageFile="~/SiteLogin.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RecipiesWebFormApp.Account.Login" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">   
    <section id="loginForm">
        <asp:Login runat="server" ViewStateMode="Disabled" RenderOuterTable="true">
            <LayoutTemplate>
                <p>
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
                <fieldset>
                    <legend>Log in Form</legend>
                    <table>
                        <tr>
                            <td>
                                <asp:Label runat="server" AssociatedControlID="UserName">User name</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="UserName" />
                            </td>
                            <td>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" ErrorMessage="The user name field is required." />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                            </td>
                            <td>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" ErrorMessage="The password field is required." />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button runat="server" CommandName="Login" Text="Log in" />
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                    </table>

                </fieldset>
            </LayoutTemplate>
        </asp:Login>
    </section>

</asp:Content>