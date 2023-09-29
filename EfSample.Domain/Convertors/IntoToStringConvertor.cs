namespace EfSample.Domain.Convertors;

public class IntoToStringConvertor : ValueConverter<int, string>
{
    public IntoToStringConvertor() : base(c=>c.ToString(),c=>int.Parse(c))
    {
    }
}
