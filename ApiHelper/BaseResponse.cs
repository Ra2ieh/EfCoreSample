namespace ApiHelper;

public class  Result<T> where T:class 
{
    public T? Data { get; set; }
    public CustomError? Error { get; set; }
}
