using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(s => s.FirstName).NotEmpty();
            RuleFor(s => s.FirstName).Length(3, 20);
            RuleFor(s => s.LastName).Length(2, 20);
            RuleFor(s => s.Password).Length(5, 20);
            RuleFor(s => s.Email).NotEmpty();
            RuleFor(s => s.Email).EmailAddress();
            RuleFor(s => s.Email).MinimumLength(10);
            RuleFor(s => s.Email).MaximumLength(35);
            RuleFor(s => s.Numara). NotEmpty();
            RuleFor(s => s.Sinif). NotEmpty();                        
        }

    }
}
