using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("There must be title!");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("There must be content!");
            RuleFor(x => x.BlogTitle).MinimumLength(3).WithMessage("Please enter a title of at least 3 characters.");
            RuleFor(x => x.BlogTitle).MaximumLength(100).WithMessage("Please write a content of not more than 50 chracters.");
        }
    }
}
