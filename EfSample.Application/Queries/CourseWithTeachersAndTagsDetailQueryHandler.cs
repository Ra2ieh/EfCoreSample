

namespace EfSample.Application.Queries;

public class CourseWithTeachersAndTagsDetailQueryHandler : IRequestHandler<GetCourseWithTeahcersAndTagsDetailQuery, Result<CourseWithTeachersAndTagsDetailRsponse>>
{
    private readonly ICourseService _courseServices;
    public CourseWithTeachersAndTagsDetailQueryHandler(ICourseService courseServices)
    {
        _courseServices = courseServices;
    }

    public Task<Result<CourseWithTeachersAndTagsDetailRsponse>> Handle(GetCourseWithTeahcersAndTagsDetailQuery request, CancellationToken cancellationToken)
    {
        return _courseServices.GetCourseWithTeachersAndTagsDetails(request.LoadingType);
    }
}
