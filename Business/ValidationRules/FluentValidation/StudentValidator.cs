using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class StudentValidator:AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(s => s.Name).NotEmpty();
            RuleFor(s => s.Name).Length(2, 30);
            RuleFor(s => s.Gender).NotEmpty();
            RuleFor(s => s.ClassId).GreaterThanOrEqualTo(1);
            //RuleFor(s => s.UnitPrice).GreaterThanOrEqualTo(10).When(s => s.CategoryId == 1);            
        }

        private bool StartWithWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
