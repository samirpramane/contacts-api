using ContactsManager.Core;
using System;

namespace ContactsManager.Data
{
    public interface IContactUnitOfWork : IDisposable
    {
        IGenericRepository<Contact> ContactRepository { get; }
        void Save();
    }
}
