<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmailTemplates.aspx.cs" Inherits="RecipiesWebFormApp.Admin.EmailTemplates" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="YordanCustomControls" Namespace="YordanCustomControls" TagPrefix="yordan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceEmailTemplates" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="EmailTemplates">
    </yordan:YordanCustomOpenAccessLinqDataSource>
    <yordan:YordanCustomRadGrid ID="rgEmailTemplates" runat="server" CellSpacing="0" DataSourceID="OpenAccessLinqDataSourceEmailTemplates" GridLines="None">
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="EmailTemplateId" DataSourceID="OpenAccessLinqDataSourceEmailTemplates">
            <Columns>
                <telerik:GridBoundColumn DataField="EmailTemplateId" DataType="System.Int32" FilterControlAltText="Filter EmailTemplateId column" HeaderText="EmailTemplateId" ReadOnly="True" SortExpression="EmailTemplateId" UniqueName="EmailTemplateId">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="From" FilterControlAltText="Filter From column" HeaderText="From" SortExpression="From" UniqueName="From">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>              
                <telerik:GridBoundColumn DataField="Cc" FilterControlAltText="Filter Cc column" HeaderText="Cc" SortExpression="Cc" UniqueName="Cc">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Bcc" FilterControlAltText="Filter Bcc column" HeaderText="Bcc" SortExpression="Bcc" UniqueName="Bcc">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Subject" FilterControlAltText="Filter Subject column" HeaderText="Subject" SortExpression="Subject" UniqueName="Subject">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="TextBody" FilterControlAltText="Filter TextBody column" HeaderText="TextBody" SortExpression="TextBody" UniqueName="TextBody">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridHTMLEditorColumn DataField="HtmlBody" FilterControlAltText="Filter HtmlBody column" HeaderText="HtmlBody" SortExpression="HtmlBody" UniqueName="HtmlBody">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridHTMLEditorColumn>
                <telerik:GridBoundColumn DataField="AttachmentName" FilterControlAltText="Filter AttachmentName column" HeaderText="AttachmentName" SortExpression="AttachmentName" UniqueName="AttachmentName">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridCheckBoxColumn DataField="IsDefault" DataType="System.Boolean" FilterControlAltText="Filter IsDefault column" HeaderText="IsDefault" SortExpression="IsDefault" UniqueName="IsDefault">
                </telerik:GridCheckBoxColumn>
                <telerik:GridBoundColumn DataField="ModifiedDate" ReadOnly="true" DataType="System.DateTime" FilterControlAltText="Filter ModifiedDate column" HeaderText="ModifiedDate" SortExpression="ModifiedDate" UniqueName="ModifiedDate">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ModifiedByUser" ReadOnly="true" FilterControlAltText="Filter ModifiedByUser column" HeaderText="ModifiedByUser" SortExpression="ModifiedByUser" UniqueName="ModifiedByUser">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
            </Columns>
        </MasterTableView>
    </yordan:YordanCustomRadGrid>
</asp:Content>