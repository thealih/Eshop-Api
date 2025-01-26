using Common.Application;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Seller.AddInventory;

internal class AddSellerInventoryCommandHandler:IBaseCommandHandler<AddSellerInventoryCommand>
{
    ISellerRepository _repository;

    public AddSellerInventoryCommandHandler(ISellerRepository repository)
    {
        _repository = repository;
    }


    public async Task<OperationResult> Handle(AddSellerInventoryCommand request, CancellationToken cancellationToken)
    {
        var seller = await _repository.GetTracking(request.SellerId);
        if (seller == null)
            return OperationResult.NotFound();
        var inventor = new SellerInventory(request.ProductId,request.Count,request.Price,request.PercentageDiscount);
        seller.AddInventory(inventor);
        await _repository.Save();
        return OperationResult.Success();
    }
}