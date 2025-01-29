using Common.Domain.ValueObjects;

namespace Shop.Query.Categories.DTOs;

public class CategoryDto
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
    public List<ChildCategoryDto> Children { get; set; }
}

public class ChildCategoryDto
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
    public long? ParentId { get; set; }
    public List<ChildCategoryDto> Children { get; set; }
}

public class SecondaryChildCategoryDto
{

}