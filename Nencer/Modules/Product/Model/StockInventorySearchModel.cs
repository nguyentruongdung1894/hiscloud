﻿namespace Nencer.Modules.Product.Model
{
    public class StockInventorySearchModel
    {
        public int? StockId { get; set; }

        public int SkipCount { get; set; } = 0;

        public int MaxResultCount { get; set; } = 10;
    }
}
