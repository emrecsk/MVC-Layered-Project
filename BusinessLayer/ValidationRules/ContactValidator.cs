using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail address cannot be empty!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname cannot be empty!");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Message area cannot be empty!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject cannot be empty!");
        }
    }
}
