using System;

namespace DotNetCore.DataAccess.Abstractions
{
    public interface IDateTimeAuditable
    {
        DateTime CreatedOn { get; set; }
        DateTime ModifiedOn { get; set; }
    }
}
