namespace Nencer.Modules.Product.Model
{
    public class ApproveInventorySearchModel
    {
        public int StockOdersId { get; set; }

        public int SkipCount { get; set; } = 0;

        public int MaxResultCount { get; set; } = 10;
    }
}
