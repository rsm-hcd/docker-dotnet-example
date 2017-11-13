using System.Collections.Generic;

namespace ProjectName.Business.Core.Interfaces.Errors
{
    public interface IResult<T>
    {
        int          ErrorCount   { get; }
        List<IError> Errors       { get; set; }
        bool         HasErrors    { get; }
        T            ResultObject { get; set; }
    }
}
