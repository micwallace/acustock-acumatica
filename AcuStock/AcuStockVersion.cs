using System;
using PX.Data;

namespace AcuStock
{
  public class AcuStockConfig : PXGraph<AcuStockConfig>
  {

    public PXFilter<ConfigTable> ConfigView;

    [Serializable]
    public class ConfigTable : IBqlTable
    {
      [PXString(16)]
      [PXUIField(DisplayName="Version")]
      [PXDefault(TypeCode.String, "1.2.1")]
      public virtual string Version { get; set; }
      public abstract class version : IBqlField { }
    }


  }
}