namespace Nencer.Modules.Product.Model
{
    public class ProductBidsModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int? SupplierId { get; set; }

        public string? SupplierName { get; set; }

        public string? Code { get; set; }

        public string? Name { get; set; }

        public string? BidNumber { get; set; }

        public string? BidGroup { get; set; }

        public string? BidPackage { get; set; }

        public DateTime? BidDate { get; set; }

        public string? BidYear { get; set; }

        public string? Description { get; set; }

        public int? Status { get; set; }

        public string? CreatorId { get; set; }

        public string? UpdaterId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int TotalCount { get; set; }
    }
}
