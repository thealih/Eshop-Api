using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Exceptions
{
    public class SlugIsDuplicatedException : BaseDomainException
    {
        public SlugIsDuplicatedException():base("slug تکراری است.")
        {

        }
        public SlugIsDuplicatedException(string message) : base(message) { }
    }
}
