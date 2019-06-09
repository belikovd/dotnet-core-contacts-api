using DotNetCore.Contacts.DataAccess.Entities;
using DotNetCore.DataAccess.Abstractions.Repositories;

namespace DotNetCore.Contacts.DataAccess.Abstractions.Repositories
{
    public interface IContactsRepository : IRepository<Contact>
    {
    }
}
