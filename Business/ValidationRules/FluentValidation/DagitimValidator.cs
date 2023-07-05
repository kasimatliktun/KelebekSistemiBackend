using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class DagitimValidator:AbstractValidator<Dagitim>
    {
        public DagitimValidator()
        {
            RuleFor(s => s.Name).NotEmpty();
            RuleFor(s => s.Name).Length(2, 50);
                     
        }
        
    }
}
