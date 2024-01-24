using AutoMapper;
using Nencer.Modules.Product.Model;

namespace Nencer.Modules.Product.Repository
{
    public interface IStockOrderRepository
    {
        Task<List<StockOdersModel>> GetAllStockOrderAync(SearchStockOdersModel searchModel);
        Task<List<StockOrderDetailModel>> GetProductStockOrderItemsAync(ApproveInventorySearchModel searchModel);
    }

    public class StockOrderRepository : IStockOrderRepository
    {
        private readonly NencerDbContext _context;
        private readonly IMapper _mapper;

        public StockOrderRepository(NencerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<StockOdersModel>> GetAllStockOrderAync(SearchStockOdersModel searchModel)
        {
            using (var _context = new NencerDbContext())
            {
                var lstData = (from stockOrder in _context.StockOrders
                               join productSupplier in _context.ProductSuppliers on stockOrder.SupplierId equals productSupplier.Id into joinedProductSuppliers
                               from productSupplier in joinedProductSuppliers.DefaultIfEmpty()
                               join stock in _context.Stocks on stockOrder.StockId equals stock.Id into joinedStocks
                               from stock in joinedStocks.DefaultIfEmpty()
                               join targetStock in _context.Stocks on stockOrder.TargetStockId equals targetStock.Id into joinedTargetStock
                               from targetStock in joinedTargetStock.DefaultIfEmpty()
                               join department in _context.Departments on stockOrder.DepartmentId equals department.Id into joinedDepartments
                               from department in joinedDepartments.DefaultIfEmpty()
                               join room in _context.Rooms on stockOrder.RoomId equals room.Id into joinedRooms
                               from room in joinedRooms.DefaultIfEmpty()
                               join patient in _context.Patients on stockOrder.CustomerId equals patient.Id into joinedPatients
                               from patient in joinedPatients.DefaultIfEmpty()
                               where stockOrder.IsDel == 1
                               select new StockOdersModel
                               {
                                   Id = stockOrder.Id,
                                   Code = stockOrder.Code,
                                   Type = stockOrder.Type,
                                   Coupon = stockOrder.Type.ToString(),
                                   Supplier = productSupplier.Name,
                                   Stock = stock.Name,
                                   TargetStock = targetStock.Name,
                                   Status = stockOrder.Status.ToString(),
                                   ImportDate = stockOrder.CreatedAt,
                                   ApproveDate = stockOrder.ApproveDate,
                                   ExportDate = stockOrder.ExportDate,
                                   DepartmentRoom = department.Name + " - " + room.Name,
                                   Name = patient.Name,
                                   Note = stockOrder.Note,
                                   CreatedAt = stockOrder.CreatedAt
                               })
                               .OrderByDescending(c => c.CreatedAt)
                               .Skip(searchModel.SkipCount)
                               .Take(searchModel.MaxResultCount)
                               .ToList();

                if (searchModel.Type > 0)
                {
                    lstData = lstData.Where(x => x.Type != null && x.Type == searchModel.Type).ToList();
                }

                // Then, retrieve the total count separately
                int totalCount = _context.ProductCates.Count();
                if (lstData.Count > 0 && lstData[0] != null)
                {
                    lstData[0].TotalCount = totalCount;
                }

                return lstData;
            }
        }

        public async Task<List<StockOrderDetailModel>> GetProductStockOrderItemsAync(ApproveInventorySearchModel searchModel)
        {
            using (var _context = new NencerDbContext())
            {
                var lstData = (from stockOrderItem in _context.StockOrderItems
                               join product in _context.Products on stockOrderItem.ProductId equals product.Id into joinedProducts
                               from product in joinedProducts.DefaultIfEmpty()
                               join productBid in _context.ProductBids on stockOrderItem.BidId equals productBid.Id into joinedProductBids
                               from productBid in joinedProductBids.DefaultIfEmpty()
                               where stockOrderItem.StockOrderId == searchModel.StockOdersId
                               select new StockOrderDetailModel
                               {
                                   Name = product.Name,
                                   Concentration = product.Concentration,
                                   Content = product.Content,
                                   Quantity = stockOrderItem.Qty,
                                   Price = stockOrderItem.Price,
                                   TotalPrice = stockOrderItem.Qty * stockOrderItem.Price,
                                   LotCode = stockOrderItem.LotCode,
                                   BidDecisionNumber = productBid.BidPackage,
                                   ContractorGroup = productBid.BidGroup,
                                   BidId = stockOrderItem.BidId.ToString(),
                                   BidYear = productBid.BidYear,
                               })
                               .Skip(searchModel.SkipCount)
                               .Take(searchModel.MaxResultCount)
                               .ToList();

                // Then, retrieve the total count separately
                int totalCount = _context.StockOrderItems.Where(x => x.StockOrderId == searchModel.StockOdersId).Count();
                if (lstData.Count > 0 && lstData[0] != null)
                {
                    lstData[0].TotalCount = totalCount;
                }

                return lstData;
            }
        }
    }
}
