using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace Shop.Application.Orders.IncreaseItemCount
{
    public record IncreaseOrderItemCount(long UserId, long ItemId, int Count):IBaseCommand;
}
