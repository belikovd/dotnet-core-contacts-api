using DotNetCore.DataAccess.Abstractions;
using System;

namespace DotNetCore.Contacts.DataAccess.Entities
{
    public class ContactProfileField : IEntity<int>, IDateTimeAuditable, ISoftDeletable
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
