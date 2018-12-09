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
    #region UsrASPickStatus
    [PXDBString(2)]
    [PXUIField(DisplayName="Pick Status")]
    [PXDefault(TypeCode.String, "1", PersistingCheck = PXPersistingCheck.Nothing)]
    [PXStringList(new string[] {"1","2","3","4","5","6"}, new string[] {"Open","Assigned","Partial","Picked","Packed","Shipped"})]
    public virtual string UsrASPickStatus { get; set; }
    public abstract class usrASPickStatus : IBqlField { }
    #endregion

    #region UsrASPickDevice
    [PXDBString(66)]
    [PXUIField(DisplayName="Pick Device")]

    public virtual string UsrASPickDevice { get; set; }
    public abstract class usrASPickDevice : IBqlField { }
    #endregion
  }
}