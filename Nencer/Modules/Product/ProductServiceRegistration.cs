using Nencer.Modules.Product.Repository;

namespace Nencer.Modules.Product
{
    public class ProductServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IProductCateRepository, ProductCateRepository>();
            services.AddScoped<IStockOrderRepository, StockOrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IProductSupplierRepository, ProductSupplierRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IProductOrderRepository, ProductOrderRepository>();
            services.AddScoped<IProductBidRepository, ProductBidRepository>();
        }
    }
}
