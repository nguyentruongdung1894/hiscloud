namespace Nencer.Modules.Product.Model
{
    public class StockModel
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public int? Type { get; set; }

        public string? TypeName { get; set; }

        public string Name { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public int? DepartmentId { get; set; }

        public string? DepartmentName { get; set; }

        public string? OwnerId { get; set; }

        public string? Description { get; set; }

        public int? PaymentRequire { get; set; }

        public int? Status { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int TotalCount { get; set; }
    }
}
