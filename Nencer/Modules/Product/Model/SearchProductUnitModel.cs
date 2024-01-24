namespace Nencer.Modules.Product.Model
{
    public class SearchProductUnitModel
    {
        public string? Name { get; set; }

        public int SkipCount { get; set; } = 0;

        public int MaxResultCount { get; set; } = 10;
    }
}
