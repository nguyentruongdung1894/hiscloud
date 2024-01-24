using Microsoft.AspNetCore.Mvc;
using Nencer.Modules.Product.Model;
using Nencer.Modules.Product.Repository;
using Nencer.Shared;

namespace Nencer.Modules.Product.Controller;
[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductCateRepository _productCateRepository;
    private readonly IProductRepository _productRepository;
    private readonly IProductSupplierRepository _productSupplierRepository;
    private readonly IProductOrderRepository _productOrderRepository;
    private readonly IProductBidRepository _productBidRepository;
    public ProductController(IProductCateRepository productCateRepository, IProductRepository productRepository, IProductSupplierRepository productSupplierRepository, IProductOrderRepository productOrderRepository, IProductBidRepository productBidRepository)
    {
        _productCateRepository = productCateRepository;
        _productRepository = productRepository;
        _productSupplierRepository = productSupplierRepository;
        _productOrderRepository = productOrderRepository;
        _productBidRepository = productBidRepository;
    }
    // start Product Cate
    [HttpPost("Cate/List")]
    public async Task<List<CategoryModel>> GetAllProductCate(SearchCategoryModel searchModel)
    {
        return await _productCateRepository.GetAllProductCate(searchModel);
    }

    [HttpGet("Cate/Find/{categoryID}")]
    public async Task<ProductCate> FindProductCate(long categoryID)
    {
        return await _productCateRepository.FindProductCate(categoryID);
    }

    [HttpPost("Cate/Create")]
    public async Task<BaseResponse<ProductCate>> CreateProductCate(ProductCate productCate)
    {
        return await _productCateRepository.CreateProductCate(productCate);
    }

    [HttpPost("Cate/Update")]
    public async Task<BaseResponse<ProductCate>> UpdateProductCate(ProductCate productCate)
    {
        return await _productCateRepository.UpdateProductCate(productCate);
    }

    [HttpDelete("Cate/Delete/{id}")]
    public async Task<BaseResponse<ProductCate>> DeleteProductCate(int Id)
    {
        return await _productCateRepository.DeleteProductCate(Id);
    }
    //end ProductCate

    // Product
    [HttpPost("GetAll")]
    public async Task<List<ProductModel>> GetAllProductAsync(SearchProductModel searchModel)
    {
        return await _productRepository.GetAllProductAsync(searchModel);
    }

    // Product
    [HttpGet("GetAllProductByStockId/{stockId}")]
    public async Task<List<ProductModel>> GetAllProductByStockIdAsync(int stockId)
    {
        return await _productRepository.GetAllProductByStockIdAsync(stockId);
    }

    // Product
    [HttpGet("GetAllProductByStockIdAndSupplierId/{stockId}/{supplierId}")]
    public async Task<List<ProductModel>> GetAllProductByStockIdAndSupplierIdAsync(int stockId, int supplierId)
    {
        return await _productRepository.GetAllProductByStockIdAndSupplierIdAsync(stockId, supplierId);
    }

    [HttpGet("GetProductByCate/{cat_id}")]
    public async Task<BaseResponse<List<Model.Product>>> GetProductByCateAsync(int cat_id, int? page = 0, int? pageSize = 20)
    {
        if (page >= 1)
        {
            page = (page - 1) * pageSize;
        }
        var item = await _productRepository.GetProductByCateAsync(cat_id, page.GetValueOrDefault(), pageSize.GetValueOrDefault());
        return new BaseResponse<List<Model.Product>>
        {
            ResponseCode = "200",
            Message = "",
            Data = item
        };
    }

    [HttpGet("Find/{productID}")]
    public async Task<Model.Product> FindProductAsync(int productID)
    {
        return await _productRepository.FindProductAsync(productID);
    }

    [HttpGet("FindByInventorieId/{productID}")]
    public async Task<ProductModel> FindByInventorieIdAsync(int productID)
    {
        return await _productRepository.FindByInventorieId(productID);
    }

    [HttpDelete("Delete/{id}")]
    public async Task<BaseResponse<Model.Product>> DeleteProductAsync(int Id)
    {
        return await _productRepository.DeleteProductAsync(Id);
    }

    [HttpPost("Create")]
    public async Task<BaseResponse<Model.Product>> CreateProductAsync(Model.Product request)
    {
        return await _productRepository.CreateProductAsync(request);
    }

    [HttpPost("Update")]
    public async Task<BaseResponse<Model.Product>> UpdateProductAsync(Model.Product request)
    {
        return await _productRepository.UpdateProductAsync(request);
    }

    //End Product
    // start Supplier
    [HttpPost("Supplier/List")]
    public async Task<List<SupplierModel>> GetAllProductSupplier(SearchSupplierModel searchModel)
    {
        return await _productSupplierRepository.GetAllProductSupplier(searchModel);
    }

    [HttpGet("Supplier/Find/{supplierID}")]
    public async Task<ProductSupplier> FindProductSupplier(long supplierID)
    {
        return await _productSupplierRepository.FindProductSupplier(supplierID);
    }

    [HttpPost("Supplier/Create")]
    public async Task<BaseResponse<ProductSupplier>> CreateProductSupplier(ProductSupplier req)
    {
        return await _productSupplierRepository.CreateProductSupplier(req);
    }

    [HttpPost("Supplier/Update")]
    public async Task<BaseResponse<ProductSupplier>> UpdateProductSupplier(ProductSupplier req)
    {
        return await _productSupplierRepository.UpdateProductSupplier(req);
    }

    [HttpDelete("Supplier/Delete/{id}")]
    public async Task<BaseResponse<ProductSupplier>> DeleteProductSupplier(int Id)
    {
        return await _productSupplierRepository.DeleteProductSupplier(Id);
    }
    //end Supplier
    //order
    [HttpDelete("GetOrder/{id}")]
    public async Task<BaseResponse<ProductOrderResult>> FindProductOrder(int Id)
    {
        return await _productOrderRepository.FindProductOrder(Id);
    }

    [HttpPost("ProductBid/GetAll")]
    public async Task<List<ProductBidsModel>> GetAllProductBidAsync(ProductBidsSearchModel searchModel)
    {
        return await _productBidRepository.GetAllProductBidAsync(searchModel);
    }

    [HttpPost("ProductBid/Create")]
    public async Task<BaseResponse<ProductBid>> CreateProductBid(ProductBid req)
    {
        return await _productBidRepository.CreateProductBid(req);
    }
}
