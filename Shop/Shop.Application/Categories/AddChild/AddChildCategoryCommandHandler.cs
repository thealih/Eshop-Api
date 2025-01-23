﻿using Common.Application;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Categories.AddChild;

public class AddChildCategoryCommandHandler:IBaseCommandHandler<AddChildCategoryCommand>
{
    private readonly ICategoryRepository _repository;
    private readonly ICategoryDomainService _domainService;

    public AddChildCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }
    public async Task<OperationResult> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetTracking(request.ParentId);
        if (category == null) return OperationResult.NotFound();
        category.AddChild(request.Title, request.Slug, request.SeoData, _domainService);
        await _repository.Save();
        return OperationResult.Success();
    }
}