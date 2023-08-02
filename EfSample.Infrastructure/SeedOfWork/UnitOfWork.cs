namespace EfSample.Infrastructure.SeedOfWork;

public class UnitOfWork : IUnitOfWork
{

    private readonly Lazy<ICourseRepository> _courseRepository;
    private readonly CourseDbContext _context;

    public UnitOfWork(CourseDbContext context)
    {
        _context = context;
        _courseRepository = new Lazy<ICourseRepository>(() => new CourseRepository(_context));

    }

    public ICourseRepository CourseRepository => _courseRepository.Value;

}
