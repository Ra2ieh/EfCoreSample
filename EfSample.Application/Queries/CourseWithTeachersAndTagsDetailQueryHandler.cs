

namespace EfSample.Application.Queries;

public class CourseWithTeachersAndTagsDetailQueryHandler : IRequestHandler<GetCourseWithTeahcersAndTagsDetailEagerQuery, Result<CourseWithTeachersAndTagsDetailRsponse>>
{
    private readonly ICourseService _courseServices;
    public CourseWithTeachersAndTagsDetailQueryHandler(ICourseService courseServices)
    {
        _courseServices = courseServices;
    }

    public Task<Result<CourseWithTeachersAndTagsDetailRsponse>> Handle(GetCourseWithTeahcersAndTagsDetailEagerQuery request, CancellationToken cancellationToken)
    {
        return _courseServices.GetCourseWithTeachersAndTagsDetailsEager();
    }
}
