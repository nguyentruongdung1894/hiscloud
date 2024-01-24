namespace Nencer.Modules.Product.Model
{
    public class StockOdersModel
    {
        public int? Id { get; set; }

        public string? Code { get; set; }

        public int? Type { get; set; }

        public string? Coupon { get; set; }

        public string? Supplier { get; set; }

        public string? Stock { get; set; }

        public string? TargetStock { get; set; }

        public string? Status { get; set; }

        public DateTime? ImportDate { get; set; }

        public DateTime? ApproveDate { get; set; }

        public DateTime? ExportDate { get; set; }

        public string? DepartmentRoom { get; set; }

        public string? Name { get; set; }

        public string? Note { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int TotalCount { get; set; }
    }
}
