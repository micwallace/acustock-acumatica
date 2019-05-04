using POReceiptLine = PX.Objects.PO.POReceiptLine;
using PX.Data.ReferentialIntegrity.Attributes;
using PX.Data;
using PX.Objects.AR;
using PX.Objects.CM;
using PX.Objects.Common;
using PX.Objects.CS;
using PX.Objects.IN;
using PX.Objects.SO;
using PX.Objects;
using System.Collections.Generic;
using System;

namespace PX.Objects.SO
{
  public class SOShipLineExt : PXCacheExtension<PX.Objects.SO.SOShipLine>
  {
    #region UsrASQtyPicked
    [PXDBDecimal]
    [PXDefault(TypeCode.Decimal, "0.0", PersistingCheck = PXPersistingCheck.Nothing)]
    [PXUIField(DisplayName="Picked Qty.", Enabled=false)]

    public virtual Decimal? UsrASQtyPicked { get; set; }
    public abstract class usrASQtyPicked : IBqlField { }
    #endregion

    #region InventoryType
	[PXString(1, IsFixed = true)]
	[PXFormula(typeof(Selector<SOShipLine.inventoryID, InventoryItem.itemType>))]
    [INItemTypes.List()]
    [PXUIField(DisplayName="Item Type", Enabled=false, Visible=false)]
    public virtual String InventoryType { get; set; }
    public abstract class inventoryType : IBqlField { }
    #endregion
  }
}