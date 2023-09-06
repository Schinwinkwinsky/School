using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain;
using School.Domain.Entities;
using School.Domain.Relations;
using System.Net;

namespace School.Application.CQRS.Relations.Students;

public class StudentAddSchoolClassesRequest : IRequest<Student>
{
    public Guid StudentId { get; set; }
    public Guid[] SchoolClassIds { get; set; } = new Guid[0];

    public StudentAddSchoolClassesRequest(Guid studentId, Guid[] schoolClassIds)
    {
        StudentId = studentId;
        SchoolClassIds = schoolClassIds;
    }
}

public class StudentAddSchoolClassesRequestHandler : IRequestHandler<StudentAddSchoolClassesRequest, Student>
{
    private readonly IUnitOfWork _unitOfWork;

    public StudentAddSchoolClassesRequestHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;


    public async Task<Student> Handle(StudentAddSchoolClassesRequest request, CancellationToken cancellationToken)
    {
        var student = await _unitOfWork.Repository<Student>()
            .GetAll()
            .Where(s => s.Id == request.StudentId)
            .Include(s => s.SchoolClassStudent)
            .FirstOrDefaultAsync(cancellationToken);

        if (student is null)
            throw new HttpRequestException($"Student with id = {request.StudentId} was not found.", null, HttpStatusCode.NotFound);

        foreach (var id in request.SchoolClassIds)
        {
            var schoolClass = await _unitOfWork.Repository<SchoolClass>().GetAsync(id, cancellationToken);

            if (schoolClass is not null && !student.SchoolClassStudent.Any(scs => scs.SchoolClassId == schoolClass.Id && scs.StudentId == student.Id))
            {
                var schoolClassStudent = new SchoolClassStudent
                {
                    SchoolClassId = schoolClass.Id,
                    StudentId = student.Id,
                    CreatedAt = DateTime.Now
                };

                student.SchoolClassStudent.Add(schoolClassStudent);
            }
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return student;
    }
}
