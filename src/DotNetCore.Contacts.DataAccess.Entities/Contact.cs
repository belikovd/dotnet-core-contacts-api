using DotNetCore.DataAccess.Abstractions;
using System;

namespace DotNetCore.Contacts.DataAccess.Entities
{
    public class Contact : IEntity<int>, IDateTimeAuditable, ISoftDeletable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public string MainAddress { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
