using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.BenFatto.Domain.Interfaces
{
    public interface ICreatePostRepository
    {
        bool ProcessFile(IFormFile file);
    }
}
