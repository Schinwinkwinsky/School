using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain;
using School.Domain.Entities;
using School.Domain.Relations;
using System.Net;

namespace School.Application.CQRS.Relations.Teachers;

public class TeacherAddKnowledgeAreasRequest : IRequest<Teacher>
{
    public Guid TeacherId { get; set; }
    public Guid[] KnowledgeAreaIds { get; set; } = new Guid[0];

    public TeacherAddKnowledgeAreasRequest(Guid subjectId, Guid[] knowledgeAreaIds)
    {
        TeacherId = subjectId;
        KnowledgeAreaIds = knowledgeAreaIds;
    }
}

public class TeacherAddKnowledgeAreasRequestHandler : IRequestHandler<TeacherAddKnowledgeAreasRequest, Teacher>
{
    private readonly IUnitOfWork _unitOfWork;

    public TeacherAddKnowledgeAreasRequestHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<Teacher> Handle(TeacherAddKnowledgeAreasRequest request, CancellationToken cancellationToken)
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
            var knowledgeArea = await _unitOfWork.Repository<KnowledgeArea>().GetAsync(id, cancellationToken);

            if (knowledgeArea is not null && !teacher.KnowledgeAreaTeacher.Any(kat => kat.KnowledgeAreaId == knowledgeArea.Id && kat.TeacherId == teacher.Id))
            {
                var knowledgeAreaTeacher = new KnowledgeAreaTeacher
                {
                    KnowledgeAreaId = knowledgeArea.Id,
                    TeacherId = teacher.Id,
                    CreatedAt = DateTime.Now
                };

                teacher.KnowledgeAreaTeacher.Add(knowledgeAreaTeacher);
            }
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return teacher;
    }
}