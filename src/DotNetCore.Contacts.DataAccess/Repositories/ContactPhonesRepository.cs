using DotNetCore.Contacts.DataAccess.Abstractions.Repositories;
using DotNetCore.Contacts.DataAccess.Entities;
using DotNetCore.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCore.Contacts.DataAccess.Repositories
{
    public class ContactPhonesRepository : EFCoreRepository<ContactPhone, int>, IContactPhonesRepository
    {
        public ContactPhonesRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<ContactPhone> FindByContactId(int contactId)
        {
            if (contactId <= 0)
                return Enumerable.Empty<ContactPhone>();

            var query = DbSet.AsNoTracking().AsQueryable();

            return query.Where(_ => _.ContactId == contactId).ToList();
        }
    }
}
