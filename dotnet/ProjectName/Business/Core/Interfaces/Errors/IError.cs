using ProjectName.Business.Core.Enumerations.Errors;

namespace ProjectName.Business.Core.Interfaces.Errors
{
    public interface IError
    {
        ErrorType ErrorType { get; set; }
        string    Key       { get; set; }
        string    Message   { get; set; }
    }
}
