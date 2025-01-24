using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.Products.AddImage
{
    public class AddProductImageCommand:IBaseCommand
    {
        public IFormFile ImageFile { get;private  set; }
        public long ProductId { get;private set; }
        public int Sequence { get;private  set; }
    }
}
