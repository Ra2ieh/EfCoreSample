

namespace EfSample.Application.Queries;

public  class GetCourseWithTeahcersAndTagsDetailQuery:IRequest<Result<CourseWithTeachersAndTagsDetailRsponse>>
{
    public LoadingTypes LoadingType { get; set; }
}
