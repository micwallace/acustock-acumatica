<%@ Page Language="C#" MasterPageFile="~/MasterPages/ListView.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="AS000002.aspx.cs" Inherits="Page_AS000002" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/ListView.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="AcuStock.InventoryLotSerials"
        PrimaryView="LotSerials"
        >
		<CallbackCommands>

		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phL" runat="Server">
	<px:PXGrid ID="grid" runat="server" DataSourceID="ds" Width="100%" Height="150px" SkinID="Primary" AllowAutoHide="false">
		<Levels>
			<px:PXGridLevel DataMember="LotSerials">
			    <Columns>
				<px:PXGridColumn DataField="INSite__SiteCD" Width="120" ></px:PXGridColumn>
				<px:PXGridColumn DataField="INLocation__LocationCD" Width="120" ></px:PXGridColumn>
				<px:PXGridColumn DataField="InventoryID" Width="70" ></px:PXGridColumn>
				<px:PXGridColumn DataField="LotSerialNbr" Width="200" ></px:PXGridColumn>
				<px:PXGridColumn DataField="QtyOnHand" Width="100" ></px:PXGridColumn>
				<px:PXGridColumn DataField="QtyAvail" Width="100" ></px:PXGridColumn>
				<px:PXGridColumn DataField="QtyHardAvail" Width="100" /></Columns>
			
				<Mode AllowUpdate="False" ></Mode>
				<Mode AllowFormEdit="False" ></Mode>
				<Mode AllowDelete="False" ></Mode>
				<Mode AllowAddNew="False" ></Mode>
				<Mode AutoInsert="False" ></Mode></px:PXGridLevel>
		</Levels>
		<AutoSize Container="Window" Enabled="True" MinHeight="150" ></AutoSize>
		<ActionBar >
		
			<Actions>
				<AddNew Enabled="False" MenuVisible="False" ></AddNew>
						<Delete MenuVisible="False" Enabled="False" ></Delete>
						<EditRecord Enabled="False" ></EditRecord>
						<Save MenuVisible="False" Enabled="False" ></Save>
						<Upload Enabled="False" ></Upload></Actions>
			<Actions>
				<AddNew Enabled="False" ></AddNew></Actions></ActionBar>
	</px:PXGrid>
</asp:Content>