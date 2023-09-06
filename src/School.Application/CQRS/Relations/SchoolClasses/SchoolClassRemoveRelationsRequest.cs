using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.Relations.SchoolClasses;

public class SchoolClassRemoveRelationsRequest : IRequest
{
    public Guid SchoolClassId { get; set; }

    public SchoolClassRemoveRelationsRequest(Guid schoolClassId)
    {
        SchoolClassId = schoolClassId;
    }
}

public class SchoolClassRemoveRelationsRequestHandler : IRequestHandler<SchoolClassRemoveRelationsRequest>
{
    private readonly IUnitOfWork _unitOfWork;

    public SchoolClassRemoveRelationsRequestHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task Handle(SchoolClassRemoveRelationsRequest request, CancellationToken cancellationToken)
    {
        var schoolClass = await _unitOfWork.Repository<SchoolClass>()
            .GetAll()
            .Where(sc => sc.Id == request.SchoolClassId)
            .Include(sc => sc.SchoolClassStudent)
            .FirstOrDefaultAsync(cancellationToken);

        if (schoolClass is null)
            throw new HttpRequestException($"SchoolClass with id = {request.SchoolClassId} was not found.", null, HttpStatusCode.NotFound);

        foreach (var schoolClassStudent in schoolClass.SchoolClassStudent)
            if (schoolClassStudent.DeletedAt == default)
                schoolClassStudent.DeletedAt = DateTime.Now;

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
