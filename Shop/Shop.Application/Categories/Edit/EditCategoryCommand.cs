using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using Common.Domain.ValueObjects;

namespace Shop.Application.Categories.Edit
{
    public record EditCategoryCommand(long Id,string Title, string Slug, SeoData SeoData) : IBaseCommand;
}
