using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain;
using School.Domain.Entities;
using School.Domain.Relations;
using System.Net;

namespace School.Application.CQRS.Relations.KnowledgeAreas;

public class KnowledgeAreaAddTeachersRequest : IRequest<KnowledgeArea>
{
    public Guid KnowledgeAreaId { get; set; }
    public Guid[] TeacherIds { get; set; } = new Guid[0];

    public KnowledgeAreaAddTeachersRequest(Guid knowledgeAreaId, Guid[] teacherIds)
    {
        KnowledgeAreaId = knowledgeAreaId;
        TeacherIds = teacherIds;
    }
}

public class KnowledgeAreaAddTeachersRequestHandler : IRequestHandler<KnowledgeAreaAddTeachersRequest, KnowledgeArea>
{
    private readonly IUnitOfWork _unitOfWork;

    public KnowledgeAreaAddTeachersRequestHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<KnowledgeArea> Handle(KnowledgeAreaAddTeachersRequest request, CancellationToken cancellationToken)
    {
        var knowledgeArea = await _unitOfWork.Repository<KnowledgeArea>()
            .GetAll()
            .Where(ka => ka.Id == request.KnowledgeAreaId)
            .Include(ka => ka.KnowledgeAreaTeacher)
            .FirstOrDefaultAsync(cancellationToken);

        if (knowledgeArea is null)
            throw new HttpRequestException($"KnowledgeArea with id = {request.KnowledgeAreaId} was not found.", null, HttpStatusCode.NotFound);

        foreach (var id in request.TeacherIds)
        {
            var teacher = await _unitOfWork.Repository<Teacher>().GetAsync(id, cancellationToken);

            if (teacher is not null && !knowledgeArea.KnowledgeAreaTeacher.Any(kat => kat.KnowledgeAreaId == knowledgeArea.Id && kat.TeacherId == teacher.Id))
            {
                var knowledgeAreaTeacher = new KnowledgeAreaTeacher
                {
                    KnowledgeAreaId = knowledgeArea.Id,
                    TeacherId = teacher.Id,
                    CreatedAt = DateTime.Now
                };

                knowledgeArea.KnowledgeAreaTeacher.Add(knowledgeAreaTeacher);
            }
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return knowledgeArea;
    }
}
