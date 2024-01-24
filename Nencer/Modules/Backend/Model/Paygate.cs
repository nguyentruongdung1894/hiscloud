using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Backend.Model
{
    
    public class Paygate
    {
        public long Id { get; set; }

        [Column("currency_code")]
        public string CurrencyCode { get; set; } = null!;

        public string Code { get; set; } = null!;
        [Column("paygate_group")]
        public string? PaygateGroup { get; set; }

        public string Name { get; set; } = null!;

        public float? Balance { get; set; }

        public string? Type { get; set; }

        public short Withdraw { get; set; }

        [Column("withdraw_field")]
        public string? WithdrawField { get; set; }

        public short Deposit { get; set; }

        public short Payment { get; set; }

        public short? Round { get; set; }

        public string? Avatar { get; set; }

        public string? Configs { get; set; }

        public short Status { get; set; }

        [Column("mid_bank")]
        public string? MidBank { get; set; }

        [Column("qr_bank")]
        public string? QrBank { get; set; }

        [Column("input_fixed")]
        public string? InputFixed { get; set; }

        [Column("input_percent")]
        public string? InputPercent { get; set; }

        [Column("output_fixed")]
        public string? OutputFixed { get; set; }

        [Column("output_percent")]
        public string? OutputPercent { get; set; }

        [Column("allow_groups")]
        public string? AllowGroups { get; set; }

        [Column("deposit_paygate")]
        public string? DepositPaygate { get; set; }

        [Column("withdraw_paygate")]
        public string? WithdrawPaygate { get; set; }

        public int? Sort { get; set; }

        [Column("cancel_time")]
        public int? CancelTime { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

    }
}
