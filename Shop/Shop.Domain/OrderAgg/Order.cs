﻿using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.OrderAgg.ValueObjects;

namespace Shop.Domain.OrderAgg;

public class Order : AggregateRoot
{
    private Order()
    {
    }

    public Order(long userId)
    {
        UserId = userId;
        Status = OrderStatus.Pending;
        Items = new List<OrderItem>();
    }

    public long UserId { get; set; }
    public OrderStatus Status { get; private set; }
    public OrderDiscount? Discount { get; private set; }
    public OrderAddress? Address { get; private set; }
    public ShippingMethod? ShippingMethod { get; private set; }
    public DateTime? LastUpdate { get; set; }
    public List<OrderItem> Items { get; }

    public int TotalPrice
    {
        get
        {
            var totalPrice = Items.Sum(f => f.TotalPrice);
            if (ShippingMethod != null)
            {
                totalPrice += ShippingMethod.ShippingCost;
            }

            if (Discount != null)
            {
                totalPrice -= Discount.DiscountAmount;
            }
            return totalPrice;
        }
    }
    public int ItemCount => Items.Count;

    public void AddItem(OrderItem item)
    {
        Items.Add(item);
    }

    public void RemoveItem(long itemId)
    {
        var currentItems = Items.FirstOrDefault(f => f.Id == itemId);
        if (currentItems != null) Items.Remove(currentItems);
    }

    public void ChangeCountItem(long itemId, int newCount)
    {
        var currentItems = Items.FirstOrDefault(f => f.Id == itemId);
        if (currentItems == null) throw new NullOrEmptyDomainDataException();
        currentItems.ChangeCount(newCount);
    }

    public void ChangeStatus(OrderStatus status)
    {
        Status = status;
        LastUpdate = DateTime.Now;
    }

    public void Checkout(OrderAddress orderAddress)
    {
        Address = orderAddress;
    }
}