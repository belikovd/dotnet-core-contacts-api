using DotNetCore.Common.Types.Enums;
using DotNetCore.DataAccess.Abstractions;
using System;

namespace DotNetCore.Contacts.DataAccess.Entities
{
    public class ContactPhone : IEntity<int>, IDateTimeAuditable, ISoftDeletable
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public PhoneNumberType Type { get; set; }
        public string Number { get; set; }
        public string Extension { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
