using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.Relations.Students;

public class StudentRemoveRelationsRequest : IRequest
{
    public Guid StudentId { get; set; }

    public StudentRemoveRelationsRequest(Guid studentId)
    {
        StudentId = studentId;
    }
}

public class StudentRemoveRelationsRequestHandler : IRequestHandler<StudentRemoveRelationsRequest>
{
    private readonly IUnitOfWork _unitOfWork;

    public StudentRemoveRelationsRequestHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task Handle(StudentRemoveRelationsRequest request, CancellationToken cancellationToken)
    {
        var student = await _unitOfWork.Repository<Student>()
            .GetAll()
            .Where(s => s.Id == request.StudentId)
            .Include(s => s.SchoolClassStudent)
            .FirstOrDefaultAsync(cancellationToken);

        if (student is null)
            throw new HttpRequestException($"Student with id = {request.StudentId} was not found.", null, HttpStatusCode.NotFound);

        foreach (var schoolClassStudent in student.SchoolClassStudent)
            if (schoolClassStudent.DeletedAt == default)
                schoolClassStudent.DeletedAt = DateTime.Now;

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
