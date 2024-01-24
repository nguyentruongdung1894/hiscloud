using System.ComponentModel.DataAnnotations.Schema;
namespace Nencer.Modules.Backend.Model.Slider
{
    [Table("sliders")]
    public partial class Slider
    {
        public long Id { set; get; }
        [Column("slider_name")]
        public string SliderName { set; get; } = null!;
        [Column("slider_image")]
        public string? SliderImage { set; get; }
        [Column("slider_text")]
        public string? SliderText { set; get; }
        [Column("slider_url")]
        public string? SliderUrl { set; get; }
        [Column("slider_btn_text")]
        public string? SliderBtnText { set; get; }
        [Column("slider_btn_url")]
        public string? SliderBtnUrl { set; get; }
        [Column("sort_order")]
        public int? SortOrder { set; get; }
        public int? Status { set; get; }
        public int? App { set; get; }
        public string? Lang { set; get; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
