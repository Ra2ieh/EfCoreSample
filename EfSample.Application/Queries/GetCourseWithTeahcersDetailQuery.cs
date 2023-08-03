namespace EfSample.Application.Queries;

public class GetCourseWithTeahcersDetailQuery:IRequest<Result<CourseWithTeachersDetailsResponse>>
{
    public LoadingTypes LoadingType { get; set; }
}

