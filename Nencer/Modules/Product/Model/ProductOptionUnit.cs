using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Product.Model
{
    [Table("product_option_unit")]
    public partial class ProductOptionUnit
    {
        public int Id { get; set; }
        [Column("product_id")] public int? ProductId {  get; set; }
        public string? Key {  get; set; }
        public string? Name {  get; set; }
        public int? Qty { get; set; }
        
    }
}
