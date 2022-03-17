using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Author name is required!");
            RuleFor(x => x.AuthorTitle).NotEmpty().WithMessage("Author Title is required!");
            RuleFor(x => x.AuthorImage).NotEmpty().WithMessage("Author image is required!");
            RuleFor(x => x.AuthorAbout).NotEmpty().WithMessage("Author about is required!");
        }
    }
}
