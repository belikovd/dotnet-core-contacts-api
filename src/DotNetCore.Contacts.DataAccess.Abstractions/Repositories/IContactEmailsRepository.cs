using DotNetCore.Contacts.DataAccess.Entities;
using DotNetCore.DataAccess.Abstractions.Repositories;
using System.Collections.Generic;

namespace DotNetCore.Contacts.DataAccess.Abstractions.Repositories
{
    public interface IContactEmailsRepository : IRepository<ContactEmail>
    {
        IEnumerable<ContactEmail> FindByContactId(int contactId);
    }
}
