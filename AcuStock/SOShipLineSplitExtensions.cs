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
    #region UsrQtyPicked
    [PXDBDecimal]
    [PXDefault(TypeCode.Decimal, "0.0")]
    [PXUIField(DisplayName="Picked Qty.")]
    //[PXFormula(null, typeof(SumCalc<SOShipLineExt.usrQtyPicked>))]
    public virtual Decimal? UsrQtyPicked { get; set; }
    public abstract class usrQtyPicked : IBqlField { }
    #endregion
  }
      
  public class SOTableShipLineSplitExt : PXCacheExtension<PX.Objects.SO.Table.SOShipLineSplit>
  {
    #region UsrQtyPicked
    [PXDBDecimal]
    [PXDefault(TypeCode.Decimal, "0.0")]
    [PXUIField(DisplayName="Picked Qty.")]
    //[PXFormula(null, typeof(SumCalc<SOShipLineExt.usrQtyPicked>))]
    public virtual Decimal? UsrQtyPicked { get; set; }
    public abstract class usrQtyPicked : IBqlField { }
    #endregion
  }
}