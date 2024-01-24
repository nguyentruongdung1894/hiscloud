namespace Nencer.Modules.Product.Model
{
    public class ProductModel
    {
        public int ID { get; set; }

        public string? Sku { get; set; }

        public string? Name { get; set; }

        public string? Barcode { get; set; }

        public string? CatId { get; set; }

        public string? LotCode { get; set; }

        public string? ActiveIngredient { get; set; }

        public string? Concentration { get; set; }

        public string? Content { get; set; }

        public string? Usage { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public int? Qty { get; set; }

        public string? CountryCode { get; set; }

        public string? Manufacturer { get; set; }

        public string? RegistrationNumber { get; set; }

        public string? Packing { get; set; }

        public string? Unit { get; set; }

        public decimal? PriceInput { get; set; }

        public decimal? TaxRate { get; set; }

        public decimal? Price { get; set; }

        public decimal? TotalAmount { get; set; }

        public decimal? PriceRequest { get; set; }

        public string? BidGroup { get; set; }

        public string? BidNumber { get; set; }

        public string? BidYear { get; set; }

        public int? BidId { get; set; }

        public decimal? PriceIns { get; set; }

        public string? Description { get; set; }

        public string? UsageIns { get; set; }

        public string? Status { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int TotalCount { get; set; }
    }
}
