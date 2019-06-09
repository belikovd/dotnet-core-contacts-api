using System;

namespace DotNetCore.DataAccess.Abstractions
{
    public interface ISoftDeletable
    {
        DateTime? DeletedOn { get; set; }
    }
}
