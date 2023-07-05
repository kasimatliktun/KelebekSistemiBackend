using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ExamValidator:AbstractValidator<Exam>
    {
        public ExamValidator()
        {
            RuleFor(s => s.Name).NotEmpty();
            RuleFor(s => s.Name).Length(2, 30);
            RuleFor(s => s.DersSaati).NotEmpty();
            
        }
        
    }
}
