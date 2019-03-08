<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormDetail.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="AS000002.aspx.cs" Inherits="Page_AS000002" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormDetail.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="AcuStock.InventoryLotSerials"
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
			<px:PXSegmentMask CommitChanges="True" runat="server" ID="CstPXSegmentMask3" DataField="SiteID" ></px:PXSegmentMask>
			<px:PXLayoutRule runat="server" ID="CstPXLayoutRule5" StartColumn="True" />
			<px:PXSegmentMask runat="server" ID="CstPXSegmentMask2" DataField="LocationID" />
			<px:PXLayoutRule runat="server" ID="CstPXLayoutRule6" StartColumn="True" />
			<px:PXSegmentMask CommitChanges="True" runat="server" ID="CstPXSegmentMask1" DataField="InventoryID" ></px:PXSegmentMask></Template>
	</px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" Runat="Server">
	<px:PXGrid ID="grid" runat="server" DataSourceID="ds" Width="100%" Height="150px" SkinID="Details" AllowAutoHide="false">
		<Levels>
			<px:PXGridLevel DataMember="LotSerials">
			    <Columns>
				<px:PXGridColumn DataField="InventoryID" Width="70" ></px:PXGridColumn>
				<px:PXGridColumn DataField="SiteID" Width="120" ></px:PXGridColumn>
				<px:PXGridColumn DataField="LocationID" Width="120" ></px:PXGridColumn>
				<px:PXGridColumn DataField="LotSerialNbr" Width="200" />
				<px:PXGridColumn DataField="QtyOnHand" Width="100" ></px:PXGridColumn>
				<px:PXGridColumn DataField="QtyAvail" Width="100" ></px:PXGridColumn>
				<px:PXGridColumn DataField="QtyHardAvail" Width="100" ></px:PXGridColumn></Columns>
			</px:PXGridLevel>
		</Levels>
		<AutoSize Container="Window" Enabled="True" MinHeight="150" />
		<ActionBar >
		</ActionBar>
	</px:PXGrid>
</asp:Content>
