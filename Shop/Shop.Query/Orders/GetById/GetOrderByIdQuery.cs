﻿using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.GetById;

public record GetOrderByIdQuery(long OrderId) : IQuery<OrderDto?>;

internal class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery , OrderDto?>
{
    private ShopContext _shopContext;
    private DapperContext _dapperContext;

    public GetOrderByIdQueryHandler(ShopContext shopContext, DapperContext dapperContext)
    {
        _shopContext = shopContext;
        _dapperContext = dapperContext;
    }
    public async Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order =await _shopContext.Orders
            .FirstOrDefaultAsync(f => f.Id == request.OrderId, cancellationToken);
        if (order == null)
            return null;

        var orderDto = order.Map();
        orderDto.UserFullName = await _shopContext.Users.Where(f => f.Id == orderDto.UserId)
            .Select(s => $"{s.Name} {s.Family}").FirstAsync();
    }
}