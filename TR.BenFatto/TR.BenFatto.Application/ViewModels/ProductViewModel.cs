using TR.BenFatto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.BenFatto.Application.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do produto.")]
        [MinLength(5)]
        [MaxLength(150)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Informe os pontos do produto.")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DisplayName("Pontos")]
        public int Points { get; set; }

        public int CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}
