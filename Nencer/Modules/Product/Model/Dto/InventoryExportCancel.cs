namespace Nencer.Modules.Product.Model.Dto
{
    public partial class InventoryExportCancel
    {
        public int StockId { get; set; }
        public string Reason { get; set; }
        public int? Status { get; set; }
        public string? Note { get; set; }
        public int? Supplier_id { get; set; }
        public string? Receiver { get; set; }
        public List<InventoryExportCancelItem> Items { get; set; }
    }
    public class InventoryExportCancelItem
    {
        public int InventoryId { get; set; }
        public int Qty { get; set; }
        public string Unit { get; set; }
    }
}
