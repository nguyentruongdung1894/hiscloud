namespace Nencer.Modules.Product.Model
{
    public class SearchStockModel
    {
        public string? Code { get; set; }

        public string? Name { get; set; }

        public int SkipCount { get; set; } = 0;

        public int MaxResultCount { get; set; } = 10;
    }
}
