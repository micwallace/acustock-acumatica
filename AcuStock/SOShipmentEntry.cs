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

      PXUIFieldAttribute.SetEnabled<SOShipLineExt.usrASQtyPicked>(cache, e.Row, (row.LocationID > 0));

    }  

    protected void SOShipLine_UsrASQtyPicked_FieldUpdated(PXCache cache, PXFieldUpdatedEventArgs e){
      
      if (!e.ExternalCall) return;
      
      var row = (SOShipLine) e.Row;
      
      var rowExt = row.GetExtension<SOShipLineExt>();
      
      decimal? qty = rowExt.UsrASQtyPicked;

      foreach (SOShipLineSplit split in Base.splits.Select()){
        
        decimal? pickQty = qty < split.Qty ? qty : split.Qty;
        
        qty -= pickQty;

        Base.splits.Cache.SetValue<SOTableShipLineSplitExt.usrASQtyPicked>(split, pickQty);
        Base.splits.Cache.SetValue<SOShipLineSplitExt.usrASQtyPicked>(split, pickQty);
        Base.splits.Cache.SetStatus(split, PXEntryStatus.Modified);
        Base.splits.Cache.IsDirty = true;
        
      }

    }

    protected void SOShipLine_UsrASQtyPicked_FieldDefaulting(PXCache cache, PXFieldDefaultingEventArgs e){
        e.NewValue = 0;
    }

    protected void SOShipLineSplit_UsrASQtyPicked_FieldVerifying(PXCache cache, PXFieldVerifyingEventArgs e){
      
      var row = (SOShipLineSplit) e.Row;
      var qty = (decimal) e.NewValue;

      if (qty > row.Qty)
        throw new PXSetPropertyException("Picked quantity must be less or equal to the allocated quantity.");
      
    }

    /*protected void SOShipLineSplit_RowInserted(PXCache cache, PXRowInsertedEventArgs e){
        var row = (SOShipLineSplit) e.Row;
        SOShipLineSplitExt splitExt = row.GetExtension<SOShipLineSplitExt>();

        if (splitExt.UsrASQtyPicked > 0 && Base.Transactions.Current != null){
            SOShipLineExt lineExt = Base.Transactions.Current.GetExtension<SOShipLineExt>();
            Base.Transactions.Cache.SetValue<SOShipLineExt.usrASQtyPicked>(Base.Transactions.Current, (lineExt.UsrASQtyPicked + splitExt.UsrASQtyPicked));
        }
    }*/

    protected void SOShipLineSplit_UsrASQtyPicked_FieldDefaulting(PXCache cache, PXFieldDefaultingEventArgs e){
        e.NewValue = 0;
    }

    protected void SOShipLineSplit_UsrASQtyPicked_FieldUpdated(PXCache cache, PXFieldUpdatedEventArgs e){
        var row = (SOShipLineSplit) e.Row;

        //if (cache.GetStatus(row) == PXEntryStatus.Inserted)
            //return;

        SOShipLineSplitExt splitExt = row.GetExtension<SOShipLineSplitExt>();
        decimal? diff = splitExt.UsrASQtyPicked - ((decimal) e.OldValue);

        PXTrace.WriteInformation("Field updated, old value: " + ((decimal)e.OldValue) + " new: " + splitExt.UsrASQtyPicked);

        //cache.SetValue<SOTableShipLineSplitExt.usrASQtyPicked>(row, splitExt.UsrASQtyPicked);

        if (diff != 0 && Base.Transactions.Current != null){
            SOShipLineExt lineExt = Base.Transactions.Current.GetExtension<SOShipLineExt>();
            Base.Transactions.Cache.SetValue<SOShipLineExt.usrASQtyPicked>(Base.Transactions.Current, (lineExt.UsrASQtyPicked + diff));
        }
    }

     /*protected void SOShipLineSplit_RowUpdated(PXCache cache, PXRowUpdatedEventArgs e){

        var row = (SOShipLineSplit) e.Row;
        SOShipLineSplitExt splitExt = row.GetExtension<SOShipLineSplitExt>();

        var oldRow = (SOShipLineSplit) e.Row;
        SOShipLineSplitExt oldSplitExt = row.GetExtension<SOShipLineSplitExt>();

        decimal? diff = splitExt.UsrASQtyPicked - oldSplitExt.UsrASQtyPicked;

        PXTrace.WriteInformation("Field updated, old value: " + oldSplitExt.UsrASQtyPicked + " new: " + splitExt.UsrASQtyPicked);

        if (diff != 0 && Base.Transactions.Current != null){
            SOShipLineExt lineExt = Base.Transactions.Current.GetExtension<SOShipLineExt>();
            Base.Transactions.SetValueExt<SOShipLineExt.usrASQtyPicked>(Base.Transactions.Current, (lineExt.UsrASQtyPicked + diff));
        }
    }*/

    protected void SOShipLineSplit_RowDeleted(PXCache cache, PXRowDeletedEventArgs e){
        var row = (SOShipLineSplit) e.Row;
        SOShipLineSplitExt splitExt = row.GetExtension<SOShipLineSplitExt>();

        if (splitExt.UsrASQtyPicked > 0 && Base.Transactions.Current != null){
            SOShipLineExt lineExt = Base.Transactions.Current.GetExtension<SOShipLineExt>();
            Base.Transactions.Cache.SetValue<SOShipLineExt.usrASQtyPicked>(Base.Transactions.Current, (lineExt.UsrASQtyPicked - splitExt.UsrASQtyPicked));
            //Base.Transactions.Update(Base.Transactions.Current);
        }
    }

    protected void SOShipLine_UsrASQtyPicked_FieldVerifying(PXCache cache, PXFieldVerifyingEventArgs e){
      
      var row = (SOShipLine) e.Row;
      var qty = (decimal) e.NewValue;

      if (qty > row.ShippedQty)
        throw new PXSetPropertyException("Picked quantity must be less or equal to the shipped quantity.");
      
    }

    #endregion
  }
}