using DotNetCore.Common.Types.Enums;
using DotNetCore.DataAccess.Abstractions;
using System;

namespace DotNetCore.Contacts.DataAccess.Entities
{
    public class ContactEmail : IEntity<int>, IDateTimeAuditable, ISoftDeletable
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public EmailAddressType Type { get; set; }
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
