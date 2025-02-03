using Common.Domain.Repository;
using Shop.Domain.OrderAgg.ValueObjects;

namespace Shop.Domain.SiteEntities.Repositories;

public interface IShippingMethodRepository : IBaseRepository<ShippingMethod>
{
    void Delete(ShippingMethod method);
}