<%@ Page Language="C#" MasterPageFile="~/MasterPages/TabDetail.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="AS000003.aspx.cs" Inherits="Page_AS000003" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/TabDetail.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="False" Width="100%"
        TypeName="AcuStock.InventoryLocations"
        PrimaryView="Locations"
        >
		<CallbackCommands>

		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" Runat="Server"></asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" Runat="Server">
	<px:PXGrid AutoAdjustColumns="True" AllowPaging="True" AllowFilter="True" AllowSearch="True" Width="100%" SyncPosition="True" DataSourceID="ds" Height="150px" runat="server" ID="Locations">
		<Levels>
			<px:PXGridLevel DataMember="Locations" >
				<Columns>
					<px:PXGridColumn DataField="InventoryItem__InventoryCD" Width="70" ></px:PXGridColumn>
					<px:PXGridColumn DataField="InventoryID_description" Width="200" ></px:PXGridColumn>
					<px:PXGridColumn DataField="INSite__SiteCD" Width="120" ></px:PXGridColumn>
					<px:PXGridColumn DataField="INLocation__LocationCD" Width="120" ></px:PXGridColumn>
					<px:PXGridColumn DataField="QtyOnHand" Width="100" ></px:PXGridColumn>
					<px:PXGridColumn DataField="QtyAvail" Width="100" ></px:PXGridColumn>
					<px:PXGridColumn DataField="QtyHardAvail" Width="100" ></px:PXGridColumn>
					<px:PXGridColumn DataField="QtySOShipped" Width="100" ></px:PXGridColumn></Columns>
				<Mode AllowAddNew="False" ></Mode>
				<Mode AllowDelete="False" ></Mode>
				<Mode AllowFormEdit="False" ></Mode>
				<Mode AllowUpdate="False" ></Mode>
				<Mode AutoInsert="False" ></Mode></px:PXGridLevel></Levels>
		<OnChangeCommand Command="Refresh" Target="SerialLotDetails" Enabled="True" ></OnChangeCommand>
		<OnChangeCommand Target="SerialLotDetails" ></OnChangeCommand>
		<AutoCallBack Target="LotSerialDetails" Command="Refresh" Enabled="True" ></AutoCallBack>
		<AutoCallBack Handler="Refresh" ></AutoCallBack>
		<AutoCallBack Target="LotSerialDetails" ></AutoCallBack>
		<Mode AllowAddNew="False" ></Mode>
		<Mode AllowColMoving="True" ></Mode>
		<Mode AllowColSizing="True" ></Mode>
		<Mode AllowDelete="False" ></Mode>
		<Mode AllowFormEdit="False" ></Mode>
		<Mode AllowSort="True" ></Mode>
		<Mode AllowUpdate="False" ></Mode>
		<Mode AllowUpload="False" ></Mode>
		<Mode AutoInsert="False" ></Mode>
		<ActionBar Position="Top" ActionsVisible="True" >
			<Actions>
				<Delete Enabled="False" ></Delete>
				<AddNew Enabled="False" ></AddNew>
				<Save Enabled="False" ></Save>
				<Search Enabled="False" ></Search>
				<PageFirst Enabled="False" ></PageFirst>
				<PageLast Enabled="True" ></PageLast>
				<PageNext Enabled="False" ></PageNext>
				<PagePrev Enabled="False" ></PagePrev>
				<NoteShow Enabled="False" ></NoteShow>
				<FilterBar Enabled="True" ></FilterBar></Actions></ActionBar>
		<ActionBar>
			<Actions>
				<Delete Enabled="False" ></Delete></Actions></ActionBar>
		<ActionBar>
			<Actions>
				<EditRecord Enabled="False" ></EditRecord></Actions></ActionBar></px:PXGrid>
	<px:PXGrid AutoAdjustColumns="True" AllowFilter="True" AllowSearch="True" ID="LotSerialDetails" runat="server" DataSourceID="ds" Width="100%" Height="150px" SkinID="Details" AllowAutoHide="false">
		<Levels>
			<px:PXGridLevel DataMember="LotSerialDetails">
			    <Columns>
				<px:PXGridColumn DataField="LotSerialNbr" Width="200" ></px:PXGridColumn>
				<px:PXGridColumn DataField="QtyOnHand" Width="100" ></px:PXGridColumn>
				<px:PXGridColumn DataField="QtyAvail" Width="100" ></px:PXGridColumn>
				<px:PXGridColumn DataField="QtyHardAvail" Width="100" /></Columns>
			</px:PXGridLevel>
		</Levels>
		<AutoSize Container="Window" Enabled="True" MinHeight="150" ></AutoSize>
		<ActionBar >
		
			<Actions>
				<AddNew Enabled="False" ></AddNew></Actions>
			<Actions>
				<Delete Enabled="False" ></Delete></Actions></ActionBar>
	
		<CallbackCommands>
			<Refresh SelectControlsIDs="Locations" ></Refresh></CallbackCommands>
		<Mode AllowAddNew="False" ></Mode>
		<Mode AllowColMoving="True" ></Mode>
		<Mode AllowColSizing="True" ></Mode>
		<Mode AllowDelete="False" ></Mode>
		<Mode AllowDragRows="False" ></Mode>
		<Mode AllowFormEdit="False" ></Mode>
		<Mode AllowSort="True" ></Mode>
		<Mode AllowUpdate="False" ></Mode>
		<Mode AllowUpload="False" ></Mode>
		<Mode AutoInsert="False" ></Mode></px:PXGrid></asp:Content>
