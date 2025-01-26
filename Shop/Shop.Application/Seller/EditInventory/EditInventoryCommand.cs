using Common.Application;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Seller.EditInventory;

public class EditInventoryCommand:IBaseCommand
{
    public EditInventoryCommand(long sellerId, long inventoryId, int count, int price, int? discountPercentage)
    {
        SellerId = sellerId;
        InventoryId = inventoryId;
        Count = count;
        Price = price;
        DiscountPercentage = discountPercentage;
    }
    public long SellerId { get; private set; }
    public long InventoryId { get; private set; }
    public int Count { get; private set; }
    public int Price { get; private set; }
    public int? DiscountPercentage { get; private set; }
}
internal class EditInventoryCommandHandler:IBaseCommandHandler<EditInventoryCommand>
{
    private readonly ISellerRepository _repository;

    public EditInventoryCommandHandler(ISellerRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(EditInventoryCommand request, CancellationToken cancellationToken)
    {
        var seller = await _repository.GetTracking(request.SellerId);
        if (seller == null)
            return OperationResult.NotFound();
        seller.EditInventory(request.InventoryId,request.Count,request.Price,request.DiscountPercentage);
        await _repository.Save();
        return OperationResult.Success();
    }
}