namespace Nencer.Modules.Product.Model
{
    public class SupplierModel
    {
        public int ID { get; set; }

        public string? Code { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? ContactPhone { get; set; }

        public string? ContactEmail { get; set; }

        public string? Description { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int TotalCount { get; set; }
    }
}
