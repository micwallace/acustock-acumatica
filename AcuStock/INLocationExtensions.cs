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
    #region UsrZone
    [PXDBString(32)]
    [PXUIField(DisplayName="Zone")]

    public virtual string UsrZone { get; set; }
    public abstract class usrZone : IBqlField { }
    #endregion

    #region UsrPickingOrder
    [PXDBInt]
[PXUIField(DisplayName="Picking Order")]
    public virtual int? UsrPickingOrder { get; set; }
    public abstract class usrPickingOrder : IBqlField { }
    #endregion
  }
}