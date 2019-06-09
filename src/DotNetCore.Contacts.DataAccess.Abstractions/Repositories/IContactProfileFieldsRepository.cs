using DotNetCore.Contacts.DataAccess.Entities;
using DotNetCore.DataAccess.Abstractions.Repositories;
using System.Collections.Generic;

namespace DotNetCore.Contacts.DataAccess.Abstractions.Repositories
{
    public interface IContactProfileFieldsRepository : IRepository<ContactProfileField>
    {
        IEnumerable<ContactProfileField> FindByContactId(int contactId);
    }
}
