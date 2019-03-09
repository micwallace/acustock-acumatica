using System;
using PX.Data;
using PX.Objects;
using PX.Objects.IN;

namespace AcuStock
{
  public class InventoryLocations : PXGraph<InventoryLocations, INLocationStatus>
  {

    public PXSelectJoin<INLocationStatus,
                LeftJoin<InventoryItem,
                    On<INLocationStatus.inventoryID, Equal<InventoryItem.inventoryID>>,
                      LeftJoin<INLocation,
                        On<INLocationStatus.locationID, Equal<INLocation.locationID>>,
                          LeftJoin<INSite,
                            On<INLocationStatus.siteID, Equal<INSite.siteID>>
                        >
                    >
                >
           > Locations;
    
     public PXSelectJoin<INLotSerialStatus,
              LeftJoin<InventoryItem,
                On<INLotSerialStatus.inventoryID, Equal<InventoryItem.inventoryID>>,
                LeftJoin<INLocation,
                  On<INLotSerialStatus.locationID, Equal<INLocation.locationID>>,
                LeftJoin<INSite,
                  On<INLotSerialStatus.siteID, Equal<INSite.siteID>>>
              >>,
              Where<INLocation.locationID, Equal<Current<INLocationStatus.locationID>>,
                 And<InventoryItem.inventoryID, Equal<Current<INLocationStatus.inventoryID>>>>
         > LotSerialDetails;

  }
}