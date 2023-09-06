using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.Relations.Teachers;

public class TeacherRemoveKnowledgeAreasRequest : IRequest<Teacher>
{
    public Guid TeacherId { get; set; }
    public Guid[] KnowledgeAreaIds { get; set; } = new Guid[0];

    public TeacherRemoveKnowledgeAreasRequest(Guid teacherId, Guid[] knowledgeAreaIds)
    {
        TeacherId = teacherId;
        KnowledgeAreaIds = knowledgeAreaIds;
    }
}

public class KnowledgeAreaRemoveTeachersRequestHandler : IRequestHandler<TeacherRemoveKnowledgeAreasRequest, Teacher>
{
    private readonly IUnitOfWork _unitOfWork;

    public KnowledgeAreaRemoveTeachersRequestHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<Teacher> Handle(TeacherRemoveKnowledgeAreasRequest request, CancellationToken cancellationToken)
    {
        var teacher = await _unitOfWork.Repository<Teacher>()
            .GetAll()
            .Where(t => t.Id == request.TeacherId)
            .Include(t => t.KnowledgeAreaTeacher)
            .FirstOrDefaultAsync(cancellationToken);

        if (teacher is null)
            throw new HttpRequestException($"Teacher with id = {request.TeacherId} was not found.", null, HttpStatusCode.NotFound);

        foreach (var id in request.KnowledgeAreaIds)
        {
            var knowledgeAreaTeacher = teacher.KnowledgeAreaTeacher.SingleOrDefault(kat => kat.KnowledgeAreaId == id && kat.TeacherId == teacher.Id && !kat.IsDeleted);

            if (knowledgeAreaTeacher is not null)
                knowledgeAreaTeacher.DeletedAt = DateTime.Now;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return teacher;
    }
}
