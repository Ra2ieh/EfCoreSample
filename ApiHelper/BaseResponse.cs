namespace ApiHelper;

public class  Result<T> where T:class 
{
    public Result()
    {
        Error = new CustomError();
    }

    public T Data { get; set; }
    public CustomError Error { get; set; }
    public bool HasError { get; set; } = false;
    public Result<T> SetError(CustomError error)
    {
        Error = error;
        HasError = true;
        return this;
    }
}
