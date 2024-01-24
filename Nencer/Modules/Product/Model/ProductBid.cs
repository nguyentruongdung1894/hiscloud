using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Product.Model
{
    [Table("product_bids")]
    public partial class ProductBid
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("supplier_id")]
        public int? SupplierId { get; set; }

        [Column("code")]
        public string? Code { get; set; }

        [Column("name")]
        public string? Name { get; set; }

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

        [Column("description")]
        public string? Description { get; set; }

        [Column("status")]
        public int? Status { get; set; }

        [Column("creator_id")]
        public string? CreatorId { get; set; }

        [Column("updater_id")]
        public string? UpdaterId { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [NotMapped]
        public List<ProductBidsItem> Items { get; set; }
    }
}
