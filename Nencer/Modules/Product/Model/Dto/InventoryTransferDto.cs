namespace Nencer.Modules.Product.Model.Dto
{
    public partial class InventoryTransferDto
    {
        public int StockId { get; set; }
        public int TargetStockId { get; set; }
        public int? Status { get; set; }
        public string? Note { get; set; }
        public List<InventoryTransferDtoItems> Items { get; set; }

    }
    public class InventoryTransferDtoItems
    {
        public int InventoryId { get; set; }
        public int Qty { get; set; }
        public string Unit { get; set; }
        public string? PackageCode { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public Decimal? Price { get; set; }
        public string? BidNumber { get; set; }
    }

}
