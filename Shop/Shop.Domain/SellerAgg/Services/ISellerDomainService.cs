﻿namespace Shop.Domain.SellerAgg.Services;

public interface ISellerDomainService
{
    bool CheckSellerInfo(Seller seller);
    bool NationalCodeExistInDataBase(string nationalCode);
}