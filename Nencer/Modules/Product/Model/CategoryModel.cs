namespace Nencer.Modules.Product.Model
{
    public class CategoryModel
    {
        public int ID { get; set; }

        public string? Slug { get; set; }

        public string? Name { get; set; }

        public string? Area { get; set; }

        public string? Description { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int TotalCount { get; set; }
    }
}
