using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace Shop.Application.Orders.DecreaseItemCount
{
    public record DecreaseOrderItemCountCommand(long UserId, long ItemId, int Count) : IBaseCommand;
}
