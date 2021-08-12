using Microsoft.AspNetCore.Http;

namespace TR.BenFatto.Application.ViewModels
{
    public class CreatePost
    {
        public IFormFile Arquivo { set; get; }
    }
}
