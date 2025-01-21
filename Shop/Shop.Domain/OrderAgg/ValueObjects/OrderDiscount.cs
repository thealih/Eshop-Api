using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;

namespace Shop.Domain.OrderAgg.ValueObjects
{
    public class OrderDiscount:ValueObject
    {
        public OrderDiscount(int discountAmount, string discountTitle)
        {
            DiscountAmount = discountAmount;
            DiscountTitle = discountTitle;
        }

        public string DiscountTitle { get; private set; }
        public int DiscountAmount { get; private set; }
    }
}
