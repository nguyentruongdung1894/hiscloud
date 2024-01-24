using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Product.Model;
using Nencer.Modules.Product.Model.Dto;
using Nencer.Modules.Product.Repository;
using Nencer.Shared;

namespace Nencer.Modules.Product.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;
        private readonly IStockOrderRepository _stockOrderRepository;
        private readonly IUnitRepository _unitRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly NencerDbContext _context;
        public StockController(IStockRepository stockRepository, IStockOrderRepository stockOrderRepository, IUnitRepository unitRepository, IInventoryRepository inventoryRepository, NencerDbContext context)
        {
            _stockRepository = stockRepository;
            _stockOrderRepository = stockOrderRepository;
            _unitRepository = unitRepository;
            _inventoryRepository = inventoryRepository;
            _context = context;
        }
        [HttpPost("List")]
        public async Task<List<StockModel>> GetAllStockAync(SearchStockModel searchModel)
        {
            return await _stockRepository.GetAllStockAync(searchModel);
        }
        [HttpPost("StockOutput/List")]
        public async Task<List<StockModel>> GetAllStockOutputAync(SearchStockModel searchModel)
        {
            return await _stockRepository.GetAllStockOutputAync(searchModel);
        }
        [HttpGet("Stock/Find/{id}")]
        public async Task<Stock> FindStockAync(int Id)
        {
            return await _stockRepository.FindStockAync(Id);
        }
        [HttpPost("Stock/Create")]
        public async Task<BaseResponse<Stock>> CreateProductCate(Stock stock)
        {
            return await _stockRepository.CreateStockAync(stock);
        }
        [HttpPost("Stock/Update")]
        public async Task<BaseResponse<Stock>> UpdateStockAync(Stock stock)
        {
            return await _stockRepository.UpdateStockAync(stock);
        }
        [HttpDelete("Stock/Delete/{id}")]
        public async Task<BaseResponse<Stock>> DeleteStockAync(int Id)
        {
            return await _stockRepository.DeleteStockAync(Id);
        }
        // start Unit
        [HttpPost("Unit/List")]
        public async Task<List<ProductUnitModel>> GetAllProductUnit(SearchProductUnitModel searchModel)
        {
            return await _unitRepository.GetAllProductUnit(searchModel);
        }
        [HttpGet("Unit/Find/{id}")]
        public async Task<BaseResponse<ProductUnit>> FindProductUnit(int Id)
        {
            return await _unitRepository.FindProductUnit(Id);
        }
        [HttpPost("Unit/Create")]
        public async Task<BaseResponse<ProductUnit>> CreateProductUnit(ProductUnit req)
        {
            return await _unitRepository.CreateProductUnit(req);
        }
        [HttpPut("Unit/Update/{id}")]
        public async Task<BaseResponse<ProductUnit>> UpdateProductUnit(ProductUnit req, int Id)
        {
            return await _unitRepository.UpdateProductUnit(req, Id);
        }
        [HttpDelete("Unit/Delete/{id}")]
        public async Task<BaseResponse<ProductUnit>> DeleteProductUnit(int Id)
        {
            return await _unitRepository.DeleteProductUnit(Id);
        }
        //end Unit

        // inventory
        [HttpPost("Inventory/List")]
        public async Task<List<StockInventoryModel>> GetAllInventoryAsync(StockInventorySearchModel searchModel)
        {
            return await _inventoryRepository.GetAllInventoryAsync(searchModel);
        }
        [HttpPost("GetInventoryByStockAsync")]
        public async Task<BaseResponse<List<Inventory>>> GetInventoryByStockAsync(int stockId, string? filter = "", int? page = 0, int? pageSize = 20)
        {
            var search = !string.IsNullOrEmpty(filter) ? filter.ToLower().Trim() : "";
            if (page >= 1)
            {
                page = (page - 1) * pageSize;
            }
            var item = await _inventoryRepository.GetInventoryByStockAsync(stockId, search, page.GetValueOrDefault(), pageSize.GetValueOrDefault());
            return new BaseResponse<List<Inventory>>
            {
                ResponseCode = "200",
                Message = "",
                Data = item
            };
        }
        [HttpPost("StockOrder/List")]
        public async Task<List<StockOdersModel>> GetAllStockOrderAync(SearchStockOdersModel searchModel)
        {
            return await _stockOrderRepository.GetAllStockOrderAync(searchModel);
        }
        [HttpPost("GetProductStockOrderItems/List")]
        public async Task<List<StockOrderDetailModel>> GetProductStockOrderItemsAync(ApproveInventorySearchModel searchModel)
        {
            return await _stockOrderRepository.GetProductStockOrderItemsAync(searchModel);
        }
        [HttpPost("CreateTicketImport")]
        public async Task<BaseResponse<StockOrder>> CreateTicketImport(InventoryAddDto request)
        {
            var creator_id = 1;
            return await _inventoryRepository.CreateTicketImport(request, creator_id);
        }
        [HttpGet("ApproveInventory/{orderItemId}")]
        public async Task<BaseResponse<Inventory>> ApproveInventory(int orderItemId)
        {
            var creator_id = 1;
            var result = await _inventoryRepository.ApproveInventory(orderItemId, creator_id);
            if (result == "SUCCESS")
            {
                return new BaseResponse<Inventory>
                {
                    Message = "Duyệt thành công! ",
                    ResponseCode = "200"
                };
            }
            else
            {
                return new BaseResponse<Inventory>
                {
                    Message = "Duyệt thất bại! " + result,
                    ResponseCode = "500"
                };
            }
        }
        [HttpPost("CreateTicketTransfer")]
        public async Task<BaseResponse<StockOrder>> CreateTicketTransfer(InventoryTransferDto request)
        {
            var creator_id = 1;
            return await _inventoryRepository.CreateTicketTransfer(request, creator_id);
        }
        [HttpPost("CreateTicketExportPatient")]
        public async Task<BaseResponse<StockOrder>> CreateTicketExportPatient(InventoryExportPatient request)
        {
            var creator_id = 1;
            return await _inventoryRepository.CreateTicketExportPatient(request, creator_id);
        }
        [HttpPost("CreateTicketExportCancel")]
        public async Task<BaseResponse<StockOrder>> CreateTicketExportCancel(InventoryExportCancel request)
        {
            var creator_id = 1;
            return await _inventoryRepository.CreateTicketExportCancel(request, creator_id);
        }
        [HttpGet("ApproveOrder/{orderId}")]
        public async Task<BaseResponse<Inventory>> ApproveOrder(int orderId)
        {
            var creator_id = 1;
            var order = await _context.StockOrders.FirstOrDefaultAsync(x => x.Id == orderId && x.Status == 1);
            if (order == null)
            {
                return new BaseResponse<Inventory>
                {
                    Message = "Phiếu không tồn tại hoặc đã đươc xử lý trước đấy! ",
                    ResponseCode = "500"
                };
            }
            var OrderItems = _context.StockOrderItems.Where(x => x.StockOrderId == order.Id && x.Status == 1).ToList();
            string result = null;
            foreach (var item in OrderItems)
            {
                result = await _inventoryRepository.ApproveInventory(item.Id, creator_id);
            }
            if (result == "SUCCESS")
            {
                return new BaseResponse<Inventory>
                {
                    Message = "Duyệt thành công! ",
                    ResponseCode = "200"
                };
            }
            else
            {
                return new BaseResponse<Inventory>
                {
                    Message = "Duyệt thất bại! " + result,
                    ResponseCode = "500"
                };
            }
        }
        //endinventory
    }
}
