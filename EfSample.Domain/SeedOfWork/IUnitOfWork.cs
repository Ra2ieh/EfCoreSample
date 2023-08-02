

namespace EfSample.Domain.SeedOfWork;

public interface IUnitOfWork
{
    public ICourseRepository CourseRepository { get; }



}
