namespace Generic.Common.Interfaces;

public interface IQueryObject
{
    public string Sql { get; set; }
    public object? Parameters { get; set; }
}