using DotNetCore.Contacts.DataAccess.Abstractions.Repositories;
using DotNetCore.Contacts.DataAccess.Entities;
using DotNetCore.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore.Contacts.DataAccess.Repositories
{
    public class ContactsRepository : EFCoreRepository<Contact, int>, IContactsRepository
    {
        public ContactsRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
