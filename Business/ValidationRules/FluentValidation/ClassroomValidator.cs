using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ClassroomValidator:AbstractValidator<Classroom>
    {
        public ClassroomValidator()
        {
            RuleFor(s => s.Name).NotEmpty();
            RuleFor(s => s.Name).Length(2, 10);
                        
        }
        
    }
}
