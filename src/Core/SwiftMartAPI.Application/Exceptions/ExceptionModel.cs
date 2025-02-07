using Newtonsoft.Json;

namespace SwiftMartAPI.Application.Exceptions;

public class ExceptionModel
{
    public IEnumerable<string>? Errors { get; set; }
    public int StatusCode { get; set; }
    public override string ToString()
        => JsonConvert.SerializeObject(this);

}