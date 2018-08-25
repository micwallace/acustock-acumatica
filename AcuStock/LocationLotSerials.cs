using System;
using PX.Data;
using PX.Objects;
using PX.Objects.IN;

namespace AcuStock
{
  public class LocationLotSerials : PXGraph<LocationLotSerials, INLotSerialStatus>
  {

    public PXSelectJoin<INLotSerialStatus,
                LeftJoin<InventoryItem,
                    On<INLotSerialStatus.inventoryID, Equal<InventoryItem.inventoryID>>,
                      LeftJoin<INLocation,
                        On<INLotSerialStatus.locationID, Equal<INLocation.locationID>>,
                          LeftJoin<INSite,
                            On<INLotSerialStatus.siteID, Equal<INSite.siteID>>
                        >
                    >
                >
           > InventoryLotSerials;

  }
}