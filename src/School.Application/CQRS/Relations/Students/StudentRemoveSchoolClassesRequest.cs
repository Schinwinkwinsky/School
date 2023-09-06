using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.Relations.Students;

public class StudentRemoveSchoolClassesRequest : IRequest<Student>
{
    public Guid StudentId { get; set; }
    public Guid[] SchoolClassIds { get; set; } = new Guid[0];

    public StudentRemoveSchoolClassesRequest(Guid studentId, Guid[] schoolClassIds)
    {
        StudentId = studentId;
        SchoolClassIds = schoolClassIds;
    }
}

public class StudentRemoveSchoolClassesRequestHandler : IRequestHandler<StudentRemoveSchoolClassesRequest, Student>
{
    private readonly IUnitOfWork _unitOfWork;

    public StudentRemoveSchoolClassesRequestHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<Student> Handle(StudentRemoveSchoolClassesRequest request, CancellationToken cancellationToken)
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
            var schoolClassStudent = student.SchoolClassStudent.SingleOrDefault(scs => scs.SchoolClassId == id && scs.StudentId == student.Id && !scs.IsDeleted);

            if (schoolClassStudent is not null)
                schoolClassStudent.DeletedAt = DateTime.Now;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return student;
    }
}
