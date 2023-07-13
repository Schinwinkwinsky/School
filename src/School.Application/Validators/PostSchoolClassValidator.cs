using FluentValidation;
using Microsoft.EntityFrameworkCore;
using School.Application.CQRS.Generics;
using School.Application.Models;
using School.Domain;
using School.Domain.Entities;

namespace School.Application.Validators;

public class PostSchoolClassValidator : AbstractValidator<PostRequest<SchoolClass, SchoolClassModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public PostSchoolClassValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        RuleFor(r => r).MustAsync(CheckIfPeriodCourseContainsSubject)
            .WithMessage("Subject must be one of the Period.Course.Subjects.");

        RuleFor(r => r).MustAsync(CheckIfSubjectAndTeacherHasOneCommonKnowledgeArea)
            .WithMessage("Subject and Teacher must have at least one common KnowledgeArea.");
    }

    private async Task<bool> CheckIfSubjectAndTeacherHasOneCommonKnowledgeArea(PostRequest<SchoolClass, SchoolClassModel> request, CancellationToken cancellationToken)
    {
        var subject = await _unitOfWork.Repository<Subject>()
            .GetAll()
            .Where(s => s.Id == request.Model.SubjectId)
            .Include(s => s.KnowledgeAreas)
            .FirstOrDefaultAsync(cancellationToken);

        var teacher = await _unitOfWork.Repository<Teacher>()
            .GetAll()
            .Where(t => t.Id == request.Model.TeacherId)
            .Include (t => t.KnowledgeAreas)
            .FirstOrDefaultAsync(cancellationToken);

        if (subject is null || teacher is null)
            return false;

        return subject.KnowledgeAreas.Intersect(teacher.KnowledgeAreas).Any();
    }

    private async Task<bool> CheckIfPeriodCourseContainsSubject(PostRequest<SchoolClass, SchoolClassModel> request, CancellationToken cancellationToken)
    {
        var period = await _unitOfWork.Repository<Period>()
            .GetAll()
            .Where(p => p.Id == request.Model.PeriodId)
            .Include(p => p.Course)
                .ThenInclude(c => c.Subjects)
            .FirstOrDefaultAsync(cancellationToken);

        if (period is null)
            return false;

        return period.Course.Subjects.Any(s => s.Id == request.Model.SubjectId);
    }
}
