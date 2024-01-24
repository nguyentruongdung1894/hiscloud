using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Product.Model
{
    [Table("product_inventories")]
    public partial class Inventory
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("stock_id")]
        public int? StockId { get; set; }

        [Column("product_id")]
        public int? ProductId { get; set; }

        [Column("barcode")]
        public string? Barcode { get; set; }

        [Column("package_code")]
        public string? PackageCode { get; set; }

        [Column("product_name")]
        public string? ProductName { get; set; }

        [Column("supplier_id")]
        public int? SupplierId { get; set; }

        [Column("bid_id")]
        public int? BidId { get; set; }

        [Column("qty")]
        public int? Qty { get; set; }

        [Column("locked_qty")]
        public int? LockedQty { get; set; }

        [Column("certificate_code")]
        public string? CertificateCode { get; set; }

        [Column("production_date")]
        public DateTime? ProductionDate { get; set; }

        [Column("expiration_date")]
        public DateTime? ExpirationDate { get; set; }

        [Column("position")]
        public string? Position { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("status")]
        public int? Status { get; set; }

        [Column("creator_id")]
        public int? CreatorId { get; set; }

        [Column("updater_id")]
        public int? UpdaterId { get; set; }

        [Column("price_input")]
        public decimal? PriceInput { get; set; }

        [Column("price")]
        public decimal? Price { get; set; }

        [Column("price_request")]
        public decimal? PriceRequest { get; set; }

        [Column("price_ins")]
        public decimal? PriceIns { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
