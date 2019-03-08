using System;
using PX.Data;
using PX.Objects;
using PX.Objects.IN;

namespace AcuStock
{
  public class InventoryLotSerials : PXGraph<InventoryLotSerials, INLotSerialStatus>
  {

    public PXFilter<InventoryFilter> Filter;

    public PXSelectReadonly2<INLotSerialStatus,
                LeftJoin<InventoryItem,
                    On<INLotSerialStatus.inventoryID, Equal<InventoryItem.inventoryID>>,
                        LeftJoin<INLocation,
                        On<INLotSerialStatus.locationID, Equal<INLocation.locationID>>,
                            LeftJoin<INSite,
                            On<INLotSerialStatus.siteID, Equal<INSite.siteID>>
                        >
                    >
                >,
                Where2<Where<Current<InventoryFilter.siteID>, IsNull, Or<INLotSerialStatus.siteID, Equal<Current<InventoryFilter.siteID>>>>,
                        And2<Where<Current<InventoryFilter.locationID>, IsNull, Or<INLotSerialStatus.locationID, Equal<Current<InventoryFilter.locationID>>>>,
                            And<Where<Current<InventoryFilter.inventoryID>, IsNull, Or<INLotSerialStatus.inventoryID, Equal<Current<InventoryFilter.inventoryID>>>>>
                        >
                >
            > LotSerials;

    [Serializable]
    public class InventoryFilter : IBqlTable
    {

        #region SiteID
        public abstract class siteID : PX.Data.IBqlField
        {
        }
        protected Int32? _SiteID;
        [PXUIField(DisplayName = "Warehouse")]
        [Site(DescriptionField = typeof(INSite.descr), DisplayName = "Warehouse")]
        public virtual Int32? SiteID
        {
            get
            {
                return this._SiteID;
            }
            set
            {
                this._SiteID = value;
            }
        }
        #endregion

        #region LocationID
        public abstract class locationID : PX.Data.IBqlField
        {
        }
        protected Int32? _LocationID;
        [Location(typeof(InventoryFilter.siteID), KeepEntry = false, DescriptionField = typeof(INLocation.descr), DisplayName = "Location")]
        public virtual Int32? LocationID
        {
            get
            {
                return this._LocationID;
            }
            set
            {
                this._LocationID = value;
            }
        }
        #endregion

        #region InventoryID
        public abstract class inventoryID : PX.Data.IBqlField
        {
        }
        protected Int32? _InventoryID;
        [Inventory()]
        [PXUIField(DisplayName = "Inventory ID")]
        public virtual Int32? InventoryID
        {
            get
            {
                return this._InventoryID;
            }
            set
            {
                this._InventoryID = value;
            }
        }
        #endregion

    }

  }
}