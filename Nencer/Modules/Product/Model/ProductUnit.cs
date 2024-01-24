using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Product.Model
{
    [Table("product_units")]
    public partial class ProductUnit
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("key")]
        public string? Key { get; set; }

        [Column("type")]
        public string? Type { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("default")]
        public int? Default { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
