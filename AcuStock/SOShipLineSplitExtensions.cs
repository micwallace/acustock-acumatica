using PX.Data;
using PX.Objects.CS;
using PX.Objects.GL;
using PX.Objects.IN;
using PX.Objects.SO;
using PX.Objects;
using System.Collections.Generic;
using System;

namespace PX.Objects.SO
{
  public class SOShipLineSplitExt : PXCacheExtension<PX.Objects.SO.SOShipLineSplit>
  {
    #region UsrASQtyPicked
    [PXDBDecimal]
    [PXDefault(TypeCode.Decimal, "0.0", PersistingCheck = PXPersistingCheck.Nothing)]
    [PXUIField(DisplayName="Picked Qty.")]
    public virtual Decimal? UsrASQtyPicked { get; set; }
    public abstract class usrASQtyPicked : IBqlField { }
    #endregion
  }
      
  public class SOTableShipLineSplitExt : PXCacheExtension<PX.Objects.SO.Table.SOShipLineSplit>
  {
    #region UsrASQtyPicked
    [PXDBDecimal]
    [PXDefault(TypeCode.Decimal, "0.0", PersistingCheck = PXPersistingCheck.Nothing)]
    [PXUIField(DisplayName="Picked Qty.")]
    public virtual Decimal? UsrASQtyPicked { get; set; }
    public abstract class usrASQtyPicked : IBqlField { }
    #endregion
  }
}