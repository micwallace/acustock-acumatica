<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormView.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="AS000004.aspx.cs" Inherits="Page_AS000004" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormView.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="AcuStock.AcuStockConfig"
        PrimaryView="ConfigView"
        >
		<CallbackCommands>

		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" Runat="Server">
	<px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="ConfigView" Width="100%" AllowAutoHide="false">
		<Template>
			<px:PXLayoutRule ID="PXLayoutRule1" runat="server" StartRow="True"></px:PXLayoutRule>
			<px:PXTextEdit runat="server" ID="CstPXTextEdit1" DataField="Version" /></Template>
		<AutoSize Container="Window" Enabled="True" MinHeight="200" ></AutoSize>
	</px:PXFormView>
</asp:Content>

