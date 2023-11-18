namespace Kader_System.Domain.Dtos.Response;

public class Response<T> where T : class
{
    public string Message { get; set; } = string.Empty;
    public bool IsSuccess { get; set; }
    public bool IsActive { get; set; }
    public T Data { get; set; } = default!;
    public string Error { get; set; } = string.Empty;

    //public override string ToString()
    //{
    //    return JsonSerializer.Serialize(this);
    //}
}
