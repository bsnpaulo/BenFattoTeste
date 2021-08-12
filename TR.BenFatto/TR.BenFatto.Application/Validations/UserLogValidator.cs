using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.BenFatto.Application.ViewModels;

namespace TR.BenFatto.Application.Validations
{
    public class UserLogValidator : AbstractValidator<UserLogViewModel>
    {
        public UserLogValidator()
        {
            RuleFor(u => u.IpAdress)
                .NotEmpty()
                .WithMessage("Informe o IP.");

            RuleFor(u => u.NormalizedDate)
                .NotEmpty()
                .WithMessage("Informe a data.");

            RuleFor(u => u.UserAgent)
                .NotEmpty()
                .WithMessage("Informe o user agent.");
        }
    }
}
