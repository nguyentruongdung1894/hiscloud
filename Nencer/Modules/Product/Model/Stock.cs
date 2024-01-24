using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Product.Model
{
    [Table("product_stocks")]
    public partial class Stock
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("code")]
        public string Code { get; set; }

        [Column("type")]
        public int Type { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("address")]
        public string? Address { get; set; }

        [Column("phone")]
        public string? Phone { get; set; }

        [Column("department_id")]
        public int? DepartmentId { get; set; }

        [Column("owner_id")]
        public string? OwnerId { get; set; }

        [Column("payment_require")]
        public int? PaymentRequire { get; set; }

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
