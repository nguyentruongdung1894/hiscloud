namespace Nencer.Modules.Product.Model
{
    public class SearchProductModel
    {
        public string? Sku { get; set; }

        public int SkipCount { get; set; } = 0;

        public int MaxResultCount { get; set; } = 10;
    }
}
