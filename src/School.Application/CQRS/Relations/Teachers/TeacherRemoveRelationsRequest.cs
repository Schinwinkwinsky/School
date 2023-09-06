using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.Relations.Teachers;

public class TeacherRemoveRelationsRequest : IRequest
{
    public Guid TeacherId { get; set; }

    public TeacherRemoveRelationsRequest(Guid teacherId)
    {
        TeacherId = teacherId;
    }
}

public class SubjectRemoveRelationsRequestHandler : IRequestHandler<TeacherRemoveRelationsRequest>
{
    private readonly IUnitOfWork _unitOfWork;

    public SubjectRemoveRelationsRequestHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task Handle(TeacherRemoveRelationsRequest request, CancellationToken cancellationToken)
    {
        var teacher = await _unitOfWork.Repository<Teacher>()
            .GetAll()
            .Where(s => s.Id == request.TeacherId)
            .Include(s => s.KnowledgeAreaTeacher)
            .FirstOrDefaultAsync(cancellationToken);

        if (teacher is null)
            throw new HttpRequestException($"Teacher with id = {request.TeacherId} was not found.", null, HttpStatusCode.NotFound);

        foreach (var knowledgeAreaTeacher in teacher.KnowledgeAreaTeacher)
            if (knowledgeAreaTeacher.DeletedAt == default)
                knowledgeAreaTeacher.DeletedAt = DateTime.Now;

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
