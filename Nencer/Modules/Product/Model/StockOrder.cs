using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Product.Model
{
    [Table("product_stock_orders")]
    public partial class StockOrder
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("code")]
        public string? Code { get; set; }

        [Column("type")]
        public int? Type { get; set; }

        [Column("supplier_id")]
        public int? SupplierId { get; set; }

        [Column("bid_id")]
        public int? BidId { get; set; }

        [Column("bid_number")]
        public string? BidNumber { get; set; }

        [Column("bid_group")]
        public string? BidGroup { get; set; }

        [Column("bid_package")]
        public string? BidPackage { get; set; }

        [Column("bid_date")]
        public DateTime? BidDate { get; set; }

        [Column("bid_year")]
        public string? BidYear { get; set; }

        [Column("bills_number")]
        public string? BillsNumber { get; set; }

        [Column("stock_id")]
        public int? StockId { get; set; }

        [Column("target_stock_id")]
        public int? TargetStockId { get; set; }

        [Column("department_id")]
        public int? DepartmentId { get; set; }

        [Column("room_id")]
        public int? RoomId { get; set; }

        [Column("customer_id")]
        public int? CustomerId { get; set; }

        [Column("group")]
        public string? Group { get; set; }

        [Column("barcode")]
        public string? Barcode { get; set; }

        [Column("package_code")]
        public string? PackageCode { get; set; }

        [Column("batch_code")]
        public string? BatchCode { get; set; }

        [Column("customer_type")]
        public string? CustomerType { get; set; }

        [Column("price")]
        public decimal? Price { get; set; }

        [Column("tax_amount")]
        public decimal? TaxAmount { get; set; }

        [Column("tax_rate")]
        public decimal? TaxRate { get; set; }

        [Column("pay_amount")]
        public decimal? PayAmount { get; set; }

        [Column("currency_code")]
        public string? CurrencyCode { get; set; }

        [Column("approve_id")]
        public int? ApproveId { get; set; }

        [Column("approve_date")]
        public DateTime? ApproveDate { get; set; }

        [Column("export_date")]
        public DateTime? ExportDate { get; set; }

        [Column("import_date")]
        public DateTime? ImportDate { get; set; }

        [Column("note")]
        public string? Note { get; set; }

        [Column("reason")]
        public string? Reason { get; set; }

        [Column("status")]
        public int? Status { get; set; }

        [Column("creator_id")]
        public int? CreatorId { get; set; }

        [Column("creator_name")]
        public string? CreatorName { get; set; }

        [Column("updater_id")]
        public string? UpdaterId { get; set; }

        [Column("require_payment")]
        public int? RequirePayment { get; set; }

        [Column("payment_status")]
        public string? PaymentStatus { get; set; }

        [Column("receiver")]
        public string? Receiver { get; set; }

        [Column("deliver")]
        public string? Deliver { get; set; }

        [Column("order_date")]
        public DateTime? OrderDate { get; set; }

        [Column("paygate_id")]
        public int? PaygateId { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("is_del")]
        public int? IsDel { get; set; }
    }
}
