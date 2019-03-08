<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormDetail.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="AS000005.aspx.cs" Inherits="Page_AS000005" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormDetail.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="AcuStock.InventoryLocations"
        PrimaryView="Filter"
        >
		<CallbackCommands>

		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" Runat="Server">
	<px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="Filter" Width="100%" Height="100px" AllowAutoHide="false">
		<Template>
			<px:PXLayoutRule ID="PXLayoutRule1" runat="server" StartRow="True"></px:PXLayoutRule>
			<px:PXLayoutRule runat="server" ID="CstPXLayoutRule4" StartColumn="True" />
			<px:PXSelector CommitChanges="True" runat="server" ID="CstPXSelector3" DataField="SiteID" ></px:PXSelector>
			<px:PXLayoutRule runat="server" ID="CstPXLayoutRule5" StartColumn="True" />
			<px:PXSelector AutoRefresh="True" CommitChanges="True" runat="server" ID="CstPXSelector2" DataField="LocationID" ></px:PXSelector>
			<px:PXLayoutRule runat="server" ID="CstPXLayoutRule6" StartColumn="True" />
			<px:PXSelector CommitChanges="True" runat="server" ID="CstPXSelector1" DataField="InventoryID" ></px:PXSelector></Template>
	</px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" Runat="Server">
	<px:PXGrid ID="grid" runat="server" DataSourceID="ds" Width="100%" Height="150px" SkinID="Inquire" AllowAutoHide="false">
		<Levels>
			<px:PXGridLevel DataMember="Locations">
			    <Columns>
				<px:PXGridColumn DataField="InventoryItem__InventoryCD" Width="70" ></px:PXGridColumn>
				<px:PXGridColumn DataField="InventoryID_description" Width="200" ></px:PXGridColumn>
				<px:PXGridColumn DataField="SiteID" Width="120" ></px:PXGridColumn>
				<px:PXGridColumn DataField="LocationID" Width="120" ></px:PXGridColumn>
				<px:PXGridColumn DataField="QtyOnHand" Width="100" ></px:PXGridColumn>
				<px:PXGridColumn DataField="QtyAvail" Width="100" ></px:PXGridColumn>
				<px:PXGridColumn DataField="QtyHardAvail" Width="100" ></px:PXGridColumn>
				<px:PXGridColumn DataField="QtySOShipped" Width="100" ></px:PXGridColumn></Columns>
			</px:PXGridLevel>
		</Levels>
		<AutoSize Container="Window" Enabled="True" MinHeight="150" ></AutoSize>
		<ActionBar >
		</ActionBar>
	</px:PXGrid>
</asp:Content>