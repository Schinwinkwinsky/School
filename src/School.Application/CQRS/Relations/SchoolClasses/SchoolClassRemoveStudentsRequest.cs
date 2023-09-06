using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.Relations.SchoolClasses;

public class SchoolClassRemoveStudentsRequest : IRequest<SchoolClass>
{
    public Guid SchoolClassId { get; set; }
    public Guid[] StudentIds { get; set; } = new Guid[0];

    public SchoolClassRemoveStudentsRequest(Guid schoolClassId, Guid[] studentIds)
    {
        SchoolClassId = schoolClassId;
        StudentIds = studentIds;
    }
}

public class SchoolClassRemoveStudentsRequestHandler : IRequestHandler<SchoolClassRemoveStudentsRequest, SchoolClass>
{
    private readonly IUnitOfWork _unitOfWork;

    public SchoolClassRemoveStudentsRequestHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<SchoolClass> Handle(SchoolClassRemoveStudentsRequest request, CancellationToken cancellationToken)
    {
        var schoolClass = await _unitOfWork.Repository<SchoolClass>()
            .GetAll()
            .Where(sc => sc.Id == request.SchoolClassId)
            .Include(sc => sc.SchoolClassStudent)
            .FirstOrDefaultAsync(cancellationToken);

        if (schoolClass is null)
            throw new HttpRequestException($"SchoolClass with id = {request.SchoolClassId} was not found.", null, HttpStatusCode.NotFound);

        foreach (var id in request.StudentIds)
        {
            var schoolClassStudent = schoolClass.SchoolClassStudent.SingleOrDefault(scs => scs.SchoolClassId == schoolClass.Id && scs.StudentId == id && !scs.IsDeleted);

            if (schoolClassStudent is not null)
                schoolClassStudent.DeletedAt = DateTime.Now;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return schoolClass;
    }
}
