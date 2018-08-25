
using PX.Data;

namespace PX.Objects.IN
{
  public class INReceiptEntry_Extension : PXGraphExtension<INReceiptEntry>
  {
    #region Event Handlers
    protected virtual void INRegister_TransferNbr_FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e, PXFieldUpdated baseMethod) {
        if (sender.Graph.IsImport == true)
          return;

        baseMethod(sender, e);
    }
    #endregion
  }
}