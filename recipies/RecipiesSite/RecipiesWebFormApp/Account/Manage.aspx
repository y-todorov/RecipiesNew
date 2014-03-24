<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="RecipiesWebFormApp.Account.Manage" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <section id="passwordForm">
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="true" ViewStateMode="Disabled">
            <p><%: SuccessMessage %></p>
        </asp:PlaceHolder>

   


        <asp:PlaceHolder runat="server" ID="changePassword" Visible="true">          
            <asp:ChangePassword runat="server" CancelDestinationPageUrl="~/" ViewStateMode="Disabled" RenderOuterTable="false" SuccessPageUrl="Manage?m=ChangePwdSuccess">
                <ChangePasswordTemplate>
                    <p>
                        <asp:Literal runat="server" ID="FailureText" />
                    </p>
                    <fieldset>
                        <legend>Change password details</legend>

                        <table>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="CurrentPasswordLabel" AssociatedControlID="CurrentPassword">Current password</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="CurrentPassword" TextMode="Password" />
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentPassword"
                                                                ErrorMessage="The current password field is required."
                                                                ValidationGroup="ChangePassword" />
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="NewPasswordLabel" AssociatedControlID="NewPassword">New password</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="NewPassword" TextMode="Password" />
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="NewPassword"
                                                                ErrorMessage="The new password is required."
                                                                ValidationGroup="ChangePassword" />
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="ConfirmNewPasswordLabel" AssociatedControlID="ConfirmNewPassword">Confirm new password</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="ConfirmNewPassword" TextMode="Password" />
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmNewPassword"
                                                                Display="Dynamic" ErrorMessage="Confirm new password is required."
                                                                ValidationGroup="ChangePassword" />
                                </td>
                                <td>
                                    <asp:CompareValidator runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                                                          Display="Dynamic" ErrorMessage="The new password and confirmation password do not match."
                                                          ValidationGroup="ChangePassword" />
                                </td>
                            </tr>
                            <tr>
                            <tr>
                                <td>
                                    <asp:Button runat="server" CommandName="ChangePassword" Text="Change password" ValidationGroup="ChangePassword" />
                                </td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                        </tr>
                        </table>
                    </fieldset>
                </ChangePasswordTemplate>
            </asp:ChangePassword>
        </asp:PlaceHolder>
    </section>
</asp:Content>