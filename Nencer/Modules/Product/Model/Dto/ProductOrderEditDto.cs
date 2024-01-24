namespace Nencer.Modules.Product.Model.Dto
{
    public class ProductOrderEditDto
    {
        public StockOrder order { get; set; }
        public List<StockOrderItem>? item { get; set; }
        public List<OrderItemNew>? itemNews { get; set; }
    }
    public class OrderItemNew
    {
        public int? ProductId { get; set; }
        public int? InventoryId { get; set; }
        public int Qty { get; set; }
        public string Unit { get; set; }
        public Decimal? PriceInput { get; set; }
        public Decimal? Tax { get; set; }
        public string? PackageCode { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public Decimal? Price { get; set; }
        public Decimal? PriceIns { get; set; }
        public Decimal? PriceRequest { get; set; }
        public string? BidNumber { get; set; }
        public string? BidGroup { get; set; }
        public string? BidPackage { get; set; }
        public string? BidYear { get; set; }
        public int? BidId { get; set; }
    }
}
