using System;
using System.Collections;
using PX.Data;
using PX.Objects.IN;

namespace AcuStock
{
  public class InventoryLookup : PXGraph<InventoryLookup>
  {

    public PXFilter<FilterParams> Filter;

    [PXFilterable]
    public PXSelectJoin<InventoryItem,
                            LeftJoin<INItemXRef, On<INItemXRef.inventoryID, Equal<InventoryItem.inventoryID>>>,
                            Where<InventoryItem.inventoryCD, Equal<Current<FilterParams.itemID>>, 
                                Or<INItemXRef.alternateID, Equal<Current<FilterParams.itemID>>>
                            >
                        > Items;

    [Serializable]
    public class FilterParams : IBqlTable {
        #region ItemID
        [PXString(32)]
        [PXUIField(DisplayName = "ID / Alternate ID")]
        public virtual string ItemID { get; set; }
        public abstract class itemID : IBqlField { }
        #endregion
    }

  }
}