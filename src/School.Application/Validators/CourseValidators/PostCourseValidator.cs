﻿using FluentValidation;
using School.Application.CQRS.Generics;
using School.Application.Models;
using School.Domain.Entities;

namespace School.Application.Validators.CourseValidators
{
    public class PostCourseValidator : AbstractValidator<InsertRequest<Course, CourseModel>>
    {
        public PostCourseValidator()
        {
            RuleFor(r => r.Model).SetValidator(new CourseModelValidator());
        }
    }
}
