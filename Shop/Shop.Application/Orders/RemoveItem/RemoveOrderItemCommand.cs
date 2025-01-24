using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using FluentValidation;

namespace Shop.Application.Orders.RemoveItem;

public record RemoveOrderItemCommand(long UserId,long ItemId) : IBaseCommand;