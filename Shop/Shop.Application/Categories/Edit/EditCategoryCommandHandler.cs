﻿using Common.Application;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Categories.Edit;

public class EditCategoryCommandHandler : IBaseCommandHandler<EditCategoryCommand>
{
    private readonly ICategoryDomainService _domainService;
    private readonly ICategoryRepository _repository;

    public EditCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }

    public async Task<OperationResult> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetTracking(request.Id);
        if (category == null) return OperationResult.NotFound();
        category.Edit(request.Title, request.Slug, request.SeoData, _domainService);
        await _repository.Save();
        return OperationResult.Success();
    }
}