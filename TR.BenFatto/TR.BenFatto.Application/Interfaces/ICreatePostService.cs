using TR.BenFatto.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.BenFatto.Application.Interfaces
{
    public interface ICreatePostService
    {        
        bool ProcessFile(CreatePost file);
    }
}
