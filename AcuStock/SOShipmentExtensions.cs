using CRLocation = PX.Objects.CR.Standalone.Location;
using POReceipt = PX.Objects.PO.POReceipt;
using PX.Data.ReferentialIntegrity.Attributes;
using PX.Data;
using PX.Objects.AR;
using PX.Objects.CM;
using PX.Objects.CR;
using PX.Objects.CS;
using PX.Objects.IN;
using PX.Objects.SO;
using PX.Objects;
using System.Collections.Generic;
using System;

namespace PX.Objects.SO
{
  public class SOShipmentExt : PXCacheExtension<PX.Objects.SO.SOShipment>
  {
    #region UsrPickStatus
    [PXDBString(2)]
    [PXUIField(DisplayName="Pick Status")]
    [PXDefault(TypeCode.String, "1")]
    [PXUnboundDefault("1", PersistingCheck = PXPersistingCheck.Nothing)]
    [PXStringList(new string[] {"1","2","3","4","5","6"}, new string[] {"Open","Pick in Progress","Partially Picked","Picked","Packed","Shipped"})]
    public virtual string UsrPickStatus { get; set; }
    public abstract class usrPickStatus : IBqlField { }
    #endregion

    #region UsrPickedBy
    [PXDBString(66)]
    [PXUIField(DisplayName="Picked By")]

    public virtual string UsrPickedBy { get; set; }
    public abstract class usrPickedBy : IBqlField { }
    #endregion
  }
}