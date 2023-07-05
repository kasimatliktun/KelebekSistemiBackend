using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class LessonValidator:AbstractValidator<Lesson>
    {
        public LessonValidator()
        {
            RuleFor(s => s.Name).NotEmpty();
            RuleFor(s => s.Name).Length(2, 30);
            RuleFor(s => s.Duration).NotEmpty();
            
        }
        
    }
}
