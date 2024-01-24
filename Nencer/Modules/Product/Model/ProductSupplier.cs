using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Product.Model
{
    [Table("product_supplier")]
    public partial class ProductSupplier
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("code")]
        public string Code { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("address")]
        public string? Address { get; set; }

        [Column("contact_phone")]
        public string? ContactPhone { get; set; }

        [Column("contact_email")]
        public string? ContactEmail { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("status")]
        public int? Status { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
