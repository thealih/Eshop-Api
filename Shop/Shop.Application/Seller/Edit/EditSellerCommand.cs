using Common.Application;

namespace Shop.Application.Seller.Edit;

public record EditSellerCommand(long Id , string ShopName , string NationalCode):IBaseCommand
{
    
}