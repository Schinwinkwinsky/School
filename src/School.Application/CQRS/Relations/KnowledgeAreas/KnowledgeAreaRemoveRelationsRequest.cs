using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.Relations.KnowledgeAreas;

public class KnowledgeAreaRemoveRelationsRequest : IRequest
{
    public Guid KnowledgeAreaId { get; set; }

    public KnowledgeAreaRemoveRelationsRequest(Guid knowledgeAreaId)
    {
        KnowledgeAreaId = knowledgeAreaId;
    }
}

public class KnowledgeAreaRemoveRelationsRequestHandler : IRequestHandler<KnowledgeAreaRemoveRelationsRequest>
{
    private readonly IUnitOfWork _unitOfWork;

    public KnowledgeAreaRemoveRelationsRequestHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task Handle(KnowledgeAreaRemoveRelationsRequest request, CancellationToken cancellationToken)
    {
        var knowledgeArea = await _unitOfWork.Repository<KnowledgeArea>()
            .GetAll()
            .Where(ka => ka.Id == request.KnowledgeAreaId)
            .Include(ka => ka.KnowledgeAreaSubject)
            .Include (ka => ka.KnowledgeAreaTeacher)
            .FirstOrDefaultAsync(cancellationToken);

        if (knowledgeArea is null)
            throw new HttpRequestException($"KnowledgeArea with id = { request.KnowledgeAreaId } was not found.", null, HttpStatusCode.NotFound);

        foreach (var knowledgeAreaSubject in knowledgeArea.KnowledgeAreaSubject)
            if (knowledgeAreaSubject.DeletedAt == default)
                knowledgeAreaSubject.DeletedAt = DateTime.Now;

        foreach (var knowledgeAreaTeacher in knowledgeArea.KnowledgeAreaTeacher)
            if (knowledgeAreaTeacher.DeletedAt == default)
                knowledgeAreaTeacher.DeletedAt = DateTime.Now;

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
