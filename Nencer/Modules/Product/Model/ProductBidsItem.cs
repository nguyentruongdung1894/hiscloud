using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Product.Model
{
    [Table("product_bid_items")]
    public class ProductBidsItem
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("bid_id")]
        public int BidId { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("vat")]
        public decimal Vat { get; set; }

        [Column("unit")]
        public string Unit { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("price_ins")]
        public decimal PriceIns { get; set; }

        [Column("status")]
        public int Status { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
