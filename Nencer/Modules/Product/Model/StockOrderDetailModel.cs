namespace Nencer.Modules.Product.Model
{
    public class StockOrderDetailModel
    {
        public string? Name { get; set; }

        public string? Concentration { get; set; }

        public string? Content { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }

        public decimal? TotalPrice { get; set; }

        public string? LotCode { get; set; }

        public string? BidDecisionNumber { get; set; }

        public string? ContractorGroup { get; set; }

        public string? BidId { get; set; }

        public string? BidYear { get; set; }

        public int TotalCount { get; set; }
    }
}
