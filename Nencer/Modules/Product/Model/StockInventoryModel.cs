namespace Nencer.Modules.Product.Model
{
    public class StockInventoryModel
    {
        public int Id { get; set; }

        public int? StockId { get; set; }

        public string? StockName { get; set; }

        public int? ProductId { get; set; }

        public string? Barcode { get; set; }

        public string? PackageCode { get; set; }

        public string? ProductName { get; set; }

        public int? SupplierId { get; set; }

        public string? SupplierName { get; set; }

        public int? BidId { get; set; }

        public string? BidName { get; set; }

        public int? Qty { get; set; }

        public int? LockedQty { get; set; }

        public string? CertificateCode { get; set; }

        public DateTime? ProductionDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public string? Position { get; set; }

        public string? Description { get; set; }

        public int? Status { get; set; }

        public int? CreatorId { get; set; }

        public int? UpdaterId { get; set; }

        public decimal? PriceInput { get; set; }

        public decimal? Price { get; set; }

        public decimal? PriceRequest { get; set; }

        public decimal? PriceIns { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int TotalCount { get; set; }
    }
}
