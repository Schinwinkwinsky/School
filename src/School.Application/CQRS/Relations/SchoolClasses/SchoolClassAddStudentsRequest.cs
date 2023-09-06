using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain;
using School.Domain.Entities;
using School.Domain.Relations;
using System.Net;

namespace School.Application.CQRS.Relations.SchoolClasses;

public class SchoolClassAddStudentsRequest : IRequest<SchoolClass>
{
    public Guid SchoolClassId { get; set; }
    public Guid[] StudentIds { get; set; } = new Guid[0];

    public SchoolClassAddStudentsRequest(Guid schoolClassId, Guid[] studentIds)
    {
        SchoolClassId = schoolClassId;
        StudentIds = studentIds;
    }
}

public class SchoolClassAddStudentsRequestHandler : IRequestHandler<SchoolClassAddStudentsRequest, SchoolClass>
{
    private readonly IUnitOfWork _unitOfWork;

    public SchoolClassAddStudentsRequestHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;


    public async Task<SchoolClass> Handle(SchoolClassAddStudentsRequest request, CancellationToken cancellationToken)
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
            var student = await _unitOfWork.Repository<Student>().GetAsync(id, cancellationToken);

            if (student is not null && !schoolClass.SchoolClassStudent.Any(scs => scs.SchoolClassId == schoolClass.Id && scs.StudentId == student.Id))
            {
                var schoolClassStudent = new SchoolClassStudent
                {
                    SchoolClassId = schoolClass.Id,
                    StudentId = student.Id,
                    CreatedAt = DateTime.Now
                };

                schoolClass.SchoolClassStudent.Add(schoolClassStudent);
            }
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return schoolClass;
    }
}
