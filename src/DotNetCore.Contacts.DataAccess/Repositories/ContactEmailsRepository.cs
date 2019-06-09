using DotNetCore.Contacts.DataAccess.Abstractions.Repositories;
using DotNetCore.Contacts.DataAccess.Entities;
using DotNetCore.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCore.Contacts.DataAccess.Repositories
{
    public class ContactEmailsRepository : EFCoreRepository<ContactEmail, int>, IContactEmailsRepository
    {
        public ContactEmailsRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<ContactEmail> FindByContactId(int contactId)
        {
            if (contactId <= 0)
                return Enumerable.Empty<ContactEmail>();

            var query = DbSet.AsNoTracking().AsQueryable();

            return query.Where(_ => _.ContactId == contactId).ToList();
        }
    }
}
