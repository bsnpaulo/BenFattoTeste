using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.BenFatto.Application.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [DisplayName("Categoria")]
        public string Name { get; set; }

        public ICollection<ProductViewModel> Products { get; set; }
    }
}
