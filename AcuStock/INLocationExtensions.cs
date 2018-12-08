using PX.Data.ReferentialIntegrity.Attributes;
using PX.Data;
using PX.Objects.CS;
using PX.Objects.IN;
using PX.Objects;
using System.Collections.Generic;
using System;

namespace PX.Objects.IN
{
  public class INLocationExt : PXCacheExtension<PX.Objects.IN.INLocation>
  {
    #region UsrASZone
    [PXDBString(32)]
    [PXUIField(DisplayName="Zone")]

    public virtual string UsrASZone { get; set; }
    public abstract class usrASZone : IBqlField { }
    #endregion

    #region UsrASPickingOrder
    [PXDBInt]
    [PXUIField(DisplayName="Picking Order")]
    public virtual int? UsrASPickingOrder { get; set; }
    public abstract class usrASPickingOrder : IBqlField { }
    #endregion
  }
}