using Nencer.Modules.Product.Model;

namespace Nencer.Modules.Product.Repository
{
    public class ProductOrderResult
    {
        public StockOrder order { get; set; }
        public List<StockOrderItem> items { get; set; }
    }
}
