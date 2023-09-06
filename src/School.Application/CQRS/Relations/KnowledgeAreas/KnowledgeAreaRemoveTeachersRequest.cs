using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.Relations.KnowledgeAreas;

public class KnowledgeAreaRemoveTeachersRequest : IRequest<KnowledgeArea>
{
    public Guid KnowledgeAreaId { get; set; }
    public Guid[] TeacherIds { get; set; } = new Guid[0];

    public KnowledgeAreaRemoveTeachersRequest(Guid knowledgeAreaId, Guid[] teacherIds)
    {
        KnowledgeAreaId = knowledgeAreaId;
        TeacherIds = teacherIds;
    }
}

public class KnowledgeAreaRemoveTeachersRequestHandler : IRequestHandler<KnowledgeAreaRemoveTeachersRequest, KnowledgeArea>
{
    private readonly IUnitOfWork _unitOfWork;

    public KnowledgeAreaRemoveTeachersRequestHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<KnowledgeArea> Handle(KnowledgeAreaRemoveTeachersRequest request, CancellationToken cancellationToken)
    {
        var knowledgeArea = await _unitOfWork.Repository<KnowledgeArea>()
            .GetAll()
            .Where(ka => ka.Id == request.KnowledgeAreaId)
            .Include(ka => ka.KnowledgeAreaTeacher)
            .FirstOrDefaultAsync(cancellationToken);

        if (knowledgeArea is null)
            throw new HttpRequestException($"KnowledgeArea with id = { request.KnowledgeAreaId } was not found.", null, HttpStatusCode.NotFound);

        foreach (var id in request.TeacherIds)
        {
            var knowledgeAreaTeacher = knowledgeArea.KnowledgeAreaTeacher.SingleOrDefault(kas => kas.KnowledgeAreaId == knowledgeArea.Id && kas.TeacherId == id && !kas.IsDeleted);

            if (knowledgeAreaTeacher is not null)
                knowledgeAreaTeacher.DeletedAt = DateTime.Now;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return knowledgeArea;
    }
}
