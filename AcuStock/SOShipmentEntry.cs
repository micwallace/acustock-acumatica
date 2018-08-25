using PX.Data.ReferentialIntegrity.Attributes;


using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using PX.Data;
using PX.Common;
using PX.Objects.AR;
using PX.Objects.CM;
using PX.Objects.CR;
using PX.Objects.CS;
using PX.Objects.EP;
using PX.Objects.GL;
using PX.Objects.IN;
using PX.SM;
using PX.TM;
using SiteStatus = PX.Objects.IN.Overrides.INDocumentRelease.SiteStatus;
using LocationStatus = PX.Objects.IN.Overrides.INDocumentRelease.LocationStatus;
using LotSerialStatus = PX.Objects.IN.Overrides.INDocumentRelease.LotSerialStatus;
using ItemLotSerial = PX.Objects.IN.Overrides.INDocumentRelease.ItemLotSerial;
using SiteLotSerial = PX.Objects.IN.Overrides.INDocumentRelease.SiteLotSerial;
using POLineType = PX.Objects.PO.POLineType;
using POReceipt = PX.Objects.PO.POReceipt;
using POReceiptLine = PX.Objects.PO.POReceiptLine;
using System.Diagnostics;
using PX.Objects.PO;
using PX.Objects.AR.MigrationMode;
using PX.Objects.Common;
using PX.Objects;
using PX.Objects.SO;

namespace PX.Objects.SO
{
  public class SOShipmentEntry_Extension : PXGraphExtension<SOShipmentEntry>
  {
    
    #region Event Handlers
  
    protected void SOShipLine_RowSelected(PXCache cache, PXRowSelectedEventArgs e){
      
      var row = (SOShipLine) e.Row;

      if (row == null)
        return;

      PXUIFieldAttribute.SetEnabled<SOShipLineExt.usrQtyPicked>(cache, e.Row, (row.LocationID > 0));

    }  

    protected void SOShipLine_UsrQtyPicked_FieldUpdated(PXCache cache, PXFieldUpdatedEventArgs e){
      
      if (!e.ExternalCall) return;
      
      var row = (SOShipLine) e.Row;
      
      var rowExt = row.GetExtension<SOShipLineExt>();
      
      decimal? qty = rowExt.UsrQtyPicked;

      foreach (SOShipLineSplit split in Base.splits.Select()){
        
        decimal? pickQty = qty < split.Qty ? qty : split.Qty;
        
        qty -= pickQty;

        Base.splits.Cache.SetValueExt<SOTableShipLineSplitExt.usrQtyPicked>(split, pickQty);
        Base.splits.Cache.SetValueExt<SOShipLineSplitExt.usrQtyPicked>(split, pickQty);
        Base.splits.Cache.SetStatus(split, PXEntryStatus.Modified);
        Base.splits.Cache.IsDirty = true;
        
      }

    }

    protected void SOShipLineSplit_UsrQtyPicked_FieldVerifying(PXCache cache, PXFieldVerifyingEventArgs e){
      
      var row = (SOShipLineSplit) e.Row;
      var qty = (decimal) e.NewValue;

      if (qty > row.Qty)
        throw new PXSetPropertyException("Picked quantity must be less or equal to the allocated quantity.");
      
    }

    protected void SOShipLineSplit_RowInserted(PXCache cache, PXRowInsertedEventArgs e){
        var row = (SOShipLineSplit) e.Row;
        SOShipLineSplitExt splitExt = row.GetExtension<SOShipLineSplitExt>();

        if (splitExt.UsrQtyPicked > 0 && Base.Transactions.Current != null){
            SOShipLineExt lineExt = Base.Transactions.Current.GetExtension<SOShipLineExt>();
            Base.Transactions.SetValueExt<SOShipLineExt.usrQtyPicked>(Base.Transactions.Current, (lineExt.UsrQtyPicked + splitExt.UsrQtyPicked));
        }
    }

    protected void SOShipLineSplit_UsrQtyPicked_FieldUpdated(PXCache cache, PXFieldUpdatedEventArgs e){
        var row = (SOShipLineSplit) e.Row;
        SOShipLineSplitExt splitExt = row.GetExtension<SOShipLineSplitExt>();
        decimal? diff = splitExt.UsrQtyPicked - ((decimal) e.OldValue);

        PXTrace.WriteInformation("Field updated, old value: " + ((decimal)e.OldValue) + " new: " + splitExt.UsrQtyPicked);

        if (diff != 0 && Base.Transactions.Current != null){
            SOShipLineExt lineExt = Base.Transactions.Current.GetExtension<SOShipLineExt>();
            Base.Transactions.SetValueExt<SOShipLineExt.usrQtyPicked>(Base.Transactions.Current, (lineExt.UsrQtyPicked + diff));
        }
    }

    protected void SOShipLineSplit_RowDeleted(PXCache cache, PXRowDeletedEventArgs e){
        var row = (SOShipLineSplit) e.Row;
        SOShipLineSplitExt splitExt = row.GetExtension<SOShipLineSplitExt>();

        if (splitExt.UsrQtyPicked > 0 && Base.Transactions.Current != null){
            SOShipLineExt lineExt = Base.Transactions.Current.GetExtension<SOShipLineExt>();
            Base.Transactions.SetValueExt<SOShipLineExt.usrQtyPicked>(Base.Transactions.Current, (lineExt.UsrQtyPicked - splitExt.UsrQtyPicked));
            //Base.Transactions.Update(Base.Transactions.Current);
        }
    }

    protected void SOShipLine_UsrQtyPicked_FieldVerifying(PXCache cache, PXFieldVerifyingEventArgs e){
      
      var row = (SOShipLine) e.Row;
      var qty = (decimal) e.NewValue;

      if (qty > row.ShippedQty)
        throw new PXSetPropertyException("Picked quantity must be less or equal to the shipped quantity.");
      
    }

    #endregion
  }
}