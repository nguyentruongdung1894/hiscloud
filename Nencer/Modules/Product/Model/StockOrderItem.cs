using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Product.Model
{
    [Table("product_stock_order_items")]
    public partial class StockOrderItem
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("stock_order_id")]
        public int? StockOrderId { get; set; }

        [Column("service_object")]
        public string? ServiceObject { get; set; }

        [Column("product_id")]
        public int? ProductId { get; set; }

        [Column("type")]
        public int? Type { get; set; }

        [Column("product_name")]
        public string? ProductName { get; set; }

        [Column("price_input")]
        public decimal? PriceInput { get; set; }

        [Column("price")]
        public decimal? Price { get; set; }

        [Column("qty")]
        public int? Qty { get; set; }

        [Column("benefit_rate")]
        public int? BenefitRate { get; set; }

        [Column("pay_amount")]
        public decimal? PayAmount { get; set; }

        [Column("total_amount")]
        public decimal? TotalAmount { get; set; }

        [Column("insurance_pay")]
        public decimal? InsurancePay { get; set; }

        [Column("copay_patient")]
        public decimal? CopayPatient { get; set; }

        [Column("patient_paid")]
        public decimal? PatientPaid { get; set; }

        [Column("patient_in_debt")]
        public decimal? PatientInDebt { get; set; }

        [Column("barcode")]
        public string? Barcode { get; set; }

        [Column("batch_code")]
        public string? BatchCode { get; set; }

        [Column("approve_qty")]
        public int? ApproveQty { get; set; }

        [Column("unit")]
        public string? Unit { get; set; }

        [Column("tax_amount")]
        public decimal? TaxAmount { get; set; }

        [Column("tax_rate")]
        public decimal? TaxRate { get; set; }

        [Column("currency_code")]
        public string? CurrencyCode { get; set; }

        [Column("approve_id")]
        public int? ApproveId { get; set; }

        [Column("approve_date")]
        public DateTime? ApproveDate { get; set; }

        [Column("creator_id")]
        public int? CreatorId { get; set; }

        [Column("status")]
        public int? Status { get; set; }

        [Column("invoice_id")]
        public long? InvoiceId { get; set; }

        [Column("bid_id")]
        public int? BidId { get; set; }

        [Column("inventory_id")]
        public int? InventoryId { get; set; }

        [Column("production_date")]
        public DateTime? ProductionDate { get; set; }

        [Column("expiration_date")]
        public DateTime? ExpirationDate { get; set; }

        [Column("lot_code")]
        public string? LotCode { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("payment_status")]
        public string? PaymentStatus { get; set; }
    }
}
